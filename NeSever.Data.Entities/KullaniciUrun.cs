using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class KullaniciUrun : Entity
    {
        public int KullaniciUrunId { get; set; }
        public Guid KullaniciId { get; set; }
        public int UrunId { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
