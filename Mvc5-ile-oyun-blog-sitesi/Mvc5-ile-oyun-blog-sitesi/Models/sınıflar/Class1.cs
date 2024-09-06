using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc5_ile_oyun_blog_sitesi.Models.entities;

namespace Mvc5_ile_oyun_blog_sitesi.Models.sınıflar
{
    public class Class1
    {
        public IEnumerable<tbl_bloglar> blg { get; set; }
        public IEnumerable<tbl_homegiris> grs { get; set; }
        public IEnumerable<tbl_duyurular> dyr { get; set; }
        public IEnumerable<tbl_sosyalmedya> sys { get; set; }
        public IEnumerable<tbl_hakkımızda> hkm { get; set; }
        public IEnumerable<tbl_yorumlar> yrm { get; set; }
        public IEnumerable<tbl_iletisim2> iltsm { get; set; }
        public IEnumerable<tbl_yorumlar> yrm2 { get; set; }



    }
}