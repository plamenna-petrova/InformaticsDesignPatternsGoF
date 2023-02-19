using System;

namespace Architecture
{
    public class Program
    {
        public abstract class StylesFactory
        {
            public abstract Style CreateMedievalStyleObject();

            public abstract Style CreateRenaissanceStyleObject();

            public abstract Style CreateVictorianEraStyleObject();
        }

        public class HouseFactory : StylesFactory
        {
            public override Style CreateMedievalStyleObject()
            {
                return new MedievalHouse();
            }

            public override Style CreateRenaissanceStyleObject()
            {
                return new RenaissanceHouse();
            }

            public override Style CreateVictorianEraStyleObject()
            {
                return new VictorianEraHouse();
            }
        }

        public class ShipFactory : StylesFactory
        {
            public override Style CreateMedievalStyleObject()
            {
                return new MedievalShip();
            }

            public override Style CreateRenaissanceStyleObject()
            {
                return new RenaissancelShip();  
            }

            public override Style CreateVictorianEraStyleObject()
            {
                throw new NotImplementedException();
            }
        }

        public class ClothingFactory : StylesFactory
        {
            public override Style CreateMedievalStyleObject()
            {
                return new MedievalClothing();
            }

            public override Style CreateRenaissanceStyleObject()
            {
                return new RenaissanceClothing();
            }

            public override Style CreateVictorianEraStyleObject()
            {
                throw new NotImplementedException();
            }
        }

        public abstract class Style
        {
            public abstract void ShowDetails();
        }

        public class MedievalHouse : Style
        {
            public override void ShowDetails()
            {
                Console.WriteLine("This is a medieval house");
            }
        }

        public class MedievalShip: Style
        {
            public override void ShowDetails()
            {
                Console.WriteLine("This is a medieval ship");
            }
        }

        public class MedievalClothing: Style
        {
            public override void ShowDetails()
            {
                Console.WriteLine("This is medieval cloting");
            }
        }

        public class RenaissanceHouse : Style
        {
            public override void ShowDetails()
            {
                Console.WriteLine("This is a Renaissance house");
            }
        }

        public class RenaissancelShip : Style
        {
            public override void ShowDetails()
            {
                Console.WriteLine("This is a Renaissance ship");
            }
        }

        public class RenaissanceClothing : Style
        {
            public override void ShowDetails()
            {
                Console.WriteLine("This is Renaissance cloting");
            }
        }

        public class VictorianEraHouse : Style
        {
            public override void ShowDetails()
            {
                Console.WriteLine("This is a Victorian Era house");
            }
        }

        public class VictorianEraShip : Style
        {
            public override void ShowDetails()
            {
                Console.WriteLine("This is a Victorian Era ship");
            }
        }

        public class VictorianEraClothing : Style
        {
            public override void ShowDetails()
            {
                Console.WriteLine("This is Victorian Era cloting");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please select your object type:");
            Console.WriteLine("[1]House, [2]Ship, [3]Clothing");

            if (int.TryParse(Console.ReadLine(), out int objectType))
            {
                StylesFactory stylesFactory = null;

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
                    Style styleObject = null;

                    switch (eraStyle)
                    {
                        case 1:
                            styleObject = stylesFactory.CreateMedievalStyleObject();
                            break;
                        case 2:
                            styleObject = stylesFactory.CreateRenaissanceStyleObject();
                            break;
                        case 3:
                            styleObject = stylesFactory.CreateVictorianEraStyleObject();
                            break;
                    }

                    styleObject.ShowDetails();
                }
            }
        }
    }
}
