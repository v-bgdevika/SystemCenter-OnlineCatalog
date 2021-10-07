$MPFolderPath="C:\BVT\UI\MP"

Write-Host "Deleting Image and log files..."
Remove-Item *.jpg

#Check OMSDK is running or not. Start if not running.
Write-Host "Checking OMSDK services..."
$OMSDKService = get-Service OMSDK
if($OMSDKService.Status -ne "Running")
{
    Write-Host "Starting OMSDK Services..."
    start-service OMSDK
    Start-Sleep -s 60
}

#Close console if it is running.
Write-Host "Checking OMSDK services..."
$ConsoleProcess = Get-Process -Name "Microsoft.EnterpriseManagement.Monitoring.Console"
if($ConsoleProcess)
{
    Stop-Process -Id $ConsoleProcess.Id -Force
}

#Run Automation
cd $MPFolderPath
..\..\mcf.exe /m:Mom.Test.UI.Tests.MP.xml /s:6 /l:1 /v:1