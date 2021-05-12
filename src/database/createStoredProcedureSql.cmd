@ECHO OFF

REM -----------------------------------------------------
REM - Script to create functions and SPs
REM -----------------------------------------------------

type Function\fn_VersionCompare.FN.sql > %1
type Function\fn_MajorMinorVersionCompare.FN.sql >> %1
type HelperSPs\CategoryGet.SP.sql >> %1
type HelperSPs\CategoryParentIdsGet.SP.SQL >> %1
type HelperSPs\CategorySubCategoryIdsGet.SP.sql >> %1
type WebserviceSPs\CatalogItemExtendedInfoGet.SP.sql >> %1
type WebserviceSPs\ManagementPackDependenciesGet.SP.sql >> %1
type WebserviceSPs\ManagementPackExtendedInfoGet.SP.sql >> %1
type WebserviceSPs\ManagementPackGet.SP.sql >> %1
type WebserviceSPs\ManagementPackList.SP.sql >> %1
type WebserviceSPs\ManagementPackSearch.SP.sql >> %1