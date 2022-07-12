using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class ArkadaslikKabulDurumTip
    {
        public ArkadaslikKabulDurumTip()
        {
            ArkadaslikIstek = new HashSet<ArkadaslikIstek>();
        }

        public int ArkadaslikKabulDurumTipId { get; set; }
        public string ArkadaslikKabulDurumTipAdi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<ArkadaslikIstek> ArkadaslikIstek { get; set; }
    }
}
