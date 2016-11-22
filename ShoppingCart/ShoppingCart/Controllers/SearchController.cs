using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class SearchController : Controller
    {
        private IProductRepository ProductRepository;

        public SearchController()
        {
            this.ProductRepository = new ProductRepository(new ShoppingCartDb());
        }
        // GET: Search
        public ActionResult Index(string id)
        {
            if (id == null) {
                Redirect("/");
            }
            var products = ProductRepository.GetProducts().Where(x => x.NAME.ToUpper().Contains(id.ToUpper())).ToList();
            return View(products);
        }
    }
}