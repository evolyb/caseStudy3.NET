using SimpleWeb.Methods;
using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWeb.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Cart cart = new Cart() { listItemsLine = new List<ItemLine>() };
            if (Session["cart"] != null)
            {
                cart = (Cart)Session["cart"];
            }
      
            return View(cart);
        }
        public ActionResult Add(int id)
        {
            
            if (Session["cart"] == null)
            {
                Session["cart"] = new Cart() { listItemsLine = new List<ItemLine>() };
            }

            Cart cart = (Cart)Session["cart"];

            
            ItemLine itemLine = cart.GetItemLineById(id);
            itemLine.quantity++;
            return Redirect("~/Cart/index");
        }
        public ActionResult Minus(int id)
        {

            if (Session["cart"] == null)
            {
                Session["cart"] = new Cart() { listItemsLine = new List<ItemLine>() };
            }

            Cart cart = (Cart)Session["cart"];
            ItemLine itemLine = cart.GetItemLineById(id);
            itemLine.quantity--;
            if (itemLine.quantity == 0) cart.listItemsLine.Remove(itemLine);
            return Redirect("~/Cart/index");
        }
        public ActionResult Remove(int id)
        {

            if (Session["cart"] != null)
            {
                Cart cart = (Cart)Session["cart"];
                ItemLine itemLine = cart.GetItemLineById(id);
                cart.listItemsLine.Remove(itemLine);
            }

            
            return Redirect("~/Cart/index");
        }
    }
}