using Microsoft.AspNetCore.Mvc;
using NeServer.Business.Program;
using NeSever.Common.Models.Admin;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Program;
using System.Threading.Tasks;

namespace NeSever.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : Controller
    {
        private readonly IProgramBusiness programBusiness;

        public ProgramController(IProgramBusiness programBusiness)
        {
            this.programBusiness = programBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Ayarlar

        #region Admin  

        [HttpGet]
        [Route("AyarlarBilgileriniGetir")]
        public async Task<IActionResult> AyarlarBilgileriniGetir()
        {
            var result = await programBusiness.AyarlarBilgileriniGetir();

            return Ok(result);
        }
        [HttpPost]
        [Route("AyarlarGuncelle")]
        public async Task<IActionResult> AyarlarGuncelle(AyarlarVM model)
        {
            var result = await programBusiness.AyarlarGuncelle(model);
            return Ok(result);
        }
     
        [HttpPost]
        [Route("LogArama")]
        public async Task<IActionResult> LogArama(LogAramaVM model)
        {
            var result = await programBusiness.LogArama(model);
            return Ok(result);
        }
        #endregion

        #region FrontEnd

        [HttpGet]
        [Route("UyelikSozlesmesiGetir")]
        public async Task<IActionResult> UyelikSozlesmesiGetir()
        {
            var result = await programBusiness.UyelikSozlesmesiGetir();
            return Ok(result);
        }

        [HttpGet]
        [Route("BilgiGetir")]
        public async Task<IActionResult> BilgiGetir()
        {
            var result = await programBusiness.BilgiGetir();
            return Ok(result);
        }

        [HttpGet]
        [Route("HakkimizdaBilgiGetir")]
        public async Task<IActionResult> HakkimizdaBilgiGetir()
        {
            var result = await programBusiness.HakkimizdaBilgiGetir();
            return Ok(result);
        }

        [HttpGet]
        [Route("IletisimBilgiGetir")]
        public async Task<IActionResult> IletisimBilgiGetir()
        {
            var result = await programBusiness.IletisimBilgiGetir();
            return Ok(result);
        }

        [HttpPost]
        [Route("IletisimTalepGonder")]
        public async Task<IActionResult> IletisimTalepGonder(IletisimTalepVM model)
        {
            var result = await programBusiness.IletisimTalepGonder(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("SikSorulanSorularGetir")]
        public async Task<IActionResult> SikSorulanSorularGetir()
        {
            var result = await programBusiness.SikSorulanSorularGetir();
            return Ok(result);
        }

        #endregion

        #endregion

        #region YoneticiKullanici

        #region Admin

        [HttpGet]
        [Route("YoneticiKullaniciKontrol")]
        public async Task<IActionResult> YoneticiKullaniciKontrol(string eposta)
        {
            var result = await programBusiness.YoneticiKullaniciKontrol(eposta);

            return Ok(result);
        }

        [HttpPost]
        [Route("YoneticiKullaniciGirisDataGetir")]
        public async Task<IActionResult> YoneticiKullaniciGirisDataGetir(YoneticiKullaniciGirisVM model)
        {
            var result = await programBusiness.YoneticiKullaniciGirisDataGetir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("YoneticiKullaniciKaydet")]
        public async Task<IActionResult> YoneticiKullaniciKaydet(YoneticiKullaniciKayitVM model)
        {
            var result = await programBusiness.YoneticiKullaniciKaydet(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("YoneticiKullaniciSil")]
        public async Task<IActionResult> YoneticiKullaniciSil(int id)
        {
            var result = await programBusiness.YoneticiKullaniciSil(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("YoneticiKullaniciKayitVMGetir")]
        public async Task<IActionResult> YoneticiKullaniciKayitVMGetir(int id)
        {
            var result = await programBusiness.YoneticiKullaniciKayitVMGetir(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("YoneticiKullaniciArama")]
        public async Task<IActionResult> YoneticiKullaniciArama(YoneticiKullaniciAramaVM model)
        {
            var result = await programBusiness.YoneticiKullaniciArama(model);
            return Ok(result);
        }

        #endregion

        #region FrontEnd


        #endregion

        #endregion

        #region Kullanici

        #region Admin

        [HttpPost]
        [Route("UyeArama")]
        public async Task<IActionResult> UyeArama(KullaniciAramaVM model)
        {
            var result = await programBusiness.UyeArama(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("DogumKriterliUyeArama")]
        public async Task<IActionResult> DogumKriterliUyeArama(DogumKriterliKullaniciAramaVM model)
        {
            var result = await programBusiness.DogumKriterliUyeArama(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("UrunSayisinaGoreUyeArama")]
        public async Task<IActionResult> UrunSayisinaGoreUyeArama(UrunSayisinaGoreKullaniciArama model)
        {
            var result = await programBusiness.UrunSayisinaGoreUyeArama(model);
            return Ok(result);
        }

        #endregion

        #region FrontEnd


        #endregion

        #endregion

        #region Panel Anasayfa

        #region Admin

        [HttpGet]
        [Route("PanelAnasayfaRaporlariGetir")]
        public async Task<IActionResult> PanelAnasayfaRaporlariGetir()
        {
            var result = await programBusiness.PanelAnasayfaRaporlariGetir();
            return Ok(result);
        }

        #endregion

        #region FrontEnd

        #endregion

        #endregion
    }
}
