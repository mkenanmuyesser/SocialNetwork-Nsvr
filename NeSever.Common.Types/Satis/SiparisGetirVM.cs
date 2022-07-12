using System;
using System.Collections.Generic;

namespace NeSever.Common.Models.Satis
{
    public class SiparisGetirVM
    {
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
        public string SiparisTarihi { get; set; }
        public string SonIslemTarihi { get; set; }
        public string OdemeTarihi { get; set; }
        public bool AktifMi { get; set; }
        public string KullaniciBilgileri { get; set; }

        public List<SiparisDurumTipVM> SiparisDurumTipListesi { get; set; }
        public List<SiparisOdemeTipVM> SiparisOdemeTipListesi { get; set; }
        public List<OdemeDurumTipVM> OdemeDurumTipListesi { get; set; }
    }
}
