using PayPal.Api;
using ShoppingCart.Enums;
using ShoppingCart.Interfaces;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ShoppingCart.Controllers
{
    public class PaymentController : Controller
    {
        private IOrderRepository OrderRepository;
        public PaymentController()
        {
            this.OrderRepository = new OrderRepository(new ShoppingCartDb());
        }
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public APIContext GetAPIContext() {
            // Authenticate with PayPal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            return new APIContext(accessToken);
        }

        [HttpPost]
        public ActionResult ProcessPayment(Payment payment) {
            var apiContext = GetAPIContext();
            //Payment.Get(apiContext, createdPayment.id);
            try
            {
                var createdPayment = payment.Create(apiContext);
                var order = new order();
                order.id = createdPayment.id;
                order.status = OrderStatus.PENDING.ToString();
                string currentUserId = User.Identity.GetUserId();
                order.userid = currentUserId;
                OrderRepository.InsertOrder(order);
                OrderRepository.Save();
                return Json(createdPayment);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult GetPaymentStatus(string paymentId)
        {
            var order = OrderRepository.GetOrderById(paymentId);
            var status = "Not Found";
            if (order != null) {
                status = order.status;
            }
            return Json(status);
        }

    }
}