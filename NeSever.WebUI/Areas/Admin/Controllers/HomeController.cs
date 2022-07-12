using Microsoft.AspNetCore.Mvc;
using NeSever.WebUI.Services;
using System.Threading.Tasks;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        private readonly IProgramApiService programApiService; 
        public HomeController(IProgramApiService programApiService)
        {
            this.programApiService = programApiService;
        }

        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> IndexGet()
        {
            var model = await programApiService.PanelAnasayfaRaporlariGetir();
            return View(model);
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            return View();
        }
    }
}
