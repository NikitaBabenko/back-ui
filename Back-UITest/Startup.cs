using Back_UITest.SpaHelper;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(Back_UITest.Startup))]

namespace Back_UITest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            app.UseWebApi(config);
            config.MapHttpAttributeRoutes();
            app.UseSpaRazor("index.cshtml");
        }
    }
}
