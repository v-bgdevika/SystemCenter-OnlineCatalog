IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogProduct' AND TABLE_SCHEMA = 'dbo')
BEGIN

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogProduct_CatalogProductCatalogItem ')
    ALTER TABLE CatalogProductCatalogItem  DROP CONSTRAINT FK_CatalogProduct_CatalogProductCatalogItem 

DROP TABLE CatalogProduct
END
GO


CREATE TABLE CatalogProduct
(
	ProductId					int					NOT NULL IDENTITY(1,1) NOT FOR REPLICATION
	,ProductName			nvarchar(1024)		NOT NULL
	,ProductVersion			nvarchar(25)		NOT NULL
	
	,CONSTRAINT PK_CatalogProduct PRIMARY KEY CLUSTERED (ProductId ASC)
)
GO
