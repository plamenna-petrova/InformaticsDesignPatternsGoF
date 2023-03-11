using System;
using System.Collections.Specialized;

namespace Restaurant_Orders
{
    public interface IRestaurant
    {
        void PlaceOrder(string orderName);
    }

    public abstract class Order
    {
        public IRestaurant restaurant;

        public abstract void SendOrder();
    }

    public class DiaryFreeOrder : Order
    {
        public override void SendOrder()
        {
            restaurant.PlaceOrder("Dairy-Free Meal");
        }
    }

    public class GlutenFreeOrder : Order
    {
        public override void SendOrder()
        {
            restaurant.PlaceOrder("Gluten-Free Meal");
        }
    }

    public class MiddleClassRestaurant : IRestaurant
    {
        public void PlaceOrder(string order)
        {
            Console.WriteLine($"Placing order for {order} at {GetType().Name}");
        }
    }

    public class FancyRestaurant : IRestaurant
    {
        public void PlaceOrder(string order)
        {
            Console.WriteLine($"Placing order for {order} at {GetType().Name}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Order order = new DiaryFreeOrder();
            order.restaurant = new MiddleClassRestaurant();
            order.SendOrder();

            order.restaurant = new FancyRestaurant();
            order.SendOrder();

            order = new GlutenFreeOrder();
            order.restaurant = new MiddleClassRestaurant();
            order.SendOrder();

            order.restaurant = new FancyRestaurant();
            order.SendOrder();

            Console.ReadKey();
        }
    }
}
