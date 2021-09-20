using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var result = adminManager.Login(admin);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.AdminUserName, false);
                Session["AdminUserName"] = result.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.Wrong = true;
            }
            return View();
        }
    }
}