IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogCategoryLocalized' AND TABLE_SCHEMA = 'dbo')
BEGIN



DROP TABLE dbo.CatalogCategoryLocalized
END
GO

CREATE TABLE dbo.CatalogCategoryLocalized
(
	CatalogItemId			int				NOT NULL
	,ThreeLetterLanguageCode	char(3)				NOT NULL
	,LocalizedGuideUriText		nvarchar(1024)		NULL
	,LocalizedGuideUriLink		nvarchar(1024)		NULL

    ,CONSTRAINT PK_CatalogCategoryLocalized PRIMARY KEY CLUSTERED (CatalogItemId ASC, ThreeLetterLanguageCode ASC)
    ,CONSTRAINT FK_CatalogCategory_CatalogCategoryLocalized FOREIGN KEY (CatalogItemId) REFERENCES CatalogCategory (CatalogItemId) ON DELETE CASCADE
    
)
GO
