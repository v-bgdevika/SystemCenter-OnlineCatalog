IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogProductCatalogItemGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogProductCatalogItemGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogProductCatalogItemGet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogProductCatalogItemGet
(
   @CatalogItemId             int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogProductCatalogItemGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/09/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Products that a Catalog Item belongs to.

If id is 0, it returns all catalog item mappings.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/09/2008       maaakash      Created Stored Procedure.

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

  -- Main select
  SELECT
     ProductId
    ,CatalogItemId
  FROM
    CatalogProductCatalogItem AS c        
  WHERE
    ( @CatalogItemId = 0 OR @CatalogItemId = c.CatalogItemId )
  

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


