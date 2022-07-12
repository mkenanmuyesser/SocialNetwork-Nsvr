using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using NeSever.Common.Models.Admin;
using NeSever.Common.Utils.Session;
using System;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    public class AdminActionFilter : Attribute, IActionFilter
    {
        public AdminActionFilter()
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var baseController = context.Controller as BaseController;
            var kullaniciLoginData = context.HttpContext.Session.GetObjectFromJson<YoneticiKullaniciGirisVM>("KullaniciGirisData");

            if (baseController == null)
            {
                GiriseDon(context);
            }
            else
            {
                if (kullaniciLoginData == null)
                {
                    GiriseDon(context);
                }
                else
                {
                    baseController.ViewBag.KullaniciGirisData = kullaniciLoginData;
                }
            }
        }

        private void GiriseDon(ActionExecutingContext context)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                area = "Admin",
                controller = "Giris",
                action = "Index",
                ReturnUrl = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(context.HttpContext.Request)
            }));
        }
    }
}
