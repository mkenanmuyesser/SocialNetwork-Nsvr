using Microsoft.AspNetCore.Mvc;
using NeServer.Business.Urun;
using NeSever.Common.Commands.Urun;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.Common.Models.Urun;
using System.Threading.Tasks;

namespace NeSever.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : Controller
    {
        private readonly IUrunBusiness urunBusiness;

        public UrunController(IUrunBusiness urunBusiness)
        {
            this.urunBusiness = urunBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Marka

        #region Admin

        #endregion

        #region FrontEnd   

        [HttpGet]
        [Route("MarkaIcerikListGetir")]
        public async Task<IActionResult> MarkaIcerikListGetir()
        {
            var result = await urunBusiness.MarkaIcerikListGetir();

            return Ok(result);
        }

        [HttpGet]
        [Route("MarkaListGetir")]
        public async Task<IActionResult> MarkaListGetir(string m)
        {
            var result = await urunBusiness.MarkaListGetir(m);

            return Ok(result);
        }

        [HttpGet]
        [Route("MarkaAdindanIdGetir")]
        public async Task<IActionResult> MarkaAdindanIdGetir(string markaAdi)
        {
            var result = await urunBusiness.MarkaAdindanIdGetir(markaAdi);

            return Ok(result);
        }

        #endregion

        #endregion

        #region Kategori

        #region Admin
        [HttpPost]
        [Route("KategoriKaydet")]
        public async Task<IActionResult> KategoriKaydet([FromBody] KategoriVM kategoriVM)
        {
            var kategoriKayitResult = await urunBusiness.KategoriKaydet(new KategoriCommand
            {
                Kategori = kategoriVM
            });
            return Ok(kategoriKayitResult.Result);
        }

        [HttpGet]
        [Route("KategoriGetirById")]
        public async Task<IActionResult> KategoriGetirById(int id)
        {
            var result = await urunBusiness.KategoriGetirById(id);

            return Ok(result);
        }


        [HttpPost]
        [Route("KategoriArama")]
        public async Task<IActionResult> KategoriArama(KategoriAramaVM kategoriAramaVM)
        {
            var kategoriList = await urunBusiness.KategoriArama(kategoriAramaVM);
            return Ok(kategoriList);
        }
        [HttpGet]
        [Route("KategoriSil")]
        public async Task<IActionResult> KategoriSil(int id)
        {
            var result = await urunBusiness.KategoriSil(id);
            return Ok(result);
        }
        [HttpGet]
        [Route("KategoriListesiniGetir")]
        public async Task<IActionResult> KategoriListesiniGetir()
        {
            var result = await urunBusiness.KategoriListesiniGetir();
            return Ok(result);
        }
        
        #endregion

        #region FrontEnd   

        [HttpGet]
        [Route("KategoriIcerikListGetir")]
        public async Task<IActionResult> KategoriIcerikListGetir(bool anasayfadaGoster = true)
        {
            var result = await urunBusiness.KategoriIcerikListGetir(anasayfadaGoster);

            return Ok(result);
        }

        #endregion

        #endregion

        #region KategoriBanner

        #region Admin      

        [HttpGet]
        [Route("KategoriBannerGetirById")]
        public async Task<IActionResult> KategoriBannerGetirById(int id)
        {
            var result = await urunBusiness.KategoriBannerGetirById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("KategoriBannerKaydet")]
        public async Task<IActionResult> KategoriBannerKaydet([FromBody] KategoriBannerVM kategoriVM)
        {
            var kategoriKayitResult = await urunBusiness.KategoriBannerKaydet(new KategoriBannerCommand
            {
                KategoriBanner = kategoriVM
            });
            return Ok(kategoriKayitResult.Result);
        }

        [HttpPost]
        [Route("KategoriBannerArama")]
        public async Task<IActionResult> KategoriBannerArama(KategoriBannerAramaVM kategoriAramaVM)
        {
            var kategoriList = await urunBusiness.KategoriBannerArama(kategoriAramaVM);
            return Ok(kategoriList);
        }

        [HttpGet]
        [Route("KategoriBannerSil")]
        public async Task<IActionResult> KategoriBannerSil(int id)
        {
            var result = await urunBusiness.KategoriBannerSil(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("KategoriBannerListesiniGetir")]
        public async Task<IActionResult> KategoriBannerListesiniGetir()
        {
            var result = await urunBusiness.KategoriBannerListesiniGetir();
            return Ok(result);
        }

        #endregion

        #region FrontEnd          

        #endregion

        #endregion

        #region Urun

        #region Admin
        [HttpPost]
        [Route("UrunKaydet")]
        public async Task<IActionResult> UrunKaydet([FromBody] UrunVM urunVM)
        {
            var urunKayitResult = await urunBusiness.UrunKaydet(new UrunCommand
            {
                Urun = urunVM
            });
            return Ok(urunKayitResult.Result);
        }

        [HttpGet]
        [Route("UrunGetirById")]
        public async Task<IActionResult> UrunGetirById(int id)
        {
            var result = await urunBusiness.UrunGetirById(id);

            return Ok(result);
        }
 

        [HttpPost]
        [Route("UrunArama")]
        public async Task<IActionResult> UrunArama(UrunAramaVM urunAramaVM)
        {
            var urunLst = await urunBusiness.UrunArama(urunAramaVM);
            return Ok(urunLst);
        }
        [HttpGet]
        [Route("UrunSil")]
        public async Task<IActionResult> UrunSil(int id)
        {
            var result = await urunBusiness.UrunSil(id);
            return Ok(result);
        }
        [HttpGet]
        [Route("UrunResimGetirById")]
        public async Task<IActionResult> UrunResimGetirById(int id)
        {
            var result = await urunBusiness.UrunResimGetirById(id);

            return Ok(result);
        }
        [HttpGet]
        [Route("UrunKategoriGetirById")]
        public async Task<IActionResult> UrunKategoriGetirById(int id)
        {
            var result = await urunBusiness.UrunKategoriGetirById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("YonlendirmeSayisiArttir")]
        public async Task YonlendirmeSayisiArttir(UrunYonlendirmeSayisi urun)
        {
             await urunBusiness.YonlendirmeSayisiArttir(urun);
        }

        [HttpPost]
        [Route("KullaniciFiyatGorListArttir")]
        public async Task KullaniciFiyatGorListArttir(KullaniciFiyatGorVM kullanici)
        {
            await urunBusiness.KullaniciFiyatGorListArttir(kullanici);
        }

        [HttpPost]
        [Route("UrunResimKaydet")]
        public async Task<IActionResult> UrunResimKaydet([FromBody] UrunResimVM urunResimVM)
        {
            var result = await urunBusiness.UrunResimKaydet(urunResimVM);
            return Ok(result);
        }

        [HttpPost]
        [Route("GoruntulenenUrunRaporuGetir")]
        public async Task<IActionResult> GoruntulenenUrunRaporuGetir(GoruntulenenUrunAramaVM model)
        {
            var result = await urunBusiness.GoruntulenenUrunRaporuGetir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("YonlendirilenUrunRaporuGetir")]
        public async Task<IActionResult> YonlendirilenUrunRaporuGetir(YonlendirilenUrunAramaVM model)
        {
            var result = await urunBusiness.YonlendirilenUrunRaporuGetir(model);

            return Ok(result);
        }
        #endregion

        #region FrontEnd   

        [HttpGet]
        [Route("TrendKadinUrunIcerikListGetir")]
        public async Task<IActionResult> TrendKadinUrunIcerikListGetir()
        {
            var result = await urunBusiness.TrendKadinUrunIcerikListGetir();

            return Ok(result);
        }

        [HttpGet]
        [Route("TrendErkekUrunIcerikListGetir")]
        public async Task<IActionResult> TrendErkekUrunIcerikListGetir()
        {
            var result = await urunBusiness.TrendErkekUrunIcerikListGetir();

            return Ok(result);
        }

        [HttpPost]
        [Route("UrunIcerikListGetir")]
        public async Task<IActionResult> UrunIcerikListGetir(UrunIcerikAramaVM urunIcerikAramaVM)
        {
            var subset = await urunBusiness.UrunIcerikListGetir(urunIcerikAramaVM);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }

        [HttpGet]
        [Route("UrunDetayIcerikGetir")]
        public async Task<IActionResult> UrunDetayIcerikGetir(int id)
        {
            var result = await urunBusiness.UrunDetayIcerikGetir(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("SurprizHediyeKontrol")]
        public async Task<IActionResult> SurprizHediyeKontrol(SurprizHediyeVM surprizHediye)
        {
            var result = await urunBusiness.SurprizHediyeKontrol(surprizHediye);

            return Ok(result);
        }

        #endregion

        #endregion

        #region Sürpriz Ürün
        [HttpPost]
        [Route("SurprizUrunGetir")]
        public async Task<IActionResult> SurprizUrunGetir(SurprizUrunKayitVM data)
        {
            var result = await urunBusiness.SurprizUrunGetir(data);

            return Ok(result);
        }

        [HttpPost]
        [Route("SurprizUrunKayit")]
        public async Task<IActionResult> SurprizUrunKayit(SurprizUrunKayitVM model)
        {
            var result = await urunBusiness.SurprizUrunKayit(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("SurprizUrunGetirById")]
        public async Task<IActionResult> SurprizUrunGetirById(int id)
        {
            var result = await urunBusiness.SurprizUrunGetirById(id);

            return Ok(result);
        }
        [HttpPost]
        [Route("SurprizUrunArama")]
        public async Task<IActionResult> SurprizUrunArama(SurprizUrunAramaVM model)
        {
            var urunLst = await urunBusiness.SurprizUrunArama(model);
            return Ok(urunLst);
        }
        [HttpGet]
        [Route("SurprizUrunSil")]
        public async Task<IActionResult> SurprizUrunSil(int id)
        {
            var result = await urunBusiness.SurprizUrunSil(id);

            return Ok(result);
        }
        #endregion
    }
}
