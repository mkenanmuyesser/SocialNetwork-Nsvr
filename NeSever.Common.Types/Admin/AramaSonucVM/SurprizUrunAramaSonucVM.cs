using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.AramaSonucVM
{
    public class SurprizUrunAramaSonucVM
    {
        public int TotalCount { get; set; }
        public int SurprizUrunId { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        public string KazandigiTarih { get; set; }
        public bool AktifMi { get; set; }
    }
}
