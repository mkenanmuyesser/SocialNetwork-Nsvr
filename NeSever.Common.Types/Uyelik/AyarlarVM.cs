using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class AyarlarVM
    {
        public bool DogumGunleriHatirlatma { get; set; }
        public bool MesajEpostaBildirim { get; set; }
        public int ProfilGoruntulemeDurum { get; set; }
        public int ArkadasIstekTalepleriDurum { get; set; }
        public bool KisiselBilgiGosterimDurum { get; set; }

        public TokenVM Token { get; set; }
    }
}
