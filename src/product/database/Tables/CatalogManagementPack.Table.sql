IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogManagementPack' AND TABLE_SCHEMA = 'dbo')
BEGIN

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogManagementPack_CatalogManagementPackLocalized')
    ALTER TABLE CatalogManagementPackLocalized DROP CONSTRAINT FK_CatalogManagementPack_CatalogManagementPackLocalized

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogManagementPack_CatalogManagementPackCategory')
    ALTER TABLE CatalogManagementPackCategory DROP CONSTRAINT FK_CatalogManagementPack_CatalogManagementPackCategory

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogManagementPack_CatalogManagementPackDependency')
    ALTER TABLE CatalogManagementPackDependency DROP CONSTRAINT FK_CatalogManagementPack_CatalogManagementPackDependency


DROP TABLE CatalogManagementPack
END
GO

CREATE TABLE CatalogManagementPack
(
	CatalogItemId             int              NOT NULL
	,VersionIndependentGuid   uniqueidentifier NOT NULL
	,Version                  nvarchar(25)     NOT NULL
	,SystemName               nvarchar(256)    NOT NULL
	,PublicKey                varchar(32)      NOT NULL
	,ReleaseDate              datetime         NOT NULL DEFAULT (GETUTCDATE())
	,VendorId                 int              NOT NULL
	,DownloadUri              nvarchar(1024)   NOT NULL
	,DefaultKnowledge         nvarchar(MAX)    NOT NULL
	,EulaInd                  bit              NOT NULL DEFAULT (0)
	,DefaultEula              nvarchar(MAX)
        ,SecurityInd              bit   NOT NULL DEFAULT(0)
	
    ,CONSTRAINT PK_CatalogManagementPack PRIMARY KEY CLUSTERED (CatalogItemId ASC)
	,CONSTRAINT FK_CatalogItem_CatalogManagementPack FOREIGN KEY (CatalogItemId) REFERENCES CatalogItem (CatalogItemId) ON DELETE CASCADE
	,CONSTRAINT FK_CatalogVendor_CatalogManagementPack FOREIGN KEY (VendorId) REFERENCES CatalogVendor (VendorId) ON DELETE CASCADE
	,CONSTRAINT UN_CatalogManagementPack_Guid_Version	UNIQUE ( VersionIndependentGuid , Version )

)
GO
