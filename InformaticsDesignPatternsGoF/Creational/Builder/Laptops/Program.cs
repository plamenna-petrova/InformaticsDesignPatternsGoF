using Laptops.Builder;
using Laptops.ConcreteBuilders;
using Laptops.Director;
using System;
using System.Text;

namespace Laptops
{
    public class Program
    {
        static void Main(string[] args)
        {
            LaptopBuilder laptopBuilder = null;

            LaptopStore laptopStore = new LaptopStore();

            laptopBuilder = new ASUSConcreteBuilder();
            laptopStore.BuildLaptopConfiguration(laptopBuilder);
            laptopBuilder.Laptop.ShowDetails();

            laptopBuilder = new LenovoConcreteBuilder();
            laptopStore.BuildLaptopConfiguration(laptopBuilder);
            laptopBuilder.Laptop.ShowDetails();
        }
    }
}
