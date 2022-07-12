using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeServer.Business.Uyelik;
using NeSever.Common.Commands.Uyelik;
using NeSever.Common.Models;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Uyelik;
using NeSever.Data.Entities;
using System;
using System.Threading.Tasks;

namespace NeSever.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UyelikController : Controller
    {
        private readonly IUyelikBusiness uyelikBusiness;

        public UyelikController(IUyelikBusiness uyelikBusiness)
        {
            this.uyelikBusiness = uyelikBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("KullaniciKaydet")]
        public async Task<IActionResult> KullaniciKaydet([FromBody] KullaniciKayitVM kullanici)
        {



            var kullaniciKayitResult = await uyelikBusiness.KullaniciKaydet(kullanici);

            return Ok(kullaniciKayitResult);
        }

        [HttpPost]
        //[Authorize]
        [Route("KullaniciSil")]
        public async Task<IActionResult> KullaniciSil([FromBody] KullaniciSilVM vm)
        {
            var kullaniciSilResult = await uyelikBusiness.KullaniciSil(new KullaniciSilCommand
            {
                Kullanici = vm
            });
            return Ok(kullaniciSilResult);
        }

        [HttpPost]
        [Route("KullaniciGirisYap")]
        public async Task<IActionResult> KullaniciGirisYap([FromBody] KullaniciGirisVM kullanici)
        {
            var kullaniciGirisResult = await uyelikBusiness.KullaniciGirisYapByEmailPassword(new KullaniciGirisCommand
            {
                Kullanici = kullanici
            });
            return Ok(kullaniciGirisResult);
        }


        [HttpPost]
        [Route("KullaniciFbGirisYap")]
        public async Task<IActionResult> KullaniciFbGirisYap([FromBody] KullaniciFbGirisVM kullanici)
        {
            var kullaniciGirisResult = await uyelikBusiness.KullaniciGirisYapWithFacebook(kullanici);
            return Ok(kullaniciGirisResult);
        }


        [HttpPost]
        [Route("KullaniciGoogleGirisYap")]
        public async Task<IActionResult> KullaniciGoogleGirisYap([FromBody] KullaniciGoogleGirisVM kullanici)
        {
            var kullaniciGirisResult = await uyelikBusiness.KullaniciGirisYapWithGoogle(kullanici);
            return Ok(kullaniciGirisResult);
        }



        [HttpPost]
        [Route("KullaniciInstegramGirisYap")]
        public async Task<IActionResult> KullaniciInstegramGirisYap([FromBody] KullaniciInstegramGirisVM kullanici)
        {
            var kullaniciGirisResult = await uyelikBusiness.KullaniciGirisYapWithInstegram(kullanici);
            return Ok(kullaniciGirisResult);
        }




        [HttpPost]
        [Route("KullaniciTokenYenile")]
        public async Task<IActionResult> KullaniciTokenYenile([FromBody] KullaniciTokenYenileSilVM token)
        {
            var kullaniciTokenYenileResult = await uyelikBusiness.KullaniciTokenYenile(token);
            return Ok(kullaniciTokenYenileResult);
        }

        //[Authorize]
        [HttpPost]
        [Route("KullaniciCikis")]
        public async Task<IActionResult> KullaniciCikis([FromBody] string token)
        {
            var kullaniciTokenSilResult = await uyelikBusiness.RefreshTokenSil(new KullaniciRefreshTokenKaydetSilCommand
            {
                RefreshToken = token
            });
            return Ok(kullaniciTokenSilResult);
        }

        //[Authorize]
        [HttpPost]
        [Route("KullaniciKisiselBilgileriGetir")]
        public async Task<IActionResult> KullaniciKisiselBilgileriGetir([FromBody] string token)
        {
            var kullaniciKisiselBilgileriSonuc = await uyelikBusiness.KullaniciKisiselBilgileriGetir(new KullaniciTokenCommand
            {
                RefreshToken = token
            });
            return Ok(kullaniciKisiselBilgileriSonuc);
        }

        
        [HttpPost]
        [Route("SehirleriGetir")]
        public async Task<IActionResult> SehirleriGetir()
        {
            var sehirlerSonuc = await uyelikBusiness.SehirleriGetir();
            return Ok(sehirlerSonuc);
        }

        [HttpPost]
        //[Authorize]
        [Route("KullaniciGetir")]
        public async Task<IActionResult> KullaniciGetir([FromBody] string token)
        {
            var kullaniciGetirResult = await uyelikBusiness.KullaniciGetir(new KullaniciGetirCommand
            {
                RefreshToken = token
            });
            return Ok(kullaniciGetirResult);
        }

        [HttpPost]
        //[Authorize]
        [Route("KullaniciKisiselBilgiKaydetGuncelle")]
        public async Task<IActionResult> KullaniciKisiselBilgiKaydetGuncelle([FromBody] KullaniciKisiselBilgiKaydetGuncelleVM kullaniciKisiselBilgi)
        {
            var kullaniciGetirResult = await uyelikBusiness.KullaniciKisiselBilgiKaydetGuncelle(kullaniciKisiselBilgi);
            return Ok(kullaniciGetirResult);
        }

        [HttpPost]
        //[Authorize]
        [Route("SifreKaydetGuncelle")]
        public async Task<IActionResult> SifreKaydetGuncelle([FromBody] SifreDegistirVM vm)
        {
            var sifreKaydetGuncelleSonuc = await uyelikBusiness.SifreKaydetGuncelle(vm);
            return Ok(sifreKaydetGuncelleSonuc);
        }

        [HttpPost]
        //[Authorize]
        [Route("AyarlarKaydetGuncelle")]
        public async Task<IActionResult> AyarlarKaydetGuncelle([FromBody] AyarlarVM vm)
        {
            var ayarlarKaydetGuncelleSonuc = await uyelikBusiness.AyarlarKaydetGuncelle(vm);
            return Ok(ayarlarKaydetGuncelleSonuc);
        }

        [HttpPost]
        //[Authorize]
        [Route("KullaniciAyarlariniGetir")]
        public async Task<IActionResult> KullaniciAyarlariniGetir([FromBody] string token)
        {
            var ayarlarKaydetGuncelleSonuc = await uyelikBusiness.KullaniciAyarlariniGetir(token);
            return Ok(ayarlarKaydetGuncelleSonuc);
        }

        [HttpPost]
        //[Authorize]
        [Route("KullaniciArkadasListesiGetir")]
        public async Task<IActionResult> KullaniciArkadasListesiGetir([FromBody] ArkadasListeAramaVM vm)
        {
            var subset = await uyelikBusiness.KullaniciArkadasListesiGetir(vm);
            var result = new { items = subset, metaData = subset.GetMetaData() };
            return Ok(result);
        }

        [HttpPost]
        //[Authorize]
        [Route("KullaniciArkadasListesiGetirDogumGunleriIcin")]
        public async Task<IActionResult> KullaniciArkadasListesiGetirDogumGunleriIcin([FromBody] ArkadasListesiGetirVM vm)
        {
            var result = await uyelikBusiness.KullaniciArkadasListesiGetirDogumGunleriIcin(vm);
            return Ok(result);
        }

        [HttpPost]
        //[Authorize]
        [Route("ArkadasMenuDegerleriGetir")]
        public async Task<IActionResult> ArkadasMenuDegerleriGetir([FromBody] TokenVM vm)
        {
            var ayarlarKaydetGuncelleSonuc = await uyelikBusiness.ArkadasMenuDegerleriGetir(vm);
            return Ok(ayarlarKaydetGuncelleSonuc);
        }

        [HttpPost]
        //[Authorize]
        [Route("ArkadasIstekleriniGetir")]
        public async Task<IActionResult> ArkadasIstekleriniGetir([FromBody] TokenVM vm)
        {
            var arkadasIstekleriSonuc = await uyelikBusiness.ArkadasIstekleriniGetir(vm);
            return Ok(arkadasIstekleriSonuc);
        }
        [HttpPost]
        //[Authorize]
        [Route("ArkadasIstekleriniOku")]
        public async Task<IActionResult> ArkadasIstekleriniOku([FromBody] TokenVM vm)
        {
            var arkadasIstekleriSonuc = await uyelikBusiness.ArkadasIstekleriniOku(vm);
            return Ok(arkadasIstekleriSonuc);
        }
        [HttpPost]
        //[Authorize]
        [Route("ArkadaslikIsteginiKabulEt")]
        public async Task<IActionResult> ArkadaslikIsteginiKabulEt([FromBody] ArkadaslikIsteginiKabulEtVM vm)
        {
            var arkadasIstekleriSonuc = await uyelikBusiness.ArkadaslikIsteginiKabulEt(vm);
            return Ok(arkadasIstekleriSonuc);
        }

        [HttpPost]
        //[Authorize]
        [Route("ArkadaslikIsteginiReddet")]
        public async Task<IActionResult> ArkadaslikIsteginiReddet([FromBody] ArkadaslikIsteginiSilVM vm)
        {
            var arkadasIstekleriSonuc = await uyelikBusiness.ArkadaslikIsteginiReddet(vm);
            return Ok(arkadasIstekleriSonuc);
        }

        [HttpPost]
        [Route("ArkadasAramaListGetir")]
        public async Task<IActionResult> ArkadasAramaListGetir(ArkadasAramaVM arkadasAramaVM)
        {
            var subset = await uyelikBusiness.ArkadasAramaListGetir(arkadasAramaVM);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }

        [HttpPost]
        [Route("ArkadaslikIstekGonder")]
        //[Authorize]
        public async Task<IActionResult> ArkadaslikIstekGonder(ArkadaslikIstegiGonderVM vm)
        {
            var result = await uyelikBusiness.ArkadaslikIstekGonder(vm);
            return Ok(result);
        }

        [HttpPost]
        [Route("ArkadaslikIstekGonderildiMi")]
        //[Authorize]
        public async Task<IActionResult> ArkadaslikIstekGonderildiMi(ArkadaslikIstegiGonderVM vm)
        {
            var result = await uyelikBusiness.ArkadaslikIstekGonderildiMi(vm);
            return Ok(result);
        }

        [HttpPost]
        [Route("ArkadaslikIstekBanaGonderildiMi")]
        //[Authorize]
        public async Task<IActionResult> ArkadaslikIstekBanaGonderildiMi(ArkadaslikIstegiGonderVM vm)
        {
            var result = await uyelikBusiness.ArkadaslikIstekBanaGonderildiMi(vm);
            return Ok(result);
        }

        [HttpPost]
        [Route("ArkadasProfilGetir")]
        public async Task<IActionResult> ArkadasProfilGetir(ArkadasProfilGetirVM vm)
        {
            var result = await uyelikBusiness.ArkadaslikProfilGetir(vm);
            return Ok(result);
        }

        [HttpGet]
        [Route("KullaniciProfilGoruntulenmeSayisiGetir")]
        public async Task<IActionResult> KullaniciProfilGoruntulenmeSayisiGetir(Guid kullaniciId)
        {
            var result = await uyelikBusiness.KullaniciProfilGoruntulenmeSayisiGetir(kullaniciId);
            return Ok(result);
        }

        [HttpPost]
        [Route("ArkadasMesajGonder")]
        //[Authorize]
        public async Task<IActionResult> ArkadasMesajGonder(MesajGonderVM vm)
        {
            var result = await uyelikBusiness.ArkadasMesajGonder(vm);
            return Ok(result);
        }

        [HttpPost]
        [Route("ArkadasSil")]
        //[Authorize]
        public async Task<IActionResult> ArkadasSil(ArkadasSilVM vm)
        {
            var result = await uyelikBusiness.ArkadasSil(vm);
            return Ok(result);
        }

        [HttpPost]
        [Route("MesajDetayGetir")]
        //[Authorize]
        public async Task<IActionResult> MesajDetayGetir(MesajDetayGetirVM vm)
        {
            var result = await uyelikBusiness.MesajDetayGetir(vm);
            return Ok(result);
        }
        [HttpPost]
        [Route("MesajlariOku")]
        //[Authorize]
        public async Task<IActionResult> MesajlariOku(MesajDetayGetirVM vm)
        {
            var result = await uyelikBusiness.MesajlariOku(vm);
            return Ok(result);
        }
        [HttpPost]
        [Route("KonusmaSil")]
        //[Authorize]
        public async Task<IActionResult> KonusmaSil(KonusmaSilVM vm)
        {
            var result = await uyelikBusiness.KonusmaSil(vm);
            return Ok(result);
        }

        [HttpPost]
        [Route("MesajSil")]
        //[Authorize]
        public async Task<IActionResult> MesajSil(MesajSilVM vm)
        {
            var result = await uyelikBusiness.MesajSil(vm);
            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciArkadasMesajListesiGetir")]
        //[Authorize]
        public async Task<IActionResult> KullaniciArkadasMesajListesiGetir(ArkadasMesajListeVM vm)
        {
            var subset = await uyelikBusiness.KullaniciMesajListesiGetir(vm);
            var result = new { items = subset, metaData = subset.GetMetaData() };
            return Ok(result);

        }

        [HttpPost]
        [Route("ArkadasAra")]
        //[Authorize]
        public async Task<IActionResult> ArkadasAra(ArkadasAraVM vm)
        {
            var result = await uyelikBusiness.ArkadasAra(vm);
            return Ok(result);

        }

        [HttpPost]
        [Route("ArkadasArama")]
        public async Task<IActionResult> ArkadasArama(ArkadasAraVM vm)
        {
            var result = await uyelikBusiness.ArkadasAra(vm);
            return Ok(result);

        }

        //TODO ŞG: Üst menü arama alanı için kullanılacak.
        //[HttpPost]
        //[Route("HizliArkadasAra")]
        //public async Task<IActionResult> HizliArkadasAra(HizliArkadasAraVM vm)
        //{
        //    var result = await uyelikBusiness.HizliArkadasAra(vm);
        //    return Ok(result);

        //}

        [HttpGet]
        [Route("KullaniciGetirByKullaniciAdi")]
        public async Task<IActionResult> KullaniciGetirByKullaniciAdi(string kullaniciAdi)
        {
            var result = await uyelikBusiness.KullaniciGetirByKullaniciAdi(kullaniciAdi);
            return Ok(result);

        }

        [HttpPost]
        [Route("KisiAra")]
        public async Task<IActionResult> KisiAra(KisiAraVM vm)
        {
            var result = await uyelikBusiness.KisiAra(vm);
            return Ok(result);

        }
        [HttpPost]
        [Route("KullaniciHediyeKartKayit")]
        public async Task<IActionResult> KullaniciHediyeKartKayit(KullaniciHediyeKartKayitVM model)
        {
            var kullaniciHediyeKartKayitResult = await uyelikBusiness.KullaniciHediyeKartKayit(model);
            return Ok(kullaniciHediyeKartKayitResult);
        }

        [HttpPost]
        [Route("KullaniciHediyeKartListesiGetir")]
        //[Authorize]
        public async Task<IActionResult> KullaniciHediyeKartListesiGetir(HediyeKartListeVM vm)
        {
            var subset = await uyelikBusiness.KullaniciHediyeKartListesiGetir(vm);
            var result = new { items = subset, metaData = subset.GetMetaData() };
            return Ok(result);

        }
        [HttpPost]
        [Route("HediyeKartDetayGetir")]
        //[Authorize]
        public async Task<IActionResult> HediyeKartDetayGetir(HediyeKartDetayGetirVM vm)
        {
            var result = await uyelikBusiness.HediyeKartDetayGetir(vm);
            return Ok(result);
        }

        [HttpPost]
        [Route("HediyeKartSil")]
        //[Authorize]
        public async Task<IActionResult> HediyeKartSil(HediyeKartSilVM vm)
        {
            var result = await uyelikBusiness.HediyeKartSil(vm);
            return Ok(result);
        }
        [HttpPost]
        [Route("HediyeKartKonusmaSil")]
        //[Authorize]
        public async Task<IActionResult> HediyeKartKonusmaSil(KonusmaSilVM vm)
        {
            var result = await uyelikBusiness.HediyeKartKonusmaSil(vm);
            return Ok(result);
        }

        [HttpGet]
        [Route("HediyeKartMesajIcerikGetirById")]
        public async Task<IActionResult> HediyeKartMesajIcerikGetirById(int id)
        {
            var result = await uyelikBusiness.HediyeKartMesajIcerikGetirById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("ProfilSagMenuGetir")]
        //[Authorize]
        public async Task<IActionResult> ProfilSagMenuGetir(ProfilSagMenuAraVM model)
        {
            var result = await uyelikBusiness.ProfilSagMenuGetir(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("KullaniciArkadasKullaniciMi")]
        public async Task<IActionResult> KullaniciArkadasKullaniciMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            var result = await uyelikBusiness.KullaniciArkadasKullaniciMi(kullaniciId, kullaniciArkadasId);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciBakilanProfilEkle")]
        public async Task<bool> KullaniciBakilanProfilEkle(KullaniciBakilanProfillerVM bakilanProfil)
        {
            return await uyelikBusiness.KullaniciBakilanProfilEkle(bakilanProfil);
        }

        [HttpPost]
        [Route("BakilanProfilSil")]
        public async Task<bool> BakilanProfilSil(BakilanProfilSilVM bakilanProfil)
        {
            return await uyelikBusiness.KullaniciBakilanProfilSil(bakilanProfil);
        }

        [HttpPost]
        [Route("BakilanTumProfilleriSil")]
        public async Task<bool> BakilanTumProfilleriSil(KullaniciVM vm)
        {
            return await uyelikBusiness.BakilanTumProfilleriSil(vm);
        }

        [HttpGet]
        [Route("KullaniciArkadasiminArkadasiMi")]
        public async Task<IActionResult> KullaniciArkadasiminArkadasiMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            var result = await uyelikBusiness.KullaniciArkadasiminArkadasiMi(kullaniciId, kullaniciArkadasId);

            return Ok(result);
        }

        [HttpPost]
        [Route("ProfilArkadasEkle")]
        //[Authorize]
        public async Task<IActionResult> ProfilArkadasEkle(ArkadaslikIstegiGonderVM vm)
        {
            var result = await uyelikBusiness.ProfilArkadasEkle(vm);
            return Ok(result);
        }
        [HttpPost]
        [Route("KullaniciAdiGuncelle")]
        public async Task<IActionResult> KullaniciAdiGuncelle([FromBody] KullaniciAdiVM kullanici)
        {

            var kullaniciResult = await uyelikBusiness.KullaniciAdiGuncelle(kullanici);

            return Ok(kullaniciResult);
        }
        [HttpGet]
        [Route("KullaniciGetirByKullaniciId")]
        public async Task<IActionResult> KullaniciGetirByKullaniciId(Guid kullaniciId)
        {
            var result = await uyelikBusiness.KullaniciGetirByKullaniciId(kullaniciId);
            return Ok(result);

        }
        [HttpPost]
        [Route("HediyeKartOkunduIsaretle")]
        //[Authorize]
        public async Task<IActionResult> HediyeKartOkunduIsaretle(HediyeKartOkunduVM hediyeKartOkundu)
        {
            var result = await uyelikBusiness.HediyeKartOkunduIsaretle(hediyeKartOkundu);
            return Ok(result);
        }
        [HttpPost]
        [Route("BildirimKullaniciListGetir")]
        public async Task<IActionResult> BildirimKullaniciListGetir(KisiyeOzelBildirimVM data)
        {
            var result = await uyelikBusiness.BildirimKullaniciListGetir(data);

            return Ok(result);
        }
        #region ProfilEngel

        #region Admin

        #endregion

        #region FrontEnd

        [HttpPost]
        [Route("ProfilEngelKaydet")]
        public async Task<IActionResult> ProfilEngelKaydet(ProfilEngelVM model)
        {
            var result = await uyelikBusiness.ProfilEngelKaydet(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("ProfilEngelSil")]
        public async Task<IActionResult> ProfilEngelSil(ProfilEngelVM model)
        {
            var result = await uyelikBusiness.ProfilEngelSil(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("ProfilEngelListGetir")]
        public async Task<IActionResult> ProfilEngelListGetir(EngellenenProfilListesiAramaVM model)
        {
            var subset = await uyelikBusiness.ProfilEngelListGetir(model);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }

        #endregion

        #endregion

        #region ProfilSikayet

        #region Admin
        [HttpPost]
        [Route("ProfilSikayetArama")]
        public async Task<IActionResult> ProfilSikayetArama(ProfilSikayetAramaVM model)
        {
            var result = await uyelikBusiness.ProfilSikayetArama(model);
            return Ok(result);
        }
        #endregion

        #region FrontEnd
        [HttpPost]
        [Route("ProfilSikayetKaydet")]
        public async Task<IActionResult> ProfilSikayetKaydet(ProfilSikayetVM model)
        {
            var result = await uyelikBusiness.ProfilSikayetKaydet(model);
            return Ok(result);
        }
        #endregion

        #endregion

        #region KullaniciHobi

        #region Admin       

        #endregion

        #region FrontEnd
        //[Authorize]
        [HttpPost]
        [Route("HobileriGetir")]
        public async Task<IActionResult> HobileriGetir([FromBody] HobileriGetirVM hobiler)
        {
            var hobilerSonuc = await uyelikBusiness.HobileriGetir(hobiler.Query);
            return Ok(hobilerSonuc);
        }

        [HttpGet]
        [Route("KullaniciHobiIlgiAlanGetir")]
        public async Task<IActionResult> KullaniciHobiIlgiAlanGetir(Guid kullaniciId)
        {
            var result = await uyelikBusiness.KullaniciHobiIlgiAlanGetir(kullaniciId);
            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciHobiKaydetGuncelle")]
        public async Task<IActionResult> KullaniciHobiKaydetGuncelle(KullaniciHobiKaydetGuncelleVM model)
        {
            var result = await uyelikBusiness.KullaniciHobiKaydetGuncelle(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciIlgiAlanKaydetGuncelle")]
        public async Task<IActionResult> KullaniciIlgiAlanKaydetGuncelle(KullaniciIlgiAlanKaydetGuncelleVM model)
        {
            var result = await uyelikBusiness.KullaniciIlgiAlanKaydetGuncelle(model);
            return Ok(result);
        }
        #endregion

        #endregion

        #region KullaniciIlgiAlan

        #region Admin       

        #endregion

        #region FrontEnd
        //[Authorize]
        [HttpPost]
        [Route("IlgiAlanlariniGetir")]
        public async Task<IActionResult> IlgiAlanlariniGetir([FromBody] IlgiAlanGetirVM ilgiAlan)
        {
            var hobilerSonuc = await uyelikBusiness.IlgiAlanGetir(ilgiAlan.Query);
            return Ok(hobilerSonuc);
        }
        #endregion

        #endregion

        #region KullaniciUrun

        #region Admin       

        #endregion

        #region FrontEnd

        [HttpPost]
        [Route("KullaniciHediyeEkle")]
        public async Task<IActionResult> KullaniciHediyeEkle(KullaniciUrunEkleSilVM model)
        {
            var result = await uyelikBusiness.KullaniciHediyeEkle(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciHediyeSil")]
        public async Task<IActionResult> KullaniciHediyeSil(KullaniciUrunEkleSilVM model)
        {
            var result = await uyelikBusiness.KullaniciHediyeSil(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciHediyeSepetiGetir")]
        public async Task<IActionResult> KullaniciHediyeSepetiGetir(KullaniciUrunListesiAramaVM model)
        {
            var subset = await uyelikBusiness.KullaniciHediyeSepetiGetir(model);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciArkadasListesiModalGetir")]
        public async Task<IActionResult> KullaniciArkadasListesiModalGetir(KullaniciArkadasListesiModalAramaVM model)
        {
            var subset = await uyelikBusiness.KullaniciArkadasListesiModalGetir(model);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciBakilanProfilleriGetir")]
        public async Task<IActionResult> KullaniciBakilanProfilleriGetir(KullaniciArkadasListesiModalAramaVM model)
        {
            var subset = await uyelikBusiness.KullaniciBakilanProfilleriGetir(model);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }

        [HttpGet]
        [Route("KullaniciHediyeSepetiSayisiGetir")]
        public async Task<IActionResult> KullaniciHediyeSepetiSayisiGetir(Guid kullaniciId)
        {
            var result = await uyelikBusiness.KullaniciHediyeSepetiSayisiGetir(kullaniciId);

            return Ok(result);
        }

        #endregion

        #endregion

        #region KullaniciResim
        [HttpPost]
        [Route("KullaniciProfilResimKaydetGuncelle")]
        public async Task<IActionResult> KullaniciProfilResimKaydetGuncelle([FromBody] KullaniciResimVM kullaniciResimtVM)
        {
            var kullaniciKayitResult = await uyelikBusiness.KullaniciProfilResimKaydetGuncelle(kullaniciResimtVM);
            return Ok(kullaniciKayitResult);
        }
        [HttpPost]
        [Route("KullaniciResimKaydet")]
        public async Task<IActionResult> KullaniciResimKaydet([FromBody] KullaniciResimVM kullaniciResimtVM)
        {
            var kullaniciKayitResult = await uyelikBusiness.KullaniciResimKaydet(kullaniciResimtVM);
            return Ok(kullaniciKayitResult);
        }
        [HttpPost]
        [Route("KullaniciResimGetir")]
        public async Task<IActionResult> KullaniciResimGetir([FromBody] Guid kullaniciId)
        {
            var KullaniciResim = await uyelikBusiness.KullaniciResimGetir(kullaniciId);
            return Ok(KullaniciResim);
        }
        [HttpGet]
        [Route("KullaniciResimListele")]
        public async Task<IActionResult> KullaniciResimListele(string kullaniciId)
        {
            var KullaniciResimList = await uyelikBusiness.KullaniciResimListele(kullaniciId);
            return Ok(KullaniciResimList);
        }
        [HttpGet]
        [Route("KullaniciResimGetirByResimId")]
        public async Task<IActionResult> KullaniciResimGetirByResimId(int resimId)
        {
            var KullaniciResimList = await uyelikBusiness.KullaniciResimGetirByResimId(resimId);
            return Ok(KullaniciResimList);
        }
        [HttpGet]
        [Route("ProfilResminiDegistir")]
        public async Task<IActionResult> ProfilResminiDegistir(Guid kullaniciId, int resimId)
        {
            var KullaniciResim = await uyelikBusiness.ProfilResminiDegistir(kullaniciId, resimId);
            return Ok(KullaniciResim);
        }

        [HttpGet]
        [Route("KullaniciResimSil")]
        public async Task<IActionResult> KullaniciResimSil(Guid kullaniciId, int resimId)
        {
            var KullaniciResim = await uyelikBusiness.KullaniciResimSil(kullaniciId, resimId);
            return Ok(KullaniciResim);
        }

        [HttpGet]
        [Route("KullaniciResimListesiGetir")]
        public async Task<IActionResult> KullaniciResimListesiGetir(int start, int length, Guid kullaniciId)
        {
            var subset = await uyelikBusiness.KullaniciListesiResimGetir(start, length, kullaniciId);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }
        [HttpPost]
        [Route("KullaniciProfilResmiSil")]
        public async Task<IActionResult> KullaniciProfilResmiSil(KullaniciResim kullaniciResim)
        {
            var Result = await uyelikBusiness.KullaniciProfilResmiSil(kullaniciResim);
            return Ok(Result);
        }
        [HttpGet]
        [Route("KullaniciProfilResimGetir")]
        public async Task<IActionResult> KullaniciProfilResimGetir(string kullaniciId)
        {
            var Result = await uyelikBusiness.KullaniciProfilResimGetir(kullaniciId);
            return Ok(Result);
        }
        [HttpGet]
        [Route("KullaniciResimSayisiGetir")]
        public async Task<IActionResult> KullaniciResimSayisiGetir(Guid kullaniciId)
        {
            var KullaniciResim = await uyelikBusiness.KullaniciResimSayisiGetir(kullaniciId);
            return Ok(KullaniciResim);
        }
        [HttpPost]
        [Route("KullaniciBuyukProfilResimKaydetGuncelle")]
        public async Task<IActionResult> KullaniciBuyukProfilResimKaydetGuncelle([FromBody] KullaniciResimVM kullaniciResimtVM)
        {
            var kullaniciKayitResult = await uyelikBusiness.KullaniciBuyukProfilResimKaydetGuncelle(kullaniciResimtVM);
            return Ok(kullaniciKayitResult);
        }
        [HttpGet]
        [Route("KullaniciBuyukProfilResimGetir")]
        public async Task<IActionResult> KullaniciBuyukProfilResimGetir(Guid KullaniciId)
        {
            var kullaniciKayitResult = await uyelikBusiness.KullaniciBuyukProfilResimGetir(KullaniciId);
            return Ok(kullaniciKayitResult);
        }
        #endregion

        #region Duvar Resim
        [HttpGet]
        [Route("DuvarResimleriniGetir")]
        public async Task<IActionResult> DuvarResimleriniGetir()
        {
            var DuvarResimList = await uyelikBusiness.DuvarResimleriniGetir();
            return Ok(DuvarResimList);
        }
        [HttpGet]
        [Route("KullaniciDuvarResimDegistir")]
        public async Task<IActionResult> KullaniciDuvarResimDegistir(Guid kullaniciId, int resimId)
        {
            var DuvarResimList = await uyelikBusiness.KullaniciDuvarResimDegistir(kullaniciId, resimId);
            return Ok(DuvarResimList);
        }
        [HttpGet]
        [Route("KullaniciDuvarResimGetir")]
        public async Task<IActionResult> KullaniciDuvarResimGetir(Guid kullaniciId)
        {
            var DuvarResim = await uyelikBusiness.KullaniciDuvarResimGetir(kullaniciId);
            return Ok(DuvarResim);
        }

        #endregion

        #region KullaniciBildirim
        [HttpPost]
        [Route("KullaniciBildirimListGetir")]
        public async Task<IActionResult> KullaniciBildirimListGetir(KullaniciBildirimListeVM model)
        {
            var subset = await uyelikBusiness.KullaniciBildirimListGetir(model);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciBildirimEkle")]
        public async Task<bool> KullaniciBildirimEkle(KullaniciBildirimVM kullaniciBildirim)
        {
            return await uyelikBusiness.KullaniciBildirimEkle(kullaniciBildirim);
        }

        [HttpPost]
        [Route("KullaniciBildirimSil")]
        public async Task<bool> KullaniciBildirimSil(KullaniciBildirimVM kullaniciBildirim)
        {
            return await uyelikBusiness.KullaniciBildirimSil(kullaniciBildirim);
        }

        [HttpGet]
        [Route("KullaniciHeaderBildirimListGetir")]
        public async Task<IActionResult> KullaniciHeaderBildirimListGetir(Guid kullaniciId)
        {
            var KullaniciBildirimList = await uyelikBusiness.KullaniciHeaderBildirimListGetir(kullaniciId);
            return Ok(KullaniciBildirimList);
        }
        [HttpGet]
        [Route("KullaniciBildirimOkundu")]
        public async Task<bool> KullaniciBildirimOkundu(Guid kullaniciId)
        {            
            return await uyelikBusiness.KullaniciBildirimOkundu(kullaniciId);
        }

        [HttpPost]
        [Route("TopluBildirimGonder")]
        public async Task<int> TopluBildirimGonder(IletisimTopluBildirimVM bildirim)
        {
            return await uyelikBusiness.TopluBildirimGonder(bildirim);
        }
        [HttpPost]
        [Route("TumBildirimleriGetir")]
        public async Task<IActionResult> TumBildirimleriGetir(BildirimAramaVM bildirimAramaVM)
        {
            var bildirimLstResult = await uyelikBusiness.TumBildirimleriGetir(bildirimAramaVM);
            return Ok(bildirimLstResult);
        }
        [HttpGet]
        [Route("BildirimSil")]
        public async Task<IActionResult> BildirimSil(int id)
        {
            var result = await uyelikBusiness.BildirimSil(id);
            return Ok(result);
        }
        [HttpGet]
        [Route("KullaniciTumBildirimleriSil")]
        public async Task<bool> KullaniciTumBildirimleriSil(Guid kullaniciId)
        {
            return await uyelikBusiness.KullaniciTumBildirimleriSil(kullaniciId);
        }
        [HttpPost]
        [Route("BildirimSayisiGetir")]
        public async Task<int> BildirimSayisiGetir(IletisimTopluBildirimVM bildirim)
        {
            return await uyelikBusiness.BildirimSayisiGetir(bildirim);
        }
        [HttpPost]
        [Route("KisiyeOzelBildirimGonder")]
        public async Task<int> KisiyeOzelBildirimGonder(KisiyeOzelBildirimVM bildirim)
        {
            return await uyelikBusiness.KisiyeOzelBildirimGonder(bildirim);
        }
        [HttpGet]
        [Route("BildirimIdBildirimGetir")]
        public async Task<IActionResult> BildirimIdBildirimGetir(int id)
        {
            var bildirimResult = await uyelikBusiness.BildirimIdBildirimGetir(id);
            return Ok(bildirimResult);
        }
        [HttpPost]
        [Route("KisiyeOzelBildirimleriGetir")]
        public async Task<IActionResult> KisiyeOzelBildirimleriGetir(BildirimAramaVM bildirimAramaVM)
        {
            var bildirimLstResult = await uyelikBusiness.KisiyeOzelBildirimleriGetir(bildirimAramaVM);
            return Ok(bildirimLstResult);
        }

        [HttpGet]
        [Route("KullaniciHeaderSepetUrunSayisiGetir")]
        public async Task<IActionResult> KullaniciHeaderSepetUrunSayisiGetir(Guid kullaniciId)
        {
            var bildirimResult = await uyelikBusiness.KullaniciHeaderSepetUrunSayisiGetir(kullaniciId);
            return Ok(bildirimResult);
        }
        #endregion

        #region Sifremi Unuttum
        [HttpPost]
        [Route("KullaniciYeniSifreGonder")]
        public async Task<IActionResult> KullaniciYeniSifreGonder(KullaniciSifreGonderVM model)
        {
            var result = await uyelikBusiness.KullaniciYeniSifreGonder(model);

            return Ok(result);
        }
        #endregion
    }
}
