using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class BlogResim : Entity
    {
        public int BlogResimId { get; set; }
        public int BlogId { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public string Aciklama { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public bool AktifMi { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
