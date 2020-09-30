using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Methods
{
    public class UserService
    {
        private static List<User> users;
        public void initData()
        {
            if (users == null)
            {
                users = new List<User>();
                users.Add(new User() { id = 1, username = "admin", password = "z", role = new Role() { id = 1, name="ADMIN" },fullname="Đoàn Hùng Dũng",email="admin@gmail.com", phoneNumber="0972060092",address="Hà Nội" });
                users.Add(new User() { id = 2, username = "map", password = "z", role = new Role() { id = 2, name = "USER" }, fullname = "Trần Văn A", email = "A@gmail.com", phoneNumber = "01234567890", address = "Nam Định" } );
                users.Add(new User() { id = 3, username = "tung", password = "z", role = new Role() { id = 2, name = "USER" }, fullname = "Văn Thanh Tùng", email = "tung@gmail.com", phoneNumber = "0987654321", address = "Hà Nội" });
            }
        }
        public List<User> getAllUsers()
        {
            initData();
            return users;
        }
        public User getUserByUserName(String username)
        {
            initData();
            List<User> allUsers = getAllUsers();
            foreach (User user in allUsers)
            {
                if (user.username.ToUpper().Equals(username.ToUpper())) return user;
            }
            return null;
        }
        public User getUserById(int id)
        {
            initData();
            foreach (User user in users)
            {
                if (user.id == id) return user;
            }
            return null;
        }
        public void removeUserById(int id)
        {
            User user = getUserById(id);
            users.Remove(user);
        }
        public void save(User user)
        {
            initData();
            users.Add(user);
        }
    }
}