using System;
using System.Net;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

public static async Task<HttpResponseMessage> run(HttpRequestMessage req, CloudBlobContainer container, TraceWriter log)
{
    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

	string path = data?.path;
	string html = data?.html;

    var blob = container.GetBlockBlobReference(path);
    
    MemoryStream stream = new MemoryStream();
    StreamWriter writer = new StreamWriter(stream);
    writer.Write(html);
    writer.Flush();
    stream.Position = 0;
    
    blob.UploadFromStream(stream);
    
    blob.Properties.ContentType = "text/html";
    blob.SetProperties();
	
	return req.CreateResponse(HttpStatusCode.OK, "OK");
}