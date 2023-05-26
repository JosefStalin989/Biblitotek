using Bibliotek.Handle_Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Return
    {
        List<BorrowedBook> borrowedBooks = HandleBorrowBook.GetBorrowedBooks();
        List<UserOB> currentUserList = HandleCurrentUser.GetCurrentUsers();
        List<BookOB> allBooksList = HandleAllBooks.GetBooks();
        public void ReturnBook()
        {
            List<BorrowedBook> books = new List<BorrowedBook>();
            for (int i = 0; i < borrowedBooks.Count; i++)
            {
                if (borrowedBooks[i].UserSsn == currentUserList[0].SsnUserOb)
                {
                    books.Add(borrowedBooks[i]);
                }
            }
            if (books.Count <= 0)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine("You have not borrowed any books");
                Console.WriteLine("Press any key to coninue");
                Console.ReadKey();
                Reroute.Rerouts(Reroute_Location.user);
                
            }
            int counter = 1;
            for (int i = 0; i < books.Count; i++)
            {
                for (int j = 0; j < allBooksList.Count; j++)
                {
                    if (books[i].ISBM == allBooksList[j].ISBMOb)
                    {
                        
                        Console.WriteLine(counter + ". " + allBooksList[j].TitleOb);
                        counter++;
                    }
                }
            }

            Console.WriteLine("What book do you want to return \n");
            int answer = int.Parse(Console.ReadLine());
            Console.Clear();
            for (int i = 0; i < borrowedBooks.Count; i++)
            {   
                if (borrowedBooks[i].ISBM == books[answer-1].ISBM && borrowedBooks[i].UserSsn == books[answer-1].UserSsn)
                { HandleBorrowBook.RemoveOneObject(i); HandleBorrowBook.UpdateDocument(); }
            }
            for (int i = 0; i < books.Count; i++) { if (books[i].ISBM != books[answer - 1].ISBM) { books.Remove(books[i]); } }
            for (int i = 0; i < allBooksList.Count; i++)
            {
                if (allBooksList[i].ISBMOb == books[0].ISBM) {
                    HandleAllBooks.UpdateOneBook(allBooksList[i - 1].IdOb, allBooksList[i].TitleOb, allBooksList[i].GenreOb,
                        allBooksList[i].AuthorOb, allBooksList[i].ISBMOb, allBooksList[i].CopysOb + 1, allBooksList[i].BorrowedOb - 1, allBooksList[i].ReservedOb);
                    HandleAllBooks.UpdateDocument();
                }
            }
            
            WhatToDo();
        }
        internal static void WhatToDo()
        {
            var Return = new Return();
            Console.WriteLine("Where do you want to go? \n");
            Console.WriteLine("A: Return another book");
            Console.WriteLine("B: Go back to the menu");
            Console.WriteLine("C: Exit the program \n");
            string answer = Console.ReadLine().ToLower();
            Console.Clear();
            switch (answer)
            {
                case "a":
                    Return.ReturnBook();
                    break;
                case "b":
                    Reroute.Rerouts(Reroute_Location.user);
                    break;
                case "c":
                    Environment.Exit(0);
                    break;
                default:
                    Convo.Error_null_Convo();
                    WhatToDo();
                    break;
            }

        }
    }
}
