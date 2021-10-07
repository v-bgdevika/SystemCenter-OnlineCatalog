@if "%echo%"=="" (@echo off) else (@echo on)

pushd .

REM ======================================================================
REM
REM Copyright Microsoft Corp. 2007
REM
REM Module : UI_fixaa64.cmd
REM
REM Summary: Modifies registry entries for IAccessible interface for
REM          Gridview control on Longhorn/Vista X64 machines
REM
REM History: (09/26/2007) kellymor
REM
REM ======================================================================

REM ======================================================================
REM Set log file and log start up
REM ======================================================================

set UIFIXAA64_LOGFILE=ui_fixaax64.log
set REGFILE=fixaax64.reg

if exist %UIFIXAA64_LOGFILE% del %UIFIXAA64_LOGFILE%

call :LogMsg Starting UI_FixAA64.cmd

REM ======================================================================
REM Check OSVer and PROCESSOR_ARCHITECTURE
REM ======================================================================

REM Check if OSVer is defined
if defined OSVer (

	REM Check if OSVer is LONGHORN for Longhorn Server and Vista
	if /I {%OSVer%} equ {LONGHORN} (

		REM Check if PROCESSOR_ARCHITECTURE is defined
		if defined PROCESSOR_ARCHITECTURE (

			REM Check if PROCESSOR_ARCHITECTURE is AMD64 for X64 (Intel or AMD)
			if /I {%PROCESSOR_ARCHITECTURE%} equ {AMD64} (

				REM Check for registry file
				if exist "%CD%\%REGFILE%" (
					
					REM Merge registry key

					call :LogMsg Merging Active Accessibility Registry keys from "%CD%\%REGFILE%"
					REG IMPORT "%CD%\%REGFILE%"

					REM Check Error Level
					if {%ERRORLEVEL%} equ {0} (
						call :LogMsg Successfully merged registry keys

					) ELSE (
						call :LogMsg Error merging registry keys!
					)
				) ELSE (
					
					REM Registry file not found

					call :LogMsg Registry file not found:  "%CD%\%REGFILE%"
					set ERRORLEVEL=1
				)
			) ELSE (
				call :LogMsg Processor Architecture := %PROCESSOR_ARCHITECTURE%
			)
		) ELSE (

			REM PROCESSOR_ARCHITECTURE not defined

			call :LogMsg PROCESSOR_ARCHITECTURE not defined!
			set ERRORLEVEL=1
		)
	) ELSE (
		call :LogMsg OS Version := %OSVer%
	)	
) ELSE (

	REM OSVer not defined

	call :LogMsg OSVer not defined!
	set ERRORLEVEL=1
)

:Finish

call :LogMsg Finished UI_FixAA64.cmd

goto :End

REM ======================================================================
REM Logging Function - log to screen and file
REM ======================================================================
:LogMsg

setlocal
set STRMSG=%TIME% - %*
echo %STRMSG%
echo %STRMSG% >> %UIFIXAA64_LOGFILE%
endlocal
goto :EOF

REM ======================================================================
REM Usage
REM ======================================================================
:Usage
echo.
echo Usage:
echo.
echo UI_FixAA64.cmd
echo.
echo Example: UI_FixAA64.cmd
echo.
echo Required Parameters:  none.
echo.
echo Note: Quotes are required where provided in the example
echo.
goto :End

:End
popd
