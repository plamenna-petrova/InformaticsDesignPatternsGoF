using System;
using System.Collections.Generic;

namespace Shapes
{
    public interface Shape
    {
        void Draw();
    }

    public class Circle : Shape
    {
        public string Color { get; set; }
        private int XCoordinate = 10;
        private int YCooordinate = 20;
        private int Radius = 30;

        public void SetColor(string Color)
        {
            this.Color = Color;
        }
        public void Draw()
        {
            Console.WriteLine($" Circle: Draw() [Color : {Color}, X Coordinate : {XCoordinate} YCoordinate : {YCooordinate}, Radius : {Radius} ]");
        }
    }

    public class ShapeFactory
    {
        private static Dictionary<string, Shape> shapes = new Dictionary<string, Shape>();
        public static Shape GetShape(string shapeType)
        {
            Shape shape = null;

            if (shapeType.Equals("circle", StringComparison.InvariantCultureIgnoreCase))
            {
                if (shapes.TryGetValue("circle", out shape))
                {
                }
                else
                {
                    shape = new Circle();
                    shapes.Add("circle", shape);
                    Console.WriteLine(" Creating circle object with out any color in shapefactory \n");
                }
            }
            return shape;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n Red color Circles ");

            for (int i = 0; i < 3; i++)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Red");
                circle.Draw();
            }

            Console.WriteLine("\n Green color Circles ");

            for (int i = 0; i < 3; i++)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }

            Console.WriteLine("\n Blue color Circles");

            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }

            Console.WriteLine("\n Orange color Circles");

            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Orange");
                circle.Draw();
            }

            Console.WriteLine("\n Black color Circles");

            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Black");
                circle.Draw();
            }

            Console.ReadKey();
        }
    }
}
