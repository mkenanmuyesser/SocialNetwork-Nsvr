using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class KullaniciResim : Entity
    {
        public int KullaniciResimId { get; set; }
        public Guid KullaniciId { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public string ResimUzanti{ get; set; }
        public string ResimYorum { get; set; }
        public bool ProfilFotografiMi { get; set; }
        public bool? BuyukProfilFotografiMi { get; set; }
        public bool AktifMi { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
