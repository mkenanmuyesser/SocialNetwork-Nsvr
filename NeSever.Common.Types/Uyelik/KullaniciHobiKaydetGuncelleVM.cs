using System;
using System.Collections.Generic;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciHobiKaydetGuncelleVM
    {
        public Guid KullaniciId { get; set; }
        public List<KullaniciHobiVM> KullaniciHobiList { get; set; }
        
    }
}
