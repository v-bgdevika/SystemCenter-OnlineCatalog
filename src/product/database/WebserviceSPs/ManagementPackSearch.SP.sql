IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ManagementPackSearch')
  BEGIN
    EXECUTE ('CREATE PROCEDURE ManagementPackSearch AS RETURN 1')
  END
GO

GRANT EXECUTE ON ManagementPackSearch TO "SystemCenter_user"
GRANT EXECUTE ON ManagementPackSearch TO "SystemCenter_admin"

GO


ALTER PROC dbo.ManagementPackSearch
(
     @ManagementPackNamePattern     nvarchar(1024) = NULL   -- INPUT expects MP or category name search pattern
    ,@VendorNamePattern             nvarchar(1024) = NULL   -- INPUT expects Vendor name search pattern
    ,@ReleasedOnOrAfter             datetime = NULL         -- INPUT expects filtering date for MPs
    ,@InstalledManagementPackXml    xml = NULL              -- INPUT expects xml to represent installed MPs, see description for sample
    ,@ProductName                   nvarchar(1024)          -- INPUT expects Product name of the client
    ,@ProductVersion                nvarchar(25)            -- INPUT expects Product version of the client
    ,@ThreeLetterLanguageCode       char(3) = 'ENU'         -- INPUT expects three letter language code for the locale of returned info
    ,@IncludeUnpublishedItemsInd    bit = NULL              -- INPUT expects indicator on whether to include unpublished items
)
AS

