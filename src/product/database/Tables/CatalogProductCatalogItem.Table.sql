IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogProductCatalogItem' AND TABLE_SCHEMA = 'dbo')
BEGIN


DROP TABLE CatalogProductCatalogItem
END
GO

CREATE TABLE CatalogProductCatalogItem
(
	ProductId			int			NOT NULL
	,CatalogItemId		int			NOT NULL	
	
	,CONSTRAINT PK_CatalogProductCatalogItem PRIMARY KEY CLUSTERED (ProductId ASC,CatalogItemId ASC)
	,CONSTRAINT FK_CatalogProduct_CatalogProductCatalogItem FOREIGN KEY (ProductId) REFERENCES CatalogProduct (ProductId) ON DELETE CASCADE
	,CONSTRAINT FK_CatalogItem_CatalogProductCatalogItem FOREIGN KEY (CatalogItemId) REFERENCES CatalogItem (CatalogItemId) ON DELETE CASCADE
)
GO
