using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class SkillsProfileController : Controller
    {
        // GET: SkillsProfile
        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public ActionResult Index(int id=1)
        {
            var values = skillManager.GetByID(id);
            return View(values);
        }
    }
}