using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HypernovaNet.domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HypernovaNet
{
    public class HypernovaClient : IHypernovaClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _serializerSettings;

        public HypernovaClient(HypernovaConfig hypernovaConfig)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(hypernovaConfig.Endpoint)
            };
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public async Task<BatchResponse> RenderBatch(BatchRequest batchRequest)
        {
            var batchRequestJson = JsonConvert.SerializeObject(batchRequest.Jobs, _serializerSettings);
            var response = await _httpClient.PostAsync("/batch",
                new StringContent(batchRequestJson, Encoding.UTF8, "application/json"));
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BatchResponse>(content);
        }
    }
}