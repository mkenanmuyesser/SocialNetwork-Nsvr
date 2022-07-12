using NeSever.Common.Infra.DataLayer.Entity;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class AdresIl: Entity
    {
        public AdresIl()
        {
            Adres = new HashSet<Adres>();
            AdresIlce = new HashSet<AdresIlce>();
        }

        public int AdresIlId { get; set; }
        public string IlAdi { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<Adres> Adres { get; set; }
        public virtual ICollection<AdresIlce> AdresIlce { get; set; }
    }
}
