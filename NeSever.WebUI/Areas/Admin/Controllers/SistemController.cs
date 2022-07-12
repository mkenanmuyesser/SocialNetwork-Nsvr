using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models;
using NeSever.Common.Models.DataAktarim;
using NeSever.Common.Models.Program;
using NeSever.Common.Models.Sistem;
using NeSever.WebUI.Services;
using Newtonsoft.Json;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SistemController : BaseController
    {
        private readonly ISistemApiService sistemApiService;
        private readonly IDataAktarimApiService dataAktarimApiService;
        private readonly IUrunApiService urunApiService;
        private readonly IProgramApiService programApiService;

        public SistemController(ISistemApiService sistemApiService,IDataAktarimApiService dataAktarimApiService, IUrunApiService urunApiService, IProgramApiService programApiService)
        {
            this.sistemApiService = sistemApiService;
            this.dataAktarimApiService = dataAktarimApiService;
            this.urunApiService = urunApiService;
            this.programApiService = programApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Program Ayarları

        [HttpGet]
        public async Task<IActionResult> ProgramAyar()
        {
            AyarlarVM model = new AyarlarVM();
            model = await programApiService.AyarlarBilgileriniGetir();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ProgramAyar(AyarlarVM model)
        {
            int sonuc = await programApiService.AyarlarGuncelle(model);
            if (sonuc > 0)
                return View(model);
            else
                return Ok();
        }

        #endregion

        #region Program Log

        [HttpGet]
        public async Task<IActionResult> ProgramLog()
        {
            LogAramaVM model = new LogAramaVM();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogArama(LogAramaVM model)
        {
            var result = await programApiService.LogArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }
        #endregion

        #region Cache Temizleme

        [HttpGet]
        public async Task<IActionResult> CacheTemizleme()
        {
            CacheTemizleme model = new CacheTemizleme();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CacheTemizleme(CacheTemizleme model)
        {
            ResultModel result = new ResultModel()
            {
                Type = ResultType.Basarisiz
            };
            result = await sistemApiService.CacheTemizleme(model);
            if (result.Type == ResultType.Basarili)
                return View(model);
            else
                return View(result);

        }
        #endregion
    }
}
