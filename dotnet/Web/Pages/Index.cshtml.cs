using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web.Pages
{
    public class HelloWorldModel
    {
        public string From { get; set; }
    }
    
    public class IndexModel : PageModel
    {
        public string From { get; set; }
        public HelloWorldModel HelloWorldData { get; set; }

        public void OnGet(string from)
        {
            HelloWorldData = new HelloWorldModel
            {
                From = from
            };
        }
    }
}