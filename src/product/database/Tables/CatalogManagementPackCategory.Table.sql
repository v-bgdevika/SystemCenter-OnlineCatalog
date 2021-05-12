IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogManagementPackCategory' AND TABLE_SCHEMA = 'dbo')
BEGIN

DROP TABLE dbo.CatalogManagementPackCategory
END
GO

CREATE TABLE CatalogManagementPackCategory
(
	ManagementPackCatalogItemId		int		NOT NULL
	,CategoryCatalogItemId			int		NOT NULL
	
	,CONSTRAINT PK_CatalogManagementPackCategory PRIMARY KEY CLUSTERED (ManagementPackCatalogItemId ASC, CategoryCatalogItemId ASC)
	,CONSTRAINT FK_CatalogManagementPack_CatalogManagementPackCategory FOREIGN KEY (ManagementPackCatalogItemId) REFERENCES CatalogManagementPack (CatalogItemId) ON DELETE CASCADE
	,CONSTRAINT FK_CatalogCategory_CatalogManagementPackCategory FOREIGN KEY (CategoryCatalogItemId) REFERENCES CatalogCategory (CatalogItemId)
)

GO
