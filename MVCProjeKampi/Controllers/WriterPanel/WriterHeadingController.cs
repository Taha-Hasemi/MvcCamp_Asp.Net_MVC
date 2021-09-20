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
    public class WriterHeadingController : Controller
    {
        // GET: WriterHeading
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var values = headingManager.List().Where(x => x.WriterID == 1).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.CategoryValue = categoryValue;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Now;
            //Session işlemleri yapılsın
            heading.WriterID = 1;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.CategoryValue = categoryValue;
            var headingValue = headingManager.GetByID(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetByID(id);
            if (headingValue.HeadingStatus)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }
            headingManager.DeleteHeading(headingValue);
            return RedirectToAction("Index");
        }
    }
}