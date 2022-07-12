using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.AramaVM
{
    public class SurprizUrunAramaVM
    {
        public int SurprizUrunId { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string KullaniciAdiVeyaEposta { get; set; }
        public int AktifMi{ get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
