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
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void DeleteRole(UserRole role)
        {
            _roleDal.Delete(role);
        }

        public UserRole GetByID(int id)
        {
            return _roleDal.Get(x => x.RoleID == id);
        }

        public List<UserRole> List()
        {
            return _roleDal.List();
        }

        public void RoleAdd(UserRole role)
        {
            _roleDal.Insert(role);
        }

        public void RoleUpdate(UserRole role)
        {
            _roleDal.Update(role);
        }
    }
}
