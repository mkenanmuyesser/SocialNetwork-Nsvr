using System;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciBildirimVM
    {
        public Guid KullaniciId { get; set; }
        public int BildirimTipId { get; set; }
        public string BildirimIcerik { get; set; }
        public string KayitTarihi { get; set; }
        public bool OkunduMu { get; set; }
        public bool AktifMi { get; set; }
    }
}
