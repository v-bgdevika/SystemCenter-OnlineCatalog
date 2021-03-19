IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogVendorSet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogVendorSet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogVendorSet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogVendorSet
(
   @VendorId        int = NULL
  ,@VendorName      nvarchar(1024)
  ,@VendorLink      nvarchar(1024)
)
AS


/****************************************************************************

PROCEDURE NAME: CatalogVendorSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Vendor Information in 'ENU'.

If id is 0, it inserts new vendor.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/23/2008       maaakash      Created Stored Procedure.

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

  IF @VendorId = 0
    BEGIN
          INSERT INTO CatalogVendor (DefaultVendorName,DefaultVendorLink)
      VALUES (@VendorName,@VendorLink)
      
      SET @VendorId = SCOPE_IDENTITY()
      
    END
  ELSE
    BEGIN
      IF EXISTS (SELECT * FROM CatalogVendor WHERE VendorId = @VendorId)
        BEGIN
          UPDATE CatalogVendor
            SET
               DefaultVendorName = ISNULL(@VendorName,DefaultVendorName)
              ,DefaultVendorLink = ISNULL(@VendorLink,DefaultVendorLink)
            WHERE VendorId = @VendorId
        END
      ELSE
        BEGIN
          RAISERROR('Cannot find the vendor with the given vendor id to update', 16, 1)
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

  SELECT @VendorId
END
GO
