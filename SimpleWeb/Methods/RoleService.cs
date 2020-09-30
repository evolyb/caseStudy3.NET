using SimpleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWeb.Methods
{
    public class RoleService
    {
        private static List<Role> roles;
        private void initData()
        {
            if (roles == null)
            {
                roles = new List<Role>();
                roles.Add(new Role() { id = 1, name = "ADMIN" });
                roles.Add(new Role() { id = 2, name = "USER" });
            }
        }
        public List<Role> getAllRoles()
        {
            initData();
            return roles;
        }
        public Role getRoleById(int id)
        {
            initData();
            foreach (Role role in roles)
            {
                if (role.id == id) return role;
            }
            return null;
        }
    }
}