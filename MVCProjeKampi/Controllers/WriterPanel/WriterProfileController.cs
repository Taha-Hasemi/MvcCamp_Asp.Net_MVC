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

namespace MVCProjeKampi.Controllers.WriterPanel
{
    public class WriterProfileController : Controller
    {
        // GET: WriterProfile
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            int id = (int)Session["WriterID"];
            var values = writerManager.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Writer writer)
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