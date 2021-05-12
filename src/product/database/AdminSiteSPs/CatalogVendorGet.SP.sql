IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogVendorGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogVendorGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogVendorGet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogVendorGet
(
   @VendorId                 int = NULL
  ,@ThreeLetterLanguageCode  char(3) = 'ENU'
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogVendorGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Vendor Information given a vendor id and language code.

If id is 0, it returns all vendors.

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
  SET @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')

  -- Main select
  SELECT
     v.VendorId
    ,VendorName = ISNULL(LocalizedVendorName, DefaultVendorName)
    ,VendorLink = ISNULL(LocalizedVendorLink, DefaultVendorLink)
  FROM
    CatalogVendor AS v
    LEFT JOIN CatalogVendorLocalized AS loc ON (v.VendorId = loc.VendorId and loc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode)
  WHERE 
  ( @VendorId = 0 OR @VendorId = v.VendorId )
  

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


