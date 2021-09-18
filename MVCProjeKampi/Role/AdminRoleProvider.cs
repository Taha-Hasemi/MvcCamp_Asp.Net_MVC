using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EntityLayer.Concrete;

namespace MVCProjeKampi.Role
{
    public class AdminRoleProvider : RoleProvider
    {
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            List<string> a=new List<string>();
            //var value = roleManager.List().Where(x => x.Admin.AdminUserName == username).Select(x => new { RoleName = x.RoleName });
            var value = (from x in roleManager.List()
                         join y in adminManager.List()
                         on x.AdminID equals y.AdminID
                        where y.AdminUserName == username
                         select new
                         {
                             RoleName = x.RoleName
                         });
            foreach (var item in value)
            {
                a.Add(item.RoleName);
            }
            return a.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}