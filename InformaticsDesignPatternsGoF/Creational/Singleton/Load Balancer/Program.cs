using System;
using System.Collections.Generic;

namespace Load_Balancer
{
    public class LoadBalancer
    {
        private static LoadBalancer instance;

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
            LoadBalancer firstLoadBalancer = LoadBalancer.GetLoadBalancer();
            LoadBalancer secondLoadBalancer = LoadBalancer.GetLoadBalancer();
            LoadBalancer thirdLoadBalancer = LoadBalancer.GetLoadBalancer();
            LoadBalancer fourthLoadBalancer = LoadBalancer.GetLoadBalancer();

            if (firstLoadBalancer == secondLoadBalancer && secondLoadBalancer == thirdLoadBalancer && thirdLoadBalancer == fourthLoadBalancer)
            {
                Console.WriteLine($"Same instance of all load balancers \n");
            }

            LoadBalancer fifthLoadBalancer = LoadBalancer.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                string randomServer = firstLoadBalancer.Server;
                Console.WriteLine("Dispatch Request to: " + randomServer);
            }

            Console.ReadKey();
        }
    }
}
