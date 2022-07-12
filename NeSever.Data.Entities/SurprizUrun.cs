using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class SurprizUrun : Entity
    {
        public int SurprizUrunId { get; set; }
        public int UrunId { get; set; }
        public Guid? KullaniciId { get; set; }
        public DateTime? KazandigiTarih { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime? GuncellemeTarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}