using System.Net;

public static void Run(HttpRequestMessage req, out string outputBlob, TraceWriter log)
{
    var helloRequest = req.Content.ReadAsAsync<HelloRequest>();
    
    var personToGreet = helloRequest?.Name ?? "world";    
    var responseMessage = $"Hello {personToGreet}!";

    outputBlob = responseMessage;
}

public class HelloRequest
{
    public string Name { get; set; }
}