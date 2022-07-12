using System;
using System.Collections.Generic;

namespace NeSever.Common.Models.Satis
{
    public class AdresIcerikVM
    {
        public Guid KullaniciId { get; set; }
        public List<SepetAdresVM> Adresler { get; set; }       
        public int FaturaAdresId { get; set; }
        public int GonderimAdresId { get; set; }     
    }
}
