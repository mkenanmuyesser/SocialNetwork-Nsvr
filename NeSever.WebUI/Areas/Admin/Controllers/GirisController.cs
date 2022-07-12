using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Admin;
using NeSever.Common.Models.Program;
using NeSever.Common.Utils.Session;
using NeSever.WebUI.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Net;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GirisController : Controller
    {
        private IHostingEnvironment environment;
        private readonly IProgramApiService programApiService;
        public GirisController(IHostingEnvironment environment,
                               IProgramApiService programApiService)
        {
            this.programApiService = programApiService;
            this.environment = environment;
        }

        #region Index

        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> IndexGet(string returnUrl)
        {
            AyarlarVM ayarlar = await programApiService.AyarlarBilgileriniGetir();
            string ipBlokListesi = ayarlar.IpBlokListesi?.Trim();

            if (ayarlar.IpBloklamaAktifMi && !string.IsNullOrEmpty(ipBlokListesi))
            {
                IPAddress ip;
                var headers = Request.Headers.ToList();
                if (headers.Exists((kvp) => kvp.Key == "X-Forwarded-For"))
                {
                    // when running behind a load balancer you can expect this header
                    var header = headers.First((kvp) => kvp.Key == "X-Forwarded-For").Value.ToString();
                    ip = IPAddress.Parse(header);
                }
                else
                {
                    // this will always have a value (running locally in development won't have the header)
                    ip = Request.HttpContext.Connection.RemoteIpAddress;
                }
                if (ip != null)
                {
                    var ipler = ipBlokListesi.Split(';').ToList();

                    if (ipler.IndexOf(ip.ToString()) == -1)
                        return Redirect("/Home/SayfaBulunamadi");
                }
                else
                {
                    return Redirect("/Home/SayfaBulunamadi");
                }
            }

            returnUrl = string.IsNullOrEmpty(returnUrl) || returnUrl.IndexOf("/Admin") < 0 ? null : returnUrl.Remove(0, returnUrl.IndexOf("/Admin"));
            YoneticiKullaniciGirisVM model = new YoneticiKullaniciGirisVM()
            {
                ReturnUrl = returnUrl,
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<JsonResult> IndexPost(YoneticiKullaniciGirisVM model)
        {
            var kullaniciGirisData = await programApiService.YoneticiKullaniciGirisDataGetir(model);

            JsonResult result;
            if (kullaniciGirisData == null)
            {
                result = Json(new { message = "error", returnUrl = "" });
            }
            else
            {
                HttpContext.Session.SetObjectAsJson("KullaniciGirisData", kullaniciGirisData);

                //var returnUrl = string.IsNullOrEmpty(model.ReturnUrl) ? "/Admin" : model.ReturnUrl;
                //result = Json(new { message = "success", returnUrl = returnUrl });
                result = Json(new { message = "success", returnUrl = "/Admin" });
            }

            return result;
        }

        #endregion
    }
}
