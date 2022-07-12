using System;
using System.ComponentModel.DataAnnotations;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciKisiselBilgiVM
    {
        public Guid KullaniciId { get; set; }
        public int? KullaniciSehirId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        [Required]
        public int DogumGun { get; set; }
        [Required]
        public int DogumAy { get; set; }
        [Required]
        public int DogumYil { get; set; }
        public string Telefon { get; set; }
        [StringLength(500)]
        public string Hakkinda { get; set; }
        public string Adres { get; set; }
        public string IliskiDurumu { get; set; }
        public string Cinsiyet { get; set; }
        public string InstagramAdi { get; set; }
    }
}
