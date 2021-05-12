IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogManagementPackSet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogManagementPackSet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogManagementPackSet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogManagementPackSet
(
   @CatalogItemId            int = NULL
  ,@DisplayName              nvarchar(1024) = NULL
  ,@Description              nvarchar(MAX) = NULL
  ,@VersionIndependentGuid   uniqueidentifier = NULL
  ,@Version                  nvarchar(25) = NULL
  ,@SystemName               nvarchar(256) = NULL
  ,@PublicKey                varchar(32) = NULL
  ,@ReleaseDate              datetime = NULL
  ,@VendorId                 int = NULL
  ,@DownloadUri              nvarchar(1024) = NULL
  ,@DefaultKnowledge         nvarchar(MAX) = NULL
  ,@EulaInd                  bit = NULL
  ,@DefaultEula              nvarchar(MAX) = NULL
  ,@SecurityInd              bit = NULL
  ,@PublishedInd             bit = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackSet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/25/2008

DESCRIPTION:
------------
This store procedure is used to create / update Catalog Management Pack given a catalog item id in ENU.

If id is 0, it inserts management pack.

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
    
      BEGIN TRANSACTION;
      
      SET @PublishedInd = ISNULL(@PublishedInd,'false')
    
      --Insert CatalogItem
      INSERT INTO CatalogItem (IsManagementPack,IsCategory,PublishedInd,DefaultDisplayName,DefaultDescription)
        VALUES ('true','false',@PublishedInd,@DisplayName,@Description)
        
      SET @CatalogItemId = SCOPE_IDENTITY()
        
      --Insert CatalogManagementPack
      INSERT INTO CatalogManagementPack (CatalogItemId,VersionIndependentGuid,Version,SystemName,PublicKey,ReleaseDate,VendorId,DownloadUri,DefaultKnowledge,EulaInd,DefaultEula,SecurityInd)
        VALUES (@CatalogItemId,@VersionIndependentGuid,@Version,@SystemName,@PublicKey,@ReleaseDate,@VendorId,@DownloadUri,@DefaultKnowledge,@EulaInd,@DefaultEula,@SecurityInd);
        
      COMMIT TRANSACTION;
      
    END
  ELSE
    BEGIN
      IF EXISTS (SELECT * FROM CatalogItem WHERE CatalogItemId = @CatalogItemId AND IsManagementPack = 'true')
        BEGIN
        
          BEGIN TRANSACTION;
          
          --Update CatalogItem
          UPDATE CatalogItem
            SET
               DefaultDisplayName = ISNULL(@DisplayName,DefaultDisplayName)
              ,DefaultDescription = ISNULL(@Description,DefaultDescription)
              ,PublishedInd = ISNULL(@PublishedInd,PublishedInd)
            WHERE CatalogItemId = @CatalogItemId
          --Update CatalogManagementPack
          UPDATE CatalogManagementPack
            SET
               VersionIndependentGuid = ISNULL(@VersionIndependentGuid,VersionIndependentGuid)
              ,Version = ISNULL(@Version,Version)
              ,SystemName = ISNULL(@SystemName,SystemName)
              ,PublicKey = ISNULL(@PublicKey,PublicKey)
              ,ReleaseDate = ISNULL(@ReleaseDate,ReleaseDate)
              ,VendorId = ISNULL(@VendorId,VendorId)
              ,DownloadUri = ISNULL(@DownloadUri,DownloadUri)
              ,DefaultKnowledge = ISNULL(@DefaultKnowledge,DefaultKnowledge)
              ,EulaInd = ISNULL(@EulaInd,EulaInd)
              ,DefaultEula = ISNULL(@DefaultEula,DefaultEula)
              ,SecurityInd = ISNULL(@SecurityInd,SecurityInd)
            WHERE CatalogItemId = @CatalogItemId
          
          COMMIT TRANSACTION;
          
        END
      ELSE
        BEGIN
          RAISERROR('Cannot find the management pack with the given catalog item id to update', 16, 1)
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

SELECT @CatalogItemId,@VersionIndependentGuid,@Version

END
GO
