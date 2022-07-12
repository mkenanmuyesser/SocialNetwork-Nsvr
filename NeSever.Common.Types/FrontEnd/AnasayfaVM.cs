using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Urun;
using System.Collections.Generic;

namespace NeSever.Common.Models.FrontEnd
{
    public class AnasayfaVM
    {
        public List<KategoriIcerikVM> KategoriIcerikList { get; set; }
        public List<BannerIcerikVM> BannerIcerikList { get; set; }
        public List<KategoriBannerIcerikVM> KategoriBannerIcerikList { get; set; }
        public List<BlogKategoriIcerikVM> BlogKategoriIcerikList { get; set; }
        public List<HediyeKartIcerikVM> HediyeKartIcerikList { get; set; }
        public List<UrunIcerikVM> TrendKadinUrunIcerikList { get; set; }
        public List<UrunIcerikVM> TrendErkekUrunIcerikList { get; set; }
        public List<MarkaIcerikVM> MarkaIcerikList { get; set; }
    }
}
