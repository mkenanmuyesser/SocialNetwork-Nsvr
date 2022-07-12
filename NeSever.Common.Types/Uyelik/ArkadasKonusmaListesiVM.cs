using System;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasKonusmaListesiVM
    {
        public Guid KullaniciId { get; set; }
        public string ProfilResmiBase64 { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string MesajOzet { get; set; }
        public DateTime SonKonusmaTarihi { get; set; }
    }
}
