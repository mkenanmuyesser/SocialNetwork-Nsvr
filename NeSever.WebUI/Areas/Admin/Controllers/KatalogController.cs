using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.DataAktarim;
using NeSever.Common.Models.Katalog;
using NeSever.Common.Models.Sistem;
using NeSever.Common.Models.Urun;
using NeSever.WebUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KatalogController : BaseController
    {
        private readonly IKatalogApiService katalogApiService;
        private readonly IDataAktarimApiService dataAktarimApiService;
        private readonly IUrunApiService urunApiService;
        private readonly ISistemApiService sistemApiService;

        public KatalogController(IKatalogApiService katalogApiService,IDataAktarimApiService dataAktarimApiService,IUrunApiService urunApiService,ISistemApiService sistemApiService)
        {
            this.katalogApiService = katalogApiService;
            this.dataAktarimApiService = dataAktarimApiService;
            this.urunApiService = urunApiService;
            this.sistemApiService = sistemApiService;

        }

        public IActionResult Index()
        {
            return View();
        }

  
        [HttpGet]
        public async Task<IActionResult> MarkaArama()
        {
            MarkaAramaVM model = new MarkaAramaVM();
            model.AktifMi = 1;
            model.WebSiteListesi = await dataAktarimApiService.WebSiteListesiniGetir();
            return View(model);
        }

        [HttpPost]
        [ActionName("MarkaArama")]
        public async Task<IActionResult> MarkaAramaPost(MarkaAramaVM model)
        {
            var result = await katalogApiService.MarkaArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        [HttpGet]
        public async Task<IActionResult> MarkaGuncelle(int id)
        {
            MarkaVM model = new MarkaVM();
            if (id > 0)
            {
                model = await katalogApiService.MarkaGetirById(id);
            }

            model.WebSiteListesi = await dataAktarimApiService.WebSiteListesiniGetir();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MarkaGuncelle(MarkaVM data, IFormFile file)
        {
            if (file != null)
            {
                if (file != null)
                //Resmi binary olarak al
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    data.Resim = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    data.ResimUrl = file.FileName;

                }
            }
            data.MarkaId = await katalogApiService.MarkaGuncelle(data);
            return Ok(data);
        }


        [HttpGet]
        [ActionName("KategoriKayit")]
        public async Task<IActionResult> KategoriKayit(int? Id)
        {
            KategoriVM model = new KategoriVM();

            if (Id.HasValue)
            {
                model = await urunApiService.KategoriGetirById(Id.Value);
                if (!string.IsNullOrEmpty(model.ResimUrl))
                {
                    model.ResimBase64 = Convert.ToBase64String(model.Resim);
                }
            }
            model.UstKategoriListesi = await urunApiService.KategoriListesiniGetir();
            return View(model);
        }

        [HttpPost]
        [ActionName("KategoriKayit")]
        public async Task<JsonResult> KategoriKayit(KategoriVM data, IFormFile file)
        {
            JsonResult result;
            data.Aciklama = data.AciklamaContent;
            data.Parametre = data.Parametre.Trim();
            if (file != null)
            {
                if (file != null)
                //Resmi binary olarak al
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    data.Resim = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    data.ResimUrl = file.FileName;



                }
            }
            var id = await urunApiService.KategoriKaydet(data);
            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.KategoriId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.KategoriId > 0 ? "update" : "insert" });
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> KategoriArama()
        {
            KategoriAramaVM KategoriAramaVM = new KategoriAramaVM();
            KategoriAramaVM.AktifMi = -1;
            KategoriAramaVM.SabitKategoriMi = -1;
            return View(KategoriAramaVM);

        }

        [HttpPost]
        public async Task<IActionResult> KategoriArama(KategoriAramaVM model)
        {
            var result = await urunApiService.KategoriArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }

        [HttpPost]
        public async Task<IActionResult> KategoriSil(int id)
        {
            var result = await urunApiService.KategoriSil(id);

            return Json(new { message = "Silme işlemi başarılı" });

        }

        [HttpGet]
        [ActionName("UrunKayit")]
        public async Task<IActionResult> UrunKayit(int? Id)
        {
            UrunVM model = new UrunVM();
            model.UrunResimListesi = new List<UrunResimVM>();
            model.UrunKategoriListesi = new List<UrunKategoriVM>();
            model.KategoriListesi = new List<KategoriVM>();
            HttpContext.Session.Remove("UrunResimListesi");
            if (Id.HasValue)
            {
                model = await urunApiService.UrunGetirById(Id.Value);
                model.UrunResimListesi = await urunApiService.UrunResimGetirById(Id.Value);
                model.UrunKategoriListesi = await urunApiService.UrunKategoriGetirById(Id.Value);



                string secilenKategoriler = string.Empty;
                foreach (var item in model.UrunKategoriListesi)
                {
                    secilenKategoriler += item.KategoriId.ToString()+ ',';
                }
                if(!string.IsNullOrEmpty(secilenKategoriler))
                model.SecilenKategoriListesi = secilenKategoriler.Remove(secilenKategoriler.Length - 1);
                HttpContext.Session.SetString("UrunResimListesi", JsonConvert.SerializeObject(model.UrunResimListesi));
            }
            model.MarkaListesi = await katalogApiService.MarkaListesiGetir();
            model.WebSiteListesi = await dataAktarimApiService.WebSiteListesiniGetir();
            model.KategoriListesi = await urunApiService.KategoriListesiniGetir();
            return View(model);
        }

        [HttpPost]
        [ActionName("UrunKayit")]
        public async Task<JsonResult> UrunKayit(UrunVM data, IEnumerable<IFormFile> file)
        {
            JsonResult result;
            UrunResimVM urunResim = new UrunResimVM();
            data.UrunResimListesi = new List<UrunResimVM>();
            foreach (var item in file)
            {
                MemoryStream ms = new MemoryStream();
                item.CopyTo(ms);
                byte[] resimByte = ms.ToArray();
                ms.Close();
                ms.Dispose();
                UrunResimVM resim = new UrunResimVM();
                resim.Resim = resimByte;
                resim.ResimUrl = item.FileName;
                resim.AktifMi = true;
                data.UrunResimListesi.Add(resim);
            }

            if(data.UrunResimListesi.Count() == 0)
            {
                data.UrunResimListesi = JsonConvert.DeserializeObject<List<UrunResimVM>>(HttpContext.Session.GetString("UrunResimListesi"));
            }
            

            if (data.AciklamaContent == null || data.AciklamaContent == "")
            {
                data.Aciklama = data.AciklamaContent;
            }
            else
            {
                data.AciklamaContent = data.AciklamaContent.Replace("<p>&nbsp;</p>", " ");
                data.Aciklama = data.AciklamaContent.Trim();
            }
            
            if(data.KisaAciklamaContent == null || data.KisaAciklamaContent == "")
            {
                data.KisaAciklama = data.KisaAciklamaContent;
            }
            else
            {
                data.KisaAciklamaContent = data.KisaAciklamaContent.Replace("<p>&nbsp;</p>", " ");
                data.KisaAciklama = data.KisaAciklamaContent.Trim();
            }
            
            data.KayitTarih = DateTime.Now;
            data.GuncellemeTarih = DateTime.Now;
            data.GoruntulenmeSayisi = 0;
            data.UrunKategoriListesi = new List<UrunKategoriVM>();
            if(data.SecilenKategoriler != null)
            {
                string[] secilenKategoriId = data.SecilenKategoriler.Split(',');
                foreach (var item in secilenKategoriId)
                {
                    UrunKategoriVM kategoriVM = new UrunKategoriVM();
                    kategoriVM.KategoriId = Convert.ToInt32(item);
                    kategoriVM.AktifMi = true;
                    data.UrunKategoriListesi.Add(kategoriVM);
                }
            }
            var id  = await urunApiService.UrunKaydet(data);
            /*if(id > 0)
            {
                urunResim.UrunId = id;
                urunResim.KayitTarih = DateTime.Now;
                var resimId = await urunApiService.UrunResimKaydet(urunResim);
            }*/

            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.UrunId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.UrunId > 0 ? "update" : "insert" });
            return result;
        }



        [HttpGet]
        public async Task<IActionResult> UrunAra()
        {
            UrunAramaVM UrunAramaVM = new UrunAramaVM();
            UrunAramaVM.KategoriListesi = new List<KategoriVM>();
            UrunAramaVM.KategoriListesi = await urunApiService.KategoriListesiniGetir();
            UrunAramaVM.AktifMi = -1;
            UrunAramaVM.SatilabilirUrunMu = -1;
            return View(UrunAramaVM);

        }
        [HttpPost]
        public async Task<IActionResult> UrunAra(UrunAramaVM model)
        {
            var result = await urunApiService.UrunArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }

        [HttpPost]
        public async Task<IActionResult> UrunSil(int id)
        {
            var result = await urunApiService.UrunSil(id);

            return Json(new { message = "Silme işlemi başarılı" });

        }

        [HttpGet]
        public JsonResult UrunResimSil(string Id)
        {
            List<UrunResimVM> resimLst = new List<UrunResimVM>();
            if (HttpContext.Session.GetString("UrunResimListesi") != null)
                resimLst = JsonConvert.DeserializeObject<List<UrunResimVM>>(HttpContext.Session.GetString("UrunResimListesi"));
            var silinecekResim = resimLst.Where(p => p.UrunResimId == Convert.ToInt32(Id)).Single();
            if (silinecekResim != null)
            {
                resimLst.Remove(silinecekResim);
                foreach (var item in resimLst)
                {
                    item.ResimBase64 = Convert.ToBase64String(item.Resim);
                }
                HttpContext.Session.SetString("UrunResimListesi", JsonConvert.SerializeObject(resimLst));
            }
            return Json(resimLst);
        }

        public async Task<IActionResult> KategoriListe()
        {
            List<TreeViewNodeModel> nodes = new List<TreeViewNodeModel>();

            nodes = await sistemApiService.KategoriListesiniGetir();

            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View();
        }

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

        [HttpGet]
        public async Task<IActionResult> TargetCategoryGuncelle(int Id, int targetCategoryId)
        {
            int sonuc = await sistemApiService.GuncelleDataKategoriTargetCategory(Id, targetCategoryId);
            return Json(new { result = "Guncelleme basarılı" });
        }

        [HttpGet]
        public async Task<IActionResult> TargetCategorySil(int Id)
        {
            int sonuc = await sistemApiService.DataKategoriTargetCategorySil(Id);
            return Json(new { result = "Silme işlemi basarılı" });
        }

        [HttpGet]
        public async Task<IActionResult> DurumGuncelle(int Id, bool durum)
        {
            int sonuc = await sistemApiService.GuncelleDataKategoriIsActive(Id, durum);
            return Json(new { result = "Guncelleme basarılı" });
        }

        [HttpGet]
        [ActionName("KategoriBannerKayit")]
        public async Task<IActionResult> KategoriBannerKayit(int? Id)
        {
            KategoriBannerVM model = new KategoriBannerVM();

            if (Id.HasValue)
            {
                model = await urunApiService.KategoriBannerGetirById(Id.Value);
                if (!string.IsNullOrEmpty(model.ResimUrl))
                {
                    model.ResimBase64 = Convert.ToBase64String(model.Resim);
                }
            }
            model.UstKategoriListesi = await urunApiService.KategoriListesiniGetir();
            model.UstKategoriBannerListesi = await urunApiService.KategoriBannerListesiniGetir();
            return View(model);
        }

        [HttpPost]
        [ActionName("KategoriBannerKayit")]
        public async Task<JsonResult> KategoriBannerKayit(KategoriBannerVM data, IFormFile file)
        {
            JsonResult result;
            if (file != null)
            {
                if (file != null)
                //Resmi binary olarak al
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    data.Resim = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    data.ResimUrl = file.FileName;
                }
            }
            var id = await urunApiService.KategoriBannerKaydet(data);
            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.KategoriBannerId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.KategoriBannerId > 0 ? "update" : "insert" });
            return result;
        }

        [HttpGet]
        [ActionName("KategoriBannerArama")]
        public async Task<IActionResult> KategoriBannerArama()
        {
            KategoriBannerAramaVM KategoriBannerAramaVM = new KategoriBannerAramaVM();
            KategoriBannerAramaVM.AktifMi = -1;
            return View(KategoriBannerAramaVM);

        }

        [HttpPost]
        [ActionName("KategoriBannerArama")]
        public async Task<IActionResult> KategoriBannerArama(KategoriBannerAramaVM model)
        {
            var result = await urunApiService.KategoriBannerArama(model);
            foreach(var item in result)
            {
                if(item.ResimBase64 != null)                
                    item.ResimBase64 = "src=\"data: image / png; base64," + item.ResimBase64;                
                else                
                    item.ResimBase64 = "src=\"../.." + item.ResimUrl;                
            }
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        [HttpPost]
        public async Task<IActionResult> KategoriBannerSil(int id)
        {
            var result = await urunApiService.KategoriBannerSil(id);

            return Json(new { message = "Silme işlemi başarılı" });

        }

    }
}
