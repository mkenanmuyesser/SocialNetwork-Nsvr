using Microsoft.AspNetCore.Mvc;
using NeServer.Business.Katalog;
using NeSever.Common.Models.Katalog;
using System.Threading.Tasks;

namespace NeSever.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KatalogController : Controller
    {
        private readonly IKatalogBusiness katalogBusiness;

        public KatalogController(IKatalogBusiness katalogBusiness)
        {
            this.katalogBusiness = katalogBusiness;
        }
   
        [HttpPost]
        [Route("MarkaArama")]
        public async Task<IActionResult> MarkaArama(MarkaAramaVM markaAramaVM)
        {

            var webSite = await katalogBusiness.MarkaArama(markaAramaVM);
            return Ok(webSite);
        }

        [HttpPost]
        [Route("MarkaGuncelle")]
        public async Task<IActionResult> MarkaGuncelle(MarkaVM data)
        {
            var result = await katalogBusiness.MarkaGuncelle(data);
            return Ok(result);
        }
 
        [HttpGet]
        [Route("MarkaGetirById")]
        public async Task<IActionResult> MarkaGetirById(int id)
        {
            var result = await katalogBusiness.MarkaGetirById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("MarkaListesiGetir")]
        public async Task<IActionResult> MarkaListesiGetir()
        {
            var result = await katalogBusiness.MarkaListesiGetir();
            return Ok(result);
        }
    }
}
