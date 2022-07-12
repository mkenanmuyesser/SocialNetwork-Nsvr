using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class BildirimTip
    {
        public BildirimTip()
        {
            Bildirim = new HashSet<Bildirim>();
        }

        public int BildirimTipId { get; set; }
        public string BildirimTipAdi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<Bildirim> Bildirim { get; set; }
    }
}
