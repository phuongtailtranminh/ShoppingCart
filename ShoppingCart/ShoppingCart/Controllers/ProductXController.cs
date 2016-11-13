using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ProductXController : Controller
    {
        private IProductRepository ProductRepository;
        private ShoppingCartDb shoppingCart = new ShoppingCartDb();
        public ProductXController()
        {
            this.ProductRepository = new ProductRepository(shoppingCart);
        }

        // GET: Product
        public ActionResult Index(int id)
        {
            var product = ProductRepository.GetProductById(id);
            return View(product);
        }
    }
}