using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class UserOB
    {
        internal string NameUserOb;
        internal string SsnUserOb;
        internal string PasswordUserOb;
        internal int IdOb;
        public UserOB(int id, string name, string ssn, string password)
        { IdOb = id; NameUserOb = name; SsnUserOb = ssn; PasswordUserOb = password; }
    }
}
