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

        public void Active(int id)
        {
            var admin = _adminDal.Get(x => x.AdminID == id);
            admin.AdminStatus = true;
            _adminDal.Update(admin);
        }

        public void AdminAdd(Admin admin)
        {
            //ForOnHashing
            byte[] veridizim = ASCIIEncoding.ASCII.GetBytes(admin.AdminPassword);
            admin.AdminPassword = Convert.ToBase64String(veridizim);

            byte[] veridizim2 = ASCIIEncoding.ASCII.GetBytes(admin.AdminUserName);
            admin.AdminUserName = Convert.ToBase64String(veridizim2);

            _adminDal.Insert(admin);
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
            var admin = _adminDal.List();

            try
            {
                foreach (var item in admin)
                {
                    byte[] cozulenvarilerim = Convert.FromBase64String(item.AdminPassword);
                    item.AdminPassword = ASCIIEncoding.ASCII.GetString(cozulenvarilerim);

                    byte[] cozulenvarilerim2 = Convert.FromBase64String(item.AdminUserName);
                    item.AdminUserName = ASCIIEncoding.ASCII.GetString(cozulenvarilerim2);
                }
            }
            catch (Exception)
            {

            }
            return admin;
        }

        public Admin Login(Admin admin)
        {
            //Hashing
            byte[] veridizim = ASCIIEncoding.ASCII.GetBytes(admin.AdminPassword);
            admin.AdminPassword = Convert.ToBase64String(veridizim);

            byte[] veridizim2 = ASCIIEncoding.ASCII.GetBytes(admin.AdminUserName);
            admin.AdminUserName = Convert.ToBase64String(veridizim2);

            var admin2 = _adminDal.List().FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);

            if (admin2 != null)
            {
                byte[] cozulenvarilerim = Convert.FromBase64String(admin2.AdminPassword);
                admin2.AdminPassword = ASCIIEncoding.ASCII.GetString(cozulenvarilerim);

                byte[] cozulenvarilerim2 = Convert.FromBase64String(admin2.AdminUserName);
                admin2.AdminUserName = ASCIIEncoding.ASCII.GetString(cozulenvarilerim2);
            }

            return admin2;
        }

        public void Passive(int id)
        {
            var admin = _adminDal.Get(x => x.AdminID == id);
            admin.AdminStatus = false;
            _adminDal.Update(admin);
        }
    }
}
