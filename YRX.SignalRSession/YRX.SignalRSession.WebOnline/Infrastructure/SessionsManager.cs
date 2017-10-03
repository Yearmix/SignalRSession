using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace YRX.SignalRSession.WebOnline.Infrastructure
{
    public class SessionsManager : ISessionManager
    {
        private Hashtable _sessions;

        private static readonly Lazy<SessionsManager> _instance = new Lazy<SessionsManager>(() => new SessionsManager());

        private SessionsManager()
        {
            _sessions = new Hashtable();
        }

        public static SessionsManager Instance => _instance.Value;

        public void AddSession(HttpSessionState session)
        {
            var theKey = session.SessionID;
            if (!_sessions.ContainsKey(theKey))
            {
                _sessions.Add(theKey, session);
            }
        }

        #region IDisposable Members

        ~SessionsManager()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            _sessions.Clear();
            _sessions = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        #endregion

        public HttpSessionState GetSession(string key)
        {
            return _sessions[key] == null ? null : (HttpSessionState) _sessions[key];
        }

        public void RemoveSession(HttpSessionState session)
        {
            var theKey = session.SessionID;
            if (_sessions.ContainsKey(theKey))
            {
                _sessions.Remove(theKey);
            }
        }
    }
}
