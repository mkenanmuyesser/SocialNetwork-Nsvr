using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class HediyeKartAramaResultVM
    {
        public int TotalCount { get; set; }
        public int HediyeKartId { get; set; }
        public string HediyeKartAdi { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool AktifMi { get; set; }

        public int Sira { get; set; }
        public string ResimBase64 { get; set; }
        public string Durum { get; set; }
    }
}
