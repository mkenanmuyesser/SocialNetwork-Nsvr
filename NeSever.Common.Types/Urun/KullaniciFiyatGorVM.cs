using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Urun
{
    public class KullaniciFiyatGorVM
    {
        public int FiyatGorId { get; set; }
        public Guid KullaniciId { get; set; }
        public int UrunId { get; set; }
        public DateTime BakilanTarih { get; set; }
    }
}
