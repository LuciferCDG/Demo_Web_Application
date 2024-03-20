using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI.WebControls;


namespace Demo_Web_Application.App_Start
{
    public class WebApiConfig
    {

        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services
        //    // Configure Web API to use only bearer token authentication.
        //    //config.SuppressDefaultHostAuthentication();
        //    //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );



        //    //To produce JSON format add this line of code
        //    GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
        //    new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

        //    GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
        //        new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));



        //}

    }
}