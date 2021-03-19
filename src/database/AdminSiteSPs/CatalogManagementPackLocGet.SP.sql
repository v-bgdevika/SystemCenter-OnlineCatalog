IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogManagementPackLocGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogManagementPackLocGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogManagementPackLocGet TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogManagementPackLocGet
(
   @ManagementPackId                 int = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogManagementPackLocGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 12/10/2008

DESCRIPTION:
------------
This stored procedure is used to retrieve list of languages in which a mp is localized.


MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         12/10/2008       maaakash      Created Stored Procedure.

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
  
  SET @ManagementPackId = ISNULL(@ManagementPackId,0)

  -- Input Validation
  IF NOT EXISTS (SELECT CatalogItemId FROM CatalogManagementPack where CatalogItemId = @ManagementPackId)
  BEGIN
    RAISERROR('Cannot find the mp with given mp id', 16, 1)        
  END

  -- Main select
  SELECT
     loc.ThreeLetterLanguageCode 
  FROM
    CatalogManagementPackLocalized AS loc
  WHERE 
  loc.CatalogItemId = @ManagementPackId
  

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


