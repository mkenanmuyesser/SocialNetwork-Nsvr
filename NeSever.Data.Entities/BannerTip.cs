using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class BannerTip : Entity
    {
        public BannerTip()
        {
            Banner = new HashSet<Banner>();
        }

        public int BannerTipId { get; set; }
        public string Adi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<Banner> Banner { get; set; }
    }
}
