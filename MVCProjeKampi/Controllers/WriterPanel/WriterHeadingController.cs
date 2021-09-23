using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MVCProjeKampi.Controllers.WriterPanel
{
    public class WriterHeadingController : Controller
    {
        // GET: WriterHeading
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            int id = (int)Session["WriterID"];
            var values = headingManager.List().Where(x => x.WriterID == id).ToList();
            return View(values);
        }
        [AllowAnonymous]
        public ActionResult AllHeading(int sayfa = 1)
        {
            var values = headingManager.ListActive().ToPagedList(sayfa,3);
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
            heading.WriterID = (int)Session["WriterID"];
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            int writerID = (int)Session["WriterID"];
            var result = headingManager.Belong(writerID, id);
            if (result != null)
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
            else
            {
                return RedirectToAction("Page404", "ErrorPage");
            }
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            int writerID = (int)Session["WriterID"];
            var result = headingManager.Belong(writerID, id);
            if (result != null)
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
            else
            {
                return RedirectToAction("Page404", "ErrorPage");
            }
        }
    }
}