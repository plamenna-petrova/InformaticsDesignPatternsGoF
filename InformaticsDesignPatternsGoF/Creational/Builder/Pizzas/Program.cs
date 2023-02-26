using System;
using System.Collections.Generic;

namespace Pizzas
{
    public class Pizza
    {
        private string pizzaName;

        private Dictionary<string, string> ingredients = new Dictionary<string, string>();

        public Pizza(string pizzaName)
        {
            this.pizzaName = pizzaName; 
        }

        public string this[string key]
        {
            get
            {
                return ingredients[key];
            }

            set
            {
                ingredients[key] = value;
            }
        }

        public void ShowIngredients()
        {
            Console.WriteLine($"\n{new string('-', 40)}");
            Console.WriteLine($"Pizza: {pizzaName}");
            Console.WriteLine($" Dough: {ingredients["dough"]}");
            Console.WriteLine($" Sauce: {ingredients["sauce"]}");
            Console.WriteLine($" Meat: {ingredients["meat"]}");
            Console.WriteLine($" Cheese: {ingredients["cheese"]}");
            Console.WriteLine($" Veggies: {ingredients["veggies"]}");
            Console.WriteLine($" Extras: {ingredients["extras"]}");
        }
    }

    public abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public Pizza Pizza
        {
            get 
            { 
                return pizza; 
            }
        }

        public abstract void AddDough();

        public abstract void AddSauce();

        public abstract void AddMeat();

        public abstract void AddCheese();

        public abstract void AddVeggies();

        public abstract void AddExtras();
    }

    public class Pepperoni : PizzaBuilder
    {
        public Pepperoni()
        {
            pizza = new Pizza("Pepperoni");
        }

        public override void AddDough()
        {
            pizza["dough"] = "Wheat pizza dough";
        }

        public override void AddSauce()
        {
            pizza["sauce"] = "Tomato base";
        }

        public override void AddMeat()
        {
            pizza["meat"] = "Pepperoni, Ham, Beef, Chicken";
        }

        public override void AddCheese()
        {
            pizza["cheese"] = "Mozzarella";
        }

        public override void AddVeggies()
        {
            pizza["veggies"] = string.Empty;
        }

        public override void AddExtras()
        {
            pizza["extras"] = "jalapenos";
        }
    }

    public class HawaiianPizza : PizzaBuilder
    {
        public HawaiianPizza()
        {
            pizza = new Pizza("Hawaiian Pizza");
        }

        public override void AddDough()
        {
            pizza["dough"] = "Ball pizza dough";
        }

        public override void AddSauce()
        {
            pizza["sauce"] = "Tomato base";
        }

        public override void AddMeat()
        {
            pizza["meat"] = "Sliced cooked ham";
        }

        public override void AddCheese()
        {
            pizza["cheese"] = "Mozzarella";
        }

        public override void AddVeggies()
        {
            pizza["veggies"] = "Fresh pineapple chunks";
        }

        public override void AddExtras()
        {
            pizza["extras"] = string.Empty;
        }
    }

    public class Pizzeria
    {
        public void MakePizza(PizzaBuilder pizzaBuilder)
        {
            pizzaBuilder.AddDough();
            pizzaBuilder.AddSauce();
            pizzaBuilder.AddCheese();
            pizzaBuilder.AddMeat();
            pizzaBuilder.AddVeggies();
            pizzaBuilder.AddExtras();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            PizzaBuilder pizzaBuilder = null;

            Pizzeria pizzeria = new Pizzeria();

            pizzaBuilder = new Pepperoni();
            pizzeria.MakePizza(pizzaBuilder);
            pizzaBuilder.Pizza.ShowIngredients();

            pizzaBuilder = new HawaiianPizza();
            pizzeria.MakePizza(pizzaBuilder);
            pizzaBuilder.Pizza.ShowIngredients();

            Console.ReadKey();
        }
    }
}
