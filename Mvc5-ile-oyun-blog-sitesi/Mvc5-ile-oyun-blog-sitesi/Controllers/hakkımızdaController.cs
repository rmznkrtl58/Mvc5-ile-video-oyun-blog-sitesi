using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.sınıflar;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;
namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{
    public class hakkımızdaController : Controller
    {
        // GET: hakkımızda
        dboyunblogEntities ent = new dboyunblogEntities();
        public ActionResult Index()
        {
            return View(ent.tbl_hakkımızda.ToList());
        }
        public ActionResult hgetir(int id)
        {
            var hbul = ent.tbl_hakkımızda.Find(id); 
            return View("hgetir",hbul);
        }
        public ActionResult hgüncelle(tbl_hakkımızda h)
        {
            var hbul = ent.tbl_hakkımızda.Find(h.Id);
            hbul.Acıklama = h.Acıklama;
            ent.SaveChanges();
            return RedirectToAction("Index", "hakkımızda");
        }
    }
}