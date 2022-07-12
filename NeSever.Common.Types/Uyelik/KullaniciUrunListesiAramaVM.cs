using System;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciUrunListesiAramaVM
    {
        public Guid KullaniciId { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public string order { get; set; }
    }
}
