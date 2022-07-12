using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class DataUrunKategori
    {
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual DataKategori Category { get; set; }
        public virtual Urun Product { get; set; }
    }
}
