using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Interfaces
{
    interface IUserRepository : IDisposable
    {
        IEnumerable<user> GetUsers();
        user GetUserById(int userId);
        void InsertUser(user user);
        void DeleteUserById(int userId);
        void UpdateUser(user user);
        void Save();
    }
}
