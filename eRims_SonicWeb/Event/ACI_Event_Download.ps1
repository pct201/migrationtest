
$ImageProtocol = "http://"
$ImageFileDomainName = "device.amsvideo.com"
$UrlPortNo = "4531"
$ReqUserName = "sonicauto"
$ReqPassword = "sonic2014"
$CSVPath = "D:\eRIMS2 Applications\dev\sonic\Documents\Downloads"
$SqlConnection = New-Object System.Data.SqlClient.SqlConnection
$SqlConnection.ConnectionString = "Data Source=pci120;DataBase=erims_Sonic;User ID=sa;Password=tatva123;Connect Timeout=10000;"
$ImageURL = $ImageProtocol + $ImageFileDomainName + ":" + $UrlPortNo + "/GetThumbnail?user=$ReqUserName&password=$ReqPassword"
$ImagePath = "D:\eRIMS2 Applications\dev\sonic\Documents\EventImage"

$SFTPDestiFileName = "export.xls"

##Functions Start
function Write-Log 
{ 
    [CmdletBinding()] 
    Param 
    ( 
        [Parameter(Mandatory=$true, 
                   ValueFromPipelineByPropertyName=$true)] 
        [ValidateNotNullOrEmpty()] 
        [Alias("LogContent")] 
        [string]$Message, 
 
        [Parameter(Mandatory=$false)] 
        [Alias('LogPath')] 
        [string]$Path=$CSVPath + "\General Log\" + (Get-Date).Year + "\" + (Get-Date).Month +"\General_Info.log", 
         
        [Parameter(Mandatory=$false)] 
        [ValidateSet("Error","Warn","Info")] 
        [string]$Level="Info", 
         
        [Parameter(Mandatory=$false)] 
        [switch]$NoClobber 
    ) 
 
    Begin 
    { 
        # Set VerbosePreference to Continue so that verbose messages are displayed. 
        $VerbosePreference = 'Continue' 
    } 
    Process 
    { 
         
        # If the file already exists and NoClobber was specified, do not write to the log. 
        if ((Test-Path $Path) -AND $NoClobber) { 
            Write-Error "Log file $Path already exists, and you specified NoClobber. Either delete the file or specify a different name." 
            Return 
            } 
 
        # If attempting to write to a log file in a folder/path that doesn't exist create the file including the path. 
        elseif (!(Test-Path $Path)) { 
            Write-Verbose "Creating $Path." 
            $NewLogFile = New-Item $Path -Force -ItemType File 
            } 
 
        else { 
            # Nothing to see here yet. 
            } 
 
        # Format Date for our Log File 
        $FormattedDate = Get-Date -Format "yyyy-MM-dd HH:mm:ss" 
 
        # Write message to error, warning, or verbose pipeline and specify $LevelText 
        switch ($Level) { 
            'Error' { 
                Write-Error $Message 
                $LevelText = 'ERROR:' 
                } 
            'Warn' { 
                Write-Warning $Message 
                $LevelText = 'WARNING:' 
                } 
            'Info' { 
                Write-Verbose $Message 
                $LevelText = 'Info:-' 
                } 
            } 
         
        # Write log entry to $Path 
        "$FormattedDate $LevelText $Message`r`n" | Out-File -FilePath $Path -Append 
    } 
    End 
    { 
    } 
}

function Exec-Sproc{
	param($Conn, $Sproc, $Parameters=@{})

	$SqlCmd = New-Object System.Data.SqlClient.SqlCommand
	$SqlCmd.CommandType = [System.Data.CommandType]::StoredProcedure
	$SqlCmd.Connection = $Conn
	$SqlCmd.CommandText = $Sproc
    $SqlCmd.CommandTimeout = 100000
	foreach($p in $Parameters.Keys){
 		[Void] $SqlCmd.Parameters.AddWithValue("@$p",$Parameters[$p])
 	}
	$SqlAdapter = New-Object System.Data.SqlClient.SqlDataAdapter($SqlCmd)
	$DataSet = New-Object System.Data.DataSet
	[Void] $SqlAdapter.Fill($DataSet)
	$SqlConnection.Close()
	#return $DataSet.Tables[0]
    return $DataSet
}

if (!(Test-Path $ImagePath)) { 
    New-Item -ItemType Directory -Force -Path $ImagePath
}
##Function End

$startlog = "//////////////////////////////////Event Import Service Started On :" + (get-date).ToString() + "  ///////////////////////////"
Write-Log $startlog

try
{
    $fileEvent = "$CSVPath" +"\" +"$SFTPDestiFileName"

    $tempfile = "$CSVPath" +"\temp.txt"

    [int]$ISexist = 0
    [int]$timer = 0

    Do
    {
        if(Test-Path $tempfile)
        {
            $ISexist = $ISexist + 1
            ##Write-Log $ISexist
        }
        else
        {
            sleep -Seconds 5
            $timer = $timer + 5
            ##Write-Log $timer
        }
        
        
    }while ($ISexist -le 1 -and ($timer -le 1800))
    
    
    $webclient = New-Object System.Net.WebClient
    
    Write-Log "Inserting Event."
    try
    {
         $ds = Exec-Sproc -Conn $SqlConnection -Sproc "Import_Event_FTP" -Parameters @{FilePath=$fileEvent; IsMaster=1}

         if ($ds -ne $null -and ($ds.Tables.Count -gt 0) -and ($ds.Tables[0].Rows.Count -gt 0))
         {
            $Templog = "Event Insert Call : " + $ds.Tables[0].Rows[0][0]
            Write-Log $Templog
        
            if ($ds.Tables.Count -eq 2)
            {
                if($ds.Tables[1].Rows.Count -gt 0)
                {
                    Write-Log "Downloading Event Images is Started."
                    foreach ($Row in $ds.Tables[1])
                    { 
                        try
                        {
                            $dwnImgurl = $ImageURL + "&event=" +$Row[0]
                            $webclient.DownloadFile($dwnImgurl,$ImagePath+"\"+$Row[0]+".jpg")
                        }
                        catch
                        {
                            $Errlog = "Error Image URL :- " + $dwnImgurl
                            Write-Log $Errlog
                            $Errlog = $_.Exception.GetType().FullName +" "+ $_.Exception.Message
                            Write-Log $Errlog
                        }
                    }
                    Write-Log "Downloading Event Images is Completed."
                }
                else
                {
                    Write-Log "No Event Image for Download."
                }
            }
         
         }
         else
         {
            Write-Log "No Event Available for Insert."
         }
         Write-Log "Inserting Event Completed."


    }
    catch
    {
        Write-Log "Error while Inserting Events."
        $Errlog = $_.Exception.GetType().FullName +" "+ $_.Exception.Message
        Write-Log $Errlog
    }
          if(Test-Path $tempfile)
          {
                Remove-Item -Path $tempfile -Force
          }

}
catch
{
    Write-Log "Error while Running Import Event Service."
    $Errlog = $_.Exception.GetType().FullName +" "+ $_.Exception.Message
    Write-Log $Errlog
}
$startlog = "//////////////////////////////////Event Import Service Completed On :" + (get-date).ToString() + "  ///////////////////////////"
Write-Log $startlog
