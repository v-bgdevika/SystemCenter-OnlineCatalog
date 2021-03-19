IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogManagementPackCategorySet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogManagementPackCategorySet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogManagementPackCategorySet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogManagementPackCategorySet
(
   @ManagementPackCatalogItemId            int
  ,@CategoryCatalogItemId                  int
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackCategorySet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/02/2008

DESCRIPTION:
------------
This store procedure is used to add management packs to categories.

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
  
  SET @ManagementPackCatalogItemId = ISNULL(@ManagementPackCatalogItemId,0)
  SET @CategoryCatalogItemId = ISNULL(@CategoryCatalogItemId,0)

  IF NOT EXISTS (SELECT * FROM CatalogManagementPackCategory WHERE ManagementPackCatalogItemId = @ManagementPackCatalogItemId AND CategoryCatalogItemId = @CategoryCatalogItemId)
    BEGIN
      INSERT INTO CatalogManagementPackCategory(ManagementPackCatalogItemId,CategoryCatalogItemId)
        VALUES (@ManagementPackCatalogItemId,@CategoryCatalogItemId)
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
  SELECT @ManagementPackCatalogItemId, @CategoryCatalogItemId
END
GO
