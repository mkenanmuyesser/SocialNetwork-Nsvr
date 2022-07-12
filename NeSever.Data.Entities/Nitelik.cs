using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Nitelik
    {
        public Nitelik()
        {
            UrunNitelik = new HashSet<UrunNitelik>();
        }

        public int NitelikId { get; set; }
        public string NitelikAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<UrunNitelik> UrunNitelik { get; set; }
    }
}
