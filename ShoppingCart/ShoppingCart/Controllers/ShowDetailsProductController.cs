using ShoppingCart;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ShowDetailsProductController : Controller
    {
        private IProductRepository ProductRepository;
        ShoppingCartDb ShoppingCartDb = new ShoppingCartDb();
        public ShowDetailsProductController()
        {
            this.ProductRepository = new ProductRepository(ShoppingCartDb);
        }

        public ActionResult Index(int id)
        {
            //int id = 1;
            var product = ProductRepository.GetProductById(id);
            return View(product);
        }

        public ActionResult showDetail()
        {
            
            return View();
        }








        //public ActionResult findById(int id)
        //{
        //    var productId = ProductRepository.GetProductById(id);
        //    return View(productId);
        //}








    }
}