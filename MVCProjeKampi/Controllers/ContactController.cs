using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = contactManager.List();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult LeftMenuPartial()
        {
            var contactCount = contactManager.List().Where(x => !x.MessageRead).Count();
            ViewBag.contactCount = contactCount;

            var inboxCount = messageManager.ListInbox("admin@gmail.com").Where(x => !x.MessageRead).Count();
            ViewBag.inboxCount = inboxCount;

            var sendboxCount = messageManager.ListSendbox(6).Where(x => !x.MessageRead).Count();
            ViewBag.sendboxCount = sendboxCount;
            return PartialView();
        }
    }
}