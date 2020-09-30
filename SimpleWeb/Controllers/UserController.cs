using SimpleWeb.Methods;
using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWeb.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService();
        RoleService roleService = new RoleService();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            userService.removeUserById(id);
            return Redirect("~/Admin/UserManage");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = userService.getUserById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(int id, String username, String password, String fullname, String email, String phoneNumber, String address, int role_id)
        {
            User user = userService.getUserById(id);
            user.username = username;
            user.password = password;
            user.fullname = fullname;
            user.email = email;
            user.phoneNumber = phoneNumber;
            user.address = address;
            user.role = roleService.getRoleById(role_id);
            return Redirect("~/Admin/UserManage");
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Signup(String username, String password, String fullname, String phoneNumber, String address)
        {
            User user = new User() { username = username, password = password, fullname = fullname, phoneNumber = phoneNumber, address = address };
            user.role = roleService.getRoleById(2);
            userService.save(user);
            return Redirect("~/Login");
        }
    }
}