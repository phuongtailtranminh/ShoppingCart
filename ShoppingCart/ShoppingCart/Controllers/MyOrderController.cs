using Microsoft.AspNet.Identity;
using ShoppingCart.Interfaces;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class MyOrderController : Controller
    {
        private IOrderRepository OrderRepository;

        public MyOrderController()
        {
            this.OrderRepository = new OrderRepository(new ShoppingCartDb());
        }
        // GET: MyOrder
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult GetListOrder() {
            string currentUserId = User.Identity.GetUserId();
            return Json(OrderRepository.GetOrdersByUserId(currentUserId), JsonRequestBehavior.AllowGet);
        }
    }
}