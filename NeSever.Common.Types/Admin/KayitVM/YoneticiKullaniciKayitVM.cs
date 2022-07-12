using System;

namespace NeSever.Common.Models.Admin.KayitVM
{
    public class YoneticiKullaniciKayitVM
    {
        public int YoneticiKullaniciId { get; set; }

        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
        public int IslemKullaniciId { get; set; }
        public DateTime IslemTarih { get; set; }
    }
}
