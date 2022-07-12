using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Adres: Entity
    {
        public Adres()
        {
            SiparisFaturaAdres = new HashSet<Siparis>();
            SiparisGonderimAdres = new HashSet<Siparis>();
        }

        public int AdresId { get; set; }
        public Guid KullaniciId { get; set; }
        public int FaturaTipId { get; set; }
        public string AdresAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
        public string FirmaUnvan { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string AdresBilgi { get; set; }
        public string Aciklama { get; set; }
        public string PostaKodu { get; set; }
        public int AdresIlceId { get; set; }
        public int AdresIlId { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public DateTime Tarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual AdresIl AdresIl { get; set; }
        public virtual AdresIlce AdresIlce { get; set; }
        public virtual FaturaTip FaturaTip { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual ICollection<Siparis> SiparisFaturaAdres { get; set; }
        public virtual ICollection<Siparis> SiparisGonderimAdres { get; set; }
    }
}
