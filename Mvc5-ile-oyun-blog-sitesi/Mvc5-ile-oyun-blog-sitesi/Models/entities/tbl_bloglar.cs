//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc5_ile_oyun_blog_sitesi.Models.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_bloglar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_bloglar()
        {
            this.tbl_yorumlar = new HashSet<tbl_yorumlar>();
        }
    
        public byte BlogId { get; set; }
        public Nullable<byte> BlogKategori { get; set; }
        public string BlogBaslik { get; set; }
        public string BlogAciklama { get; set; }
        public Nullable<System.DateTime> BlogTarih { get; set; }
        public string BlogResim { get; set; }
        public Nullable<bool> BSil { get; set; }
    
        public virtual tbl_kategoriler tbl_kategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_yorumlar> tbl_yorumlar { get; set; }
    }
}
