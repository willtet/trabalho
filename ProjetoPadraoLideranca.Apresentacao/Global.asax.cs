using System;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Config;
using Lidercap.Auth;

namespace ProjetoPadraoLideranca.Apresentacao
{
    public class WebApiApplication : HttpApplication
    {
        public readonly ILog Looger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.Config")));
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }

        void Application_Error(object sender, EventArgs e)
        {
            var env = Environment.GetEnvironmentVariable("ENV");
            var url = Config.Url(env);

            Exception exception = Server.GetLastError().GetBaseException();

            if (exception.Message.Contains("Não autenticado"))
                HttpContext.Current.Response.Redirect(url, true);

            LogError(exception);
        }

        protected void LogError(Exception exception)
        {
            Looger.Error(exception.Message);
        }
    }
}
