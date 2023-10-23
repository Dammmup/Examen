using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class LibraryService : ILibraryService
    {
        private IUserDataAccess userDataAccess;
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

        public void AddUser(User user)
        {
          
            User existingUser = userDataAccess.GetUser(user.Username);
            if (existingUser == null)
            {
              
                userDataAccess.SaveUser(user);
            }
        }

        public void EditUser(User user)
        {
          
            User existingUser = userDataAccess.GetUser(user.Username);
            if (existingUser != null)
            {
                
                userDataAccess.SaveUser(user);
            }
        }

        public void BlockUser(string username)
        {
           
            User user = userDataAccess.GetUser(username);
            if (user != null)
            {
                // Установите статус блокировки пользователя
                user.IsBlocked = true;
                userDataAccess.SaveUser(user);
            }
        }

        public void ChangePassword(string username, string newPassword)
        {
          
            User user = userDataAccess.GetUser(username);
            if (user != null)
            {
                // Обновите пароль пользователя
                user.Password = newPassword;
                userDataAccess.SaveUser(user);
            }
        }
    }
}
