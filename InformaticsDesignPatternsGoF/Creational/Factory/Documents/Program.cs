using System;
using System.Collections.Generic;

namespace Documents
{
    public abstract class Page
    {

    }

    public class SkillsPage: Page
    {

    }

    public class EdutionPage: Page
    {

    }

    public class ExperiencePage: Page
    {

    }

    public class IntroductionPage: Page
    {

    }

    public class ResultsPage: Page
    {

    }

    public class ConclusionPage: Page
    {

    }

    public class SummaryPage: Page
    {

    }

    public class BibliographyPage: Page
    {

    }

    public abstract class Document
    {
        public Document()
        {
            CreatePages();
        }

        public List<Page> Pages { get; private set; } = new List<Page>();

        public abstract void CreatePages();
    }

    public class Resume: Document
    {
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EdutionPage());
            Pages.Add(new ExperiencePage());
        }
    }

    public class Report: Document
    {
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
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

                foreach (Page page in document.Pages)
                {
                    Console.WriteLine($" {page.GetType().Name}");
                }
            }

            Console.ReadKey();
        }
    }
}
