using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.AramaSonucVM
{
    public class GoruntulenenUrunAramaSonucVM
    {
        public string UrunAdi { get; set; }
        public int GoruntulenmeSayisi { get; set; }
        public bool AktifMi { get; set; }
        public int ToplamGoruntulenme { get; set; }
    }
}
