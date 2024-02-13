using Microsoft.Extensions.DependencyInjection;
using SingletonMultitonPractice;
using System.Security.Authentication.ExtendedProtection;

internal class Program
{
    private static void Main(string[] args)
    {

        //ServiceCollection services = new ServiceCollection();
        //services.AddSingleton<ServerPoolHandler>();
        //var provider = services.BuildServiceProvider();

        //var poolhandler = provider.GetRequiredService<ServerPoolHandler>();


        for (int i = 0; i < 15; i++)
        {
            var loadBalancer = LoadBalancer.GetInstance();
            Console.WriteLine(loadBalancer.GetHashCode().ToString());
            loadBalancer.SendServiceRequest();
        }


        Console.ReadLine();
    }
}

//internal class ServerPoolHandler
//{
//    public void SendServiceRequest()
//    {
//        var instance = MultitonBackendServer.GetAvailableServer;
//        instance.InvokeServer();
//    }
//}