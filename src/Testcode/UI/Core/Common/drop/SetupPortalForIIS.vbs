'// <copyright file="SetupPortalForIIS.vbs" company="Microsoft">
'//     Copyright (c) Microsoft Corporation.  All rights reserved.
'// </copyright>
'// <summary>
'// Sets up the IIS settings for the installation of the MonitoringPortal
'// Should be called with [TARGETDIR] [TARGETVDIR] [BUTTON4] settings or c:\inetpub\wwwroot\WebConsole WebConsole 1
'// </summary>
'//-----------------------------------------------------------------------
' This script sets up the IIS settings for our installation of the Monitoring Portal
Dim wshell, fso, MyFile, vrootDir, vrootName, authMethod, webConfigSourceFile, objVirtualDir
Set wshell = CreateObject("WScript.Shell")
' Create the File System Object
Set fso = CreateObject("Scripting.FileSystemObject")

'// **************************************************
'// Get command line arguments
'// **************************************************
vrootDir = WScript.Arguments.Item(0)
vrootName = WScript.Arguments.Item(1)
authMethod = WScript.Arguments.Item(2)
WScript.Echo("Input Arguments Gathered: " & vrootDir & " : " & vrootName & " : " & authMethod)

'// **************************************************
'// Create and Setup the IIS VRoot and Application
'// **************************************************

'// Create physical folder under wwwroot
if fso.FolderExists(vrootDir) = False then
    WScript.Echo("Creating directory " & vrootDir)
    fso.CreateFolder(vrootDir)
end if

'// Get IIsWebVirtualDir object (ADSI container)
Set objIIS = GetObject("IIS://localhost/W3SVC/1/root")
Set objVirtualDir = objIIS.Create("IISWebVirtualDir", vrootName)

'// Set Properties
objVirtualDir.Put "Path", (vrootDir)
objVirtualDir.AppCreate True
objVirtualDir.AccessScript = "True"
objVirtualDir.AccessRead = "True"
objVirtualDir.AccessWrite = "False"
objVirtualDir.AccessExecute = "False"

'// Create an Application on the vroot 
objVirtualDir.AppCreate2(True)
objVirtualDir.AppFriendlyName = vrootName


'// **************************************************
'// Set correct web.config
'//
'// CURRENTLY NOT BEING USED... we copy over the 
'// correct web.config file in the calling batch file
'// **************************************************
select case authMethod
    ' IIS Mixed Auth
    case 1
        objVirtualDir.AuthFlags = 4
        webConfigSourceFile = "web.config.iis_mixed"
    ' IIS Network Auth
    case 2
        objVirtualDir.AuthFlags = 1
        webConfigSourceFile = "web.config.iis_network"
    ' IIS Mixed Auth - SSL        
    case 3
        objVirtualDir.AuthFlags = 4
        webConfigSourceFile = "web.config.iis_mixed_ssl"
    ' IIS Network Auth - SSL
    case 4
        objVirtualDir.AuthFlags = 1
        webConfigSourceFile = "web.config.iis_network_ssl"
end select

'// **************************************************
'// save our information to the IIS metabase
'// **************************************************
objVirtualDir.SetInfo
