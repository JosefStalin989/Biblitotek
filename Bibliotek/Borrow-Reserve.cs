using Bibliotek.Handle_Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Borrow_Reserve
    {
        static List<BorrowedBook> BorrowedBooksList = HandleBorrowBook.GetBorrowedBooks();
        static List<BookOB> CurrentBookList = HandleCurrentBook.GetCurrentBooks();
        static List<UserOB> CurrentUserList = HandleCurrentUser.GetCurrentUsers();
        static List<Reserved> ReservedBooksList = HandleReservedBook.GetReservedBooks();


        string BookPath = Resources_Path.BooksPath;
        string BorrowBookPath = Resources_Path.BorrowPath;
        string ReserveBookPath = Resources_Path.ReservedPath;
        static string[] BorrowArray = Resources_Arrays.BorrowArray;
        static string[] ReservedArray = Resources_Arrays.ReservedArray;
        public static void BorrowReserveMenu()
        {
            Console.WriteLine("What do you want to search for to find the book \n");
            Console.WriteLine("A: Author name? ");
            Console.WriteLine("B: Genre? ");
            Console.WriteLine("C: A Book's name? ");
            Console.WriteLine("D: ISBM number? \n");
            string answer = Console.ReadLine().ToLower();
            Console.Clear();
            SearchBook.WhatToSearch(answer);
        }
        internal void BorrowBook()
        {
            if (CurrentBookList[0].CopysOb == 0) { ReserveBook(); }
            string newBorrow;
            string CurrentUser = CurrentUserList[0].SsnUserOb;
            if (BorrowedBooksList.Count == 0)
            {
                newBorrow = CurrentUser + "," + CurrentBookList[0].ISBMOb;
                HandleAllBooks.UpdateOneBook(CurrentBookList[0].IdOb - 1, CurrentBookList[0].TitleOb, CurrentBookList[0].GenreOb, CurrentBookList[0].AuthorOb,
                    CurrentBookList[0].ISBMOb, CurrentBookList[0].CopysOb - 1, CurrentBookList[0].BorrowedOb + 1, CurrentBookList[0].ReservedOb);
                HandleAllBooks.UpdateDocument();
                File.AppendAllText(BorrowBookPath, newBorrow + Environment.NewLine);
                WhatToDo("a");
            }
            for (int i = 0; i < BorrowArray.Length; i++)
            {
                if (BorrowedBooksList[i].UserSsn == CurrentUserList[0].SsnUserOb)
                {
                    string Borrowed = BorrowArray[i];
                    string[] BorrowedSplit = Borrowed.Split(',');
                    for (int j = 1; j < BorrowedSplit.Length; j++)
                    {
                        if (BorrowedSplit[j] == CurrentBookList[0].ISBMOb)
                        {
                            Console.WriteLine("You can not borrow the same book\n");
                            Console.WriteLine("Please search again");
                            Console.ReadKey();
                            Console.Clear();
                            BorrowReserveMenu();
                        }
                    }
                    HandleAllBooks.UpdateOneBook(CurrentBookList[0].IdOb - 1, CurrentBookList[0].TitleOb, CurrentBookList[0].GenreOb, CurrentBookList[0].AuthorOb,
                        CurrentBookList[0].ISBMOb, CurrentBookList[0].CopysOb - 1, CurrentBookList[0].BorrowedOb + 1, CurrentBookList[0].ReservedOb);
                    HandleAllBooks.UpdateDocument();
                }
                if (BorrowedBooksList[i].UserSsn == CurrentUserList[0].SsnUserOb)
                {
                    if (BorrowedBooksList[i].ISBM != CurrentBookList[0].ISBMOb)
                    {
                        var HandleBorrowedBook = new HandleBorrowBook();
                        HandleBorrowedBook.AddOneBorrowedBook(CurrentUserList[0].SsnUserOb, CurrentBookList[0].ISBMOb);
                        HandleBorrowBook.UpdateDocument();
                        WhatToDo("a");
                    }
                }
                else
                {
                    newBorrow = CurrentUser + "," + CurrentBookList[0].ISBMOb;
                    HandleAllBooks.UpdateOneBook(CurrentBookList[0].IdOb - 1, CurrentBookList[0].TitleOb, CurrentBookList[0].GenreOb, CurrentBookList[0].AuthorOb,
                        CurrentBookList[0].ISBMOb, CurrentBookList[0].CopysOb - 1, CurrentBookList[0].BorrowedOb + 1, CurrentBookList[0].ReservedOb);
                    HandleAllBooks.UpdateDocument();
                    File.AppendAllText(BorrowBookPath, newBorrow + Environment.NewLine);
                    WhatToDo("a");
                }
            }
        }
        internal void ReserveBook()
        {
            Console.WriteLine("We did not have any copyes!\n");
            Console.WriteLine("Do you want to reserve the book? Y/N \n");
            string answer = Console.ReadLine().ToLower();
            Console.Clear();
            if (answer == "y")
            {
                string newReservedBook;
                string CurrentUser = CurrentUserList[0].SsnUserOb;
                int QueuePosition = 1;
                if (ReservedBooksList.Count == 0)
                {
                    newReservedBook = CurrentUser + "," + CurrentBookList[0].ISBMOb + "," + QueuePosition;
                    HandleAllBooks.UpdateOneBook(CurrentBookList[0].IdOb - 1, CurrentBookList[0].TitleOb, CurrentBookList[0].GenreOb, CurrentBookList[0].AuthorOb,
                        CurrentBookList[0].ISBMOb, CurrentBookList[0].CopysOb, CurrentBookList[0].BorrowedOb, CurrentBookList[0].ReservedOb + 1);
                    HandleAllBooks.UpdateDocument();
                    File.AppendAllText(ReserveBookPath, newReservedBook + Environment.NewLine);
                    WhatToDo("b");
                }
                for(int i = 0; i < ReservedBooksList.Count; i++)
                {
                    if (ReservedBooksList[i].UserSsn == CurrentUser && ReservedBooksList[i].BookISBM == CurrentBookList[i].ISBMOb)
                    {
                        Console.WriteLine("You can not borrow the same book\n");
                        Console.WriteLine("Please search again");
                        Console.ReadKey();
                        Console.Clear();
                        BorrowReserveMenu();
                    }
                }
                HandleAllBooks.UpdateOneBook(CurrentBookList[0].IdOb - 1, CurrentBookList[0].TitleOb, CurrentBookList[0].GenreOb, CurrentBookList[0].AuthorOb,
                    CurrentBookList[0].ISBMOb, CurrentBookList[0].CopysOb, CurrentBookList[0].BorrowedOb, CurrentBookList[0].ReservedOb + 1);
                HandleAllBooks.UpdateDocument();
                for (int i = 0; i < ReservedBooksList.Count; i++)
                {
                    if (ReservedBooksList[i].BookISBM == CurrentBookList[i].ISBMOb)
                    {
                        if (QueuePosition > CurrentBookList[i].BorrowedOb)
                        {
                            Console.WriteLine("Too many have reserved this book");
                            WhatToDo("c");
                        }
                        QueuePosition++;
                    }
                }
                var HandleReservedBook = new HandleReservedBook();
                HandleReservedBook.AddOneReservedBook(CurrentUser, CurrentBookList[0].ISBMOb, QueuePosition);
                HandleReservedBook.UpdateDocument();
                WhatToDo("b");
            }
            else if (answer == "n")
            {
                WhatToDo("c");
            }
            else
            {

            }
        }
        internal static void WhatToDo(string WhereFrom)
        {
            Convo.Success_Convo();
            if (WhereFrom == "a")
            {
                Console.WriteLine("Where do you want to go? \n");
                Console.WriteLine("A: Borrow another book");
                Console.WriteLine("B: Go back to the menu");
                Console.WriteLine("C: Exit the program");
                string answer = Console.ReadLine().ToLower();
                Console.Clear();
                switch (answer)
                {
                    case "a":
                        BorrowReserveMenu();
                        break;
                    case "b":
                        Reroute.Rerouts(Reroute_Location.user);
                        break;
                    case "c":
                        Environment.Exit(0);
                        break;
                    default:
                        Convo.Error_null_Convo();
                        WhatToDo(WhereFrom);
                        break;
                }
            }
            else if (WhereFrom == "b")
            {
                Console.WriteLine("After Reserved Book");
                Console.ReadKey();
            }
        }
    }
}
