using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Handle_Objects
{
    public class HandleCurrentBook
    {
        private static List<BookOB> CurrentBook = new List<BookOB>();
        public static List<BookOB> GetCurrentBooks() { return CurrentBook; }

        List<BookOB> book = HandleAllBooks.GetBooks();
        public void CreateCurrentBookObject(int Id)
        {
            CurrentBook.Clear();
            BookOB newBook = new BookOB(Id, book[Id - 1].TitleOb, book[Id - 1].GenreOb, book[Id - 1].AuthorOb, book[Id - 1].ISBMOb, book[Id - 1].CopysOb, book[Id - 1].BorrowedOb, book[Id - 1].ReservedOb);
            CurrentBook.Add(newBook);

        }
        public static void ClearCurrentBook()
        {
            CurrentBook.Clear();
        }
    }
}
