using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeProjectInCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeProjectInCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            //at present this is the middleware as this is writing to the response.
            //using use insteaad of run makes the middle ware non terminal and also lets second middleware to be called as well with next().

            app.Use(async (context,next) =>
            {
                logger.LogInformation("MW1: Incoming request");
                //await context.Response.WriteAsync("Hello from first middleware");
                await next();
                logger.LogInformation("MW1: Outgoing response");
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //below function showld be called before any exception is raised.
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions devPageError = new DeveloperExceptionPageOptions()
                {
                    SourceCodeLineCount = 10
                };
                app.UseDeveloperExceptionPage(devPageError);
            }
            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming request");
                //await context.Response.WriteAsync("Hello from first middleware");
                await next();
                logger.LogInformation("MW2: Outgoing response");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from third middleware!");
                throw new Exception("Generated to demostrate developer exception page");

            });
            
        }
    }
}
