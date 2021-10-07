Import-Module OperationsManager
Import-Module Microsoft.WSMan.Management
Import-Module Microsoft.PowerShell.Utility
Import-Module Microsoft.PowerShell.Security
Import-Module Microsoft.PowerShell.Management
Import-Module ISE

function RemoveMPsHelper 
{param($mpList)

  foreach ($mp in $mpList)
  {  
	$recursiveListOfManagementPacksToRemove = Get-SCOMManagementPack -Name $mp.Name -Recurse
    if ($recursiveListOfManagementPacksToRemove.Count -gt 1)
	{
		Echo "`r`n"
		Echo "Following dependent management packs has to be deleted before deleting $($mp.Name)..."
		$recursiveListOfManagementPacksToRemove | format-table name
		RemoveMPsHelper $recursiveListOfManagementPacksToRemove
	}
	else
	{
		$mpPresent = Get-SCOMManagementPack -Name $mp.Name
        $Error.Clear()
       
        if ($mpPresent -eq $null)
        {
            # If the MP wasn’t found, we skip the uninstallation of it.
            Echo "    $mp has already been uninstalled"
        }
		else
		{
			Echo "    * Uninstalling $mp "
			Remove-SCOMManagementPack -managementpack $mp
		}
	}
  }

}


function RemoveMPs
{param($mp)

  $listOfManagementPacksToRemove = Get-SCOMManagementPack -Name $mp -Recurse
  $listOfManagementPacksToRemove | format-table name
  $title = "Uninstall Management Packs"
  $message = "Do you want to uninstall the above $($listOfManagementPacksToRemove.Count) management packs and its dependent management packs"

  $yes = New-Object System.Management.Automation.Host.ChoiceDescription "&Yes", "Uninstall selected Management Packs."
  $no = New-Object System.Management.Automation.Host.ChoiceDescription "&No", "Do not remove Management Packs."
  $options = [System.Management.Automation.Host.ChoiceDescription[]]($yes, $no)

  $result = 0 

  switch ($result)
  {
        0 {RemoveMPsHelper $listOfManagementPacksToRemove}
        1 {"Exiting without removing any management packs"}
  }

}


function RemoveMP
{param($mp)
  
  # Needed for SCOM SDK
  $ipProperties = [System.Net.NetworkInformation.IPGlobalProperties]::GetIPGlobalProperties()
  $rootMS = "{0}.{1}" -f $ipProperties.HostName, $ipProperties.DomainName
  
  $firstArg = $mp
  add-pssnapin "Microsoft.EnterpriseManagement.OperationsManager.Client";
  $cwd = get-location
  
  set-location "OperationsManagerMonitoring::";

 # $mgConnection = new-managementGroupConnection -ConnectionString:$rootMS;
  $mgConnection = Get-SCOMManagementGroupConnection -ComputerName:$rootMS;

  RemoveMPs $firstArg

  set-location $cwd
  remove-pssnapin "Microsoft.EnterpriseManagement.OperationsManager.Client"; 

}


$data = Get-Content C:\bvt\ui\mp\SystemNames.txt

foreach($mp in $data)
{
  try
  {
    RemoveMP -mp $mp
    
  }
  catch
  {     
    log($_.Exception.Message)
  }
}
