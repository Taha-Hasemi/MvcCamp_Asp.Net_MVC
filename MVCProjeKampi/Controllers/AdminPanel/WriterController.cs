using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var writerValue = writerManager.List();
            return View(writerValue);
        }
        public ActionResult SearchWriter(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                var values = writerManager.List(word);
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

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
            {
                Request.Files[0].SaveAs(Server.MapPath("~/Images/" + Request.Files[0].FileName));
                writer.WriterImage = "/Images/" + Request.Files[0].FileName;
            }

            WriterValidator writerValidator = new WriterValidator();
            ValidationResult Results = writerValidator.Validate(writer);
            if (Results.IsValid)
            {
                writerManager.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in Results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writerValue = writerManager.GetByID(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
            {
                Request.Files[0].SaveAs(Server.MapPath("~/Images/" + Request.Files[0].FileName));
                writer.WriterImage = "/Images/" + Request.Files[0].FileName;
            }

            WriterValidator writerValidator = new WriterValidator();
            ValidationResult Results = writerValidator.Validate(writer);
            if (Results.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in Results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}