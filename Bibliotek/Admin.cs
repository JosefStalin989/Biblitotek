using Bibliotek.Handle_Objects;
using Bibliotek.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    internal class Admin
    {
        public static void librarian()
        {
            
            Console.Clear();
            Console.WriteLine("Do you want to");
            Console.WriteLine("A: Do something with Books");
            Console.WriteLine("B: Do something with Users");
            Console.WriteLine("C: Exit the Program");
            string answer = Console.ReadLine().ToLower();
            Console.Clear();
            switch (answer)
            {
                case "a":
                    books_menu();
                    break;
                case "b":
                    users_menu();
                    break;
                case "c":
                    Environment.Exit(0);
                    break;
                default:
                    Convo.Error_Convo();
                    librarian();
                    break;
            }
        }

        private static void books_menu()
        {
            Console.Clear();
            Console.WriteLine("What do you want to do \n");
            Console.WriteLine("A: Add a Book ");
            Console.WriteLine("B: Remove a Book ");
            Console.WriteLine("C: Search for a Book ");
            Console.WriteLine("D: List of all Books");
            Console.WriteLine("E: Edit a book");
            Console.WriteLine("F: Exit the Program \n");
            switch (Console.ReadLine().ToLower())
            {
                case "a":
                    Request.addBook();
                    break;
                case "b":
                    Request.removeBook();
                    break;
                case "c":
                    SearchBook.Search_Book();
                    break;
                case "d":
                    Request.listOfBooks();
                    break;
                case "e":
                    Request.updateBook();
                    break;
                case "f":
                    Environment.Exit(0);
                    break;
                default:
                    Convo.Error_Convo();
                    books_menu();
                    break;
            }
        }

        private static void users_menu()
        {

        }

    }
}
