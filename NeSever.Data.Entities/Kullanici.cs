using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class Kullanici : Entity
    {
        public Kullanici()
        {
            AdresNavigation = new HashSet<Adres>();
            ArkadaslikIstekArkadaslikIstekKullanici = new HashSet<ArkadaslikIstek>();
            ArkadaslikIstekKullanici = new HashSet<ArkadaslikIstek>();
            KullaniciBildirim = new HashSet<Bildirim>();
            KullaniciArkadasArkadasKullanici = new HashSet<KullaniciArkadas>();
            KullaniciArkadasKullanici = new HashSet<KullaniciArkadas>();
            ProfilEngelEngellenenKullanici = new HashSet<ProfilEngel>();
            ProfilEngelEngelleyenKullanici = new HashSet<ProfilEngel>();
            KullaniciHediyeKartAliciKullanici = new HashSet<KullaniciHediyeKart>();
            KullaniciHediyeKartGonderenKullanici = new HashSet<KullaniciHediyeKart>();
            KullaniciHobi = new HashSet<KullaniciHobi>();
            KullaniciIlgiAlan = new HashSet<KullaniciIlgiAlan>();
            KullaniciMesajAliciKullanici = new HashSet<KullaniciMesaj>();
            KullaniciMesajGondericiKullanici = new HashSet<KullaniciMesaj>();
            KullaniciResim = new HashSet<KullaniciResim>();
            KullaniciRol = new HashSet<KullaniciRol>();
            KullaniciUrun = new HashSet<KullaniciUrun>();
            KullaniciSikayetEdilenKullanici = new HashSet<ProfilSikayet>();
            KullaniciSikayetEdenKullanici = new HashSet<ProfilSikayet>();
            KullaniciUrunFiyatGor = new HashSet<KullaniciUrunFiyatGor>();
            KullaniciBakilanProfiller = new HashSet<KullaniciBakilanProfiller>();
            Sepet = new HashSet<Sepet>();
            Siparis = new HashSet<Siparis>();
            SurprizUrun = new HashSet<SurprizUrun>();
        }

        public Guid KullaniciId { get; set; }
        public int? KullaniciSehirId { get; set; }
        public string KullaniciAdi { get; set; }
        public string FacebookId { get; set; }
        public string InstagramId { get; set; }
        public string GoogleId { get; set; }
        public bool FacebookKullanicisiMi { get; set; }
        public bool InstagramKullanicisiMi { get; set; }
        public bool GoogleKullanicisiMi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string IliskiDurumu { get; set; }
        public DateTime UyelikTarihi { get; set; }
        public string Adres { get; set; }
        public string Hakkinda { get; set; }
        public DateTime SonGirisTarihi { get; set; }
        public bool HesapKilitliMi { get; set; }
        public bool EpostaOnayliMi { get; set; }
        public bool AktifMi { get; set; }
        public bool DogumGunleriHatirlatmaDurum { get; set; }
        public bool MesajEpostaBildirimDurum { get; set; }
        public int ProfilGoruntulemeDurum { get; set; }
        public int ArkadasIstekTalepleriDurum { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public bool KisiselBilgiGosterimDurum { get; set; }
        public int ProfilGoruntulenmeSayisi { get; set; }
        public int? DuvarResimId { get; set; }
        public string InstagramAdi { get; set; }
        public virtual KullaniciSehir KullaniciSehir {get; set;}
        public virtual DuvarResim DuvarResim { get; set; }
        public virtual ICollection<Adres> AdresNavigation { get; set; }
        public virtual ICollection<ArkadaslikIstek> ArkadaslikIstekArkadaslikIstekKullanici { get; set; }
        public virtual ICollection<ArkadaslikIstek> ArkadaslikIstekKullanici { get; set; }
        public virtual ICollection<Bildirim> KullaniciBildirim { get; set; }
        public virtual ICollection<KullaniciArkadas> KullaniciArkadasArkadasKullanici { get; set; }
        public virtual ICollection<KullaniciArkadas> KullaniciArkadasKullanici { get; set; }
        public virtual ICollection<KullaniciHediyeKart> KullaniciHediyeKartAliciKullanici { get; set; }
        public virtual ICollection<KullaniciHediyeKart> KullaniciHediyeKartGonderenKullanici { get; set; }
        public virtual ICollection<KullaniciHobi> KullaniciHobi { get; set; }
        public virtual ICollection<KullaniciIlgiAlan> KullaniciIlgiAlan { get; set; }
        public virtual ICollection<KullaniciMesaj> KullaniciMesajAliciKullanici { get; set; }
        public virtual ICollection<KullaniciMesaj> KullaniciMesajGondericiKullanici { get; set; }
        public virtual ICollection<KullaniciResim> KullaniciResim { get; set; }
        public virtual ICollection<KullaniciRol> KullaniciRol { get; set; }
        public virtual ICollection<KullaniciUrun> KullaniciUrun { get; set; }
        public virtual ICollection<ProfilEngel> ProfilEngelEngellenenKullanici { get; set; }
        public virtual ICollection<ProfilEngel> ProfilEngelEngelleyenKullanici { get; set; }
        public virtual ICollection<ProfilSikayet> KullaniciSikayetEdilenKullanici { get; set; }
        public virtual ICollection<ProfilSikayet> KullaniciSikayetEdenKullanici { get; set; }
        public virtual ICollection<KullaniciUrunFiyatGor> KullaniciUrunFiyatGor { get; set; }
        public virtual ICollection<KullaniciBakilanProfiller> KullaniciBakilanProfiller { get; set; }
        public virtual ICollection<Sepet> Sepet { get; set; }
        public virtual ICollection<Siparis> Siparis { get; set; }
        public virtual ICollection<SurprizUrun> SurprizUrun { get; set; }
    }
}
