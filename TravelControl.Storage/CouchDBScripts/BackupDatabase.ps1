#
#	global shizzle
#
#	Note: is almost identical to RestoreDatabase.ps1 => good idea to merge!
#
$url="http://127.0.0.1:5984"
$databasename="travelcontrol"
$database="$url/$databasename"
$databasebackup="$url/$($databasename)_backup"

Write-Host "Will backup database ($database) to ($databasebackup)" 

#
#	Delete the backup database if it exists
#
$dbExists = $true
Try
{
	curl $databasebackup -Method Get | Out-Null
}
Catch
{
	$dbExists = $false
}

if ($dbExists)
{ 
	Write-Host "Backup database ($databasebackup) exists, it will be deleted first" 
	curl $databasebackup -Method Delete | Out-Null
}

#
#	Create the backup database
#
Write-Host "Backup database ($databasebackup) will be created"
curl $databasebackup -Method Put | Out-Null

#
#	Finally make the backup
#
curl $url/_replicate -Body "{""source"":""$($databasename)"",""target"":""$($databasebackup)""}" -ContentType "application/json" -Method POST -Verbose