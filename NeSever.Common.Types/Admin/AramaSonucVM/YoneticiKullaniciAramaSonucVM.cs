using System.ComponentModel.DataAnnotations;

namespace NeSever.Common.Models.Admin.AramaSonucVM
{
    public class YoneticiKullaniciAramaSonucVM
    {
        [Key]
        public int YoneticiKullaniciId { get; set; }
        public string Eposta { get; set; }
        public string KayitTarih { get; set; }
        public bool AktifMi { get; set; }

        public int TotalCount { get; set; }
    }
}
