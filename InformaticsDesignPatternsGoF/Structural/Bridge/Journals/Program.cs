using System;
using System.Collections;
using System.Collections.Generic;

namespace Journals
{
    public abstract class Academy
    { 
        protected IJournal journal;

        protected Academy(IJournal journal)
        {
            this.journal = journal;
        }

        public abstract void AddMessage(string message);

        public abstract void DescribeEvent(string friend, string message);

        public abstract void Poke(string targetPerson);
    }

    public class JediAcademy : Academy
    {
        public JediAcademy(IJournal journal) 
            : base(journal)
        {

        }

        public override void AddMessage(string message)
        {
            journal.AddMessage(message);    
        }

        public override void DescribeEvent(string friend, string message)
        {
            journal.DescribeEvent(friend, message); 
        }

        public override void Poke(string targetPerson)
        {
            journal.Poke(targetPerson);
        }
    }

    public interface IJournal
    {
        void AddMessage(string message);

        void DescribeEvent(string friend, string message);

        void Poke(string targetPerson);
    }

    public class DailyJournal : IJournal
    {
        static SortedList<string, DailyJournal> community = new SortedList<string, DailyJournal>(100);

        private string pages;

        private string name;

        private const string gap = "\n\t\t\t\t";

        public DailyJournal(string name)
        {
            this.name = name;
            community[name] = this;
        }

        public void AddMessage(string message)
        {
            pages += gap + message;
            Console.Write($"{gap} {new string('=', 7)} {name} \'s' Spacebook {new string('=', 7)}");
            Console.Write(pages);
            Console.WriteLine($"{gap} {new string('=', 70)}");
        }

        public void DescribeEvent(string friend, string message)
        {
            community[friend].AddMessage(message);
        }

        public void Poke(string targetPerson)
        {
            community[targetPerson].pages += $"{gap} You have been poked";
        }
    }

    public class ShareJournal : IJournal
    {
        private DailyJournal dailyJournal;

        private string name;

        private int users;

        public ShareJournal(string name)
        {
            this.name = name;
            users++;
            dailyJournal = new DailyJournal($"{name}\'s daily journal");
        }

        public void AddMessage(string message)
        {
            dailyJournal.AddMessage(message);
        }

        public void DescribeEvent(string friend, string message)
        {
            dailyJournal.AddMessage($"{friend}, {name} said: {message}");
        }

        public void Poke(string targetPerson)
        {
            dailyJournal.Poke(targetPerson);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            DailyJournal skywalkerDailyJournal = new DailyJournal("Luke");
            skywalkerDailyJournal.AddMessage(" Hello, Jedi World ");
            skywalkerDailyJournal.AddMessage(" Busy day at training with the green saber today :( ");

            IJournal jedisShareJournal = new ShareJournal("Jedis");
            Academy academy = new JediAcademy(jedisShareJournal);
            academy.Poke("Luke");
            academy.DescribeEvent("Luke", "How is everything going?");
            academy.AddMessage("Hello threre I have started to write on share journal");
        }
    }
}
