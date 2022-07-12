using Microsoft.Extensions.Configuration;
using NeSever.Common.Models.Uyelik;
using NeSever.Common.Utils.RandomString;
using NeSever.Data.Entities;
using System;
using System.Collections.Generic;

namespace NeSever.BusinessDomain.Uyelik
{
    public class UyelikDomain
    {
        public static Kullanici Kayit(KullaniciKayitVM model)
        {
            var kullanici = new Kullanici()
            {
                KullaniciId = Guid.NewGuid(),
                KullaniciAdi = model.KullaniciKayitKullaniciAdi.Trim(),
                Adi = model.KullaniciKayitAd.Trim(),
                Soyadi = model.KullaniciKayitSoyad.Trim(),
                Sifre = model.KullaniciKayitSifre.Trim(),
                Eposta = model.KullaniciKayitEposta.Trim(),
                DogumTarihi = new DateTime(model.KullaniciKayitDogumYil, model.KullaniciKayitDogumAy, model.KullaniciKayitDogumGun),
                Cinsiyet = model.KullaniciKayitCinsiyet.Trim(),
                UyelikTarihi = DateTime.Now,
                SonGirisTarihi = DateTime.Now,
                HesapKilitliMi = false,
                EpostaOnayliMi = false,
                ArkadasIstekTalepleriDurum = 1,
                ProfilGoruntulemeDurum = 1,
                DogumGunleriHatirlatmaDurum = true,
                MesajEpostaBildirimDurum = true,
                AktifMi = true
            };

            return kullanici;
        }


        public static KullaniciKisiselBilgiKaydetGuncelleVM Guncelle(KullaniciKisiselBilgiKaydetGuncelleVM kullaniciKisiselBilgi)
        {
            kullaniciKisiselBilgi.Adi = kullaniciKisiselBilgi.Adi.Trim();
            kullaniciKisiselBilgi.Soyadi = kullaniciKisiselBilgi.Soyadi.Trim();
            kullaniciKisiselBilgi.Eposta = kullaniciKisiselBilgi.Eposta;
            kullaniciKisiselBilgi.DogumTarihi = kullaniciKisiselBilgi.DogumTarihi;
            kullaniciKisiselBilgi.Cinsiyet = kullaniciKisiselBilgi.Cinsiyet.Trim();
            kullaniciKisiselBilgi.KullaniciSehirId = kullaniciKisiselBilgi.KullaniciSehirId;
            kullaniciKisiselBilgi.Adres = kullaniciKisiselBilgi.Adres;
            kullaniciKisiselBilgi.IliskiDurumu = kullaniciKisiselBilgi.IliskiDurumu;
            kullaniciKisiselBilgi.Hakkinda = kullaniciKisiselBilgi.Hakkinda;
            kullaniciKisiselBilgi.Telefon = kullaniciKisiselBilgi.Telefon;

            return kullaniciKisiselBilgi;
        }


        public static Kullanici KullaniciRefreshTokenSil(Kullanici kullanici)
        {
            kullanici.RefreshToken = null;
            kullanici.RefreshTokenEndDate = null;
            return kullanici;
        }

        public static Kullanici KullaniciRefreshTokenKaydet(Kullanici kullanici, string refreshToken)
        {
            int refreshTokenExpiration = 60;
            var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("TokenOptions");
            if (appSettings != null)
                refreshTokenExpiration = Convert.ToInt32(appSettings["RefreshTokenExpiration"]);

            kullanici.RefreshToken = refreshToken;
            kullanici.RefreshTokenEndDate = DateTime.Now.AddMinutes(refreshTokenExpiration);
            return kullanici;
        }
        public static Kullanici KullaniciKilitle(Kullanici kullanici)
        {
            if (kullanici.AktifMi == true)
            {
                kullanici.AktifMi = false;
            }
            return kullanici;
        }
        public static Kullanici KullaniciKilitKaldir(Kullanici kullanici)
        {
            if (kullanici.AktifMi == false)
            {
                kullanici.AktifMi = true;
            }
            return kullanici;
        }
        public static KullaniciArkadas KullaniciArkadasKaydet(Guid kullaniciId, Guid arkadasId)
        {
            KullaniciArkadas arkadas = new KullaniciArkadas();
            arkadas.KullaniciId = kullaniciId;
            arkadas.ArkadasKullaniciId = arkadasId;
            arkadas.KayitTarihi = DateTime.Now;
            arkadas.AktifMi = true;
            return arkadas;
        }

        public static ArkadaslikIstek KullaniciIstekKaydet(Guid istekGonderenKullaniciId, Guid istekAlanKullaniciId)
        {
            ArkadaslikIstek istek = new ArkadaslikIstek();
            istek.KullaniciId = istekAlanKullaniciId;
            istek.ArkadaslikIstekKullaniciId = istekGonderenKullaniciId;
            istek.ArkadaslikKabulDurumTipId = 1;
            istek.KayitTarihi = DateTime.Now;
            istek.AktifMi = true;
            return istek;
        }

        public static ArkadaslikIstek KullaniciIstekGuncelle(ArkadaslikIstek istek)
        {
            istek.ArkadaslikKabulDurumTipId = 2;
            return istek;
        }
        public static IEnumerable<ArkadaslikIstek> ArkadaslikIstekleriniOku(List<ArkadaslikIstek> istek)
        {
            istek.ForEach(a => a.OkunduMu = true);
            return istek;
        }
        public static ArkadaslikIstek KullaniciIstekReddet(ArkadaslikIstek istek)
        {
            istek.ArkadaslikKabulDurumTipId = 3;
            return istek;
        }

