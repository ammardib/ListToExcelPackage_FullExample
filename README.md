# ListToExcelPackage_FullExample
This is a full project .net core (C#) to show how to use ListToExcelPackage nuget package to export a list of objects to an Excel sheet

## APIs Included
### GET v1/Orders
This will export list of objects to stream and return Excel File by using ListToExcelPackage nuget package
Create the Excel file and save it as stream, Returns a Memory Stream
Simple Excel file without any styles added.

### GET v1/OrdersWithStyle
This will export list of objects to stream and return Excel File by using ListToExcelPackage nuget package, with adding some styles to excel, FontBold, BackgroundColor, ... etc

### GET v1/OrdersOCI
Create the Excel file from list of objects and save it to ObjectStorage (here Oracle Cloud Infrastructure), Returns ObjectName
for more information about OCI Object Storage visit: https://docs.cloud.oracle.com/en-us/iaas/Content/Object/Concepts/objectstorageoverview.htm
for creating free cloud account visit: https://www.oracle.com/sa/cloud/free/
Saving bucket name and namespace of OCI object storage as environment variable as following example:
```json
"environmentVariables": {
        "BUCKET_NAME": "bucket-20201015-0005",
        "NAMESPACE_NAME": "axy7edlo4u4z",
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
```
        
### GET v1/DownloadFile/{objectName}
Helper action to download the file saved to the ObjectStorage (here OCI), can be used from anywhere.
