@call :SETTOOLPATH
@%_TOOLPATH% %*
@set _TOOLPATH=& exit /b %ERRORLEVEL%

:SETTOOLPATH
@set _TOOLPATH="D:\CxCache\TipOfTheDay.OneBranch.1.0.29\ValidateSTConfig.cmd"
@exit /b
