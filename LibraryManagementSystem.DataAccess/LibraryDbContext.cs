using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
namespace Book
{
    public class LibraryDbContext
    {
        private LiteDatabase database;

        public LibraryDbContext(string dbPath)
        {
            database = new LiteDatabase(dbPath);
        }

        public LiteCollection<LibraryBook> Books => (LiteCollection<LibraryBook>)database.GetCollection<LibraryBook>("books");
        public LiteCollection<User> Users => (LiteCollection<User>)database.GetCollection<User>("users");
    }
}
