using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class HediyeKartKonusmaListesiVM
    {
        public Guid KullaniciId { get; set; }
        public string ProfilResmiBase64 { get; set; }

        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Aciklama { get; set; }
        public string HediyeKartBase64 { get; set; }
        public int HediyeKartId { get; set; }
        public DateTime SonKonusmaTarihi { get; set; }
        public bool OkunduMu { get; set; }
    }
}
