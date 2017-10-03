using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(YRX.SignalRSession.WebOnline.Startup))]
namespace YRX.SignalRSession.WebOnline
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}