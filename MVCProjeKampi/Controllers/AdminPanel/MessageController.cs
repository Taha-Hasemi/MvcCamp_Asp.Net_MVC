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
            var messageList = messageManager.ListInbox("admin@gmail.com");
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageList = messageManager.ListSendbox(6);
            return View(messageList);
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
            ViewBag.MessageType = type;
            var messageValues = messageManager.GetByID(id);
            messageValues.MessageRead = true;
            messageManager.MessageUpdate(messageValues);
            return View(messageValues);
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
                //////SEŞŞINDAN SONRA DÜZELTİLSİN/////////
                message.WriterID = 2;
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