using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class BildirimAramaVM
    {
        public int BildirimId { get; set; }
        public int BildirimTipId { get; set; }
        public string BildirimIcerik { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int OkunduMu { get; set; }
        public int AktifMi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
