//libs 

//working namespace

using System;
using System.Collections.Generic;
using core.author;

namespace core.book
{
    //main class for one book
    public class Book
    {
        //variables
        public string name;
        public int pages;
        public Author author;
        public bool isAvailable = true;
        private int id;
        private List<Book> libBooks;

        //constructor
        public Book(string name, int pages, Author author, int id, List<Book> libBooks)
        {
            this.name = name;
            this.pages = pages;
            this.author = author;
            this.id = id;
            this.libBooks = libBooks;
        }
        //methods

        // Book interface
        public void Interface ()
        {
            // variable for main loop interface
            bool isWorking = true;

            //main loop
            while (isWorking)
            {
                //clean console
                Console.Clear();

                //welcome message
                Console.WriteLine("Book menu");
                Console.WriteLine("ESC > exit | t > take book  | b > back book | d > delete book");
                Console.WriteLine("Book info:");
                Console.WriteLine("{0}  {1} pages | author: {2} | {3} | id > {4}",name, pages, author.name, isAvailable ? "Available" : "Not available", id);

                // action process
                switch (Console.ReadKey().Key)
                {
                    //exit
                    case ConsoleKey.Escape:
                        isWorking = false;
                        break;

                    //take book
                    case ConsoleKey.T:

                        //console clean
                        Console.Clear();

                        if (isAvailable)
                        {
                            //change book status
                            isAvailable = false;

                            //message
                            Console.WriteLine("You taked book");
                        }
                        else
                        {
                            Console.WriteLine("Book not available Please try again later");
                        }

                        // pause message
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();

                        break;

                    //back book
                    case ConsoleKey.B:

                        //console clean
                        Console.Clear();

                        //change book status
                        isAvailable = true;

                        //status message
                        Console.WriteLine("You have successfully returned the book");

                        // pause message
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();

                        break;

                    //delete book
                    case ConsoleKey.D:

                        //clean console
                        Console.Clear();

                        // ask message
                        Console.WriteLine("You really want to delete book?");
                        Console.Write("Y/N: ");

                        //get user input
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            //delete book from author
                            author.books.Remove(this);

                            //delete book from library
                            libBooks.Remove(this);

                            // stop interface loop
                            isWorking = false;

                            // status message
                            Console.Clear();
                            Console.WriteLine("Deleting complete");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        } 

        //get id 
        public int GetId()
        {
            return id;
        }

    }
}