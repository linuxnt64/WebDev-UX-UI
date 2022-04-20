using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunction
{
    public static class AnomalyDetection
    {
        [FunctionName("AnomalyDetection")]
        public static void Run([CosmosDBTrigger(
            databaseName: "analyticsdb",
            collectionName: "anomalydetection",
            ConnectionStringSetting = "CosmosDB",
            LeaseCollectionName = "leases", 
            CreateLeaseCollectionIfNotExists = true )]IReadOnlyList<Document> input,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Document Id " + input[0].Id);
                log.LogInformation("DeviceId " + input[0].GetPropertyValue<string>("deviceId"));
                log.LogInformation("Temperature " + input[0].GetPropertyValue<float>("temperature"));
                log.LogInformation("Humidity " + input[0].GetPropertyValue<int>("humidity"));
                log.LogInformation("Anomaly Detected? " + input[0].GetPropertyValue<int>("anomalyDetected"));
                Thread.Sleep(1000);
            }
        }
    }
}
