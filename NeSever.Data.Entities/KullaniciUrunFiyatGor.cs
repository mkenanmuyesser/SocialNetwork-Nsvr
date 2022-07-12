using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeSever.Data.Entities
{
    public partial class KullaniciUrunFiyatGor : Entity
    {
        [Key]
        public int FiyatGorId { get; set; }
        public Guid KullaniciId { get; set; }
        public int UrunId { get; set; }
        public DateTime BakilanTarih { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Urun Urun { get; set; }

    }
}
