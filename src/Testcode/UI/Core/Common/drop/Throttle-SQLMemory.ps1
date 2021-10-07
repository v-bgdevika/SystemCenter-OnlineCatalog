<#
 # Throttle sql server memory to workaround test bug #410501
#>

function Log([string] $message)
{
  $line = ("{0} - $message" -f [DateTime]::Now)
  Write-Host $line
  $line | out-file $logFile -Append
}

<#
 # Get all management server machine names
 #>
function Select-ManagemnetServerNames()
{
    $config=[xml](Get-Content $env:windir\config.xml)
    $msNames=@()
    $config.Config.Machines.Machine | 
    where { (Get-Service -ComputerName $_.Name -Name "OMSDK" -ErrorAction SilentlyContinue) -ne $null } |
    foreach {
        $msNames += $_.Name
    }
    Log "Returned management servers in function [Select-ManagemnetServerNames]:"
    Log ($msNames| Out-String)
    return $msNames
}

<#
 # Invok sql command
#>

function Invok-SqlCommand()
{
    param($connStr,$cmdTxt)
    Log "connectionString=$connStr"
    Log "comandText=$cmdTxt"
    $conn=new-object System.Data.SqlClient.SQLConnection
    $conn.ConnectionString=$connStr

    $conn.Open()
    Log "Connected to database..."
    $cmd=new-object system.Data.SqlClient.SqlCommand($cmdTxt,$conn)
    try
    {
        $cmd.ExecuteNonQuery()
    }
    catch [System.Data.SqlClient.SqlException]
    {
        Log "Invok-SqlCommand failed. Exception: $($_.Exception.Message)"
    }

    $conn.Close()
    Log "Connection closed"
}

$logFile = "{0}\Throttle-SQLMemory_log.txt" -f (Get-Item $MyInvocation.InvocationName ).Directory.FullName
$managemnetServerNames = Select-ManagemnetServerNames
$momDBRegPath='HKLM:\SOFTWARE\Microsoft\System Center\2010\Common\Database'
$sqlThrottleMomory = ((Get-WmiObject -Class Win32_ComputerSystem).TotalPhysicalMemory /1mb)*(1/5)
if(Test-Path $momDBRegPath)
{
    Log "Current machine is management server"
    $databaseServerName=(Get-ItemProperty  $momDBRegPath).DatabaseServerName 
    $dbServer,$instance=$databaseServerName.split("\");
    $sqlInstSvc='MSSQL${0}' -f $instance
    $dbServer,$instance
    $connectionString = "Server={0}\{1};Database=master;Integrated Security=True;Connect Timeout=300" -f $dbServer,$instance
    $sqlComamnd="EXEC sp_configure 'show advanced options', 1 RECONFIGURE WITH OVERRIDE
                 EXEC sp_configure 'max server memory (MB)', {0} RECONFIGURE WITH OVERRIDE" -f $sqlThrottleMomory
    Invok-SqlCommand -connStr $connectionString -cmdTxt $sqlComamnd
}