IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogCategorySet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogCategorySet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogCategorySet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogCategorySet
(
     @CatalogItemId     int = NULL
    ,@DisplayName       nvarchar(1024) = NULL
    ,@Description       nvarchar(MAX) = NULL
    ,@ParentId          int = NULL
    ,@GuideUriText      nvarchar(1024) = NULL
    ,@GuideUriLink      nvarchar(1024) = NULL
    ,@PublishedInd      bit = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategorySet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/23/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Category given a catalog item id in ENU.

If id is 0, it inserts category.

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
  
  SET @CatalogItemId = ISNULL(@CatalogItemId,0)
  
  IF @CatalogItemId = 0
    BEGIN
    
      BEGIN TRANSACTION;
      
      SET @PublishedInd = ISNULL(@PublishedInd,'false')
      
      --Insert CatalogItem
      INSERT INTO CatalogItem (IsManagementPack,IsCategory,PublishedInd,DefaultDisplayName,DefaultDescription)
        VALUES ('false','true',@PublishedInd,@DisplayName,@Description)
      --Insert CatalogCategory
      
      SET @CatalogItemId = SCOPE_IDENTITY()
      
      INSERT INTO CatalogCategory (CatalogItemId,ParentCategoryId,DefaultGuideUriText,DefaultGuideUriLink)
        VALUES (@CatalogItemId,@ParentId,@GuideUriText,@GuideUriLink);      
        
      COMMIT TRANSACTION;
    END
  ELSE
    BEGIN
      IF EXISTS (SELECT * FROM CatalogItem WHERE CatalogItemId = @CatalogItemId AND IsCategory = 'true')
        BEGIN
        
          BEGIN TRANSACTION;
          
          --Update CatalogItem
          UPDATE CatalogItem
            SET
               DefaultDisplayName = ISNULL(@DisplayName,DefaultDisplayName)
              ,DefaultDescription = ISNULL(@Description,DefaultDescription)
              ,PublishedInd = ISNULL(@PublishedInd,PublishedInd)              
            WHERE CatalogItemId = @CatalogItemId
          --Update CatalogCategory
          UPDATE CatalogCategory
            SET
               ParentCategoryId = ISNULL(@ParentId,ParentCategoryId)
              ,DefaultGuideUriText = ISNULL(@GuideUriText,DefaultGuideUriText)
              ,DefaultGuideUriLink = ISNULL(@GuideUriText,DefaultGuideUriLink)              
            WHERE CatalogItemId = @CatalogItemId
            
          COMMIT TRANSACTION;
          
        END
      ELSE
        BEGIN
          RAISERROR('Cannot find the category with the given catalog item id to update', 16, 1)
        END
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
