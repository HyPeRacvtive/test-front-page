using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test_front_page.Models;

namespace test_front_page.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        DataContext context = new DataContext();
        public ActionResult Index()
        {
            var Product = context.Products.ToList().Count();
            ViewBag.Product = Product;
            var Contact = context.Contact.ToList().Count();
            ViewBag.Contact = Contact;
           var Videos = context.Videos.ToList().Count();
            ViewBag.Videos = Videos;
            var Slider = context.Sliders.ToList().Count();
            ViewBag.Slider = Slider;

            return View();
        }

        public ActionResult Social(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialFeed = context.SocialMedia.Find(id);
            if (socialFeed == null)
            {
                return HttpNotFound();
            }
            return View(socialFeed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Social([Bind(Include = "Id,FaceBook,Instagram,Youtube")] SocialMedia socialFeed)
        {
            if (ModelState.IsValid)
            {
                context.Entry(socialFeed).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Social/1");
            }
            return View(socialFeed);
        }




        #region ADMİN PROFİL
        public ActionResult AdminProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = context.Admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminProfile([Bind(Include = "Id,UserName,Password,Mail,NameSurname,Phone,Image,Address,AdminAbout")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string FileName = Path.GetFileName(Request.Files[0].FileName);
                    //Extension
                    _ = Path.GetExtension(Request.Files[0].FileName);
                    string Map = @"~\Content\AdminStyle\assets\img\" + FileName;
                    Request.Files[0].SaveAs(Server.MapPath(Map));
                    admin.Image = FileName;
                }
                context.Entry(admin).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }
        #endregion
        #region ÜRÜNLER
        /*ÜRÜNLER*/
        public ActionResult ProductList()
        {
            return PartialView(context.Products.OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult ProductCreate()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductCreate([Bind(Include = "Id,Name,Image,Width,Height,Stock,Statu,AddedDate")] Products products)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string FileName = Path.GetFileName(Request.Files[0].FileName);
                    string Extension = Path.GetExtension(Request.Files[0].FileName);
                    string Map = @"~/Content/img/Product/" + FileName;
                    Request.Files[0].SaveAs(Server.MapPath(Map));
                    products.Image = FileName;
                }
                context.Products.Add(products);
                context.SaveChanges();
                return RedirectToAction("ProductList");
            }

            return View(products);
        }

        public ActionResult ProductDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = context.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        [HttpPost, ActionName("ProductDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = context.Products.Find(id);
            context.Products.Remove(products);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = context.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit([Bind(Include = "Id,Name,Image,Width,Height,Stock,Statu,AddedDate")] Products products)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string FileName = Path.GetFileName(Request.Files[0].FileName);
                    string Extension = Path.GetExtension(Request.Files[0].FileName);
                    string Map = @"~/Content/img/Product/" + FileName;
                    Request.Files[0].SaveAs(Server.MapPath(Map));
                    products.Image = FileName;
                }
                context.Entry(products).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View(products);
        }
        #endregion
        #region MESAJLAR
        /*MESAJLAR*/
        public ActionResult MessagesList()
        {
            return View(context.Contact.OrderByDescending(x=>x.Id).ToList());
        }
        public ActionResult MessagesDetails(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = context.Contact.Find(id);
            if (!messages.IsRead)
            {
                messages.IsRead = true;
            }
            context.SaveChanges();
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        public ActionResult MessagesDelete(int? id)
        {
            Messages messages = context.Contact.Find(id);
            context.Contact.Remove(messages);
            context.SaveChanges();
            return RedirectToAction("MessagesList");
        }

        [HttpPost, ActionName("MessagesDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult MessagesDeleteConfirmed(int id)
        {
            Messages messages = context.Contact.Find(id);
            context.Contact.Remove(messages);
            context.SaveChanges();
            return RedirectToAction("MessagesList");
        }

        #endregion
        #region VİDEOLAR

        public ActionResult VideosList()
        {
            return View(context.Videos.OrderByDescending(x => x.Id).ToList());
        }

        public ActionResult VideosCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VideosCreate([Bind(Include = "Id,Image,Link")] Videos videos)
        {
            if (ModelState.IsValid)
            {
                /*D:\MEHMET\Projeler\test-fr%ont-page\Content\HomeStyle\assets\img\card-test-image\*/
                if (Request.Files.Count > 0)
                {
                    string FileName = Path.GetFileName(Request.Files[0].FileName);
                    string Extension = Path.GetExtension(Request.Files[0].FileName);
                    string Map = @"~/Content/HomeStyle/assets/img/VideosImages/" + FileName;
                    Request.Files[0].SaveAs(Server.MapPath(Map));
                    videos.Image = FileName;
                }
                context.Videos.Add(videos);
                context.SaveChanges();
                return RedirectToAction("VideosList");
            }

            return View(videos);
        }


        public ActionResult VideosDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videos videos = context.Videos.Find(id);
            if (videos == null)
            {
                return HttpNotFound();
            }
            return View(videos);
        }

        [HttpPost, ActionName("VideosDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult VideosDeleteConfirmed(int id)
        {
            Videos videos = context.Videos.Find(id);
            context.Videos.Remove(videos);
            context.SaveChanges();
            return RedirectToAction("VideosList");
        }




        #endregion
        #region SLİDERLAR

        public ActionResult SliderList()
        {
            return View(context.Sliders.OrderByDescending(x => x.Id).ToList());
        }

        public ActionResult SliderCreate()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SliderCreate([Bind(Include = "Id,Header,Content,Image")] Sliders sliders)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string FileName = Path.GetFileName(Request.Files[0].FileName);
                    string Extension = Path.GetExtension(Request.Files[0].FileName);
                    string Map = @"~/Content/img/Slider/" + FileName;
                    Request.Files[0].SaveAs(Server.MapPath(Map));
                    sliders.Image = FileName;
                }

                context.Sliders.Add(sliders);
                context.SaveChanges();
                return RedirectToAction("SliderList");
            }

            return View(sliders);
        }


        public ActionResult SliderEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sliders sliders = context.Sliders.Find(id);
            if (sliders == null)
            {
                return HttpNotFound();
            }
            return View(sliders);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SliderEdit([Bind(Include = "Id,Header,Content,Image")] Sliders sliders)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string FileName = Path.GetFileName(Request.Files[0].FileName);
                    string Extension = Path.GetExtension(Request.Files[0].FileName);
                    string Map = @"~/Content/img/Slider/" + FileName;
                    Request.Files[0].SaveAs(Server.MapPath(Map));
                    sliders.Image = FileName;
                }

                context.Entry(sliders).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("SliderList");
            }
            return View(sliders);
        }

        public ActionResult SliderDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sliders sliders = context.Sliders.Find(id);
            if (sliders == null)
            {
                return HttpNotFound();
            }
            return View(sliders);
        }

        [HttpPost, ActionName("SliderDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SliderDeleteConfirmed(int id)
        {
            Sliders sliders = context.Sliders.Find(id);
            context.Sliders.Remove(sliders);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }




        public ActionResult SliderConfirm(int id)
        {
            Sliders slider = context.Sliders.Find(id);
            if (!slider.Statu)
            {
                slider.Statu = true;
            }
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }
        public ActionResult SliderUnConfirm(int id)
        {
            Sliders slider = context.Sliders.Find(id);
            if (slider.Statu)
            {
                slider.Statu = false;
            }
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        #endregion

        #region AYARLAR
        public ActionResult About(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About About = context.About.Find(id);
            if (About == null)
            {
                return HttpNotFound();
            }
            return View(About);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult About([Bind(Include = "Id,text,Image")] About About)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string FileName = Path.GetFileName(Request.Files[0].FileName);
                    string Extension = Path.GetExtension(Request.Files[0].FileName);
                    string Map = @"~/Content/img/About/" + FileName;
                    Request.Files[0].SaveAs(Server.MapPath(Map));
                    About.Image = FileName;
                }

                context.Entry(About).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("About/1");
            }
            return View(About);
        }

        public ActionResult GeneralSettings(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Settings setting = context.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GeneralSettings([Bind(Include = "Id,Logo,ProjectText,Phone,Mail,Address,Map")] Settings setting)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string FileName = Path.GetFileName(Request.Files[0].FileName);
                    string Extension = Path.GetExtension(Request.Files[0].FileName);
                    string Map = @"~/Content/img/Logo/" + FileName;
                    Request.Files[0].SaveAs(Server.MapPath(Map));
                    setting.Logo = FileName;
                }

                context.Entry(setting).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GeneralSettings/1");
            }
            return View(setting);
        }



        #endregion



        #region PARTİAL VİEW
        /*Partial Views*/
        public ActionResult _AdminSideBar()
        {
            return PartialView(context.Admin.FirstOrDefault());
        }


        public ActionResult _MessagesNotification()
        {
            return PartialView(context.Contact.OrderByDescending(x => x.IsRead == false).ThenByDescending(x => x.Time).ToList());
        }
        public ActionResult _MessagesCount()
        {
            return PartialView(context.Contact.Where(x => x.IsRead == false).OrderByDescending(x => x.Id).ToList());
        }



        #endregion

    }
}