using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace web
{
    public class HypernovaJob {
        public string Name { get; set; }
        public object Data { get; set; }
    }
    public class HypernovaBatchRequest {
        public List<HypernovaJob> jobs { get; set; }

        public HypernovaBatchRequest()
        {
            jobs = new List<HypernovaJob>();
        }
    }

    public class HypernovaBatchResponse {
        public string Error { get; set; }
        public bool Success {get;set;}
        public IDictionary<string, HypernovaBatchJobResponse> results {get;set;}
    }

    public class HypernovaBatchJobResponse {
        public float Duration { get; set; }
        public string Html {get;set;}
        public int StatusCode {get;set;}
        public bool Success {get;set;}
    }


    public class HypernovaClient
    {
        private readonly HttpClient client;
        private readonly JsonSerializerSettings serializerSettings;
        public HypernovaClient()
        {
            client = new HttpClient();
            serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public async Task<HypernovaBatchResponse> RenderBatch(HypernovaBatchRequest batch) {
            var batchRequest = JsonConvert.SerializeObject(batch.jobs, serializerSettings);
            var response = await client.PostAsync("http://hypernova:3000/batch", new StringContent(batchRequest, Encoding.UTF8, "application/json"));
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<HypernovaBatchResponse>(content);
        }
    }
}
