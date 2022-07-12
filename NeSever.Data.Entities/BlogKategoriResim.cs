using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class BlogKategoriResim : Entity
    {
        public int BlogKategoriResimId { get; set; }
        public int BlogKategoriId { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public string Aciklama { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public bool AktifMi { get; set; }

        public virtual BlogKategori BlogKategori { get; set; }
    }
}
