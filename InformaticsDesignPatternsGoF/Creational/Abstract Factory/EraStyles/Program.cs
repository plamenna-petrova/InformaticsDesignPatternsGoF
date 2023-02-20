using System;
using EraStyles.Abstraction;
using EraStyles.Client;
using EraStyles.ConcreteFactories;

namespace EraStyles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select your object type:");
            Console.WriteLine("[1]House, [2]Ship, [3]Clothing");

            if (int.TryParse(Console.ReadLine(), out int objectType))
            {
                EraObjectStylesFactory stylesFactory = null;

                switch (objectType)
                {
                    case 1:
                        stylesFactory = new HouseFactory();
                        break;
                    case 2:
                        stylesFactory = new ShipFactory();
                        break;
                    case 3:
                        stylesFactory = new ClothingFactory();
                        break;
                }

                Console.WriteLine("Please select your object style:");
                Console.WriteLine("[1]Medieval, [2]Renaissance, [3]Victorian Era");

                if (int.TryParse(Console.ReadLine(), out int eraStyle))
                {
                    EraObject eraObject = null;

                    switch (eraStyle)
                    {
                        case 1:
                            eraObject = stylesFactory.CreateMedievalStyleObject();
                            break;
                        case 2:
                            eraObject = stylesFactory.CreateRenaissanceStyleObject();
                            break;
                        case 3:
                            eraObject = stylesFactory.CreateVictorianEraStyleObject();
                            break;
                    }

                    eraObject.ShowDetails();
                }
            }

            // alternative

            Console.WriteLine(new string('-', 50));

            int objectsCount = 1;

            Console.WriteLine($"Please select your object type number: {objectsCount}");
            Console.WriteLine("[H]House, [S]Ship, [C]Clothing");

            char objType = Console.ReadKey().KeyChar;

            Console.WriteLine();

            while (objectType != 'E')
            {
                EraObjectStylesFactory factory = null;

                switch (objType)
                {
                    case 'H':
                        factory = new HouseFactory();
                        break;
                    case 'S':
                        factory = new ShipFactory();
                        break;
                    case 'C':
                        factory = new ClothingFactory();
                        break;
                }

                Console.WriteLine("Enter era name: ");
                Console.WriteLine("[M]Medieval, [R]Renaissance, [V]Victorian Era");

                char eraCharacter = Console.ReadKey().KeyChar;

                Console.WriteLine();

                Era era = new Era(factory, eraCharacter); 
                Console.Write($"Object Number #{objectsCount} ");
                era.Info();

                Console.WriteLine(new string('-', 50));

                Console.WriteLine($"Please select your object type: {++objectsCount}");
                Console.WriteLine("[H]House, [S]Ship, [C]Clothing");

                objType = Console.ReadKey().KeyChar;

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
