@echo off
REM ========================================
REM Process Command-line Args
REM ========================================
if {%1} == {} ( goto :Usage )
if {%1} == {-?} ( goto :Usage )
if {%1{ == {/?} ( goto :Usage )
if {%1} == {-help} ( goto :Usage )
if {%1} == {/help} ( goto :Usage )

REM ========================================
REM Enable/Disable Http Compression Scheme
REM ========================================
if /i %1 EQU ON (
   %windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /+[name='xpress',doStaticCompression='false',dll='%windir%\system32\inetsrv\suscomp.dll']
   goto :Finish
) 

if /i %1 EQU OFF (
   %windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /-[name='xpress']
   goto :Finish
)

goto :Error


REM ========================================
REM Usage
REM ========================================
:Usage
echo.
echo SetGlobalHttpCompressionScheme.cmd [ON/OFF]
echo.
goto :Finish

REM ========================================
REM Invalid Arguments
REM ========================================
:Error
echo.
echo Invalid Argument '%1'
echo. 
goto :Usage

:Finish