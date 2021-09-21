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
    public class WriterMessageController : Controller
    {
        // GET: WriterMessage
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        ContactManager contactManager = new ContactManager(new EfContactDal());
        OtherValuesManager OtherValuesManager = new OtherValuesManager(new EfOtherValuesDal());

        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.ListInbox(mail);
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.ListSendbox(mail);
            return View(messageList);
        }

        public PartialViewResult LeftMenuPartial()
        {
            string mail = (string)Session["WriterMail"];

            var inboxCount = messageManager.ListInbox(mail).Where(x => !x.MessageRead).Count();
            ViewBag.inboxCount = inboxCount;

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
            var result = messageManager.Belong(id, (string)Session["WriterMail"]);
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
                string writerMail = (string)Session["WriterMail"];
                message.MessageDate = DateTime.Now;
                message.MessageStatus = true;
                message.SenderMail = writerMail;
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