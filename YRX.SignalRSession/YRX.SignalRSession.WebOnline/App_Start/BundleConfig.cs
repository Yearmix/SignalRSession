using System;
using System.Web.Optimization;

namespace YRX.SignalRSession.WebOnline
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/main").Include(
                "~/Scripts/jquery-{version}.js", 
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/css/main").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-datepicker.css",
                "~/Content/site.css"));
        }
    }
}