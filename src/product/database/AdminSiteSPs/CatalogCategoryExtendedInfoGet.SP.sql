IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogCategoryExtendedInfoGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogCategoryExtendedInfoGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogCategoryExtendedInfoGet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogCategoryExtendedInfoGet
(
   @CatalogItemId             int = NULL
  ,@ThreeLetterLanguageCode   char(3) = 'ENU'
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategoryExtendedInfoGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/21/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Category Extended Information given a catalog item id and language code.

If id is 0, it returns all categories.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/21/2008       maaakash      Created Stored Procedure.

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
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')

  -- Main select
  SELECT
     c.CatalogItemId
    ,Description = ISNULL(LocalizedDescription, DefaultDescription)
  FROM
    CatalogItem AS c        
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
  WHERE
    c.IsCategory = 'true'
    AND ( @CatalogItemId = 0 OR @CatalogItemId = c.CatalogItemId )
  

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


