using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class KategoriBanner : Entity
    {
        public KategoriBanner()
        {
            InverseUstKategoriBanner = new HashSet<KategoriBanner>();
        }

        public int KategoriBannerId { get; set; }
        public int? UstKategoriBannerId { get; set; }
        public int? UstKategoriId { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public bool AnasayfadaGoster { get; set; }
        public string Parametre { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual Kategori UstKategori { get; set; }
        public virtual KategoriBanner UstKategoriBanner { get; set; }
        public virtual ICollection<KategoriBanner> InverseUstKategoriBanner { get; set; }
    }
}
