using Bibliotek.Handle_Objects;
using Bibliotek.users;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bibliotek
{
    public class HandleAllBooks
    {
        private static List<BookOB> book = new List<BookOB>();
        public static List<BookOB> GetBooks() { return book; }

        static string BookPath = Resources_Path.BooksPath;
        public void CreateAllBooksObjects()
        {
            string[] BookArray = Resources_Arrays.BookArray;
            book.Clear();
            for (int i = 0; i < BookArray.Length; i++)
            {
                string BookDB = BookArray[i];
                string[] BookToSplit = BookDB.Split(",");
                for (int j = 5; j < 7; j++) { if (BookToSplit[j] == "") { BookToSplit[j] = "0"; } }
                BookOB newBook = new(i+1, BookToSplit[1], BookToSplit[2], BookToSplit[3], BookToSplit[4], int.Parse(BookToSplit[5]), int.Parse(BookToSplit[6]), 
                    int.Parse(BookToSplit[7]));
                book.Add(newBook);
            }       
        }
        public void AddOneBook(string Title, string Genre, string Author, string ISBM, int Copys, int Booked, int Reserve)
        {
            BookOB newBook = new(book.Count+1, Title, Genre, Author, ISBM, Copys, Booked, Reserve);
            book.Add(newBook);
        }
        public static void ClearBookList()
        {
            book.Clear();
        }
        public static List<BookOB> FindBook(string request)
        {
            var textLowerCase = request.ToLower();
            int maxDistance = 2;
            var result = new List<BookOB>();

            foreach (var books in book)
            {
                var titleDistance = LevenshteinDistance.GetDistance(books.TitleOb.ToLower(), textLowerCase);
                var authorDistance = LevenshteinDistance.GetDistance(books.AuthorOb.ToLower(), textLowerCase);
                var genreDistance = LevenshteinDistance.GetDistance(books.GenreOb.ToLower(), textLowerCase);
                var ISBMDistance = LevenshteinDistance.GetDistance(books.ISBMOb.ToLower(), textLowerCase);

                if (titleDistance <= maxDistance || authorDistance <= maxDistance || genreDistance <= maxDistance || ISBMDistance <= maxDistance)
                {
                    result.Add(books);
                }
            }

            return result;
        }
        public static void UpdateDocument()
        {
            List<string> BookOBToString = new List<string>();
            for (int i = 0; i < book.Count; i++)
            {
                string BookOBToStrings = book[i].IdOb + "," + book[i].TitleOb + "," + book[i].GenreOb + "," + book[i].AuthorOb + "," + book[i].ISBMOb + "," + 
                    book[i].CopysOb + "," + book[i].BorrowedOb + "," + book[i].ReservedOb;
                BookOBToString.Add(BookOBToStrings);
            }
            File.WriteAllLines(BookPath, BookOBToString);
        }
        public static void UpdateOneBook(int position, string Title, string Genre, string Author, string ISBM, int Copys, int Booked, int Reserve)
        {
            book[position].IdOb = position + 1;
            book[position].TitleOb = Title;
            book[position].GenreOb = Genre;
            book[position].AuthorOb = Author;
            book[position].ISBMOb = ISBM;
            book[position].CopysOb = Copys;
            book[position].BorrowedOb = Booked;
            book[position].ReservedOb = Reserve;
        }
        public void ClearOneBook(int id)
        {
            book.RemoveAt(id);
            UpdateDocument();
            CreateAllBooksObjects();
        }
    }







    public class HandleBorrowBook
    {
        private static List<BorrowedBook> borrowedbook = new List<BorrowedBook>();
        public static List<BorrowedBook> GetBorrowedBooks() { return borrowedbook; }
        static string BorrowedBookPath = Resources_Path.BorrowPath;
        public void CreateAllBorrowBooks()
        {
            string[] BorrowedBooksArray = Resources_Arrays.BorrowArray;
            for (int i = 0; i < BorrowedBooksArray.Length; i++)
            {
                string Stringforspliting = BorrowedBooksArray[i];
                string[] CurrentBook = Stringforspliting.Split(",");
                BorrowedBook NewBorrowedBook = new(CurrentBook[0], CurrentBook[1]);
                borrowedbook.Add(NewBorrowedBook);
            }
        }
        public static void UpdateDocument()
        {
            List<string> BorrowedBookOBToString = new List<string>();
            for (int i = 0; i < borrowedbook.Count; i++)
            {
                string newBook = borrowedbook[i].UserSsn + "," + borrowedbook[i].ISBM;
                BorrowedBookOBToString.Add(newBook);
            }
            File.WriteAllLines(BorrowedBookPath, BorrowedBookOBToString);
        }
        public void AddOneBorrowedBook(string UserSsn, string ISBM)
        {
            BorrowedBook newBorrowedBook = new(UserSsn, ISBM);
            borrowedbook.Add(newBorrowedBook);
        }
        public static void ClearList()
        {
            borrowedbook.Clear();
        }
        public static void UpdateOneObject(int Position, string NewUserSsn, string NewISBM)
        {
            borrowedbook[Position].UserSsn = NewUserSsn;
            borrowedbook[Position].ISBM = NewISBM;
        }
        public static void RemoveOneObject(int Position)
        {
            borrowedbook.RemoveAt(Position);
            
        }

    }




    class HandleReservedBook
    {
        private static List<Reserved> reservedbooks = new List<Reserved>();
        public static List<Reserved> GetReservedBooks() { return reservedbooks; }
        static string ReservedBooksPath = Resources_Path.ReservedPath;
        public void CreateAllReservedBooks()
        {
            string[] ReservedBooksArray = Resources_Arrays.ReservedArray;
            for (int i = 0; i < ReservedBooksArray.Length; i++)
            {
                string Stringforspliting = ReservedBooksArray[i];
                string[] CurrentBook = Stringforspliting.Split(",");
                Reserved NewBorrowedBook = new(CurrentBook[0], CurrentBook[1], Convert.ToInt16(CurrentBook[2]));
                reservedbooks.Add(NewBorrowedBook);
            }
        }
        public static void UpdateDocument()
        {
            List<string> BorrowedBookOBToString = new List<string>();
            for (int i = 0; i < reservedbooks.Count; i++)
            {
                string newBook = reservedbooks[i].UserSsn + "," + reservedbooks[i].BookISBM + "," + reservedbooks[i].PlaceInQueue;
                BorrowedBookOBToString.Add(newBook);
            }
            File.WriteAllLines(ReservedBooksPath, BorrowedBookOBToString);
        }
        public void AddOneReservedBook(string UserSsn, string ISBM, int QueuePosition)
        {
            Reserved newReservedBook = new(UserSsn, ISBM, QueuePosition);
            reservedbooks.Add(newReservedBook);
        }
        public static void ClearList()
        {
            reservedbooks.Clear();
        }
        public static void UpdateOneObject(int Position, string NewUserSsn, string NewISBM, int NewQueuePosition)
        {
            reservedbooks[Position].UserSsn = NewUserSsn;
            reservedbooks[Position].BookISBM = NewISBM;
            reservedbooks[Position].PlaceInQueue = NewQueuePosition;
        }
        public static void RemoveOneObject(int Position)
        {
            reservedbooks.RemoveAt(Position);
        }
    }
}
