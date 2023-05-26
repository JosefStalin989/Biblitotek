using Bibliotek.users;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Bibliotek
{
    public class Resources_Path
    {
        public static string UserPath = @"C:\Users\hampus.hult\source\repos\Bibliotek\users\Users.txt";
        public static string PasswordPath = @"C:\Users\hampus.hult\source\repos\Bibliotek\users\password.txt";
        public static string SsnPath = @"C:\Users\hampus.hult\source\repos\Bibliotek\users\ssn.txt";
        public static string NamePath = @"C:\Users\hampus.hult\source\repos\Bibliotek\users\name.txt";
        public static string BooksPath = @"C:\Users\hampus.hult\source\repos\Bibliotek\Books\Books.txt";
        public static string BorrowPath = @"C:\Users\hampus.hult\source\repos\Bibliotek\Reserved and Borrow Books\Borrow.txt";
        public static string ReservedPath = @"C:\Users\hampus.hult\source\repos\Bibliotek\Reserved and Borrow Books\Reserved.txt";
    }
    public class Resources_Arrays
    {
        public static string[] UserArray = System.IO.File.ReadAllLines(Resources_Path.UserPath);
        public static string[] BookArray = System.IO.File.ReadAllLines(Resources_Path.BooksPath);
        public static string[] BorrowArray = System.IO.File.ReadAllLines(Resources_Path.BorrowPath);
        public static string[] ReservedArray = System.IO.File.ReadAllLines(Resources_Path.ReservedPath);
    }
    public enum Reroute_Location
    {
        sign_in,
        sign_up,
        reset_password,
        admin,
        user,
        search,
        Return
    }
    public enum Lists
    {
        all_users,
        all_books,
        current_user
    }
    public class Program 
    {

        static void Main()
        {
            var HandleBorrowedBookObject = new HandleBorrowBook();
            var HandleBookObject = new HandleAllBooks();
            var HandleUserObject = new HandleAllUsers();
            HandleUserObject.CreateAllUsersObjects();
            HandleBookObject.CreateAllBooksObjects();
            HandleBorrowedBookObject.CreateAllBorrowBooks();
            var Reroute = new Reroute();
            Console.Clear();
            int counterSignup = 0;
            Convo.First_Program_Convo();
            string answer = Console.ReadLine().ToLower();
            if (answer == "a")
            {
                Reroute.Rerouts(Reroute_Location.sign_in);
            }
            else if (answer == "b" && counterSignup == 0)
            {
                counterSignup++;
                Reroute.Rerouts(Reroute_Location.sign_up);
            }
            else if (answer == "c")
            {
                Reroute.Rerouts(Reroute_Location.reset_password);
            }
            else if (answer == "b" && counterSignup != 0)
            {
                Convo.Error_SignUp_Convo();
            }
            else
            {
                Convo.Error_Convo();
            }
            Console.Clear();
        }
    }
}