using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShoppingCart.Interfaces;

namespace ShoppingCart.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private ShoppingCartDb context;
        public UserRepository(ShoppingCartDb context)
        {
            this.context = context;
        }

        public void DeleteUserById(int userId)
        {
            user user = context.users.Find(userId);
            context.users.Remove(user);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public user GetUserById(int userId)
        {
            return context.users.Find(userId);
        }

        public IEnumerable<user> GetUsers()
        {
            return context.users;
        }

        public void InsertUser(user user)
        {
            context.users.Add(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateUser(user user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}