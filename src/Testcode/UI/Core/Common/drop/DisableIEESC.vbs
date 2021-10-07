'--------------------------------------------------------------------
' <company>Microsoft Corporation</company>
'
' <copyright>Copyright (c) Microsoft Corporation 2005</copyright>
'
'<summary>
'       Script to disable Internet Explorer Enhanced Security Configuration
'</summary>
'
'<history>
'  <record date = "2/5/2009"  who="v-lileo">
'       First version.
'   </record> 
'</History>
'--------------------------------------------------------------------
On Error Resume Next
Dim objWMIService
Dim Version
Dim WSHShell
Set WSHShell =CreateObject("WScript.Shell")

Const HKEY_LOCAL_MACHINE = &H80000002
strComputer = "."
Set objReg=GetObject("winmgmts:!\\" & strComputer & "\root\default:StdRegProv")

strKeyPath = "SOFTWARE\Microsoft\Active Setup\Installed Components\" _
    & "{A509B1A7-37EF-4b3f-8CFC-4F3A74704073}"
strValueName = "IsInstalled"
objReg.GetDWORDValue HKEY_LOCAL_MACHINE,strKeyPath,strValueName,intAdmin
 
strKeyPath = "SOFTWARE\Microsoft\Active Setup\Installed Components\" _
    & "{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}"
strValueName = "IsInstalled"
objReg.GetDWORDValue HKEY_LOCAL_MACHINE,strKeyPath,strValueName,intUsers

strConfiguration = intAdmin & intUsers
If strConfiguration <> "00" Then

	For Each objWMIService in GetObject("winmgmts:{impersonationLevel=impersonate}").InstancesOf ("Win32_OperatingSystem")
	Version = left(objWMIService.Version,1)
	Next

	If Version=6 then
		'Set registry values to off IEESC
		WSHShell.RegWrite "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A7-37EF-4b3f-8CFC-4F3A74704073}\IsInstalled",0,"REG_DWORD"
		WSHshell.RegWrite "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}\IsInstalled",0,"REG_DWORD"

		'Run iesetup.dll
		WSHShell.exec "Rundll32 iesetup.dll,IEHardenLMSettings"
		WSHShell.exec "Rundll32 iesetup.dll,IEHardenUser"
		WSHShell.exec "Rundll32 iesetup.dll,IEHardenAdmin"

		'Delete User registry keys
		WSHShell.RegDelete "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A7-37EF-4b3f-8CFC-4F3A74704073}\"
		WSHShell.RegDelete "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A8-37EF-4b3f-8CFC-4F3A74704073}\"

		'Disable the warning page on first run
		WSHShell.RegWrite "HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\First Home Page",""

	Else
		WSHShell.exec "sysocmgr.exe /i:..\common\IEHSysOC.inf /u:..\common\IEHUnInstall.ini"
	End if
End if
