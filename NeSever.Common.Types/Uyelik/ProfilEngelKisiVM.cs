using System;

namespace NeSever.Common.Models.Uyelik
{
    public class ProfilEngelKisiVM
    {
        public Guid ProfilEngellenenKullaniciId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string KayitTarihi { get; set; }
        public string ProfilResmiBase64 { get; set; }
    }
}
