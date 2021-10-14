@ECHO OFF

type nul > %1\ManagementPackCatalog.AdminStoredProcedures.Setup.sql

REM name of the output file
set OUTFILE=%1\ManagementPackCatalog.AdminStoredProcedures.Setup.sql

REM dir where scripts can be found
set script_dir=\database

REM del %OUTFILE%


REM Generate the output file. Ignore any error messages

REM -----------------
SET ObjectType=Sprocs
REM -----------------

type AdminSiteSPs\CatalogCategoryAssignedManagementPackGet.SP.sql > %OUTFILE% 2>nul
type AdminSiteSPs\CatalogCategoryExtendedInfoGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogCategoryGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogCategoryLocGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogCategoryLocSet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogCategorySet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogCategoryUnAssignedManagementPackGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogItemAssociatedProductGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogItemPublish.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogItemUnAssociatedProductGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogManagementPackCategorySet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogManagementPackCategoryUnSet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogManagementPackDependencySet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogManagementPackExtendedInfoGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogManagementPackGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogManagementPackLocGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogManagementPackLocSet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogManagementPackSet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogProductCatalogItemGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogProductCatalogItemSet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogProductCatalogItemUnSet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogProductGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogProductSet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogVendorGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogVendorLocGet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogVendorLocSet.SP.sql >> %OUTFILE% 2>nul
type AdminSiteSPs\CatalogVendorSet.SP.sql >> %OUTFILE% 2>nul