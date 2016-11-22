using Newtonsoft.Json;
using ShoppingCart.Enums;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
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
        [Authorize]
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
        public ActionResult GetListOrder(string orderId)
        {
            var orders = OrderRepository.GetOrders().Where(a => a.id.ToUpper().Contains(orderId.ToUpper()));
            var userManager = new ApplicationDbContext();
            var lstUsers = userManager.Users.ToList();
            return Json(new
            {
                Result = JTableResponseCode.OK.ToString(),
                Records = orders
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
        //[HttpPost]
        //public ActionResult DeleteOrder(int id)
        //{
        //    OrderRepository.DeleteOrderById(id);
        //    OrderRepository.Save();
        //    return Json(new { Result = JTableResponseCode.OK.ToString() });
        //}

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