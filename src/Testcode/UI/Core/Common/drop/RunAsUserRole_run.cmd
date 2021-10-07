@echo OFF
if defined ECHO (echo %ECHO%)
setlocal
pushd .

REM ======================================================================
REM
REM Copyright Microsoft Corp. 2003
REM
REM Module : RunAsUserRole
REM
REM Summary:
REM
REM History: 5April07 ruhim - created
REM          9April09 a-mujtch - RE call replaced by RunProcessAs to
REM                              fix session 0 isolation issue in
REM                              Win2K8/Vista and above
REM	     22JAN10 v-dayow - Add the call to remove test accounts from user roles.
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
if {%3} equ {} (goto :Usage)
if {%4} equ {} (goto :Usage)
if {%5} equ {} (goto :Usage)
if {%6} equ {} (goto :Usage)
if {%7} equ {} (goto :Usage)
if {%8} equ {} (goto :Usage)

set RunAsLOGFILE=RunAsUserRole.log
set TESTLOGFILE=AdministratorsMembers.log
set RunAsUser=%1
set Password=%2
set FEATURE=%3
set TEST=%4
set LEVEL=%5
set Temp=%6
set VARMAP=%7
set LOGFILE=%8
set LOGFILEV=%9

echo %TIME% - Started RunAsUserRole_run.cmd

if exist %TESTLOGFILE% del %TESTLOGFILE%

call :LogMsg RunAsUserRole.cmd - arguments = %*

REM ======================================================================
REM Code that would run add user role members and also to Local Administrators group
REM ======================================================================


call :LogMsg Running Powershell commands

%SYSTEMDRIVE%\%TEST%\momcommon\momdir.exe /header:"set MOMDIR=" /console>temp.bat
call temp.bat
del temp.bat

call :LogMsg Set MOMDIR path

rem pushd %MOMDIR%
cd /d %MOMDIR%

%WINDIR%\system32\windowspowershell\v1.0\powershell.exe -PSConsoleFile Microsoft.EnterpriseManagement.OperationsManager.ClientShell.Console.psc1 ".\Microsoft.EnterpriseManagement.OperationsManager.ClientShell.NonInteractiveStartup.ps1;%SYSTEMDRIVE%\%TEST%\UI\common\addtestaccountstouserRoles.ps1"&& cd %SYSTEMDRIVE%\%TEST%\UI\%FEATURE%

rem popd

call :LogMsg RunAsUserRole_run.cmd - checking for Administrators members in %TESTLOGFILE%

net localgroup "Administrators" >> %TESTLOGFILE%
findstr /i /c:"smx\momauthor" %TESTLOGFILE%
if %ERRORLEVEL% neq 0 (
   call :LogMsg
   call :LogMsg smx\momauthor not found. Adding to Administrators role
   net localgroup "Administrators" "smx\momauthor" /add	
)

findstr /i /c:"smx\smx_user" %TESTLOGFILE%
if %ERRORLEVEL% neq 0 (
   call :LogMsg
   call :LogMsg smx\smx_user not found. Adding to Administrators role
   net localgroup "Administrators" "smx\smx_user" /add	
)

findstr /i /c:"smx\momuser" %TESTLOGFILE%
if %ERRORLEVEL% neq 0 (
   call :LogMsg
   call :LogMsg smx\momuser not found. Adding to Administrators role
   net localgroup "Administrators" "smx\momuser" /add	
)

findstr /i /c:"smx\momreporting" %TESTLOGFILE%
if %ERRORLEVEL% neq 0 (
   call :LogMsg
   call :LogMsg smx\momreporting not found. Adding to Administrators role
   net localgroup "Administrators" "smx\momreporting" /add	
)

findstr /i /c:"smx\momDW" %TESTLOGFILE%
if %ERRORLEVEL% neq 0 (
   call :LogMsg
   call :LogMsg smx\momDW not found. Adding to Administrators role
   net localgroup "Administrators" "smx\momDW" /add	
)
findstr /i /c:"smx\momDB" %TESTLOGFILE%
if %ERRORLEVEL% neq 0 (
   call :LogMsg
   call :LogMsg smx\momDB not found. Adding to Administrators role
   net localgroup "Administrators" "smx\momDB" /add	
)
call :LogMsg Launch the frmwk as User %RunAsUser%
REM RE /i /u %RunAsUser% /p %Password% %Temp% "cmd.exe /c cd %SYSTEMDRIVE%\%TEST%\UI\%FEATURE%&&..\..\mcf.exe /apt:sta /m:%VARMAP% %LEVEL% /log:%LOGFILE% /dbgloc:14 /logv:%LOGFILEV%"
REM %SYSTEMDRIVE%\%TEST%\MOMCommon\RunProcessAs %RunAsUser% %Password% "%SYSTEMDRIVE%\%TEST%\UI\%FEATURE%" "cmd.exe" "/c ..\..\mcf.exe /apt:sta /m:%VARMAP% %LEVEL% /log:%LOGFILE% /dbgloc:14 /logv:%LOGFILEV%"
..\..\mcf.exe /apt:sta /m:%VARMAP% %LEVEL% /log:%LOGFILE% /dbgloc:14 /logv:%LOGFILEV%
set RunAsUser=
set Password=

call :LogMsg Remove test accounts from user roles
cd /d %MOMDIR%
%WINDIR%\system32\windowspowershell\v1.0\powershell.exe -PSConsoleFile Microsoft.EnterpriseManagement.OperationsManager.ClientShell.Console.psc1 ".\Microsoft.EnterpriseManagement.OperationsManager.ClientShell.NonInteractiveStartup.ps1;%SYSTEMDRIVE%\%TEST%\UI\common\RemoveTestAccountsFromUserRoles.ps1"&& cd %SYSTEMDRIVE%\%TEST%\UI\%FEATURE%

REM ======================================================================
REM Auxiliary Functions
REM ======================================================================
:LogMsg
setlocal
set STRMSG=%TIME% - %*
echo %STRMSG%
echo %STRMSG% >> %RunAsLOGFILE%
endlocal
goto :EOF


REM ======================================================================
REM Usage
REM ======================================================================
:Usage
echo.
echo Usage:
echo.
echo SCRIPT.CMD UserName Password Feature TEST ComputerName VARMAP LOGFILE LOGFILEV
echo.
echo Required Parameters:
echo    UserName, Password, Feature, TEST, ComputerName, VARMAP, LOGFILE, LOGFILEV
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
