using System;
using System.Collections.Generic;

namespace Structural_Code
{
    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        public abstract void Display(int depth);
    }

    public class Composite : Component
    {
        List<Component> children = new List<Component>();

        public Composite(string name)
            : base(name)
        {

        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);

            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    public class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        {

        }

        public override void Add(Component component)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component component)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite composite = new Composite("Composite X");
            composite.Add(new Leaf("Leaf XA"));
            composite.Add(new Leaf("Leaf XB"));

            root.Add(composite);
            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            root.Display(1);

            Console.ReadKey();
        }
    }
}
