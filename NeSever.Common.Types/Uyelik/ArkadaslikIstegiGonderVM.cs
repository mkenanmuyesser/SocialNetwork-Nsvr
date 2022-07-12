using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadaslikIstegiGonderVM
    {
        public Guid IstekGonderilenKullaniciId { get; set; }
        public TokenVM Token { get; set; }
    }
}
