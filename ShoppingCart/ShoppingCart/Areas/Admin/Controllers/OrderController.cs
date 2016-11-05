using Newtonsoft.Json;
using ShoppingCart.Enums;
using ShoppingCart.Interfaces;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            return View();
        }
        private IOrderRepository OrderRepository;

        public OrderController()
        {
            this.OrderRepository = new OrderRepository(new ShoppingCartDb());
        }
        // GET: Admin/Order/GetListOrder
        public ActionResult GetListOrder()
        {
            var orders = OrderRepository.GetOrders();
            return Json(new { Result = JTableResponseCode.OK.ToString(), Records = orders.Select(x => new {
                id = x.id,
                status = x.status,
                products = x.orderproducts.Select(y => new {
                    name = y.product.NAME
                }),
                 
                //user = x.userorders.Select(z => new
                //{
                //    name = z.user.NAME
                //})
            })
        });
        }

        // POST: Admin/Order/UpdateOrder
        [HttpPost]
        public ActionResult UpdateOrder(order order)
        {

            OrderRepository.UpdateOrder(order);
            OrderRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString() });
        }

        // POST: Admin/Order/DeleteOrder
        [HttpPost]
        public ActionResult DeleteOrder(int id)
        {
            OrderRepository.DeleteOrderById(id);
            OrderRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString() });
        }

        // POST: Admin/Order/AddOrder
        [HttpPost]
        public ActionResult AddOrder(order order)
        {
            OrderRepository.InsertOrder(order);
            OrderRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString(), Record = order });
        }
    }
}