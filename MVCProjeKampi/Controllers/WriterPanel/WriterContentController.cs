using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers.WriterPanel
{
    public class WriterContentController : Controller
    {
        // GET: WriterContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            int id = (int)Session["WriterID"];
            var values = contentManager.ListByWriterID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.HeadingID = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate = DateTime.Now;
            content.WriterID = (int)Session["WriterID"];
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("AllHeading","WriterHeading");
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.ListByHeadingID(id);
            return View(contentValues);
        }
    }
}