using System;
using System.Text;

namespace Chemical_Databank
{
    public class Compound
    {
        protected float boilingPoint;

        protected float meltingPoint;

        protected double molecularWeight;

        protected string molecularFormula;

        public virtual void Display()
        {
            Console.WriteLine("\nCompound: Unknown: -------");
        }
    }

    public class RichCompound : Compound
    {
        private string chemical;

        private ChemicalDatabank chemicalDatabank;

        public RichCompound(string chemical)
        {
            this.chemical = chemical;
        }

        public override void Display()
        {
            chemicalDatabank = new ChemicalDatabank();

            boilingPoint = chemicalDatabank.GetCriticalPoint(chemical, "B");
            meltingPoint = chemicalDatabank.GetCriticalPoint(chemical, "M");
            molecularWeight = chemicalDatabank.GetMolecularWeight(chemical);
            molecularFormula = chemicalDatabank.GetMolecularStructure(chemical);

            var stringBuilder = new StringBuilder()
                .AppendLine($"Compound :  {new string('-', 7)} {chemical}")
                .AppendLine($" Formula : {molecularFormula}")
                .AppendLine($" Weight : {molecularWeight}")
                .AppendLine($" Melting Point: {meltingPoint}")
                .AppendLine($" Boiling Point: {boilingPoint}");

            Console.WriteLine(stringBuilder.ToString());
        }
    }

    public class ChemicalDatabank
    {
        public float GetCriticalPoint(string compound, string point)
        {
            if (point == "M")
            {
                switch (compound.ToLower())
                {
                    case "water":
                        return 0.0f;
                    case "benzene":
                        return 5.5f;
                    case "ethanol":
                        return -114.1f;
                    default:
                        return 0f;
                }
            }
            else
            {
                switch (compound.ToLower())
                {
                    case "water":
                        return 100.0f;
                    case "benzene":
                        return 80.1f;
                    case "ethanol":
                        return 78.3f;
                    default:
                        return 0f;
                }
            }
        }

        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water":
                    return "H20";
                case "benzene":
                    return "C6H6";
                case "ethanol":
                    return "C2H50H";
                default:
                    return "";
            }
        }

        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water":
                    return 18.015;
                case "benzene":
                    return 78.1134;
                case "ethanol":
                    return 46.0688;
                default:
                    return 0d;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Compound unknown = new Compound();
            unknown.Display();

            Compound water = new RichCompound("Water");
            water.Display();
            Compound benzene = new RichCompound("Benzene");
            benzene.Display();
            Compound ethanol = new RichCompound("Ethanol");
            ethanol.Display();

            Console.ReadKey();
        }
    }
}