/****************************************************************************

PROCEDURE NAME: ManagementPackSearch

AUTHOR: Aakash Mandhar (maaakash)

DATE: 08/28/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Management Packs satisfying the given criteria and associated categories.

Sample Xml for InstalledManagementPackXml
<ManagementPacks>
<ManagementPack VersionIndependentGuid="version_independent_guid1" Version="6.0.6278.0" />
<ManagementPack VersionIndependentGuid="version_independent_guid2" Version="6.0.6278.10" />
</ManagementPacks>

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         08/28/2008       maaakash      Created Stored Procedure.
1.1         11/19/2008       maaakash      Sort result by display name and also search category name for management pack name pattern.
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


  --Parameter handling
  
  set @ManagementPackNamePattern = ISNULL(@ManagementPackNamePattern,'%')
  set @VendorNamePattern = ISNULL(@VendorNamePattern,'%')
  set @ReleasedOnOrAfter = ISNULL(@ReleasedOnOrAfter,0)
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')


  -- Create temp table   
  CREATE TABLE #InstalledManagementPack (
    VersionIndependentGuid uniqueidentifier
   ,Version                nvarchar(25)
  )
  

  IF @InstalledManagementPackXml IS NOT NULL 
  BEGIN
    -- Read the Xml
       EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @InstalledManagementPackXml
       IF @ExecResult <> 0 RAISERROR('TODO: Fix this error message',16, 1, @ExecResult)


    -- Populate temp table 
    INSERT #InstalledManagementPack(VersionIndependentGuid, Version)
      SELECT VersionIndependentGuid, Version FROM OPENXML (@XmlDocHandle, '/ManagementPacks/ManagementPack',1) WITH (VersionIndependentGuid uniqueidentifier, Version nvarchar(25))
  END



  -- Create table to store all matching categories
  CREATE TABLE #CategoryIds
  (
    CategoryId int
    ,Level     int
  )

  --Add all matching category information
  INSERT #CategoryIds(CategoryId,Level)
  SELECT
    c.CatalogItemId
    ,0
  FROM 
    CatalogItem as c
      LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
      JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
      JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
  WHERE
    (@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')
    AND ISNULL(LocalizedDisplayName,DefaultDisplayName) LIKE @ManagementPackNamePattern COLLATE SQL_Latin1_General_CP1_CI_AS
    AND IsCategory = 'true'

  -- Get all sub categories of matching categories
  EXEC CategorySubCategoryIdsGet 0,@ProductName,@ProductVersion,@IncludeUnpublishedItemsInd

  -- Create table to store all MP ids matching categories
  CREATE TABLE #CategoryManagementPackIds
  (
    ManagementPackId int
  )

  --Insert MP id information
  INSERT #CategoryManagementPackIds(ManagementPacKId)
  SELECT DISTINCT(ManagementPackCatalogItemId)
    FROM 
      CatalogManagementPackCategory AS cmp
      JOIN #CategoryIds AS cid ON (cid.CategoryId = cmp.CategoryCatalogItemId)


  -- Create the result MP Table
  CREATE TABLE #ManagementPackResult
  (
    CatalogItemId           int
   ,DisplayName             nvarchar(1024)
   ,VersionIndependentGuid  uniqueidentifier
   ,Version                 nvarchar(25)
   ,SystemName              nvarchar(256)
   ,PublicKey               varchar(32)
   ,ReleaseDate             DateTime
   ,VendorName              nvarchar(1024)
   ,VendorLink              nvarchar(1024)
   ,DownloadUri             nvarchar(1024)
   ,EulaInd                 bit
   ,SecurityInd             bit
   ,PublishedInd            bit
  )


 -- Populate MP Result Table 
  INSERT #ManagementPackResult(CatalogItemId,DisplayName,VersionIndependentGuid,Version,SystemName,PublicKey,ReleaseDate,VendorName,VendorLink,DownloadUri,EulaInd,SecurityInd,PublishedInd)
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
    AND ISNULL(LocalizedVendorName, DefaultVendorName) LIKE @VendorNamePattern COLLATE SQL_Latin1_General_CP1_CI_AS
    AND (ISNULL(LocalizedDisplayName, DefaultDisplayName) LIKE @ManagementPackNamePattern COLLATE SQL_Latin1_General_CP1_CI_AS OR EXISTS ( SELECT * from #CategoryManagementPackIds AS cmp WHERE cmp.ManagementPackId = c.CatalogItemId ) )
    AND m.ReleaseDate >= @ReleasedOnOrAfter
    AND 
      (
        @InstalledManagementPackXml IS NULL 
        OR
        EXISTS (Select i.Version from #InstalledManagementPack as i where i.VersionIndependentGuid = m.VersionIndependentGuid AND dbo.fn_VersionCompare(m.Version,i.Version) = 1)
      )


  DELETE FROM #CategoryIds

  DROP TABLE #CategoryManagementPackIds

  -- Output Management Pack Results
  SELECT * FROM #ManagementPackResult ORDER BY DisplayName
 
 
  --Create the resulting MP category map table
  CREATE TABLE #ManagementPackCategoryResult
  (
    ManagementPackCatalogItemId int
   ,CategoryCatalogItemId       int
  )
 
  INSERT #ManagementPackCategoryResult(ManagementPackCatalogItemId,CategoryCatalogItemId)
  SELECT 
    mc.ManagementPackCatalogItemId
   ,mc.CategoryCatalogItemId
  FROM
    CatalogManagementPackCategory AS mc
      JOIN #ManagementPackResult AS m ON mc.ManagementPackCatalogItemId = m.CatalogItemId
      JOIN CatalogProductCatalogItem AS pc ON mc.CategoryCatalogItemId = pc.CatalogItemId
      JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) <= 0
      JOIN CatalogItem AS ci ON mc.CategoryCatalogItemId = ci.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR ci.PublishedInd = 'true')
          
  -- Output MP Category Map Table
  SELECT * FROM #ManagementPackCategoryResult



  -- Populate initial category list
  INSERT #CategoryIds(CategoryId,Level)
    SELECT 
      DISTINCT(CategoryCatalogItemId)
      ,0 
    FROM 
      #ManagementPackCategoryResult AS m
        JOIN CatalogItem AS c ON m.CategoryCatalogItemId = c.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR c.PublishedInd = 'true')


  -- Find Parent Categories
  EXEC CategoryParentIdsGet 0,@ProductName,@ProductVersion,@IncludeUnpublishedItemsInd

  -- Output all categories
  EXEC dbo.CategoryGet @ThreeLetterLanguageCode


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


  IF (OBJECT_ID('#InstalledManagementPack') IS NOT NULL)
    DROP TABLE #InstalledManagementPack

  IF (OBJECT_ID('#ManagementPackResult') IS NOT NULL)
    DROP TABLE #ManagementPackResult

  IF (OBJECT_ID('#ManagementPackCategoryResult') IS NOT NULL)
    DROP TABLE #ManagementPackCategoryResult

  IF (OBJECT_ID('#CategoryIds') IS NOT NULL)
    DROP TABLE #CategoryIds


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


