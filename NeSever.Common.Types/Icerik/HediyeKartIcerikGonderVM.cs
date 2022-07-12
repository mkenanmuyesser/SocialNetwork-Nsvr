using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class HediyeKartIcerikGonderVM
    {
        public int HediyeKartId { get; set; }
        public string HediyeKartAdi { get; set; }
        public string Aciklama { get; set; }
        public string ResimBase64 { get; set; }
        public int GonderilmeSayisi { get; set; }
        public string KullaniciProfilResimBase64 { get; set; }
    }
}
