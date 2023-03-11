using System;
using System.Collections.Generic;

namespace Customers
{
    public class CustomerBase
    {
        private DataObject dataObject;

        public DataObject DataObject
        {
            get => dataObject;
            set => dataObject = value;
        }

        public virtual void Next()
        {
            dataObject.GetNextRecord();
        }

        public virtual void Previous()
        {
            dataObject.GetPreviousRecord();
        }

        public virtual void Add(string customer)
        {
            dataObject.AddRecord(customer);
        }

        public virtual void Remove(string customer)
        {
            dataObject.RemoveRecord(customer);
        }

        public virtual void Show()
        {
            dataObject.ShowRecord();
        }

        public virtual void ShowAll()
        {
            dataObject.ShowAllRecords();
        }
    }

    public class Customers : CustomerBase
    {
        public override void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));
            base.ShowAll();
            Console.WriteLine(new string('-', 20));
        }
    }

    public abstract class DataObject
    {
        public abstract void GetNextRecord();

        public abstract void GetPreviousRecord();

        public abstract void AddRecord(string name);

        public abstract void RemoveRecord(string name);

        public abstract string GetCurrentRecord();

        public abstract void ShowRecord();

        public abstract void ShowAllRecords();
    }

    public class CustomersData : DataObject
    {
        private readonly List<string> customers = new List<string>();

        private int currentCustomerIndex = 0;

        private string city;

        public CustomersData(string city)
        {
            this.city = city;

            customers.Add("Jim Jones");
            customers.Add("Samuel Jackson");
            customers.Add("Allen Good");
            customers.Add("Ann Stills");
            customers.Add("Lisa Giolani");
        }

        public override void GetNextRecord()
        {
            if (currentCustomerIndex <= customers.Count - 1)
            {
                currentCustomerIndex++;
            }
        }

        public override void GetPreviousRecord()
        {
            if (currentCustomerIndex > 0)
            {
                currentCustomerIndex--;
            }
        }

        public override void AddRecord(string customer)
        {
            customers.Add(customer);
        }

        public override void RemoveRecord(string customer)
        {
            customers.Remove(customer);
        }

        public override string GetCurrentRecord()
        {
            return customers[currentCustomerIndex];
        }

        public override void ShowRecord()
        {
            Console.WriteLine(customers[currentCustomerIndex]);
        }

        public override void ShowAllRecords()
        {
            Console.WriteLine($"Customer City: {city}");

            foreach (string customer in customers)
            {
                Console.WriteLine($" {customer}");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // Create RefinedAbstraction
            CustomerBase customers = new Customers();

            // Set ConcreteImplementor
            customers.DataObject = new CustomersData("Chicago");

            // Exercise the bridge
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Previous();
            customers.Show();
            customers.Add("Henry Velasquez");
            customers.ShowAll();
            customers.Remove("Allen Good");
            customers.ShowAll();

            Console.ReadKey();
        }
    }
}
