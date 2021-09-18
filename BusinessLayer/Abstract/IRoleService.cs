using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Abstract
{
    interface IRoleService
    {
        List<UserRole> List();
        void RoleAdd(UserRole role);
        UserRole GetByID(int id);
        void DeleteRole(UserRole role);
        void RoleUpdate(UserRole role);
    }
}
