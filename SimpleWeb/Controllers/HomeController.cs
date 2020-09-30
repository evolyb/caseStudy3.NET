using SimpleWeb.Methods;
using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Phone> listFavoritePhones = PhoneService.getFavoritePhones();
            return View(listFavoritePhones);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}