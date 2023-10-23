using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public interface ILibraryService
    {
        void AddBook(LibraryBook book);
        void EditBook(LibraryBook book);
        LibraryBook FindBook(string title);
    }
}
