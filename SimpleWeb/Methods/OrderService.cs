using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Methods
{
    public class OrderService
    {
        UserService userService = new UserService();
        private static List<Order> orders;
        private void initData()
        {
            if (orders == null)
            {
                orders = new List<Order>();
                orders.Add(
                    new Order()
                {
                    id = 1,
                    itemLines = new List<ItemLine>() { new ItemLine() { id = 1, phone = PhoneService.getPhoneById(1), quantity = 2, price = PhoneService.getPhoneById(1).price } },
                    user = userService.getUserById(2),
                    customerName = userService.getUserById(2).fullname,
                    phoneNumber = userService.getUserById(2).phoneNumber,
                    address = userService.getUserById(2).address
                    }) ;
                orders.Add(
                    new Order()
                    {
                        id = 2,
                        itemLines = new List<ItemLine>() 
                        { 
                            new ItemLine() { id = 2, phone = PhoneService.getPhoneById(2), quantity = 3, price = PhoneService.getPhoneById(2).price } ,
                            new ItemLine() { id = 3, phone = PhoneService.getPhoneById(3), quantity = 1, price = PhoneService.getPhoneById(3).price }
                        },
                        user = userService.getUserById(3),
                        customerName = userService.getUserById(3).fullname,
                        phoneNumber = userService.getUserById(3).phoneNumber,
                        address = userService.getUserById(3).address
                    });
            }
        }
        public List<Order> getAllOrders()
        {
            initData();
            return orders;
        }
        public Order getOrderById(int id)
        {
            initData();
            Order order = orders.Where(o => o.id == id).FirstOrDefault();
            return order;
        }
        public List<Order> getOrdersByPhone(Phone phone)
        {
            initData();
            List<Order> list = orders.Where(o => o.getItemLineOfPhone(phone) != null).ToList();
            return list;
        }
        public void addOrder(Order order)
        {
            initData();
            orders.Add(order);
        }
        
    }
}