using Bibliotek.Handle_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Request
    {
        static List<BookOB> CurrentBook = HandleCurrentBook.GetCurrentBooks();
        static List<BookOB> AllBooks = HandleAllBooks.GetBooks();
        static List<Reserved> AllReservedBooks = HandleReservedBook.GetReservedBooks();
        static List<BorrowedBook> AllBorrowedBooks = HandleBorrowBook.GetBorrowedBooks();
        static List<UserOB> AllUsers = HandleAllUsers.GetUsers();
        static List<UserOB> CurrentUser = HandleCurrentUser.GetCurrentUsers();
        public static void addBook()
        {
            Console.Clear();
            Console.WriteLine("What is the name of the book?");
            string newBookName = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < AllBooks.Count; i++)
            {
                if (newBookName == AllBooks[i].TitleOb)
                {
                    Convo.Error_FoundBook();
                    switch (Console.ReadLine().ToLower())
                    {
                        case "a":
                            addBook();
                            break;
                        case "b":
                            Reroute.Rerouts(Reroute_Location.admin);
                            break;
                        case "c":
                            Environment.Exit(0);
                            break;
                    }
                }
            }

            Console.WriteLine("What is the name of the author?");
            string newAuhterName = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < AllBooks.Count; i++)
            {
                if (newAuhterName == AllBooks[i].AuthorOb)
                {
                    Convo.Error_FoundBook();
                    switch (Console.ReadLine().ToLower())
                    {
                        case "a":
                            addBook();
                            break;
                        case "b":
                            Reroute.Rerouts(Reroute_Location.admin);
                            break;
                        case "c":
                            Environment.Exit(0);
                            break;
                    }
                }
            }

            Console.WriteLine("What is the Genre?");
            string newGenre = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < AllBooks.Count; i++)
            {
                if (newGenre == AllBooks[i].GenreOb)
                {
                    Convo.Error_FoundBook();
                    switch (Console.ReadLine().ToLower())
                    {
                        case "a":
                            addBook();
                            break;
                        case "b":
                            Reroute.Rerouts(Reroute_Location.admin);
                            break;
                        case "c":
                            Environment.Exit(0);
                            break;
                    }
                }
            }

            Console.WriteLine("What is the books ISBM?");
            string newISBM = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < AllBooks.Count; i++)
            {
                if (newISBM == AllBooks[i].ISBMOb)
                {
                    Convo.Error_FoundBook();
                    switch (Console.ReadLine().ToLower())
                    {
                        case "a":
                            addBook();
                            break;
                        case "b":
                            Reroute.Rerouts(Reroute_Location.admin);
                            break;
                        case "c":
                            Environment.Exit(0);
                            break;
                    }
                }
            }

            Console.WriteLine("How many copies are being added");
            int newCopys = int.Parse(Console.ReadLine());
            Console.Clear();

            for (int i = 0; i < AllBooks.Count; i++)
            {
                if (newCopys == AllBooks[i].CopysOb)
                {
                    Convo.Error_FoundBook();
                    switch (Console.ReadLine().ToLower())
                    {
                        case "a":
                            addBook();
                            break;
                        case "b":
                            Reroute.Rerouts(Reroute_Location.admin);
                            break;
                        case "c":
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            var HandleAllBooks = new HandleAllBooks();
            HandleAllBooks.AddOneBook(newBookName, newGenre, newAuhterName, newISBM, newCopys, 0, 0);
          

        }
        public static void addUser()
        {
            Console.Clear();
            Console.WriteLine("What is the name of the new users?");
            string newUserName = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (newUserName == AllUsers[i].NameUserOb)
                {
                    Convo.Error_FoundBook();
                    switch (Console.ReadLine().ToLower())
                    {
                        case "a":
                            addUser();
                            break;
                        case "b":
                            Reroute.Rerouts(Reroute_Location.admin);
                            break;
                        case "c":
                            Environment.Exit(0);
                            break;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("What is the ssn off the new user");
            string newSsn = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (newSsn == AllUsers[i].SsnUserOb)
                {
                    Convo.Error_FoundBook();
                    switch (Console.ReadLine().ToLower())
                    {
                        case "a":
                            addUser();
                            break;
                        case "b":
                            Reroute.Rerouts(Reroute_Location.admin);
                            break;
                        case "c":
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("What is the password");
            string newPassword = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (newPassword == AllUsers[i].PasswordUserOb)
                {
                    Convo.Error_FoundBook();
                    switch (Console.ReadLine().ToLower())
                    {
                        case "a":
                            addUser();
                            break;
                        case "b":
                            Reroute.Rerouts(Reroute_Location.admin);
                            break;
                        case "c":
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            var HandleAllUsers = new HandleAllUsers();
            HandleAllUsers.AddOneUser(newUserName, newSsn, newPassword);

        }
        public static void removeBook()
        {
            var HandleAllUsers = new HandleAllUsers();
            Console.Clear();
            Console.WriteLine("How do you want to find the book you what to remove?");
            Console.WriteLine("A: A list");
            Console.WriteLine("B: Search for the book");
            if (Console.ReadLine().ToLower() == "a")
            {
                listOfBooks();
                Console.WriteLine("What book do you want to remove");
                int IdOffTheRemovedBook = int.Parse(Console.ReadLine()) - 1;
                HandleAllUsers.ClearOneUser(IdOffTheRemovedBook);
            }
            else if (Console.ReadLine().ToLower() == "b")
            {
                SearchBook.Search_Book();
            }
            else
            {
                Convo.Error_Convo();
            }
        }
        public static void removeUser()
        {
            listOfUsers();
            Console.WriteLine("Which user do you want to remove?");
            int UserId = int.Parse(Console.ReadLine()) - 1;
            var HandleAllUsers = new HandleAllUsers();
            HandleAllUsers.ClearOneUser(UserId);
            Console.Clear();
            

        }
        public static void updateBook()
        {
            if (CurrentBook.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("How do you want to find the book you want to update");
                Console.WriteLine("A: Search for a book");
                Console.WriteLine("B: Get a list of all books");
                string answer = Console.ReadLine().ToLower();
                if (answer == "a")
                {
                    SearchBook.Search_Book();
                }
                else if (answer == "b")
                {
                    Console.Clear();
                    listOfBooks();
                    Console.WriteLine("What book do you want to change");
                    int NewCurrentBook = int.Parse(Console.ReadLine());
                    var HandleCurrentBook = new HandleCurrentBook();
                    HandleCurrentBook.CreateCurrentBookObject(NewCurrentBook);
                    Console.Clear();
                    updateBook();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("A: Title \n" + "B: Genre \n" + "C: Author \n" + "D: ISBM \n" + "E: How many borrowed books");
                Console.WriteLine("F: How many copys \n" + "G: How many reserved \n");
                string answer = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("What do you want to change it to");
                string NewChange = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "a":
                        HandleAllBooks.UpdateOneBook(CurrentBook[0].IdOb, NewChange, CurrentBook[0].GenreOb, CurrentBook[0].AuthorOb, CurrentBook[0].ISBMOb,
                            CurrentBook[0].BorrowedOb, CurrentBook[0].CopysOb, CurrentBook[0].ReservedOb);
                        break;
                    case "b":
                        HandleAllBooks.UpdateOneBook(CurrentBook[0].IdOb, CurrentBook[0].TitleOb, NewChange, CurrentBook[0].AuthorOb, CurrentBook[0].ISBMOb,
                            CurrentBook[0].BorrowedOb, CurrentBook[0].CopysOb, CurrentBook[0].ReservedOb);
                        break;
                    case "c":
                        HandleAllBooks.UpdateOneBook(CurrentBook[0].IdOb, CurrentBook[0].TitleOb, CurrentBook[0].GenreOb, NewChange, CurrentBook[0].ISBMOb,
                            CurrentBook[0].BorrowedOb, CurrentBook[0].CopysOb, CurrentBook[0].ReservedOb);
                        break;
                    case "d":
                        HandleAllBooks.UpdateOneBook(CurrentBook[0].IdOb, CurrentBook[0].TitleOb, CurrentBook[0].GenreOb, CurrentBook[0].AuthorOb, NewChange,
                            CurrentBook[0].BorrowedOb, CurrentBook[0].CopysOb, CurrentBook[0].ReservedOb);
                        break;
                    case "e":
                        HandleAllBooks.UpdateOneBook(CurrentBook[0].IdOb, CurrentBook[0].TitleOb, CurrentBook[0].GenreOb, CurrentBook[0].AuthorOb, CurrentBook[0].ISBMOb,
                            Convert.ToInt32(NewChange), CurrentBook[0].CopysOb, CurrentBook[0].ReservedOb);
                        break;
                    case "f":
                        HandleAllBooks.UpdateOneBook(CurrentBook[0].IdOb, CurrentBook[0].TitleOb, CurrentBook[0].GenreOb, CurrentBook[0].AuthorOb, CurrentBook[0].ISBMOb,
                            CurrentBook[0].BorrowedOb, Convert.ToInt32(NewChange), CurrentBook[0].ReservedOb);
                        break;
                    case "g":
                        HandleAllBooks.UpdateOneBook(CurrentBook[0].IdOb, CurrentBook[0].TitleOb, CurrentBook[0].GenreOb, CurrentBook[0].AuthorOb, CurrentBook[0].ISBMOb,
                            CurrentBook[0].BorrowedOb, CurrentBook[0].CopysOb, Convert.ToInt32(NewChange));
                        break;
                }
                
                Console.Clear();
                Console.WriteLine("What do you want to do now");
                Console.WriteLine("A: Change the same book again");
                Console.WriteLine("B: Go back to the menu");
                Console.WriteLine("C: Exit the program");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        Console.Clear();
                        updateBook();
                        break;
                    case "b":
                        Console.Clear();
                        Admin.librarian();
                        break;
                    case "c":
                        Environment.Exit(0);
                        break;
                }
            }

        }
        public static void updateUser()
        {
            listOfUsers();
            Console.WriteLine("Which user do you want to update?");
            int UserId = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("What name is the user going to change to?");
            string NewName = Console.ReadLine();

            Console.WriteLine("What name is the ssn going to change to?");
            string NewSsn = Console.ReadLine();

            Console.WriteLine("What name is the password going to change to?");
            string NewPassword = Console.ReadLine();

            HandleAllUsers.UpdateOneUser(UserId, NewName, NewSsn, NewPassword);
            Console.Clear();
        }
        public static void listOfUsers()
        {
            Console.Clear();
            for (int i = 0; i < AllUsers.Count; i++)
            {
                Console.WriteLine(AllUsers[i].IdOb + ". Name: " + AllUsers[i].NameUserOb + "; Password: " + AllUsers[i].PasswordUserOb + "; SSN: " + 
                    AllUsers[i].SsnUserOb);
            }
            Console.WriteLine("");
            Console.ReadLine();
        }
        public static void listOfBooks()
        {
            Console.Clear();
            for (int i = 0; i < AllBooks.Count; i++)
            {
                Console.WriteLine(AllBooks[i].IdOb + ". " + AllBooks[i].TitleOb + " by " + AllBooks[i].AuthorOb);
            }
            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
