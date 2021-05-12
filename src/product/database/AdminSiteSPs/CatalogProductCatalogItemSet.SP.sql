IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogProductCatalogItemSet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogProductCatalogItemSet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogProductCatalogItemSet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogProductCatalogItemSet
(
   @CatalogItemId            int
  ,@ProductId                int
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogProductCatalogItemSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/02/2008

DESCRIPTION:
------------
This store procedure is used to relate catalog items to product.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         10/02/2008       maaakash      Created Stored Procedure.

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
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)
  SET @ProductId = ISNULL(@ProductId,0)

  IF NOT EXISTS (SELECT * FROM CatalogProductCatalogItem WHERE CatalogItemId = @CatalogItemId AND ProductId = @ProductId)
    BEGIN
      INSERT INTO CatalogProductCatalogItem(CatalogItemId,ProductId)
        VALUES (@CatalogItemId,@ProductId)
    END
    
    
END TRY
  BEGIN CATCH

    IF (@@TRANCOUNT > 0)
      ROLLBACK TRAN
  
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
  SELECT @ProductId, @CatalogItemId
END
GO
