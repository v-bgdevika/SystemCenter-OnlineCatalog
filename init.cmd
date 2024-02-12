@echo off

@echo.
echo Configuring path..
==========================================================

set PATH=%PATH%;C:\Program Files (x86)\MSBuild\14.0\Bin\;C:\Windows\Microsoft.NET\Framework\v4.0.30319\;%ProgramFiles%\Git\usr\bin
echo ##vso[task.prependpath]%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\

echo Done!
@echo on