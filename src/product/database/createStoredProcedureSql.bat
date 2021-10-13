@ECHO OFF

REM name of the output file
set OUTFILE=%1\CreateStoredProcedureSql.sql

set script_dir=\database

del %OUTFILE%
SET ObjectType=Sprocs

REM -----------------------------------------------------
REM - Script to create functions and SPs
REM -----------------------------------------------------

type Function\fn_VersionCompare.FN.sql >  %OUTFILE% 2>nul
type Function\fn_MajorMinorVersionCompare.FN.sql >>  %OUTFILE% 2>nul
type HelperSPs\CategoryGet.SP.sql >>  %OUTFILE% 2>nul
type HelperSPs\CategoryParentIdsGet.SP.SQL >>  %OUTFILE% 2>nul
type HelperSPs\CategorySubCategoryIdsGet.SP.sql >>  %OUTFILE% 2>nul
type WebserviceSPs\CatalogItemExtendedInfoGet.SP.sql >>  %OUTFILE% 2>nul
type WebserviceSPs\ManagementPackDependenciesGet.SP.sql >>  %OUTFILE% 2>nul
type WebserviceSPs\ManagementPackExtendedInfoGet.SP.sql >>  %OUTFILE% 2>nul
type WebserviceSPs\ManagementPackGet.SP.sql >>  %OUTFILE% 2>nul
type WebserviceSPs\ManagementPackList.SP.sql >>  %OUTFILE% 2>nul
type WebserviceSPs\ManagementPackSearch.SP.sql >>  %OUTFILE% 2>nul