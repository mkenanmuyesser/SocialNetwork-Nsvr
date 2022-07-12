using System;

namespace NeSever.Common.Models.FrontEnd
{
    public class UyeVM
    {
        public bool DisKullanici { get; set; }
        public bool ArkadasProfil { get; set; }
        public bool KullaniciArkadasiMi { get; set; }
        public Guid KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }              
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }
        public string KullaniciResimBase64 { get; set; }
        public string DuvarResimBase64 { get; set; }
        public bool KisiselBilgiGosterimDurum { get; set; }
        public int ProfilGoruntulemeDurum { get; set; }
        public int ArkadasIstekTalepleriDurum { get; set; }
    }
}
