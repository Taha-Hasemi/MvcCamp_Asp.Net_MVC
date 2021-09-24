using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVCProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        ContactManager contactManager = new ContactManager(new EfContactDal());
        OtherValuesManager OtherValuesManager = new OtherValuesManager(new EfOtherValuesDal());

        public ActionResult Inbox()
        {
            string mail = (string)Session["AdminMail"];
            var messageList = messageManager.ListInbox(mail);
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            string mail = (string)Session["AdminMail"];
            var messageList = messageManager.ListSendbox(mail);
            return View(messageList);
        }

        public ActionResult SearchMessageInbox(string word)
        {
            string mail = (string)Session["AdminMail"];
            if (!string.IsNullOrEmpty(word))
            {
                var values = messageManager.ListInbox(word, mail);
                return View(values);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult SearchMessageSendbox(string word)
        {
            string mail = (string)Session["AdminMail"];
            if (!string.IsNullOrEmpty(word))
            {
                var values = messageManager.ListSendbox(word, mail);
                return View(values);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public PartialViewResult SearchMenuInbox()
        {
            return PartialView();
        }

        public PartialViewResult SearchMenuSendbox()
        {
            return PartialView();
        }


        public PartialViewResult InboxPartial(int id)
        {
            var messageValues = messageManager.GetByID(id);
            return PartialView(messageValues);
        }

        public PartialViewResult SendboxPartial(int id)
        {
            var messageValues = messageManager.GetByID(id);
            return PartialView(messageValues);
        }

        public ActionResult GetMessageDetails(int id, string type)
        {
            var result = messageManager.Belong(id, (string)Session["AdminMail"]);
            if (result != null)
            {
                ViewBag.MessageType = type;
                var messageValues = messageManager.GetByID(id);
                messageValues.MessageRead = true;
                messageManager.MessageUpdate(messageValues);
                return View(messageValues);
            }
            else
            {
                return RedirectToAction("Page404", "ErrorPage");
            }
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string fileName = OtherValuesManager.GetFileName();


            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (Request.Files[i].FileName != "")
                {
                    string[] uzanti = Request.Files[i].FileName.ToString().Split('.');

                    Request.Files[i].SaveAs(Server.MapPath("~/Files/" + fileName + "." + uzanti[1]));
                    message.FileName = "/Files/" + fileName + "." + uzanti[1];
                }
            }


            ValidationResult result = validationRules.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Now;
                message.MessageStatus = true;
                message.SenderMail = (string)Session["AdminMail"];
                messageManager.MessageAdd(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}