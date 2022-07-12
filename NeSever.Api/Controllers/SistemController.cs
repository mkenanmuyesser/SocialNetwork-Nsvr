using Microsoft.AspNetCore.Mvc;
using NeServer.Business.Sistem;
using NeSever.Common.Models.DataAktarim;
using NeSever.Common.Models.Sistem;
using System.Threading.Tasks;

namespace NeSever.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemController : Controller
    {
        private readonly ISistemBusiness sistemBusiness;

        public SistemController(ISistemBusiness sistemBusiness)
        {
            this.sistemBusiness = sistemBusiness;
        }

        [HttpGet]
        [Route("KategoriTreeViewListesiniGetir")]
        public async Task<IActionResult> KategoriTreeViewListesiniGetir()
        {
            var result = await sistemBusiness.KategoriTreeViewListesiniGetir();

            return Ok(result);
        }
        [HttpPost]
        [Route("DataKategoriListesiniGetir")]
        public async Task<IActionResult> DataKategoriListesiniGetir(DataKategoriAramaVM dataKategoriAramaVM)
        {
            var result = await sistemBusiness.DataKategoriListesiGetir(dataKategoriAramaVM);

            return Ok(result);
        }
        [HttpGet]
        [Route("GuncelleDataKategoriIsActive")]
        public async Task<IActionResult>  GuncelleDataKategoriIsActive(int id, bool isActive)
        {
            var result = await sistemBusiness.GuncelleDataKategoriIsActive(id,isActive);

            return Ok(result);
        }
        [HttpGet]
        [Route("GuncelleDataKategoriTargetCategory")]
        public async Task<IActionResult> GuncelleDataKategoriTargetCategory(int id, int targetCategoryId)
        {
            var result = await sistemBusiness.GuncelleDataKategoriTargetCategory(id,targetCategoryId);

            return Ok(result);
        }
        [HttpGet]
        [Route("DataKategoriTargetCategorySil")]
        public async Task<IActionResult> DataKategoriTargetCategorySil(int id)
        {
            var result = await sistemBusiness.DataKategoriTargetCategorySil(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("CacheTemizleme")]
        public async Task<IActionResult> CacheTemizleme(CacheTemizleme vm)
        {
            var result = await sistemBusiness.CacheTemizleme(vm);

            return Ok(result);
        }
    }
}
