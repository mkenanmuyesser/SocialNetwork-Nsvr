using System;

namespace NeSever.Common.Models.Urun
{
    [Serializable]
    public class UrunIcerikVM
    {
        public int UrunId { get; set; }
        public string Sku { get; set; }
        public string MarkaAdi { get; set; }
        public string UrunAdi { get; set; }
        public string ResimUrl { get; set; }
        public string AdresUrl { get; set; }
        public bool SatilabilirUrun { get; set; }
        public decimal Fiyat { get; set; }
        public int HediyeSepetindekiUrunAdeti { get; set; }
        public string Aciklama { get; set; }
    }
}
