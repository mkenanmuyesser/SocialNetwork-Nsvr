using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.WebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Controllers
{
    public class HediyeKartController : BaseController
    {
        private readonly ISayfaApiService sayfaApiService;
        private readonly IUyelikApiService uyelikApiService;
        public HediyeKartController(ILogger<BaseController> logger,
                                    IUyelikApiService uyelikApiService,
                                    ISayfaApiService sayfaApiService) : base(logger, uyelikApiService)
        {
            this.uyelikApiService = uyelikApiService;
            this.sayfaApiService = sayfaApiService;
            this.logger = logger;
        }

        [ActionName("Ara")]
        public async Task<IActionResult> AraGet(HediyeKartAramaSayfaVM hediyeKartAramaSayfaVM)
        {

            var hediyeKartIcerikAramaVM = new HediyeKartIcerikAramaVM()
            {
                AramaKelime = hediyeKartAramaSayfaVM.q,
                AramaKategori = 0,

                start = hediyeKartAramaSayfaVM.p.HasValue && hediyeKartAramaSayfaVM.p.Value > 0 ? hediyeKartAramaSayfaVM.p.Value : 1,
                length = 32
            };

            if (hediyeKartAramaSayfaVM.sk != 0)
            {
                hediyeKartIcerikAramaVM.AramaKategori = hediyeKartAramaSayfaVM.sk;
            }

            var kategoriIcerikList = await sayfaApiService.HediyeKartKategoriTipleriniGetir();
            var hediyeIcerikList = await sayfaApiService.HediyeKartAramaIcerikListGetir(hediyeKartIcerikAramaVM);

            HediyeKartAramaSayfaSonucVM model = new HediyeKartAramaSayfaSonucVM()
            {
                HediyeKartArama = hediyeKartAramaSayfaVM.q,
                HediyeKartKategori = hediyeKartAramaSayfaVM.k,
                SayfaKategori = hediyeKartAramaSayfaVM.sk,

                HediyeKartIcerikList = hediyeIcerikList,
                HediyeKartKategoriIcerikList = kategoriIcerikList,
            };

            return View(model);
        }
    }
}
