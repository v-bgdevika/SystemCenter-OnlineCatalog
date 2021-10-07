REM ======================================================================
REM Adding Windows Authentication Negotitate Provider
REM ======================================================================
%WINDIR%\system32\inetsrv\appcmd.exe unlock config -section:system.webServer/security/authentication/windowsAuthentication
%WINDIR%\system32\inetsrv\appcmd.exe set config "Default Web Site/MonitoringPortal" -section:system.webServer/security/authentication/windowsAuthentication /+"providers.[value='Negotiate']"