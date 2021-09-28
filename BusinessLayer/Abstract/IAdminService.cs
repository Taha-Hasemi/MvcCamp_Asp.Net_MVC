using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IAdminService
    {
        List<Admin> List();
        Admin Login(Admin admin);
        void AdminAdd(Admin admin);
        Admin GetByID(int id);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
        void Active(int id);
        void Passive(int id);
    }
}
