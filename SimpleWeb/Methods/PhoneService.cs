using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Methods
{
    public class PhoneService
    {
        private OrderService orderService = new OrderService();
        private static List<Phone> listPhone;
        public static void initData()
        {
            if (listPhone.Count == 0)
            {
                listPhone = new List<Phone>();
                listPhone.Add(new Phone() { id = 1, name = "Iphone X", price = 1000, brand_id = 2, imgSrc = "/Content/images/iphoneX.jpg", shortDescription = "New Iphone X. FullBox", sold = 5 });
                listPhone.Add(new Phone() { id = 2, name = "Iphone 8", price = 800, brand_id = 2, imgSrc = "/Content/images/iphone8.jpg", shortDescription = "New Iphone 8. FullBox", sold = 5 });
                listPhone.Add(new Phone() { id = 3, name = "Samsung Note 8", price = 700, brand_id = 1, imgSrc = "/Content/images/note8.jpg", shortDescription = "Old phone 99%", sold = 8 });
                listPhone.Add(new Phone() { id = 4, name = "Samsung Note 20", price = 1200, brand_id = 1, imgSrc = "/Content/images/note20.jpg", shortDescription = "PreOrder. FullBox", sold = 4 });
                listPhone.Add(new Phone() { id = 5, name = "OPPO Reno3", price = 750, brand_id = 3, imgSrc = "/Content/images/oppoReno3.jpg", shortDescription = "Tặng 100.000₫ khi mua Online", sold = 6 });
                listPhone.Add(new Phone() { id = 6, name = "Samsung Note 10", price = 950, brand_id = 1, imgSrc = "/Content/images/note10.jpg", shortDescription = "Nguyên Seal", sold = 6 });
            }
        }
        public static List<Phone> getAllPhones()
        {
            if (listPhone == null)
            {
                listPhone = new List<Phone>();
                initData();
            }
            return listPhone;
        }
        public static List<Phone> getFavoritePhones()
        {
            List<Phone> listAllPhones = getAllPhones();
            listAllPhones.Sort((x, y) => (y.sold - x.sold));
            List<Phone> listFavoritePhones = listAllPhones.GetRange(0, Math.Min(4,listAllPhones.Count));
            return listFavoritePhones;
        }
        public static List<Phone> getPhonesByBrand(int brand_id)
        {
            List<Phone> listAllPhones = getAllPhones();
            List<Phone> listPhones = new List<Phone>();
            foreach (Phone phone in listAllPhones)
            {
                if (phone.brand_id == brand_id)
                {
                    listPhones.Add(phone);
                }
            }
            return listPhones;
        }
        public static List<Phone> getPhonesByName(String name)
        {
            List<Phone> listAllPhones = getAllPhones();
            List<Phone> listPhones = new List<Phone>();
            if (name == null) name = "";
            foreach (Phone phone in listAllPhones)
            {
                if (phone.name.ToUpper().Contains(name.ToUpper()))
                {
                    listPhones.Add(phone);
                }
            }
            return listPhones;
        }
        public static Phone getPhoneById(int id)
        {
            List<Phone> listPhones = getAllPhones();
            foreach ( Phone phone in listPhones)
            {
                if (phone.id == id) return phone;
            }
            return null;
        }
        public static void removeById(int id)
        {
            listPhone.Remove(getPhoneById(id));
        }
        public static List<Phone> SortByName()
        {
            List<Phone> listPhones = getAllPhones();
            listPhones.Sort((a, b) =>
            {
                return a.name.CompareTo(b.name);
            });
            return listPhones;
        }
        public static List<Phone> SortByPrice()
        {
            List<Phone> listPhones = getAllPhones();
            listPhones.Sort((a, b) =>
            {
                return a.price.CompareTo(b.price);
            });
            return listPhones;
        }
        public static List<Phone> SortByBrand()
        {
            List<Phone> listPhones = getAllPhones();
            listPhones.Sort((a, b) =>
            {
                return a.getBrand().name.CompareTo(b.getBrand().name);
            });
            return listPhones;
        }
    }
}