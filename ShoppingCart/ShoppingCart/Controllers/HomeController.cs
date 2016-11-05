using ShoppingCart;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository ProductRepository;
        ShoppingCartDb shoppingCartDb = new ShoppingCartDb();
        public HomeController()
        {
            this.ProductRepository = new ProductRepository(shoppingCartDb);
        }

        public ActionResult Index()
        {
            var products = ProductRepository.GetProducts().ToList();
            return View(products);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult Search(String productName)
        {
            return Json(ProductRepository.SearchProduct(productName),JsonRequestBehavior.AllowGet);
        }
      


    }
}