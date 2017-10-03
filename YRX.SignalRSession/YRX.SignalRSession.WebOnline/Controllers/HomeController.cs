using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRX.SignalRSession.WebOnline.Infrastructure;

namespace YRX.SignalRSession.WebOnline.Controllers
{
    public class HomeController : Controller
    {
        private ISessionManager _session;
        public HomeController(ISessionManager session)
        {
            _session = session;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}