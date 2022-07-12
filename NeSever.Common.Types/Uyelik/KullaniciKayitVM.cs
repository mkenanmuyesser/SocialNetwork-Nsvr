using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciKayitVM
    {
        public List<int> KullaniciKayitDogumGunList { get; set; }
        public List<int> KullaniciKayitDogumAyList { get; set; }
        public List<int> KullaniciKayitDogumYilList { get; set; }

        [Required]
        [StringLength(20)]
        public string KullaniciKayitAd { get; set; }
        [Required]
        [StringLength(20)]
        public string KullaniciKayitSoyad { get; set; }
        [Required]
        [StringLength(20)]
        public string KullaniciKayitKullaniciAdi { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string KullaniciKayitSifre { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string KullaniciKayitSifreTekrar { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string KullaniciKayitEposta { get; set; }
        [Required]
        public int KullaniciKayitDogumGun { get; set; }
        [Required]
        public int KullaniciKayitDogumAy { get; set; }
        [Required]
        public int KullaniciKayitDogumYil { get; set; }
        [Required]
        public string KullaniciKayitCinsiyet { get; set; }
    }
}
