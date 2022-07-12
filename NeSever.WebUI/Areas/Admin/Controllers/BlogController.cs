using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Sayfa;
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
    public class BlogController : BaseController
    {
        private IHostingEnvironment environment;
        private readonly ISayfaApiService sayfaApiService;
        private readonly IUrunApiService urunApiService;
        public BlogController(ISayfaApiService sayfaApiService, IHostingEnvironment environment,IUrunApiService urunApiService)
        {
            this.sayfaApiService = sayfaApiService;
            this.urunApiService = urunApiService;
            this.environment = environment;
        }

        [HttpGet]
        [ActionName("Kayit")]
        public async Task<IActionResult> KayitGet(int? Id)
        {

            BlogKayitVM BlogKayitVM = new BlogKayitVM();
            BlogKayitVM.SecilenUrunListesi = new List<Common.Models.Sayfa.UrunVM>();
            HttpContext.Session.Remove("UrunListesi");
            HttpContext.Session.Remove("ResimListesi");
            if (Id.HasValue)
            {
            
                BlogKayitVM = await sayfaApiService.BlogGetirById(Id.Value);
                BlogKayitVM.BlogKategoriTipleri = await sayfaApiService.BlogKategoriTipleriniGetir();
                HttpContext.Session.SetString("UrunListesi", JsonConvert.SerializeObject(BlogKayitVM.SecilenUrunListesi));
                HttpContext.Session.SetString("ResimListesi", JsonConvert.SerializeObject(BlogKayitVM.BlogResimListesi));
            }
            else
            {
                BlogKayitVM.BlogKategoriTipleri = await sayfaApiService.BlogKategoriTipleriniGetir();
            }
            return View(BlogKayitVM);
        }

        [HttpPost]
        [ActionName("Kayit")]
        public async Task<JsonResult> KayitPost(BlogKayitVM data, IEnumerable<IFormFile> file)
        {
            JsonResult result;
            data.Icerik = data.IcerikContent;
            data.KisaIcerik = data.KisaIcerikContent;
            if (HttpContext.Session.GetString("UrunListesi") != null)
                data.SecilenUrunListesi = JsonConvert.DeserializeObject<List<Common.Models.Sayfa.UrunVM>>(HttpContext.Session.GetString("UrunListesi"));

            data.BlogResimListesi = new List<BlogResimVM>();
            foreach (var item in file)
            {
                MemoryStream ms = new MemoryStream();
                item.CopyTo(ms);
                byte[] resimByte = ms.ToArray();
                ms.Close();
                ms.Dispose();
                BlogResimVM resim = new BlogResimVM();
                resim.Resim = resimByte;
                resim.ResimUrl = item.FileName;
                resim.AktifMi = true;
                data.BlogResimListesi.Add(resim);
            }

            if(data.BlogResimListesi.Count() == 0)
            {
                data.BlogResimListesi = JsonConvert.DeserializeObject<List<Common.Models.Sayfa.BlogResimVM>>(HttpContext.Session.GetString("ResimListesi"));
            }
            var id = await sayfaApiService.BlogKaydet(data);

            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.BlogId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.BlogId > 0 ? "update" : "insert" });
            return result;
        }

        public async Task<PartialViewResult> UrunBulPartial()
        {

            UrunAramaVM model = new UrunAramaVM();
            return PartialView("~/Areas/Admin/Views/Blog/Partials/UrunAramaPartial.cshtml", model);
        }
      

        [HttpGet]
        public async Task<JsonResult> UrunListesiGuncelle(List<string> seciliUrunler)
        {
          
            var idList=seciliUrunler[0].Split(",");
            var sessiondakiUrunler=new List<Common.Models.Sayfa.UrunVM>();
            if (HttpContext.Session.GetString("UrunListesi") != null)
                sessiondakiUrunler = JsonConvert.DeserializeObject<List<Common.Models.Sayfa.UrunVM>>(HttpContext.Session.GetString("UrunListesi"));
            for (int i=0;i< idList.Length;i++)
            {
                idList[i] = idList[i].Replace("[", string.Empty);
                idList[i] = idList[i].Replace("\\", string.Empty);
                idList[i] = idList[i].Replace("]", string.Empty);
                idList[i] = idList[i].Replace('"',' ');
                int Id = Convert.ToInt32(idList[i].Trim());
                Common.Models.Sayfa.UrunVM yeniEklenenUrun = new Common.Models.Sayfa.UrunVM();
                yeniEklenenUrun = await sayfaApiService.UrunListesiniGetirIdIle(Id);
                sessiondakiUrunler.Add(yeniEklenenUrun);
                

            }
            HttpContext.Session.SetString("UrunListesi", JsonConvert.SerializeObject(sessiondakiUrunler));
            return Json(sessiondakiUrunler);
        }
        [HttpGet]
        public JsonResult UrunSil(string Id)
        {
            List<Common.Models.Sayfa.UrunVM> urunLst = new List<Common.Models.Sayfa.UrunVM>();
            if (HttpContext.Session.GetString("UrunListesi") != null)
                urunLst = JsonConvert.DeserializeObject<List<Common.Models.Sayfa.UrunVM>>(HttpContext.Session.GetString("UrunListesi"));
            var silinecekUrun = urunLst.Where(p => p.UrunId == Convert.ToInt32(Id)).First();
        

            urunLst.Remove(silinecekUrun);
            HttpContext.Session.SetString("UrunListesi", JsonConvert.SerializeObject(urunLst));
            return Json(urunLst);
        }
        [HttpGet]
        public async Task<JsonResult> SecilenUrunleriKaydet(string girilenUrunIdleri)
        {
            int sira;
            List<Common.Models.Sayfa.UrunVM> urunLst = new List<Common.Models.Sayfa.UrunVM>();
            if (HttpContext.Session.GetString("UrunListesi") != null)
            {
                urunLst = JsonConvert.DeserializeObject<List<Common.Models.Sayfa.UrunVM>>(HttpContext.Session.GetString("UrunListesi"));
                sira = urunLst.Count + 1;
            }
            else
            {
                urunLst = new List<Common.Models.Sayfa.UrunVM>();
                sira = 1;
            }
            Common.Models.Sayfa.UrunVM urunModel = new Common.Models.Sayfa.UrunVM();
            urunModel = await sayfaApiService.UrunListesiniGetirIdIle(Convert.ToInt32(girilenUrunIdleri));

            urunModel.Sira = sira;
            urunModel.AktifMi = true;
            urunLst.Add(urunModel);


            HttpContext.Session.SetString("UrunListesi", JsonConvert.SerializeObject(urunLst));
            return Json(urunModel);
        }

        [HttpGet]
        [ActionName("Arama")]
        public async Task<IActionResult> AramaGet()
        {
            BlogAramaVM BlogAramaVM = new BlogAramaVM();
            BlogAramaVM.AktifMi = -1;
            BlogAramaVM.BlogKategoriTipleri = await sayfaApiService.BlogKategoriTipleriniGetir();
            BlogKategoriVM hepsi = new BlogKategoriVM()
            {
                BlogKategoriAdi = "Hepsi",
                BlogKategoriId = -1
            };
            BlogAramaVM.BlogKategoriTipleri.Append(hepsi);
            BlogAramaVM.BlogKategoriTipleri.OrderBy(p => p.BlogKategoriId);
            return View(BlogAramaVM);

        }

        [HttpPost]
        public async Task<IActionResult> AramaSonuclariniGetir(BlogAramaVM model)
        {
            var result = await sayfaApiService.BlogArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }
        [HttpPost]
        public async Task<IActionResult> UrunAramaSonuclariniGetir(UrunAramaVM model)
        {
            model.AktifMi = 1;
            var result = await sayfaApiService.BlogUrunArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }
        [HttpPost]
        public async Task<IActionResult> BlogSil(int id)
        {
            var result = await sayfaApiService.BlogSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }

        [HttpGet]
        public JsonResult ResimSil(string Id)
        {
            List<BlogResimVM> resimLst = new List<BlogResimVM>();
            if (HttpContext.Session.GetString("ResimListesi") != null)
                resimLst = JsonConvert.DeserializeObject<List<BlogResimVM>>(HttpContext.Session.GetString("ResimListesi"));
            var silinecekResim = resimLst.Where(p => p.BlogResimId == Convert.ToInt32(Id)).Single();
            if (silinecekResim != null)
            {
                resimLst.Remove(silinecekResim);
                foreach (var item in resimLst)
                {
                    item.ResimBase64 = Convert.ToBase64String(item.Resim);
                }
                HttpContext.Session.SetString("ResimListesi", JsonConvert.SerializeObject(resimLst));
            }
            return Json(resimLst);
        }


    }
}
