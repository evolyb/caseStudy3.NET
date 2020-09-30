using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Methods
{
    public class BrandService
    {
        public static List<Brand> listBrand = new List<Brand>();

        public static void initData()
        {
            if (listBrand.Count == 0)
            {
                listBrand.Add(new Brand() { id = 1, name = "SamSung" });
                listBrand.Add(new Brand() { id = 2, name = "Iphone" });
                listBrand.Add(new Brand() { id = 3, name = "Oppo" });
            }
        }
        public static List<Brand> getAllBrand()
        {
            initData();
            return listBrand;
        }
        public static Brand getBrandById(int id)
        {
            List<Brand> brands = getAllBrand();
            foreach (Brand brand in brands)
            {
                if (brand.id == id) return brand;
            }
            return new Brand() { name = "Not Listed" };
        }
    }
}