using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
using Zola.Web.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Zola.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        public void createDatabase()
        {
            PharmaDbContext db = new PharmaDbContext();
            db.Medicines.Insert(new Models.Medicines() { Id = 1, Name = "First medicine ever", ManufacturingDate = DateTime.Now.AddDays(-9), ExpiryDate = DateTime.Now.AddYears(1) });
            db.Medicines.Insert(new Models.Medicines() { Id = 1, Name = "First medicine ever", ManufacturingDate = DateTime.Now.AddDays(-9), ExpiryDate = DateTime.Now.AddYears(1) });
        }
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    //...

        //    services.AddDbContext<PharmaDbContext>(options => options.UseInMemoryDatabase(databaseName: "PharmaCompany"));
        //}
    }
}