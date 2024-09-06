using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;
using System.Web.Security;

namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{   [AllowAnonymous]
    public class adminloginController : Controller
    {
        // GET: adminlogin
        dboyunblogEntities ent = new dboyunblogEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_Admin a)
        {
            var bilgiler = ent.tbl_Admin.FirstOrDefault(x => x.KullaniciAdi == a.KullaniciAdi && x.Sifre == a.Sifre);
            if (bilgiler != null)//bu bilgiler değişkenimde veri varsa yani buradaki şartlar
                                 //sağlandıysa
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["kullanıcı"] = bilgiler.KullaniciAdi;
                return RedirectToAction("Index","kategori");
            }
            return View();
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "adminlogin");
        }
    }
}