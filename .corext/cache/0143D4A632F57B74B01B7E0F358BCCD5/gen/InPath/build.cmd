@call :SETTOOLPATH
@%_TOOLPATH% %*
@set _TOOLPATH=& exit /b %ERRORLEVEL%

:SETTOOLPATH
@set _TOOLPATH="D:\CxCache\MsBuildShim.OneBranch.2.1.12\build.cmd"
@exit /b
