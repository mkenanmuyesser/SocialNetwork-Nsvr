using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.AramaSonucVM
{
    public class KisiyeOzelBildirimAramaSonucVM
    {
        public int BildirimId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string MesajIcerigi { get; set; }
        public bool KullaniciAktifMi { get; set; }
        public bool OkunduMu { get; set; }
        public bool AktifMi { get; set; }
        public int TotalCount { get; set; }

    }
}
