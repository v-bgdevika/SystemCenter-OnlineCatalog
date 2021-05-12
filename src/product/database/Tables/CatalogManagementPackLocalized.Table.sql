IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogManagementPackLocalized' AND TABLE_SCHEMA = 'dbo')
BEGIN

DROP TABLE CatalogManagementPackLocalized
END
GO

CREATE TABLE CatalogManagementPackLocalized
(
	CatalogItemId				int					NOT NULL
	,ThreeLetterLanguageCode	char(3)				NOT NULL
	,LocalizedKnowledge			nvarchar(MAX)		NULL
	,LocalizedEula				nvarchar(MAX)		NULL
	
    ,CONSTRAINT PK_CatalogManagementPackLocalized PRIMARY KEY CLUSTERED (CatalogItemId ASC, ThreeLetterLanguageCode ASC)
	,CONSTRAINT FK_CatalogManagementPack_CatalogManagementPackLocalized FOREIGN KEY (CatalogItemId) REFERENCES CatalogManagementPack (CatalogItemId) ON DELETE CASCADE

)
GO
