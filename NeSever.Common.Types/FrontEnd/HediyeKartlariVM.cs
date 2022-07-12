using NeSever.Common.Models.Uyelik;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.FrontEnd
{
    public class HediyeKartlariVM
    {
        public string KullaniciAd { get; set; }
        public List<HediyeKartDetaySonucVM> HediyeKartList { get; set; }
    }
}
