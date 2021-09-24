using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            var values = contentManager.List();
            return View(values);
        }
        public ActionResult SearchContent(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                var values = contentManager.List(word);
                return View(values);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public PartialViewResult SearchMenu()
        {
            return PartialView();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.ListByHeadingID(id);
            return View(contentValues);
        }
    }
}