using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            KullaniciRol = new HashSet<KullaniciRol>();
        }

        public int RolId { get; set; }
        public string RolAdi { get; set; }
        public string Aciklama { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<KullaniciRol> KullaniciRol { get; set; }
    }
}
