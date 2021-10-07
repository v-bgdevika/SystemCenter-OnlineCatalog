@ECHO OFF
REM ======================================================================
REM Test For Payload Directory
REM ======================================================================
if NOT EXIST %~dp0Payload GOTO :ErrorNoPayload


REM ======================================================================
REM Build Install Directory Path
REM ======================================================================
set VROOTNAME=WebConsole
set VROOTPATH=%SYSTEMDRIVE%\inetpub\wwwroot\%VROOTNAME%



REM ======================================================================
REM Create IIS VRoot 
REM ======================================================================
ECHO.
ECHO Creating directory %VROOTPATH%
%~dp0SetupPortalForIIS.vbs %VROOTPATH% %VROOTNAME% 1



REM ======================================================================
REM Copy Files
REM ======================================================================
ECHO Copying MonitoringPortal files
xcopy /S /Y %~dp0Payload\* %VROOTPATH%

REM ===Work-around for bug #179141, etc===
del /q %VROOTPATH%\bin\Microsoft.Mom.Isam.Interop.dll

REM ===Copy resources to correct location===
mkdir %VROOTPATH%\bin\en
copy %VROOTPATH%\bin\*.resources.dll %VROOTPATH%\bin\en


REM ======================================================================
REM ===Remove HTTP Global Compression Scheme===
REM
REM This compression scheme causes problems when enabling 32-bit apps in
REM Remove HTTP Global Compression Scheme
REM This compression scheme causes problems when enabling 32-bit apps in
REM the 64-bit DefaultAppPool. http://forums.iis.net/t/1149768.aspx.
REM ======================================================================
ECHO Removing HTTP Global Compression Scheme...
SetGlobalHttpCompressionScheme.cmd OFF


REM ======================================================================
REM Build the correct web.config file
REM ======================================================================
ECHO.
ECHO Generating web.config...
TextPreprocessor /i %VROOTPATH%\web.setup.config /o %VROOTPATH%\web.config /p:authmode='Mixed' /p:debug='false'


REM ======================================================================
REM ErrorNoPayload
REM ======================================================================
:ErrorNoPayload
ECHO ERROR: Payload not found
GOTO :Finish


:Finish
