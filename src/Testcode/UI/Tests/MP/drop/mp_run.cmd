@echo OFF
if defined ECHO (echo %ECHO%)
setlocal
pushd .

REM ======================================================================
REM
REM Copyright Microsoft Corp. 2003
REM
REM Module : MP
REM
REM Summary:
REM
REM History: 30AUG05 barryw - created
REM
REM ======================================================================

REM ======================================================================
REM Ensure proper parameters entered
REM ======================================================================
if {%1} equ {} (goto :Usage)
if {%1} equ {/?} (goto :Usage)
if {%1} equ {?} (goto :Usage)
if {%1} equ {-?} (goto :Usage)
if {%2} equ {} (goto :Usage)

set FEATURE=MP
set VARMAP=Mom.Test.UI.Tests.%FEATURE%.xml
set LOGFILE=%FEATURE%.Log
set LOGFILEV=Verbose_%FEATURE%.Log

echo %TIME% - Started %FEATURE%_run.cmd

if exist %LOGFILE% del %LOGFILE%
if exist %LOGFILEV% del %LOGFILEV%

REM ======================================================================
REM Set common variables (e.g., MACHINES, CONFIG, etc.)
REM ======================================================================
call :LogMsg - pushd ..\common
pushd ..\common
if {%ERRORLEVEL%} neq {0} (
    call :LogMsg COMMON directory not found. Ditspause called - ABORT
    ditspause.exe
    exit /b 1
)

call :LogMsg - Running UI_PreReq
call UI_PreReq.cmd %* null
if {%ERRORLEVEL%} neq {0} (
    call :LogMsg UI_PreReq.cmd returned errorlevel %ERRORLEVEL%. Ditspause called - ABORT
    ditspause.exe
    exit /b 1
)
popd

REM ======================================================================
REM TODO: Put general setup code and other stuff that always has to be done here
REM ======================================================================
pushd ..\common
regedit /s IEProxy-W2K8.reg
popd
echo Starting IE to send registry change signal...
pushd "%programfiles%/Internet Explorer"
start /B iexplore.exe
  if errorlevel 1 (
    echo ERROR: Unable to open IE
  )
ping localhost -n 10 -w 1000 >nul
popd
::Kill IE window
echo Killing IE...
taskkill /F /IM iexplore.exe

REM ======================================================================
REM Check if Machine has UI, if not look remotely
REM ======================================================================
cscript.exe ..\..\common\cdsfetch.vbs %USERDOMAIN%\%USERNAME%
call temp.bat
del temp.bat

set /A COUNT=0
..\..\CheckRole %COMPUTERNAME% UI
if {%ERRORLEVEL%} equ {0} (
    call :LogMsg Running UI Locally
    call :RunLocal
) else (
    call :LogMsg Running UI Remotely
    set RUNREMOTE=Y
    call :RunRemote
)
goto :Finish

:RunLocal
REM ======================================================================
REM Check for distributed and local tests
REM Currently, only local tests are supported
REM ======================================================================
REM if /i "%LOCAL%" equ "1" goto :LaunchLocal

REM if /i "%DIST%"  equ "1" goto :LaunchDist

REM call :LogMsg %CONFIG% - VAR_UNSUPPORTED

REM goto :Finish

:LaunchLocal
REM ======================================================================
REM Launch the tests
REM ======================================================================
if /i {%TEST%} equ {bvt} (goto :BVT)
if /i {%TEST%} equ {regression} (goto :Regression)
if /i {%TEST%} equ {func} (goto :Func)
goto :Finish

:BVT
REM ======================================================================
REM TODO: Code to run BVT set of tests
REM ======================================================================
..\..\mcf.exe /apt:sta /m:%VARMAP% /l:1 /log:%LOGFILE% /dbgloc:14 /logv:%LOGFILEV%

goto :Finish

REM ======================================================================
REM TODO: Code to run Regression set of tests
REM ======================================================================
:Regression
..\..\mcf.exe /apt:sta /m:%VARMAP% /l:1 /log:%LOGFILE% /dbgloc:14 /logv:%LOGFILEV%
..\..\mcf.exe /apt:sta /m:%VARMAP% /l:2 /log:%LOGFILE% /dbgloc:14 /logv:%LOGFILEV%

goto :Finish

REM ======================================================================
REM TODO: Code to run Functional set of tests
REM ======================================================================
:Func
..\..\mcf.exe /apt:sta /m:%VARMAP% /l:1 /log:%LOGFILE% /dbgloc:14 /logv:%LOGFILEV%
..\..\mcf.exe /apt:sta /m:%VARMAP% /l:2 /log:%LOGFILE% /dbgloc:14 /logv:%LOGFILEV%
..\..\mcf.exe /apt:sta /m:%VARMAP% /l:3 /log:%LOGFILE% /dbgloc:14 /logv:%LOGFILEV%

goto :Finish

REM ======================================================================
REM Launch distributed UI tests
REM ======================================================================
:LaunchDist

call :LogMsg %CONFIG% - VAR_UNSUPPORTED

goto :Finish

REM ======================================================================
REM TODO: Put any general cleanup code here
REM ======================================================================
:Finish

call ..\..\MiscTools\BackupTraceIfFailure.cmd %* %LOGFILE%

if defined RUNREMOTE (
    if /I {%RUNREMOTE%} neq {PASS} (call :LogMsg No UI Machines Found - VAR_ABORT)
)

goto :End

REM ======================================================================
REM Run Remotely
REM ======================================================================
:RunRemote
call :LogMsg RunRemote %COUNT%

for /F "tokens=* delims=," %%i in (%MACHINES%) do set /A COUNT=%COUNT%+1

set TEMP=
for /F "tokens=%COUNT% delims=," %%i in (%MACHINES%) do set TEMP=%%i

if not defined TEMP (
 set /A COUNT=%COUNT%-1
 goto :EOF
)

REM Skip current machine
if /i "%TEMP%" equ "%COMPUTERNAME%" goto :RunRemote

..\..\checkrole %TEMP% UI
if {%ERRORLEVEL%} equ {0} (
    RE /i /u %USERDOMAIN%\%USERNAME% /p %PASSWORD% %TEMP% "cmd.exe /c cd /d \%TEST%\UI\%FEATURE%&&%FEATURE%_run.cmd \"%MACHINES%\" %TEST%" >> %LOGFILE%
    set RUNREMOTE=pass
) else (
    goto :RunRemote
)
if "%ERRORLEVEL%" neq "0" (
    call :LogMsg Execution of %FEATURE%_run.cmd on remote machine %TEMP% failed
    set REMOTEEXEC_FAIL=1
)

goto :RunRemote

REM ======================================================================
REM Auxiliary Functions
REM ======================================================================
:LogMsg
setlocal
set STRMSG=%TIME% - %*
echo %STRMSG%
echo %STRMSG% >> %LOGFILE%
endlocal
goto :EOF

REM ======================================================================
REM Usage
REM ======================================================================
:Usage
echo.
echo Usage:
echo.
echo SCRIPT.CMD "MACHINES" TEST
echo.
echo HomeView: SCRIPT.CMD "MACHINE1,MACHINE2" BVT
echo.
echo Required Parameters:
echo    "MACHINES", TEST
echo.
echo Optional Parameters:
echo    None
echo.
echo Note: Quotes are required where provided in the example
echo.
goto :End

:End
popd
endlocal
