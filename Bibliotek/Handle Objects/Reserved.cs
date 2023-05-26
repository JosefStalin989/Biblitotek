using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek.Handle_Objects
{
    public class Reserved
    {
        internal string UserSsn;
        internal string BookISBM;
        internal int PlaceInQueue;
        public Reserved(string UserSsnInput, string BookISBMInput, int PlaceInQueueInput)
        {
            UserSsn = UserSsnInput; BookISBM = BookISBMInput; PlaceInQueue = PlaceInQueueInput; 
        }
    }
}
