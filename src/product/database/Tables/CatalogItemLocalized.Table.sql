
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogItemLocalized' AND TABLE_SCHEMA = 'dbo')
BEGIN

DROP TABLE dbo.CatalogItemLocalized
END
GO

CREATE TABLE dbo.CatalogItemLocalized
(
	CatalogItemId				int				NOT NULL
	,ThreeLetterLanguageCode	char(3)			NOT NULL
	,LocalizedDisplayName		nvarchar(1024)	NULL
	,LocalizedDescription		nvarchar(MAX)	NULL

	,CONSTRAINT PK_CatalogItemLocalized PRIMARY KEY CLUSTERED (CatalogItemId ASC, ThreeLetterLanguageCode ASC)
	,CONSTRAINT FK_CatalogItem_CatalogItemLocalized FOREIGN KEY (CatalogItemId) REFERENCES CatalogItem (CatalogItemId) ON DELETE CASCADE

)
GO

