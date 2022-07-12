using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models.FrontEnd;
using NeSever.WebUI.Services;
using System.Threading.Tasks;

namespace NeSever.WebUI.Controllers
{
    public class BilgiController : BaseController
    {
        private readonly IProgramApiService programApiService;
        private readonly IUyelikApiService uyelikApiService;

        public BilgiController(ILogger<BaseController> logger, 
                               IProgramApiService programApiService, IUyelikApiService uyelikApiService) : base(logger,uyelikApiService)
        {
            this.uyelikApiService = uyelikApiService;
            this.programApiService = programApiService;
            this.logger = logger;
        }               

        [HttpGet]
        [ActionName("Hakkimizda")]
        public async Task<IActionResult> HakkimizdaGet()
        {
            var sonuc = await programApiService.HakkimizdaBilgiGetir();
            return View(sonuc);
        }

        [HttpGet]
        [ActionName("Iletisim")]
        public async Task<IActionResult> IletisimGet()
        {
            var sonuc = await programApiService.IletisimBilgiGetir();
            return View(sonuc);
        }

        [HttpGet]
        [ActionName("KisiselVerilerinKorunmasi")]
        public async Task<IActionResult> KisiselVerilerinKorunmasiGet()
        {
            var sonuc = await programApiService.BilgiGetir();
            return View(sonuc);
        }

        [HttpGet]
        [ActionName("TeslimIadeSartlari")]
        public async Task<IActionResult> TeslimIadeSartlariGet()
        {
            var sonuc = await programApiService.BilgiGetir();
            return View(sonuc);
        }

        [HttpGet]
        [ActionName("UyelikSozlesmesi")]
        public async Task<IActionResult> UyelikSozlesmesiGet()
        {
            var sonuc = await programApiService.BilgiGetir();
            return View(sonuc);
        }

        [HttpPost]
        [ActionName("IletisimTalepGonder")]
        public async Task<JsonResult> IletisimTalepGonderPost(IletisimTalepVM model)
        {
            var epostaResult = await programApiService.IletisimTalepGonder(model);
            var result = Json(new { eposta = epostaResult });

            //var mesajResult = await _MesajBS.IletisimTalepKaydet(model, 1);
            //var result = Json(new { eposta = epostaResult, mesaj = mesajResult > 0 });

            return result;
        }

        [HttpGet]
        [ActionName("SSS")]
        public async Task<IActionResult> SSSGet()
        {
            var sonuc = await programApiService.SikSorulanSorularGetir();
            return View(sonuc);
        }

        //[HttpGet]
        //[ActionName("SSS")]
        //public async Task<IActionResult> SSSGet()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[ActionName("SiteHaritasi")]
        //public async Task<IActionResult> SiteHaritasiGet()
        //{
        //    return View();
        //}

        #region Partials

        public async Task<PartialViewResult> UyelikSozlesmesiPartial()
        {
            var sonuc = await programApiService.UyelikSozlesmesiGetir();
            return PartialView("~/Views/Bilgi/Partials/UyelikSozlesmesi.cshtml", sonuc);
        }

        #endregion
    }
}