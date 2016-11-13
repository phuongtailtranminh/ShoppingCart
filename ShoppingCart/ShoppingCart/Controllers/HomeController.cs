using ShoppingCart;
using ShoppingCart.Interfaces;
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
        private IBrandRepository BrandRepository;
        ShoppingCartDb shoppingCartDb = new ShoppingCartDb();
        public HomeController()
        {
            this.ProductRepository = new ProductRepository(shoppingCartDb);
            this.BrandRepository = new BrandRepository(shoppingCartDb);
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
        public ActionResult Search(string productName)
        {
            return Json(ProductRepository.SearchProduct(productName),JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public ActionResult _HeaderNavBar()
        {
            var listBrands = BrandRepository.GetBrands().ToList();
            return PartialView(listBrands);
        }

    }
}