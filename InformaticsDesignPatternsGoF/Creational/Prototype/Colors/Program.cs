using System;
using System.Collections.Generic;

namespace Colors
{
    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    public class Color : ColorPrototype
    {
        private int red;
        private int green;
        private int blue;

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;   
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", red, green, blue);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    public class ColorManager
    {
        private Dictionary<string, ColorPrototype> colors = new Dictionary<string, ColorPrototype>();

        // indexer 
        public ColorPrototype this[string key]
        {
            get { return colors[key];  }
            set { colors.Add(key, value); }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager();

            colorManager["red"] = new Color(255, 0, 0);
            colorManager["green"] = new Color(0, 255, 0);
            colorManager["blue"] = new Color(0, 0, 255);

            colorManager["angry"] = new Color(255, 54, 0);
            colorManager["peace"] = new Color(128, 211, 128);
            colorManager["flame"] = new Color(211, 34, 20);

            Color firstColor = colorManager["red"].Clone() as Color;
            Color secondColor = colorManager["peace"].Clone() as Color;
            Color thirdColor = colorManager["flame"].Clone() as Color;

            Console.ReadKey();
        }
    }
}
