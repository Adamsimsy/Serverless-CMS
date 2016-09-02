using System.Net;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

public static void Run(CloudBlockBlob inBlob, out CloudBlockBlob outputBlob, TraceWriter log)
{
	outputBlob = inBlob;
	
	outputBlob.Properties.ContentType = "application/xhtml+xml";
}