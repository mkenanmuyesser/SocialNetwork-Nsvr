using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Siparis: Entity
    {
        public Siparis()
        {
            SiparisDetay = new HashSet<SiparisDetay>();
            SiparisHareket = new HashSet<SiparisHareket>();
        }

        public int SiparisId { get; set; }
        public Guid KullaniciId { get; set; }
        public int FaturaAdresId { get; set; }
        public int GonderimAdresId { get; set; }
        public int SiparisOdemeTipId { get; set; }
        public int SiparisDurumTipId { get; set; }
        public int OdemeDurumTipId { get; set; }
        public string KrediKartiAdSoyad { get; set; }
        public string KrediKartiMaskeliNumara { get; set; }
        public int? KrediKartiTaksit { get; set; }
        public string KrediKartiTransferId { get; set; }
        public decimal UrunKdvDahilToplamTutar { get; set; }
        public decimal UrunKdvHaricToplamTutar { get; set; }
        public decimal UrunKdvToplamTutar { get; set; }
        public decimal OdemeTipUcreti { get; set; }
        public decimal GonderimUcreti { get; set; }
        public decimal OdenecekTutar { get; set; }
        public decimal IadeToplam { get; set; }
        public string Aciklama { get; set; }
        public string KullaniciIp { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime SonIslemTarihi { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public bool AktifMi { get; set; }

        public virtual Adres FaturaAdres { get; set; }
        public virtual Adres GonderimAdres { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual OdemeDurumTip OdemeDurumTip { get; set; }
        public virtual SiparisDurumTip SiparisDurumTip { get; set; }
        public virtual SiparisOdemeTip SiparisOdemeTip { get; set; }
        public virtual ICollection<SiparisDetay> SiparisDetay { get; set; }
        public virtual ICollection<SiparisHareket> SiparisHareket { get; set; }
    }
}
