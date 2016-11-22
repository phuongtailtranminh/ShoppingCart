using ShoppingCart.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Interfaces;
using ShoppingCart.Repositories;
namespace ShoppingCart.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository ProductRepository;

        public ProductController()
        {
            this.ProductRepository = new ProductRepository(new ShoppingCartDb());
        }
        // GET: Admin/Product/Index
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Product/GetListProduct
        public ActionResult GetListProduct(string productName)
        {
            var products = ProductRepository.GetProducts().Where(x => x.NAME.ToUpper().Contains(productName.ToUpper()));
            return Json(new {
                Result = JTableResponseCode.OK.ToString(),
                Records = products.Select(x => new {
                 id = x.id,
                 name = x.NAME,
                 quantity = x.quantity,
                 imageurl = x.imageurl,
                 description = x.description,
                 chip = x.chip,
                 ram = x.ram,
                 monitor = x.monitor,
                 harddrive = x.harddrive,
                 power = x.power,
                 mainboard = x.mainboard,
                 vga = x.vga,
                 cpu = x.cpu,
                 price = x.price,
                 brandId = x.brandid
                }).ToList()
            });
        }

        // POST: Admin/Product/UpdateProduct
        [HttpPost]
        public ActionResult UpdateProduct(product product)
        {
            ProductRepository.UpdateProduct(product);
            ProductRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString() });
        }

        // POST: Admin/Product/DeleteProduct
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            ProductRepository.DeleteProductById(id);
            ProductRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString() });
        }

        // POST: Admin/Product/AddProduct
        [HttpPost]
        public ActionResult AddProduct(product product)
        {
            ProductRepository.InsertProduct(product);
            ProductRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString(), Record = product });
        }
        //public ActionResult FindProductCPUByID(int id)
        //{
        //    List<productcpu> cpu = ProductCPURepository.GetCpusByProductId(id);
        //    return Json(new { Result = JTableResponseCode.OK.ToString(), Record = cpu });
        //}
      }
        //public JsonResult GetProductOptions(int id)
        //{
        //    try
        //    {
        //        var chip = ProductRepository.GetProductById(id);
        //        return Json(new { Result = "OK", Options = chip ,
        //            Record = chip. });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}
    
}