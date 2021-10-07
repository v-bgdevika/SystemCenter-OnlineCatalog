@ECHO OFF

pushd .
REM ======================================================================
REM Copyright Microsoft Corp. 2009
REM
REM Module : GenerateMomTestUICoreChm.cmd
REM
REM Summary: Generate Mom.Test.UI.Core.Common.chm or
REM          Mom.Test.UI.Core.Console.chm
REM
REM History: (7/14/2009) Walter Li - Initial coding
REM ======================================================================
SET DXROOT=%CD%

REM ======================================================================
REM Ensure proper parameters entered
REM ======================================================================
if "%1" equ "/?" (goto :Usage)
if "%1" equ "?" (goto :Usage)
if "%1" equ "-?" (goto :Usage)

if NOT "%1" equ "Mom.Test.UI.Core.Console" (
    if NOT "%1" equ "Mom.Test.UI.Core.Common" (
        set errnum=2
        ECHO Parameter value must be Mom.Test.UI.Core.Console or Mom.Test.UI.Core.Common
        goto :End
    )
)
goto :RunBuild

REM ======================================================================
REM Run build_Sandcastle.bat
REM ======================================================================
:RunBuild
cd %1
CALL build_Sandcastle.bat vs2005 %1
goto :End

REM ======================================================================
REM Usage
REM ======================================================================
:Usage
echo.
echo Usage:
echo.
echo GenerateMomTestUICoreChm.cmd ModuleName 
echo.
echo Example: GenerateMomTestUICoreChm.cmd Mom.Test.UI.Core.Common
echo.
echo. Specific steps to prepare environment:
echo 1)	Install .Net Framework 2.0 
echo 2)	Install HTML Help Workshop at: http://go.microsoft.com/fwlink/?linkid=14188
echo 3)	Copy "SandCasle" files from \\smfiles\Scratch\ruhim\sandcastle-26202 to local computer. Remember the root folder path
echo.
echo Specific steps for generating Mom.Test.UI.Core.Common.chm:
echo 1)	Generate xml document named "Mom.Test.UI.Core.Common.xml" with visual studio. The file name must be "Mom.Test.UI.Core.Common.xml"
echo 2)	Copy  "Mom.Test.UI.Core.Common.xml" and all reference files to "Mom.Test.UI.Core.Common" folder
echo 3)	Start cmd and change current directory to the root folder path
echo 4)	Run "GenerateMomTestUICoreChm.cmd Mom.Test.UI.Core.Common"
echo 5)	Verify "Mom.Test.UI.Core.Common.chm" is generated under "Mom.Test.UI.Core.Common\chm" folder
echo.
echo Specific steps for generating Mom.Test.UI.Core.Console.chm:
echo 1)	Generate xml document named "Mom.Test.UI.Core.Console.xml" with visual studio. The file name must be "Mom.Test.UI.Core.Console.xml"
echo 2)	Copy "Mom.Test.UI.Core.Console.xml" and all reference files to "Mom.Test.UI.Core.Console" folder
echo 3)	Start cmd and change current directory to the root folder path
echo 4)	Run "GenerateMomTestUICoreChm.cmd Mom.Test.UI.Core.Console"
echo 5)	Verify "Mom.Test.UI.Core.Console.chm" is generated under "Mom.Test.UI.Core.Console\chm" folder
echo.
set ERRNUM=1


REM ======================================================================
REM End
REM ======================================================================
:End
popd
