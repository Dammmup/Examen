using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class LibraryService : ILibraryService
    {
     
        private IBookDataAccess bookDataAccess;
        private IBookTypeDataAccess bookTypeDataAccess;

        public void AddBook(LibraryBook book)
        {
          
            BookType type = bookTypeDataAccess.GetBookType(book.Type.Name);
            if (type == null)
            {
                
                bookTypeDataAccess.SaveBookType(book.Type);
            }

            bookDataAccess.SaveBook(book);
        }

        public void EditBook(LibraryBook book)
        {
            
            LibraryBook existingBook = bookDataAccess.GetBook(book.Title);
            if (existingBook != null)
            {
                
                bookDataAccess.SaveBook(book);
            }
        }

        public LibraryBook FindBook(string title)
        {
           
            return bookDataAccess.GetBook(title);
        }

    

    }
}
