using AutoMapper;
using NeSever.BusinessDomain.Sayfa;
using NeSever.Common.Commands.Sayfa;
using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Urun;
using NeSever.Data.DataService.Sayfa;
using NeSever.Data.Entities;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace NeServer.Business.Sayfa
{
    public interface ISayfaBusiness
    {
        #region Blog

        #region Admin
        Task<int> BlogKaydet(BlogKayitVM model);
        Task<CommandResponse<BlogKayitVM>> BlogKaydet(BlogKayitCommand command);
        Task<List<BlogKategoriVM>> BlogKategoriTipleriniGetir();
        Task<List<NeSever.Common.Models.Sayfa.UrunVM>> UrunListesiGetir(string urunSKU);
        NeSever.Common.Models.Sayfa.UrunVM UrunListesiniGetirIdIle(string urunId);
        Task<List<BlogAramaResultVM>> BlogArama(BlogAramaVM blogAramaVM);
        Task<int> BlogSil(int id);
        Task<BlogKayitVM> BlogGetirById(int id);
        Task<int> BlogGuncelle(BlogKayitVM blogVM);
        Task<int> BlogResimPasifeAl(int id);
        List<BlogResimVM> ResimListesiniGetirBlogIdile(int blogId);
        List<NeSever.Common.Models.Sayfa.UrunVM> UrunListesiGetir();
        Task<List<UrunAramaResultVM>> BlogUrunArama(UrunAramaVM urunAramaVM);
        #endregion

        #region FrontEnd
        Task<BlogIcerikVM> BlogIcerikGetir(int id);
        Task<IPagedList<BlogIcerikVM>> BlogIcerikListGetir(BlogIcerikAramaVM blogIcerikAramaVM);
        #endregion

        #endregion

        #region Banner

        #region Admin
        Task<List<BannerTipVM>> BannerTipleriniGetir();
        Task<int> BannerKaydet(BannerKayitVM model);
        Task<BannerKayitVM> BannerGetirById(int id);
        Task<List<BannerAramaResultVM>> BannerArama(BannerAramaVM bannerAramaVM);
        Task<int> BannerSil(int id);
        #endregion

        #region FrontEnd
        Task<List<BannerIcerikVM>> BannerIcerikListGetir();
        #endregion

        #endregion

        #region KategoriBanner

        #region Admin
      
        #endregion

        #region FrontEnd
        Task<List<KategoriBannerIcerikVM>> KategoriBannerIcerikListGetir(KategoriBannerIcerikAramaVM urunIcerikAramaVM);
        #endregion

        #endregion

        #region BlogKategori

        #region Admin
        Task<CommandResponse<int>> BlogKategoriKaydet(BlogKategoriCommand command);
        Task<List<BlogKategoriResultVM>> BlogKategoriArama(BlogKategoriAramaVM blogAramaVM);
        Task<int> BlogKategoriSil(int id);
        Task<BlogKategoriVM> BlogKategoriGetirById(int id);
        Task<int> BlogKategoriResimPasifeAl(int id);
        List<BlogKategoriResimVM> ResimListesiniGetirBlogKategoriIdile(int blogKategoriId);
        #endregion

        #region FrontEnd
        Task<List<BlogKategoriIcerikVM>> BlogKategoriIcerikListGetir();
        #endregion

        #endregion

        #region Hediye Kartı

        #region Admin
        Task<int> HediyeKartiKaydet(HediyeKartVM model);
        Task<HediyeKartVM> HediyeKartiGetirById(int id);
        Task<List<HediyeKartAramaResultVM>> HediyeKartArama(HediyeKartAramaVM hediyeKartAramaVM);
        Task<int> HediyeKartSil(int id);
        Task<IPagedList<HediyeKartIcerikVM>> HediyeKartAramaIcerikListGetir(HediyeKartIcerikAramaVM hediyeKartIcerik);
        #endregion

        #region FrontEnd
        Task<HediyeKartIcerikVM> HediyeKartIcerikGetir(int id);
        Task<List<HediyeKartIcerikVM>> HediyeKartIcerikListGetir();
        #endregion

        #endregion

        #region IlgiAlan
        Task<int> IlgiAlanKaydet(IlgiAlanVM model);
        Task<IlgiAlanVM> IlgiAlanGetirById(int id);
        Task<List<IlgiAlanAramaResultVM>> IlgiAlanArama(IlgiAlanAramaVM ilgiAlanAramaVM);
        Task<int> IlgiAlanSil(int id);

        #endregion

        #region Hobi
        Task<int> HobiKaydet(HobiVM model);
        Task<HobiVM> HobiGetirById(int id);
        Task<List<HobiAramaResultVM>> HobiArama(HobiAramaVM hobiAramaResultVM);
        Task<int> HobiSil(int id);

        #endregion

        #region DuvarResim

        #region Admin

        Task<int> DuvarResimKaydet(DuvarResimKayitVM model);
        Task<bool> DuvarResimSil(int id);
        Task<DuvarResimKayitVM> DuvarResimKayitVMGetir(int id);
        Task<List<DuvarResimAramaSonucVM>> DuvarResimAramaSonucVMGetir(DuvarResimAramaVM model);

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Hediye Kartı Kategori

        #region Admin
        Task<HediyeKartKategoriVM> HediyeKartKategoriGetirById(int id);
        Task<int> HediyeKartKategoriKaydet(HediyeKartKategoriVM model);
        Task<List<HediyeKartKategoriAramaResultVM>> HediyeKartKategoriArama(HediyeKartKategoriAramaVM hediyeKartKategoriAramaVM);
        Task<int> HediyeKartKategoriSil(int id);

        Task<List<HediyeKartKategoriVM>> HediyeKartKategoriTipleriniGetir();


        #endregion

        #endregion

        #region İndirim Kuponu 

        #region Admin
        Task<IndirimKuponuKayitVM> IndirimKuponuGetirById(int id);
        Task<int> IndirimKuponuKaydet(IndirimKuponuKayitVM model);
        Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuArama(IndirimKuponuAramaVM indirimKuponuAramaVM);
        Task<int> IndirimKuponuSil(int id);

        #endregion

        #region FrontEnd
        Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuGetir(IndirimKuponuAramaVM indirimKuponuAramaVM);
        #endregion

        #endregion
    }

    public class SayfaBusiness : BaseBusiness, ISayfaBusiness
    {
        private readonly ISayfaDataService sayfaDataService;
        private readonly IMapper mapper;

        public SayfaBusiness(ISayfaDataService sayfaDataService, IMapper mapper)
        {
            this.sayfaDataService = sayfaDataService;
            this.mapper = mapper;
        }

        #region Blog

        #region Admin
        public async Task<List<BlogKategoriVM>> BlogKategoriTipleriniGetir()
        {
            List<BlogKategoriVM> response = new List<BlogKategoriVM>();
            var blogKategoriLst = await sayfaDataService.GetBlogKategori();
            foreach (var item in blogKategoriLst)
            {
                BlogKategoriVM blogKategoriVM = mapper.Map<BlogKategori, BlogKategoriVM>(item);
                response.Add(blogKategoriVM);
            }
            return response;

        }
        public async Task<List<NeSever.Common.Models.Sayfa.UrunVM>> UrunListesiGetir(string urunSKU)
        {
            List<NeSever.Common.Models.Sayfa.UrunVM> response = new List<NeSever.Common.Models.Sayfa.UrunVM>();
            var urunLst = await sayfaDataService.GetUrunBySku(urunSKU);
            foreach (var item in urunLst)
            {
                NeSever.Common.Models.Sayfa.UrunVM urunVM = mapper.Map<NeSever.Data.Entities.Urun, NeSever.Common.Models.Sayfa.UrunVM>(item);
                response.Add(urunVM);
            }
            return response;

        }
        public List<NeSever.Common.Models.Sayfa.UrunVM> UrunListesiGetir()
        {

            var urunLst = sayfaDataService.GetUrunList();

            return urunLst;

        }
        public List<BlogResimVM> ResimListesiniGetirBlogIdile(int blogId)
        {

            return sayfaDataService.GetResimListByBlogId(blogId);



        }
        public NeSever.Common.Models.Sayfa.UrunVM UrunListesiniGetirIdIle(string urunId)
        {

            var urun = sayfaDataService.GetUrunById(urunId);
            NeSever.Common.Models.Sayfa.UrunVM urunVM = mapper.Map<NeSever.Data.Entities.Urun, NeSever.Common.Models.Sayfa.UrunVM>(urun);

            return urunVM;

        }
        public Task<List<UrunAramaResultVM>> BlogUrunArama(UrunAramaVM urunAramaVM)
        {

            return sayfaDataService.BlogUrunArama(urunAramaVM);

        }
        public async Task<int> BlogKaydet(BlogKayitVM model)
        {

            return await sayfaDataService.BlogKaydet(model);


        }
        public async Task<CommandResponse<BlogKayitVM>> BlogKaydet(BlogKayitCommand command)
        {
            CommandResponse<BlogKayitVM> response = new CommandResponse<BlogKayitVM>(command);
            if (response.HasError)
                return AppError(response, response.Code);
            Blog blog = SayfaDomain.BlogKayit(command.Blog);


            try
            {
                blog = await sayfaDataService.BlogKayit(blog);

            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.User_ErrorOccuredWhileAddingRecord, ex);
            }

            return Ok(response, mapper.Map<Blog, BlogKayitVM>(blog));
        }
        public async Task<List<BlogAramaResultVM>> BlogArama(BlogAramaVM blogAramaVM)
        {

            return await sayfaDataService.GetBlogList(blogAramaVM);


        }
        public async Task<int> BlogSil(int id)
        {

            return await sayfaDataService.DeleteBlog(id);


        }
        public async Task<int> BlogResimPasifeAl(int id)
        {

            return await sayfaDataService.BlogResimPasifeAl(id);


        }
        public async Task<int> BlogGuncelle(BlogKayitVM blogVM)
        {
            Blog blog = mapper.Map<BlogKayitVM, Blog>(blogVM);

            List<BlogUrun> urunLst = new List<BlogUrun>();
            foreach (var item in blogVM.SecilenUrunListesi.ToList())
            {
                BlogUrun blogUrun = new BlogUrun()
                {
                    BlogId = blogVM.BlogId,
                    AktifMi = item.AktifMi,
                    Sira = item.Sira,
                    UrunId = item.UrunId,
                    Urun = sayfaDataService.GetUrunById(item.UrunId.ToString())

                };
                blog.BlogUrun.Add(blogUrun);

            }
            List<BlogResim> resimLst = new List<BlogResim>();
            foreach (var item in blogVM.BlogResimListesi.ToList())
            {
                BlogResim blogResim = new BlogResim()
                {
                    BlogId = blogVM.BlogId,
                    AktifMi = item.AktifMi,
                    Resim = item.Resim,
                    ResimUrl = item.ResimUrl


                };
                blog.BlogResim.Add(blogResim);

            }
            var response = await sayfaDataService.UpdateBlog(blog);
            return response;




        }
        public async Task<BlogKayitVM> BlogGetirById(int id)
        {
            Blog blog = await sayfaDataService.GetBlogById(id);

            BlogKayitVM model = new BlogKayitVM();
            model.YayinTarihi = blog.YayinTarihi.ToShortDateString();
            model.BaslangicTarihi = blog.BaslangicTarihi.HasValue == true ? blog.BaslangicTarihi.Value.ToShortDateString() : null;
            model.BitisTarihi = blog.BitisTarihi.HasValue == true ? blog.BitisTarihi.Value.ToShortDateString() : null;
            model.BlogId = blog.BlogId;
            model.BlogKategoriId = blog.BlogKategoriId;
            model.Baslik = blog.Baslik;
            model.KisaIcerik = blog.KisaIcerik;
            model.Icerik = blog.Icerik;
            model.Etiketler = blog.Etiketler;
            model.OneCikanGonderi = blog.OneCikanGonderi;
            model.MetaKeywords = blog.MetaKeywords;
            model.MetaDescription = blog.MetaDescription;
            model.MetaTitle = blog.MetaTitle;
            model.AktifMi = blog.AktifMi;
            model.BlogKategoriTipleri = await BlogKategoriTipleriniGetir();
            model.SecilenUrunListesi = await sayfaDataService.GetUrunListByBlogId(id);
            model.BlogResimListesi = sayfaDataService.GetResimListByBlogId(id);

            return model;
        }
        #endregion

        #region FrontEnd
        public async Task<BlogIcerikVM> BlogIcerikGetir(int id)
        {
            return await sayfaDataService.GetBlogIcerikById(id);
        }
        public async Task<IPagedList<BlogIcerikVM>> BlogIcerikListGetir(BlogIcerikAramaVM blogIcerikAramaVM)
        {
            return await sayfaDataService.GetBlogIcerikListByBlogKategoriAttribute(blogIcerikAramaVM);
        }
        #endregion

        #endregion

        #region Banner

        #region Admin
        public async Task<List<BannerTipVM>> BannerTipleriniGetir()
        {
            List<BannerTipVM> response = new List<BannerTipVM>();
            var bannerLst = await sayfaDataService.GetBannerTipleri();
            foreach (var item in bannerLst)
            {
                BannerTipVM bannertipVM = mapper.Map<BannerTip, BannerTipVM>(item);
                response.Add(bannertipVM);
            }
            return response;

        }
        public async Task<int> BannerKaydet(BannerKayitVM model)
        {
            return await sayfaDataService.BannerKaydet(model);
        }
        public async Task<BannerKayitVM> BannerGetirById(int id)
        {
            Banner banner = await sayfaDataService.GetBannerById(id);
            BannerKayitVM model = mapper.Map<Banner, BannerKayitVM>(banner);
            model.BannerTipleri = await BannerTipleriniGetir();

            return model;
        }
   
        public async Task<List<BannerAramaResultVM>> BannerArama(BannerAramaVM bannerAramaVM)
        {

            return await sayfaDataService.GetBannerList(bannerAramaVM);


        }
        public async Task<int> BannerSil(int id)
        {

            return await sayfaDataService.DeleteBanner(id);


        }
        #endregion

        #region FrontEnd
        public async Task<List<BannerIcerikVM>> BannerIcerikListGetir()
        {
            return await sayfaDataService.GetBannerIcerikList();
        }
        #endregion

        #endregion

        #region KategoriBanner

        #region Admin
      
        #endregion

        #region FrontEnd
        public async Task<List<KategoriBannerIcerikVM>> KategoriBannerIcerikListGetir(KategoriBannerIcerikAramaVM urunIcerikAramaVM)
        {
            return await sayfaDataService.GetKategoriBannerIcerikList(urunIcerikAramaVM);
        }
        #endregion

        #endregion

        #region Blog Kategori

        #region Admin
        public async Task<CommandResponse<int>> BlogKategoriKaydet(BlogKategoriCommand command)
        {
            CommandResponse<int> response = new CommandResponse<int>(command);
            var blogKategoriKontrol = await sayfaDataService.BlogKategoriKontrol(command.BlogKategori);
            int sonuc=0;
            if (blogKategoriKontrol)
            {
          
               
                try
                {
                   sonuc = await sayfaDataService.BlogKategoriKaydet(command.BlogKategori);

                }
                catch (Exception ex)
                {
                    return ServerError(response, ErrorCodes.User_ErrorOccuredWhileAddingRecord, ex);
                }

                return Ok(response, sonuc);
            }
            else
            {
                return ServerError(response, "Aynı attribute kullanılamaz.", null);
            }
        }
        public async Task<List<BlogKategoriResultVM>> BlogKategoriArama(BlogKategoriAramaVM blogKategoriVM)
        {

            return await sayfaDataService.GetBlogKategoriList(blogKategoriVM);


        }
        public async Task<int> BlogKategoriSil(int id)
        {

            return await sayfaDataService.DeleteBlogKategori(id);


        }
        public async Task<BlogKategoriVM> BlogKategoriGetirById(int id)
        {
            BlogKategori blogKategori = await sayfaDataService.GetBlogKategoriById(id);
            BlogKategoriVM model = new BlogKategoriVM();
            model.Aciklama = blogKategori.Aciklama;
            model.AktifMi = blogKategori.AktifMi;
            model.BlogKategoriAdi = blogKategori.BlogKategoriAdi;
            model.BlogKategoriAttribute = blogKategori.BlogKategoriAttribute;
            model.BlogKategoriId = blogKategori.BlogKategoriId;
            model.Sira = blogKategori.Sira;
            model.BlogKategoriResimListesi = sayfaDataService.GetBlogKategoriResimListByBlogId(id);
            return model;
        }
        public async Task<int> BlogKategoriResimPasifeAl(int id)
        {

            return await sayfaDataService.BlogKategoriResimPasifeAl(id);


        }
        public List<BlogKategoriResimVM> ResimListesiniGetirBlogKategoriIdile(int blogKategoriId)
        {

            return sayfaDataService.GetBlogKategoriResimListByBlogId(blogKategoriId);



        }
        #endregion

        #region FrontEnd
        public async Task<List<BlogKategoriIcerikVM>> BlogKategoriIcerikListGetir()
        {
            return await sayfaDataService.GetBlogKategoriIcerikList();
        }
        #endregion

        #endregion

        #region Hediye Kartı

        #region Admin
        public async Task<int> HediyeKartiKaydet(HediyeKartVM model)
        {
            return await sayfaDataService.HediyeKartKayit(model);
        }
        public async Task<HediyeKartVM> HediyeKartiGetirById(int id)
        {
            HediyeKartVM model = await sayfaDataService.GetHediyeKartById(id);
            model.HediyeKartKategoriTipleri = await HediyeKartKategoriTipleriniGetir();
            return model;
        }
 
        public async Task<List<HediyeKartAramaResultVM>> HediyeKartArama(HediyeKartAramaVM hediyeKartAramaVM)
        {
            return await sayfaDataService.GetHediyeKartList(hediyeKartAramaVM);
        }
        public async Task<int> HediyeKartSil(int id)
        {
            return await sayfaDataService.DeleteHediyeKart(id);
        }
        public async Task<IPagedList<HediyeKartIcerikVM>> HediyeKartAramaIcerikListGetir(HediyeKartIcerikAramaVM hediyeKartIcerik)
        {
            return await sayfaDataService.HediyeKartAramaIcerikListGetir(hediyeKartIcerik);
        }
        #endregion

        #region FrontEnd

        public async Task<HediyeKartIcerikVM> HediyeKartIcerikGetir(int id)
        {
            return await sayfaDataService.GetHediyeKartIcerikById(id);
        }

        public async Task<List<HediyeKartIcerikVM>> HediyeKartIcerikListGetir()
        {
            return await sayfaDataService.GetHediyeKartIcerikList();
        }

        #endregion

        #endregion

        #region İlgi Alan

        public async Task<int> IlgiAlanKaydet(IlgiAlanVM model)
        {
            return await sayfaDataService.IlgiAlanKayit(model);
        }
        public async Task<IlgiAlanVM> IlgiAlanGetirById(int id)
        {
            IlgiAlan ilgiAlan = await sayfaDataService.GetIlgiAlanById(id);
            IlgiAlanVM model = mapper.Map<IlgiAlan, IlgiAlanVM>(ilgiAlan);
            return model;
        }
     
        public async Task<List<IlgiAlanAramaResultVM>> IlgiAlanArama(IlgiAlanAramaVM ilgiAlanAramaVM)
        {

            return await sayfaDataService.GetIlgiAlanList(ilgiAlanAramaVM);


        }
        public async Task<int> IlgiAlanSil(int id)
        {

            return await sayfaDataService.DeleteIlgiAlan(id);


        }

        #endregion

        #region Hobi

        public async Task<int> HobiKaydet(HobiVM model)
        {
            return await sayfaDataService.HobiKayit(model);
        }
        public async Task<HobiVM> HobiGetirById(int id)
        {
            Hobi hobi = await sayfaDataService.GetHobiById(id);
            HobiVM model = mapper.Map<Hobi, HobiVM>(hobi);
            return model;
        }
        public async Task<List<HobiAramaResultVM>> HobiArama(HobiAramaVM hobiAramaVM)
        {

            return await sayfaDataService.GetHobiList(hobiAramaVM);


        }
        public async Task<int> HobiSil(int id)
        {

            return await sayfaDataService.DeleteHobi(id);


        }
        #endregion

        #region DuvarResim

        #region Admin

        public async Task<int> DuvarResimKaydet(DuvarResimKayitVM model)
        {
            return await sayfaDataService.DuvarResimKaydet(model);
        }

        public async Task<bool> DuvarResimSil(int id)
        {
            return await sayfaDataService.DuvarResimSil(id);
        }

        public async Task<DuvarResimKayitVM> DuvarResimKayitVMGetir(int id)
        {
            return await sayfaDataService.DuvarResimKayitVMGetir(id);
        }

        public async Task<List<DuvarResimAramaSonucVM>> DuvarResimAramaSonucVMGetir(DuvarResimAramaVM model)
        {
            return await sayfaDataService.DuvarResimAramaSonucVMGetir(model);
        }

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Hediye Kartı Kategori

        #region Admin
        public async Task<HediyeKartKategoriVM> HediyeKartKategoriGetirById(int id)
        {
            HediyeKartKategori hediyeKartKategori = await sayfaDataService.GetHediyeKartKategoriById(id);
            HediyeKartKategoriVM model = mapper.Map<HediyeKartKategori, HediyeKartKategoriVM>(hediyeKartKategori);
            return model;
        }

        public async Task<int> HediyeKartKategoriKaydet(HediyeKartKategoriVM model)
        {
            return await sayfaDataService.HediyeKartKategoriKayit(model);
        }

        public async Task<List<HediyeKartKategoriAramaResultVM>> HediyeKartKategoriArama(HediyeKartKategoriAramaVM hediyeKartKategoriAramaVM)
        {
            return await sayfaDataService.GetHediyeKartKategoriList(hediyeKartKategoriAramaVM);
        }

        public async Task<int> HediyeKartKategoriSil(int id)
        {
            return await sayfaDataService.DeleteHediyeKartKategori(id);
        }

        public async Task<List<HediyeKartKategoriVM>> HediyeKartKategoriTipleriniGetir()
        {
            List<HediyeKartKategoriVM> response = new List<HediyeKartKategoriVM>();
            var blogKategoriLst = await sayfaDataService.HediyeKartKategoriListesi();
            foreach (var item in blogKategoriLst)
            {
                HediyeKartKategoriVM blogKategoriVM = mapper.Map<HediyeKartKategori, HediyeKartKategoriVM>(item);
                response.Add(blogKategoriVM);
            }
            return response;

        }

        #endregion

        #endregion


        #region İndirim Kuponu 

        #region Admin
        public async Task<IndirimKuponuKayitVM> IndirimKuponuGetirById(int id)
        {
            IndirimKuponu kupon = await sayfaDataService.IndirimKuponuGetirById(id);
            IndirimKuponuKayitVM model = mapper.Map<IndirimKuponu, IndirimKuponuKayitVM>(kupon);

            return model;
        }

        public async Task<int> IndirimKuponuKaydet(IndirimKuponuKayitVM model)
        {
            return await sayfaDataService.IndirimKuponuKaydet(model);
        }
        public async Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuArama(IndirimKuponuAramaVM indirimKuponuAramaVM)
        {
            return await sayfaDataService.IndirimKuponuArama(indirimKuponuAramaVM);
        }
        public async Task<int> IndirimKuponuSil(int id)
        {
            return await sayfaDataService.IndirimKuponuSil(id);
        }

        #endregion

        #region FrontEnd
        public async Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuGetir(IndirimKuponuAramaVM indirimKuponuAramaVM)
        {
            return await sayfaDataService.IndirimKuponuGetir(indirimKuponuAramaVM);
        }
        #endregion

        #endregion
    }
}