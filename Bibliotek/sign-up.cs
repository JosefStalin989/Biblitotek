using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.users
{
    public class sign_up
    {
        string user = Resources_Path.UserPath;
        string[] UserArray = System.IO.File.ReadAllLines(Resources_Path.UserPath);
        public void signup()
        {
            Console.WriteLine("Please write your full name. Your name can't contain ','");
            string Name = Console.ReadLine();
            if (Name.Contains(",")) { Convo.Error_Comma_Convo(); }
            Console.WriteLine("Is " + Name + " corect? Y/N");
            string answerName = Console.ReadLine().ToLower();
            Console.Clear();
            if (answerName == "y" && Name != null)
            {
                Console.WriteLine("Please write your social security number (12 numbers)");
                string Ssn = Console.ReadLine();
                if (Ssn.Contains(",")) { Convo.Error_Comma_Convo(); }
                Console.WriteLine("Is " + Ssn + " corect? Y/N");
                string answerSsn = Console.ReadLine().ToLower();
                Console.Clear();
                if (answerSsn == "y" && Ssn != null)
                {
                    Console.WriteLine("Please write your password. Your Password can't contain ','");
                    string Password = Console.ReadLine().ToLower();
                    if (Password.Contains(",")) { Convo.Error_Comma_Convo(); }
                    Console.WriteLine("Is " + Password + " corect? Y/N");
                    string answerPassword = Console.ReadLine();
                    Console.Clear();
                    if (answerPassword == "y" && Password != null)
                    {
                        update_doc(Name, Ssn, Password);
                    }
                    else if (answerPassword == "n")
                    {
                    }
                    else if (Password == null)
                    {
                        Convo.Error_null_Convo();
                    }
                    else
                    {
                        Convo.Error_Convo();
                    }
                }
                else if (answerSsn == "n")
                {

                }
                else if (Ssn == null)
                {
                    Convo.Error_null_Convo();
                }
                else
                {
                    Convo.Error_Convo();
                }

            }
            else if (Name == null)
            {
                Convo.Error_null_Convo();
            }
            else if (answerName == "n")
            {
            }
            else
            {
                Convo.Error_Convo();
            }
        }
    
        internal void update_doc(string Name, string Ssn, string Password)
        {
            var HandleCurrentUser = new HandleCurrentUser();
            if (Name != null && Ssn != null && Password != null)
            {
                int id = UserArray.Length + 1;
                string idString;
                idString = id.ToString();
                string newUser = idString + "," + Name + "," + Ssn + "," + Password;
                File.AppendAllText(user, newUser + Environment.NewLine);
                Convo.Success_Convo();
                HandleCurrentUser.CreateCurrentUserObject(id);
                Reroute.Rerouts(Reroute_Location.user);
            }
        }
    }   
}
