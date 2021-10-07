'// <summary>
'// Creates a desktop shortcut for the MonitoringPortal.
'// Usage: CreateMonitoringPortalShortcut.vbs <pathToMonitorPortalExe>
'// </summary>
'//-----------------------------------------------------------------------
set WshShell = CreateObject("Wscript.shell")
strDesktop = WshShell.SpecialFolders("Desktop")
set oMyShortcut = WshShell.CreateShortcut(strDesktop + "\MonitoringPortal.lnk")
oMyShortcut.TargetPath = WScript.Arguments.Item(0)
oMyShortCut.Save