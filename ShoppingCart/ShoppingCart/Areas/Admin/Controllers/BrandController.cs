using ShoppingCart.Enums;
using ShoppingCart.Interfaces;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        private IBrandRepository BrandRepository;

        public BrandController()
        {
            this.BrandRepository = new BrandRepository(new ShoppingCartDb());
        }

        // GET: Admin/Brand
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Chip/GetListChip
        public ActionResult GetListBrand(string brandName)
        {
            var brands = BrandRepository.GetBrands().Where(x => x.name.ToUpper().Contains(brandName.ToUpper()));
            return Json(new { Result = JTableResponseCode.OK.ToString(), Records = brands.Select(x => new {
                id = x.id,
                name = x.name,
                productName = x.products.Select(y => new
                {
                    nameproduct = y.NAME,
                })

            })
            });
        }

        public ActionResult GetListBrandOptions()
        {
            var brands = BrandRepository.GetBrands();
            return Json(new
            {
                Result = JTableResponseCode.OK.ToString(),
                Options = brands.Select(x => new {
                    Value = x.id,
                    DisplayText = x.name
                })
            });
        }

        // POST: Admin/Chip/UpdateChip
        [HttpPost]
        public ActionResult UpdateBrand(brand brand)
        {
            BrandRepository.UpdateBrand(brand);
            BrandRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString() });
        }

        // POST: Admin/Chip/DeleteChip
        [HttpPost]
        public ActionResult DeleteBrand(int id)
        {
            BrandRepository.DeleteBrandById(id);
            BrandRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString() });
        }

        // POST: Admin/Chip/AddChip
        [HttpPost]
        public ActionResult AddBrand(brand brand)
        {
            BrandRepository.InsertBrand(brand);
            BrandRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString(), Record = brand });
        }
    }
}