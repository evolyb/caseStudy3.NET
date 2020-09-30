using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Models
{
    public class ItemLine
    {
        public int id { get; set; }
        public Phone phone  { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double getTotal()
        {
            return quantity * price;
        }
    }
}