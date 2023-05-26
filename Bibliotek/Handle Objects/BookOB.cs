using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class BookOB
    {
        internal int IdOb;
        internal string TitleOb;
        internal string GenreOb;
        internal string AuthorOb;
        internal string ISBMOb;
        internal int CopysOb;
        internal int BorrowedOb;
        internal int ReservedOb;
        public BookOB(int Idbook, string Title, string Genre, string Author, string ISBM, int Copys, int Borrowed, int Reserved)
        {
            IdOb = Idbook; TitleOb = Title; GenreOb = Genre; AuthorOb = Author; ISBMOb = ISBM; CopysOb = Copys; BorrowedOb = Borrowed; ReservedOb = Reserved;
        }
    }
}
