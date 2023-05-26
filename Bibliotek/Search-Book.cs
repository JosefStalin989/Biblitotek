using Bibliotek.Handle_Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class SearchBook
    {
        static List<UserOB> currentUser = HandleCurrentUser.GetCurrentUsers();
        public static void Search_Book()
        {
            Console.Clear();
            Console.WriteLine("What do you want search for? \n");
            Console.WriteLine("A: Author name?");
            Console.WriteLine("B: Genre?");
            Console.WriteLine("C: A Book's name?");
            Console.WriteLine("D: ISBM number? \n");
            string anwser = Console.ReadLine().ToLower();
            Console.Clear();
            if (anwser == null || anwser == "") { Convo.Error_null_Convo(); Search_Book(); }
            WhatToSearch(anwser);

        }
        internal static void WhatToSearch(string anwser)
        {
            if (anwser == "a")
            {
                Console.WriteLine("What term or number do you want to search for?");
                string request = Console.ReadLine();
                Console.Clear();
                var resultat = HandleAllBooks.FindBook(request);
                if (resultat == null) { ResultetIsNull(anwser); }
                Console.WriteLine("These books was found ");
                int position;
                for (position = 0; position < resultat.Count; position++)
                {
                    var book = resultat[position];
                    Console.WriteLine($"{book.TitleOb} by {book.AuthorOb}. \n");
                }
                WhatToDoWithResultat(resultat);
            }
            else if (anwser == "b")
            {
                Console.WriteLine("What term or number do you want to search for?");
                string request = Console.ReadLine();
                Console.Clear();
                var resultat = HandleAllBooks.FindBook(request);
                if (resultat == null) { ResultetIsNull(anwser); }
                Console.WriteLine("These books was found ");
                int position;
                for (position = 0; position < resultat.Count; position++)
                {
                    var book = resultat[position];
                    Console.WriteLine($"{book.TitleOb} by {book.AuthorOb}. \n");
                }
                WhatToDoWithResultat(resultat);
            }
            else if (anwser == "c")
            {
                Console.WriteLine("What term or number do you want to search for?");
                string request = Console.ReadLine();
                Console.Clear();
                var resultat = HandleAllBooks.FindBook(request);
                if (resultat == null) { ResultetIsNull(anwser); }
                Console.WriteLine("These books was found ");
                int position;
                for (position = 0; position < resultat.Count; position++)
                {
                    var book = resultat[position];
                    Console.WriteLine($"{book.TitleOb} by {book.AuthorOb}. \n");
                }
                WhatToDoWithResultat(resultat);
            }
            else if (anwser == "d")
            {
                Console.WriteLine("What term or number do you want to search for?");
                string request = Console.ReadLine();
                Console.Clear();
                var resultat = HandleAllBooks.FindBook(request);
                if (resultat == null) { ResultetIsNull(anwser); }
                Console.WriteLine("These books was found ");
                int position;
                for (position = 0; position < resultat.Count; position++)
                {
                    var book = resultat[position];
                    Console.WriteLine($"{resultat[position].TitleOb} by {resultat[position].AuthorOb}. \n");
                }
                WhatToDoWithResultat(resultat);
            }
            else
            {
                Convo.Error_null_Convo();
                Search_Book();
            }
        }
        internal static void ResultetIsNull(string anwser)
        {
            Convo.Error_Not_Found_Convo();
            anwser = Console.ReadLine().ToLower();
            Console.Clear();
            if (anwser == "a") { WhatToSearch(anwser); }
            else if (anwser == "b") { Search_Book(); }
            else if (anwser == "c") { Reroute.Rerouts(Reroute_Location.user); }
        }

        internal static void WhatToDoWithResultat(List<BookOB> Results)
        {
            var Borrow_Reserve = new Borrow_Reserve();
            var HandleCurrentBook = new HandleCurrentBook();
            Console.WriteLine("How do you want to proceed");
            if (currentUser != null) 
            {
                Console.WriteLine("A: Borrow one of the books");
                Console.WriteLine("B: Search for another book");
                Console.WriteLine("C: Back to the main menu");
                string answer = Console.ReadLine().ToLower();
                Console.Clear();
                if (answer == null || answer == "") { Convo.Error_null_Convo(); WhatToDoWithResultat(Results); }
                if (answer == "a")
                {
                    Console.Clear();
                    for (int i = 0; i < Results.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Results[i].TitleOb} by {Results[i].AuthorOb}. \n");
                    }
                    Console.WriteLine("Which of this books do you want to borrow");
                    int PositionWithinResults = int.Parse(Console.ReadLine());
                    int IdOfBook = Results[PositionWithinResults - 1].IdOb;
                    HandleCurrentBook.CreateCurrentBookObject(IdOfBook);
                    Console.Clear();
                    Borrow_Reserve.BorrowBook();
                }
                else if (answer == "b")
                {
                    Console.Clear();
                    Search_Book();
                }
                else if (answer == "c")
                {
                    Console.Clear();
                    User.NormalUser();
                }
                else
                {
                    Convo.Error_Convo();
                    Console.ReadKey();
                    WhatToDoWithResultat(Results);
                }
            }
            else
            {
                for (int i = 0; i < Results.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Results[i].TitleOb} by {Results[i].AuthorOb}. \n");
                }
                Console.WriteLine("Which of this books do you want to do something with");
                int PositionOfCurrentBook = int.Parse(Console.ReadLine());
                int IdOfCurrentBook = Results[PositionOfCurrentBook - 1].IdOb;
                Console.Clear();
                Console.WriteLine("What do you want do to with the book");
                Console.WriteLine("A: Search for another book");
                Console.WriteLine("B: Remove this book");
                Console.WriteLine("C: Edit this book");
                Console.WriteLine("D: Back to the main menu");
                string answer = Console.ReadLine().ToLower();
                switch (answer)
                {
                    case "a":
                        Search_Book();
                        break;
                    case "b":
                        var HandleAllBooks = new HandleAllBooks();
                        HandleAllBooks.ClearOneBook(IdOfCurrentBook);
                        break;
                    case "c":
                        HandleCurrentBook.CreateCurrentBookObject(IdOfCurrentBook);
                        Request.updateBook();
                        break;
                    case "d":
                        HandleCurrentBook.ClearCurrentBook();
                        Admin.librarian();
                        break;
                    default:
                        Convo.Error_null_Convo(); 
                        WhatToDoWithResultat(Results);
                        break;
                }
            }
        }
    }
}
