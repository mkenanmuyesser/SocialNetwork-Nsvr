using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class KullaniciHobi: Entity
    {
        public int KullaniciHobiId { get; set; }
        public Guid KullaniciId { get; set; }
        public int HobiId { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual Hobi Hobi { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
