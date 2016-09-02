using System.Net;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

public static void Run(HttpRequestMessage req, out CloudBlockBlob outputBlob, TraceWriter log)
{
    //var helloRequest = req.Content.ReadAsAsync<HelloRequest>();
    
    //var personToGreet = helloRequest?.Name ?? "world";    
    //var responseMessage = $"Hello {personToGreet}!";

    htmlText = @"<!DOCTYPE html><html lang=""en""><head><meta charset=""utf-8""><title>Hello World</title></head><body><h1>Hello World</h1><p>Adam was here.</p></body></html>";
	
	using (var stream = new MemoryStream(Encoding.Default.GetBytes(htmlText), false))
	{
		outputBlob.UploadFromStream(stream, null, options);
	}
	
	outputBlob.Properties.ContentType = "application/xhtml+xml";
}

public class HelloRequest
{
    public string Name { get; set; }
}