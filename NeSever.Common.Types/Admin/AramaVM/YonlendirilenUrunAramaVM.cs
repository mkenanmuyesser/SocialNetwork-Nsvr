using NeSever.Common.Models.FrontEnd;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.AramaVM
{
    public class YonlendirilenUrunAramaVM
    {
        public string MarkaAdi { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public int Aktiflik { get; set; }

        public MarkaAramaSayfaSonucVM MarkaListesi { get; set; }
    }
}
