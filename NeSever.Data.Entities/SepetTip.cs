using NeSever.Common.Infra.DataLayer.Entity;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class SepetTip : Entity
    {
        public SepetTip()
        {
            Sepet = new HashSet<Sepet>();
        }

        public int SepetTipId { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<Sepet> Sepet { get; set; }
    }
}
