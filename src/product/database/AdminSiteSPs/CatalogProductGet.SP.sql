IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogProductGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogProductGet AS RETURN 1')
  END
GO


GRANT EXECUTE ON CatalogProductGet TO "SystemCenter_admin"
GO


ALTER PROC dbo.CatalogProductGet
(
  @ProductId    int = NULL	
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogProductGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/19/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Product Information given a product id.

If id is 0, it returns all catalog products.

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
  
  set @ProductId = ISNULL(@ProductId,0)

  -- Main select
  SELECT
     p.ProductId
    ,p.ProductName
    ,p.ProductVersion
  FROM
    CatalogProduct AS p
  WHERE 
  ( @ProductId = 0 OR @ProductId = p.ProductId )
  ORDER BY p.ProductName
  

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


