using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutDegerler = aboutManager.List();
            return View(aboutDegerler);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.Add(about);
            return RedirectToAction("Index");
        }
        public ActionResult Active(int id)
        {
            var value = aboutManager.GetByID(id);
            value.AboutState = true;
            aboutManager.AboutUpdate(value);
            return RedirectToAction("Index");
        }
        public ActionResult Passive(int id)
        {
            var value = aboutManager.GetByID(id);
            value.AboutState = false;
            aboutManager.AboutUpdate(value);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}