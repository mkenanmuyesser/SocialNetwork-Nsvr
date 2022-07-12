using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class UrunKategori : Entity
    {
        public int UrunKategoriId { get; set; }
        public int UrunId { get; set; }
        public int KategoriId { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
