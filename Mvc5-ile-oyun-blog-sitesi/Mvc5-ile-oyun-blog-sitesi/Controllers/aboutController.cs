using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;
using Mvc5_ile_oyun_blog_sitesi.Models.sınıflar;

namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{   [AllowAnonymous]
    public class aboutController : Controller
    {
        // GET: about
        dboyunblogEntities ent = new dboyunblogEntities();
        Class1 cs = new Class1();
        public ActionResult Index()
        {
            cs.hkm = ent.tbl_hakkımızda.ToList();
            return View(cs);
        }
    }
}