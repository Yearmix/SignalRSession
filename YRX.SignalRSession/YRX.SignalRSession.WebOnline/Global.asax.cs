using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Optimization;
using YRX.SignalRSession.WebOnline.Infrastructure;

namespace YRX.SignalRSession.WebOnline
{
    public class Global : HttpApplication
    {
        // Hotfix for not working Inject attribute
        private ISessionManager _sessionManager;

        public ISessionManager SessionManager
        {
            get
            {
                return _sessionManager ??
                       (_sessionManager = DependencyResolver.Current.GetService<ISessionManager>());
            }
            set { _sessionManager = value; }
        }

        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            NinjectContainer.RegisterModules(NinjectModules.Modules);
            NinjectHttpContainer.RegisterModules(NinjectModules.Modules);
            NinjectContainer.RegisterAssembly();
            NinjectHttpContainer.RegisterAssembly();
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            SessionManager.AddSession(Session);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            SessionManager.RemoveSession(Session);
        }
    }
}