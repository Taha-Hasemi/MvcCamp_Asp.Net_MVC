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
    public class GraphicsController : Controller
    {
        // GET: Graphics
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChartIndex()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(GetCategoryStatus(), JsonRequestBehavior.AllowGet);
        }
        public List<Category> GetCategoryStatus()
        {
            var values= headingManager.List().GroupBy(x => x.CategoryID).SelectMany(x => categoryManager.List().Where(y => y.CategoryID == x.Key).ToList() , (x,y)=>new { Key = y.CategoryName, Count = x.Count() }).ToList();
            List<Category> values2 = new List<Category>();
            foreach (var item in values)
            {
                values2.Add(new Category { CategoryID = Convert.ToInt32(item.Count), CategoryName = item.Key.ToString() });
            }

            return values2;
        }
    }
}