using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;
using PagedList;
using PagedList.Mvc;

namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{
    public class kategoriController : Controller
    {
        // GET: kategori
        dboyunblogEntities ent = new dboyunblogEntities();
        public ActionResult Index(string k,int sayfa=1)
        {
            var kategorilist = from x in ent.tbl_kategoriler select x;
            kategorilist = kategorilist.Where(x => x.KategoriSil == true);
            if (!string.IsNullOrEmpty(k))
            {
                kategorilist = kategorilist.Where(x => x.KategoriAd.Contains(k)&&x.KategoriSil==true);
            }
            return View(kategorilist.ToList().ToPagedList(sayfa,4));
        }
        [HttpGet]
        public ActionResult yenikategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenikategori(tbl_kategoriler k)
        {
            k.KategoriSil = true;
            ent.tbl_kategoriler.Add(k);
            ent.SaveChanges();
            return RedirectToAction("Index","kategori");
        }
        public ActionResult ksil(tbl_kategoriler k)
        {
            var kategoribul = ent.tbl_kategoriler.Find(k.Id);
            kategoribul.KategoriSil = false;
            ent.SaveChanges();
            return RedirectToAction("Index", "kategori");
        }
        [HttpGet]
        public ActionResult kgetir(tbl_kategoriler k)
        {
            var kategoribul = ent.tbl_kategoriler.Find(k.Id);
            return View("kgetir",kategoribul);
        }
        [HttpPost]
        public ActionResult kguncelle(tbl_kategoriler k)
        {
            var kbul = ent.tbl_kategoriler.Find(k.Id);
            kbul.KategoriAd = k.KategoriAd;
            ent.SaveChanges();
            return RedirectToAction("Index", "kategori");
        }
    }
}