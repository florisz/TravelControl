#
#	Script to insert Routes in the couchdb database for travelcontrol
#	Routes data is contained as a JSON array within this script
#
$travelControlUrl="http://127.0.0.1:5984/travelcontrol"

$routes=@(
'{
   "DocType": 3, "Finished": false, "RouteId": "999900", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"00:01", "PlannedDepartureTime":"00:02" },
    { "FromLocation":"rta", "PlannedArrivalTime":"00:03", "PlannedDepartureTime":"00:04" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"00:05", "PlannedDepartureTime":"00:06" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"00:07", "PlannedDepartureTime":"00:08" },
    { "FromLocation":"amf", "PlannedArrivalTime":"00:09", "PlannedDepartureTime":"00:10" },
    { "FromLocation":"apd", "PlannedArrivalTime":"00:11", "PlannedDepartureTime":"00:12" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"00:13", "PlannedDepartureTime":"00:14" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "999901", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"00:15", "PlannedDepartureTime":"00:16" },
    { "FromLocation":"rta", "PlannedArrivalTime":"00:17", "PlannedDepartureTime":"00:18" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"00:19", "PlannedDepartureTime":"00:20" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"00:21", "PlannedDepartureTime":"00:22" },
    { "FromLocation":"amf", "PlannedArrivalTime":"00:23", "PlannedDepartureTime":"00:24" },
    { "FromLocation":"apd", "PlannedArrivalTime":"00:25", "PlannedDepartureTime":"00:26" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"00:27", "PlannedDepartureTime":"00:28" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "999902", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"00:31", "PlannedDepartureTime":"00:32" },
    { "FromLocation":"rta", "PlannedArrivalTime":"00:33", "PlannedDepartureTime":"00:34" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"00:35", "PlannedDepartureTime":"00:36" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"00:37", "PlannedDepartureTime":"00:38" },
    { "FromLocation":"amf", "PlannedArrivalTime":"00:39", "PlannedDepartureTime":"00:40" },
    { "FromLocation":"apd", "PlannedArrivalTime":"00:41", "PlannedDepartureTime":"00:42" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"00:43", "PlannedDepartureTime":"00:44" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "999903", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"00:45", "PlannedDepartureTime":"00:46" },
    { "FromLocation":"rta", "PlannedArrivalTime":"00:47", "PlannedDepartureTime":"00:48" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"00:49", "PlannedDepartureTime":"00:50" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"00:51", "PlannedDepartureTime":"00:52" },
    { "FromLocation":"amf", "PlannedArrivalTime":"00:53", "PlannedDepartureTime":"00:54" },
    { "FromLocation":"apd", "PlannedArrivalTime":"00:55", "PlannedDepartureTime":"00:56" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"00:57", "PlannedDepartureTime":"00:58" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "999904", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"01:01", "PlannedDepartureTime":"01:02" },
    { "FromLocation":"rta", "PlannedArrivalTime":"01:03", "PlannedDepartureTime":"01:04" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"01:05", "PlannedDepartureTime":"01:06" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"01:07", "PlannedDepartureTime":"01:08" },
    { "FromLocation":"amf", "PlannedArrivalTime":"01:09", "PlannedDepartureTime":"01:10" },
    { "FromLocation":"apd", "PlannedArrivalTime":"01:11", "PlannedDepartureTime":"01:12" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"01:13", "PlannedDepartureTime":"01:14" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "999905", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"01:15", "PlannedDepartureTime":"01:16" },
    { "FromLocation":"rta", "PlannedArrivalTime":"01:17", "PlannedDepartureTime":"01:18" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"01:19", "PlannedDepartureTime":"01:20" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"01:21", "PlannedDepartureTime":"01:22" },
    { "FromLocation":"amf", "PlannedArrivalTime":"01:23", "PlannedDepartureTime":"01:24" },
    { "FromLocation":"apd", "PlannedArrivalTime":"01:25", "PlannedDepartureTime":"01:26" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"01:27", "PlannedDepartureTime":"01:28" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "999906", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"01:31", "PlannedDepartureTime":"01:32" },
    { "FromLocation":"rta", "PlannedArrivalTime":"01:33", "PlannedDepartureTime":"01:34" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"01:35", "PlannedDepartureTime":"01:36" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"01:37", "PlannedDepartureTime":"01:38" },
    { "FromLocation":"amf", "PlannedArrivalTime":"01:39", "PlannedDepartureTime":"01:40" },
    { "FromLocation":"apd", "PlannedArrivalTime":"01:41", "PlannedDepartureTime":"01:42" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"01:43", "PlannedDepartureTime":"01:44" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "999907", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"01:45", "PlannedDepartureTime":"01:46" },
    { "FromLocation":"rta", "PlannedArrivalTime":"01:47", "PlannedDepartureTime":"01:48" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"01:49", "PlannedDepartureTime":"01:50" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"01:51", "PlannedDepartureTime":"01:52" },
    { "FromLocation":"amf", "PlannedArrivalTime":"01:53", "PlannedDepartureTime":"01:54" },
    { "FromLocation":"apd", "PlannedArrivalTime":"01:55", "PlannedDepartureTime":"01:56" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"01:57", "PlannedDepartureTime":"01:58" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "999908", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"02:01", "PlannedDepartureTime":"02:02" },
    { "FromLocation":"rta", "PlannedArrivalTime":"02:03", "PlannedDepartureTime":"02:04" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"02:05", "PlannedDepartureTime":"02:06" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"02:07", "PlannedDepartureTime":"02:08" },
    { "FromLocation":"amf", "PlannedArrivalTime":"02:09", "PlannedDepartureTime":"02:10" },
    { "FromLocation":"apd", "PlannedArrivalTime":"02:11", "PlannedDepartureTime":"02:12" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"02:13", "PlannedDepartureTime":"02:14" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "9999909", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"02:15", "PlannedDepartureTime":"02:16" },
    { "FromLocation":"rta", "PlannedArrivalTime":"02:17", "PlannedDepartureTime":"02:18" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"02:19", "PlannedDepartureTime":"02:20" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"02:21", "PlannedDepartureTime":"02:22" },
    { "FromLocation":"amf", "PlannedArrivalTime":"02:23", "PlannedDepartureTime":"02:24" },
    { "FromLocation":"apd", "PlannedArrivalTime":"02:25", "PlannedDepartureTime":"02:26" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"02:27", "PlannedDepartureTime":"02:28" }
  ]
}'
'{
   "DocType": 3, "Finished": false, "RouteId": "999910", "Started": false, "Code": "999999", "Departures":[
    { "FromLocation":"rtd", "PlannedArrivalTime":"02:31", "PlannedDepartureTime":"02:32" },
    { "FromLocation":"rta", "PlannedArrivalTime":"02:33", "PlannedDepartureTime":"02:34" },
    { "FromLocation":"gd",  "PlannedArrivalTime":"02:35", "PlannedDepartureTime":"02:36" },
    { "FromLocation":"ut",  "PlannedArrivalTime":"02:37", "PlannedDepartureTime":"02:38" },
    { "FromLocation":"amf", "PlannedArrivalTime":"02:39", "PlannedDepartureTime":"02:40" },
    { "FromLocation":"apd", "PlannedArrivalTime":"02:41", "PlannedDepartureTime":"02:42" },
    { "FromLocation":"dv",  "PlannedArrivalTime":"02:43", "PlannedDepartureTime":"02:44" }
  ]
}'
)

Function PostRoutes2CouchDB($url, $connections)
{
	$routes | foreach {
		$body = $_
		PostRoute2CouchDB $url $body
	}
    Write-Host("Route documents successful created")
}

Function PostRoute2CouchDB($url, $body)
{
	$return = curl -Uri $url -Method Post -ContentType application/json -Body $body
    if ($return.StatusCode -ne "201")
    {
        Write-Error("Document with route could not be created, Received $($return.StatusCode) from post for body $body")
    }
}

#
#	Script starts here
#
Write-Host("Posting data...")
PostRoutes2CouchDB $travelControlUrl $routes

