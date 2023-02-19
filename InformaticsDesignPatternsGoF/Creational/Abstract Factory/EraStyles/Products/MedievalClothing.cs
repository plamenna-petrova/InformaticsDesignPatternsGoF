using EraStyles.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.Products
{
    public class MedievalClothing: Style
    {
        public override void ShowDetails()
        {
            Console.WriteLine("This is medieval clothing");
        }
    }
}
