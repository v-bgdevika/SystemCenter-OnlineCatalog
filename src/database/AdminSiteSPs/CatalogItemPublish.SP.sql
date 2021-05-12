IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogItemPublish')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogItemPublish AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogItemPublish TO "SystemCenter_admin"
GO

ALTER PROC dbo.CatalogItemPublish
(
     @CatalogItemXml    xml
    ,@PublishInd        bit = NULL
)
AS

/****************************************************************************

PROCEDURE NAME: CatalogItemPublish

AUTHOR: Aakash Mandhar (maaakash)

DATE: 10/02/2008

DESCRIPTION:
------------
This store procedure is used to publish and unpublish catalog items.

Sample Xml for CatalogItemXml:
<CatalogItems>
<CatalogItem ID="1"/>
<CatalogItem ID="2"/>
</CatalogItems>


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
    
    ,@XmlDocHandle    int
    ,@ExecResult      int

  SET @ErrorInd = 0

  BEGIN TRY

  --Parameter handling
  set @PublishInd = ISNULL(@PublishInd,1)
      
  -- Read the Xml
     EXEC @ExecResult = sp_xml_preparedocument @XmlDocHandle OUTPUT, @CatalogItemXml
     IF @ExecResult <> 0 RAISERROR(N'TODO: Fix this error message', 16, 1, @ExecResult)

  -- Create temp table 
  CREATE TABLE #CatalogItemIds (
    CatalogItemId int
  )

  -- Populate temp table 
  INSERT #CatalogItemIds(CatalogItemId)
    SELECT ID FROM OPENXML (@XmlDocHandle, '/CatalogItems/CatalogItem',1) WITH (ID int)

  
  --Update the CatalogItem table
  UPDATE CatalogItem
    SET PublishedInd = @PublishInd
    WHERE
      CatalogItemId IN (Select CatalogItemId FROM #CatalogItemIds) 

  --Select updated items and the operation
  SELECT c.CatalogItemId FROM CatalogItem AS c  WHERE EXISTS (SELECT CatalogItemId FROM #CatalogItemIds WHERE CatalogItemId = c.CatalogItemId)    
    
  SELECT @PublishInd
  
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

  --Cleanup
  IF (@XmlDocHandle IS NOT NULL)
    EXEC sp_xml_removedocument @XmlDocHandle

  IF (OBJECT_ID('#CatalogItemIds') IS NOT NULL)
    DROP TABLE #CatalogItemIds

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
