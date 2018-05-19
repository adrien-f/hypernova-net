using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HypernovaNet.domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HypernovaNet
{
    public interface IHypernovaClient
    {
        Task<BatchResponse> RenderBatch(BatchRequest batchRequest);
    }
}