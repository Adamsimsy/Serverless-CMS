using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

public static async Task<HttpResponseMessage> run(HttpRequestMessage req, CloudBlobContainer container, TraceWriter log)
{
	// parse query parameter
    string name = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
        .Value;

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Set name to query string or body data
    name = name ?? data?.name;
    
    var htmlText = @"<!DOCTYPE html><html lang=""en""><head><meta charset=""utf-8""><title>Hello World</title></head><body><h1>Hello World</h1><p>" + name + " was here.</p></body></html>";
    
    var blob = container.GetBlockBlobReference("pages/test6.html");
    
    MemoryStream stream = new MemoryStream();
    StreamWriter writer = new StreamWriter(stream);
    writer.Write(htmlText);
    writer.Flush();
    stream.Position = 0;
    
    blob.UploadFromStream(stream);
    
    blob.Properties.ContentType = "text/html";
    blob.SetProperties();
	
	return "true";
}