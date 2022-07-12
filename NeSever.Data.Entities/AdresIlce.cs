using NeSever.Common.Infra.DataLayer.Entity;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class AdresIlce : Entity
    {
        public AdresIlce()
        {
            Adres = new HashSet<Adres>();
        }

        public int AdresIlceId { get; set; }
        public int AdresIlId { get; set; }
        public string IlceAdi { get; set; }
        public bool AktifMi { get; set; }

        public virtual AdresIl AdresIl { get; set; }
        public virtual ICollection<Adres> Adres { get; set; }
    }
}
