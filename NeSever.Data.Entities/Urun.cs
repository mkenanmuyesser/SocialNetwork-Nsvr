using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Urun :Entity
    {
        public Urun()
        {
            BlogUrun = new HashSet<BlogUrun>();
            DataUrunKategori = new HashSet<DataUrunKategori>();
            KullaniciUrun = new HashSet<KullaniciUrun>();
            KullaniciUrunFiyatGor = new HashSet<KullaniciUrunFiyatGor>();
            Sepet = new HashSet<Sepet>();
            SiparisDetay = new HashSet<SiparisDetay>();
            SurprizUrun = new HashSet<SurprizUrun>();
            UrunKategori = new HashSet<UrunKategori>();
            UrunNitelik = new HashSet<UrunNitelik>();
            UrunResim = new HashSet<UrunResim>();
        }

        public int UrunId { get; set; }
        public string OriginalId { get; set; }
        public int MarkaId { get; set; }
        public int? WebSiteId { get; set; }
        public string Sku { get; set; }
        public string UrunAdi { get; set; }
        public string KisaAciklama { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string Etiketler { get; set; }
        public string AdresUrl { get; set; }
        public bool AnasayfadaGoster { get; set; }
        public int GoruntulenmeSayisi { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public int YonlendirmeSayisi { get; set; }
        public bool SatilabilirUrun { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime? GuncellemeTarih { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }       

        public virtual Marka Marka { get; set; }
        public virtual ICollection<BlogUrun> BlogUrun { get; set; }
        public virtual ICollection<DataUrunKategori> DataUrunKategori { get; set; }
        public virtual ICollection<KullaniciUrun> KullaniciUrun { get; set; }
        public virtual ICollection<KullaniciUrunFiyatGor> KullaniciUrunFiyatGor { get; set; }
        public virtual ICollection<Sepet> Sepet { get; set; }
        public virtual ICollection<SiparisDetay> SiparisDetay { get; set; }
        public virtual ICollection<SurprizUrun> SurprizUrun { get; set; }
        public virtual ICollection<UrunKategori> UrunKategori { get; set; }
        public virtual ICollection<UrunNitelik> UrunNitelik { get; set; }
        public virtual ICollection<UrunResim> UrunResim { get; set; }
    }
}
