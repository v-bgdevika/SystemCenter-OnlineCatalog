IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CategorySubCategoryIdsGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CategorySubCategoryIdsGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CategorySubCategoryIdsGet TO "SystemCenter_user"
GRANT EXECUTE ON CategorySubCategoryIdsGet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CategorySubCategoryIdsGet
(
     @Level                         int = 0                 -- INPUT the number of levels of sub categories to fetch
    ,@ProductName                   nvarchar(1024)          -- INPUT expects Product name of the client
    ,@ProductVersion                nvarchar(25)                -- INPUT expects Product version of the client
    ,@IncludeUnpublishedItemsInd    bit = NULL              -- INPUT expects indicator on whether to include unpublished items
)
AS

/****************************************************************************

PROCEDURE NAME: CategorySubCategoryIdsGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/02/2008

DESCRIPTION:
------------
This store procedure is used to recursively retrieve the sub category ids upto a given level.
The category id information is stored in a temp table #CategoryIds
Which needs to contain the category ids whose parents need to be found when this SP is first called.

The #CategoryIds table should have the following schema:
  CREATE TABLE #CategoryIds
  (
    CategoryId int
    ,Level     int
  )


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/02/2008       maaakash      Created Stored Procedure.

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


  -- Parameter Handling
  
  set @Level = ISNULL(@Level,0)
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')  

  
  DECLARE
    @LevelCounter int
    
  set @LevelCounter = 0
  
  IF @Level = 0
  BEGIN
    set @Level = 1024 -- Assuming 1024 is the max depth
  END
 

  --Recurse till no more sub categories exist
  WHILE EXISTS(Select * from #CategoryIds where Level = @LevelCounter) AND @Level >@LevelCounter
  BEGIN    
   
    INSERT #CategoryIds(CategoryId,Level)
      SELECT
         c.CatalogItemId
        ,@LevelCounter + 1
      FROM
        CatalogCategory AS c
          JOIN #CategoryIds AS t on c.ParentCategoryId = t.CategoryId AND t.Level = @LevelCounter
          JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
          JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
          JOIN CatalogItem AS ci ON c.CatalogItemId = ci.CatalogItemId and (@IncludeUnpublishedItemsInd = 'true' OR ci.PublishedInd = 'true')
      WHERE c.CatalogItemId NOT IN (SELECT CategoryId from #CategoryIds)

    set @LevelCounter = @LevelCounter + 1
        
  END



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
