using System;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasListesiKullaniciArkadasVM
    {
        public Guid KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Hakkinda { get; set; }
        public string Sehir { get; set; }
        public int ArkadasSayisi { get; set; }
        public int HediyeSepetiUrunSayisi { get; set; }
        public string ProfilResmiBase64 { get; set; }
        public string DuvarResimBase64 { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int? ArkadaslikIstekDurum { get; set; }
        public int ArkadaslikIstekTalepleriDurum { get; set; }
    }
}
