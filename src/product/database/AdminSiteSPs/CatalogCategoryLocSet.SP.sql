IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogCategoryLocSet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogCategoryLocSet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogCategoryLocSet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogCategoryLocSet
(
   @CatalogItemId               int
  ,@DisplayName                 nvarchar(1024) = NULL
  ,@Description                 nvarchar(MAX)= NULL
  ,@GuideUriText                nvarchar(1024) = NULL
  ,@GuideUriLink                nvarchar(1024) = NULL
  ,@ThreeLetterLanguageCode     char(3)
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategoryLocSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Category given a catalog item id in specified language.

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
  
  set @CatalogItemId = ISNULL(@CatalogItemId,0)

  IF @CatalogItemId = 0
    BEGIN
      RAISERROR('Cannot find the catalog category with the given catalog item id to update', 16, 1)        
    END
  ELSE 
    BEGIN
    
      BEGIN TRANSACTION;
 
    
      IF EXISTS (Select * from CatalogItemLocalized WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode)
        BEGIN
          --Update CatalogItemLocalized
          UPDATE CatalogItemLocalized
            SET
               LocalizedDisplayName = ISNULL(@DisplayName,LocalizedDisplayName)
              ,LocalizedDescription = ISNULL(@Description,LocalizedDescription)
            WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
          --Update CatalogCategoryLocalized
          UPDATE CatalogCategoryLocalized
            SET
               LocalizedGuideUriText = ISNULL(@GuideUriText,LocalizedGuideUriText)
              ,LocalizedGuideUriLink = ISNULL(@GuideUriText,LocalizedGuideUriLink)              
            WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        END
      ELSE
        BEGIN
          --Insert CatalogItem
          INSERT INTO CatalogItemLocalized (CatalogItemId,ThreeLetterLanguageCode,LocalizedDisplayName,LocalizedDescription)
            VALUES (@CatalogItemId,@ThreeLetterLanguageCode,@DisplayName,@Description)
          --Insert CatalogCategory
          INSERT INTO CatalogCategoryLocalized (CatalogItemId,ThreeLetterLanguageCode,LocalizedGuideUriText,LocalizedGuideUriLink)
            VALUES (@CatalogItemId,@ThreeLetterLanguageCode,@GuideUriText,@GuideUriLink);      
        END
        
      COMMIT TRANSACTION
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

  SELECT @CatalogItemId

END
GO
