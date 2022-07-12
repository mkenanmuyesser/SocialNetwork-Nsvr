using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class HediyeKartAramaVM
    {
        public int? HediyeKartId { get; set; }
        public string HediyeKartAdi { get; set; }
        public string Aciklama { get; set; }
        public int AktifMi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
