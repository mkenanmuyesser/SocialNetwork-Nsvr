using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class BlogKategori : Entity
    {
        public BlogKategori()
        {
            Blog = new HashSet<Blog>();
            BlogKategoriResim = new List<BlogKategoriResim>();
        }

        public int BlogKategoriId { get; set; }
        public string BlogKategoriAdi { get; set; }
        public string BlogKategoriAttribute { get; set; }
        public string Aciklama { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<Blog> Blog { get; set; }
        public virtual ICollection<BlogKategoriResim> BlogKategoriResim { get; set; }
    }
}
