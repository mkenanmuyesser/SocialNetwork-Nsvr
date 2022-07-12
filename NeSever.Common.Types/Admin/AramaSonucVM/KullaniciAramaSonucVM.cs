using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.AramaSonucVM
{
    public class KullaniciAramaSonucVM
    {
        public Guid KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        public string DogumTarihi { get; set; }
        public string UyelikTarihi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string InstagramAdi { get; set; }
        public bool AktifMi { get; set; }
        public int TotalCount { get; set; }
    }
}
