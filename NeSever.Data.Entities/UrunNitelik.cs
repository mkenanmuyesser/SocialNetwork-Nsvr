using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class UrunNitelik
    {
        public int UrunNitelikId { get; set; }
        public int UrunId { get; set; }
        public int NitelikId { get; set; }
        public string NitelikDegeri { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual Nitelik Nitelik { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