        public static Kullanici FacebookKullanicisiKaydet(KullaniciFbGirisVM model)
        {
            var kullanici = new Kullanici()
            {
                KullaniciId = Guid.NewGuid(),
                KullaniciAdi = KullaniciAdiOlustur(model.Name),
                Adi = model.First_Name,
                Soyadi = model.Last_Name,
                Eposta = model.Email,
                DogumTarihi = DateTime.Now.AddYears(-18),
                Cinsiyet = "B",
                UyelikTarihi = DateTime.Now,
                SonGirisTarihi = DateTime.Now,
                HesapKilitliMi = false,
                EpostaOnayliMi = false,
                ArkadasIstekTalepleriDurum = 1,
                ProfilGoruntulemeDurum = 1,
                DogumGunleriHatirlatmaDurum = true,
                MesajEpostaBildirimDurum = true,
                AktifMi = true,
                FacebookKullanicisiMi = true,
                FacebookId = model.Id
            };
            return kullanici;
        }


        public static Kullanici InstegramKullanicisiKaydet(KullaniciInstegramGirisVM model)
        {
            var kullanici = new Kullanici()
            {
                KullaniciId = Guid.NewGuid(),
                KullaniciAdi = KullaniciAdiOlustur(model.Username),
                Adi = model.Name,
                Eposta = model.Email,
                DogumTarihi = DateTime.Now.AddYears(-18),
                Cinsiyet = "B",
                UyelikTarihi = DateTime.Now,
                SonGirisTarihi = DateTime.Now,
                HesapKilitliMi = false,
                EpostaOnayliMi = false,
                ArkadasIstekTalepleriDurum = 1,
                ProfilGoruntulemeDurum = 1,
                DogumGunleriHatirlatmaDurum = true,
                MesajEpostaBildirimDurum = true,
                AktifMi = true,
                InstagramKullanicisiMi = true,
                InstagramId = model.Id
            };
            return kullanici;
        }



        public static Kullanici GoogleKullanicisiKaydet(KullaniciGoogleGirisVM model)
        {
            var kullanici = new Kullanici()
            {
                KullaniciId = Guid.NewGuid(),
                KullaniciAdi = KullaniciAdiOlustur(model.Name),
                Adi = model.Name,
                Soyadi = model.Lastname,
                Eposta = model.Email,
                DogumTarihi = DateTime.Now.AddYears(-18),
                Cinsiyet = "B",
                UyelikTarihi = DateTime.Now,
                SonGirisTarihi = DateTime.Now,
                HesapKilitliMi = false,
                EpostaOnayliMi = false,
                ArkadasIstekTalepleriDurum = 1,
                ProfilGoruntulemeDurum = 1,
                DogumGunleriHatirlatmaDurum = true,
                MesajEpostaBildirimDurum = true,
                AktifMi = true,
                GoogleKullanicisiMi = true,
                GoogleId = model.Id
            };
            return kullanici;
        }



        public static string KullaniciAdiOlustur(string fbKullaniciAdi)
        {
            var generator = new StringGenerator();
            var randomString = generator.RandomStringAndNumber();
            fbKullaniciAdi = fbKullaniciAdi.ToLower().Replace(" ", "_");
            fbKullaniciAdi += "_";
            fbKullaniciAdi = string.Concat(fbKullaniciAdi, randomString);
            return fbKullaniciAdi;
        }

        public static Kullanici KullaniciyiFacebookKullanicisiGuncelle(Kullanici kullanici, KullaniciFbGirisVM fbGirisVM)
        {
            kullanici.FacebookKullanicisiMi = true;
            kullanici.FacebookId = fbGirisVM.Id;
            return kullanici;
        }

        public static Kullanici KullaniciyiInstegramKullanicisiGuncelle(Kullanici kullanici, KullaniciInstegramGirisVM instegramGirisVM)
        {
            kullanici.InstagramKullanicisiMi = true;
            kullanici.FacebookId = instegramGirisVM.Id;
            return kullanici;
        }

        public static Kullanici KullaniciyiGoogleKullanicisiGuncelle(Kullanici kullanici, KullaniciGoogleGirisVM googleGirisVM)
        {
            kullanici.GoogleKullanicisiMi = true;
            kullanici.GoogleId = googleGirisVM.Id;
            return kullanici;
        }



        public static Kullanici SocialKullanicisiniNormalKaydet(Kullanici kullanici, Kullanici kayitliKullanici)
        {
            kayitliKullanici.KullaniciAdi = kullanici.KullaniciAdi;
            kayitliKullanici.DogumTarihi = kullanici.DogumTarihi;
            kayitliKullanici.Cinsiyet = kullanici.Cinsiyet;
            kayitliKullanici.SonGirisTarihi = DateTime.Now;
            return kullanici;
        }

        public static KullaniciMesaj KullaniciMesajKaydet(MesajGonderVM vm)
        {
            KullaniciMesaj mesaj = new KullaniciMesaj();
            mesaj.AktifMi = true;
            mesaj.AliciKullaniciId = new Guid(vm.AlanKullanici);
            mesaj.GondericiKullaniciId = new Guid(vm.GonderenKullanici);
            mesaj.GonderenAktifMi = true;
            mesaj.AlanAktifMi = true;
            mesaj.MesajIcerik = vm.GidenMesaj;
            mesaj.KayitTarih = DateTime.Now;
            return mesaj;
        }

        public static KullaniciArkadas ArkadasSil(KullaniciArkadas arkadas)
        {
            arkadas.AktifMi = false;
            return arkadas;
        }



        public static IEnumerable<KullaniciMesaj> MesajlariOku(List<KullaniciMesaj> istek)
        {
            istek.ForEach(a => a.OkunduMu = true);
            return istek;
        }
    }
}
