using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class HediyeKartSilVM
    {
        public int HediyeKartId { get; set; }
        public Guid SilenKullaniciId { get; set; }
        public TokenVM Token { get; set; }
    }
}
