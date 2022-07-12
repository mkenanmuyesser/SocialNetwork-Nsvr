using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeSever.Data.Entities
{
    public partial class KullaniciBakilanProfiller : Entity
    {
        [Key]
        public int BakilanProfilId { get; set; }
        public Guid KullaniciId { get; set; }
        public Guid BakilanKullaniciId { get; set; }
        public DateTime BakilanTarih { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
