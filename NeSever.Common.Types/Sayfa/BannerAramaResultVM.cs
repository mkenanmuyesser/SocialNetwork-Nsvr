using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class BannerAramaResultVM
    {
        public int TotalCount { get; set; }
        public int BannerId { get; set; }
        public string BannerTipAdi { get; set; }
        public int BannerTipId { get; set; }
        public string Adi { get; set; }
        public byte[] Resim { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public string Link { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public string ResimBase64 { get; set; }
        public string Durum { get; set; }
    }
}
