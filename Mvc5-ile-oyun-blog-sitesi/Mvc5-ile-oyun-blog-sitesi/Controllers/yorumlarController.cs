using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;
using Mvc5_ile_oyun_blog_sitesi.Models.sınıflar;

namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{
    public class yorumlarController : Controller
    {
        // GET: yorumlar
        dboyunblogEntities ent = new dboyunblogEntities();
        public ActionResult Index(string y)
        {
            var yliste = from x in ent.tbl_yorumlar select x;
            yliste = yliste.Where(x => x.YSil == true);
            if (!string.IsNullOrEmpty(y))
            {
                yliste = yliste.Where(x => x.tbl_bloglar.BlogBaslik.Contains(y) && x.YSil == true);
            }
            return View(yliste.ToList());
        }
        public ActionResult ysil(int id)
        {
            var ybul = ent.tbl_yorumlar.Find(id);
            ybul.YSil = false;
            ent.SaveChanges();
            return RedirectToAction("Index", "yorumlar");
        }
        [HttpGet]
        public ActionResult ygetir(int id)
        {
            List<SelectListItem> bloglis = (from x in ent.tbl_bloglar.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.BlogBaslik,
                                                Value = x.BlogId.ToString()
                                            }
                                         ).ToList();
            ViewBag.blg = bloglis;
            var ybul = ent.tbl_yorumlar.Find(id);
            return View("ygetir",ybul);
        }
        [HttpPost]
        public ActionResult yguncelle(tbl_yorumlar y)
        {
            var blg = ent.tbl_bloglar.Where(x => x.BlogId == y.tbl_bloglar.BlogId).FirstOrDefault();
            var ybul = ent.tbl_yorumlar.Find(y.Id);
            ybul.AdSoyad = y.AdSoyad;
            ybul.Blog = blg.BlogId;
            ybul.Eposta = y.Eposta;
            ybul.Yorum = y.Yorum;
            ybul.YSil = true;
            ent.SaveChanges();
            return RedirectToAction("Index", "yorumlar");
        }
    }
}