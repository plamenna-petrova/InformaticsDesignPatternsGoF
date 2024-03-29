﻿using System;

namespace Structural_Code
{
    public class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    public class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }

    public class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }

    public class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }

    public class Facade
    {
        SubSystemOne subSystemOne;

        SubSystemTwo subSystemTwo;

        SubSystemThree subSystemThree;

        SubSystemFour subSystemFour;

        public Facade()
        {
            subSystemOne = new SubSystemOne();
            subSystemTwo = new SubSystemTwo();
            subSystemThree = new SubSystemThree();
            subSystemFour = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            subSystemOne.MethodOne();
            subSystemTwo.MethodTwo();
            subSystemFour.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            subSystemTwo.MethodTwo();
            subSystemThree.MethodThree();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            Console.ReadKey();
        }
    }
}
