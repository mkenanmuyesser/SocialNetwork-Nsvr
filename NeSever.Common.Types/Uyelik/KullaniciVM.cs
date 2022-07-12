using System;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciVM
    {
        public Guid KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public string Hakkinda { get; set; }
        public string IliskiDurumu { get; set; }
        public string Semt { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Rol { get; set; }
        public string RefreshToken { get; set; }        
        public DateTime RefreshTokenEndTime { get; set; }
        public KullaniciSehirVM KullaniciSehir { get; set; }
    }
}
