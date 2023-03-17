using System;
using System.Collections.Generic;

namespace Library_For_Borrowing
{
    public abstract class LibraryItem
    {
        private int numberOfCopies;

        public int NumberOfCopies
        {
            get => numberOfCopies;
            set => numberOfCopies = value;
        }

        public abstract void Display();
    }

    public class Book : LibraryItem
    {
        private string author;
        
        private string title;

        public Book(string author, string title, int numberOfCopies)
        {
            this.author = author;
            this.title = title;
            NumberOfCopies = numberOfCopies;
        }

        public override void Display()
        {
            Console.WriteLine($"\nBook ----- ");
            Console.WriteLine($" Author: {author}");
            Console.WriteLine($" Title: {title}");
            Console.WriteLine($" # Copies: {NumberOfCopies}");
        }
    }

    public class Video : LibraryItem
    {
        private string director;

        private string title;

        private int playTime;

        public Video(string director, string title, int numberOfCopies, int playTime)
        {
            this.director = director;
            this.title = title;
            NumberOfCopies = numberOfCopies;
            this.playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine($" Director: {director}");
            Console.WriteLine($" Title: {title}");
            Console.WriteLine($" # Copies: {NumberOfCopies}");
            Console.WriteLine($" Playtime: \n {playTime}");
        }
    }

    public abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }

    public class BorrowableItem : Decorator
    {
        protected readonly List<string> borrowers = new List<string>();

        public BorrowableItem(LibraryItem libraryItem)
            : base(libraryItem)
        {

        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumberOfCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumberOfCopies++;
        }

        public override void Display()
        {
            base.Display();

            foreach (string borrower in borrowers)
            {
                Console.WriteLine($" borrower: {borrower}");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            Console.WriteLine("\nMaking videos borrowable: ");

            BorrowableItem borrowableVideo = new BorrowableItem(video);
            borrowableVideo.BorrowItem("Customer #1");
            borrowableVideo.BorrowItem("Customer #2");

            borrowableVideo.Display();

            Console.ReadKey();
        }
    }
}
