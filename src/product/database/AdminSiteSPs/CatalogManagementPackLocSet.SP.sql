IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogManagementPackLocSet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogManagementPackLocSet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogManagementPackLocSet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogManagementPackLocSet
(
   @CatalogItemId             int
  ,@DisplayName               nvarchar(1024) = NULL
  ,@Description               nvarchar(MAX) = NULL
  ,@LocalizedKnowledge        nvarchar(MAX) = NULL
  ,@LocalizedEula             nvarchar(MAX) = NULL
  ,@ThreeLetterLanguageCode   char(3)	
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackLocSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/25/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Management Pack given a catalog item id in specified language.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/25/2008       maaakash      Created Stored Procedure.

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

  IF @CatalogItemId = 0
    BEGIN
      RAISERROR('Cannot find the catalog management pack with the given catalog item id to update', 16, 1)        
    END
  ELSE 
    BEGIN
        
      BEGIN TRANSACTION;
    
      IF EXISTS (SELECT * FROM CatalogItemLocalized WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode)
        BEGIN
          --Update CatalogItemLocalized
          UPDATE CatalogItemLocalized
            SET
               LocalizedDisplayName = ISNULL(@DisplayName,LocalizedDisplayName)
              ,LocalizedDescription = ISNULL(@Description,LocalizedDescription)
            WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
          --Update CatalogManagementPackLocalized
          UPDATE CatalogManagementPackLocalized
            SET
               LocalizedKnowledge = ISNULL(@LocalizedKnowledge,LocalizedKnowledge)
              ,LocalizedEula = ISNULL(@LocalizedEula,LocalizedEula)
            WHERE CatalogItemId = @CatalogItemId AND ThreeLetterLanguageCode = @ThreeLetterLanguageCode
        END
      ELSE
        BEGIN
          --Insert CatalogItem
          INSERT INTO CatalogItemLocalized (CatalogItemId,ThreeLetterLanguageCode,LocalizedDisplayName,LocalizedDescription)
            VALUES (@CatalogItemId,@ThreeLetterLanguageCode,@DisplayName,@Description)
          --Insert CatalogManagementPackLocalized
          INSERT INTO CatalogManagementPackLocalized (CatalogItemId,ThreeLetterLanguageCode,LocalizedKnowledge,LocalizedEula)
            VALUES (@CatalogItemId,@ThreeLetterLanguageCode,@LocalizedKnowledge,@LocalizedEula)
        END
      COMMIT TRANSACTION;
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
