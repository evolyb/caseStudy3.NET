using SimpleWeb.Methods;
using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWeb.Controllers
{
    public class OrderController : Controller
    {
        OrderService orderService = new OrderService();
        public ActionResult Index()
        {
            if (Session["currentUser"] == null || ((User)Session["currentUser"]).role.name != "ADMIN") return Redirect("~/Login");
            return View();
        }
        [HttpPost]
        public ActionResult Add(String fullname, String phoneNumber, String address)
        {
            if (Session["cart"] == null) return Redirect("~/Home");
            Cart cart = (Cart)Session["cart"];
            Order order = new Order() { itemLines = cart.listItemsLine };
            order.id = orderService.getAllOrders()[orderService.getAllOrders().Count - 1].id + 1;
            if (Session["currentUser"] != null)
            {
                order.user = (User)Session["currentUser"];
            }
            order.customerName = fullname;
            order.address = address;
            order.phoneNumber = phoneNumber;
            Session["cart"] = null;
            orderService.addOrder(order);
            return Redirect("~/Home");
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            if (Session["currentUser"] == null || ((User)Session["currentUser"]).role.name != "ADMIN") return Redirect("~/Login");
            Order order = orderService.getOrderById(id);
            return View(order);
        }
        public ActionResult Payment()
        {
            if (Session["cart"] == null || ((Cart)Session["cart"]).getTotalPrice()==0) return Redirect("~/Home");
            User user;
            if (Session["currentUser"] == null)
            {
                user = new User();
            }
            else
            {
                user = (User)Session["currentUser"];
            }
            
            return View(user);
        }
    }
}