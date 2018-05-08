namespace ServiceManagerAPI.Web
{
    using ServiceManagerAPI.Web.Managers;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "CustomerOrders",
                routeTemplate: "api/{controller}/{customerId}/{action}/{id}",
                defaults: new
                {
                    customerId = RouteParameter.Optional,
                    action = RouteParameter.Optional,
                    id = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "Customers",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    action = RouteParameter.Optional,
                    id = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            config.Formatters.Add(new BrowserJsonFormatter());

            config.Formatters.JsonFormatter
                .SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //config = GlobalConfiguration.Configuration;

            //config.Formatters.JsonFormatter
            //            .SerializerSettings
            //            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }




    }
}
