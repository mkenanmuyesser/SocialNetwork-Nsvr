using NeSever.Common.Models.Urun;
using System.Collections.Generic;

namespace NeSever.Common.Models.FrontEnd
{
    public class MarkaAramaSayfaSonucVM
    {
        public List<MarkaIcerikVM> MarkaListesi { get; set; }
        public List<string> HarfListesi { get; set; }
        public List<string> BenzersizMarkaIsimleri { get; set; }
    }
}
