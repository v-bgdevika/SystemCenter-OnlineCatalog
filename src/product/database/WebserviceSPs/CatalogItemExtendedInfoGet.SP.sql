IF NOT EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CatalogItemExtendedInfoGet')
  BEGIN
    EXECUTE ('CREATE PROCEDURE CatalogItemExtendedInfoGet AS RETURN 1')
  END
GO

GRANT EXECUTE ON CatalogItemExtendedInfoGet TO "SystemCenter_user"
GRANT EXECUTE ON CatalogItemExtendedInfoGet TO "SystemCenter_admin"
GO


ALTER PROC dbo.CatalogItemExtendedInfoGet
(
     @CatalogItemXml              xml                 -- INPUT expects CatalogItem xml explained in description
    ,@ProductName                 nvarchar(1024)      -- INPUT expects Product name of the client
    ,@ProductVersion              nvarchar(25)        -- INPUT expects Product version of the client
    ,@ThreeLetterLanguageCode     char(3) = 'ENU'     -- INPUT expects three letter language code for the locale of returned info
    ,@IncludeUnpublishedItemsInd  bit = NULL          -- INPUT expects indicator on whether to include unpublished items
)
AS
/****************************************************************************

PROCEDURE NAME: CatalogItemExtendedInfoGet

AUTHOR: Aakash Mandhar (maaakash)

DATE: 08/28/2008

DESCRIPTION:
------------
This store procedure is used to retrieve CatalogItemExtendedInfo given the catalog item ids and a language code.

Sample Xml for CatalogItemXml:
<CatalogItems>
<CatalogItem ID="1"/>
<CatalogItem ID="2"/>
</CatalogItems>

MAINTENANCE LOG:

REVISION     DATE            EMAIL         DESCRIPTION
--------     ----            -----         -----------
1.0         08/28/2008       maaakash      Created Stored Procedure.

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

  -- Handle parameters
  set @IncludeUnpublishedItemsInd = ISNULL(@IncludeUnpublishedItemsInd,'false')
  set @ThreeLetterLanguageCode = ISNULL(@ThreeLetterLanguageCode,'ENU')

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

 
  -- Main select 
  SELECT 
	 c.CatalogItemId  -- CatalogItemId
	,Description = ISNULL(LocalizedDescription,DefaultDescription)
	,c.PublishedInd
  FROM 
	CatalogItem AS c
		LEFT JOIN CatalogItemLocalized AS loc ON loc.CatalogItemId = c.CatalogItemId and loc.ThreeLetterLanguageCode = @ThreeLetterLanguageCode
		JOIN CatalogProductCatalogItem AS pc ON c.CatalogItemId = pc.CatalogItemId
		JOIN CatalogProduct AS p ON p.ProductId = pc.ProductId  and p.ProductName = @ProductName and dbo.fn_MajorMinorVersionCompare(p.ProductVersion, @ProductVersion) = 0
  WHERE 
	(@IncludeUnpublishedItemsInd = 'true' OR PublishedInd = 'true')
	AND EXISTS (SELECT CatalogItemId from #CatalogItemIds AS ids WHERE ids.CatalogItemId = c.CatalogItemId)

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


-- Cleanup

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
