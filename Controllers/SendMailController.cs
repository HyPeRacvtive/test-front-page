using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_front_page.Models;

namespace test_front_page.Controllers
{
    public class SendMailController : Controller
    {
        DataContext context = new DataContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SendMessage(Messages contact)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (ModelState.IsValid)
            {
                contact.IpAdress = ip;
                context.Contact.Add(contact);
                context.SaveChanges();
                return Json(new { IsSuccess = true, Message = "Başarılı" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kayıt hatası" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}