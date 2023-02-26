using System;
using System.Collections.Generic;

namespace Structural_Code
{
    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    public class Product
    {
        private List<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine($"\nProduct Parts" + new string('-', 10));

            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    public class ConcreteBuilder1 : Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("PartA");
        }

        public override void BuildPartB()
        {
            product.Add("PartB");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    public class ConcreteBuilder2: Builder
    {
        private Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("PartX");
        }

        public override void BuildPartB()
        {
            product.Add("PartY");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            Builder builder1 = new ConcreteBuilder1();
            Builder builder2 = new ConcreteBuilder2();

            director.Construct(builder1);
            Product product1 = builder1.GetResult();
            product1.Show();

            director.Construct(builder2);
            Product product2 = builder2.GetResult();
            product2.Show();

            Console.ReadKey();
        }
    }
}
