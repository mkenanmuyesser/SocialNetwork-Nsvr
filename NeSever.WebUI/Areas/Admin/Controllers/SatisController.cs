using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Satis;
using NeSever.WebUI.Services;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SatisController : BaseController
    {
        private readonly IKatalogApiService katalogApiService;
        private readonly ISatisApiService satisApiService;

        public SatisController(IKatalogApiService katalogApiService, ISatisApiService satisApiService)
        {
            this.katalogApiService = katalogApiService;
            this.satisApiService = satisApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Arama")]
        public async Task<IActionResult> AramaGet()
        {
            SiparisAramaVM SiparisAramaVM = new SiparisAramaVM();
            SiparisAramaVM.AdresIlListesi = await satisApiService.SatisAdresIlGetir();
            SiparisAramaVM.MarkaListesi = await katalogApiService.MarkaListesiGetir();
            SiparisAramaVM.OdemeDurumTipListesi = await satisApiService.OdemeDurumTipListesiGetir();
            SiparisAramaVM.SiparisDurumTipListesi = await satisApiService.SiparisDurumTipListesiGetir();
            SiparisAramaVM.SiparisOdemeTipListesi = await satisApiService.SiparisOdemeTipListesiGetir();
            SiparisAramaVM.AktifMi = -1;

            return View(SiparisAramaVM);

        }

        [HttpPost]
        [ActionName("Arama")]
        public async Task<IActionResult> AramaPost(SiparisAramaVM model)
        {
            var result = await satisApiService.SiparisAramaSonuc(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        [HttpPost]
        public async Task<IActionResult> SiparisSil(int id)
        {
            var result = await satisApiService.SiparisSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }

        [HttpGet]
        [ActionName("SiparisDetay")]
        public async Task<IActionResult> SiparisDetay(int Id)
        {
            SiparisAramaDetayVM siparisDetay = new SiparisAramaDetayVM();
            siparisDetay = await satisApiService.SiparisDetay(Id);

            return View(siparisDetay);

        }

        [HttpPost]
        [ActionName("SiparisGuncelle")]
        public async Task<IActionResult> SiparisGuncelle(SiparisAramaDetayVM model)
        {
            var result = await satisApiService.SiparisGuncelle(model);
            return Json(result);
        }

        [HttpPost]
        [ActionName("SiparisHareketKaydet")]
        public async Task<IActionResult> SiparisHareketKaydet(SiparisAramaDetayVM model)
        {
            var result = await satisApiService.SiparisHareketKaydet(model);
            return Json(result);
        }

        [HttpPost]
        [ActionName("SiparisHareketSil")]
        public async Task<IActionResult> SiparisHareketSil(int id)
        {
            var result = await satisApiService.SiparisHareketSil(id);
            return Json(result);
        }

        [HttpPost]
        [ActionName("SiparisDetayDurum")]
        public async Task<IActionResult> SiparisDetayDurum(int id)
        {
            var result = await satisApiService.SiparisDetayDurum(id);
            return Json(result);
        }
    }
}
