using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Kategori : Entity
    {
        public Kategori()
        {
            InverseUstKategori = new HashSet<Kategori>();
            KategoriBanner = new HashSet<KategoriBanner>();
            UrunKategori = new HashSet<UrunKategori>();
            DataKategori = new HashSet<DataKategori>();
        }

        public int KategoriId { get; set; }
        public int? UstKategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public bool AnasayfadaGoster { get; set; }
        public bool SabitKategori { get; set; }
        public string Parametre { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual Kategori UstKategori { get; set; }
        public virtual ICollection<Kategori> InverseUstKategori { get; set; }
        public virtual ICollection<KategoriBanner> KategoriBanner { get; set; }
        public virtual ICollection<UrunKategori> UrunKategori { get; set; }
        public virtual ICollection<DataKategori> DataKategori { get; set; }
    }
}
