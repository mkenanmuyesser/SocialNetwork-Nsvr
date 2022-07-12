using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class ArkadaslikIstek : Entity
    {
        public int ArkadaslikIstekId { get; set; }
        public Guid KullaniciId { get; set; }
        public Guid ArkadaslikIstekKullaniciId { get; set; }
        public int ArkadaslikKabulDurumTipId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime? GuncellemeTarih { get; set; }
        public bool AktifMi { get; set; }
        public bool OkunduMu { get; set; }

        public virtual Kullanici ArkadaslikIstekKullanici { get; set; }
        public virtual ArkadaslikKabulDurumTip ArkadaslikKabulDurumTip { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
