using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;

namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{
    public class ayarlarController : Controller
    {
        // GET: ayarlar
        dboyunblogEntities ent = new dboyunblogEntities();
        public ActionResult Index()
        {
            var adminliste = ent.tbl_Admin.ToList();
            return View(adminliste);
        }
        public ActionResult agetir(int id)
        {
            var adminbul = ent.tbl_Admin.Find(id);
            return View("agetir",adminbul);
        }
        public ActionResult agüncelle(tbl_Admin a)
        {
            var adminbul = ent.tbl_Admin.Find(a.Id);
            adminbul.Sifre = a.Sifre;
            ent.SaveChanges();
            return RedirectToAction("Index", "ayarlar");
        }
    }
}