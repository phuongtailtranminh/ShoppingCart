using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Interfaces
{
    interface IOrderRepository : IDisposable
    {
        IEnumerable<order> GetOrders();
        order GetOrderById(string orderId);
        IEnumerable<order> GetOrdersByUserId(string userId);
        void InsertOrder(order order);
        void DeleteOrderById(string orderId);
        void UpdateOrder(order order);
        void Save();
    }
}
