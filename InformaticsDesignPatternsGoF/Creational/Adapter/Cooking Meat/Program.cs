using System;
using System.Text;

namespace Cooking
{
    public class MeatDatabase
    {
        public float GetSafeCookingTemperature(string meat)
        {
            switch (meat.ToLower())
            {
                case "beef":
                case "pork":
                    return 145f;
                case "chicken":
                case "turkey":
                    return 165f;
                default:
                    return 165f;
            }
        }

        public int GetCaloriesPerOunce(string meat)
        {
            switch (meat.ToLower())
            {
                case "beef":
                    return 71;
                case "pork":
                    return 69;
                case "chicken":
                    return 66;
                case "turkey":
                    return 38;
                default:
                    return 0;
            }
        }

        public double GetProteinPerOunce(string meat)
        {
            switch (meat.ToLower())
            {
                case "beef":
                    return 7.33f;
                case "pork":
                    return 7.67;
                case "chicken":
                    return 8.57;
                case "turkey":
                    return 8.5f;
                default:
                    return 0f;
            }
        }
    }

    public class Meat
    {
        protected string meatName;
        protected double safeCookingTemperatureInFahrenheit;
        protected double safeCookingTemperaturInCelsius;
        protected double caloriesPerOunce;
        protected double caloriesPerGram;
        protected double proteinPerOunce;
        protected double proteinPerGram;

        public Meat(string meatName)
        {
            this.meatName = meatName;
        }

        public virtual void LoadData()
        {
            Console.WriteLine($"\nMeat: {meatName} {new string('-', 7)}");
        }
    }

    public class MeatDetails : Meat
    {
        private MeatDatabase meatDatabase;

        public MeatDetails(string meatName) :
            base(meatName)
        {

        }

        public override void LoadData()
        {
            meatDatabase = new MeatDatabase();
            safeCookingTemperatureInFahrenheit = meatDatabase.GetSafeCookingTemperature(meatName);
            safeCookingTemperaturInCelsius = FathrenheitToCelsius(safeCookingTemperatureInFahrenheit);
            caloriesPerOunce = meatDatabase.GetCaloriesPerOunce(meatName);
            caloriesPerGram = PoundsToGrams(caloriesPerOunce);
            proteinPerOunce = meatDatabase.GetProteinPerOunce(meatName);
            proteinPerGram = PoundsToGrams(proteinPerOunce);

            base.LoadData();

            string meatDetails = new StringBuilder()
                .AppendLine($" Safe Cooking Temperature (Fahrenheit) : " +
                    $"{Math.Round(safeCookingTemperatureInFahrenheit, 2)}")
                .AppendLine($" Safe Cooking Temperature (Celsius) : " +
                    $"{Math.Round(safeCookingTemperaturInCelsius, 2)}")
                .AppendLine($" Calories per Ounce: " +
                    $"{Math.Round(caloriesPerOunce, 2)}")
                .AppendLine($" Calories per Gram: " +
                    $"{Math.Round(caloriesPerGram, 2)}")
                .AppendLine($" Protein per Ounce: " +
                    $"{Math.Round(proteinPerOunce, 2)}")
                .AppendLine($" Protein per gram: " +
                    $"{Math.Round(proteinPerGram, 2)}").ToString();

            Console.WriteLine(meatDetails);
        }

        private double FathrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 0.55555;
        }

        private double PoundsToGrams(double pounds)
        {
            return pounds * 0.0283 / 1000;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Meat unknown = new Meat("Beef");
            unknown.LoadData();

            MeatDetails beef = new MeatDetails("Beef");
            beef.LoadData();

            MeatDetails chicken = new MeatDetails("Chicken");
            chicken.LoadData();

            MeatDetails turkey = new MeatDetails("Turkey");
            turkey.LoadData();
        }
    }
}
