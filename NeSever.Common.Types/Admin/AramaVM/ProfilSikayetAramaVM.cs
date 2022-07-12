using System;
using System.ComponentModel.DataAnnotations;

namespace NeSever.Common.Models.Admin.AramaVM
{
    public class ProfilSikayetAramaVM
    {
        public int? ProfilSikayetId { get; set; }
        public string SikayetEdilenKullaniciEposta { get; set; }
        public string SikayetEdenKullaniciEposta { get; set; }
        public string SikayetSebebi { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public int Aktiflik { get; set; }

        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
