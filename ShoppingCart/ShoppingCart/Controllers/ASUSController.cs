﻿using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ASUSController : Controller
    {
        // GET: ASUS
        private IProductRepository ProductRepository;
        public ASUSController()
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