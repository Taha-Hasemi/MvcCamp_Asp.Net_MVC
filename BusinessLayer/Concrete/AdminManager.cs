using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            //ForOnHashing
            //byte[] cozulenvarilerim = Convert.FromBase64String(admin.AdminPassword);
            //admin.AdminPassword = ASCIIEncoding.ASCII.GetString(cozulenvarilerim);
        }

        public void AdminDelete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> List()
        {
            return _adminDal.List();
        }

        public Admin Login(Admin admin)
        {
            //Hashing
            byte[] veridizim = ASCIIEncoding.ASCII.GetBytes(admin.AdminPassword);
            admin.AdminPassword = Convert.ToBase64String(veridizim);

            byte[] veridizim2 = ASCIIEncoding.ASCII.GetBytes(admin.AdminUserName);
            admin.AdminUserName = Convert.ToBase64String(veridizim2);

            return _adminDal.List().FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
        }
    }
}
