using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TexoITTeste.App_Start;
using TexoITTeste.Manager;
using TexoITTeste.Models;
using TexoITTeste.ViewModel;

namespace TexoITTeste
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static List<CIDADE> CidadePublic = new List<CIDADE>();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            managerCidade mngCidade = new managerCidade();
            MvcApplication.CidadePublic = mngCidade.CarregaMemoria();
        }
    }
}
