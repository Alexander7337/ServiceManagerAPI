using System.Web.Http;
using WebActivatorEx;
using ServiceManagerAPI.Web;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ServiceManagerAPI.Web
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "ServiceManagerAPI.Web");
                    })
                .EnableSwaggerUi(c => {});
        }
    }
}
