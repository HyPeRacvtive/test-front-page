using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_front_page.Models;

namespace test_front_page.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lahiyeler()
        {
            return View(context.Settings.FirstOrDefault());
        }
        public ActionResult Alaqa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Alaqa(Messages contact)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (ModelState.IsValid)
            {
                contact.IpAdress = ip;
                context.Contact.Add(contact);
                context.SaveChanges();
               // return Json(new { IsSuccess = true, Message = "Başarılı" }, JsonRequestBehavior.AllowGet);
            }
            return View(true);
        }
        public ActionResult _Logo()
        {
            return PartialView(context.Settings.FirstOrDefault());
        }
        public ActionResult _Slider()
        {
            return PartialView(context.Sliders.Where(x=>x.Statu==true).ToList());
        }

        public ActionResult _Product()
        {
            var product = context.Products.Where(x => x.Statu == true).OrderBy(a => Guid.NewGuid()).Take(6).ToList();
            return PartialView(product);
        }

        public ActionResult _About()
        {
            return PartialView(context.About.FirstOrDefault());
        }

        public ActionResult _Header()
        {
            return PartialView(context.Settings.FirstOrDefault());
        }
        public ActionResult _Footer()
        {
            return PartialView(context.Settings.FirstOrDefault());
        }
        public ActionResult _Social()
        {
            return PartialView(context.SocialMedia.FirstOrDefault());
        }
        public ActionResult _Videos()
        {
            return PartialView(context.Videos.OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult _Contact()
        {
            return PartialView(context.Settings.FirstOrDefault());
        }



   






    }
}

