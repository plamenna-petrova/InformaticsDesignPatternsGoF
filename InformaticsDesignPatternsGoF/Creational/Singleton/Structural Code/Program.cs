using System;

namespace Structural_Code
{
    public class Singleton
    {
        static Singleton instance;

        protected Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton1 = Singleton.GetInstance();
            Singleton singleton2 = Singleton.GetInstance();

            if (singleton1 == singleton2)
            {
                Console.WriteLine("The objects share the same instance");
            }

            Console.ReadKey();
        }
    }
}
