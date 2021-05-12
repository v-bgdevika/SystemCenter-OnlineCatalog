IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogVendorLocSet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogVendorLocSet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogVendorLocSet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogVendorLocSet
(
   @VendorId                 int
  ,@VendorName               nvarchar(1024) = NULL
  ,@VendorLink               nvarchar(1024) = NULL
  ,@ThreeLetterLanguageCode  char(3)
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogVendorSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Vendor Information in the chosen language.

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

  IF @VendorId = 0 OR NOT EXISTS (Select * from CatalogVendor WHERE VendorId = @VendorId)
    BEGIN
      RAISERROR('Cannot find the vendor with the given vendor id to update', 16, 1)    
    END
  ELSE
    BEGIN
      IF EXISTS (Select * from CatalogVendorLocalized WHERE VendorId = @VendorId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode)
        BEGIN
          UPDATE CatalogVendorLocalized
            SET
               LocalizedVendorName = ISNULL(@VendorName,LocalizedVendorName)
              ,LocalizedVendorLink = ISNULL(@VendorLink,LocalizedVendorLink)
            WHERE VendorId = @VendorId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        END
      ELSE
        BEGIN
          INSERT INTO CatalogVendorLocalized (VendorId, LocalizedVendorName, LocalizedVendorLink, ThreeLetterLanguageCode)
            VALUES (@VendorId, @VendorName, @VendorLink, @ThreeLetterLanguageCode)
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
