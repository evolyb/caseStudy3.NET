using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Models
{
    public class User
    {
        public int id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public Role role { get; set; }
        public String fullname { get; set; }
        public String email { get; set; }
        public String phoneNumber { get; set; }
        public String address { get; set; }
    }
}