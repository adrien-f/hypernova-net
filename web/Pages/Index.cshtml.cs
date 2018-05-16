using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HypernovaClient hypernovaClient;
        public string HelloWorld {get;set;}

        public IndexModel()
        {
            hypernovaClient = new HypernovaClient();
        }

        public async Task OnGetAsync()
        {
            var hello = await hypernovaClient.RenderBatch(new HypernovaBatchRequest{jobs = new List<HypernovaJob>{new HypernovaJob{Name = "HelloWorld"}}});
            HelloWorld = hello.results["0"].Html;
            Console.WriteLine(HelloWorld);
        }
    }
}
