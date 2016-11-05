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
        order GetOrderById(int orderId);
        void InsertOrder(order order);
        void DeleteOrderById(int orderId);
        void UpdateOrder(order order);
        void Save();
    }
}
