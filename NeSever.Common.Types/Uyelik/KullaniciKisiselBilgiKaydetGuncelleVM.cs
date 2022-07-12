using System;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciKisiselBilgiKaydetGuncelleVM :TokenVM
    {
        public Guid KullaniciId { get; set; }
        public int? KullaniciSehirId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        public DateTime datetimepicker { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string Hakkinda { get; set; }
        public string Adres { get; set; }
        public string IliskiDurumu { get; set; }
        public string Cinsiyet { get; set; }
        public string InstagramAdi { get; set; }
    }
}
