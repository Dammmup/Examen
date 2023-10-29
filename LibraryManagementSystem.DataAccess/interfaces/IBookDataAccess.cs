using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public interface IBookDataAccess
    {
        LibraryBook GetBook(string title);
        void SaveBook(LibraryBook book);
    }
}
