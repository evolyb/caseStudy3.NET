using SimpleWeb.Methods;
using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWeb.Controllers
{
    public class LoginController : Controller
    {
        private UserService userServive = new UserService();
        public ActionResult Index()
        {
            if (Session["currentUser"] != null) return Redirect("~/Home");
            return View();
        }
        public ActionResult Logout()
        {
            Session["currentUser"] = null;
            return Redirect("~/Home");
        }
        [HttpPost]
        public ActionResult Validate(String username, String password)
        {
            User user = userServive.getUserByUserName(username);
            if (user != null && user.password.Equals(password))
            {
                Session["currentUser"] = user;
                return Redirect("~/Admin");
            }
            return Redirect("~/Login");
        }
    }
}