IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogManagementPackDependencySet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogManagementPackDependencySet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogManagementPackDependencySet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogManagementPackDependencySet
(
   @CatalogItemId            int
  ,@VersionIndependentGuid   uniqueidentifier
  ,@Version                  nvarchar(25)
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackDependencySet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/30/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Management Pack dependency.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         09/30/2008       maaakash      Created Stored Procedure.

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

  IF @CatalogItemId = 0 OR NOT EXISTS (SELECT * FROM CatalogManagementPack WHERE CatalogItemId = @CatalogItemId)
    BEGIN
      RAISERROR('Cannot find the management pack with the given catalog item id to set dependency', 16, 1)
    END
  ELSE IF EXISTS (SELECT * FROM CatalogManagementPackDependency WHERE ManagementPackCatalogItemId = @CatalogItemId AND DependentMpVersionIndependentGuid = @VersionIndependentGuid)
    BEGIN
      --Update CatalogManagementPackDependency
      UPDATE 
        CatalogManagementPackDependency
          SET 
            DependentMpVersion = @Version
          WHERE ManagementPackCatalogItemId = @CatalogItemId AND DependentMpVersionIndependentGuid = @VersionIndependentGuid
    END
  ELSE
    BEGIN     
      --Insert CatalogManagementPackDependency
      INSERT INTO CatalogManagementPackDependency (ManagementPackCatalogItemId,DependentMpVersionIndependentGuid,DependentMpVersion)
        VALUES (@CatalogItemId,@VersionIndependentGuid,@Version)
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
  SELECT @CatalogItemId, @VersionIndependentGuid, @Version
END
GO
