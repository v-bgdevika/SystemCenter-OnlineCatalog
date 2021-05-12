IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogProductSet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogProductSet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogProductSet TO "SystemCenter_admin"
GO


ALTER PROC dbo.CatalogProductSet
(
   @ProductId         int = NULL
  ,@ProductName       nvarchar(1024)
  ,@ProductVersion    nvarchar(25)	
)
AS


/****************************************************************************

PROCEDURE NAME: CatalogProductSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/19/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Product Information given a product id.

If id is 0, it inserts catalog products.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/19/2008       maaakash      Created Stored Procedure.

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
  
  SET @ProductId = ISNULL(@ProductId,0)

  IF @ProductId = 0
    BEGIN
          INSERT INTO CatalogProduct (ProductName,ProductVersion)
      VALUES (@ProductName,@ProductVersion)
      
      SET @ProductId = SCOPE_IDENTITY()
      
    END
  ELSE
    BEGIN
      IF EXISTS (SELECT * FROM CatalogProduct WHERE ProductId = @ProductId)
        BEGIN
          UPDATE CatalogProduct
            SET
               ProductName = ISNULL(@ProductName,ProductName)
              ,ProductVersion = ISNULL(@ProductVersion,ProductVersion)
            WHERE ProductId = @ProductId
        END
      ELSE
        BEGIN
          RAISERROR('Cannot find the product with the given product id to update', 16, 1)
        END
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

SELECT @ProductId

END
GO


