using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class KonusmaSilVM
    {
        public Guid GonderenKullaniciId { get; set; }
        public Guid SilenKullaniciId { get; set; }
        public TokenVM Token { get; set; }
    }
}
