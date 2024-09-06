using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;
using Mvc5_ile_oyun_blog_sitesi.Models.sınıflar;
namespace Mvc5_ile_oyun_blog_sitesi.Controllers
{
    public class mesajlarController : Controller
    {
        // GET: mesajlar
        dboyunblogEntities ent = new dboyunblogEntities();
        public ActionResult Index(string k)
        {
            var mesajliste = from x in ent.tbl_iletisim select x;
            
            if (!string.IsNullOrEmpty(k))
            {
                mesajliste = mesajliste.Where(x => x.AdSoyad.Contains(k));
            }
            return View(mesajliste.ToList());
        }
        public ActionResult mgetir(int id)
        {
            var mesajbul = ent.tbl_iletisim.Find(id);
            return View("mgetir",mesajbul);
        }
       
    }
}