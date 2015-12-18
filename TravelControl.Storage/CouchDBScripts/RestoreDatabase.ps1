#
#	global shizzle
#
#	Note: is almost identical to BackupDatabase.ps1 => good idea to merge!
#
$url="http://127.0.0.1:5984"
$databasename="travelcontrol"
$database="$url/$databasename"
$databasebackup="$url/$($databasename)_backup"

Write-Host "Will restore database ($databasebackup) to ($database)" 

#
#	Delete the target database if it exists
#
$dbExists = $true
Try
{
	curl $database -Method Get | Out-Null
}
Catch
{
	$dbExists = $false
}

if ($dbExists)
{ 
	Write-Host "Database ($database) exists, it will be deleted first" 
	curl $database -Method Delete | Out-Null
}

#
#	Create the target database again as a new database
#
Write-Host "Database ($database) will be created"
curl $database -Method Put | Out-Null

#
#	Finally make restore the backup
#
curl $url/_replicate -Body "{""source"":""$($databasebackup)"", ""target"":""$($databasename)""}" -ContentType "application/json" -Method POST -Verbose