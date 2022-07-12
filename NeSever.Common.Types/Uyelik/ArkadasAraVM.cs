using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasAraVM
    {
        public string AramaKelime { get; set; }
        public Guid KullaniciId { get; set; }
        public TokenVM Token { get; set; }

    }
}
