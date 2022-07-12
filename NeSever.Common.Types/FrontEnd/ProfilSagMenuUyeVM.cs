using System;

namespace NeSever.Common.Models.FrontEnd
{
    public class ProfilSagMenuUyeVM
    {
        public Guid KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }              
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string DogumGunu { get; set; }
        public string ProfilResmiBase64 { get; set; }
    }
}
