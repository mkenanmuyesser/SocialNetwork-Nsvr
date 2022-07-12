using NeSever.Common.Models.Uyelik;
using System.Collections.Generic;

namespace NeSever.Common.Models.FrontEnd
{
    public class MesajlarVM
    {
        public string KullaniciAd { get; set; }
        public List<MesajDetaySonucVM> MesajList { get; set; }       
    }
}
