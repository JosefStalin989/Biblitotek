using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Handle_Objects
{
    public class BorrowedBook
    {
        internal string UserSsn;
        internal string ISBM;
        public BorrowedBook(string InputUserSsn, string InputISBM)
        {
            UserSsn = InputUserSsn; ISBM = InputISBM;
        }
    }
}
