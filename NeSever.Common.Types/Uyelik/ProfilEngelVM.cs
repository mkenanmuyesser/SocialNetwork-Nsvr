using System;

namespace NeSever.Common.Models.Uyelik
{
    public class ProfilEngelVM
    {
        public Guid ProfilEngelleyenKullaniciId { get; set; }
        public Guid ProfilEngellenenKullaniciId { get; set; }
        public string Mesaj { get; set; }
        public bool Hata { get; set; }
    }
}
