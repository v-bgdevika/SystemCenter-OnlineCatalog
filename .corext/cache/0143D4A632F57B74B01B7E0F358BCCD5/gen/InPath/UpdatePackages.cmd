@call :SETTOOLPATH
@%_TOOLPATH% %*
@set _TOOLPATH=& exit /b %ERRORLEVEL%

:SETTOOLPATH
@set _TOOLPATH="D:\CxCache\UpdatePackages.1.1.1.2\lib\net462\UpdatePackages.exe"
@exit /b
