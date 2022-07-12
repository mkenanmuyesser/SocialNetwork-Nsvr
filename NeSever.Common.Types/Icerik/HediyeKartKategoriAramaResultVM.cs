using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class HediyeKartKategoriAramaResultVM
    {
        public int TotalCount { get; set; }
        public int HediyeKartKategoriId { get; set; }
        public string HediyeKartKategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; }
        public int Sira { get; set; }
        public string Durum { get; set; }

    }
}
