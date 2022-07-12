using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciIlgiAlanKaydetGuncelleVM
    {
        public Guid KullaniciId { get; set; }
        public List<KullaniciIlgiAlanVM> KullaniciIlgiAlanList { get; set; }
    }
}
