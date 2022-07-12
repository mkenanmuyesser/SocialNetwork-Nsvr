using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.AramaSonucVM
{
    public class YonlendirilenUrunAramaSonucVM
    {
        public string UrunAdi { get; set; }
        public int YonlendirmeSayisi { get; set; }
        public bool AktifMi { get; set; }
        public int ToplamYonlendirme { get; set; }
    }
}
