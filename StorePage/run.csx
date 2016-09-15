using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

public static void Run(string input, CloudBlobContainer container, TraceWriter log)
{
    log.Info(input);
    
    var htmlText = @"<!DOCTYPE html><html lang=""en""><head><meta charset=""utf-8""><title>Hello World</title></head><body><h1>Hello World</h1><p>Adam was here.</p></body></html>";
    
    var blob = container.GetBlockBlobReference("pages/test6.html");
    
    MemoryStream stream = new MemoryStream();
    StreamWriter writer = new StreamWriter(stream);
    writer.Write(htmlText);
    writer.Flush();
    stream.Position = 0;
    
    blob.UploadFromStream(stream);
    
    blob.Properties.ContentType = "text/html";
    blob.SetProperties();
}