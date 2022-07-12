using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Uyelik;
using NeSever.WebUI.Services;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IletisimController : BaseController
    {
        private readonly IUyelikApiService uyelikApiService;

        public IletisimController(IUyelikApiService uyelikApiService)
        {
            this.uyelikApiService = uyelikApiService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [ActionName("BildirimGonder")]
        public async Task<IActionResult> BildirimGonderGet(int? Id)
        {
            IletisimTopluBildirimVM model = new IletisimTopluBildirimVM();

            return View(model);
        }

        [HttpPost]
        [ActionName("BildirimGonder")]
        public async Task<JsonResult> BildirimGonderPost(IletisimTopluBildirimVM data)
        {
            JsonResult result;

            data.BildirimIcerik = data.AciklamaContent.Substring(3, data.AciklamaContent.Length - 3).Substring(0, data.AciklamaContent.Length - 7);
            
            var id = await uyelikApiService.TopluBildirimGonder(data);
            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.BildirimId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.BildirimId > 0 ? "update" : "insert" });
            return result;

        }

        [HttpGet]
        public IActionResult BildirimArama()
        {
            BildirimAramaVM BildirimAramaVM = new BildirimAramaVM();
            BildirimAramaVM.AktifMi = -1;
            return View(BildirimAramaVM);

        }
        [HttpPost]
        public async Task<IActionResult> BildirimArama(BildirimAramaVM model)
        {
            var result = await uyelikApiService.TumBildirimleriGetir(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        [HttpPost]
        public async Task<IActionResult> BildirimSil(int id)
        {
            var result = await uyelikApiService.BildirimSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }

        [HttpPost]
        [ActionName("BildirimSayisiGetir")]
        public async Task<int> BildirimSayisiGetir(IletisimTopluBildirimVM data)
        {
            var bildirimSayisi = await uyelikApiService.BildirimSayisiGetir(data);

            return bildirimSayisi;
        }

        [HttpGet]
        [ActionName("KisiyeOzelBildirimGonder")]
        public async Task<IActionResult> KisiyeOzelBildirimGonderGet(int? Id)
        {
            KisiyeOzelBildirimVM model = new KisiyeOzelBildirimVM();

            if(Id.HasValue)
            {
                var bildirim = await uyelikApiService.BildirimIdBildirimGetir(Id.Value);
                if(bildirim != null)
                {
                    model.BildirimId = Id.Value;
                    model.BildirimIcerik = bildirim.BildirimIcerik;
                    model.KullaniciId = bildirim.KullaniciId;
                    var kullanici = await uyelikApiService.KullaniciGetirByKullaniciId(bildirim.KullaniciId);
                    model.KulaniciAdi = kullanici.KullaniciAdi;
                }
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("KisiyeOzelBildirimGonder")]
        public async Task<JsonResult> KisiyeOzelBildirimGonderPost(KisiyeOzelBildirimVM data)
        {
            JsonResult result;

            data.BildirimIcerik = data.AciklamaContent.Substring(3, data.AciklamaContent.Length - 3).Substring(0, data.AciklamaContent.Length - 7);

            var id = await uyelikApiService.KisiyeOzelBildirimGonder(data);
            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.BildirimId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.BildirimId > 0 ? "update" : "insert" });
            return result;

        }

        [HttpPost]
        [ActionName("BildirimKullaniciListGetir")]
        public async Task<IActionResult> BildirimKullaniciListGetir(string kelime)
        {

            KisiyeOzelBildirimVM data = new KisiyeOzelBildirimVM();
            if (kelime != null && kelime.Length >= 3)
            {

                data.KulaniciAdi = kelime;

                var kullanicilar = await uyelikApiService.BildirimKullaniciListGetir(data);

                return Json(kullanicilar);
            }

            return Json(null);
        }

        [HttpGet]
        public IActionResult KisiyeOzelBildirimArama()
        {
            BildirimAramaVM BildirimAramaVM = new BildirimAramaVM();
            BildirimAramaVM.AktifMi = -1;
            return View(BildirimAramaVM);

        }
        [HttpPost]
        public async Task<IActionResult> KisiyeOzelBildirimArama(BildirimAramaVM model)
        {
            var result = await uyelikApiService.KisiyeOzelBildirimleriGetir(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }
    }
}
