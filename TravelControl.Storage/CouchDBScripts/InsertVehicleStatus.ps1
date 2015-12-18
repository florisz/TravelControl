#
#	Script to insert VehicleStatus views in the couchdb database for travelcontrol
#
$travelControlUrl="http://127.0.0.1:5984/travelcontrol"

$viewsBody = '{
   "language": "javascript",
   "views": {
       "ByRoute": {
           "map": "function(doc) {\n\tvar RouteId, Location;\n\tif (doc.DocType == 4) {\n\t\tRouteId = doc.RouteId;\n\t\tLocation = doc.Location;\n\t\temit(RouteId, Location);\n\t}\n}"
       },
       "DeleteAll": {
           "map": "function(doc) {\n\tif (doc.DocType == 4) {\n\t\temit(null, doc._rev);\n\t}\n}"
       }
   }
}'

#
#	beware: this function only works if the view does not exist already (so preferably an empty database)
#		    (reason is the http PUT) 
#
Function PostViews2CouchDB($url, $viewsBody)
{
	$return = curl -Uri $url -Method Put -ContentType application/javascript -Body $viewsBody
    if ($return.StatusCode -ne "201")
    {
		$statusCode = $return.StatusCode
        Write-Error("Views for vehicle status could not be created, Received $statusCode from post for body $viewsBody")
    }
    else
    {
        Write-Host("Views for vehicle status successful created")
    }

}
#
#	Script starts here
#
Write-Host("Posting VehicleStatus views...")
$viewsUrl = $travelControlUrl + "/_design/VehicleStatus"
PostViews2CouchDB $viewsUrl $viewsBody