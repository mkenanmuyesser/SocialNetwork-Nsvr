using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class KullaniciHediyeKart : Entity
    {
        public int KullaniciHediyeKartId { get; set; }
        public Guid GonderenKullaniciId { get; set; }
        public Guid AliciKullaniciId { get; set; }
        public int HediyeKartId { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool OkunduMu { get; set; }
        public bool GonderenAktifMi { get; set; }

        public bool AlanAktifMi { get; set; }

        public bool AktifMi { get; set; }

        public virtual Kullanici AliciKullanici { get; set; }
        public virtual Kullanici GonderenKullanici { get; set; }
        public virtual HediyeKart HediyeKart { get; set; }
    }
}
