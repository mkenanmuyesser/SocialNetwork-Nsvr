using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class IlgiAlanAramaResultVM
    {
        public int TotalCount { get; set; }
        public int IlgiAlanId { get; set; }
        public string IlgiAlanAdi { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
        public string ResimBase64 { get; set; }
        public string Durum { get; set; }
    }
}
