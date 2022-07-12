using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class BildirimAramaResultVM
    {
        public string BildirimIcerik { get; set; }
        public int Okunan { get; set; }
        public int Adet { get; set; }
        public int Okunmayan { get; set; }
        public int TotalCount { get; set; }
        public int BildirimId { get; set; }
    }
}
