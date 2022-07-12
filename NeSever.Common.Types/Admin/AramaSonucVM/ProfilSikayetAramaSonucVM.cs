using System.ComponentModel.DataAnnotations;

namespace NeSever.Common.Models.Admin.AramaSonucVM
{
    public class ProfilSikayetAramaSonucVM
    {
        [Key]
        public int ProfilSikayetId { get; set; }
        public string SikayetEdilenKullaniciEposta { get; set; }
        public string SikayetEdenKullaniciEposta { get; set; }
        public string SikayetSebebi { get; set; }
        public string Tarih { get; set; }
        public bool AktifMi { get; set; }

        public int TotalCount { get; set; }
    }
}
