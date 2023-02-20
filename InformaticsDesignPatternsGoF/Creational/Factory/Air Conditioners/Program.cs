using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;

namespace Air_Conditioners
{
    public interface IAirConditioner
    {
        void Operate();
    }

    public class CoolingManger: IAirConditioner
    {
        private readonly double temperature;

        public CoolingManger(double temperature)
        {
            this.temperature = temperature; 
        }

        public void Operate()
        {
            Console.WriteLine($"Cooling the room to the required temperature of {temperature} degrees");
        }
    }

    public class WarmingManager : IAirConditioner
    {
        private readonly double temperature;

        public WarmingManager(double temperature)
        {
            this.temperature = temperature;
        }

        public void Operate()
        {
            Console.WriteLine($"Warming the room to the required temperature of {temperature} degrees");
        }
    }

    public abstract class AirConditionerFactory
    {
        public abstract IAirConditioner CreateAirConditioner(double temperature);
    }

    public class CoolingFactory: AirConditionerFactory
    {
        public override IAirConditioner CreateAirConditioner(double temperature) => new CoolingManger(temperature);
    }

    public class WarmingFactory : AirConditionerFactory
    {
        public override IAirConditioner CreateAirConditioner(double temperature) => new WarmingManager(temperature);
    }

    public enum Actions
    {
        Cooling,
        Warming
    }

    public class AirConditioner
    {
        private readonly Dictionary<Actions, AirConditionerFactory> _airConditionerFactories;

        public AirConditioner()
        {
            _airConditionerFactories = new Dictionary<Actions, AirConditionerFactory>();

            foreach (Actions action in Enum.GetValues(typeof(Actions)))
            {
                var airConditionerFactory = (AirConditionerFactory) Activator.CreateInstance(
                    Type.GetType("Air_Conditioners." + Enum.GetName(typeof(Actions), action) + "Factory")
                );
                _airConditionerFactories.Add(action, airConditionerFactory);
            }
        }

        public IAirConditioner ExecuteCreation(Actions action, double temperature)
            => _airConditionerFactories[action].CreateAirConditioner(temperature);  
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var airConditioner = new AirConditioner();

            var coolingAirConditioner = airConditioner.ExecuteCreation(Actions.Cooling, 22.5);
            coolingAirConditioner.Operate();

            var warmingAirConditioner = airConditioner.ExecuteCreation(Actions.Warming, 33.4);
            warmingAirConditioner.Operate();
        }
    }
}
