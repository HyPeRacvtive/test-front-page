using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using test_front_page.Models;

namespace test_front_page.Controllers
{
    public class SecurityController : Controller
    {
        DataContext context = new DataContext();    
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin a)
        {
            var Login = context.Admin.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);

            if (Login != null)
            {
                Session["AdminUser"] = Login.NameSurname;
                FormsAuthentication.SetAuthCookie(Login.UserName, false);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.ErrorLogin = "Kullanıcı Adı Veya Parola Hatalı";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}