using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class UrunVM
    {
        public int UrunId { get; set; }
        public string Sku { get; set; }
        public string UrunAdi { get; set; }

        public int Sira { get; set; }
        public bool  AktifMi { get; set; }
        public int TotalCount { get; set; }

    }
}
