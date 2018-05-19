using System.Collections.Generic;

namespace HypernovaNet.domain
{
    public class BatchRequest
    {
        public List<JobRequest> Jobs { get; set; }

        public BatchRequest()
        {
            Jobs = new List<JobRequest>();
        }
    }
}