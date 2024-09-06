using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;


namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{
    public class duyurularController : Controller
    {
        dboyunblogEntities ent = new dboyunblogEntities();
        // GET: duyurular
        public ActionResult Index()
        {
            var dliste = ent.tbl_duyurular.ToList();
            return View(dliste);
        }
        public ActionResult dgetir(int id)
        {
            var dbul = ent.tbl_duyurular.Find(id);
            return View("dgetir",dbul);
        }
        public ActionResult dguncelle(tbl_duyurular d)
        {
            var dbul = ent.tbl_duyurular.Find(d.Id);
            dbul.Konu = d.Konu;
            dbul.Acıklama = d.Acıklama;
            ent.SaveChanges();
            return RedirectToAction("Index", "duyurular");
        }
    }
}