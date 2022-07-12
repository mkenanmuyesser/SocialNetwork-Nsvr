using System;

namespace NeSever.Common.Models.Satis
{
    [Serializable]
    public class OdemeSonucVM
    {        
        public bool SiparisBasariliMi { get; set; }
        public int SiparisId { get; set; }
        public string TransferId { get; set; }
        public Guid KullaniciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public SepetAdresVM GonderimAdres { get; set; }
        public SepetAdresVM FaturaAdres { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public string OdemeTipi { get; set; }
        public decimal ToplamIskonto { get; set; }
        public decimal ToplamKomisyon { get; set; }
        public decimal OdemeTipUcreti { get; set; }
        public decimal GonderimUcreti { get; set; }
        public decimal OdenecekTutar { get; set; }
        public SepetIcerikVM SepetIcerik { get; set; }
        //public KrediKartiDataObj KrediKartiBilgi { get; set; }
    }
}
