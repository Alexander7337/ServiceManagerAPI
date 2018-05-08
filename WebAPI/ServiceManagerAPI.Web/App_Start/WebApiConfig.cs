namespace ServiceManagerAPI.Web
{
    using ServiceManagerAPI.Web.Managers;
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
                routeTemplate: "api/customers/{customerId}/GetCustomerOrders/{id}",
                defaults: new
                {
                    customerId = RouteParameter.Optional,
                    action = RouteParameter.Optional,
                    id = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new BrowserJsonFormatter());

            config.Formatters.JsonFormatter
                .SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }




    }
}
