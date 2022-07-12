using NeSever.Common.Infra.DataLayer.Entity;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class KullaniciUlke : Entity
    {
        public KullaniciUlke()
        {
            KullaniciSehir = new HashSet<KullaniciSehir>();
        }

        public int KullaniciUlkeId { get; set; }
        public string UlkeKodu { get; set; }
        public string UlkeAdi { get; set; }
        public string AlanKodu { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<KullaniciSehir> KullaniciSehir { get; set; }
    }
}
