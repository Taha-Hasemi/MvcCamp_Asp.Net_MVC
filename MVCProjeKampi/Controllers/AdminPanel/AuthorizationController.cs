using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        RoleManager roleManager = new RoleManager(new EfRoleDal());

        public ActionResult Index()
        {
            var values = adminManager.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            admin.AdminStatus = true;
            adminManager.AdminAdd(admin);
            admin.UserRoles.Add(admin.UserRoles[0]);
            return RedirectToAction("Index");
        }
        public ActionResult UserRoleIndex(int id)
        {
            ViewBag.AdminID = id;
            var values = roleManager.GetByAdminID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddRole(int id)
        {
            ViewBag.AdminID = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(UserRole role)
        {
            roleManager.RoleAdd(role);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteRole(int id)
        {
            roleManager.DeleteRoleByID(id);
            return RedirectToAction("Index");
        }

        public ActionResult Active(int id)
        {
            adminManager.Active(id);
            return RedirectToAction("Index");
        }
        public ActionResult Passive(int id)
        {
            adminManager.Passive(id);
            return RedirectToAction("Index");
        }
    }
}