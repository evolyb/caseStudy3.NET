using SimpleWeb.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Models
{
    public class Phone
    {
        public int id { get; set; }
        public String name { get; set; }
        public double price { get; set; }
        public int brand_id { get; set; }
        public String imgSrc { get; set; }
        public String shortDescription { get; set; }
        public String fullDescription { get; set; }
        public int sold { get; set; }

        public Brand getBrand()
        {
            return BrandService.getBrandById(this.brand_id);
        }

    }
}