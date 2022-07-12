using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class UrunResim :Entity
    {
        public int UrunResimId { get; set; }
        public int UrunId { get; set; }
        public string OrjinalResimUrl { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public int Sira { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
