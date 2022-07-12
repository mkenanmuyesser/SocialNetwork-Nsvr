using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class KullaniciIlgiAlan : Entity
    {
        public int KullaniciIlgiAlanId { get; set; }
        public Guid KullaniciId { get; set; }
        public int IlgiAlanId { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual IlgiAlan IlgiAlan { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
