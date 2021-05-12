IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ManagementPackList')
  BEGIN
    EXECUTE ('CREATE PROCEDURE ManagementPackList AS RETURN 1')
  END
GO

GRANT EXECUTE ON ManagementPackList TO "SystemCenter_user"
GRANT EXECUTE ON ManagementPackList TO "SystemCenter_admin"
GO


ALTER PROC dbo.ManagementPackList
(
     @CatalogItemId                 int = NULL              -- INPUT expects the starting category id, 0 for the root of the tree
    ,@Depth                         int = NULL              -- INPUT expects the depth to which categories should be returned
    ,@ProductName                   nvarchar(1024)          -- INPUT expects Product name of the client
    ,@ProductVersion                nvarchar(25)            -- INPUT expects Product version of the client
    ,@ThreeLetterLanguageCode       char(3) = 'ENU'         -- INPUT expects three letter language code for the locale of returned info
    ,@IncludeUnpublishedItemsInd    bit = NULL              -- INPUT expects indicator on whether to include unpublished items
)
AS
/****************************************************************************

PROCEDURE NAME: ManagementPackList

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/02/2008

DESCRIPTION:
------------
This store procedure is used to retrieve a part of the catalog tree structure up to a given depth given a starting category catalog item id.
If CatalogItemId is 0 then it starts with the root node
If Depth is 0 then it fetches all the levels.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/02/2008       maaakash      Created Stored Procedure.
1.1         11/19/2008       maaakash      Sort result by display name.
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
    

  SET @ErrorInd = 0

  BEGIN TRY


  --Parameter handling
  
  set @CatalogItemId = ISNULL(@CatalogItemId,0)
  set @Depth = ISNULL(@Depth,0)
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')



  --Create table to store all categories needed
  CREATE TABLE #CategoryIds
  (
    CategoryId int
    ,Level     int
  )

  -- Populate initial category list
  INSERT INTO #CategoryIds VALUES (@CatalogItemId,0)

  
  -- Find Parent Categories
  EXEC CategorySubCategoryIdsGet @Depth,@ProductName,@ProductVersion,@IncludeUnpublishedItemsInd

  -- Output all categories
  EXEC dbo.CategoryGet @ThreeLetterLanguageCode


  --Create the resulting MP category map table
  CREATE TABLE #ManagementPackCategoryResult
  (
    ManagementPackCatalogItemId int
   ,CategoryCatalogItemId       int
  )

  -- Find the management packs
  INSERT INTO #ManagementPackCategoryResult
      SELECT 
         mc.ManagementPackCatalogItemId
        ,mc.CategoryCatalogItemId
      FROM
        CatalogManagementPackCategory AS mc
          JOIN CatalogProductCatalogItem AS pc ON mc.CategoryCatalogItemId = pc.CatalogItemId
          JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName AND dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
          JOIN CatalogItem AS ci ON mc.ManagementPackCatalogItemId = ci.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR ci.PublishedInd = 'true')
      WHERE
        EXISTS(Select * from #CategoryIds AS ids where ids.CategoryId = mc.CategoryCatalogItemId)

  -- Display the mapping between categories and management packs
  SELECT * from #ManagementPackCategoryResult    

  -- Output Management Packs
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
    AND EXISTS (Select ManagementPackCatalogItemId from #ManagementPackCategoryResult as i where i.ManagementPackCatalogItemId = c.CatalogItemId)
  ORDER BY
    DisplayName


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

  IF (OBJECT_ID('#CategoryIds') IS NOT NULL)
    DROP TABLE #CategoryIds


  IF (OBJECT_ID('#ManagementPackIdsCategoryResult') IS NOT NULL)
    DROP TABLE #ManagementPackCategoryResult


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
