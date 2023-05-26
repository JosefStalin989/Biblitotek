using Bibliotek.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bibliotek
{
    public class Reroute
    {
        public static void Rerouts(Reroute_Location ReroutePostion)
        {
            Console.Clear();
            var signup = new sign_up();
            var signin = new login();
            var forgot = new forgotpassword();
            var Return = new Return(); 
            switch (ReroutePostion){
                case Reroute_Location.sign_up:
                    signup.signup();
                    break;
                case Reroute_Location.sign_in:
                    signin.signin();
                    break;
                case Reroute_Location.reset_password:
                    forgot.passwordChanger();
                    break;
                case Reroute_Location.admin:
                    Admin.librarian();
                    break;
                case Reroute_Location.user:
                    User.NormalUser();
                    break;
                case Reroute_Location.search:
                    SearchBook.Search_Book();
                    break;
                case Reroute_Location.Return:
                    Return.ReturnBook();
                    break;
                default:
                    Console.WriteLine("REROUTE ERROR");
                    break;
            }
        }
    }
}
