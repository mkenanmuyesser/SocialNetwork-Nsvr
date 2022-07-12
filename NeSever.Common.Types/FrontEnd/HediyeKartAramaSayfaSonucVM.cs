using NeSever.Common.Models.Icerik;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace NeSever.Common.Models.FrontEnd
{
    public class HediyeKartAramaSayfaSonucVM
    {
        public int? SayfaKategori { get; set; }
        public string HediyeKartArama { get; set; }
        public string HediyeKartKategori { get; set; }

        public IPagedList<HediyeKartIcerikVM> HediyeKartIcerikList { get; set; }
        public List<HediyeKartKategoriVM> HediyeKartKategoriIcerikList { get; set; }
    }
}
