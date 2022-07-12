using Microsoft.AspNetCore.Mvc;
using NeServer.Business.Sayfa;
using NeSever.Common.Commands.Sayfa;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Urun;
using System.Threading.Tasks;

namespace NeSever.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SayfaController : Controller
    {
        private readonly ISayfaBusiness sayfaBusiness;

        public SayfaController(ISayfaBusiness sayfaBusiness)
        {
            this.sayfaBusiness = sayfaBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Blog

        #region Admin
        [HttpPost]
        [Route("BlogKaydet")]
        public async Task<IActionResult> BlogKaydet([FromBody] BlogKayitVM model)
        {
            var blogKayitResult = await sayfaBusiness.BlogKaydet(model);
            return Ok(blogKayitResult);
        }
        [HttpGet]
        [Route("BlogKategoriTipleriniGetir")]
        public async Task<IActionResult> BlogKategoriTipleriniGetir()
        {
            var blogKayitResult = await sayfaBusiness.BlogKategoriTipleriniGetir();
            return Ok(blogKayitResult);
        }
        [HttpGet]
        [Route("UrunListesiGetir")]
        public async Task<IActionResult> UrunListesiGetir(string urunSKU)
        {

            var urunLstResult = await sayfaBusiness.UrunListesiGetir(urunSKU);
            return Ok(urunLstResult);
        }
        [HttpGet]
        [Route("UrunListesiniGetir")]
        public async Task<IActionResult> UrunListesiniGetir()
        {

            var urunLstResult = sayfaBusiness.UrunListesiGetir();
            return Ok(urunLstResult);
        }
        [HttpGet]
        [Route("UrunListesiniGetirIdIle")]
        public async Task<IActionResult> UrunListesiniGetirIdIle(string urunId)
        {

            var urunLstResult = sayfaBusiness.UrunListesiniGetirIdIle(urunId);
            return Ok(urunLstResult);
        }

        [HttpGet]
        [Route("ResimListesiniGetirBlogIdIle")]
        public IActionResult ResimListesiniGetirBlogIdIle(int blogId)
        {

            var urunLstResult = sayfaBusiness.ResimListesiniGetirBlogIdile(blogId);
            return Ok(urunLstResult);
        }
        [HttpPost]
        [Route("BlogArama")]
        public async Task<IActionResult> BlogArama(BlogAramaVM blogAramaVM)
        {
            var urunLstResult = await sayfaBusiness.BlogArama(blogAramaVM);
            return Ok(urunLstResult);
        }

        [HttpGet]
        [Route("BlogSil")]
        public async Task<IActionResult> BlogSil(int id)
        {
            var result = await sayfaBusiness.BlogSil(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("BlogResimPasifeAl")]
        public async Task<IActionResult> BlogResimPasifeAl(int blogResimId)
        {
            var result = await sayfaBusiness.BlogResimPasifeAl(blogResimId);
            return Ok(result);
        }
        [HttpGet]
        [Route("BlogGetirById")]
        public async Task<IActionResult> BlogGetirById(int id)
        {
            var result = await sayfaBusiness.BlogGetirById(id);

            return Ok(result);
        }
        [HttpPost]
        [Route("BlogGuncelle")]
        public async Task<IActionResult> BlogGuncelle(BlogKayitVM blogKayitVM)
        {
            var result = await sayfaBusiness.BlogGuncelle(blogKayitVM);
            return Ok(result);
        }

        [HttpPost]
        [Route("BlogUrunArama")]
        public async Task<IActionResult> BlogUrunArama(UrunAramaVM model)
        {
            var result = await sayfaBusiness.BlogUrunArama(model);
            return Ok(result);
        }
        #endregion

        #region FrontEnd
        [HttpGet]
        [Route("BlogIcerikGetir")]
        public async Task<IActionResult> BlogIcerikGetir(int id)
        {
            var result = await sayfaBusiness.BlogIcerikGetir(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("BlogIcerikListGetir")]
        public async Task<IActionResult> BlogIcerikListGetir(BlogIcerikAramaVM blogIcerikAramaVM)
        {
            var subset = await sayfaBusiness.BlogIcerikListGetir(blogIcerikAramaVM);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }
        #endregion

        #endregion

        #region Banner

        #region Admin
        [HttpGet]
        [Route("BannerTipleriniGetir")]
        public async Task<IActionResult> BannerTipleriniGetir()
        {
            var bannerTipResult = await sayfaBusiness.BannerTipleriniGetir();
            return Ok(bannerTipResult);
        }
        [HttpPost]
        [Route("BannerKaydet")]
        public async Task<IActionResult> BannerKaydet(BannerKayitVM model)
        {
            var result = await sayfaBusiness.BannerKaydet(model);

            return Ok(result);
        }


        [HttpGet]
        [Route("BannerGetirById")]
        public async Task<IActionResult> BannerGetirById(int id)
        {
            var result = await sayfaBusiness.BannerGetirById(id);

            return Ok(result);
        }


        [HttpPost]
        [Route("BannerArama")]
        public async Task<IActionResult> BannerArama(BannerAramaVM bannerAramaVM)
        {
            var bannerLst = await sayfaBusiness.BannerArama(bannerAramaVM);
            return Ok(bannerLst);
        }
        [HttpGet]
        [Route("BannerSil")]
        public async Task<IActionResult> BannerSil(int id)
        {
            var result = await sayfaBusiness.BannerSil(id);
            return Ok(result);
        }
        #endregion

        #region FrontEnd
        [HttpGet]
        [Route("BannerIcerikListGetir")]
        public async Task<IActionResult> BannerIcerikListGetir()
        {
            var result = await sayfaBusiness.BannerIcerikListGetir();

            return Ok(result);
        }
        #endregion

        #endregion

        #region KategoriBanner

        #region Admin

        #endregion

        #region FrontEnd
        [HttpPost]
        [Route("KategoriBannerIcerikListGetir")]
        public async Task<IActionResult> KategoriBannerIcerikListGetir(KategoriBannerIcerikAramaVM urunIcerikAramaVM)
        {
            var result = await sayfaBusiness.KategoriBannerIcerikListGetir(urunIcerikAramaVM);

            return Ok(result);
        }
        #endregion

        #endregion

        #region BlogKategori

        #region Admin
        [HttpPost]
        [Route("BlogKategoriKaydet")]
        public async Task<IActionResult> BlogKategoriKaydet([FromBody] BlogKategoriVM blogKategori)
        {
            var blogKategoriKayitResult = await sayfaBusiness.BlogKategoriKaydet(new BlogKategoriCommand
            {
                BlogKategori = blogKategori
            });
            return Ok(blogKategoriKayitResult.Result);
        }
        [HttpPost]
        [Route("BlogKategoriArama")]
        public async Task<IActionResult> BlogKategoriArama(BlogKategoriAramaVM blogAramaVM)
        {
            var urunLstResult = await sayfaBusiness.BlogKategoriArama(blogAramaVM);
            return Ok(urunLstResult);
        }

        [HttpGet]
        [Route("BlogKategoriSil")]
        public async Task<IActionResult> BlogKategoriSil(int id)
        {
            var result = await sayfaBusiness.BlogKategoriSil(id);
            return Ok(result);
        }
        [HttpGet]
        [Route("BlogKategoriGetirById")]
        public async Task<IActionResult> BlogKategoriGetirById(int id)
        {
            var result = await sayfaBusiness.BlogKategoriGetirById(id);

            return Ok(result);
        }


        [HttpGet]
        [Route("ResimListesiniGetirBlogKategoriIdIle")]
        public IActionResult ResimListesiniGetirBlogKategoriIdIle(int blogKategoriId)
        {

            var urunLstResult = sayfaBusiness.ResimListesiniGetirBlogKategoriIdile(blogKategoriId);
            return Ok(urunLstResult);
        }
        [HttpGet]
        [Route("BlogKategoriResimPasifeAl")]
        public async Task<IActionResult> BlogKategoriResimPasifeAl(int blogKategoriResimId)
        {
            var result = await sayfaBusiness.BlogKategoriResimPasifeAl(blogKategoriResimId);
            return Ok(result);
        }
        #endregion

        #region FrontEnd
        [HttpGet]
        [Route("BlogKategoriIcerikListGetir")]
        public async Task<IActionResult> BlogKategoriIcerikListGetir()
        {
            var result = await sayfaBusiness.BlogKategoriIcerikListGetir();

            return Ok(result);
        }
        #endregion

        #endregion

        #region HediyeKarti

        #region Admin
        [HttpPost]
        [Route("HediyeKartiKaydet")]
        public async Task<IActionResult> HediyeKartiKaydet([FromBody] HediyeKartVM hediyeKart)
        {
            return Ok(await sayfaBusiness.HediyeKartiKaydet(hediyeKart));

        }

        [HttpGet]
        [Route("HediyeKartiGetirById")]
        public async Task<IActionResult> HediyeKartiGetirById(int id)
        {
            var result = await sayfaBusiness.HediyeKartiGetirById(id);

            return Ok(result);
        }
        [HttpPost]
        [Route("HediyeKartArama")]
        public async Task<IActionResult> HediyeKartArama(HediyeKartAramaVM hediyeKartAramaVM)
        {
            var hediyeKartlst = await sayfaBusiness.HediyeKartArama(hediyeKartAramaVM);
            return Ok(hediyeKartlst);
        }
        [HttpGet]
        [Route("HediyeKartSil")]
        public async Task<IActionResult> HediyeKartSil(int id)
        {
            var result = await sayfaBusiness.HediyeKartSil(id);
            return Ok(result);
        }
        #endregion

        #region FrontEnd
        [HttpGet]
        [Route("HediyeKartIcerikGetir")]
        public async Task<IActionResult> HediyeKartIcerikGetir(int id)
        {
            var result = await sayfaBusiness.HediyeKartIcerikGetir(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("HediyeKartIcerikListGetir")]
        public async Task<IActionResult> HediyeKartIcerikListGetir()
        {
            var result = await sayfaBusiness.HediyeKartIcerikListGetir();

            return Ok(result);
        }
        #endregion

        #endregion

        #region IlgiAlan

        [HttpPost]
        [Route("IlgiAlanKaydet")]
        public async Task<IActionResult> IlgiAlanKaydet(IlgiAlanVM ilgiAlanVM)
        {

            return Ok(await sayfaBusiness.IlgiAlanKaydet(ilgiAlanVM));
        }

        [HttpGet]
        [Route("IlgiAlanGetirById")]
        public async Task<IActionResult> IlgiAlanGetirById(int id)
        {
            var result = await sayfaBusiness.IlgiAlanGetirById(id);

            return Ok(result);
        }


        [HttpPost]
        [Route("IlgiAlanArama")]
        public async Task<IActionResult> IlgiAlanArama(IlgiAlanAramaVM ilgiAlanAramaVM)
        {
            var result = await sayfaBusiness.IlgiAlanArama(ilgiAlanAramaVM);
            return Ok(result);
        }
        [HttpGet]
        [Route("IlgiAlanSil")]
        public async Task<IActionResult> IlgiAlanSil(int id)
        {
            var result = await sayfaBusiness.IlgiAlanSil(id);
            return Ok(result);
        }

        #endregion

        #region Hobi

        [HttpPost]
        [Route("HobiKaydet")]
        public async Task<IActionResult> HobiKaydet(HobiVM hobiVM)
        {
            return Ok(await sayfaBusiness.HobiKaydet(hobiVM));
        }

        [HttpGet]
        [Route("HobiGetirById")]
        public async Task<IActionResult> HobiGetirById(int id)
        {
            var result = await sayfaBusiness.HobiGetirById(id);

            return Ok(result);
        }
        [HttpPost]
        [Route("HobiArama")]
        public async Task<IActionResult> HobiArama(HobiAramaVM hobiAramaVM)
        {
            var result = await sayfaBusiness.HobiArama(hobiAramaVM);
            return Ok(result);
        }
        [HttpGet]
        [Route("HobiSil")]
        public async Task<IActionResult> HobiSil(int id)
        {
            var result = await sayfaBusiness.HobiSil(id);
            return Ok(result);
        }

        #endregion

        #region DuvarResim

        #region Admin

        [HttpPost]
        [Route("DuvarResimKaydet")]
        public async Task<IActionResult> DuvarResimKaydet(DuvarResimKayitVM model)
        {
            var result = await sayfaBusiness.DuvarResimKaydet(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("DuvarResimSil")]
        public async Task<IActionResult> DuvarResimSil(int id)
        {
            var result = await sayfaBusiness.DuvarResimSil(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("DuvarResimKayitVMGetir")]
        public async Task<IActionResult> DuvarResimKayitVMGetir(int id)
        {
            var result = await sayfaBusiness.DuvarResimKayitVMGetir(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("DuvarResimAramaSonucVMGetir")]
        public async Task<IActionResult> DuvarResimAramaSonucVMGetir(DuvarResimAramaVM model)
        {
            var result = await sayfaBusiness.DuvarResimAramaSonucVMGetir(model);
            return Ok(result);
        }

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Hediye Karti Kategori

        #region Admin
        [HttpGet]
        [Route("HediyeKartKategoriGetirById")]
        public async Task<IActionResult> HediyeKartKategoriGetirById(int id)
        {
            var result = await sayfaBusiness.HediyeKartKategoriGetirById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("HediyeKartKategoriKaydet")]
        public async Task<IActionResult> HediyeKartKategoriKaydet([FromBody] HediyeKartKategoriVM hediyeKartKategori)
        {
            return Ok(await sayfaBusiness.HediyeKartKategoriKaydet(hediyeKartKategori));

        }

        [HttpPost]
        [Route("HediyeKartKategoriArama")]
        public async Task<IActionResult> HediyeKartKategoriArama(HediyeKartKategoriAramaVM hediyeKartKategoriAramaVM)
        {
            var hediyeKartlst = await sayfaBusiness.HediyeKartKategoriArama(hediyeKartKategoriAramaVM);
            return Ok(hediyeKartlst);
        }

        [HttpGet]
        [Route("HediyeKartKategoriSil")]
        public async Task<IActionResult> HediyeKartKategoriSil(int id)
        {
            var result = await sayfaBusiness.HediyeKartKategoriSil(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("HediyeKartKategoriTipleriniGetir")]
        public async Task<IActionResult> HediyeKartKategoriTipleriniGetir()
        {
            var blogKayitResult = await sayfaBusiness.HediyeKartKategoriTipleriniGetir();
            return Ok(blogKayitResult);
        }

        [HttpPost]
        [Route("HediyeKartAramaIcerikListGetir")]
        public async Task<IActionResult> HediyeKartAramaIcerikListGetir(HediyeKartIcerikAramaVM hediyeKartIcerik)
        {
            var subset = await sayfaBusiness.HediyeKartAramaIcerikListGetir(hediyeKartIcerik);
            var result = new { items = subset, metaData = subset.GetMetaData() };

            return Ok(result);
        }
        #endregion

        #endregion

        #region İndirim Kuponu 

        #region Admin
        [HttpGet]
        [Route("IndirimKuponuGetirById")]
        public async Task<IActionResult> IndirimKuponuGetirById(int id)
        {
            var result = await sayfaBusiness.IndirimKuponuGetirById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("IndirimKuponuKaydet")]
        public async Task<IActionResult> IndirimKuponuKaydet(IndirimKuponuKayitVM model)
        {
            var result = await sayfaBusiness.IndirimKuponuKaydet(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("IndirimKuponuArama")]
        public async Task<IActionResult> IndirimKuponuArama(IndirimKuponuAramaVM indirimKuponuAramaVM)
        {
            var indirimList = await sayfaBusiness.IndirimKuponuArama(indirimKuponuAramaVM);
            return Ok(indirimList);
        }

        [HttpGet]
        [Route("IndirimKuponuSil")]
        public async Task<IActionResult> IndirimKuponuSil(int id)
        {
            var result = await sayfaBusiness.IndirimKuponuSil(id);
            return Ok(result);
        }
        #endregion

        #region FrontEnd
        [HttpPost]
        [Route("IndirimKuponuGetir")]
        public async Task<IActionResult> IndirimKuponuGetir(IndirimKuponuAramaVM indirimKuponuAramaVM)
        {
            var indirimList = await sayfaBusiness.IndirimKuponuGetir(indirimKuponuAramaVM);
            return Ok(indirimList);
        }
        #endregion

        #endregion
    }
}
