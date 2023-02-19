using EraStyles.Abstraction;
using EraStyles.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.ConcreteFactories
{
    public class HouseFactory : StylesFactory
    {
        public override Style CreateMedievalStyleObject()
        {
            return new MedievalHouse();
        }

        public override Style CreateRenaissanceStyleObject()
        {
            return new RenaissanceHouse();
        }

        public override Style CreateVictorianEraStyleObject()
        {
            return new VictorianHouse();
        }
    }
}
