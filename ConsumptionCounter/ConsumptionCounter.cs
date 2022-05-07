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
    public static class ConsumptionCounter
    {
        [FunctionName("ConsumptionCounter")]
        public static object Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "%DatabaseName%",
                collectionName: "%CollectionName%",
                ConnectionStringSetting = "%CosmosDBConnectionString%",
                Id = "github_main",
                PartitionKey = "github_main")] CounterJson counter,
            ILogger log)
        {
            return counter;
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
