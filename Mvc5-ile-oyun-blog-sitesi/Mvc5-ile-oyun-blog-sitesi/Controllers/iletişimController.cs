using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.sınıflar;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;

namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{   [AllowAnonymous]
    public class iletişimController : Controller
    {
        // GET: iletişim
        dboyunblogEntities ent = new dboyunblogEntities();
        Class1 cs = new Class1();
        public ActionResult Index()
        {
            cs.iltsm = ent.tbl_iletisim2.ToList();
            return View(cs);
        }
        [HttpGet]
        public PartialViewResult partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult mesaj(tbl_iletisim i)
        {
            ent.tbl_iletisim.Add(i);
            ent.SaveChanges();
            return RedirectToAction("Index","iletişim");
        }
    }
}