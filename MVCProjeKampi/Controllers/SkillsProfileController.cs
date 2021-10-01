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
    public class SkillsProfileController : Controller
    {
        // GET: SkillsProfile
        SkillManager skillManager = new SkillManager(new EfSkillDal());

        public ActionResult Index()
        {
            var values = skillManager.List();
            return View(values);
        }
        public ActionResult SkillDetails(int id)
        {
            var values = skillManager.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            skillManager.SkillAdd(skill);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skill = skillManager.GetByID(id);
            skillManager.DeleteSkill(skill);
            return RedirectToAction("Index");
        }
    }
}