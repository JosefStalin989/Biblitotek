using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Bibliotek
{
    internal class forgotpassword
    {
        List<UserOB> user = HandleAllUsers.GetUsers();
        string User = Resources_Path.UserPath;
        public void passwordChanger()
        {
            Console.WriteLine("Please give your social security number (12 numbers)");
            string Ssn = Console.ReadLine();
            Console.WriteLine("What is your new password");
            string newpassword = Console.ReadLine();
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].SsnUserOb == Ssn)
                {
                    PasswordChanger(i, newpassword);
                }
            }
        }
        internal void PasswordChanger(int position, string newpassword)
        {
            user[position].PasswordUserOb = newpassword;
            HandleAllBooks.UpdateDocument();
            Convo.Success_Convo();
            Reroute.Rerouts(Reroute_Location.sign_in);
        }
    }
}
