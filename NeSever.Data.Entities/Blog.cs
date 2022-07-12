using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Blog :Entity
    {
        public Blog()
        {
            BlogResim = new List<BlogResim>();
            BlogUrun = new List<BlogUrun>();
        }

        public int BlogId { get; set; }
        public int BlogKategoriId { get; set; }
        public string Baslik { get; set; }
        public string KisaIcerik { get; set; }
        public string Icerik { get; set; }
        public string Etiketler { get; set; }
        public DateTime YayinTarihi { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public bool OneCikanGonderi { get; set; }
        public int OkunmaSayisi { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public bool AktifMi { get; set; }

        public virtual BlogKategori BlogKategori { get; set; }
        public virtual ICollection<BlogResim> BlogResim { get; set; }
        public virtual ICollection<BlogUrun> BlogUrun { get; set; }
    }
}
