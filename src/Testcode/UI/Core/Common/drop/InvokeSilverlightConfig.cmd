@echo OFF

setlocal

set KEY_NAME="HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft Operations Manager\3.0\Setup"
set VALUE_NAME=InstallDirectory

FOR /f "usebackq skip=2 tokens=1-2*" %%G IN (`REG QUERY %KEY_NAME% /v %VALUE_NAME% 2^>nul`) DO (
    set Valuexys=%%I..\WebConsole\WebHost\ClientBin\silverlightclientconfiguration.exe
)

if defined Valuexys (
    @echo Value xyz= "%Valuexys%"
    
    IF EXIST %Valuexys% (
        start "" "%Valuexys%"
		timeout /t 10
		taskkill /im silverlightclientconfiguration.exe
    )
) 

endlocal