using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Marka : Entity
    {
        public Marka()
        {
            Urun = new HashSet<Urun>();
        }

        public int MarkaId { get; set; }
        public int WebSiteId { get; set; }
        public string MarkaAdi { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public bool AnasayfadaGosterilsin { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public DateTime KayitTarih { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual WebSite WebSite { get; set; }
        public virtual ICollection<Urun> Urun { get; set; }
    }
}
