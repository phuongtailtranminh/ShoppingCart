using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Enums;
using ShoppingCart.Interfaces;
using ShoppingCart.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingCart.Models;

namespace ShoppingCart.Areas.Admin.Controllers
{
    public class IndexController : Controller
    {

        //private IUserRepository UserRepository;

        public IndexController()
        {
            //this.UserRepository = new UserRepository(new ShoppingCartDb());
        }

        [Authorize]
        // GET: Admin/Index/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Index/GetListUser
        public ActionResult GetListUser()
        {
            var userManager = new ApplicationDbContext();
            var users = userManager.Users.ToList();
            return Json(new
            {
                Result = JTableResponseCode.OK.ToString(),
                Records = users
            });
        }

        // POST: Admin/Index/UpdateUser
        //[HttpPost]
        //public ActionResult UpdateUser(user user)
        //{
        //    UserRepository.UpdateUser(user);
        //    UserRepository.Save();
        //    return Json(new { Result = JTableResponseCode.OK.ToString() });
        //}

        // POST: Admin/Index/DeleteUser
        //[HttpPost]
        //public ActionResult DeleteUser(int id)
        //{
        //    var userManager = new ApplicationDbContext();
        //    userManager.Users.Remove()
        //    return Json(new { Result = JTableResponseCode.OK.ToString() });
        //}

        //// POST: Admin/Index/AddUser
        //[HttpPost]
        //public ActionResult AddUser(user user)
        //{
        //    UserRepository.InsertUser(user);
        //    UserRepository.Save();
        //    return Json(new { Result = JTableResponseCode.OK.ToString(), Record = user });
        //}

    }
}