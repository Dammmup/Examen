using Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace LibraryManagementSystem.DataAccess
{
    public class BookTypeDataAccess : IBookTypeDataAccess
    {
        private LiteCollection<BookType> bookTypes;

        public BookTypeDataAccess(LiteDatabase database)
        {
            bookTypes = (LiteCollection<BookType>)database.GetCollection<BookType>("bookTypes");
        }

        public BookType GetBookType(string name)
        {
            try
            {
                return bookTypes.FindOne(bt => bt.Name == name);
            }
            catch (LiteException ex)
            {
               
                Console.WriteLine($"Ошибка при получении типа книги: {ex.Message}");
                return null;
            }
        }

        public void SaveBookType(BookType bookType)
        {
            try
            {
                bookTypes.Upsert(bookType);
            }
            catch (LiteException ex)
            {
              
                Console.WriteLine($"Ошибка при сохранении типа книги: {ex.Message}");
            }
        }
    }
    }
