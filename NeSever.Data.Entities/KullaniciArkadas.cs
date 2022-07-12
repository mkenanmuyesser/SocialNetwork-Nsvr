using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSever.Data.Entities
{
    public partial class KullaniciArkadas : Entity
    {
        public int KullaniciArkadasId { get; set; }
        public Guid KullaniciId { get; set; }
        public Guid ArkadasKullaniciId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool AktifMi { get; set; }

        public virtual Kullanici ArkadasKullanici { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
