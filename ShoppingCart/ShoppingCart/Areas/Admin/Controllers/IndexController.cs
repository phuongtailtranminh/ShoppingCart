using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Enums;
using ShoppingCart.Interfaces;
using ShoppingCart.Repositories;

namespace ShoppingCart.Areas.Admin.Controllers
{
    public class IndexController : Controller
    {

        private IUserRepository UserRepository;

        public IndexController()
        {
            this.UserRepository = new UserRepository(new ShoppingCartDb());
        }
        // GET: Admin/Index/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Index/GetListUser
        public ActionResult GetListUser()
        {
            var users = UserRepository.GetUsers();
            return Json(new { Result = JTableResponseCode.OK.ToString(), Records = users.Select(x => new {
                id = x.id,
                username = x.username,
                name = x.NAME,
                age = x.age,
                user_address = x.user_address,
                password = x.password,
                phonenumber = x.phonenumber,
                roleid = x.roleid,
                roleName = x.role != null ? x.role.NAME : "NONE"
            })
                
                });
        }

        // POST: Admin/Index/UpdateUser
        [HttpPost]
        public ActionResult UpdateUser(user user)
        {
            UserRepository.UpdateUser(user);
            UserRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString() });
        }

        // POST: Admin/Index/DeleteUser
        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            UserRepository.DeleteUserById(id);
            UserRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString() });
        }

        // POST: Admin/Index/AddUser
        [HttpPost]
        public ActionResult AddUser(user user)
        {
            UserRepository.InsertUser(user);
            UserRepository.Save();
            return Json(new { Result = JTableResponseCode.OK.ToString(), Record = user });
        }

    }
}