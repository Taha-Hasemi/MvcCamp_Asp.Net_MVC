using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            //Category Count
            var categoryCount = categoryManager.List().Count();
            ViewBag.CategoryCount = categoryCount;

            //Headings in the Programming Cattegory
            var programmingCategoryCount = headingManager.List().Where(x => x.CategoryID == 8).Count();
            ViewBag.ProgrammingCategoryCount = programmingCategoryCount;

            //Writers with 'a' in their names
            var writerNameContains_a = writerManager.List().Where(x => x.WriterName.Contains("A") || x.WriterName.Contains("a")).Count();
            ViewBag.WriterNameContains_a = writerNameContains_a;

            //Category with the most headings
            var mostHeadings = headingManager.List().Max(x=>x.Category.CategoryName);
            ViewBag.MostHeadings = mostHeadings;

            ///////
            var result1 = categoryManager.List().Where(x => x.CategoryStatus == true).Count();
            var result2 = categoryManager.List().Where(x => x.CategoryStatus == false).Count();
            ViewBag.TrueAndFalseCategory = (result1 - result2).ToString();

            return View();
        }
    }
}