using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MVCProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class GraphicsController : Controller
    {
        // GET: Graphics
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChartIndex()
        {
            return View();
        }
        public ActionResult HeadingChartIndex()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(GetCategoryStatus(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult HeadingChart()
        {
            return Json(GetHeadingStatus(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryChart> GetCategoryStatus()
        {
            var values= headingManager.List().GroupBy(x => x.CategoryID).SelectMany(x => categoryManager.List().Where(y => y.CategoryID == x.Key).ToList() , (x,y)=>new { Key = y.CategoryName, Count = x.Count() }).ToList();
            List<CategoryChart> values2 = new List<CategoryChart>();
            foreach (var item in values)
            {
                values2.Add(new CategoryChart { Count = Convert.ToInt32(item.Count), Name = item.Key.ToString() });
            }

            return values2;
        }
        public List<HeadingChart> GetHeadingStatus()
        {
            var values = contentManager.List().GroupBy(x => x.Heading.HeadingName).ToList();
            List<HeadingChart> values2 = new List<HeadingChart>();
            foreach (var item in values)
            {
                values2.Add(new HeadingChart { Count = Convert.ToInt32(item.Count()), Name = item.Key.ToString() });
            }

            return values2;
        }
    }
}