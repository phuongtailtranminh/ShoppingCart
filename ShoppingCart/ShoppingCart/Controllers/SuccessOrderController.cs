using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class SuccessOrderController : Controller
    {
        // GET: SuccessOrder
        public ActionResult Index(string id)
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}