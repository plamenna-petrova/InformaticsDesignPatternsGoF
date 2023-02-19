using System;

namespace Furniture
{
    public interface IFurnitureFactory
    {
        IFurniture CreateCabinet();

        IFurniture CreateChair();

        IFurniture CreateDiningTable();
    }

    public interface IFurniture
    {
        void ShowFurnitureStyle();
    }

    public class ClassicFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateCabinet()
        {
            return new ClassicCabinet();
        }

        public IFurniture CreateChair()
        {
            return new ClassicChair();
        }

        public IFurniture CreateDiningTable()
        {
            return new ClassicDiningTable();
        }
    }

    public class ContemporaryFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateCabinet()
        {
            return new ContemporaryCabinet();
        }

        public IFurniture CreateChair()
        {
            return new ContemporaryChair();
        }

        public IFurniture CreateDiningTable()
        {
            return new ContemporaryDiningTable();
        }
    }

    public class ScandinavianFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateCabinet()
        {
            return new ScandinavianCabinet();
        }

        public IFurniture CreateChair()
        {
            return new ScandinavianChair();
        }

        public IFurniture CreateDiningTable()
        {
            return new ScandinavianDiningTable();
        }
    }

    public class ClassicCabinet : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a classic cabinet");
        }
    }

    public class ClassicChair : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a classic chair");
        }
    }

    public class ClassicDiningTable: IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a classic dining table");
        }
    }

    public class ContemporaryCabinet : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a contemporary cabinet");
        }
    }

    public class ContemporaryChair : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a contemporary chair");
        }
    }

    public class ContemporaryDiningTable : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a contemporary dining table");
        }
    }

    public class ScandinavianCabinet : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a Scandinavian cabinet");
        }
    }

    public class ScandinavianChair : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a Scandinavian chair");
        }
    }

    public class ScandinavianDiningTable : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a Scandinavian dining table");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int style;

            do
            {
                Console.WriteLine("Please select your furniture style:");
                Console.WriteLine("[1]Classic, [2]Contemporary, [3]Scandinavian");
                int.TryParse(Console.ReadLine(), out style);
            }
            while (style == 0 || style > 3);

            IFurnitureFactory furnitureFactory = null;

            switch (style)
            {
                case 1:
                    furnitureFactory = new ClassicFurnitureFactory();
                    break;
                case 2:
                    furnitureFactory = new ContemporaryFurnitureFactory();
                    break;
                case 3:
                    furnitureFactory = new ScandinavianFurnitureFactory();
                    break;
            }

            int furnitureType;

            do
            {
                Console.WriteLine("Please select your furniture type:");
                Console.WriteLine("[1]Cabinet, [2]Chair, [3]Dining Table");
                int.TryParse(Console.ReadLine(), out furnitureType);
            }
            while (furnitureType == 0 || furnitureType > 3);

            IFurniture furniture = null;

            switch (furnitureType) 
            {
                case 1:
                    furniture = furnitureFactory.CreateCabinet();
                    break;
                case 2:
                    furniture = furnitureFactory.CreateChair();
                    break;
                case 3:
                    furniture = furnitureFactory.CreateDiningTable();
                    break;
            }

            furniture.ShowFurnitureStyle();
        }
    }
}
