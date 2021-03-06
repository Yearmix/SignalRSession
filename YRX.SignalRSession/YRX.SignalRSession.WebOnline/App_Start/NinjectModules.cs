﻿using System;
using Ninject.Modules;
using YRX.SignalRSession.WebOnline.Infrastructure;

namespace YRX.SignalRSession.WebOnline
{
    public class NinjectModules
    {
        public static INinjectModule[] Modules => new INinjectModule[] { new MainModule() };

        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                Bind<ISessionManager>().ToConstant(SessionsManager.Instance).InSingletonScope();
            }
        }
    }
}