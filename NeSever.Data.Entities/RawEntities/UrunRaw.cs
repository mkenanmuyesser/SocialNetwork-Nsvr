using NeSever.Common.Infra.DataLayer.Entity;

namespace NeSever.Data.Entities.RawEntities
{
    public partial class UrunRaw : Entity
    {       
        public int UrunId { get; set; }
        public string Sku { get; set; }
        public string MarkaAdi { get; set; }
        public string UrunAdi { get; set; }
        public string ResimUrl { get; set; }
        public string AdresUrl { get; set; }
        public bool SatilabilirUrun { get; set; }
        public decimal Fiyat { get; set; }
    }
}
