using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class KullaniciRol
    {
        public int KullaniciRolId { get; set; }
        public Guid KullaniciId { get; set; }
        public int RolId { get; set; }
        public bool AktifMi { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
