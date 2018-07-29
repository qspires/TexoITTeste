using System.Web.Http;
using WebActivatorEx;
using TexoITTeste;
using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace TexoITTeste
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Texo IT Teste");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi(c => { });
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\TexoITTeste.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
