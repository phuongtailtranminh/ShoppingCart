using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class GatewayController : Controller
    {
        // GET: Gateway
        private IProductRepository ProductRepository;
        public GatewayController()
        {
            this.ProductRepository = new ProductRepository(new ShoppingCartDb());
        }

        public ActionResult Index()
        {
            var products = ProductRepository.GetProducts().ToList();
            return View(products);
        }
    }
}