IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogManagementPackDependency' AND TABLE_SCHEMA = 'dbo')
BEGIN

DROP TABLE dbo.CatalogManagementPackDependency
END
GO

CREATE TABLE CatalogManagementPackDependency
(
	ManagementPackCatalogItemId		int					NOT NULL
	,DependentMpVersionIndependentGuid	uniqueidentifier			NOT NULL
	,DependentMpVersion			nvarchar(25)				NOT NULL
	
	,CONSTRAINT PK_CatalogManagementPackDependency	PRIMARY KEY CLUSTERED ( ManagementPackCatalogItemId ASC, DependentMpVersionIndependentGuid ASC)
	,CONSTRAINT FK_CatalogManagementPack_CatalogManagementPackDependency FOREIGN KEY (ManagementPackCatalogItemId) REFERENCES CatalogManagementPack (CatalogItemId) ON DELETE CASCADE

)

GO
