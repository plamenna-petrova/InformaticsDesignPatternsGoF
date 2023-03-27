using System;
using System.Collections.Generic;

namespace Documents
{
    public abstract class Section
    {
        
    }

    public class SkillsSection: Section
    {

    }

    public class EducationSection: Section
    {

    }

    public class ExperienceSection: Section
    {

    }

    public class IntroductionSection: Section
    {

    }

    public class ResultsSection: Section
    {

    }

    public class ConclusionSection: Section
    {

    }

    public class SummarySection: Section
    {

    }

    public class BibliographySection: Section
    {

    }

    public abstract class Document
    {
        public Document()
        {
            CreateSections();
        }

        public List<Section> Sections { get; private set; } = new List<Section>();

        public abstract void CreateSections();
    }

    public class Resume: Document
    {
        public override void CreateSections()
        {
            Sections.Add(new SkillsSection());
            Sections.Add(new EducationSection());
            Sections.Add(new ExperienceSection());
        }
    }

    public class Report: Document
    {
        public override void CreateSections()
        {
            Sections.Add(new IntroductionSection());
            Sections.Add(new ResultsSection());
            Sections.Add(new ConclusionSection());
            Sections.Add(new SummarySection());
            Sections.Add(new BibliographySection());
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();

            foreach (Document document in documents)
            {
                Console.WriteLine($"\n {document.GetType().Name} --");

                foreach (Section section in document.Sections)
                {
                    Console.WriteLine($" {section.GetType().Name}");
                }
            }

            Console.ReadKey();
        }
    }
}
