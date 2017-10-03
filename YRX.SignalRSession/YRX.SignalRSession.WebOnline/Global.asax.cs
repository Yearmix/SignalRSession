using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Optimization;
using Ninject;
using YRX.SignalRSession.WebOnline.Infrastructure;

namespace YRX.SignalRSession.WebOnline
{
    public class Global : HttpApplication
    {
        private ISessionManager _sessionManager;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            NinjectContainer.RegisterModules(NinjectModules.Modules);
            NinjectHttpContainer.RegisterModules(NinjectModules.Modules);
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        [Inject]
        public void InitSessionManager(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //_sessionManager.AddSession(Session);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //_sessionManager.RemoveSession(Session);
        }
    }
}