@ECHO OFF

REM -----------------------------------------------------
REM - Script to create functions and SPs
REM -----------------------------------------------------

type AdminSiteSPs\CatalogCategoryAssignedManagementPackGet.SP.sql > %1
type AdminSiteSPs\CatalogCategoryExtendedInfoGet.SP.sql >> %1
type AdminSiteSPs\CatalogCategoryGet.SP.sql >> %1
type AdminSiteSPs\CatalogCategoryLocGet.SP.sql >> %1
type AdminSiteSPs\CatalogCategoryLocSet.SP.sql >> %1
type AdminSiteSPs\CatalogCategorySet.SP.sql >> %1
type AdminSiteSPs\CatalogCategoryUnAssignedManagementPackGet.SP.sql >> %1
type AdminSiteSPs\CatalogItemAssociatedProductGet.SP.sql >> %1
type AdminSiteSPs\CatalogItemPublish.SP.sql >> %1
type AdminSiteSPs\CatalogItemUnAssociatedProductGet.SP.sql >> %1
type AdminSiteSPs\CatalogManagementPackCategorySet.SP.sql >> %1
type AdminSiteSPs\CatalogManagementPackCategoryUnSet.SP.sql >> %1
type AdminSiteSPs\CatalogManagementPackDependencySet.SP.sql >> %1
type AdminSiteSPs\CatalogManagementPackExtendedInfoGet.SP.sql >> %1
type AdminSiteSPs\CatalogManagementPackGet.SP.sql >> %1
type AdminSiteSPs\CatalogManagementPackLocGet.SP.sql >> %1
type AdminSiteSPs\CatalogManagementPackLocSet.SP.sql >> %1
type AdminSiteSPs\CatalogManagementPackSet.SP.sql >> %1
type AdminSiteSPs\CatalogProductCatalogItemGet.SP.sql >> %1
type AdminSiteSPs\CatalogProductCatalogItemSet.SP.sql >> %1
type AdminSiteSPs\CatalogProductCatalogItemUnSet.SP.sql >> %1
type AdminSiteSPs\CatalogProductGet.SP.sql >> %1
type AdminSiteSPs\CatalogProductSet.SP.sql >> %1
type AdminSiteSPs\CatalogVendorGet.SP.sql >> %1
type AdminSiteSPs\CatalogVendorLocGet.SP.sql >> %1
type AdminSiteSPs\CatalogVendorLocSet.SP.sql >> %1
type AdminSiteSPs\CatalogVendorSet.SP.sql >> %1