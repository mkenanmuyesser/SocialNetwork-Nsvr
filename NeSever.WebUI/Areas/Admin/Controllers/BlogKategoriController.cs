using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Sayfa;
using NeSever.WebUI.Services;
using Newtonsoft.Json;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogKategoriController : BaseController
    {
        private readonly ISayfaApiService sayfaApiService;
        private IHostingEnvironment environment;


        public BlogKategoriController(ISayfaApiService sayfaApiService, IHostingEnvironment environment)
        {
            this.sayfaApiService = sayfaApiService;
            this.environment = environment;


        }


        [HttpGet]
        [ActionName("Kayit")]
        public async Task<IActionResult> KayitGet(int? Id)
        {
            BlogKategoriVM model = new BlogKategoriVM();
          
            if (Id.HasValue)
            {
                HttpContext.Session.Remove("ResimListesi");
                model = await sayfaApiService.BlogKategoriGetirById(Id.Value);
                HttpContext.Session.SetString("ResimListesi", JsonConvert.SerializeObject(model.BlogKategoriResimListesi));

            }

            return View(model);
        }
  
        [HttpPost]
        [ActionName("Kayit")]
        public async Task<JsonResult> KayitPost(BlogKategoriVM data, IEnumerable<IFormFile> file)
        {
            JsonResult result;
            data.Aciklama = data.AciklamaContent;
            data.BlogKategoriResimListesi = new List<BlogKategoriResimVM>();
            if(data.BlogKategoriId >0)
            {
                List<BlogKategoriResimVM> oncedenEklenenResimler = JsonConvert.DeserializeObject<List<BlogKategoriResimVM>>(HttpContext.Session.GetString("ResimListesi"));
                List<BlogKategoriResimVM> kaydedilmisResimler = await sayfaApiService.BlogKategoriResimListesiniGetir(data.BlogKategoriId);
                var pasifeAlinacakResimler = kaydedilmisResimler.Where(p => !oncedenEklenenResimler.Any(l => p.BlogKategoriResimId == l.BlogKategoriResimId));

                foreach (var item in pasifeAlinacakResimler)
                {
                    await sayfaApiService.BlogKategoriResimPasifeAl(item.BlogKategoriResimId);
                }
            }
            foreach (var item in file)
            {
                for(var i = 0; i<data.Resimler.Count;i++)
                {
                    if(item.FileName == data.Resimler[i])
                    {
                        MemoryStream ms = new MemoryStream();
                        item.CopyTo(ms);
                        byte[] resimByte = ms.ToArray();
                        ms.Close();
                        ms.Dispose();

                        BlogKategoriResimVM resim = new BlogKategoriResimVM();
                        resim.Resim = resimByte;
                        resim.ResimUrl = item.FileName;
                        resim.AktifMi = true;
                        data.BlogKategoriResimListesi.Add(resim);
                    }
                }                   
             }
             var id = await sayfaApiService.BlogKategoriKaydet(data);
            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.BlogKategoriId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.BlogKategoriId > 0 ? "update" : "insert" });
            return result;

        }

        [HttpGet]
        public IActionResult Arama()
        {
            BlogKategoriAramaVM BlogKategoriAramaVM = new BlogKategoriAramaVM();
            BlogKategoriAramaVM.AktifMi = -1;
            return View(BlogKategoriAramaVM);

        }
        [HttpPost]
        public async Task<IActionResult> Arama(BlogKategoriAramaVM model)
        {
            var result = await sayfaApiService.BlogKategoriAra(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }
        [HttpPost]
        public async Task<IActionResult> BlogKategoriSil(int id)
        {
            var result = await sayfaApiService.BlogKategoriSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }

        [HttpGet]
        public IActionResult ResimSil(string Id)
        {
            List<BlogKategoriResimVM> resimLst = new List<BlogKategoriResimVM>();
            if (HttpContext.Session.GetString("ResimListesi") != null)
                resimLst = JsonConvert.DeserializeObject<List<BlogKategoriResimVM>>(HttpContext.Session.GetString("ResimListesi"));
            var silinecekResim = resimLst.Where(p => p.BlogKategoriResimId == Convert.ToInt32(Id)).Single();
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
