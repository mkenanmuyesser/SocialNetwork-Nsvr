using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Banner : Entity
    {
        public int BannerId { get; set; }
        public int BannerTipId { get; set; }
        public string Adi { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public string Link { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual BannerTip BannerTip { get; set; }
    }
}
