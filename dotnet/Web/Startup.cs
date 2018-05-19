using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HypernovaNet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = Configuration.GetSection("App").Get<AppSettings>();
            services.AddMvc();
            services.AddSingleton<IHypernovaClient>(new HypernovaClient(new HypernovaConfig
            {
                Endpoint = appSettings.HypernovaEndpoint
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}