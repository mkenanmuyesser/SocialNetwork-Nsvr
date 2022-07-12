using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Satis
{
    public class SiparisAramaSonucVM
    {
        public int SiparisId { get; set; }
        public int SiparisDurumTipId { get; set; }
        public int OdemeDurumTipId { get; set; }
        public int SiparisOdemeTipId { get; set; }
        public string MusteriBilgileri { get; set; }
        public string SiparisTarihi { get; set; }
        public string SonIslemTarihi { get; set; }
        public bool AktifMi { get; set; }
        public int TotalCount { get; set; }
    }
}
