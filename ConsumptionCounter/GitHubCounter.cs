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
                        [CosmosDB(
                            databaseName: "ToDoItems",
                            collectionName: "Items",
                            ConnectionStringSetting = "CosmosDBConnection",
                            Id = "{Query.id}",
                            PartitionKey = "{Query.partitionKey}")] ToDoItem toDoItem,
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
