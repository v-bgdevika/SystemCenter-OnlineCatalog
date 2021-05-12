IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogItemUnAssociatedProductGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogItemUnAssociatedProductGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogItemUnAssociatedProductGet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogItemUnAssociatedProductGet
(
   @CatalogItemId                 int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogItemUnAssociatedProductGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 12/09/2008

DESCRIPTION:
------------
This stored procedure is used to retrieve list of products not associated with a catalog item.


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/09/2008       maaakash      Created Stored Procedure.

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

  -- Input Validation
  IF NOT EXISTS (SELECT CatalogItemId FROM CatalogItem where CatalogItemId = @CatalogItemId)
  BEGIN
    RAISERROR('Cannot find the catalog item with given item id', 16, 1)        
  END

  -- Main select
  SELECT
     p.ProductId
    ,p.ProductName
    ,p.ProductVersion
  FROM
   CatalogProduct AS p
  WHERE 
    NOT EXISTS (SELECT CatalogItemId FROM CatalogProductCatalogItem AS cp WHERE cp.CatalogItemId = @CatalogItemId AND cp.ProductId = p.ProductId);
  

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


