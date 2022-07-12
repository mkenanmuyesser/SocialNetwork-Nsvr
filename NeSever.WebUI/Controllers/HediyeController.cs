using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Urun;
using NeSever.Common.Models.Uyelik;
using NeSever.WebUI.Services;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Controllers
{
    public class HediyeController : BaseController
    {
        private readonly IUrunApiService urunApiService;
        private readonly IUyelikApiService uyelikApiService;
        private readonly ISayfaApiService sayfaApiService;

        public HediyeController(ILogger<BaseController> logger,
                                IUrunApiService urunApiService,
                                IUyelikApiService uyelikApiService,
                                ISayfaApiService sayfaApiService) : base(logger, uyelikApiService)
        {
            this.urunApiService = urunApiService;
            this.uyelikApiService = uyelikApiService;
            this.sayfaApiService = sayfaApiService;
            this.logger = logger;
        }

        [ActionName("HediyeBulunamadi")]
        public IActionResult HediyeBulunamadiGet()
        {
            return View("~/Views/Shared/HediyeBulunamadi.cshtml");
        }

        [ActionName("Ara")]
        public async Task<IActionResult> AraGet(HediyeAramaSayfaVM hediyeAramaSayfaVM)
        {
            if (!Request.QueryString.HasValue)
                return Redirect("/");

            var urunIcerikAramaVM = new UrunIcerikAramaVM()
            {
                Siralama = hediyeAramaSayfaVM.s,
                AramaKelime = hediyeAramaSayfaVM.q,
                AramaMarka = hediyeAramaSayfaVM.m,
                AramaKategori = hediyeAramaSayfaVM.k,
                AramaKategoriBanner = hediyeAramaSayfaVM.kb,
                AramaSite = hediyeAramaSayfaVM.w,                

                start = hediyeAramaSayfaVM.p.HasValue && hediyeAramaSayfaVM.p.Value > 0 ? hediyeAramaSayfaVM.p.Value : 1,
                length = 40
            };

            KategoriBannerIcerikAramaVM kategoriBannerIcerikAramaVM = new KategoriBannerIcerikAramaVM()
            {
                Anasayfa = false,
                UstKategoriBannerId = hediyeAramaSayfaVM.kb,
                UstKategoriId = hediyeAramaSayfaVM.sk
            };
            var kategoriBannerIcerikList = await sayfaApiService.KategoriBannerIcerikListGetir(kategoriBannerIcerikAramaVM);
            var kategoriIcerikList = await urunApiService.KategoriIcerikListGetir(false);
            var hediyeIcerikList = await urunApiService.UrunIcerikListGetir(urunIcerikAramaVM);

            HediyeAramaSayfaSonucVM model = new HediyeAramaSayfaSonucVM()
            {
                HediyeArama = hediyeAramaSayfaVM.q,
                HediyeSiralama = hediyeAramaSayfaVM.s,
                HediyeKategori = hediyeAramaSayfaVM.k,
                HediyeKategoriBanner = hediyeAramaSayfaVM.kb,
                HediyeMarka = hediyeAramaSayfaVM.m,
                HediyeSite = hediyeAramaSayfaVM.w,
                SayfaKategori = hediyeAramaSayfaVM.sk,

                KategoriBannerIcerikList = kategoriBannerIcerikList,
                KategoriIcerikList = kategoriIcerikList,
                HediyeIcerikList = hediyeIcerikList,
            };

            return View(model);
        }

        public async Task<IActionResult> Detay(int id)
        {
            if (id <= 0)
                return RedirectToAction("HediyeBulunamadi", "Hediye");

            var urunDetayIcerik = await urunApiService.UrunDetayIcerikGetir(id);

            if (urunDetayIcerik.UrunId <= 0)
                return RedirectToAction("HediyeBulunamadi", "Hediye");

            HediyeDetaySayfaVM model = new HediyeDetaySayfaVM()
            {
                UrunDetayIcerik = urunDetayIcerik,
            };
            return View(model);
        }

        [HttpGet]
        [ActionName("KullaniciHediyeEkle")]
        public async Task<JsonResult> KullaniciHediyeEkleGet(int id)
        {
            //var session = HttpContext.Session.GetString("Kullanici");
            //var token = JsonConvert.DeserializeObject<TokenVM>(session);
            //var kullanici = await uyelikApiService.KullaniciGetir(token)

            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                return Json(new { error = true, message = "", operation = "show" });
            }
            else
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token == null)
                {
                    return Json(new { error = true, message = "", operation = "show" });
                }
                else
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici == null)
                    {
                        return Json(new { error = true, message = "", operation = "show" });
                    }
                    else
                    {
                        KullaniciUrunEkleSilVM model = new KullaniciUrunEkleSilVM()
                        {
                            KullaniciId = kullanici.KullaniciId,
                            UrunId = id
                        };

                        var result = await uyelikApiService.KullaniciHediyeEkle(model);

                        if (result.Sonuc)
                            return Json(new { error = false, message = "", operation = "success" });
                        else
                            return Json(new { error = true, message = result.Mesaj, operation = "message" });
                    }
                }
            }
        }

        [HttpGet]
        [ActionName("KullaniciHediyeSil")]
        public async Task<JsonResult> KullaniciHediyeSilGet(int id)
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                var kullanici = await uyelikApiService.KullaniciGetir(token);

                if (kullanici == null)
                {
                    return Json(new { error = true, message = "İşlem yapılamıyor", operation = "message" });
                }
                else
                {
                    KullaniciUrunEkleSilVM model = new KullaniciUrunEkleSilVM()
                    {
                        KullaniciId = kullanici.KullaniciId,
                        UrunId = id
                    };

                    var result = await uyelikApiService.KullaniciHediyeSil(model);

                    if (result.Sonuc)
                        return Json(new { error = false, message = "", operation = "success" });
                    else
                        return Json(new { error = true, message = result.Mesaj, operation = "message" });
                }
            }
            else
            {
                return Json(new { error = true, message = "İşlem yapılamıyor", operation = "message" });
            }
        }

        [HttpPost]
        [ActionName("YonlendirmeSayisiArttir")]
        public async Task<JsonResult> YonlendirmeSayisiArttir(int id)
        {
            var result = Json(new { result = false, content = "", title = "", text = "" });

            await urunApiService.YonlendirmeSayisiArttir(id);

            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                var kullanici = await uyelikApiService.KullaniciGetir(token);
                if (kullanici != null)
                {
                    await urunApiService.KullaniciFiyatGorListArttir(kullanici.KullaniciId, id);

                    //hediye ürün ise kontrolleri yap
                    SurprizHediyeVM model = new SurprizHediyeVM()
                    {
                        KullaniciId = kullanici.KullaniciId,
                        UrunId = id
                    };
                    var data = await urunApiService.SurprizHediyeKontrol(model);

                    if (data.Sonuc)
                        result = Json(new { result = true, content = "/Uploads/Site/surprise.gif", title = "Tebrikler!", text = "Lütfen info@nesever.com.tr adresine mail atarak bizimle iletişime geçiniz." });
                    else
                        result = Json(new { result = false, content = "", title = "", text = "" });
                }
            }

            return result;
        }

        public async Task<IActionResult> HediyeAramadaTopListGetir(string kelime)
        {
            if (!Request.QueryString.HasValue)
                return Redirect("/");

            var urunIcerikAramaVM = new UrunIcerikAramaVM()
            {
                AramaKelime = kelime,
                start = 0,
                length = 3
            };

            var hediyeIcerikList = await urunApiService.UrunIcerikListGetir(urunIcerikAramaVM);
            var model = hediyeIcerikList.ToList();
            return Json(model);
        }

        #region Partials

        #endregion
    }
}