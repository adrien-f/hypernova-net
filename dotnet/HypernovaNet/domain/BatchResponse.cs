using System.Collections.Generic;

namespace HypernovaNet.domain
{
    public class BatchResponse
    {
        public string Error { get; set; }
        public bool Success {get;set;}
        public IDictionary<string, JobResponse> Results { get; set; }
    }
}