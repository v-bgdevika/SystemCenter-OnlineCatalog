IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogItem' AND TABLE_SCHEMA = 'dbo')
BEGIN

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogItem_CatalogItemLocalized')
    ALTER TABLE CatalogItemLocalized DROP CONSTRAINT FK_CatalogItem_CatalogItemLocalized

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogItem_CatalogCategory')
    ALTER TABLE CatalogCategory DROP CONSTRAINT FK_CatalogItem_CatalogCategory

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogItem_CatalogManagementPack')
    ALTER TABLE CatalogManagementPack DROP CONSTRAINT FK_CatalogItem_CatalogManagementPack

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogItem_CatalogProductCatalogItem ')
    ALTER TABLE CatalogProductCatalogItem  DROP CONSTRAINT FK_CatalogItem_CatalogProductCatalogItem 

DROP TABLE dbo.CatalogItem
END
GO


CREATE TABLE dbo.CatalogItem
(
	CatalogItemId			int				NOT NULL	IDENTITY(1,1) NOT FOR REPLICATION 
	,IsManagementPack		bit				NOT NULL	DEFAULT(0)
	,IsCategory				bit				NOT NULL	DEFAULT(1)
	,PublishedInd			bit				NOT NULL	DEFAULT(0)
	,DefaultDisplayName		nvarchar(1024)	NOT NULL
	,DefaultDescription		nvarchar(MAX)	NOT NULL

    ,CONSTRAINT PK_CatalogItem PRIMARY KEY CLUSTERED (CatalogItemId ASC)

)

GO

