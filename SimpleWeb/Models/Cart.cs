using SimpleWeb.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Models
{
    public class Cart
    {
        public List<ItemLine> listItemsLine { get; set; }
        public ItemLine GetItemLineById(int id)
        {
            foreach (ItemLine itemLine in listItemsLine)
            {
                if (itemLine.phone.id == id) return itemLine;
            }
            Phone myPhone = PhoneService.getPhoneById(id);
            ItemLine newItemLine = new ItemLine()
            {
                phone = myPhone,
                price = myPhone.price
            };
            listItemsLine.Add(newItemLine);
            return newItemLine;
        }
        public double getTotalPrice()
        {
            double sum = 0;
            foreach (ItemLine itemLine in listItemsLine)
            {
                sum += itemLine.price*itemLine.quantity;
            }
            return sum;
        }
    }
}