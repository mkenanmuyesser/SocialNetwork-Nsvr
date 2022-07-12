using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class HediyeKartKategoriVM
    {
        public int HediyeKartKategoriId { get; set; }
        public string HediyeKartKategoriAdi { get; set; }
        public string HediyeKartKategoriAttribute { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
    }
}