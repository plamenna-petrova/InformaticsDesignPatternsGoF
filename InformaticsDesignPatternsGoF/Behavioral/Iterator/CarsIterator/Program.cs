using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CarsIterator
{
    public interface Iterator
    {
        bool MoveNext();    

        object CurrentItem { get; }
    }

    public class ConcreteIteratorForItems : Iterator
    {
        private string[] data;

        private int currentPosition = -1;

        public ConcreteIteratorForItems(string[] data)
        {
            this.data = data;    
        }

        public object CurrentItem => data[currentPosition];

        public bool MoveNext()
        {
            if (currentPosition < data.Length - 1)
            {
                currentPosition++;
                return true;
            }

            return false;
        }
    }

    public interface IIterable
    {
        Iterator CreateIterator();
    }

    public class Collection : IIterable
    {
        private string[] items;

        public Collection(string[] items)
        {
            this.items = items;    
        }

        public Iterator CreateIterator() => new ConcreteIteratorForItems(items);
    }

    public abstract class Company : IIterable
    {
        public abstract Iterator CreateIterator();    
    }

    public class Car
    {
        public Car(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override string ToString() => Name;
    }

    //public class Ferrari : Company
    //{
    //    private List<Car> cars;

    //    public Ferrari()
    //    {
    //        cars = new List<Car>();    
    //    }

    //    public void AddCar(Car car)
    //    {
    //        cars.Add(car);
    //    }

    //    public void RemoveCar(string name) 
    //    { 
    //        var carToRemove = cars.FirstOrDefault(c => c.Name == name);
    //        cars.Remove(carToRemove);
    //    }

    //    public override Iterator CreateIterator()
    //    {
    //        return new FerrariIterator(cars);
    //    }
    //}

    public class Ferrari : IEnumerable
    {
        private List<Car> cars;

        public Ferrari()
        {
            cars = new List<Car>();
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void RemoveCar(string name)
        {
            var carToRemove = cars.FirstOrDefault(x => x.Name == name);
            cars.Remove(carToRemove);
        }
        
        public IEnumerator GetEnumerator() => cars.GetEnumerator();
    }

    //public class Ford : Company
    //{
    //    private Car[] cars;

    //    public Ford(Car[] cars)
    //    {
    //        this.cars = cars;        
    //    }

    //    public override Iterator CreateIterator()
    //    {
    //        return new FordIterator(cars);
    //    }
    //}

    public class Ford : IEnumerable
    {
        private Car[] cars;

        public Ford(Car[] cars)
        {
            this.cars = cars;        
        }

        public IEnumerator GetEnumerator() => cars.GetEnumerator();
    }

    public class FerrariIterator : Iterator
    {
        private List<Car> cars;

        private int currentCarIndex = -1;

        public FerrariIterator(List<Car> cars)
        {
            this.cars = cars;    
        }

        public object CurrentItem => cars[currentCarIndex];

        public bool MoveNext()
        {
            if (currentCarIndex < cars.Count - 1)
            {
                currentCarIndex++;
                return true;
            }

            return false;
        }
    }

    public class FordIterator : Iterator
    {
        private Car[] cars;

        private int currentCarIndex = -1;

        public FordIterator(Car[] cars)
        {
            this.cars = cars;    
        }

        public object CurrentItem => cars[currentCarIndex];

        public bool MoveNext() 
        {
            if (currentCarIndex < cars.Length - 1)
            {
                currentCarIndex++;
                return true;
            }

            return false;
        }
    }

    //public class CarDealer
    //{
    //    private readonly List<Company> carCompanies;

    //    public CarDealer(params Company[] carCompanies)
    //    {
    //        this.carCompanies = carCompanies.ToList();            
    //    }

    //    public void PrintCars()
    //    {
    //        for (int i = 0; i < carCompanies.Count; i++)
    //        {
    //            PrintCars(carCompanies[i].CreateIterator());
    //        }
    //    }

    //    private void PrintCars(Iterator iterator)
    //    {
    //        while (iterator.MoveNext())
    //        {
    //            Console.WriteLine(iterator.CurrentItem.ToString());
    //        }
    //    }
    //}

    public class CarDealer
    {
        private readonly List<IEnumerable> carCompanies;

        public CarDealer(params IEnumerable[] carCompanies)
        {
            this.carCompanies = carCompanies.ToList();
        }

        public void PrintCars()
        {
            for (int i = 0; i < carCompanies.Count; i++)
            {
                //PrintCars(carCompanies[i].GetEnumerator());
                PrintCars(carCompanies[i]);
            }
        }

        //private void PrintCars(IEnumerator enumerator)
        //{
        //    while (enumerator.MoveNext())
        //    {
        //        var current = enumerator.Current;
        //        Console.WriteLine(current.ToString());
        //    }
        //}

        private void PrintCars(IEnumerable enumerable)
        {
            foreach (var car in enumerable)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }

    public class Node
    {
        public Node(int value)
        {
            Value = value;        
        }

        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }

    public abstract class BinaryTreeIterator : IEnumerator
    {
        protected Queue<Node> queue;

        private Node root;

        private object currentItem;

        public BinaryTreeIterator(Node root)
        {
            this.root = root;
            queue = new Queue<Node>();

        }

        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Collection collectionToIterateOver = new Collection(new string[] { "Item1", "Item2", "Item3" });
            Iterator iterator = collectionToIterateOver.CreateIterator();

            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.CurrentItem);
            }

            var ferrari = new Ferrari();

            ferrari.AddCar(new Car("Ferrari F40"));
            ferrari.AddCar(new Car("Ferrari F355"));
            ferrari.AddCar(new Car("Ferrari 250 GT0"));
            ferrari.AddCar(new Car("Ferrari 125 S"));
            ferrari.AddCar(new Car("Ferrari 488 GTB"));

            var ford = new Ford(new Car[]
            {
                new Car("Ford Model T"),
                new Car("Ford GT40"),
                new Car("Ford Escort"),
                new Car("Ford Focus"),
                new Car("Ford Mustang")
            });

            //var carDealer = new CarDealer(ferrari, ford);

            var carDealer = new CarDealer(ferrari, ford);

            carDealer.PrintCars();
        }
    }
}
