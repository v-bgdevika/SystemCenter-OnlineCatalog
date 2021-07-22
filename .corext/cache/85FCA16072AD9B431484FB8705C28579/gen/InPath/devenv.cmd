@call :SETTOOLPATH
@%_TOOLPATH% %*
@set _TOOLPATH=& exit /b %ERRORLEVEL%

:SETTOOLPATH
@set _TOOLPATH="D:\CxCache\Corext.Extras.1.0.6\scripts\devenv.cmd"
@exit /b
