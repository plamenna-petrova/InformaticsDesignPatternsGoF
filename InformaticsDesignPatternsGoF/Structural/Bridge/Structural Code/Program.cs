
using System;

namespace Sturctural_Code
{
    public class Abstraction
    {
        protected Implementor implementor;

        public Implementor Implementor
        {
            set { implementor = value; }
        }

        public virtual void ExecuteOperation()
        {
            implementor.ExecuteOperation();
        }
    }

    public abstract class Implementor
    {
        public abstract void ExecuteOperation();
    }

    public class RefinedAbstraction : Abstraction
    {
        public override void ExecuteOperation()
        {
            implementor.ExecuteOperation();
        }
    }

    public class ConcreteImplementorA : Implementor
    {
        public override void ExecuteOperation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }

    public class ConcreteImplementorB : Implementor
    {
        public override void ExecuteOperation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Abstraction abstraction = new RefinedAbstraction();

            abstraction.Implementor = new ConcreteImplementorA();
            abstraction.ExecuteOperation();

            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.ExecuteOperation();

            Console.ReadKey();
        }
    }
}
