using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;
using Mvc5_ile_oyun_blog_sitesi.Models.sınıflar;

namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{
    [AllowAnonymous]
    public class homeController : Controller
    {   
        // GET: home
        dboyunblogEntities ent = new dboyunblogEntities();
        //Ienumerable classı
        Class1 cs = new Class1();
        public ActionResult Index()
        {
            cs.grs = ent.tbl_homegiris.ToList();
            cs.blg = ent.tbl_bloglar.Where(x=>x.BSil==true).ToList();
            return View(cs);
        }
        public PartialViewResult partial1()
        {
            cs.blg = ent.tbl_bloglar.Where(x=>x.BSil==true).OrderByDescending(X => X.BlogTarih).Take(3).ToList();
            return PartialView(cs);
        }
        public PartialViewResult partial2()
        {
            cs.dyr = ent.tbl_duyurular.ToList();
            return PartialView(cs);
        }
        public PartialViewResult partial3()
        {  
            cs.yrm = ent.tbl_yorumlar.OrderByDescending(x => x.YTarih).Take(5).ToList();
            return PartialView(cs);
        }
    }
}