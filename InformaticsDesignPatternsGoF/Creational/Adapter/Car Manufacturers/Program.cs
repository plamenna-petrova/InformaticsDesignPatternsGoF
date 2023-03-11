using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Car_Manufacturers
{
    public class Manufacturer
    {
        public string Name { get; set; }

        public string City { get; set; }

        public int Year { get; set; }
    }

    public static class ManufacturerDataProvider
    {
        public static List<Manufacturer> GetManufacturers() =>
            new List<Manufacturer>
            {
                new Manufacturer { City = "Italy", Name = "Alfa Romeo", Year = 2016 },
                new Manufacturer { City = "UK", Name = "Aston Martin", Year = 2018 },
                new Manufacturer { City = "USA", Name = "Dodge", Year = 2017 },
                new Manufacturer { City = "Japan", Name = "Subaru", Year = 2016 },
                new Manufacturer { City = "Germany", Name = "BMW", Year = 2015 }
            };
    }

    public class XmlConverter
    {
        public XDocument GetXML()
        {
            XDocument xDocument = new XDocument();
            XElement xElement = new XElement("Manufacturers");
            IEnumerable<XElement> xAttributes = ManufacturerDataProvider.GetManufacturers()
                .Select(m => new XElement("Manufacturer",
                    new XAttribute("City", m.City),
                    new XAttribute("Name", m.Name),
                    new XAttribute("Year", m.Year)
                 ));
            xElement.Add(xAttributes);
            xDocument.Add(xElement);

            Console.WriteLine(xDocument);

            return xDocument;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            XmlConverter xmlConverter = new XmlConverter();
            xmlConverter.GetXML();
        }
    }
}
