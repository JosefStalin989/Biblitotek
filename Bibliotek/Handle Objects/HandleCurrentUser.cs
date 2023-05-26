using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class HandleCurrentUser
    {
        private static List<UserOB> CurrentUser = new List<UserOB>();
        public static List<UserOB> GetCurrentUsers() { return CurrentUser; }

        List<UserOB> user = HandleAllUsers.GetUsers();
        public void CreateCurrentUserObject(int position)
        {
            CurrentUser.Clear();
            UserOB newUser = new UserOB(position + 1, user[position].NameUserOb, user[position].SsnUserOb, user[position].PasswordUserOb);
            CurrentUser.Add(newUser);
        }
        public static void ClearCurrentUser()
        {
            CurrentUser.Clear();
        }
    }
}
