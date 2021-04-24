//libs 
using core.author;
//working namespace
using System;
using core.library;
using core.book;

namespace core.controler
{
    // class controller. User can controlling app using this class
    public class Controller
    {
        //variables
        private bool isRuning = true;

        //library main class
        private Library lib = new Library();

        //constructor
        public Controller()
        {
            //start main loop
            Start();
        }

        //methods

        //method for start main apps loop
        private void Start()
        {
            //start main loop
            while (isRuning)
            {
                // show controll
                ShowControll();

                //take user action
                ConsoleKey consoleKey = Console.ReadKey().Key;

                switch (consoleKey)
                {
                    // "esc" close app
                    case ConsoleKey.Escape:
                        //clean console
                        Console.Clear();

                        //message
                        Console.WriteLine("You really want to exit?");
                        Console.Write("Y/N: ");

                        //get user key
                        ConsoleKey pressedKey = Console.ReadKey().Key;

                        //check key
                        if (pressedKey == ConsoleKey.Y)
                        {
                            isRuning = false;
                        }

                        break;

                    // "a" add author
                    case ConsoleKey.A:
                        lib.CreateAuthor();
                        break;

                    // "b" add book
                    case ConsoleKey.B:
                        lib.CreateBook();
                        break;

                    // "c" show all authors
                    case ConsoleKey.C:
                        lib.ShowAuthors();
                        break;

                    // "l" show all books
                    case ConsoleKey.L:
                        lib.ShowBooks();
                        break;
                }
            }
        }

        //method for print controll map message
        private void ShowControll()
        {
            Console.Clear();
            Console.WriteLine("Main menu");
            Console.WriteLine("Library system. V. 1.0");
            Console.WriteLine("Press 'ESC' to exit");
            Console.WriteLine("a > add author       | b > add book         ");
            Console.WriteLine("c > show all authors | l > show all books ");
        }
    }
}