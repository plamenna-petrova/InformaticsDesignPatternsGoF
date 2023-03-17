using System;

namespace Cars
{
    public interface ICar
    {
        ICar Manufacture();
    }

    public class BMW : ICar
    {
        private string carName = "BMW";

        public string Body { get; set; }

        public string Doors { get; set; }

        public string Wheels { get; set; }

        public string Glass { get; set; }

        public string Engine { get; set; }

        public override string ToString()
        {
            string message = $"BMW [Name= {carName}, Body= {Body}, Doors = {Doors}, Wheels = {Wheels} " +
                $"Glass= {Glass}, Engine = {Engine}";
            return message;
        }

        public ICar Manufacture()
        {
            Body = "carbon fiber material";
            Doors = "4 car doors";
            Wheels = "6 car glasses";
            Glass = "4 MRF wheels";
            return this;
        }
    }

    public abstract class CarDecorator : ICar
    {
        protected ICar car;

        public CarDecorator(ICar car)
        {
            this.car = car;
        }

        public virtual ICar Manufacture()
        {
            return car.Manufacture();
        }
    }

    public class DieselCarDecorator : CarDecorator
    {
        public DieselCarDecorator(ICar car)
            : base(car)
        {

        }

        public override ICar Manufacture()
        {
            car.Manufacture();
            AddEngine(car);
            return car;
        }

        public void AddEngine(ICar car)
        {
            if (car is BMW)
            {
                BMW bmw = (BMW)car;
                bmw.Engine = "Diesel Engine";
                Console.WriteLine($"Added Diesel Engine to the Car : {car}");
            }
        }
    }

    public class PetrolCarDecorator : CarDecorator
    {
        public PetrolCarDecorator(ICar car)
            : base(car)
        {

        }

        public override ICar Manufacture()
        {
            car.Manufacture();
            AddEngine(car);
            return car;
        }

        public void AddEngine(ICar car)
        {
            if (car is BMW)
            {
                BMW bmw = (BMW)car;
                bmw.Engine = "Petrol Engine";
                Console.WriteLine($"Added Petrol Engine to the Car : {car}");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ICar bmwX7 = new BMW();
            bmwX7.Manufacture();
            Console.WriteLine(bmwX7);

            Console.WriteLine();

            DieselCarDecorator dieselCarDecorator = new DieselCarDecorator(bmwX7);
            dieselCarDecorator.Manufacture();

            Console.WriteLine();

            ICar bmwX5 = new BMW();

            PetrolCarDecorator petrolCarDecorator = new PetrolCarDecorator(bmwX5);
            petrolCarDecorator.Manufacture();

            Console.ReadKey();
        }
    }
}
