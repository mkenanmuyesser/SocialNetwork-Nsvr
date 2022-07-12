using System;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasVM
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
        public int? ArkadaslikIstekDurum { get; set; }
        public int ArkadasIstekTalepleriDurum { get; set; }
        public int ProfilGoruntulemeDurum { get; set; }
        public string DuvarResimBase64 { get; set; }
        public string ProfilResmiBase64 { get; set; }

        public byte[] DuvarResim { get; set; }
        public byte[] ProfilResmi { get; set; }
    }
}
