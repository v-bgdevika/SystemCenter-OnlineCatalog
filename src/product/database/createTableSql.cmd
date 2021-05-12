@ECHO OFF

REM -----------------------------------------------------
REM - Script to create a single sql file to create tables
REM -----------------------------------------------------

type tables\CatalogItem.Table.sql >%1
type tables\CatalogItemLocalized.Table.sql >>%1
type tables\CatalogCategory.Table.sql >>%1
type tables\CatalogCategoryLocalized.Table.sql >>%1
type tables\CatalogVendor.Table.sql >>%1
type tables\CatalogVendorLocalized.Table.sql >>%1
type tables\CatalogManagementPack.Table.sql >>%1
type tables\CatalogManagementPackLocalized.Table.sql >>%1
type tables\CatalogManagementPackCategory.Table.sql >>%1
type tables\CatalogManagementPackDependency.Table.sql >>%1
type tables\CatalogProduct.Table.sql >>%1
type tables\CatalogProductCatalogItem.Table.sql >>%1
