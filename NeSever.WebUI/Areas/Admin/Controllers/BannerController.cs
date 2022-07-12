using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Sayfa;
using NeSever.WebUI.Extensions;
using NeSever.WebUI.Services;
using NeSever.Common.Commands;
using Newtonsoft.Json;
using NeSever.Common.Commands.Sayfa;
using Microsoft.AspNetCore.Http.Extensions;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : BaseController
    {

        private IHostingEnvironment environment;

        private readonly ISayfaApiService sayfaApiService;

        public BannerController(ISayfaApiService sayfaApiService, IHostingEnvironment environment)
        {
            this.sayfaApiService = sayfaApiService;
            this.environment = environment;
        }

        [HttpGet]
        [ActionName("Kayit")]
        public async Task<IActionResult> KayitGet(int? Id)
        {
            BannerKayitVM model = new BannerKayitVM();

            if (Id.HasValue)
            {
                model = await sayfaApiService.BannerGetirById(Id.Value);
                if (!string.IsNullOrEmpty(model.ResimUrl))
                { model.ResimBase64 = Convert.ToBase64String(model.Resim);
                }
            }
            else
            { model.BannerTipleri = await sayfaApiService.BannerTipleriniGetir(); }

            return View(model);
        }




        [HttpPost]
        [ActionName("Kayit")]
        public async Task<JsonResult> KayitPost(BannerKayitVM data, IFormFile file)
        {
            JsonResult result;
            data.Aciklama1 = data.Aciklama1Content;
            data.Aciklama2 = data.Aciklama2Content;
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
           var id = await sayfaApiService.BannerKaydet(data);

            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.BannerId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.BannerId> 0 ? "update" : "insert" });
            return result;
        }


        [HttpGet]
        public async Task<IActionResult> Arama()
        {
            BannerAramaVM BannerAramaVM = new BannerAramaVM();
            BannerAramaVM.AktifMi = -1;
            BannerAramaVM.BannerTipleri = await sayfaApiService.BannerTipleriniGetir();
            return View(BannerAramaVM);

        }
        [HttpPost]
        public async Task<IActionResult> Arama(BannerAramaVM model)
        {
            var result = await sayfaApiService.BannerArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }
        [HttpPost]
        public async Task<IActionResult> BannerSil(int id)
        {
            var result = await sayfaApiService.BannerSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }
    }
}
