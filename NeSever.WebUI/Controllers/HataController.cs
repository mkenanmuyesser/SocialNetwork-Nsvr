using Microsoft.AspNetCore.Mvc;

namespace NeSever.WebUI.Controllers
{
    public class HataController : Controller
    {
        public IActionResult Hata_404()
        {
            return View();
        }

        public IActionResult Hata_500()
        {
            return View();
        }
    }
}
