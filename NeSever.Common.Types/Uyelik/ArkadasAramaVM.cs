using System;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasAramaVM
    {
        public string Siralama { get; set; }
        public string AramaKelime { get; set; }
        public string Cinsiyet { get; set; }
        public string MedeniDurum { get; set; }
        public int Ulke { get; set; }
        public int Sehir { get; set; }
        public Guid? KullaniciId { get; set; }

        public int start { get; set; }
        public int length { get; set; }
        public TokenVM Token { get; set; }
    }
}
