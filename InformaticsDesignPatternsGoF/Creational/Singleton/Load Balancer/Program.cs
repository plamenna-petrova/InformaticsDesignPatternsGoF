using System;
using System.Collections.Generic;

namespace Load_Balancer
{
    public class LoadBalancer
    {
        static LoadBalancer instance;

        List<string> servers = new List<string>();
        Random random = new Random();

        private static object locker = new object();

        protected LoadBalancer()
        {
            servers.Add("ServerI");
            servers.Add("ServerII");
            servers.Add("ServerIII");
            servers.Add("ServerIV");
            servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new LoadBalancer();
                    }
                }
            }

            return instance;
        }

        public string Server
        {
            get
            {
                int randomServerIndex = random.Next(servers.Count);
                return servers[randomServerIndex].ToString();
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            LoadBalancer loadBalancer1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer loadBalancer2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer loadBalancer3 =
              LoadBalancer.GetLoadBalancer();
            LoadBalancer loadBalancer4 =
              LoadBalancer.GetLoadBalancer();

            if (loadBalancer1 == loadBalancer2 && loadBalancer2 == loadBalancer3 && loadBalancer3 == loadBalancer4)
            {
                Console.WriteLine($"Same instance of all load balancers \n");
            }

            LoadBalancer loadBalancer5 = LoadBalancer.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                string randomServer = loadBalancer5.Server;
                Console.WriteLine("Dispatch Request to: " + randomServer);
            }

            Console.ReadKey();
        }
    }
}
