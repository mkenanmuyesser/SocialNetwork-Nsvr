using System;

namespace NeSever.Common.Models.Icerik
{
    [Serializable]
    public class HediyeKartIcerikVM
    {
        public int HediyeKartId { get; set; }
        public string HediyeKartAdi { get; set; }
        public string Aciklama { get; set; }
        public string ResimBase64 { get; set; }
        public int GonderilmeSayisi { get; set; }
        public string KUllaniciProfilResimBase64 { get; set; }
    }
}
