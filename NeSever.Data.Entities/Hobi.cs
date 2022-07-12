using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Hobi : Entity
    {
        public Hobi()
        {
            KullaniciHobi = new HashSet<KullaniciHobi>();
        }

        public int HobiId { get; set; }
        public string HobiAdi { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<KullaniciHobi> KullaniciHobi { get; set; }
    }
}
