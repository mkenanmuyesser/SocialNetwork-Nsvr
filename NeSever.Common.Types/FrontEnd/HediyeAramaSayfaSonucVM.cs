using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Urun;
using System.Collections.Generic;
using X.PagedList;

namespace NeSever.Common.Models.FrontEnd
{
    public class HediyeAramaSayfaSonucVM
    {
        public int? SayfaKategori { get; set; }
        public int? HediyeKategoriBanner { get; set; }
        public string HediyeSiralama { get; set; }
        public string HediyeArama { get; set; }
        public string HediyeKategori { get; set; }     
        public string HediyeMarka { get; set; }
        public string HediyeSite { get; set; }
     
        public IPagedList<UrunIcerikVM> HediyeIcerikList { get; set; }
        public List<KategoriBannerIcerikVM> KategoriBannerIcerikList { get; set; }
        public List<KategoriIcerikVM> KategoriIcerikList { get; set; }
    }
}
