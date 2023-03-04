using System;

namespace Structural_Code
{
    public abstract class Prototype
    {
        string id;

        public Prototype(string id)
        {
            this.id = id;
        }

        public string Id { get => id; }

        public abstract Prototype Clone();
    }

    public class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string id)
            : base(id)
        {

        }

        public override Prototype Clone()
        {
            return (Prototype) this.MemberwiseClone();
        }
    }

    public class ConcretePrototype2: Prototype
    {
        public ConcretePrototype2(string id)
            : base(id)
        {

        }

        public override Prototype Clone()
        {
            return (Prototype) this.MemberwiseClone();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ConcretePrototype1 concretePrototype1 = new ConcretePrototype1("I");
            ConcretePrototype1 clonedConcretePrototype1 = (ConcretePrototype1) concretePrototype1.Clone();
            Console.WriteLine($"Cloned: {clonedConcretePrototype1.Id}");

            ConcretePrototype2 concretePrototype2 = new ConcretePrototype2("II");
            ConcretePrototype2 clonedConcretePrototype2 = (ConcretePrototype2) concretePrototype2.Clone();
            Console.WriteLine($"Cloned: {clonedConcretePrototype2.Id}");
        }
    }
}
