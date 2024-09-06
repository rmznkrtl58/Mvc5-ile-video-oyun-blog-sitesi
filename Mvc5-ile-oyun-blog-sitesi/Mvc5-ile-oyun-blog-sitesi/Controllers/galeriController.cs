using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;
using Mvc5_ile_oyun_blog_sitesi.Models.sınıflar;

namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{   [AllowAnonymous]
    public class galeriController : Controller
    {
        // GET: galeri
        Class1 cs = new Class1();
        dboyunblogEntities ent = new dboyunblogEntities();
        public ActionResult Index()
        {
            cs.blg = ent.tbl_bloglar.Where(x => x.BSil == true).ToList();
            return View(cs);
        }
    }
}