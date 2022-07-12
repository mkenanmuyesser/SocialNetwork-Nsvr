using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class ProfilEngel : Entity
    {
        public int ProfilEngelId { get; set; }
        public Guid ProfilEngelleyenKullaniciId { get; set; }
        public Guid ProfilEngellenenKullaniciId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool AktifMi { get; set; }

        public virtual Kullanici ProfilEngelleyenKullanici { get; set; }
        public virtual Kullanici ProfilEngellenenKullanici { get; set; }
    }
}
