using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bibliotek
{
    public class HandleAllUsers
    {
        private static List<UserOB> user = new List<UserOB>();
        public static List<UserOB> GetUsers() { return user; }

        static string[] UserArray = Resources_Arrays.UserArray;
        static string UserPath = Resources_Path.UserPath;
        public void CreateAllUsersObjects()
        {
            user.Clear();
            for (int i = 0; i < UserArray.Length; i++)
            {
                string UserDB = UserArray[i];
                string[] UserToSplit = UserDB.Split(",");
                UserOB newUser = new UserOB(i, UserToSplit[1], UserToSplit[2], UserToSplit[3]);
                user.Add(newUser);
            }
        }
        public void AddOneUser(string name, string ssn, string password)
        {
            UserOB newUser = new UserOB(UserArray.Length+1, name, ssn, password);
            user.Add(newUser);
        }
        public static void ClearAllUser()
        {
            user.Clear();
        }
        public static List<UserOB> FindUser(string request)
        {
            var textLowerCase = request.ToLower();
            int maxDistance = 2;

            var result = new List<UserOB>();

            foreach (var users in user)
            {
                var nameDistance = LevenshteinDistance.GetDistance(users.NameUserOb.ToLower(), textLowerCase);
                var ssnDistance = LevenshteinDistance.GetDistance(users.SsnUserOb.ToLower(), textLowerCase);
                var passwordDistance = LevenshteinDistance.GetDistance(users.PasswordUserOb.ToLower(), textLowerCase);

                if (nameDistance <= maxDistance || ssnDistance <= maxDistance || passwordDistance <= maxDistance)
                {
                    result.Add(users);
                }
            }

            return result;
        }
        public static void UpdateOneUser(int position, string Name, string Ssn, string Password)
        {
            user[position].IdOb = position + 1;
            user[position].NameUserOb = Name;
            user[position].SsnUserOb = Ssn;
            user[position].PasswordUserOb = Password;

        }
        public void UpdateDocument() { 
            List<string> UserOBToString = new List<string>(); 
            for (int i = 0; i < user.Count; i++)
            {
                UserOBToString[i] = user[i].IdOb + "," + user[i].NameUserOb + "," + user[i].SsnUserOb + "," + user[i].PasswordUserOb;
            }
            File.WriteAllLines(UserPath, UserOBToString);
        }
        public void ClearOneUser(int id)
        {
            user.RemoveAt(id);
            UpdateDocument();
            CreateAllUsersObjects();
        }
    }
}
