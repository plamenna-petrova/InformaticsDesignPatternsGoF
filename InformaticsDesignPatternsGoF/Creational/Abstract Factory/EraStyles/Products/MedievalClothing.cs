using EraStyles.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.Products
{
    public class MedievalClothing: EraObject
    {
        public override void ShowDetails()
        {
            Console.WriteLine("This is medieval clothing");
        }
    }
}
