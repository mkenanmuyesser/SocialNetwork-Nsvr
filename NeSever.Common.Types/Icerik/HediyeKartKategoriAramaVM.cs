using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class HediyeKartKategoriAramaVM
    {
        public int? HediyeKartKategoriId { get; set; }
        public string HediyeKartKategoriAdi { get; set; }
        public int? Sira { get; set; }
        public int AktifMi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
