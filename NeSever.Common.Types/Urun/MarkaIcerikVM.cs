using System;

namespace NeSever.Common.Models.Urun
{
    [Serializable]
    public class MarkaIcerikVM
    {
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
        public string Aciklama { get; set; }
        public string ResimBase64 { get; set; }
    }
}
