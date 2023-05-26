using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Convo
    {        
        public static void First_Program_Convo()
        {
            Console.Clear();
            Console.WriteLine("Welcome to my Libery \n");
            Console.WriteLine("Do you want to");
            Console.WriteLine("A: Sign in");
            Console.WriteLine("B: Sign up");
            Console.WriteLine("C: Forgot my Password \n");
        }
        public static void Error_SignUp_Convo()
        {
            Console.Clear();
            Console.WriteLine("ERROR \n");
            Console.WriteLine("Can only Sign up one account per session \n");
            Console.WriteLine("Press Any Key to try again");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Error_SignIn_Convo()
        {
            Console.WriteLine("ERROR \n");
            Console.WriteLine("Unable to find your Username or Password \n");
            Console.WriteLine("Press Any Key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void First_Login_Convo()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("A: Log in");
            Console.WriteLine("B: Forgot my password \n");
        }
        public static void Ask_SSN_Convo()
        {
            Console.WriteLine("Please give your ssn (12 numbers)\n");
        }
        public static void PASSWORD_Login_Convo()
        {
            Console.WriteLine("Please give your password. Password can not contain (,) \n");
        }
        public static void Success_Convo()
        {
            Console.Clear();
            Console.WriteLine("Success \n");
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Error_Convo()
        {
            Console.Clear();
            Console.WriteLine("ERROR \n");
            Console.WriteLine("Press Any Key to try again");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Error_FindUser_Convo()
        {
            Console.Clear();
            Console.WriteLine("ERROR \n");
            Console.WriteLine("We can't find your profile");
            Console.WriteLine("Press Any Key to try again");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Error_FoundBook()
        {
            Console.Clear();
            Console.WriteLine("Error\n");
            Console.WriteLine("This book do already exist");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Do you want to");
            Console.WriteLine("A: Try again");
            Console.WriteLine("B: Go back to the meny");
            Console.WriteLine("C: Exit the program");

        }
        public static void Error_FoundUser()
        {
            Console.Clear();
            Console.WriteLine("Error\n");
            Console.WriteLine("This user do already exist");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Do you want to");
            Console.WriteLine("A: Try again");
            Console.WriteLine("B: Go back to the meny");
            Console.WriteLine("C: Exit the program");

        }
        public static void Error_null_Convo()
        {
            Console.Clear();
            Console.WriteLine("ERROR \n");
            Console.WriteLine("Please write something");
            Console.WriteLine("Press Any Key to try again");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Error_Not_Found_Convo()
        {
            Console.Clear();
            Console.WriteLine("ERROR \n");
            Console.WriteLine("Didn't find anything");
            Console.WriteLine("Do you want to ");
            Console.WriteLine("A: Try to search again");
            Console.WriteLine("B: Try to search for something else");
            Console.WriteLine("C: Back to the menu");
        }
        public static void Error_Comma_Convo()
        {
            Console.Clear();
            Console.WriteLine("ERROR \n");
            Console.WriteLine("You can't use ,");
            Console.WriteLine("Press Any Key to try again");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
