using System;

namespace Structural_Code
{
    public abstract class Component
    {
        public abstract void ExecuteOperation();
    }

    public class ConcreteComponent : Component
    {
        public override void ExecuteOperation()
        {
            Console.WriteLine("Called ExecuteOperation() from Concrete Component");
        }
    }

    public abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void ExecuteOperation()
        {
            if (component != null)
            {
                component.ExecuteOperation();
            }
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public override void ExecuteOperation()
        {
            base.ExecuteOperation();
            Console.WriteLine("Called ExecuteOperation() from ConcreteDecoratorA");
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public override void ExecuteOperation()
        {
            base.ExecuteOperation();
            AddBehavior();
            Console.WriteLine("Called ExecuteOperation() from ConcreteDecoratorB");
        }

        public void AddBehavior()
        {

        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ConcreteComponent concreteComponent = new ConcreteComponent();
            ConcreteDecoratorA concreteDecoratorA = new ConcreteDecoratorA();
            ConcreteDecoratorB concreteDecoratorB = new ConcreteDecoratorB();

            concreteDecoratorA.SetComponent(concreteComponent);
            concreteDecoratorB.SetComponent(concreteDecoratorA);

            concreteDecoratorB.ExecuteOperation();

            Console.ReadKey();
        }
    }
}
