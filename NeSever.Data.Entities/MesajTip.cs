using NeSever.Common.Infra.DataLayer.Entity;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class MesajTip : Entity
    {
        public MesajTip()
        {
            Mesaj = new HashSet<Mesaj>();
        }

        public int MesajTipId { get; set; }
        public string MesajTipAdi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<Mesaj> Mesaj { get; set; }
    }
}
