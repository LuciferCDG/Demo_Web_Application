using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo_Web_Application.Startup))]
namespace Demo_Web_Application
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            AutomapperConfig.Register();
        }

    }
}