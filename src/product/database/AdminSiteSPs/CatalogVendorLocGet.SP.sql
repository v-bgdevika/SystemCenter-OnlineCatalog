IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogVendorLocGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogVendorLocGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogVendorLocGet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogVendorLocGet
(
   @VendorId                 int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogVendorLocGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 12/09/2008

DESCRIPTION:
------------
This stored procedure is used to retrieve list of languages in which a vendor is localized.


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
  
  SET @VendorId = ISNULL(@VendorId,0)

  -- Input Validation
  IF NOT EXISTS (SELECT VendorId FROM CatalogVendor where VendorId = @VendorId)
  BEGIN
    RAISERROR('Cannot find the vendor with given vendor id', 16, 1)        
  END

  -- Main select
  SELECT
     loc.ThreeLetterLanguageCode 
  FROM
    CatalogVendorLocalized AS loc
  WHERE 
  loc.VendorId = @VendorId
  

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


