IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogVendor' AND TABLE_SCHEMA = 'dbo')
BEGIN

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogVendor_CatalogManagementPack')
    ALTER TABLE CatalogManagementPack DROP CONSTRAINT FK_CatalogVendor_CatalogManagementPack

  IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_CatalogVendor_CatalogVendorLocalized')
    ALTER TABLE CatalogVendorLocalized DROP CONSTRAINT FK_CatalogVendor_CatalogVendorLocalized

DROP TABLE CatalogVendor

END
GO

CREATE TABLE CatalogVendor
(
	VendorId				int					NOT NULL	IDENTITY(1,1)	NOT FOR REPLICATION
	,DefaultVendorName		nvarchar(1024)		NOT NULL
	,DefaultVendorLink		nvarchar(1024)		NOT NULL
	
	,CONSTRAINT PK_CatalogVendor PRIMARY KEY CLUSTERED (VendorId ASC)
)
GO
