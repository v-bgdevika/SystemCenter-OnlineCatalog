IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CategoryGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CategoryGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CategoryGet TO "SystemCenter_user"
GRANT EXECUTE ON CategoryGet TO "SystemCenter_admin"
GO


ALTER PROC dbo.CategoryGet
(
     @ThreeLetterLanguageCode       char(3) = 'ENU'         -- INPUT expects three letter language code for the locale of returned info
)
AS

/****************************************************************************

PROCEDURE NAME: CategoryGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/02/2008

DESCRIPTION:
------------
This store procedure is used to retrieve category information given the category information in a temp table #CategoryIds

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/02/2008       maaakash      Created Stored Procedure.
1.1         11/19/2008       maaakash      Sort the category result by display name.
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

  -- Parameter handling
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')


  -- Output category information

  SELECT
     c.CatalogItemId --CatalogItemId
    ,DisplayName = ISNULL(LocalizedDisplayName, DefaultDisplayName)
    ,GuideUriText = ISNULL(LocalizedGuideUriText, DefaultGuideUriText)
    ,GuideUriLink = ISNULL(LocalizedGuideUriLink, DefaultGuideUriLink)
    ,ParentCategoryId
    ,c.PublishedInd
  FROM
    CatalogItem AS c
        JOIN #CategoryIds AS ids on ids.CategoryId = c.CatalogItemId    
        LEFT JOIN CatalogItemLocalized AS cloc ON c.CatalogItemId = cloc.CatalogItemId and cloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        JOIN CatalogCategory AS cat ON c.CatalogItemId = cat.CatalogItemId
        LEFT JOIN CatalogCategoryLocalized AS catloc on cat.CatalogItemId = catloc.CatalogItemId and catloc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
  ORDER BY DisplayName


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
