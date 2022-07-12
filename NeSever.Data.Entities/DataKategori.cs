using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class DataKategori : Entity
    {
        public DataKategori()
        {
            DataUrunKategori = new HashSet<DataUrunKategori>();
        }

        public int CategoryId { get; set; }
        public int WebSiteId { get; set; }
        public string OriginalCategoryId { get; set; }
        public string ParentOriginalCategoryId { get; set; }
        public int? KategoriId { get; set; }
        public string CategoryName { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual WebSite WebSite { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<DataUrunKategori> DataUrunKategori { get; set; }
    }
}
