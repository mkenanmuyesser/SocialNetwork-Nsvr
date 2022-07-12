using Microsoft.AspNetCore.Mvc;
using NeServer.Business.DataAktarim;
using NeSever.Common.Models.DataAktarim;
using System.Threading.Tasks;

namespace NeSever.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataAktarimController : Controller
    {
        private readonly IDataAktarimBusiness dataAktarimBusiness;

        public DataAktarimController(IDataAktarimBusiness dataAktarimBusiness)
        {
            this.dataAktarimBusiness = dataAktarimBusiness;
        }

        [HttpGet]
        [Route("WebSiteBilgileriniGetir")]
        public async Task<IActionResult> WebSiteBilgileriniGetir()
        {

            var webSite = await dataAktarimBusiness.WebSiteBilgileriniGetir();
            return Ok(webSite);
        }
        [HttpPost]
        [Route("WebSiteArama")]
        public async Task<IActionResult> WebSiteArama(WebSiteVM model)
        {

            var webSite = await dataAktarimBusiness.WebSiteArama(model);
            return Ok(webSite);
        }

        [HttpGet]
        [Route("DurumGuncelle")]
        public async Task<IActionResult> DurumGuncelle(int id)
        {
            var result = await dataAktarimBusiness.DurumGuncelle(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("WebSiteListesiniGetir")]
        public async Task<IActionResult> WebSiteListesiniGetir()
        {
            var result = await dataAktarimBusiness.WebSiteListesiniGetir();
            return Ok(result);
        }
        [HttpGet]
        [Route("UrunLinkBilgileriniGetir")]
        public async Task<IActionResult> UrunLinkBilgileriniGetir()
        {

            var webSite = await dataAktarimBusiness.UrunLinkBilgileriniGetir();
            return Ok(webSite);
        }
        [HttpPost]
        [Route("UrunLinkArama")]
        public async Task<IActionResult> UrunLinkArama(UrunLinkIslemVM urunLinkIslemVM)
        {

            var webSite = await dataAktarimBusiness.UrunLinkArama(urunLinkIslemVM);
            return Ok(webSite);
        }

        [HttpGet]
        [Route("UrunLinkDurumGuncelle")]
        public async Task<IActionResult> UrunLinkDurumGuncelle(int id)
        {
            var result = await dataAktarimBusiness.UrunLinkDurumGuncelle(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("HataLogArama")]
        public async Task<IActionResult> HataLogArama(HataLogVM HataLogVM)
        {

            var hatalog = await dataAktarimBusiness.HataLogArama(HataLogVM);
            return Ok(hatalog);
        }
    }
}
