using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public interface IUserDataAccess
    {
        User GetUser(string username);
        void SaveUser(User user);
    }
}
