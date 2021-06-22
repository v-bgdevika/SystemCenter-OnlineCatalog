IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ManagementPackDependenciesGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE ManagementPackDependenciesGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON ManagementPackDependenciesGet TO "SystemCenter_user"
GRANT EXECUTE ON ManagementPackDependenciesGet TO "SystemCenter_admin"
GO


ALTER PROC dbo.ManagementPackDependenciesGet
(
     @ManagementPackXml            xml               --INPUT Management Packs whose information is to be returned
    ,@ProductName                  nvarchar(1024)    -- INPUT expects Product name of the client
    ,@ProductVersion               nvarchar(25)      -- INPUT expects Product version of the client
)
AS


/****************************************************************************

PROCEDURE NAME: ManagementPackExtendedInfoGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 08/28/2008

DESCRIPTION:
------------
This store procedure is used to return the direct and indirect dependencies
of a given set of management packs.

Sample Xml for ManagementPackXml
<ManagementPacks>
<ManagementPack VersionIndependentGuid="version_independent_guid1" Version="6.0.6278.0" />
<ManagementPack VersionIndependentGuid="version_independent_guid2" Version="6.0.6278.10" />
</ManagementPacks>

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         08/29/2008       maaakash      Created Stored Procedure.

****************************************************************************/


BEGIN

  SET NOCOUNT ON

  DECLARE 
     @ErrorInd        bit
    ,@ErrorMessage    nvarchar(max)
    ,@ErrorNumber     int
    ,@ErrorSeverity   int
    ,@ErrorState      int
    ,@ErrorLine       int
    ,@ErrorProcedure  nvarchar(256)
    ,@ErrorMessageText nvarchar(max)
    
    ,@XmlDocHandle    int
    ,@ExecResult      int

  SET @ErrorInd = 0

  BEGIN TRY


  -- Create temp table   
  CREATE TABLE #ManagementPack (
    VersionIndependentGuid uniqueidentifier
  )
  

  IF @ManagementPackXml IS NOT NULL 
  BEGIN
    -- Read the Xml
       EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @ManagementPackXml
       IF @ExecResult <> 0 RAISERROR('TODO: Fix this error message',16, 1, @ExecResult)


    -- Populate temp table 
    INSERT #ManagementPack(VersionIndependentGuid)
      SELECT VersionIndependentGuid FROM OPENXML (@XmlDocHandle, '/ManagementPacks/ManagementPack',1) WITH (VersionIndependentGuid uniqueidentifier)
  END



  -- Create dependencies table
  CREATE TABLE #ManagementPackDependencies
  (
     BaseMpVersionIndependentGuid      uniqueidentifier
    ,BaseMpVersion                     varchar(32)
    ,DependentMpVersionIndependentGuid uniqueidentifier
    ,DependentMpVersion                varchar(32)
    ,Depth                             int
  )

  
  DECLARE 
    @Depth  int
    
  set @Depth = 1
  
  WHILE EXISTS(Select * from #ManagementPack)
  BEGIN

  
    --Get the latest version of the CurrentMP and their dependencies
   INSERT #ManagementPackDependencies(BaseMpVersionIndependentGuid,BaseMpVersion,DependentMpVersionIndependentGuid,DependentMpVersion,Depth)
    SELECT 
       m.VersionIndependentGuid
      ,m.Version
      ,dep.DependentMpVersionIndependentGuid
      ,dep.DependentMpVersion
      ,@Depth
    FROM
      #ManagementPack AS c
        JOIN CatalogManagementPack AS m ON c.VersionIndependentGuid = m.VersionIndependentGuid
        JOIN CatalogItem AS ci ON ci.CatalogItemId = m.CatalogItemId and PublishedInd = 'true'
        JOIN CatalogManagementPackDependency AS dep ON m.CatalogItemId = dep.ManagementPackCatalogItemId
        JOIN CatalogProductCatalogItem AS pc ON m.CatalogItemId = pc.CatalogItemId
        JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
    WHERE
      NOT EXISTS (SELECT BaseMpVersionIndependentGuid FROM #ManagementPackDependencies where BaseMpVersionIndependentGuid = m.VersionIndependentGuid) 


	DELETE FROM #ManagementPack
	
   INSERT #ManagementPack(VersionIndependentGuid)
	SELECT DISTINCT(DependentMpVersionIndependentGuid)FROM #ManagementPackDependencies Where Depth = @Depth
	
	set @Depth = @Depth + 1
 
  END
  

  
  -- Output Management Pack Dependencies
  SELECT BaseMpVersionIndependentGuid,BaseMpVersion,DependentMpVersionIndependentGuid,DependentMpVersion FROM #ManagementPackDependencies

  SELECT VersionIndependentGuid, Version FROM CatalogManagementPack as m WHERE EXISTS ( SELECT * FROM #ManagementPackDependencies as d WHERE m.VersionIndependentGuid = d.DependentMpVersionIndependentGuid AND m.VersionIndependentGuid <> d.BaseMpVersionIndependentGuid)

  END TRY
  BEGIN CATCH
    SELECT 
       @ErrorNumber = ERROR_NUMBER()
      ,@ErrorSeverity = ERROR_SEVERITY()
      ,@ErrorState = ERROR_STATE()
      ,@ErrorLine = ERROR_LINE()
      ,@ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-')
      ,@ErrorMessageText = ERROR_MESSAGE()

    SET @ErrorInd = 1
  END CATCH


  -- Cleanup

  IF (@XmlDocHandle IS NOT NULL)
    EXEC sp_xml_removedocument @XmlDocHandle


  IF (OBJECT_ID('#ManagementPack') IS NOT NULL)
    DROP TABLE #ManagementPack

  IF (OBJECT_ID('#ManagementPackDependencies') IS NOT NULL)
    DROP TABLE #ManagementPackDependencies

  IF (OBJECT_ID('#TempManagementPackDependencies') IS NOT NULL)
    DROP TABLE #TempManagementPackDependencies


  -- report error if any
  IF (@ErrorInd = 1)
  BEGIN
    DECLARE @AdjustedErrorSeverity int
    SET @AdjustedErrorSeverity = CASE
                                     WHEN @ErrorSeverity > 18 THEN 18
                                     ELSE @ErrorSeverity
                                 END
  
    RAISERROR (N'Sql execution failed. Error %d, Level %d, State %d, Procedure %s, Line %d, Message: %s', @AdjustedErrorSeverity, 1
      ,@ErrorNumber
      ,@ErrorSeverity
      ,@ErrorState
      ,@ErrorProcedure
      ,@ErrorLine
      ,@ErrorMessageText
    )
  END


END
GO

