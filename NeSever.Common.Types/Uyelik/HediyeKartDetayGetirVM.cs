using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class HediyeKartDetayGetirVM
    {
        public Guid GonderenKullaniciId { get; set; }
        public Guid AliciKullaniciId { get; set; }
        public TokenVM Token { get; set; }
    }
}
