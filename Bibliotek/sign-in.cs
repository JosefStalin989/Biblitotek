using Bibliotek.users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class login
    {
        string[] userArray = Resources_Arrays.UserArray;
        public void signin()
        {

            Console.Clear();
            Convo.First_Login_Convo();
            string answer = Console.ReadLine().ToLower();
            if (answer == "a")
            {
                Console.Clear();
                Convo.Ask_SSN_Convo();
                string userSsn = Console.ReadLine();
                Console.Clear();
                Convo.PASSWORD_Login_Convo();
                string userPassword = Console.ReadLine();
                Console.Clear();
                if (userSsn == "123456789012" && userPassword == "123")
                {
                    Reroute.Rerouts(Reroute_Location.admin);
                }
                else
                {
                    Authoraization_user(userSsn, userPassword);
                }
            }
            else if (answer == "b")
            {
                Console.Clear();
                Reroute.Rerouts(Reroute_Location.reset_password);
            }
            else
            {
                Convo.Error_Convo();
                Reroute.Rerouts(Reroute_Location.sign_in);
            }
        }
        internal void Authoraization_user(string ssnUser, string passwordUser)
        {
            var CreateUserObject = new HandleCurrentUser();
            for (int i = 0; i < userArray.Length; i++)
            {
                string user = userArray[i];
                string[] UserToSplit = user.Split(",");
                if (UserToSplit[2] == ssnUser && UserToSplit[3] == passwordUser)
                {
                    CreateUserObject.CreateCurrentUserObject(i);
                    HandleAllUsers.ClearAllUser();
                    Reroute.Rerouts(Reroute_Location.user);
                }
                else if (i == userArray.Length && UserToSplit[2] != ssnUser || i == userArray.Length && UserToSplit[3] != passwordUser)
                {
                    Convo.Error_FindUser_Convo();
                    Reroute.Rerouts(Reroute_Location.sign_in);
                }

            }
        }
    }
}

