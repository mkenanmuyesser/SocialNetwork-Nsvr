using System;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasIstekleriVM
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int OrtakArkadasSayisi { get; set; }        
        public Guid KullaniciId { get; set; }
        public string ArkadasKullaniciAdi { get; set; }
        public Guid ArkadasIstekKullaniciId { get; set; }
        public string ProfilResmiBase64 { get; set; }
        public int ArkadaslikDurumTipId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime? GuncellemeTarihi { get; set; }
        public string KullaniciAdi { get; set; }
    }
}
