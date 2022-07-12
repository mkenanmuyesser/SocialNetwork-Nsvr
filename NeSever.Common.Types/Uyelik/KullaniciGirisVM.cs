using System.ComponentModel.DataAnnotations;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciGirisVM
    {
        [Required]
        public string KullaniciGirisEpostaKullaniciAd { get; set; }
        [Required]
        public string KullaniciGirisSifre { get; set; }
    }
}
