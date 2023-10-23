using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class LibraryBook
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookType Type { get; set; }
    }
}
