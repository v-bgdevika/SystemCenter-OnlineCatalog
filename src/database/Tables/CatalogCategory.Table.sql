IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogCategory' AND TABLE_SCHEMA = 'dbo')
BEGIN

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogCategory_CatalogManagementPackCategory')
    ALTER TABLE CatalogManagementPackCategory DROP CONSTRAINT FK_CatalogCategory_CatalogManagementPackCategory

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogCategory_CatalogCategoryLocalized')
    ALTER TABLE CatalogCategoryLocalized DROP CONSTRAINT FK_CatalogCategory_CatalogCategoryLocalized


DROP TABLE dbo.CatalogCategory
END
GO

CREATE TABLE dbo.CatalogCategory
(
	CatalogItemId			int				NOT NULL
	,ParentCategoryId		int				NOT NULL
	,DefaultGuideUriText		nvarchar(1024)		NOT NULL
	,DefaultGuideUriLink		nvarchar(1024)		NOT NULL

    ,CONSTRAINT PK_CatalogCategory PRIMARY KEY CLUSTERED (CatalogItemId ASC)
	,CONSTRAINT FK_CatalogItem_CatalogCategory FOREIGN KEY (CatalogItemId) REFERENCES CatalogItem (CatalogItemId) ON DELETE CASCADE
    
)
GO
