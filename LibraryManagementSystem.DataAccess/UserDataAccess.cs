using Book;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystem.DataAccess
{
    public class UserDataAccess:IUserDataAccess
    {
        private LiteCollection<User> users;

        public UserDataAccess(LiteDatabase database)
        {
            users = (LiteCollection<User>)database.GetCollection<User>("users");
        }

        public User GetUser(string username)
        {
            try
            {
                return users.FindOne(u => u.Username == username);
            }
            catch (LiteException ex)
            {
                
                Console.WriteLine($"Ошибка при получении пользователя: {ex.Message}");
                return null;
            }
        }

        public void SaveUser(User user)
        {
            try
            {
                users.Upsert(user);
            }
            catch (LiteException ex)
            {
                
                Console.WriteLine($"Ошибка при сохранении пользователя: {ex.Message}");
            }
        }

    }
}
