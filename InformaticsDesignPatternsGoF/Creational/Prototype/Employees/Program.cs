using System;

namespace Employees
{
    public class Employee
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public Employee GetClone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee();
            employee1.Name = "John";
            employee1.Department = "IT";

            Employee employee2 = employee1.GetClone();
            employee2.Name = "James";

            Console.WriteLine($"Employee #1: {employee1.Name} - {employee1.Department}");
            Console.WriteLine($"Employee #2: {employee2.Name} - {employee2.Department}");
        }
    }
}
