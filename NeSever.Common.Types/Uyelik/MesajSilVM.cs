using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class MesajSilVM
    {
        public int MesajId { get; set; }
        public Guid SilenKullaniciId { get; set; }
        public TokenVM Token { get; set; }
    }
}
