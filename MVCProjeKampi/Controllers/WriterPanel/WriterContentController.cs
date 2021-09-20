using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}