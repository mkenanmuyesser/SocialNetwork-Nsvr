using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class IndirimKuponuAramaVM
    {
        public int? IndirimKuponuId { get; set; }
        public string Adi { get; set; }
        public int AktifMi { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
