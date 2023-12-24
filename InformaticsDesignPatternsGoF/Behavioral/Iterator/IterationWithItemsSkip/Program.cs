using System;
using System.Collections.Generic;

namespace IterationWithItemsSkip
{
    public class Item 
    {
        private string name;

        public Item(string name)
        {
            this.name = name;      
        }

        public string Name { get { return name; } }
    }

    public interface IAbstractIterator
    {
        Item GetFirstItem();

        Item GetNextItem();

        bool IsIterationDone { get; }

        Item GetCurrentItem { get; }
    }

    public class Iterator : IAbstractIterator
    {
        private Collection collection;

        private int currentItemIndex;

        private int stepsToSkip = 1;

        public Iterator(Collection collection)
        {
            this.collection = collection;
        }

        public bool IsIterationDone => currentItemIndex >= collection.Count;

        public Item GetCurrentItem => collection[currentItemIndex];

        public int StepToSkip { get => stepsToSkip; set => stepsToSkip = value; }

        public Item GetFirstItem()
        {
            currentItemIndex = 0;
            return collection[currentItemIndex];
        }

        public Item GetNextItem()
        {
            currentItemIndex += stepsToSkip;

            if (IsIterationDone)
            {
                return null;    
            }
            else
            {
                return collection[currentItemIndex];
            }
        }
    }

    public interface IAbstractCollection
    {
        Iterator CreateIterator();
    }

    public class Collection : IAbstractCollection
    {
        readonly List<Item> items = new List<Item>();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int Count => items.Count;

        public Item this[int index]
        {
            get => items[index];
            set => items.Add(value);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Collection collectionToIterateOver = new Collection();

            collectionToIterateOver[0] = new Item("Item 0");
            collectionToIterateOver[1] = new Item("Item 1");
            collectionToIterateOver[2] = new Item("Item 2");
            collectionToIterateOver[3] = new Item("Item 3");
            collectionToIterateOver[4] = new Item("Item 4");
            collectionToIterateOver[5] = new Item("Item 5");
            collectionToIterateOver[6] = new Item("Item 6");
            collectionToIterateOver[7] = new Item("Item 7");
            collectionToIterateOver[8] = new Item("Item 8");

            Iterator iterator = collectionToIterateOver.CreateIterator();

            iterator.StepToSkip = 2;

            Console.WriteLine("Iterating over a collection: ");

            for (Item currentItem = iterator.GetFirstItem(); !iterator.IsIterationDone; currentItem = iterator.GetNextItem())
            {
                Console.WriteLine(currentItem.Name);
            }

            Console.ReadKey();
        }
    }
}
