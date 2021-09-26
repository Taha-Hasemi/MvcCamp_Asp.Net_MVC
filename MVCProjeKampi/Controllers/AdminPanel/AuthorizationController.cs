using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers.AdminPanel
{
    [Authorize(Roles = "Admin")]
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        RoleManager RoleManager = new RoleManager(new EfRoleDal());

        public ActionResult Index()
        {
            var values = adminManager.List();
            //var values = (from x in adminManager.List()
            //              join y in RoleManager.List()
            //              on x.AdminID equals y.AdminID
            //              select x 
            //              ).ToList();
            return View(values);
        }
    }
}