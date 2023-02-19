using EraStyles.Abstraction;
using EraStyles.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.ConcreteFactories
{
    public class ShipFactory : StylesFactory
    {
        public override Style CreateMedievalStyleObject()
        {
            return new MedievalShip();
        }

        public override Style CreateRenaissanceStyleObject()
        {
            return new RenaissancelShip();
        }

        public override Style CreateVictorianEraStyleObject()
        {
            return new VictorianShip();
        }
    }
}
