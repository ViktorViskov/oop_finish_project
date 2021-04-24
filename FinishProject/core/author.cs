//libs 
using System;
using System.Collections.Generic;
using core.book;

//working namespace

namespace core.author
{
    //class for one author
    public class Author
    {
        //variables
        public string name;
        public List<Book> books = new List<Book>();
        private int id;
        private List<Author> libAuthors;
        private List<Book> libBooks;

        //constructor
        public Author(string name, int id, List<Author> libAuthors, List<Book> libBooks)
        {
            this.name = name;
            this.id = id;
            this.libAuthors = libAuthors;
            this.libBooks = libBooks;
        }

        //methods

        // method for show interface in author class
        public void Interface()
        {
            //variable for stop interface
            bool intefaceWorking = true;

            //loop
            while (intefaceWorking)
            {            
                //clean console
                Console.Clear();

                //welcome message
                Console.WriteLine("Author menu");
                Console.WriteLine("Press ESC to return to the main menu.");
                Console.WriteLine("d > delete author | i > insert book number for select book.");

                //show books
                ShowBooks();

                //get data from user
                ConsoleKey userKey = Console.ReadKey().Key;

                // action process
                switch (userKey)
                {
                    // exit
                    case ConsoleKey.Escape:
                        intefaceWorking = false;
                        break;

                    // delete author
                    case ConsoleKey.D:

                        //clean console
                        Console.Clear();

                        // ask message
                        Console.WriteLine("You really want to delete author with all his/her books?");
                        Console.Write("Y/N: ");

                        //get user input
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            //delete all authors books from library
                            foreach(Book authorBook in books)
                            {
                                //delete from libBooks
                                libBooks.Remove(authorBook);
                            }

                            //delete author from library
                            libAuthors.Remove(this);

                            // stop interface loop
                            intefaceWorking = false;

                            // status message
                            Console.Clear();
                            Console.WriteLine("Deleting complete");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }


                        break;

                    // input number
                    case ConsoleKey.I:

                        // try to convert user input to uint
                        try
                        {
                            //clean screen
                            Console.Clear();
                            // message
                            Console.Write("Book number: ");
                            //conveting value
                            int bookNumber = int.Parse(Console.ReadLine()) - 1;

                            //open book interface
                            books[bookNumber].Interface();
                        }
                        //catch all errors
                        catch
                        {
                            Console.WriteLine("Incorect input.");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                            return;
                        }

                        break;

                    // incorrect key
                    default:

                        // print error messages
                        Console.WriteLine(" < Incorect Key.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // method for getting author id
        public int GetAuthorId()
        {
            return id;
        }

        // show books
        private void ShowBooks()
        {
            // welcome message
            Console.WriteLine("{0} have {1} books", name, books.Count);

            // loop for showing list of books
            for (int index = 0; index < books.Count; index++)
            {
                //define book
                Book book = books[index];
                //print to console
                Console.WriteLine("{0}: {1}  {2} pages | {3} | id > {4}", index + 1, book.name, book.pages, book.isAvailable ? "Available" : "Not available", book.GetId());
            }
        }
    }
}