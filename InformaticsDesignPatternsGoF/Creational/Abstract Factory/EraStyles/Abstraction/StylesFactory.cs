using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.Abstraction
{
    public abstract class StylesFactory
    {
        public abstract Style CreateMedievalStyleObject();

        public abstract Style CreateRenaissanceStyleObject();

        public abstract Style CreateVictorianEraStyleObject();
    }
}
