using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class IlgiAlan : Entity
    {
        public IlgiAlan()
        {
            KullaniciIlgiAlan = new HashSet<KullaniciIlgiAlan>();
        }

        public int IlgiAlanId { get; set; }
        public string IlgiAlanAdi { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<KullaniciIlgiAlan> KullaniciIlgiAlan { get; set; }
    }
}
