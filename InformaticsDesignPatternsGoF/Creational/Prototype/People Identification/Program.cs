using System;
using System.Xml.Linq;

namespace People_Identification
{
    public abstract class Person
    {
        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }  
        
        public IdInfo IdInfo { get; set; }

        public Person(int age, DateTime birthDate, string name, IdInfo idInfo)
        {
            Age = age;
            BirthDate = birthDate;
            Name = name;
            IdInfo = idInfo;
        }

        public abstract Person ShallowCopy();

        public abstract Person DeepCopy();
    }

    public class Traveller : Person
    {
        public Traveller(int age, DateTime birthDate, string name, IdInfo idInfo) 
            : base(age, birthDate, name, idInfo)
        {

        }

        public override Person ShallowCopy()
        {
            return MemberwiseClone() as Person;
        }

        public override Person DeepCopy()
        {
            Person clonedPerson = (Person) MemberwiseClone();
            clonedPerson.IdInfo = new IdInfo(IdInfo.IdNumber);
            return clonedPerson;
        }
    }

    public class IdInfo
    {
        public int IdNumber { get; set; }

        public IdInfo(int idNumber)
        {
            IdNumber = idNumber;
        } 
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Traveller firstTraveller = new Traveller(
                42, 
                Convert.ToDateTime("1977-01-01"), 
                "Jack Daniels", 
                new IdInfo(666)
            );

            Traveller secondTraveller = firstTraveller.ShallowCopy() as Traveller;

            Traveller thirdTraveller = firstTraveller.DeepCopy() as Traveller;

            Console.WriteLine("Original values of the first, second and third travellers: ");
            Console.WriteLine("Traveller #1 instance values: ");
            DisplayValues(firstTraveller);
            Console.WriteLine("Traveller #2 instance values: ");
            DisplayValues(secondTraveller);
            Console.WriteLine("Traveller #3 instance values: ");
            DisplayValues(thirdTraveller);

            firstTraveller.Age = 32;
            firstTraveller.BirthDate = Convert.ToDateTime("1990-05-06");
            firstTraveller.Name = "Frank";
            firstTraveller.IdInfo.IdNumber = 7879;

            Console.WriteLine("Values of the first, second and third travellers after applying changes to the first one: ");
            Console.WriteLine("Traveller #1 instance values: ");
            DisplayValues(firstTraveller);
            Console.WriteLine("Traveller #2 instance values (reference values have changed - shallow copy) :");
            DisplayValues(secondTraveller);
            Console.WriteLine("Traveller #3 instance values (everything was kept the same - deep copy) : ");
            DisplayValues(thirdTraveller);
        }

        public static void DisplayValues(Person person)
        {
            Console.WriteLine(new string(' ', 10) + "Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}", 
                person.Name, person.Age, person.BirthDate);
            Console.WriteLine(new string(' ', 10) + "ID#: {0:d}", person.IdInfo.IdNumber);
        }
    }
}
