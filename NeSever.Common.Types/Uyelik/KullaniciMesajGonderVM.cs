using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciMesajGonderVM
    {
        public Guid GondericiKullaniciId { get; set; }
        public Guid AliciKullaniciId { get; set; }
        public string MesajIcerik { get; set; }
    }
}
