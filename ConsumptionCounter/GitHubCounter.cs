using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GitHub.Counter
{
    public static class GitHubCounter
    {
        [FunctionName("GitHubCounter")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] 
            HttpRequest req,
            [CosmosDBInput(
                datbaseName: Environment.GetEnvironmentVariable("DatabaseName"),
                collectionName: Environment.GetEnvironmentVariable("CollectionName"),
                ConnectionStringSetting = Environment.GetEnvironmentVariable("CosmosDBConnectionString"),
                Id = "github_main",
                PartitionKey = "github_main")] CounterJson counter,
            ILogger log)
        {

        }
    }

    public class CounterJson 
    {
        [JsonPropertyName("id")]
        public string Id {get;set;}

        [JsonPropertyName("count")]
        public int Count {get;set;}
    }
}
