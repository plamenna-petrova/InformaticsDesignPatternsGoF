using System;

namespace Structural_Code
{
    public abstract class Product
    {

    }

    public class ConcreteProductA: Product
    {

    }

    public class ConcreteProductB: Product
    {

    }

    public abstract class Creator
    {
        public abstract Product CreateProduct();
    }

    public class ConcreteCreatorA : Creator
    {
        public override Product CreateProduct()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override Product CreateProduct()
        {
            return new ConcreteProductB();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            foreach (Creator creator in creators)
            {
                Product product = creator.CreateProduct();
                Console.WriteLine($"Created: {product.GetType().Name}");
            }

            Console.ReadKey();
        }
    }
}
