@call :SETTOOLPATH
@%_TOOLPATH% %*
@set _TOOLPATH=& exit /b %ERRORLEVEL%

:SETTOOLPATH
@set _TOOLPATH="D:\CxCache\VsMsBuild.Corext.3.2.15\v4.0\vsmsbuild.exe"
@exit /b
