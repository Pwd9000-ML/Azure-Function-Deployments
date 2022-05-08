using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker;
using System.Text.Json.Serialization;

namespace My.Function
{
    public static class ConsCount01
    {
        [FunctionName("ConsCount01")]
        // [CosmosDBOutput("%DatabaseName%", "%CollectionName%", ConnectionStringSetting = "CosmosConnection")]
        public static object Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "VisitorCounter",
                collectionName: "GitHubCounter",
                ConnectionStringSetting = "CosmosConnection",
                Id = "github_main",
                PartitionKey = "github_main")] CounterJson counter01,
            FunctionContext context)
        {
            //     counter.Count++;
            return counter01;
        }
    }

    public class CounterJson
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
// dotnet add package Microsoft.Azure.WebJobs.Extensions.CosmosDB
// dotnet add package Microsoft.Azure.WebJobs.Extensions
// dotnet add package Microsoft.Azure.Functions.Worker.Extensions.CosmosDB
// dotnet add package Microsoft.Azure.Functions.Worker.Core
// dotnet add package Microsoft.Azure.Functions.Worker
