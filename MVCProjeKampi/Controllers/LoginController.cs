using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var result = adminManager.Login(admin);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.AdminUserName, false);
                Session["AdminUserName"] = result.AdminUserName;
                Session["AdminID"] = result.AdminID;
                Session["AdminMail"] = result.AdminMail;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.Wrong = true;
            }
            return View();
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LeoBJ8cAAAAAGwQ87ftch_1kH3TdiwZXrBjRNWO";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";


            var writerResult = writerManager.Login(writer);
            if (writerResult != null/*&& status*/)
            {
                FormsAuthentication.SetAuthCookie(writerResult.WriterName + writer.WriterSurName, false);
                Session["WriterMail"] = writerResult.WriterMail;
                Session["WriterID"] = writerResult.WriterID;
                Session["WriterName"] = writerResult.WriterName;
                Session["WriterSurName"] = writerResult.WriterSurName;
                Session["WriterImage"] = writerResult.WriterImage;
                return RedirectToAction("Index", "WriterProfile");
            }
            else
            {
                ViewBag.Wrong = true;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Captcha()
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "Your secret here";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";

            //When you will post form for save data, you should check both the model validation and google recaptcha validation
            //EX.
            /* if (ModelState.IsValid && status)
            {

            }*/

            //Here I am returning to Index page for demo perpose, you can use your view here
            return View("Index");
        }

        //LogOut
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}