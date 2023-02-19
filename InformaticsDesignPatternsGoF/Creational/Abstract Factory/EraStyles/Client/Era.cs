using EraStyles.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.Client
{
    public class Era
    {
        private Style _styleObject;

        public Era(StylesFactory stylesFactory, char era)
        {
            switch (era)
            {
                case 'M':
                    _styleObject = stylesFactory.CreateMedievalStyleObject();
                    break;
                case 'R':
                    _styleObject = stylesFactory.CreateRenaissanceStyleObject();
                    break;
                case 'V':
                    _styleObject = stylesFactory.CreateVictorianEraStyleObject();
                    break;
            }
        }

        public void Info()
        {
            _styleObject.ShowDetails();
        }
    }
}
