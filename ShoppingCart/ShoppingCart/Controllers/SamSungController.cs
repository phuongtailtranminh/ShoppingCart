using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class SamSungController : Controller
    {
        // GET: SamSung
        private IProductRepository ProductRepository;
        public SamSungController()
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