using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class IndirimKuponuAramaResultVM
    {
        public int TotalCount { get; set; }
        public int IndirimKuponId { get; set; }
        public string Adi { get; set; }
        public byte[] Resim { get; set; }
        public string Aciklama { get; set; }
        public string YuklenmeTarihi { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public string Link { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public string ResimBase64 { get; set; }
        public bool Durum { get; set; }
    }
}
