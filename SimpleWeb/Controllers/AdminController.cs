using SimpleWeb.Methods;
using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWeb.Controllers
{
    public class AdminController : Controller
    {
        private UserService userService = new UserService();
        private OrderService orderService = new OrderService();
        
        public ActionResult Index()
        {
            if (Session["currentUser"] == null || ((User)Session["currentUser"]).role.name != "ADMIN") return Redirect("~/Login");
            List<Order> orders = orderService.getAllOrders();
            double sum = 0;
            foreach (Order order in orders)
            {
                sum += order.getTotalPrice();
            }
            ViewBag.Hello = sum;
            return View();
        }
        public ActionResult PhoneManage()
        {
            if (Session["currentUser"] == null || ((User)Session["currentUser"]).role.name != "ADMIN") return Redirect("~/Login");
            List<Phone> listPhones = PhoneService.SortByName();
            return View(listPhones);
        }
        public ActionResult UserManage()
        {
            if (Session["currentUser"] == null || ((User)Session["currentUser"]).role.name != "ADMIN") return Redirect("~/Login");
            List<User> listUsers = userService.getAllUsers();
            return View(listUsers);
        }
        public ActionResult OrderManage()
        {
            if (Session["currentUser"] == null || ((User)Session["currentUser"]).role.name != "ADMIN") return Redirect("~/Login");
            List<Order> orders = orderService.getAllOrders();
            return View(orders);
        }
    }
}