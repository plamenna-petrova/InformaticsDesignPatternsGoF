using System;

namespace Employees
{
    public abstract class Employee
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public Address Address { get; set; }

        public abstract Employee GetShallowCopy();

        public abstract Employee GetDeepCopy();

        public void GetDetails()
        {
            Console.WriteLine($"Employee Details: Name - {this.Name}, " +
               $"Department - {this.Department}, Address - {this.Address.Name}");
        }
    }

    public class SoftwareDeveloper : Employee
    {
        public override Employee GetShallowCopy()
        {
            return (Employee) this.MemberwiseClone();
        }

        public override Employee GetDeepCopy()
        {
            Employee clonedEmployee = this.GetShallowCopy();
            clonedEmployee.Address = Address.GetClone();
            return clonedEmployee;
        }
    }

    public class Address
    {
        public string Name { get; set; } 

        public Address GetClone()
        {
            return (Address) this.MemberwiseClone();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            SoftwareDeveloper softwareDeveloper1 = new SoftwareDeveloper();
            softwareDeveloper1.Name = "John";
            softwareDeveloper1.Department = "IT";
            softwareDeveloper1.Address = new Address { Name = "London, UK" };

            SoftwareDeveloper softwareDeveloper2 = (SoftwareDeveloper) softwareDeveloper1.GetShallowCopy();

            SoftwareDeveloper softwareDeveloper3 = (SoftwareDeveloper) softwareDeveloper1.GetDeepCopy();

            softwareDeveloper2.Name = "James";
            softwareDeveloper2.Address.Name = "New York, USA";

            softwareDeveloper3.Address.Name = "Barcelona, Spain";

            softwareDeveloper1.GetDetails();
            softwareDeveloper2.GetDetails();
            softwareDeveloper3.GetDetails();
        }
    }
}
