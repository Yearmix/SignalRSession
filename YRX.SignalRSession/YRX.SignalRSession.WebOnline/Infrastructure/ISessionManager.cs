using System;
using System.Web.SessionState;

namespace YRX.SignalRSession.WebOnline.Infrastructure
{
    public interface ISessionManager : IDisposable
    {
        HttpSessionState GetSession(string key);
        void AddSession(HttpSessionState session);
        void RemoveSession(HttpSessionState session);
    }
}
