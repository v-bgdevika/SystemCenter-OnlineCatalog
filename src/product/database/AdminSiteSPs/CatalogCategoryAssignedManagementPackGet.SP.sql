IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogCategoryAssignedManagementPackGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogCategoryAssignedManagementPackGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogCategoryAssignedManagementPackGet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogCategoryAssignedManagementPackGet
(
   @CategoryId            int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogCategoryAssignedManagementPackGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 09/25/2008

DESCRIPTION:
------------
This store procedure is used to retrieve Catalog Management Pack assigned to a category.

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/16/2008       maaakash      Created Stored Procedure.

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
  
  set @CategoryId = ISNULL(@CategoryId,0)

  -- Main select
  SELECT
     c.CatalogItemId
    ,DefaultDisplayName
    ,VersionIndependentGuid
    ,Version
    ,SystemName
    ,PublicKey
    ,ReleaseDate
    ,VendorId
    ,DownloadUri
    ,EulaInd
    ,SecurityInd
    ,c.PublishedInd    
  FROM
    CatalogItem AS c        
        JOIN CatalogManagementPackCategory AS mpcat ON mpcat.CategoryCatalogItemId = @CategoryId AND mpcat.ManagementPackCatalogItemId = c.CatalogItemId
        JOIN CatalogManagementPack AS mp ON c.CatalogItemId = mp.CatalogItemId
  WHERE
    c.IsManagementPack = 'true'
  

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


