using System;

namespace NeSever.Common.Models.Uyelik
{
    public class EngellenenProfilListesiAramaVM
    {
        public Guid KullaniciId { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
