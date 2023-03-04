using System;
using System.Collections.Generic;

namespace Load_Balancer_Optimized
{
    public class LoadBalancer
    {
        private static readonly LoadBalancer instance = new LoadBalancer();

        private readonly List<Server> servers;
        private readonly Random random = new Random();

        protected LoadBalancer()
        {
            servers = new List<Server>
            {
                new Server { Name = "ServerI", IPAddress = "120.14.220.18"},
                new Server { Name = "ServerII", IPAddress = "120.14.220.19" },
                new Server { Name = "ServerIII", IPAddress = "120.14.220.20" },
                new Server { Name = "ServerIV", IPAddress = "120.14.220.21" },
                new Server { Name = "ServerV", IPAddress = "120.14.220.22" }
            };
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return instance;
        }

        public Server NextServer
        {
            get
            {
                int randomServerIndex = random.Next(servers.Count);
                return servers[randomServerIndex];
            }
        }
    }

    public class Server
    {
        public string Name { get; set; }

        public string IPAddress { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            LoadBalancer loadBalancer1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer loadBalancer2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer loadBalancer3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer loadBalancer4 = LoadBalancer.GetLoadBalancer();

            if (loadBalancer1 == loadBalancer2 && loadBalancer2 == loadBalancer3 && loadBalancer3 == loadBalancer4)
            {
                Console.WriteLine($"Same instance of all load balancers \n");
            }

            LoadBalancer loadBalancer5 = LoadBalancer.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                string randomServer = loadBalancer5.NextServer.Name;
                Console.WriteLine("Dispatch Request to: " + randomServer);
            }

            Console.ReadKey();
        }
    }
}
