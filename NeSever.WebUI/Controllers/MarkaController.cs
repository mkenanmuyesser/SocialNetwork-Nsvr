using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeSever.WebUI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Controllers
{
    public class MarkaController : BaseController
    {
        private readonly IUyelikApiService uyelikApiService;
        private readonly IUrunApiService urunApiService;

        public MarkaController(ILogger<BaseController> logger,
                               IUyelikApiService uyelikApiService,
                               IUrunApiService urunApiService) : base(logger, uyelikApiService)
        {
            this.uyelikApiService = uyelikApiService;
            this.urunApiService = urunApiService;
            this.logger = logger;
        }

        [ActionName("Ara")]
        public async Task<IActionResult> AraGet()
        {
            var model = await urunApiService.MarkaListGetir(null);
            model.HarfListesi = new List<string>(new string[] { "0","1","2","3","4","5","6","7","8","9","A", "B", "C", "Ç", "D", "E", "F", "G", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "Ş", "T", "U", "Ü", "V", "W", "X", "Y", "Z" });

            return View(model);
        }

        [ActionName("MarkaAdindanIdGetir")]
        public async Task<string> MarkaAdindanIdGetir(string markaAdi)
        {
            var markaId = await urunApiService.MarkaAdindanIdGetir(markaAdi);
            return markaId;
        }

        [ActionName("MarkaAramaIcerik")]
        public async Task<PartialViewResult> MarkaAramaIcerik(string m)
        {
            var model = await urunApiService.MarkaListGetir(m);
            model.HarfListesi = new List<string>(new string[] {});

            if (model.MarkaListesi.Any())
            {
                model.HarfListesi.Add(model.MarkaListesi[0].MarkaAdi.Substring(0, 1));
                if (m == null)
                {
                    model.HarfListesi = new List<string>(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "Ç", "D", "E", "F", "G", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "Ş", "T", "U", "Ü", "V", "W", "X", "Y", "Z" });
                }
            }
           
            return PartialView("~/Views/Marka/Partials/MarkaAramaIcerik.cshtml", model);
        }
    }
}
