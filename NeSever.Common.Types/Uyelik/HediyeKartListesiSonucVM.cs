using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace NeSever.Common.Models.Uyelik
{
    public class HediyeKartListesiSonucVM
    {
        public string HediyeKartArama { get; set; }
        public IPagedList<HediyeKartKonusmaListesiVM> HediyeKartListSonuc { get; set; }
    }
}
