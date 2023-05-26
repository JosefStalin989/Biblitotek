using Bibliotek.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    internal class User
    {
        public static void NormalUser()
        {
            Console.Clear();
            Console.WriteLine("What do you want to do \n");
            Console.WriteLine("A: Return a Book ");
            Console.WriteLine("B: Search for a Book ");
            Console.WriteLine("C: Borrow a Book ");
            Console.WriteLine("D: Exit the program \n");
            string answer = Console.ReadLine().ToLower();
            Console.Clear();
            if (answer == "a")
            {
                Reroute.Rerouts(Reroute_Location.Return);
            }
            else if (answer == "b")
            {
                Reroute.Rerouts(Reroute_Location.search);
            }
            else if (answer == "c")
            {
                Borrow_Reserve.BorrowReserveMenu();
            }
            else if (answer == "d")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ERROR \n");
                Console.WriteLine("Press Any Key to try again");
                Console.ReadKey();
            }
        }
    }
}
