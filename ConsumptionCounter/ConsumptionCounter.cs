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
using Microsoft.Azure.Functions.Worker;


namespace GitHub.Counter
{ 
    public static class ConsumptionCounter
    {
        [FunctionName("ConsumptionCounter")]
        [CosmosDBOutput("%DatabaseName%", "%CollectionName%")]
        public static object Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [CosmosDBInput("%DatabaseName%", "%CollectionName%", Id = "github_main", PartitionKey = "github_main")] CounterJson counter,
            ILogger log)
        {
            counter.Count++;
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

// dotnet add package Microsoft.Azure.WebJobs.Extensions.CosmosDB