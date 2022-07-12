using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities.RawEntities
{
    [Serializable]
    public partial class UrunDetayIcerikRaw : Entity
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
        public string Resimler { get; set; }
    }
}
