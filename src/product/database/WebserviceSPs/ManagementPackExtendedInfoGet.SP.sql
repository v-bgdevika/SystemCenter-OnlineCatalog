IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ManagementPackExtendedInfoGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE ManagementPackExtendedInfoGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON ManagementPackExtendedInfoGet TO "SystemCenter_user"
GRANT EXECUTE ON ManagementPackExtendedInfoGet TO "SystemCenter_admin"
GO


ALTER PROC dbo.ManagementPackExtendedInfoGet
(
     @ManagementPackXml           xml              --INPUT Management Packs whose information is to be returned
    ,@ProductName                 nvarchar(1024)   -- INPUT expects Product name of the client
    ,@ProductVersion              nvarchar(25)     -- INPUT expects Product version of the client
    ,@ThreeLetterLanguageCode     char(3) = 'ENU'  -- INPUT expects three letter language code for the locale of returned info
    ,@IncludeUnpublishedItemsInd  bit = NULL       -- INPUT expects indicator on whether to include unpublished items
)
AS

/****************************************************************************

PROCEDURE NAME: ManagementPackExtendedInfoGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 08/28/2008

DESCRIPTION:
------------
This store procedure is used to retrieve extended Management Packs information given management pack identities.
It returns management packs and their immidiate dependencies.

Sample Xml for ManagementPackXml
<ManagementPacks>
<ManagementPack VersionIndependentGuid="version_independent_guid1" Version="6.0.6278.0" />
<ManagementPack VersionIndependentGuid="version_independent_guid2" Version="6.0.6278.10" />
</ManagementPacks>

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         08/28/2008       maaakash      Created Stored Procedure.

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

  -- Handle parameters
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')


  -- Create temp table   
  CREATE TABLE #ManagementPack (
    VersionIndependentGuid uniqueidentifier
   ,Version                varchar(32)
  )
  

  IF @ManagementPackXml IS NOT NULL 
  BEGIN
    -- Read the Xml
       EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @ManagementPackXml
       IF @ExecResult <> 0 RAISERROR('TODO: Fix this error message',16, 1, @ExecResult)


    -- Populate temp table 
    INSERT #ManagementPack(VersionIndependentGuid, Version)
      SELECT VersionIndependentGuid, Version FROM OPENXML (@XmlDocHandle, '/ManagementPacks/ManagementPack',1) WITH (VersionIndependentGuid uniqueidentifier, Version varchar(32))
  END


  -- Create the result MP Table
  CREATE TABLE #ManagementPackResult
  (
    CatalogItemId           int
   ,Description             nvarchar(MAX)
   ,Knowledge               nvarchar(MAX)
   ,Eula                    nvarchar(MAX)
   ,PublishedInd            bit
   ,VersionIndependentGuid  uniqueidentifier
   ,Version                 nvarchar(25)
  )

  -- Populate MP Result Table 
  INSERT #ManagementPackResult(CatalogItemId,Description,Knowledge,Eula,PublishedInd,VersionIndependentGuid,Version)
  SELECT
     c.CatalogItemId 
    ,Description = ISNULL(LocalizedDescription, DefaultDescription)
    ,Knowledge = ISNULL(LocalizedKnowledge, DefaultKnowledge)
    ,Eula = 
            CASE WHEN EulaInd = 'true' 
              THEN
                ISNULL(LocalizedEula, DefaultEula)
              ELSE
                NULL
              END
    ,c.PublishedInd
    ,m.VersionIndependentGuid
    ,m.Version
  FROM
    CatalogItem AS c
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogManagementPack AS m ON c.CatalogItemId = m.CatalogItemId
        LEFT JOIN CatalogManagementPackLocalized AS mloc ON m.CatalogItemId = mloc.CatalogItemId  and mloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
        JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
        JOIN #ManagementPack AS mp ON m.VersionIndependentGuid = mp.VersionIndependentGuid
  WHERE
    (@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')

 

  -- Output Management Pack Results
  SELECT * FROM #ManagementPackResult
 
  -- Temp table to store dependencies
  CREATE TABLE #ManagementPackDependency
  (
     ManagementPackCatalogItemId            int
    ,DependentMpVersionIndependentGuid      uniqueidentifier
    ,DependentMpVersion                     nvarchar(25)
  )
 
  --Populate the dependency table
  INSERT #ManagementPackDependency(ManagementPackCatalogItemId,DependentMpVersionIndependentGuid,DependentMpVersion)
  SELECT 
    ManagementPackCatalogItemId
   ,DependentMpVersionIndependentGuid
   ,DependentMpVersion
  FROM
    CatalogManagementPackDependency AS dep
      JOIN #ManagementPackResult AS m ON dep.ManagementPackCatalogItemId = m.CatalogItemId

  -- Output Dependency List
  SELECT * FROM #ManagementPackDependency

  -- Output dependencies information
  SELECT
     c.CatalogItemId --CatalogItemId
    ,DisplayName = ISNULL(LocalizedDisplayName, DefaultDisplayName)
    ,m.VersionIndependentGuid
    ,m.Version
    ,m.SystemName
    ,m.PublicKey
    ,m.ReleaseDate
    ,VendorName = ISNULL(LocalizedVendorName, DefaultVendorName)
    ,VendorLink = ISNULL(LocalizedVendorLink, DefaultVendorLink)
    ,DownloadUri
    ,EulaInd
    ,SecurityInd
    ,c.PublishedInd
  FROM
    CatalogItem AS c
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogManagementPack AS m ON c.CatalogItemId = m.CatalogItemId
        JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
        JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
        JOIN CatalogVendor AS v ON m.VendorId = v.VendorId
        LEFT JOIN CatalogVendorLocalized AS vloc on v.VendorId = vloc.VendorId
  WHERE
    (@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')
    AND EXISTS (Select ManagementPackCatalogItemId FROM #ManagementPackDependency AS dep WHERE dep.DependentMpVersionIndependentGuid = m.VersionIndependentGuid)
  

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

  IF (OBJECT_ID('#ManagementPackResult') IS NOT NULL)
    DROP TABLE #ManagementPackResult

  IF (OBJECT_ID('#ManagementPackDependency') IS NOT NULL)
    DROP TABLE #ManagementPackDependency



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

