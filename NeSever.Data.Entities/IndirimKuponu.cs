using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Data.Entities
{
    public partial class IndirimKuponu : Entity
    {
        public int IndirimKuponId { get; set; }
        public string Adi { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public string Aciklama { get; set; }
        public DateTime YuklenmeTarihi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Link { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
    }
}
