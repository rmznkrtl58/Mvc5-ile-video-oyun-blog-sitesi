using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;
using PagedList.Mvc;
using PagedList;
using Mvc5_ile_oyun_blog_sitesi.Models.sınıflar;


namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{    
    public class bloglarController : Controller
    {
        // GET: bloglar
        dboyunblogEntities ent = new dboyunblogEntities();
        Class1 cs = new Class1();
        [AllowAnonymous]
        public ActionResult Index(string s,int sayfa=1)
        {
            var bloglist = from x in ent.tbl_bloglar select x;
            //tbl bloglar tablomdaki bütün verileri x adındaki değişkenim tutuyor ve
            //blog liste atıyor
            bloglist = bloglist.Where(x => x.BSil == true);
            //blog sil sütunumdaki true olanları blogsil değişkenime ata
            if (!string.IsNullOrEmpty(s))
                //benim s parametremin içi boş değilse bir veri geldiyse
            {
                bloglist = bloglist.Where(x => x.BlogBaslik.Contains(s) && x.BSil == true);
            }
            return View(bloglist.ToList().ToPagedList(sayfa,4));
       
        }
        [HttpGet]
        public ActionResult yeniblog()
        {
            List<SelectListItem> kategorilist = (from x in ent.tbl_kategoriler.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.ktgr = kategorilist;
            return View();
        }
        
        public ActionResult bekle(tbl_bloglar b)
        {
            var ktgr = ent.tbl_kategoriler.Where(x => x.Id == b.tbl_kategoriler.Id).FirstOrDefault();
            b.tbl_kategoriler = ktgr;
            b.BSil = true;
            b.BlogTarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            ent.tbl_bloglar.Add(b);
            ent.SaveChanges();
            return RedirectToAction("Index","bloglar"); 
        }
        public ActionResult bsil(int id)
        {
            var blogbul = ent.tbl_bloglar.Find(id);
            blogbul.BSil = false;
            ent.SaveChanges();
            return RedirectToAction("Index", "bloglar");
        }
        [HttpGet]
        public ActionResult bgetir(int id)
        {
            List<SelectListItem> ktgrliste = (from x in ent.tbl_kategoriler.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.KategoriAd,
                                                  Value = x.Id.ToString()
                                              }).ToList();
            ViewBag.ktgr = ktgrliste;
            var bbul = ent.tbl_bloglar.Find(id);
            return View("bgetir",bbul);
        }
        public ActionResult guncelle(tbl_bloglar b)
        {
            var ktgr = ent.tbl_kategoriler.Where(x => x.Id == b.tbl_kategoriler.Id).FirstOrDefault();
            var bbul = ent.tbl_bloglar.Find(b.BlogId);
            bbul.BlogAciklama = b.BlogAciklama;
            bbul.BlogBaslik = b.BlogBaslik;
            bbul.BlogResim = b.BlogResim;
            bbul.BlogTarih = DateTime.Parse(DateTime.Today.ToLongDateString());
            bbul.BSil = true;
            bbul.BlogKategori = ktgr.Id;
            ent.SaveChanges();
            return RedirectToAction("Index", "bloglar");
        }
        [AllowAnonymous]
       public ActionResult blogdetay(int sayfa=1)
        {
            var bloglist = ent.tbl_bloglar.Where(x => x.BSil == true).ToList().ToPagedList(sayfa,6);
            return View(bloglist);
        }
        [AllowAnonymous]
        public ActionResult blogiçerik(int id)
        {   
            cs.blg = ent.tbl_bloglar.Where(x => x.BlogId == id&&x.BSil==true).ToList();
            cs.yrm = ent.tbl_yorumlar.Where(x => x.Blog == id).ToList();
            cs.yrm2 = ent.tbl_yorumlar.OrderByDescending(x => x.YTarih).Take(5).ToList();
            return View(cs);
        }
        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult partial1(int id)
        {
            ViewBag.blg = id;
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        public PartialViewResult partial1(tbl_yorumlar y)
        {
            y.YTarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            ent.tbl_yorumlar.Add(y);
            ent.SaveChanges();
            return PartialView();
        }



    }

}