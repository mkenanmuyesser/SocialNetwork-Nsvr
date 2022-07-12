using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models;
using NeSever.Common.Models.Uyelik;
using NeSever.WebUI.Services;
using Newtonsoft.Json;
using System;

namespace NeSever.WebUI.Controllers
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class BaseController : Controller
    {
        public ILogger<BaseController> logger;
        private readonly IUyelikApiService uyelikApiService;

        public BaseController(ILogger<BaseController> logger, IUyelikApiService uyelikApiService)
        {
            this.logger = logger;
            this.uyelikApiService = uyelikApiService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var kullaniciSession = HttpContext.Session.GetString("Kullanici");
            if (kullaniciSession != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(kullaniciSession);
                if (token != null && token.Expiration <= DateTime.Now)
                {
                    //  AccessToken süresi bittiyse RefreshToken ile git, yeni bir AccessToken üreterek 
                    //  RefreshToken'ın süresini uzatıp dön ve yeni AccessToken'la birlikte session'a yaz.
                    var kullaniciYenilenenToken = uyelikApiService.KullaniciTokenYenile(new KullaniciTokenYenileSilVM
                    {
                        RefreshToken = token.RefreshToken,
                        Token = token.Token
                    });

                    if (kullaniciYenilenenToken.Type == ResultType.Basarili)
                    {
                        if (kullaniciYenilenenToken.Data.Token != null)
                        {
                            HttpContext.Session.Remove("Kullanici");
                            HttpContext.Session.SetString("Kullanici", JsonConvert.SerializeObject(kullaniciYenilenenToken.Data));
                        }
                    }
                    else
                    {
                        HttpContext.Session.Clear();
                        context.Result = new RedirectResult("/");
                    }
                }
            }
        }
    }
}