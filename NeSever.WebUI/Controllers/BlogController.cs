using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Sayfa;
using NeSever.WebUI.Services;
using System.Threading.Tasks;

namespace NeSever.WebUI.Controllers
{
    public class BlogController : BaseController
    {
        private readonly ISayfaApiService sayfaApiService;
        private readonly IUyelikApiService uyelikApiService;
        public BlogController(ILogger<BaseController> logger, 
                              ISayfaApiService sayfaApiService, IUyelikApiService uyelikApiService) : base(logger,uyelikApiService)
        {
            this.uyelikApiService = uyelikApiService;
            this.sayfaApiService = sayfaApiService;
            this.logger = logger;
        }

        [ActionName("Ara")]
        public async Task<IActionResult> AraGet(BlogAramaSayfaVM blogAramaSayfaVM)
        {
            if (string.IsNullOrEmpty(blogAramaSayfaVM.id))
                return Redirect("/");

            var blogIcerikAramaVM = new BlogIcerikAramaVM()
            {
                OneCikanGonderi = false,
                BlogKategoriAttribute = blogAramaSayfaVM.id,
                Siralama = blogAramaSayfaVM.s,
                AramaKelime = blogAramaSayfaVM.q,
                start = blogAramaSayfaVM.p.HasValue && blogAramaSayfaVM.p.Value > 0 ? blogAramaSayfaVM.p.Value : 1,
                length = 5
            };

            var oneCikanBlogIcerikAramaVM = new BlogIcerikAramaVM()
            {
                OneCikanGonderi = true,
                BlogKategoriAttribute = blogAramaSayfaVM.id,

                start = 1,
                length = 0
            };

            var blogKategoriIcerikList = await sayfaApiService.BlogKategoriIcerikListGetir();
            var blogIcerikList = await sayfaApiService.BlogIcerikListGetir(blogIcerikAramaVM);
            var onerilenBlogIcerikList = await sayfaApiService.BlogIcerikListGetir(oneCikanBlogIcerikAramaVM);

            BlogAramaSayfaSonucVM model = new BlogAramaSayfaSonucVM()
            {
                BlogKategoriAttribute = blogAramaSayfaVM.id,
                BlogArama = blogAramaSayfaVM.q,
                BlogSiralama = blogAramaSayfaVM.s,

                BlogKategoriIcerikList = blogKategoriIcerikList,
                BlogIcerikList = blogIcerikList,
                OneCikanBlogIcerikList = onerilenBlogIcerikList,
            };
            return View(model);
        }

        public async Task<IActionResult> Detay(int id)
        {
            if (id <= 0)
                return Redirect("/");

            var blogIcerik = await sayfaApiService.BlogIcerikGetir(id);

            if (blogIcerik.BlogId <= 0)
                return Redirect("/");

            var oneCikanBlogIcerikAramaVM = new BlogIcerikAramaVM()
            {
                OneCikanGonderi = true,
                BlogKategoriAttribute = blogIcerik.BlogKategoriAttribute,
                start = 1,
                length = 0
            };

            var onerilenBlogIcerikList = await sayfaApiService.BlogIcerikListGetir(oneCikanBlogIcerikAramaVM);

            BlogDetaySayfaVM model = new BlogDetaySayfaVM()
            {
                BlogIcerik = blogIcerik,
                OneCikanBlogIcerikList = onerilenBlogIcerikList,
            };
            return View(model);
        }

        #region Partials


        #endregion

    }
}
