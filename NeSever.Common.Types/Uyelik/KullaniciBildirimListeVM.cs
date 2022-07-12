using System;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciBildirimListeVM
    {
        public Guid KullaniciId { get; set; }

        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
