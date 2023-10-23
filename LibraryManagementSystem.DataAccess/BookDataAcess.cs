using Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace LibraryManagementSystem.DataAccess
{
    public class BookDataAcess : IBookDataAccess
    {
        private LiteCollection<LibraryBook> books;

        public BookDataAcess(LiteDatabase database)
        {
            books = (LiteCollection<LibraryBook>)database.GetCollection<LibraryBook>("books");
        }

        public LibraryBook GetBook(string title)
        {
            try
            {
                return books.FindOne(b => b.Title == title);
            }
            catch (LiteException ex)
            {
              
                Console.WriteLine($"Ошибка при получении книги: {ex.Message}");
                return null;
            }
        }

        public void SaveBook(LibraryBook book)
        {
            try
            {
                books.Upsert(book);
            }
            catch (LiteException ex)
            {
                
                Console.WriteLine($"Ошибка при сохранении книги: {ex.Message}");
            }
        }

    }
}
