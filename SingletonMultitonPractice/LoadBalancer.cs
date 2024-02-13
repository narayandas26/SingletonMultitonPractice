using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonMultitonPractice
{
    internal sealed class LoadBalancer
    {
        private static LoadBalancer _singletonInstance;
        private static readonly object _ThreadsafeLock = new object();

        internal static LoadBalancer GetInstance()
        {
            if (_singletonInstance == null)
            {
                lock (_ThreadsafeLock)
                {
                    _singletonInstance = new LoadBalancer();
                }
            }
            return _singletonInstance;
        }

        public void SendServiceRequest()
        {
            var instance = MultitonBackendServer.GetAvailableServer;
            instance.InvokeServer();
        }
    }
}
