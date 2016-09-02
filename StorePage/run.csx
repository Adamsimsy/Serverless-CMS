using System.Net;

public static void Run(HttpRequestMessage req, out string outputBlob, TraceWriter log)
{
    //var helloRequest = req.Content.ReadAsAsync<HelloRequest>();
    
    //var personToGreet = helloRequest?.Name ?? "world";    
    //var responseMessage = $"Hello {personToGreet}!";

    outputBlob = @"<!DOCTYPE html><html lang=""en""><head><meta charset=""utf-8""><title>Hello World</title></head><body><h1>Hello World</h1><p>Adam was here.</p></body></html>";
}

public class HelloRequest
{
    public string Name { get; set; }
}