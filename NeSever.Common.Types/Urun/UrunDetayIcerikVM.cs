using System.Collections.Generic;

namespace NeSever.Common.Models.Urun
{
    public class UrunDetayIcerikVM
    {
        public int UrunId { get; set; }
        public string Sku { get; set; }
        public string MarkaAdi { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public string AdresUrl { get; set; }
        public int HediyeSepetiSayisi { get; set; }
        public int GoruntulenmeSayisi { get; set; }        
        public string Etiketler { get; set; }
        public bool SatilabilirUrun { get; set; }
        public decimal Fiyat { get; set; }
        public IEnumerable<string> Resimler { get; set; }
    }
}
