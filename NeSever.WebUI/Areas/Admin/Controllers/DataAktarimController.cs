using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.DataAktarim;
using NeSever.WebUI.Services;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DataAktarimController : BaseController
    {
        private readonly IDataAktarimApiService dataAktarimApiService;

        private readonly IUrunApiService urunApiService;

        private readonly ISistemApiService sistemApiService;
        public DataAktarimController(IDataAktarimApiService dataAktarimApiService, IUrunApiService urunApiService, ISistemApiService sistemApiService)
        {
            this.dataAktarimApiService = dataAktarimApiService;
            this.urunApiService = urunApiService;
            this.sistemApiService = sistemApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Web Site İşlemleri

        [HttpGet]
        [ActionName("WebSiteIslem")]
        public async Task<IActionResult> WebSiteIslemGet()
        {
            WebSiteVM model = new WebSiteVM();
            model.AramaFiltreleri.AktifMi = 1;
            model.WebSiteBilgileri = await dataAktarimApiService.WebSiteBilgileriniGetir();
      
            return View(model);
        }


        [HttpPost]
        [ActionName("WebSiteIslem")]
        public IActionResult WebSiteIslemPost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AramaSonuclariniGetir(WebSiteVM model)
        {
            var result = await dataAktarimApiService.WebSiteArama(model);
            int totalCount = result.WebSiteAramaSonucList.Any() ? result.WebSiteAramaSonucList.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result.WebSiteAramaSonucList });

        }

        [HttpPost]
        public async Task<IActionResult> DurumGuncelle(int id)
        {
            var result = await dataAktarimApiService.DurumGuncelle(id);

            return Json(new { message = "Güncelleme işlemi başarılı" });

        }

        #endregion

        #region Ürün Link İşlemleri

        [HttpGet]
        [ActionName("UrunLinkIslem")] 
        public async Task<IActionResult> UrunLinkIslemGet()
        {
            UrunLinkIslemVM model = new UrunLinkIslemVM();
            var lst = await dataAktarimApiService.WebSiteListesiniGetir();
            WebSiteAramaSonucVM hepsi = new WebSiteAramaSonucVM()
            {
                WebSiteAdi = "Hepsi",
                WebSiteId = -1
            };
            lst.Add(hepsi);
            model.AramaFiltreleri.WebSiteListesi =lst.OrderBy(c=>c.WebSiteId).ToList();
            model.UrunLinkIslemBilgileri = await dataAktarimApiService.UrunLinkBilgileriniGetir();
            model.AramaFiltreleri.AktifMi = 1;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UrunLinkAramaSonuclariniGetir(UrunLinkIslemVM model)
        {
            var result = await dataAktarimApiService.UrunLinkArama(model);
            int totalCount = result.UrunLinkIslemAramaSonucList.Any() ? result.UrunLinkIslemAramaSonucList.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result.UrunLinkIslemAramaSonucList });

        }

        [HttpPost]
        public async Task<IActionResult> UrunLinkDurumGuncelle(int id)
        {
            var result = await dataAktarimApiService.UrunLinkDurumGuncelle(id);

            return Json(new { message = "Güncelleme işlemi başarılı" });

        }

        [HttpPost]
        [ActionName("UrunLinkIslem")]
        public IActionResult UrunLinkIslemPost()
        {
            return View();
        }

        #endregion

        #region Kategori İşlemleri

        [HttpGet]
        public async Task<IActionResult> KategoriIslem()
        {
            DataKategoriAramaVM model = new DataKategoriAramaVM();
            model.WebSiteListesi = await dataAktarimApiService.WebSiteListesiniGetir();
            model.KategoriListesi = await urunApiService.KategoriListesiniGetir();
            model.IsActive = 1;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> KategoriIslem(DataKategoriAramaVM model)
        {
            var result = await sistemApiService.DataKategoriListesiniGetir(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        #endregion

        #region Hata Logları

        [HttpGet]
        [ActionName("HataLog")]
        public async Task<IActionResult> HataLogGet()
        {
            HataLogVM model = new HataLogVM();
            var lst = await dataAktarimApiService.WebSiteListesiniGetir();
            WebSiteAramaSonucVM hepsi = new WebSiteAramaSonucVM()
            {
                WebSiteAdi = "Hepsi",
                WebSiteId = -1
            };
            lst.Add(hepsi);
            model.WebSiteListesi = lst.OrderBy(c => c.WebSiteId).ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> HataLogAramaSonuclariniGetir(HataLogVM model)
        {
            var result = await dataAktarimApiService.HataLogArama(model);
            int totalCount = result.HataLogSonucListesi.Any() ? result.HataLogSonucListesi.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result.HataLogSonucListesi });

        }

        [HttpPost]
        [ActionName("HataLog")]
        public IActionResult HataLogPost()
        {
            return View();
        }

        #endregion
    }
}
