using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private IProductRepository ProductRepository;

        public CategoryController()
        {
            this.ProductRepository = new ProductRepository(new ShoppingCartDb());
        }
        // GET: Category
        public ActionResult Index(int? id)
        {
            if (id == null) {
                Redirect("/");
            }
            var products = ProductRepository.GetProducts().Where(x => x.brandid == id).ToList();
            return View(products);
        }
    }
}