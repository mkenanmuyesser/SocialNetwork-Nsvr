using NeSever.Common.Models.Uyelik;
using System;
using System.Collections.Generic;

namespace NeSever.Common.Models.FrontEnd
{
    public class ProfilSolMenuVM
    {
        public bool KisiselBilgiGosterimDurum { get; set; }
        public bool ArkadasProfil { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Hakkinda { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Sehir { get; set; }
        public string Ulke { get; set; }      
        public string Cinsiyet { get; set; }
        public string IliskiDurumu { get; set; }
        public int SiparisSayi { get; set; }
        public int AdresSayi { get; set; }
        public int HediyeSepetiSayi { get; set; }
        public int MesajSayi { get; set; }
        public int BildirimSayi { get; set; }
        public int ArkadasIstekSayi { get; set; }
        public int ArkadasSayi { get; set; }
        public int BakilanProfilSayi { get; set; }
        public int HediyeKartSayi { get; set; }
        public int KullaniciResimSayi { get; set; }
        public int ProfilGoruntulenmeSayisi { get; set; }
        public int IndirimKuponuSayisi { get; set; }

        public bool ProfilKullaniciMi { get; set; }
        public List<KullaniciHobiVM> KullaniciHobi { get; set; }
        public List<KullaniciIlgiAlanVM> KullaniciIlgiAlan { get; set; }

    }
}
