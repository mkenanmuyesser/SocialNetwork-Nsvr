using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class IlgiAlanAramaVM
    {
        public int? IlgiAlanId { get; set; }
        public string IlgiAlanAdi { get; set; }    
        public int AktifMi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
