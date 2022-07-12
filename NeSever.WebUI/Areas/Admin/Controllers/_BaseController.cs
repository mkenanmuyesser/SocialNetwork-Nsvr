using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Admin;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminActionFilter]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        [HttpGet]
        [ActionName("Cikis")]
        public IActionResult CikisGet()
        {
            //sessionları sil ve girişe yönlendir
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("KullaniciGirisData");
            return Redirect("/Admin/Giris");
        }

        public YoneticiKullaniciGirisVM KullaniciDataGetir()
        {
            return ViewBag.KullaniciGirisData as YoneticiKullaniciGirisVM;
        }
    }
}
