using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class BlogUrun : Entity
    {
        public int BlogUrunId { get; set; }
        public int BlogId { get; set; }
        public int UrunId { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
