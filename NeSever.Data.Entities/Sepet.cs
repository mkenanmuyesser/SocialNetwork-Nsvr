using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class Sepet : Entity
    {
        public int SepetId { get; set; }
        public int SepetTipId { get; set; }
        public Guid KullaniciId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public bool AktifMi { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual SepetTip SepetTip { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
