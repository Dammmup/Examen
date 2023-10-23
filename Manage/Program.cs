using Book;
using LibraryManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dbPath = "library.db"; 
            var dbContext = new LibraryDbContext(dbPath);


            while (true)
            {
                Console.WriteLine("Добро пожаловать в систему управления библиотекой.");
                Console.WriteLine("1. Добавить новую книгу");
                Console.WriteLine("2. Редактировать книгу");
                Console.WriteLine("3. Найти книгу");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                       
                        AddBook(dbContext);
                        break;

                    case "2":
                        
                        EditBook(dbContext);
                        break;

                    case "3":
                        
                        FindBook(dbContext);
                        break;

                    case "4":
                       
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

      
        private static void AddBook(LibraryDbContext dbContext)
        {
           
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            Console.Write("Введите автора книги: ");
            string author = Console.ReadLine();
            Console.Write("Введите тип книги: ");
            string bookType = Console.ReadLine();

            LibraryBook newBook = new LibraryBook
            {
                Title = title,
                Author = author,
                Type = new BookType { Name = bookType }
            };

            dbContext.Books.Insert(newBook);
            Console.WriteLine("Книга добавлена.");
        }

        private static void EditBook(LibraryDbContext dbContext)
        {
     
            Console.Write("Введите название книги для редактирования: ");
            string title = Console.ReadLine();

            LibraryBook existingBook = dbContext.Books.FindOne(b => b.Title == title);

            if (existingBook != null)
            {
               
                Console.Write("Введите новое название книги: ");
                string newTitle = Console.ReadLine();
                Console.Write("Введите нового автора книги: ");
                string newAuthor = Console.ReadLine();
                Console.Write("Введите новый тип книги: ");
                string newBookType = Console.ReadLine();

                existingBook.Title = newTitle;
                existingBook.Author = newAuthor;
                existingBook.Type = new BookType { Name = newBookType };

                dbContext.Books.Update(existingBook);
                Console.WriteLine("Книга отредактирована.");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }

        private static void FindBook(LibraryDbContext dbContext)
        {
            
            Console.Write("Введите название книги для поиска: ");
            string title = Console.ReadLine();

            LibraryBook foundBook = dbContext.Books.FindOne(b => b.Title == title);


            if (foundBook != null)
            {
                Console.WriteLine($"Название: {foundBook.Title}");
                Console.WriteLine($"Автор: {foundBook.Author}");
                Console.WriteLine($"Тип: {foundBook.Type.Name}");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }
    }
}
