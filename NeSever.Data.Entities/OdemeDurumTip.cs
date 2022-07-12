using NeSever.Common.Infra.DataLayer.Entity;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class OdemeDurumTip : Entity
    {
        public OdemeDurumTip()
        {
            Siparis = new HashSet<Siparis>();
        }

        public int OdemeDurumTipId { get; set; }
        public string Adi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<Siparis> Siparis { get; set; }
    }
}
