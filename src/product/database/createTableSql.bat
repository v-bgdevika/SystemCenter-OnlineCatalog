@ECHO OFF

type nul > ManagementPackCatalog.Tables.Setup.sql
REM name of the output file
set OUTFILE=%1\ManagementPackCatalog.Tables.Setup.sql

REM dir where scripts can be found
set script_dir=..\database

del %OUTFILE%

REM Generate the output file. Ignore any error messages

REM -----------------
SET ObjectType=Tables
REM -----------------

REM -----------------------------------------------------
REM - Script to create a single sql file to create tables
REM -----------------------------------------------------

type  tables\CatalogItem.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogItemLocalized.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogCategory.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogCategoryLocalized.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogVendor.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogVendorLocalized.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogManagementPack.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogManagementPackLocalized.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogManagementPackCategory.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogManagementPackDependency.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogProduct.Table.sql >> %OUTFILE% 2>nul
type  tables\CatalogProductCatalogItem.Table.sql >> %OUTFILE% 2>nul
