using EraStyles.Abstraction;
using EraStyles.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.ConcreteFactories
{
    public class ClothingFactory : StylesFactory
    {
        public override Style CreateMedievalStyleObject()
        {
            return new MedievalClothing();
        }

        public override Style CreateRenaissanceStyleObject()
        {
            return new RenaissanceClothing();
        }

        public override Style CreateVictorianEraStyleObject()
        {
            return new VictorianClothing();
        }
    }
}
