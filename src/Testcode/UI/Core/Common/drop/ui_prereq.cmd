@if "%echo%"=="" (@echo off) else (@echo on)

pushd .

REM ======================================================================
REM
REM Copyright Microsoft Corp. 2003
REM
REM Module : UI_PreReq.cmd
REM
REM Summary: Sets up the global pre-req's for MOM tests
REM
REM History: (09/11/2006) mbickle
REM          (09/26/2007) KellyMor - Added fix for Longhorn/Vista X64 AA
REM
REM ======================================================================

REM ======================================================================
REM Ensure proper parameters entered
REM ======================================================================
if {%1} equ {}   (goto :Usage)
if {%1} equ {/?} (goto :Usage)
if {%1} equ {?}  (goto :Usage)
if {%1} equ {-?} (goto :Usage)
if {%2} equ {} (goto :Usage)

REM ======================================================================
REM
REM ======================================================================

set UIPREREQ_LOGFILE=ui_prereq.log

call :LogMsg Starting UI_PreReq.cmd

REM ======================================================================
REM Set MOM Path
REM ======================================================================
..\..\momcommon\momdir.exe /header:"set MOMDIR=%PATH%;">temp.bat
call temp.bat
del temp.bat
..\..\momcommon\momdir.exe /header:"set MOMDIR=">temp.bat
call temp.bat
del temp.bat

call :LogMsg - pushd ..\..\PreReq
pushd ..\..\PreReq
if {%ERRORLEVEL%} neq {0} (
    call :LogMsg PreReq directory not found. Ditspause called - ABORT
    ditspause.exe
    exit /b 1
)

call :LogMsg - Running PreReq
call PreReq_run_full.cmd %* null
if {%ERRORLEVEL%} neq {0} (
    call :LogMsg PreReq_run.cmd returned errorlevel %ERRORLEVEL%. Ditspause called - ABORT
    ditspause.exe
    exit /b 1
)

call :LogMsg - Running ExecNames
call ExecNames.cmd %* null
if {%ERRORLEVEL%} neq {0} (
   call :LogMsg ExecNames returned errorlevel %ERRORLEVEL%. Ditspause called - ABORT
   ditspause.exe
   exit /b 1
)
popd

call :LogMsg - Checking for Longhorn/Vista X64
call ui_fixaa64.cmd
if {%ERRORLEVEL%} neq {0} (
    call :LogMsg ui_fixaa64.cmd returned errorlevel %ERRORLEVEL%. Ditspause called - ABORT
    ditspause.exe
    exit /b 1
)


call :LogMsg - pushd ..\..\MAUI
pushd ..\..\MAUI
if {%ERRORLEVEL%} neq {0} (
    call :LogMsg MAUI directory not found. Ditspause called - ABORT
    ditspause.exe
    exit /b 1
)

REM call :LogMsg - Running install.cmd for Registering RPF binaries
REM call Install.cmd
REM if {%ERRORLEVEL%} neq {0} (
REM    call :LogMsg Install.cmd returned errorlevel %ERRORLEVEL%. Ditspause called - ABORT
REM    ditspause.exe
REM    exit /b 1
REM )
popd

REM ======================================================================
REM Copy Microsoft.Mom.Common.dll 
REM ======================================================================
call :LogMsg Copying files.
xcopy "%MOMDIR%\Microsoft.Mom.Common.dll" . /Y

REM ======================================================================
REM Copy cover build dependency for Cover Build 
REM ======================================================================
call :LogMsg CopyCoverDependency.cmd file
if exist %systemdrive%\CopyCoverDependency.cmd (
call %systemdrive%\CopyCoverDependency.cmd
)

REM ======================================================================
REM Restart scom database service to workaround test bug #410501
REM ======================================================================
call PowerShell -file .\Throttle-SQLMemory.ps1

goto :Finish

REM ======================================================================
REM General cleanup code - log success
REM ======================================================================
:Finish

call :LogMsg Finished

goto :End

REM ======================================================================
REM Logging Function - log to screen and file
REM ======================================================================
:LogMsg

setlocal
set STRMSG=%TIME% - %*
echo %STRMSG%
echo %STRMSG% >> %UIPREREQ_LOGFILE%
endlocal
goto :EOF

REM ======================================================================
REM Usage
REM ======================================================================
:Usage
echo.
echo Usage:
echo.
echo UI_PreReq.CMD "MACHINES" TEST
echo.
echo Example: UI_PreReq.CMD "MACHINE1,MACHINE2" BVT
echo.
echo Required Parameters:
echo    "MACHINES", TEST
echo.
echo Note: Quotes are required where provided in the example
echo.
goto :End

:End
popd
