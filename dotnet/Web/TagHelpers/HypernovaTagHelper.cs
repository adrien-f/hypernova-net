using System.Collections.Generic;
using System.Threading.Tasks;
using HypernovaNet;
using HypernovaNet.domain;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace web.TagHelpers
{
    public class HypernovaTagHelper : TagHelper
    {
        private readonly IHypernovaClient _hypernovaClient;
        public string Component { get; set; }
        public object Data { get; set; }
        
        public HypernovaTagHelper(IHypernovaClient hypernovaClient)
        {
            _hypernovaClient = hypernovaClient;
            Data = new object();
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            output.TagMode = TagMode.StartTagAndEndTag;
            var renderRequest = new BatchRequest
            {
                Jobs = new List<JobRequest>
                {
                    new JobRequest
                    {
                        Name = Component,
                        Data = Data
                    }
                }
            };
            var renderResponse = await _hypernovaClient.RenderBatch(renderRequest);
            if (renderResponse.Success)
            {
                output.Content.SetHtmlContent(renderResponse.Results["0"].Html);
            }
            await base.ProcessAsync(context, output);
        }
    }
}