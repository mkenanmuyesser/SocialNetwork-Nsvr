using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.WebUI.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullaniciController : BaseController
    {
        private readonly IProgramApiService programApiService;
        private readonly IUyelikApiService uyelikApiService;

        public KullaniciController(IProgramApiService programApiService,
                                   IUyelikApiService uyelikApiService)
        {
            this.programApiService = programApiService;
            this.uyelikApiService = uyelikApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Üye İşlemleri

        [HttpGet]
        [ActionName("UyeArama")]
        public IActionResult UyeAramaGet()
        {
            var model = new KullaniciAramaVM()
            {
                Aktiflik = 1
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("UyeArama")]
        public async Task<IActionResult> UyeAramaPost(KullaniciAramaVM model)
        {
            var result = await programApiService.UyeArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;

            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        [HttpGet]
        [ActionName("DogumKriterliUyeArama")]
        public IActionResult DogumKriterliUyeAramaGet()
        {
            var model = new DogumKriterliKullaniciAramaVM()
            {
                Aktiflik = 1
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("DogumKriterliUyeArama")]
        public async Task<IActionResult> DogumKriterliUyeAramaPost(DogumKriterliKullaniciAramaVM model)
        {
            var result = await programApiService.DogumKriterliUyeArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;

            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        [HttpGet]
        [ActionName("UrunSayisinaGoreUyeArama")]
        public IActionResult UrunSayisinaGoreUyeArama()
        {
            var model = new UrunSayisinaGoreKullaniciArama()
            {
                Aktiflik = 1
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("UrunSayisinaGoreUyeArama")]
        public async Task<IActionResult> UrunSayisinaGoreUyeArama(UrunSayisinaGoreKullaniciArama model)
        {
            var result = await programApiService.UrunSayisinaGoreUyeArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;

            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        #endregion

        #region Profil Şikayet İşlemleri

        [HttpGet]
        [ActionName("ProfilSikayetArama")]
        public IActionResult ProfilSikayetAramaGet()
        {
            var model = new ProfilSikayetAramaVM()
            {
                Aktiflik = 1
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("ProfilSikayetArama")]
        public async Task<IActionResult> ProfilSikayetAramaPost(ProfilSikayetAramaVM model)
        {
            var result = await uyelikApiService.ProfilSikayetArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;

            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        #endregion

        #region Yönetici Kullanıcı İşlemleri

        [HttpGet]
        [ActionName("YoneticiKullaniciKayit")]
        public async Task<IActionResult> YoneticiKullaniciKayitGet(int? id)
        {
            YoneticiKullaniciKayitVM model;
            if (id.HasValue && id.Value > 0)
            {
                model = await programApiService.YoneticiKullaniciKayitVMGetir(id.Value);
            }
            else
            {
                model = new YoneticiKullaniciKayitVM()
                {
                    YoneticiKullaniciId = id ?? 0,
                    AktifMi = true,
                };
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("YoneticiKullaniciKayit")]
        public async Task<JsonResult> YoneticiKullaniciKayitPost(YoneticiKullaniciKayitVM model)
        {
            var kullaniciData = KullaniciDataGetir();
            model.IslemKullaniciId = kullaniciData == null ? 1 : kullaniciData.YoneticiKullaniciId;
            model.IslemTarih = DateTime.Now;

            JsonResult result;

            var kullaniciKontrol = model.YoneticiKullaniciId > 0 ? true : await programApiService.YoneticiKullaniciKontrol(model.Eposta);

            if (kullaniciKontrol)
            {
                var id = await programApiService.YoneticiKullaniciKaydet(model);

                if (id > 0)
                    result = Json(new { id = id, message = "success", operation = model.YoneticiKullaniciId > 0 ? "update" : "insert" });
                else
                    result = Json(new { id = id, message = "error", operation = model.YoneticiKullaniciId > 0 ? "update" : "insert" });
            }
            else
            {
                result = Json(new { id = 0, message = "control", operation = "" });
            }

            return result;
        }

        [HttpGet]
        [ActionName("YoneticiKullaniciArama")]
        public IActionResult YoneticiKullaniciAramaGet()
        {
            var model = new YoneticiKullaniciAramaVM()
            {
                Aktiflik = 1
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("YoneticiKullaniciArama")]
        public async Task<IActionResult> YoneticiKullaniciAramaPost(YoneticiKullaniciAramaVM model)
        {
            var result = await programApiService.YoneticiKullaniciArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;

            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        [HttpGet]
        [ActionName("YoneticiKullaniciSil")]
        public async Task<JsonResult> YoneticiKullaniciSilGet(int id)
        {
            var data = await programApiService.YoneticiKullaniciSil(id);

            JsonResult result = Json(data);

            return result;
        }

        #endregion
    }
}
