using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class SifreDegistirVM
    {
        public string SuankiSifre { get; set; }
        public string YeniSifre { get; set; }
        public string YeniSifreTekrar { get; set; }
        public TokenVM Token { get; set; }
    }
}
