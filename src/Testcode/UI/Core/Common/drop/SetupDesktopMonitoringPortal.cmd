@ECHO OFF
REM ======================================================================
REM Test For Bin Directory
REM ======================================================================
if NOT EXIST %~dp0bin GOTO :ErrorNoBins


REM ======================================================================
REM Build Install Directory Path
REM ======================================================================
if %PROCESSOR_ARCHITECTURE% == "AMD64" (
   set INSTALLDIR="%PROGRAMFILES%\Microsoft\MonitoringPortal.Desktop.Setup"
) else (
   set INSTALLDIR="%PROGRAMFILES(X86)%\Microsoft\MonitoringPortal.Desktop.Setup"
)


REM ======================================================================
REM Create Install Directory
REM ======================================================================
ECHO.
ECHO Creating directory %INSTALLDIR%
mkdir %INSTALLDIR%


REM ======================================================================
REM Test For Install Directory
REM ======================================================================
if NOT EXIST %INSTALLDIR% GOTO :ErrorNoInstallDir


REM ======================================================================
REM Copy Binaries
REM ======================================================================
ECHO.
ECHO Copying MonitoringPortal binaries
xcopy /Y %~dp0bin\* %INSTALLDIR%

REM ======================================================================
REM Create Desktop Shortcut
REM ======================================================================
if EXIST %INSTALLDIR%\MonitoringPortal.exe (
   ECHO.
   ECHO Creating MonitoringPortal desktop shortcut
   cscript.exe %~dp0CreateMonitoringPortalShortcut.vbs %INSTALLDIR%\MonitoringPortal.exe
) else (
   GOTO :ErrorNoPortalExe
)

GOTO :Finish

REM ======================================================================
REM ErrorNoBins
REM ======================================================================
:ErrorNoBins
ECHO ERROR: bins not found
GOTO :Finish


REM ======================================================================
REM ErrorNoInstallDir
REM ======================================================================
:ErrorNoInstallDir
ECHO ERROR: %INSTALLDIR% not found
GOTO :FINISH


REM ======================================================================
REM ErrorNoPortalExe
REM ======================================================================
:ErrorNoPortalExe
ECHO ERROR: Unable to create shortcut - %INSTALLDIR%\MonitoringPortal.exe not found
GOTO :FINISH

:Finish