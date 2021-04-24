//libs 
using System;
using System.Collections.Generic;
using core.book;
using core.author;

//working namespace

namespace core.library
{
    //main class for library
    public class Library
    {
        //variables
        public List<Book> books = new List<Book>();
        public List<Author> authors = new List<Author>();
        private int authorIdGenerator = 0;
        private int bookIdGenerator = 0;
        

        //constructor
        public Library()
        {
        }
        //methods

        //method for make pause
        private void Pause()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // show books
        public void ShowBooks()
        {
            //variable for stop interface
            bool intefaceWorking = true;

            //loop
            while (intefaceWorking)
            {
                //clean console
                Console.Clear();

                // welcome message
                Console.WriteLine("Show books menu");
                Console.WriteLine("Library have {0} books", books.Count);

                // loop for showing list of books
                for (int index = 0; index < books.Count; index++)
                {
                    //define book
                    Book book = books[index];
                    //print to console
                    Console.WriteLine("{0}: {1}  {2} pages | author: {3} | {4} | id > {5}", index + 1, book.name, book.pages,book.author.name ,book.isAvailable ? "Available" : "Not available", book.GetId());
                }

                // print controll message
                Console.WriteLine("Press i to insert book number for select book.");
                Console.WriteLine("Press ESC to return to the main menu.");

                // action process
                switch (Console.ReadKey().Key)
                {
                    // exit
                    case ConsoleKey.Escape:
                        intefaceWorking = false;
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
                        }

                        break;
                }
            }
        }

        // method for creating author 
        public void CreateAuthor()
        {
            // variable for loop
            bool isWorking = true;

            //start main loop
            while (isWorking)
            {
                // clean screen
                Console.Clear();

                //welcome message
                Console.WriteLine("Create author menu");
                Console.WriteLine("Press i to create author.");
                Console.WriteLine("Press ESC to return to the main menu.");

                // user key input
                ConsoleKey userKeyInput = Console.ReadKey().Key;

                // action process
                switch (userKeyInput)
                {
                    //exit
                    case ConsoleKey.Escape:
                        isWorking = false;
                        break;

                    // create author menu
                    case ConsoleKey.I:

                        //clean console
                        Console.Clear();

                        //getting data from user and string processing
                        Console.Write("Input Authors name: ");
                        string authorName = Console.ReadLine().Trim();

                        //if author not created, create author
                        if (authors.Find(item => item.name.ToLower().Contains(authorName.ToLower())) == null)
                        {
                            //create author and add to list
                            authors.Add(new Author(authorName, authorIdGenerator++, authors, books));
                            Console.WriteLine("Author successful created");
                        }
                        else
                        {
                            Console.WriteLine("The author has already been created. Try another name.");
                        }

                        // pause
                        Pause();
                        break;
                }
            }
        }

        // method for show all existing authors
        public void ShowAuthors()
        {
            //variable for stop interface
            bool intefaceWorking = true;

            //loop
            while (intefaceWorking)
            {
                //clean console
                Console.Clear();

                // print main message
                Console.WriteLine("Show authors menu");
                Console.WriteLine("Available {0} authors", authors.Count);

                //loop for printing all authors
                foreach (Author author in authors)
                {
                    Console.WriteLine("{0}: books {1}", author.name, author.books.Count);
                }

                // print controll message
                Console.WriteLine("Press i to insert author name for select author.");
                Console.WriteLine("Press ESC to return to the main menu.");

                //get data from user
                ConsoleKey userKey = Console.ReadKey().Key;

                // action process

                switch (userKey)
                {
                    // exit
                    case ConsoleKey.Escape:
                        intefaceWorking = false;
                        break;

                    // input number
                    case ConsoleKey.I:
                        // clean screen
                        Console.Clear();

                        //message
                        Console.Write("Author name: ");

                        //get author name from user
                        string authorName = Console.ReadLine();

                        //search after author
                        Author someAuthor = authors.Find(item => item.name.ToLower().Contains(authorName.ToLower()));

                        // if author not available
                        if (someAuthor == null)
                        {
                            Console.WriteLine("Author not found");
                            Console.ReadKey();
                        }
                        //start interface
                        else
                        {
                            someAuthor.Interface();
                        }

                        break;
                }
            }
        }

        // method for create book
        public void CreateBook()
        {
            // variable for stom menu
            bool isWorking = true;

            // main loop
            while (isWorking)
            {
                //Clean console window
                Console.Clear();

                //welcome message
                Console.WriteLine("Create book menu");
                Console.WriteLine("Press i to create book.");
                Console.WriteLine("Press ESC to return to the main menu.");

                // user key input
                ConsoleKey userKeyInput = Console.ReadKey().Key;

                // action process
                switch (userKeyInput)
                {
                    //exit
                    case ConsoleKey.Escape:
                        isWorking = false;
                        break;

                    // input book menu
                    case ConsoleKey.I:

                        //clean screen
                        Console.Clear();

                        // get book name
                        Console.Write("Book name: ");
                        string bookName = Console.ReadLine().Trim();

                        // get author name
                        Console.Write("Author name: ");
                        string authorName = Console.ReadLine().Trim();

                        // get pages (int)
                        try
                        {
                            //get pages
                            Console.Write("Pages (Must by number): ");
                            int pages = int.Parse(Console.ReadLine());

                            //search after author
                            Author someAuthor = authors.Find(item => item.name.ToLower().Contains(authorName.ToLower()));

                            //if author not created, create author
                            if (someAuthor == null)
                            {
                                //create author
                                someAuthor = new Author(authorName, authorIdGenerator++, authors, books);
                                //add to list
                                authors.Add(someAuthor);
                            }

                            //create book
                            Book someBook = new Book(bookName, pages, someAuthor, bookIdGenerator++, books);

                            // add book to author
                            someAuthor.books.Add(someBook);

                            // add book to lib
                            books.Add(someBook);

                            // message
                            Console.WriteLine("Book successful added!");

                        }
                        catch
                        {
                            Console.WriteLine("Incorrect input");
                        }

                        Pause();
                        break;
                }

            }
        }
    }
}