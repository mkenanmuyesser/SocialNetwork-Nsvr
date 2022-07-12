using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.WebUI.Services;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RaporController : BaseController
    {
        private readonly IKatalogApiService katalogApiService;
        private readonly IUrunApiService urunApiService;
        public RaporController(IKatalogApiService katalogApiService,
                               IUrunApiService urunApiService)
        {
            this.katalogApiService = katalogApiService;
            this.urunApiService = urunApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("GoruntulenenUrunRaporu")]
        public async Task<IActionResult> GoruntulenenUrunRaporuGet()
        {
            var model = new GoruntulenenUrunAramaVM()
            {
                Aktiflik = 1
            };

            model.MarkaListesi = await urunApiService.MarkaListGetir(null);

            return View(model);
        }

        [HttpPost]
        [ActionName("GoruntulenenUrunRaporu")]
        public async Task<IActionResult> GoruntulenenUrunRaporuPost(GoruntulenenUrunAramaVM model)
        {
            var rapor = await urunApiService.GoruntulenenUrunRaporuGetir(model);

            return Json(rapor);
        }

        [HttpGet]
        [ActionName("YonlendirilenUrunRaporu")]
        public async Task<IActionResult> YonlendirilenUrunRaporuGet()
        {
            var model = new YonlendirilenUrunAramaVM()
            {
                Aktiflik = 1
            };

            model.MarkaListesi = await urunApiService.MarkaListGetir(null);

            return View(model);
        }

        [HttpPost]
        [ActionName("YonlendirilenUrunRaporu")]
        public async Task<IActionResult> YonlendirilenUrunRaporuPost(YonlendirilenUrunAramaVM model)
        {
            var rapor = await urunApiService.YonlendirilenUrunRaporuGetir(model);

            return Json(rapor);
        }
    }
}
