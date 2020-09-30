using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Models
{
    public class Order
    {
        public int id { get; set; }
        public List<ItemLine> itemLines { get; set; }
        public double getTotalPrice() {
            if (itemLines == null) return 0;
            double sum = 0;
            foreach (ItemLine itemLine in itemLines)
            {
                sum += itemLine.getTotal();
            }
            return sum;
        }
        public User user { get; set; }
        public String customerName { get; set; }
        public String phoneNumber { get; set; }
        public String address { get; set; }
        public ItemLine getItemLineOfPhone(Phone phone)
        {
            ItemLine itemLine = itemLines.Where(i => i.phone == phone).FirstOrDefault();
            return itemLine;
        }
    }
}