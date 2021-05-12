IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CatalogVendorLocalized' AND TABLE_SCHEMA = 'dbo')
BEGIN

DROP TABLE CatalogVendorLocalized

END
GO

CREATE TABLE CatalogVendorLocalized
(
	VendorId					int					NOT NULL
	,ThreeLetterLanguageCode	char(3)				NOT NULL
	,LocalizedVendorName		nvarchar(1024)		NULL
	,LocalizedVendorLink		nvarchar(1024)		NULL
	
    ,CONSTRAINT PK_CatalogVendorLocalized PRIMARY KEY CLUSTERED (VendorId ASC, ThreeLetterLanguageCode ASC)
	,CONSTRAINT FK_CatalogVendor_CatalogVendorLocalized FOREIGN KEY (VendorId) REFERENCES CatalogVendor (VendorId) ON DELETE CASCADE
)
GO
