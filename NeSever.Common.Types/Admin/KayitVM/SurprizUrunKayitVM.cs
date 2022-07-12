using NeSever.Common.Models.Sayfa;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.KayitVM
{
    public class SurprizUrunKayitVM
    {
        public int SurpizUrunId { get; set; }
        public int UrunId { get; set; }
        public int UrunIdArama { get; set; }
        public string UrunAdi { get; set; }
        public bool AktifMi { get; set; }
        public List<NeSever.Common.Models.Urun.UrunVM> UrunListesi { get; set; }
    }
}
