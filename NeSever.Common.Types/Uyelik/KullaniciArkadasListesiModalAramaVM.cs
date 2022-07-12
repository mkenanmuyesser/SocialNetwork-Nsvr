using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciArkadasListesiModalAramaVM
    {
        public Guid KullaniciId { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public TokenVM Token { get; set; }
    }
}
