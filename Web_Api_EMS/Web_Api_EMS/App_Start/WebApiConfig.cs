using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web_Api_EMS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //in order to avoid Pk and Fk loop and serialize
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //to specify what media type formating our api is going to support, we do as below
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
