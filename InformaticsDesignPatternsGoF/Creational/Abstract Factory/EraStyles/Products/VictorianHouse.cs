﻿using EraStyles.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.Products
{
    public class VictorianHouse : EraObject
    {
        public override void ShowDetails()
        {
            Console.WriteLine("This is a Victorian Era house");
        }
    }
}
