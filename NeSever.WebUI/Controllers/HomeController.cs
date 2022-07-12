using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Uyelik;
using NeSever.Data.Entities;
using NeSever.WebUI.Services;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace NeSever.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISayfaApiService sayfaApiService;
        private readonly IUyelikApiService uyelikApiService;
        private readonly IUrunApiService urunApiService;

        public HomeController(ILogger<BaseController> logger,
                              ISayfaApiService sayfaApiService,
                              IUyelikApiService uyelikApiService,
                              IUrunApiService urunApiService) : base(logger, uyelikApiService)
        {
            this.sayfaApiService = sayfaApiService;
            this.uyelikApiService = uyelikApiService;
            this.urunApiService = urunApiService;
            this.logger = logger;
        }

        [ActionName("Index")]
        public async Task<IActionResult> IndexGet()
        {
            KategoriBannerIcerikAramaVM kategoriBannerIcerikAramaVM = new KategoriBannerIcerikAramaVM() { Anasayfa = true };
            var kategoriBannerIcerikList = await sayfaApiService.KategoriBannerIcerikListGetir(kategoriBannerIcerikAramaVM);
            var kategoriIcerikList = await urunApiService.KategoriIcerikListGetir();
            var bannerIcerikList = await sayfaApiService.BannerIcerikListGetir();
            var blogKategoriIcerikList = await sayfaApiService.BlogKategoriIcerikListGetir();
            var hediyeKartIcerikList = await sayfaApiService.HediyeKartIcerikListGetir();
            var trendKadinUrunIcerikListGetir = await urunApiService.TrendKadinUrunIcerikListGetir();
            var trendErkekUrunIcerikListGetir = await urunApiService.TrendErkekUrunIcerikListGetir();
            var markaIcerikList = await urunApiService.MarkaIcerikListGetir();

            AnasayfaVM model = new AnasayfaVM()
            {
                KategoriIcerikList = kategoriIcerikList,
                BannerIcerikList = bannerIcerikList,
                KategoriBannerIcerikList = kategoriBannerIcerikList,
                BlogKategoriIcerikList = blogKategoriIcerikList,
                HediyeKartIcerikList = hediyeKartIcerikList,
                TrendKadinUrunIcerikList = trendKadinUrunIcerikListGetir,
                TrendErkekUrunIcerikList = trendErkekUrunIcerikListGetir,
                MarkaIcerikList = markaIcerikList
            };
            return View(model);
        }

        [ActionName("Hata")]
        public IActionResult HataGet()
        {
            return View("~/Views/Shared/Hata.cshtml");
        }

        [ActionName("SayfaBulunamadi")]
        public IActionResult SayfaBulunamadiGet()
        {
            return View("~/Views/Shared/SayfaBulunamadi.cshtml");
        }

        #region Partials

        public async Task<PartialViewResult> HediyeKartGonderPartial(int id)
        {
            //var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            //var kullaniciKisiselBilgi = await uyelikApiService.KullaniciKisiselBilgileriGetir(token);
            var hediyeKartBilgi = await sayfaApiService.HediyeKartIcerikGetir(id);
            HediyeKartIcerikGonderVM model = new HediyeKartIcerikGonderVM()
            {
                HediyeKartId = hediyeKartBilgi.HediyeKartId,
                HediyeKartAdi = hediyeKartBilgi.HediyeKartAdi,
                Aciklama = hediyeKartBilgi.Aciklama,
                ResimBase64 = hediyeKartBilgi.ResimBase64,
                GonderilmeSayisi = hediyeKartBilgi.GonderilmeSayisi,
            };

            return PartialView("~/Views/Home/Partials/HediyeKartGonder.cshtml", model);
        }
        public async Task<PartialViewResult> HediyeKartMesajIcerikPartial(int id, string gonderenKullaniciId)
        {
            var hediyeKartBilgi = await uyelikApiService.HediyeKartIcerikGetir(id);
            HediyeKartIcerikGonderVM model = new HediyeKartIcerikGonderVM()
            {
                HediyeKartId = hediyeKartBilgi.HediyeKartId,
                HediyeKartAdi = hediyeKartBilgi.HediyeKartAdi,
                Aciklama = hediyeKartBilgi.Aciklama,
                ResimBase64 = hediyeKartBilgi.ResimBase64,
                GonderilmeSayisi = hediyeKartBilgi.GonderilmeSayisi,
            };

            var resim = await uyelikApiService.KullaniciResimGetir(new Guid(gonderenKullaniciId));

            if (resim != null)
                model.KullaniciProfilResimBase64 = string.Format("{0}{1}", "data:" + resim.ResimUzanti + ";base64,", resim.ResimBase64);

            return PartialView("~/Views/Kullanici/Partials/HediyeKartMesajIcerik.cshtml", model);
        }

        #endregion
    }
}
