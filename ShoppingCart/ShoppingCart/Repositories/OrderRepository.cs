using ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingCart.Repositories
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private ShoppingCartDb context;
        public OrderRepository(ShoppingCartDb context)
        {
            this.context = context;
        }

        public void DeleteOrderById(int orderId)
        {
            order order = context.orders.Find(orderId);
            context.orders.Remove(order);
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

        public order GetOrderById(int OrderId)
        {
            return context.orders.Find(OrderId);
        }

        public IEnumerable<order> GetOrders()
        {
            return context.orders;
        }

        public void InsertOrder(order order)
        {
            context.orders.Add(order);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateOrder(order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }
    }
}