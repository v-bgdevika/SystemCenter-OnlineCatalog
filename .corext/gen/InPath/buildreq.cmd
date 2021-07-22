@call :SETTOOLPATH
@%_TOOLPATH% %*
@set _TOOLPATH=& exit /b %ERRORLEVEL%

:SETTOOLPATH
@set _TOOLPATH="D:\CxCache\BuildReq.1.0.158.1\BuildReq.cmd"
@exit /b
