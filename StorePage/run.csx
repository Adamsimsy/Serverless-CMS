using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, out string outputBlob, TraceWriter log)
{
    var helloRequest = await req.Content.ReadAsAsync<HelloRequest>();
    
    var personToGreet = helloRequest?.Name ?? "world";    
    var responseMessage = $"Hello {personToGreet}!";

    outputBlob = responseMessage;
}

public class HelloRequest
{
    public string Name { get; set; }
}