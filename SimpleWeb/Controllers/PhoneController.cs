using Microsoft.Ajax.Utilities;
using SimpleWeb.Methods;
using SimpleWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWeb.Controllers
{
    public class PhoneController : Controller
    {
        // GET: Phone
        public ActionResult Index()
        {
            List<Brand> listAllBrands = BrandService.getAllBrand();
            List<List<Phone>> list = new List<List<Phone>>();
            List<String> listBrand = new List<string>();
            foreach (var brand in listAllBrands)
            {
                list.Add(PhoneService.getPhonesByBrand(brand.id));
                listBrand.Add(brand.name);
            }
            ViewBag.List = list;
            ViewBag.ListBrand = listBrand;
            return View();
        }
        
        [HttpPost]
        public ActionResult Search(String searchValue)
        {
            List<Phone> listPhones = PhoneService.getPhonesByName(searchValue);
            return View(listPhones);
        }
        public ActionResult Detail(int id)
        {
            Phone phone = PhoneService.getPhoneById(id);
            return View(phone);
        }
        public ActionResult Remove(int id)
        {
            if (Session["currentUser"] == null || ((User)Session["currentUser"]).role.name != "ADMIN") return Redirect("~/Login");
            PhoneService.removeById(id);
            return Redirect("~/Admin/PhoneManage");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["currentUser"] == null || ((User)Session["currentUser"]).role.name != "ADMIN") return Redirect("~/Login");
            Phone phone = PhoneService.getPhoneById(id);
            return View(phone);
        }
        [HttpPost]
        public ActionResult Edit(int id, String name, double price, String shortDescription, String fullDescription, int brand_id)
        {
            if (Session["currentUser"] == null || ((User)Session["currentUser"]).role.name != "ADMIN") return Redirect("~/Login");
            Phone phone = PhoneService.getPhoneById(id);
            phone.name = name;
            phone.price = price;
            phone.shortDescription = shortDescription;
            phone.fullDescription = fullDescription;
            phone.brand_id = brand_id;
            return Redirect("~/Admin/PhoneManage");
        }
        

    }
}