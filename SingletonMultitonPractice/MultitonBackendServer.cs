using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonMultitonPractice
{
    internal sealed class MultitonBackendServer
    {

        string _serverName;
        string _ipAddress;

        public void InvokeServer()
        {
            Console.WriteLine($"{_serverName} invoked..");
        }

        private static readonly Dictionary<int, MultitonBackendServer> _instances = new()
        {
            { 0, new MultitonBackendServer(){ _serverName = "Server1", _ipAddress = "121.11.230.31" } },
            { 1, new MultitonBackendServer(){ _serverName = "Server2", _ipAddress = "121.11.230.32" } },
            { 2, new MultitonBackendServer(){ _serverName = "Server3", _ipAddress = "121.11.230.33" } },
            { 3, new MultitonBackendServer() { _serverName = "Server4", _ipAddress = "121.11.230.34" } },
        };

        private static readonly object _randomLock = new object();
        private static readonly Random random = new Random();

        public static MultitonBackendServer GetAvailableServer { get
            {
                lock (_randomLock) { 
                    int key = random.Next(_instances.Count );
                    return _instances[key];
                }
            } }
    }
}
