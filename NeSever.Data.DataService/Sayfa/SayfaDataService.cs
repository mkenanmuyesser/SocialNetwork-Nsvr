using AutoMapper;
using HappyFit.Data.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Urun;
using NeSever.Common.Utils.DistributedCache;
using NeSever.Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using X.PagedList;
using UrunVM = NeSever.Common.Models.Sayfa.UrunVM;

namespace NeSever.Data.DataService.Sayfa
{
    public interface ISayfaDataService
    {
        #region Blog

        #region Admin
        Task<int> BlogKaydet(BlogKayitVM model);
        Task<Blog> BlogKayit(Blog blog);
        Task<BlogUrun> BlogUrunKayit(BlogUrun blogUrun);
        Task<List<BlogKategori>> GetBlogKategori();
        Task<List<Urun>> GetUrunBySku(string urunSku);
        Urun GetUrunById(string urunId);
        Task<List<BlogAramaResultVM>> GetBlogList(BlogAramaVM blogAramaVM);
        Task<int> DeleteBlog(int id);
        Task<Blog> GetBlogById(int Id);
        Task<List<NeSever.Common.Models.Sayfa.UrunVM>> GetUrunListByBlogId(int blogId);
        Task<int> UpdateBlog(Blog blog);
        List<BlogResimVM> GetResimListByBlogId(int blogId);
        Task<int> BlogResimPasifeAl(int id);
        Task<List<UrunAramaResultVM>> BlogUrunArama(UrunAramaVM urunAramaVM);
        List<UrunVM> GetUrunList();

        #endregion

        #region FrontEnd
        Task<int> GetBlogKategoriIcerikByBlogKategoriAttribute(string blogKategoriAttribute);
        Task<BlogIcerikVM> GetBlogIcerikById(int id);
        Task<IPagedList<BlogIcerikVM>> GetBlogIcerikListByBlogKategoriAttribute(BlogIcerikAramaVM blogIcerikAramaVM);
        #endregion

        #endregion

        #region Banner

        #region Admin
        Task<List<BannerTip>> GetBannerTipleri();
        Task<int> BannerKaydet(BannerKayitVM banner);
        Task<Banner> GetBannerById(int Id);
        Task<List<BannerAramaResultVM>> GetBannerList(BannerAramaVM bannerAramaVM);
        Task<int> DeleteBanner(int id);
        #endregion

        #region FrontEnd
        Task<List<BannerIcerikVM>> GetBannerIcerikList();
        #endregion

        #endregion

        #region KategoriBanner

        #region Admin

        #endregion

        #region FrontEnd
        Task<List<KategoriBannerIcerikVM>> GetKategoriBannerIcerikList(KategoriBannerIcerikAramaVM urunIcerikAramaVM);
        #endregion

        #endregion

        #region BlogKategori

        #region Admin
        Task<bool> BlogKategoriKontrol(BlogKategoriVM blogKategoriVM);
        Task<int> BlogKategoriKaydet(BlogKategoriVM model);
        Task<BlogKategori> GetBlogKategoriById(int Id);
        Task<List<BlogKategoriResultVM>> GetBlogKategoriList(BlogKategoriAramaVM blogKategoriVM);
        Task<int> DeleteBlogKategori(int id);
        List<BlogKategoriResimVM> GetBlogKategoriResimListByBlogId(int blogId);
        Task<int> BlogKategoriResimPasifeAl(int id);
        #endregion

        #region FrontEnd
        Task<List<BlogKategoriIcerikVM>> GetBlogKategoriIcerikList();
        #endregion

        #endregion

        #region HediyeKart

        #region Admin
        Task<int> HediyeKartKayit(HediyeKartVM model);
        Task<HediyeKartVM> GetHediyeKartById(int Id);
        Task<List<HediyeKartAramaResultVM>> GetHediyeKartList(HediyeKartAramaVM hediyeKartAramaVM);
        Task<int> DeleteHediyeKart(int id);
        Task<IPagedList<HediyeKartIcerikVM>> HediyeKartAramaIcerikListGetir(HediyeKartIcerikAramaVM hediyeKartIcerik);
        #endregion

        #region FrontEnd
        Task<HediyeKartIcerikVM> GetHediyeKartIcerikById(int id);
        Task<List<HediyeKartIcerikVM>> GetHediyeKartIcerikList();
        #endregion

        #endregion

        #region IlgiAlan
        Task<int> IlgiAlanKayit(IlgiAlanVM model);
        Task<IlgiAlan> GetIlgiAlanById(int Id);
        Task<List<IlgiAlanAramaResultVM>> GetIlgiAlanList(IlgiAlanAramaVM ilgiAlanAramaVM);
        Task<int> DeleteIlgiAlan(int id);
        #endregion

        #region Hobi
        Task<int> HobiKayit(HobiVM model);
        Task<Hobi> GetHobiById(int Id);
        Task<List<HobiAramaResultVM>> GetHobiList(HobiAramaVM hobiAramaVM);
        Task<int> DeleteHobi(int id);
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

        Task<HediyeKartKategori> GetHediyeKartKategoriById(int Id);
        Task<int> HediyeKartKategoriKayit(HediyeKartKategoriVM model);
        Task<List<HediyeKartKategoriAramaResultVM>> GetHediyeKartKategoriList(HediyeKartKategoriAramaVM hediyeKartKategoriAramaVM);
        Task<int> DeleteHediyeKartKategori(int id);
        Task<List<HediyeKartKategori>> HediyeKartKategoriListesi();

        #endregion

        #endregion

        #region İndirim Kuponu 

        #region Admin
        Task<IndirimKuponu> IndirimKuponuGetirById(int id);
        Task<int> IndirimKuponuKaydet(IndirimKuponuKayitVM model);
        Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuArama(IndirimKuponuAramaVM indirimKuponuAramaVM);
        Task<int> IndirimKuponuSil(int id);
        #endregion

        #region FrontEnd

        #endregion
        Task<int> IndirimKuponSayisiGetir();
        Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuGetir(IndirimKuponuAramaVM indirimKuponuAramaVM);
        #endregion
    }

    public class SayfaDataService : BaseDataService, ISayfaDataService
    {
        private IUnitOfWork unitOfWork;
        private IMemoryCache memoryCache;
        private MemoryCacheEntryOptions memoryCacheEntryOptions;
        private IDistributedCache distributedCache;
        private DistributedCacheEntryOptions distributedCacheEntryOptions;
        private readonly IMapper mapper;
        private readonly IRepository repository;
        private readonly IReadOnlyRepository readOnlyRepository;
        private readonly ILogger<SayfaDataService> logger;
        private bool fileServerIsActive;
        private bool cacheIsActive;
        private string cacheType;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public SayfaDataService(IUnitOfWork unitOfWork,
                                IMemoryCache memoryCache,
                                IDistributedCache distributedCache,
                                IMapper mapper,
                                IRepository repository,
                                IReadOnlyRepository readOnlyRepository,
                                ILogger<SayfaDataService> logger)
        {
            this.unitOfWork = unitOfWork;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
            this.mapper = mapper;
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.logger = logger;

            var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings");
            if (appSettings != null)
            {
                fileServerIsActive = Convert.ToBoolean(appSettings["FileServerIsActive"]);
                cacheIsActive = Convert.ToBoolean(appSettings["CacheIsActive"]);

                if (cacheIsActive)
                {
                    cacheType = Convert.ToString(appSettings["CacheType"]);

                    switch (cacheType)
                    {
                        default:
                        case "Memory":
                            memoryCacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(Convert.ToDouble(appSettings["CacheExpiration"])));
                            break;
                        case "Redis":
                            distributedCacheEntryOptions = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(Convert.ToDouble(appSettings["CacheExpiration"])));
                            break;
                    }
                }
            }
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }

        #region Blog

        #region Admin
        public async Task<Blog> BlogKayit(Blog blog)
        {
            repository.Create(blog);

            try
            {
                await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return blog;

        }
        public async Task<int> BlogKaydet(BlogKayitVM model)
        {
            try
            {
                var blog = new Blog();

                if (model.BlogId == 0) // Insert
                {
                    blog = new Blog()
                    {
                        BlogKategoriId = model.BlogKategoriId,
                        Baslik = model.Baslik,
                        KisaIcerik = model.KisaIcerik,
                        Icerik = model.Icerik,
                        Etiketler = model.Etiketler,
                        YayinTarihi = Convert.ToDateTime(model.YayinTarihi),
                        BaslangicTarihi = !string.IsNullOrEmpty(model.BaslangicTarihi) ? Convert.ToDateTime(model.BaslangicTarihi) : (DateTime?)null,
                        BitisTarihi = !string.IsNullOrEmpty(model.BitisTarihi) ? Convert.ToDateTime(model.BitisTarihi) : (DateTime?)null,
                        OneCikanGonderi = model.OneCikanGonderi,
                        OkunmaSayisi = model.OkunmaSayisi,
                        MetaKeywords = model.MetaKeywords,
                        MetaDescription = model.MetaDescription,
                        MetaTitle = model.MetaTitle,
                        AktifMi = model.AktifMi,
                    };
                    List<BlogUrun> blogUrunLst = new List<BlogUrun>();
                    if (model.SecilenUrunListesi != null)
                    {
                        foreach (UrunVM item in model.SecilenUrunListesi)
                        {
                            BlogUrun blogUrun = new BlogUrun()
                            {
                                BlogId = model.BlogId,
                                UrunId = item.UrunId,
                                AktifMi = true,
                                Sira = item.Sira

                            };
                            blogUrunLst.Add(blogUrun);
                        }

                        blog.BlogUrun = blogUrunLst;
                    }
                    List<BlogResim> blogResimLst = new List<BlogResim>();
                    if (model.BlogResimListesi != null)
                    {
                        foreach (BlogResimVM item in model.BlogResimListesi)
                        {
                            BlogResim blogResim = new BlogResim()
                            {
                                BlogId = model.BlogId,
                                Resim = item.Resim,
                                ResimUrl = item.ResimUrl,
                                AltAttribute = item.AltAttribute,
                                TitleAttribute = item.TitleAttribute,
                                Aciklama = item.Aciklama,
                                AktifMi = item.AktifMi



                            };
                            blogResimLst.Add(blogResim);
                        }
                    }
                    blog.BlogUrun = blogUrunLst;
                    blog.BlogResim = blogResimLst;
                    repository.Create(blog);
                }
                else
                {
                    //Blog Update
                    blog = readOnlyRepository.GetQueryable<Blog>(w => w.BlogId == model.BlogId).Single();
                    blog.Baslik = model.Baslik;
                    blog.BlogKategoriId = model.BlogKategoriId;
                    blog.Etiketler = model.Etiketler;
                    blog.Icerik = model.Icerik;
                    blog.KisaIcerik = model.KisaIcerik;
                    blog.MetaDescription = model.MetaDescription;
                    blog.MetaKeywords = model.MetaKeywords;
                    blog.MetaTitle = model.MetaTitle;
                    blog.OkunmaSayisi = model.OkunmaSayisi;
                    if (!string.IsNullOrEmpty(model.YayinTarihi))
                        blog.YayinTarihi = Convert.ToDateTime(model.YayinTarihi);
                    blog.AktifMi = model.AktifMi;
                    if (!string.IsNullOrEmpty(model.BaslangicTarihi))
                        blog.BaslangicTarihi = Convert.ToDateTime(model.BaslangicTarihi);
                    if (!string.IsNullOrEmpty(model.BitisTarihi))
                        blog.BitisTarihi = Convert.ToDateTime(model.BitisTarihi);
                    blog.OneCikanGonderi = model.OneCikanGonderi;
                    repository.Update(blog);

                    //Blog Ürün update
                    var oncekiUrunler = readOnlyRepository.GetQueryable<BlogUrun>(w => w.BlogId == model.BlogId).ToList();
                    foreach (var item in oncekiUrunler)
                    {
                        item.AktifMi = false;
                        repository.Update(item);
                    }

                    if (model.SecilenUrunListesi != null && model.SecilenUrunListesi.Count() > 0)
                    {
                        List<BlogUrun> blogUrunLst = new List<BlogUrun>();
                        foreach (UrunVM item in model.SecilenUrunListesi)
                        {
                            BlogUrun blogUrun = new BlogUrun()
                            {
                                BlogId = model.BlogId,
                                UrunId = item.UrunId,
                                AktifMi = true,
                                Sira = item.Sira

                            };
                            blogUrunLst.Add(blogUrun);
                        }

                        blog.BlogUrun = blogUrunLst;
                    }


                    foreach (var item in blog.BlogUrun)
                    {
                        repository.Create(item);
                    }
                    if (model.BlogResimListesi.Count() > 0)
                    {
                        //Blog Resim Update
                        var oncekiResimler = readOnlyRepository.GetQueryable<BlogResim>(w => w.BlogId == model.BlogId).ToList();
                        foreach (var item in oncekiResimler)
                        {
                            item.AktifMi = false;
                            repository.Update(item);
                            SaveChanges();
                        }
                        List<BlogResim> blogResimLst = new List<BlogResim>();

                        foreach (BlogResimVM item in model.BlogResimListesi)
                        {
                            BlogResim blogResim = new BlogResim()
                            {
                                BlogId = model.BlogId,
                                Resim = item.Resim,
                                ResimUrl = item.ResimUrl,
                                AltAttribute = item.AltAttribute,
                                TitleAttribute = item.TitleAttribute,
                                Aciklama = item.Aciklama,
                                AktifMi = item.AktifMi,




                            };
                            blogResimLst.Add(blogResim);
                        }
                        blog.BlogResim = blogResimLst;
                        foreach (var item in blog.BlogResim)
                        {
                            repository.Create(item);
                        }
                    }
                    else
                    {
                        var oncekiResimler = readOnlyRepository.GetQueryable<BlogResim>(w => w.BlogId == model.BlogId).ToList();
                        foreach (var item in oncekiResimler)
                        {
                            item.AktifMi = false;
                            repository.Update(item);
                            SaveChanges();
                        }
                    }



                }

                var id = await SaveChanges();

                return blog.BlogId;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<BlogUrun> BlogUrunKayit(BlogUrun blogUrun)
        {
            repository.Create(blogUrun);

            try
            {
                await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return blogUrun;

        }
        public List<UrunVM> GetUrunList()
        {
            return readOnlyRepository.GetQueryable<Urun>()
                .Select(p => new UrunVM
                {
                    UrunAdi = p.UrunAdi,
                    UrunId = p.UrunId
                })
                .ToList();
        }
        public async Task<List<Urun>> GetUrunBySku(string urunSku)
        {
            return await readOnlyRepository.GetQueryable<Urun>(w => w.Sku.Contains(urunSku) || w.UrunAdi.StartsWith(urunSku)).Take(8).ToListAsync();
        }

        public Urun GetUrunById(string urunId)
        {
            return readOnlyRepository.GetQueryable<Urun>(w => w.UrunId == Convert.ToInt32(urunId)).SingleOrDefault();
        }

        public async Task<List<BlogAramaResultVM>> GetBlogList(BlogAramaVM blogAramaVM)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<Blog>(
                                          p => (blogAramaVM.Baslik == null || p.Baslik.StartsWith(blogAramaVM.Baslik))
                                              && (blogAramaVM.BlogId == null || p.BlogId == blogAramaVM.BlogId)
                                          && (blogAramaVM.BlogKategoriId == null || p.BlogKategoriId == blogAramaVM.BlogKategoriId)
                                          && (blogAramaVM.KisaIcerik == null || blogAramaVM.KisaIcerik.Contains(blogAramaVM.KisaIcerik))
                                          && (blogAramaVM.BaslangicTarihi == null || p.YayinTarihi >= Convert.ToDateTime(blogAramaVM.BaslangicTarihi))
                                          && (blogAramaVM.BitisTarihi == null || p.YayinTarihi <= Convert.ToDateTime(blogAramaVM.BitisTarihi))
                                          && (blogAramaVM.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(blogAramaVM.AktifMi)));

                var total = query.Count();

                return await query.Include("BlogKategori").OrderByDescending(p => p.BlogId)
                                    .Select(p => new BlogAramaResultVM
                                    {
                                        ResimBase64 = p.BlogResim.First(o => o.AktifMi == true).Resim != null ? Convert.ToBase64String(p.BlogResim.First(o => o.AktifMi == true).Resim) : null,
                                        Baslik = p.Baslik,
                                        BlogId = p.BlogId,
                                        Kategori = p.BlogKategori.BlogKategoriAdi.ToString(),
                                        Etiketler = p.Etiketler,
                                        YayinTarihi = p.YayinTarihi.ToShortDateString(),
                                        Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                        OkunmaSayisi = p.OkunmaSayisi.ToString(),
                                        KisaIcerik = p.KisaIcerik,
                                        TotalCount = total
                                    }).Skip(blogAramaVM.start)
                                    .Take(blogAramaVM.length)
                                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<int> DeleteBlog(int id)
        {
            Blog updatedBlog = readOnlyRepository.GetQueryable<Blog>(w => w.BlogId == id).Single();
            updatedBlog.AktifMi = false;
            repository.Update(updatedBlog);
            return await SaveChanges();

        }

        public async Task<int> UpdateBlog(Blog blog)
        {
            try
            {
                var oncekiUrunler = readOnlyRepository.GetQueryable<BlogUrun>(w => w.BlogId == blog.BlogId).ToList();
                foreach (var item in oncekiUrunler)
                {
                    item.AktifMi = false;
                    repository.Update(item);
                }
                Blog updatedBlog = readOnlyRepository.GetQueryable<Blog>(w => w.BlogId == blog.BlogId).Single();
                updatedBlog.YayinTarihi = blog.YayinTarihi;
                updatedBlog.BaslangicTarihi = blog.BaslangicTarihi;
                updatedBlog.BitisTarihi = blog.BitisTarihi;
                updatedBlog.BlogId = blog.BlogId;
                updatedBlog.BlogKategoriId = blog.BlogKategoriId;
                updatedBlog.Baslik = blog.Baslik;
                updatedBlog.KisaIcerik = blog.KisaIcerik;
                updatedBlog.Icerik = blog.Icerik;
                updatedBlog.Etiketler = blog.Etiketler;
                updatedBlog.OneCikanGonderi = blog.OneCikanGonderi;
                updatedBlog.MetaKeywords = blog.MetaKeywords;
                updatedBlog.MetaDescription = blog.MetaDescription;
                updatedBlog.MetaTitle = blog.MetaTitle;
                updatedBlog.AktifMi = blog.AktifMi;

                repository.Update(updatedBlog);

                SaveChanges();

                foreach (var item in blog.BlogUrun)
                {
                    repository.Create(item);
                }

                foreach (var item in blog.BlogResim)
                {
                    repository.Create(item);
                }

                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<Blog> GetBlogById(int Id)
        {


            return await readOnlyRepository.GetQueryable<Blog>(w => w.BlogId == Id)
                                      .Include("BlogUrun").SingleOrDefaultAsync();

        }

        public async Task<List<NeSever.Common.Models.Sayfa.UrunVM>> GetUrunListByBlogId(int blogId)
        {

            var query = readOnlyRepository.GetQueryable<BlogUrun>(p => p.BlogId == blogId && p.AktifMi == true)
                                          .Include("Urun");
            return await query.OrderByDescending(p => p.BlogUrunId)
                                .Select(p => new NeSever.Common.Models.Sayfa.UrunVM
                                {
                                    UrunId = p.UrunId,
                                    UrunAdi = p.Urun.UrunAdi,
                                    Sira = p.Sira,
                                    AktifMi = p.AktifMi,
                                    Sku = p.Urun.Sku
                                })
                                .ToListAsync();

        }

        public List<BlogResimVM> GetResimListByBlogId(int blogId)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<BlogResim>(p => p.BlogId == blogId && p.AktifMi == true);
                return query.OrderByDescending(p => p.BlogResimId)
                                    .Select(p => new BlogResimVM
                                    {
                                        BlogId = p.BlogId,
                                        BlogResimId = p.BlogResimId,
                                        Aciklama = p.Aciklama,
                                        AktifMi = p.AktifMi,
                                        Resim = p.Resim,
                                        ResimUrl = p.ResimUrl
                                    })
                                    .ToList();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public async Task<List<UrunAramaResultVM>> BlogUrunArama(UrunAramaVM urunAramaVM)
        {

            var query = readOnlyRepository.GetQueryable<Urun>(
                                           p => (urunAramaVM.UrunAdi == null || p.UrunAdi.StartsWith(urunAramaVM.UrunAdi))
                                           && (p.AktifMi == true)
                                           && (urunAramaVM.Sku == null || p.Sku.StartsWith(urunAramaVM.Sku)));

            var total = query.Count();

            return await query.OrderByDescending(p => p.UrunId)
                                .Select(p => new UrunAramaResultVM
                                {
                                    UrunId = p.UrunId,
                                    UrunAdi = p.UrunAdi,
                                    Sira = p.Sira,
                                    Sku = p.Sku,
                                    TotalCount = total
                                }).Skip(urunAramaVM.start)
                                .Take(urunAramaVM.length)
                                .ToListAsync();

        }
        public async Task<int> BlogResimPasifeAl(int id)
        {
            BlogResim updatedBlogResim = readOnlyRepository.GetQueryable<BlogResim>(w => w.BlogResimId == id).Single();
            updatedBlogResim.AktifMi = false;
            repository.Update(updatedBlogResim);
            return await SaveChanges();

        }
        #endregion

        #region FrontEnd
        public async Task<int> GetBlogKategoriIcerikByBlogKategoriAttribute(string blogKategoriAttribute)
        {
            var result = await readOnlyRepository.GetQueryable<BlogKategori>(w => w.BlogKategoriAttribute == blogKategoriAttribute).SingleOrDefaultAsync();
            return result.BlogKategoriId;
        }

        public async Task<BlogIcerikVM> GetBlogIcerikById(int id)
        {
            BlogIcerikVM result = new BlogIcerikVM();

            try
            {
                var blog = await readOnlyRepository.GetQueryable<Blog>(w => w.BlogId == id).SingleOrDefaultAsync();
                if (blog != null)
                {
                    blog.OkunmaSayisi++;
                    repository.Update(blog);
                    await SaveChanges();

                    result = await readOnlyRepository.GetQueryable<Blog>(w => w.BlogId == id)
                                                 .Include("BlogResim")
                                                 .Include("BlogKategori")
                                                 .Include("BlogUrun")
                                                 .Include("BlogUrun.Urun")
                                                 .Include("BlogUrun.Urun.UrunResim")
                                                 .Select(p => new BlogIcerikVM
                                                 {
                                                     BlogId = p.BlogId,
                                                     BlogKategoriId = p.BlogKategoriId,
                                                     BlogKategoriAdi = p.BlogKategori.BlogKategoriAdi,
                                                     BlogKategoriAttribute = p.BlogKategori.BlogKategoriAttribute,
                                                     Baslik = p.Baslik,
                                                     KisaIcerik = p.KisaIcerik,
                                                     Icerik = p.Icerik,
                                                     OneCikanGonderi = p.OneCikanGonderi,
                                                     SecilenUrunListesi = p.BlogUrun.Select(o => new UrunIcerikVM
                                                     {
                                                         UrunId = o.UrunId,
                                                         Sku = o.Urun.Sku,
                                                         MarkaAdi = o.Urun.Marka.MarkaAdi,
                                                         UrunAdi = o.Urun.UrunAdi,
                                                         ResimUrl = o.Urun.UrunResim.Any(x => x.AktifMi) ? (fileServerIsActive ? o.Urun.UrunResim.First(x => x.AktifMi).ResimUrl.Replace(@"\", @"/") : o.Urun.UrunResim.First(x => x.AktifMi).OrjinalResimUrl) : "/Uploads/Site/blog_empty_image_500_500.png",
                                                     }),
                                                     Etiketler = p.Etiketler,
                                                     YayinTarihi = p.YayinTarihi.ToString("dd.MM.yyyy"),
                                                     OkunmaSayisi = p.OkunmaSayisi,
                                                     ResimBase64 = p.BlogResim.Any(o => o.AktifMi) ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.BlogResim.Where(o => o.AktifMi).OrderBy(p => Guid.NewGuid()).First().Resim)) : "/Uploads/Site/blog_empty_image_500_500.png",
                                                 })
                                                 .SingleOrDefaultAsync();
                }


                if (!string.IsNullOrEmpty(result.Etiketler))
                {
                    var jarrayEtiketler = JsonConvert.DeserializeObject(result.Etiketler) as JArray;
                    if (jarrayEtiketler != null)
                    {
                        result.Etiketler = string.Join(',', jarrayEtiketler.Select(o => o["value"].ToString()));
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IPagedList<BlogIcerikVM>> GetBlogIcerikListByBlogKategoriAttribute(BlogIcerikAramaVM blogIcerikAramaVM)
        {
            IPagedList<BlogIcerikVM> resultList = new List<BlogIcerikVM>().ToPagedList();

            try
            {
                int blogKategoriId = await GetBlogKategoriIcerikByBlogKategoriAttribute(blogIcerikAramaVM.BlogKategoriAttribute);

                if (blogKategoriId > 0)
                {
                    var query = readOnlyRepository.GetQueryable<Blog>(p => p.AktifMi &&
                                                                           p.BlogKategoriId == blogKategoriId &&
                                                                           (string.IsNullOrEmpty(blogIcerikAramaVM.AramaKelime) ||
                                                                            p.Baslik.Contains(blogIcerikAramaVM.AramaKelime) ||
                                                                            p.KisaIcerik.Contains(blogIcerikAramaVM.AramaKelime) ||
                                                                            p.Icerik.Contains(blogIcerikAramaVM.AramaKelime)) &&
                                                                          ((blogIcerikAramaVM.OneCikanGonderi == true && p.OneCikanGonderi == blogIcerikAramaVM.OneCikanGonderi) || (blogIcerikAramaVM.OneCikanGonderi == false)));

                    var total = query.Count();

                    switch (blogIcerikAramaVM.Siralama)
                    {
                        default:
                        case "TEY":
                            query = query.OrderByDescending(p => p.BlogId);
                            break;
                        case "TEE":
                            query = query.OrderBy(p => p.BlogId);
                            break;
                    }

                    return await query.Include("BlogResim")
                                      .Include("BlogKategori")
                                      .Select(p => new BlogIcerikVM
                                      {
                                          BlogId = p.BlogId,
                                          BlogKategoriId = p.BlogKategoriId,
                                          BlogKategoriAdi = p.BlogKategori.BlogKategoriAdi,
                                          BlogKategoriAttribute = p.BlogKategori.BlogKategoriAttribute,
                                          Baslik = p.Baslik,
                                          KisaIcerik = p.KisaIcerik,
                                          Icerik = p.Icerik,
                                          OneCikanGonderi = p.OneCikanGonderi,
                                          //SecilenUrunListesi= 
                                          Etiketler = p.Etiketler,
                                          YayinTarihi = p.YayinTarihi.ToString("dd.MM.yyyy"),
                                          OkunmaSayisi = p.OkunmaSayisi,
                                          ResimBase64 = p.BlogResim.Any(o => o.AktifMi) ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.BlogResim.Where(o => o.AktifMi).OrderBy(p => Guid.NewGuid()).First().Resim)) : "/Uploads/Site/blog_empty_image_500_500.png",
                                      })
                                      .ToPagedListAsync((blogIcerikAramaVM.start <= 0 ? 1 : blogIcerikAramaVM.start), (blogIcerikAramaVM.length <= 0 ? (total <= 0 ? 1 : total) : blogIcerikAramaVM.length));
                }
                else
                {
                    return resultList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #endregion

        #region Banner

        #region Admin
        public async Task<List<BannerTip>> GetBannerTipleri()
        {
            return await readOnlyRepository.GetQueryable<BannerTip>(w => w.AktifMi == true)
                .OrderBy(p => p.Sira)
                .ToListAsync();
        }


        public async Task<int> BannerKaydet(BannerKayitVM model)
        {
            try
            {
                var data = new Banner();

                if (model.BannerId == 0)
                {
                    data = new Banner()
                    {
                        Aciklama1 = model.Aciklama1,
                        Aciklama2 = model.Aciklama2,
                        Adi = model.Adi,
                        BannerTipId = model.BannerTipId,
                        Link = model.Link,
                        AktifMi = model.AktifMi,
                        Resim = model.Resim,
                        ResimUrl = model.ResimUrl,
                        Sira = model.Sira


                    };
                    repository.Create(data);
                }
                else
                {
                    data = await readOnlyRepository.GetQueryable<Banner>(w => w.BannerId == model.BannerId).SingleOrDefaultAsync();
                    data.Aciklama1 = model.Aciklama1;
                    data.Aciklama2 = model.Aciklama2;
                    data.Adi = model.Adi;
                    data.BannerTipId = model.BannerTipId;
                    data.Link = model.Link;
                    data.AktifMi = model.AktifMi;
                    data.Sira = model.Sira;
                    if (!string.IsNullOrEmpty(model.ResimUrl))
                        data.ResimUrl = model.ResimUrl;
                    if (model.Resim != null)
                        data.Resim = model.Resim;
                    repository.Update(data);
                }

                var id = await SaveChanges();

                return data.BannerId;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<Banner> GetBannerById(int Id)
        {


            return await readOnlyRepository.GetQueryable<Banner>(w => w.BannerId == Id)
                                     .SingleOrDefaultAsync();

        }


        public async Task<List<BannerAramaResultVM>> GetBannerList(BannerAramaVM bannerAramaVM)
        {

            var query = readOnlyRepository.GetQueryable<Banner>(
                                           p => (bannerAramaVM.Adi == null || p.Adi.StartsWith(bannerAramaVM.Adi))
                                           && (bannerAramaVM.BannerTipId == null || p.BannerTipId == bannerAramaVM.BannerTipId)
                                           && (bannerAramaVM.BannerId == null || p.BannerId == bannerAramaVM.BannerId)
                                           && (bannerAramaVM.Sira == null || p.Sira == bannerAramaVM.Sira)
                                           && (bannerAramaVM.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(bannerAramaVM.AktifMi)));

            var total = query.Count();

            return await query.Include("BannerTip").OrderByDescending(p => p.BannerId)
                                .Select(p => new BannerAramaResultVM
                                {
                                    Adi = p.Adi,
                                    BannerTipAdi = p.BannerTip.Adi,
                                    BannerTipId = p.BannerTipId,
                                    BannerId = p.BannerId,
                                    Sira = p.Sira,
                                    Resim = p.Resim,
                                    Aciklama1 = p.Aciklama1,
                                    Aciklama2 = p.Aciklama2,
                                    AktifMi = p.AktifMi,
                                    Link = p.Link,
                                    ResimBase64 = Convert.ToBase64String(p.Resim),
                                    Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                    TotalCount = total
                                }).Skip(bannerAramaVM.start)
                                .Take(bannerAramaVM.length)
                                .ToListAsync();

        }

        public async Task<int> DeleteBanner(int id)
        {
            Banner updatedBanner = readOnlyRepository.GetQueryable<Banner>(w => w.BannerId == id).Single();
            updatedBanner.AktifMi = false;
            repository.Update(updatedBanner);
            return await SaveChanges();

        }
        #endregion

        #region FrontEnd
        public async Task<List<BannerIcerikVM>> GetBannerIcerikList()
        {
            List<BannerIcerikVM> result = null;

            if (cacheIsActive)
            {
                switch (cacheType)
                {
                    default:
                    case "Memory":
                        memoryCache.TryGetValue<List<BannerIcerikVM>>("GetBannerIcerikList", out result);
                        break;
                    case "Redis":
                        result = await distributedCache.GetAsync<List<BannerIcerikVM>>("GetBannerIcerikList");
                        break;
                }
            }

            if (result == null || !cacheIsActive)
            {
                try
                {
                    var query = readOnlyRepository.GetQueryable<Banner>(p => p.AktifMi);

                    var data = await query.OrderBy(p => p.Sira)
                                      .Select(p => new
                                      {
                                          p.BannerId,
                                          p.Aciklama1,
                                          p.Aciklama2,
                                          p.Link,
                                          p.Resim
                                      })
                                      .ToListAsync();

                    result = data.Select(p => new BannerIcerikVM
                    {
                        BannerId = p.BannerId,
                        Aciklama1 = p.Aciklama1,
                        Aciklama2 = p.Aciklama2,
                        Link = p.Link,
                        ResimBase64 = p.Resim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Resim)) : "/Uploads/Site/blog_empty_image_500_500.png"
                    }).ToList();

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<BannerIcerikVM>>("GetBannerIcerikList", result, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<BannerIcerikVM>>("GetBannerIcerikList", result, distributedCacheEntryOptions);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SayfaDataService", "GetBannerIcerikList"));
                }
            }

            return result ?? new List<BannerIcerikVM>();
        }

        #endregion

        #endregion

        #region KategoriBanner

        #region Admin

        #endregion

        #region FrontEnd
        public async Task<List<KategoriBannerIcerikVM>> GetKategoriBannerIcerikList(KategoriBannerIcerikAramaVM urunIcerikAramaVM)
        {
            List<KategoriBannerIcerikVM> result = null;

            if (cacheIsActive)
            {
                switch (cacheType)
                {
                    default:
                    case "Memory":
                        memoryCache.TryGetValue<List<KategoriBannerIcerikVM>>("GetKategoriBannerIcerikList", out result);
                        break;
                    case "Redis":
                        result = await distributedCache.GetAsync<List<KategoriBannerIcerikVM>>("GetKategoriBannerIcerikList");
                        break;
                }

                if (result != null)
                {
                    if (urunIcerikAramaVM.Anasayfa)
                    {
                        result = result.Where(p => p.AnasayfadaGoster).ToList();
                    }
                    else if (urunIcerikAramaVM.UstKategoriId.HasValue || urunIcerikAramaVM.UstKategoriBannerId.HasValue)
                    {
                        var tempResult = new List<KategoriBannerIcerikVM>();

                        if (urunIcerikAramaVM.UstKategoriId.HasValue)
                            tempResult.AddRange(result.Where(p => p.UstKategoriId == urunIcerikAramaVM.UstKategoriId.Value));

                        if (urunIcerikAramaVM.UstKategoriBannerId.HasValue)
                            tempResult.AddRange(result.Where(p => p.UstKategoriBannerId == urunIcerikAramaVM.UstKategoriBannerId.Value));

                        result = tempResult.Distinct().ToList();
                    }
                    else
                    {
                        result = new List<KategoriBannerIcerikVM>();
                    }
                }
            }

            if (result == null || !cacheIsActive)
            {
                try
                {
                    var query = readOnlyRepository.GetQueryable<KategoriBanner>(p => p.AktifMi);

                    var data = await query.OrderBy(p => p.Sira)
                                          .Select(p => new
                                          {
                                              p.KategoriBannerId,
                                              p.UstKategoriId,
                                              p.UstKategoriBannerId,
                                              p.Adi,
                                              p.Aciklama,
                                              p.ResimUrl,
                                              p.Parametre,
                                              p.AnasayfadaGoster,
                                              p.Resim
                                          })
                                         .ToListAsync();

                    result = data.Select(p => new KategoriBannerIcerikVM
                    {
                        KategoriBannerId = p.KategoriBannerId,
                        UstKategoriId = p.UstKategoriId,
                        UstKategoriBannerId = p.UstKategoriBannerId,
                        Adi = p.Adi,
                        Aciklama = p.Aciklama,
                        Resim = p.Resim == null ? (p.ResimUrl == null ? "/Uploads/Site/blog_empty_image_500_500.png" : p.ResimUrl) : string.Format("data:image/png;base64,{0}", Convert.ToBase64String(p.Resim)),
                        Parametre = p.Parametre,
                        AnasayfadaGoster = p.AnasayfadaGoster
                    }).ToList();

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<KategoriBannerIcerikVM>>("GetKategoriBannerIcerikList", result, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<KategoriBannerIcerikVM>>("GetKategoriBannerIcerikList", result, distributedCacheEntryOptions);
                                break;
                        }
                    }

                    if (urunIcerikAramaVM.Anasayfa)
                    {
                        result = result.Where(p => p.AnasayfadaGoster).ToList();
                    }
                    else if (urunIcerikAramaVM.UstKategoriId.HasValue || urunIcerikAramaVM.UstKategoriBannerId.HasValue)
                    {
                        var tempResult = new List<KategoriBannerIcerikVM>();

                        if (urunIcerikAramaVM.UstKategoriId.HasValue)
                            tempResult.AddRange(result.Where(p => p.UstKategoriId == urunIcerikAramaVM.UstKategoriId.Value));

                        if (urunIcerikAramaVM.UstKategoriBannerId.HasValue)
                            tempResult.AddRange(result.Where(p => p.UstKategoriBannerId == urunIcerikAramaVM.UstKategoriBannerId.Value));

                        result = tempResult.Distinct().ToList();
                    }
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SayfaDataService", "GetKategoriBannerIcerikList"));
                }
            }

            return result ?? new List<KategoriBannerIcerikVM>();
        }
        #endregion

        #endregion

        #region Blog Kategori

        #region Admin
        public async Task<bool> BlogKategoriKontrol(BlogKategoriVM blogKategoriVM)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if ((blogKategoriVM.BlogKategoriAttribute.Split(' ').Count() > 1 || !regexItem.IsMatch(blogKategoriVM.BlogKategoriAttribute)))
            {
                return false;
            }
            else
            {
                var result = await readOnlyRepository.GetQueryable<BlogKategori>(p => p.BlogKategoriId != blogKategoriVM.BlogKategoriId &&
                                                                            p.BlogKategoriAttribute.ToLower() == blogKategoriVM.BlogKategoriAttribute.ToLower())
                                                     .AnyAsync();
                return !result;
            }
        }

        public async Task<int> BlogKategoriKaydet(BlogKategoriVM model)
        {
            try
            {
                var blogKategori = new BlogKategori();

                if (model.BlogKategoriId == 0) // Insert
                {
                    blogKategori = new BlogKategori()
                    {

                        BlogKategoriAdi = model.BlogKategoriAdi,
                        Aciklama = model.Aciklama,
                        AktifMi = model.AktifMi,
                        BlogKategoriAttribute = model.BlogKategoriAttribute,
                        Sira = model.Sira


                    };
                    List<BlogKategoriResim> blogKategoriResimLst = new List<BlogKategoriResim>();
                    if (model.BlogKategoriResimListesi != null)
                    {
                        foreach (BlogKategoriResimVM item in model.BlogKategoriResimListesi)
                        {
                            BlogKategoriResim blogKategoriResim = new BlogKategoriResim()
                            {

                                Aciklama = item.Aciklama,
                                AktifMi = item.AktifMi,
                                AltAttribute = item.AltAttribute,
                                Resim = item.Resim,
                                ResimUrl = item.ResimUrl,
                                TitleAttribute = item.TitleAttribute,
                                BlogKategoriId = item.BlogKategoriId,


                            };
                            blogKategoriResimLst.Add(blogKategoriResim);
                        }

                        blogKategori.BlogKategoriResim = blogKategoriResimLst;
                    }
                    repository.Create(blogKategori);

                }
                else//Update 
                {
                    blogKategori = readOnlyRepository.GetQueryable<BlogKategori>(w => w.BlogKategoriId == model.BlogKategoriId).Single();
                    blogKategori.Aciklama = model.Aciklama;
                    blogKategori.BlogKategoriAdi = model.BlogKategoriAdi;
                    blogKategori.BlogKategoriAttribute = model.BlogKategoriAttribute;
                    blogKategori.BlogKategoriId = model.BlogKategoriId;
                    blogKategori.AktifMi = model.AktifMi;
                    blogKategori.Sira = model.Sira;
                    List<BlogKategoriResim> blogKategoriResimLst = new List<BlogKategoriResim>();
                    if (model.BlogKategoriResimListesi != null)
                    {
                        foreach (BlogKategoriResimVM item in model.BlogKategoriResimListesi)
                        {
                            BlogKategoriResim blogKategoriResim = new BlogKategoriResim()
                            {

                                Aciklama = item.Aciklama,
                                AktifMi = item.AktifMi,
                                AltAttribute = item.AltAttribute,
                                Resim = item.Resim,
                                ResimUrl = item.ResimUrl,
                                TitleAttribute = item.TitleAttribute,
                                BlogKategoriId = item.BlogKategoriId,


                            };
                            blogKategoriResimLst.Add(blogKategoriResim);
                        }

                        blogKategori.BlogKategoriResim = blogKategoriResimLst;
                    }
                    repository.Update(blogKategori);


                }

                var id = await SaveChanges();

                return blogKategori.BlogKategoriId;


            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<List<BlogKategori>> GetBlogKategori()
        {
            return await readOnlyRepository.GetQueryable<BlogKategori>(p => p.AktifMi == true).ToListAsync();
        }

        public async Task<BlogKategori> GetBlogKategoriById(int Id)
        {
            return await readOnlyRepository.GetQueryable<BlogKategori>(w => w.BlogKategoriId == Id)
                                     .SingleOrDefaultAsync();
        }

        public async Task<int> UpdateBlogKategori(BlogKategori blogKategori)
        {
            try
            {

                BlogKategori updatedBlogKategori = readOnlyRepository.GetQueryable<BlogKategori>(w => w.BlogKategoriId == blogKategori.BlogKategoriId).Single();
                updatedBlogKategori.Aciklama = blogKategori.Aciklama;
                updatedBlogKategori.BlogKategoriAdi = blogKategori.BlogKategoriAdi;
                updatedBlogKategori.BlogKategoriAttribute = blogKategori.BlogKategoriAttribute;
                updatedBlogKategori.BlogKategoriId = blogKategori.BlogKategoriId;
                updatedBlogKategori.AktifMi = blogKategori.AktifMi;
                updatedBlogKategori.Sira = blogKategori.Sira;
                repository.Update(updatedBlogKategori);
                SaveChanges();
                foreach (var item in blogKategori.BlogKategoriResim)
                {
                    repository.Create(item);
                }

                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<List<BlogKategoriResultVM>> GetBlogKategoriList(BlogKategoriAramaVM blogKategoriVM)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<BlogKategori>(
                                   p => (blogKategoriVM.BlogKategoriAdi == null || p.BlogKategoriAdi.Contains(blogKategoriVM.BlogKategoriAdi))
                                     && (blogKategoriVM.BlogKategoriId == null || p.BlogKategoriId == blogKategoriVM.BlogKategoriId)
                                   && (blogKategoriVM.Aciklama == null || p.Aciklama.Contains(blogKategoriVM.Aciklama))
                                   && (blogKategoriVM.Sira == null || p.Sira == blogKategoriVM.Sira)
                                   && (blogKategoriVM.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(blogKategoriVM.AktifMi)));

                var total = query.Count();

                return await query.Include("BlogKategoriResim").OrderByDescending(p => p.BlogKategoriId)
                                    .Select(p => new BlogKategoriResultVM
                                    {
                                        BlogKategoriAdi = p.BlogKategoriAdi,
                                        BlogKategoriId = p.BlogKategoriId,
                                        Aciklama = p.Aciklama,
                                        Sira = p.Sira,
                                        ResimBase64 = p.BlogKategoriResim.First(o => o.AktifMi == true).Resim != null ? Convert.ToBase64String(p.BlogKategoriResim.First(o => o.AktifMi == true).Resim) : null,
                                        Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                        TotalCount = total
                                    }).Skip(blogKategoriVM.start)
                                    .Take(blogKategoriVM.length)
                                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<int> DeleteBlogKategori(int id)
        {
            BlogKategori updatedBlogKategori = readOnlyRepository.GetQueryable<BlogKategori>(w => w.BlogKategoriId == id).Single();
            updatedBlogKategori.AktifMi = false;
            repository.Update(updatedBlogKategori);
            return await SaveChanges();

        }

        public List<BlogKategoriResimVM> GetBlogKategoriResimListByBlogId(int blogKategoriId)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<BlogKategoriResim>(p => p.BlogKategoriId == blogKategoriId && p.AktifMi == true);
                return query.OrderByDescending(p => p.BlogKategoriResimId)
                                    .Select(p => new BlogKategoriResimVM
                                    {
                                        BlogKategoriId = p.BlogKategoriId,
                                        BlogKategoriResimId = p.BlogKategoriResimId,
                                        Aciklama = p.Aciklama,
                                        AktifMi = p.AktifMi,
                                        Resim = p.Resim,
                                        ResimUrl = p.ResimUrl
                                    })
                                    .ToList();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<int> BlogKategoriResimPasifeAl(int id)
        {
            BlogKategoriResim updatedBlogResim = readOnlyRepository.GetQueryable<BlogKategoriResim>(w => w.BlogKategoriResimId == id).Single();
            updatedBlogResim.AktifMi = false;
            repository.Update(updatedBlogResim);
            return await SaveChanges();

        }
        #endregion

        #region FrontEnd
        public async Task<List<BlogKategoriIcerikVM>> GetBlogKategoriIcerikList()
        {
            List<BlogKategoriIcerikVM> result = null;

            if (cacheIsActive)
            {
                switch (cacheType)
                {
                    default:
                    case "Memory":
                        memoryCache.TryGetValue<List<BlogKategoriIcerikVM>>("GetBlogKategoriIcerikList", out result);
                        break;
                    case "Redis":
                        result = await distributedCache.GetAsync<List<BlogKategoriIcerikVM>>("GetBlogKategoriIcerikList");
                        break;
                }
            }

            if (result == null || !cacheIsActive)
            {
                try
                {
                    var query = readOnlyRepository.GetQueryable<BlogKategori>(p => p.AktifMi);

                    result = await query.Include("BlogKategoriResim")
                                        .OrderBy(p => p.Sira)
                                        .Select(p => new BlogKategoriIcerikVM
                                        {
                                            BlogKategoriId = p.BlogKategoriId,
                                            BlogKategoriAdi = p.BlogKategoriAdi,
                                            BlogKategoriAttribute = p.BlogKategoriAttribute,
                                            Aciklama = p.Aciklama,
                                            ResimBase64 = p.BlogKategoriResim.Any(o => o.AktifMi) ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.BlogKategoriResim.Where(o => o.AktifMi).OrderBy(p => Guid.NewGuid()).First().Resim)) : "/Uploads/Site/blog_empty_image_500_500.png"
                                        })
                                        .ToListAsync();

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<BlogKategoriIcerikVM>>("GetBlogKategoriIcerikList", result, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<BlogKategoriIcerikVM>>("GetBlogKategoriIcerikList", result, distributedCacheEntryOptions);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SayfaDataService", "GetBlogKategoriIcerikList"));
                }
            }

            return result ?? new List<BlogKategoriIcerikVM>();
        }
        #endregion

        #endregion

        #region HediyeKart

        #region Admin

        public async Task<int> HediyeKartKayit(HediyeKartVM model)
        {
            try
            {
                var data = new HediyeKart();

                if (model.HediyeKartId == 0)
                {
                    data = new HediyeKart()
                    {
                        HediyeKartAdi = model.HediyeKartAdi,
                        Aciklama = model.Aciklama,
                        KayitTarih = model.KayitTarih,
                        AktifMi = model.AktifMi,
                        Resim = model.Dosya,
                        ResimUrl = model.DosyaAdi,
                        KucukResim = model.KucukDosya,
                        KucukResimUrl = model.KucukDosyaAdi,
                        Sira = model.Sira,
                        HediyeKartKategoriId = model.HediyeKartKategoriId

                    };

                    repository.Create(data);
                }
                else
                {
                    data = await readOnlyRepository.GetQueryable<HediyeKart>(w => w.HediyeKartId == model.HediyeKartId).SingleOrDefaultAsync();
                    data.HediyeKartAdi = model.HediyeKartAdi;
                    data.Aciklama = model.Aciklama;
                    data.KayitTarih = model.KayitTarih;
                    data.AktifMi = model.AktifMi;
                    data.Sira = model.Sira;
                    data.HediyeKartKategoriId = model.HediyeKartKategoriId;

                    if (model.Dosya != null)
                    {
                        data.ResimUrl = model.DosyaAdi;
                        data.Resim = model.Dosya;
                    }

                    if (model.KucukDosya != null)
                    {
                        data.KucukResimUrl = model.KucukDosyaAdi;
                        data.KucukResim = model.KucukDosya;
                    }
                    repository.Update(data);
                }

                var id = await SaveChanges();

                return data.HediyeKartId;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<HediyeKartVM> GetHediyeKartById(int Id)
        {


            return await readOnlyRepository.GetQueryable<HediyeKart>(p => p.HediyeKartId == Id)
                                           .Select(p => new HediyeKartVM
                                           {
                                               HediyeKartId = p.HediyeKartId,
                                               HediyeKartAdi = p.HediyeKartAdi,
                                               Aciklama = p.Aciklama,
                                               DosyaAdi = p.ResimUrl,
                                               Dosya = p.Resim,
                                               Resim = p.Resim == null ? "/Uploads/Site/noimg.png" : String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(p.Resim, 0, p.Resim.Length)),
                                               KucukResim = p.KucukResim == null ? "/Uploads/Site/noimg.png" : String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(p.KucukResim, 0, p.KucukResim.Length)),
                                               Sira = p.Sira,
                                               AktifMi = p.AktifMi,
                                               HediyeKartKategoriId = p.HediyeKartKategoriId
                                           })
                                           .SingleOrDefaultAsync();

        }



        public async Task<List<HediyeKartAramaResultVM>> GetHediyeKartList(HediyeKartAramaVM hediyeKartAramaVM)
        {

            var query = readOnlyRepository.GetQueryable<HediyeKart>(
                                           p => (hediyeKartAramaVM.HediyeKartAdi == null || p.HediyeKartAdi.StartsWith(hediyeKartAramaVM.HediyeKartAdi))
                                           && (hediyeKartAramaVM.HediyeKartId == null || p.HediyeKartId == hediyeKartAramaVM.HediyeKartId)
                                           && (hediyeKartAramaVM.Aciklama == null || p.Aciklama.Trim().StartsWith(hediyeKartAramaVM.Aciklama.Trim()))
                                           && (hediyeKartAramaVM.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(hediyeKartAramaVM.AktifMi)));

            var total = query.Count();

            return await query.OrderByDescending(p => p.HediyeKartId)
                                .Select(p => new HediyeKartAramaResultVM
                                {
                                    HediyeKartAdi = p.HediyeKartAdi,
                                    Aciklama = p.Aciklama,
                                    AktifMi = p.AktifMi,
                                    Sira = p.Sira,
                                    HediyeKartId = p.HediyeKartId,
                                    KayitTarih = p.KayitTarih,
                                    ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : string.Empty,
                                    Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                    TotalCount = total
                                }).Skip(hediyeKartAramaVM.start)
                                .Take(hediyeKartAramaVM.length)
                                .ToListAsync();

        }

        public async Task<int> DeleteHediyeKart(int id)
        {
            HediyeKart updatedHediyeKart = readOnlyRepository.GetQueryable<HediyeKart>(w => w.HediyeKartId == id).Single();
            updatedHediyeKart.AktifMi = false;
            repository.Update(updatedHediyeKart);
            return await SaveChanges();

        }
        public async Task<IPagedList<HediyeKartIcerikVM>> HediyeKartAramaIcerikListGetir(HediyeKartIcerikAramaVM hediyeKartIcerik)
        {
            try
            {
                int start = hediyeKartIcerik.start <= 0 ? 0 : hediyeKartIcerik.start - 1;
                int length = hediyeKartIcerik.length <= 0 ? 1 : hediyeKartIcerik.length;

                var query = readOnlyRepository.GetQueryable<HediyeKart>(p => p.AktifMi &&
                                                                    (string.IsNullOrEmpty(hediyeKartIcerik.AramaKelime) ||
                                                                    EF.Functions.Like(p.HediyeKartAdi, hediyeKartIcerik.AramaKelime + "%")));
                if (hediyeKartIcerik.AramaKategori != 0)
                {
                    query = readOnlyRepository.GetQueryable<HediyeKart>(p => p.AktifMi && p.HediyeKartKategoriId == hediyeKartIcerik.AramaKategori &&
                                                                    (string.IsNullOrEmpty(hediyeKartIcerik.AramaKelime) ||
                                                                    EF.Functions.Like(p.HediyeKartAdi, hediyeKartIcerik.AramaKelime + "%")));
                }

                var result = await query.OrderBy(p => p.Sira)
                                      .Select(p => new HediyeKartIcerikVM
                                      {
                                          HediyeKartId = p.HediyeKartId,
                                          HediyeKartAdi = p.HediyeKartAdi,
                                          Aciklama = p.Aciklama,
                                          ResimBase64 = p.Resim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Resim)) : "/Uploads/Site/blog_empty_image_500_500.png",
                                      })
                                      .ToListAsync();

                var total = query.Count();

                var hediyeList = result.Skip(start * length).Take(length).ToList();

                return new StaticPagedList<HediyeKartIcerikVM>(hediyeList, start + 1, length, total);


            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region FrontEnd

        public async Task<HediyeKartIcerikVM> GetHediyeKartIcerikById(int id)
        {
            HediyeKartIcerikVM result = new HediyeKartIcerikVM();

            try
            {
                result = await readOnlyRepository.GetQueryable<HediyeKart>(w => w.HediyeKartId == id)
                                                 .Include("KullaniciHediyeKart")
                                                 .Select(p => new HediyeKartIcerikVM
                                                 {
                                                     HediyeKartId = p.HediyeKartId,
                                                     HediyeKartAdi = p.HediyeKartAdi,
                                                     Aciklama = p.Aciklama,
                                                     GonderilmeSayisi = p.KullaniciHediyeKart == null ? 0 : p.KullaniciHediyeKart.Count,
                                                     ResimBase64 = p.Resim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Resim)) : "/Uploads/Site/blog_empty_image_500_500.png",
                                                 })
                                                 .SingleOrDefaultAsync();


                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<HediyeKartIcerikVM>> GetHediyeKartIcerikList()
        {
            List<HediyeKartIcerikVM> result = null;

            if (cacheIsActive)
            {
                switch (cacheType)
                {
                    default:
                    case "Memory":
                        memoryCache.TryGetValue<List<HediyeKartIcerikVM>>("GetHediyeKartIcerikList", out result);
                        break;
                    case "Redis":
                        result = await distributedCache.GetAsync<List<HediyeKartIcerikVM>>("GetHediyeKartIcerikList");
                        break;
                }
            }

            if (result == null || !cacheIsActive)
            {
                try
                {
                    var query = readOnlyRepository.GetQueryable<HediyeKart>(
                                                   p => p.AktifMi);

                    result = await query.OrderBy(p => p.Sira)
                                        .Select(p => new HediyeKartIcerikVM
                                        {
                                            HediyeKartId = p.HediyeKartId,
                                            HediyeKartAdi = p.HediyeKartAdi,
                                            Aciklama = p.Aciklama,
                                            ResimBase64 = p.Resim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Resim)) : "/  Uploads/Site/blog_empty_image_500_500.png",
                                        })
                                        .ToListAsync();

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<HediyeKartIcerikVM>>("GetHediyeKartIcerikList", result, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<HediyeKartIcerikVM>>("GetHediyeKartIcerikList", result, distributedCacheEntryOptions);
                                break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SayfaDataService", "GetHediyeKartIcerikList"));
                }
            }

            return result ?? new List<HediyeKartIcerikVM>();
        }


        #endregion

        #endregion

        #region IlgiAlan


        public async Task<int> IlgiAlanKayit(IlgiAlanVM model)
        {
            try
            {
                var data = new IlgiAlan();

                if (model.IlgiAlanId == 0)
                {
                    var ilgiAlaniVarmi = readOnlyRepository.GetQueryable<IlgiAlan>(w => w.IlgiAlanAdi.Trim().ToLower() == model.IlgiAlanAdi.Trim().ToLower()).ToList();

                    if (ilgiAlaniVarmi.Count() != 0)
                    {
                        return -1;
                    }
                    data = new IlgiAlan()
                    {
                        IlgiAlanAdi = model.IlgiAlanAdi.Trim(),
                        AktifMi = model.AktifMi,
                        Resim = model.Resim,
                        ResimUrl = model.ResimUrl,
                        Sira = model.Sira


                    };
                    repository.Create(data);
                }
                else
                {
                    var ilgiAlan = readOnlyRepository.GetQueryable<IlgiAlan>(w => w.IlgiAlanId == model.IlgiAlanId).FirstOrDefault();

                    if (ilgiAlan.IlgiAlanAdi.Trim() != model.IlgiAlanAdi.Trim())
                    {
                        var ilgiAlaniVarmi = readOnlyRepository.GetQueryable<IlgiAlan>(w => w.IlgiAlanAdi.Trim().ToLower() == model.IlgiAlanAdi.Trim().ToLower()).ToList();

                        if (ilgiAlaniVarmi.Count() != 0)
                        {
                            return -1;
                        }
                    }

                    data = await readOnlyRepository.GetQueryable<IlgiAlan>(w => w.IlgiAlanId == model.IlgiAlanId).SingleOrDefaultAsync();
                    data.IlgiAlanAdi = model.IlgiAlanAdi.Trim();
                    data.AktifMi = model.AktifMi;
                    data.Resim = model.Resim != null ? model.Resim : data.Resim;
                    data.ResimUrl = model.ResimUrl != null ? model.ResimUrl : data.ResimUrl;
                    data.Sira = model.Sira;
                    if (!string.IsNullOrEmpty(model.ResimUrl))
                        data.ResimUrl = model.ResimUrl;
                    if (model.Resim != null)
                        data.Resim = model.Resim;
                    repository.Update(data);
                }

                var id = await SaveChanges();

                return data.IlgiAlanId;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IlgiAlan> GetIlgiAlanById(int Id)
        {


            return await readOnlyRepository.GetQueryable<IlgiAlan>(w => w.IlgiAlanId == Id)
                                     .SingleOrDefaultAsync();

        }

        public async Task<List<IlgiAlanAramaResultVM>> GetIlgiAlanList(IlgiAlanAramaVM ilgiAlanAramaVM)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<IlgiAlan>(
                                         p => (ilgiAlanAramaVM.IlgiAlanAdi == null || p.IlgiAlanAdi.StartsWith(ilgiAlanAramaVM.IlgiAlanAdi))
                                         && (ilgiAlanAramaVM.IlgiAlanId == null || p.IlgiAlanId == ilgiAlanAramaVM.IlgiAlanId)
                                         && (ilgiAlanAramaVM.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(ilgiAlanAramaVM.AktifMi)));

                var total = query.Count();

                return await query.OrderByDescending(p => p.IlgiAlanId)
                                    .Select(p => new IlgiAlanAramaResultVM
                                    {
                                        IlgiAlanAdi = p.IlgiAlanAdi,
                                        IlgiAlanId = p.IlgiAlanId,
                                        AktifMi = p.AktifMi,
                                        Sira = p.Sira,
                                        ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : string.Empty,
                                        Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                        TotalCount = total
                                    }).Skip(ilgiAlanAramaVM.start)
                                    .Take(ilgiAlanAramaVM.length)
                                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<int> DeleteIlgiAlan(int id)
        {
            IlgiAlan updatedIlgiAlan = readOnlyRepository.GetQueryable<IlgiAlan>(w => w.IlgiAlanId == id).Single();
            updatedIlgiAlan.AktifMi = false;
            repository.Update(updatedIlgiAlan);
            return await SaveChanges();

        }
        #endregion

        #region Hobi
        public async Task<int> HobiKayit(HobiVM model)
        {
            try
            {
                var data = new Hobi();

                if (model.HobiId == 0)
                {
                    var hobiVarmi = readOnlyRepository.GetQueryable<Hobi>(w => w.HobiAdi.Trim().ToLower() == model.HobiAdi.Trim().ToLower()).ToList();

                    if (hobiVarmi.Count() != 0)
                    {
                        return -1;
                    }

                    data = new Hobi()
                    {
                        HobiAdi = model.HobiAdi.Trim(),
                        AktifMi = model.AktifMi,
                        Resim = model.Resim,
                        ResimUrl = model.ResimUrl,
                        Sira = model.Sira
                    };
                    repository.Create(data);
                }
                else
                {
                    var hobi = readOnlyRepository.GetQueryable<Hobi>(w => w.HobiId == model.HobiId).FirstOrDefault();

                    if (hobi.HobiAdi.Trim() != model.HobiAdi.Trim())
                    {
                        var hobiVarmi = readOnlyRepository.GetQueryable<Hobi>(w => w.HobiAdi.Trim().ToLower() == model.HobiAdi.Trim().ToLower()).ToList();

                        if (hobiVarmi.Count() != 0)
                        {
                            return -1;
                        }
                    }

                    data = await readOnlyRepository.GetQueryable<Hobi>(w => w.HobiId == model.HobiId).SingleOrDefaultAsync();
                    data.HobiAdi = model.HobiAdi.Trim();
                    data.AktifMi = model.AktifMi;
                    data.Sira = model.Sira;
                    if (!string.IsNullOrEmpty(model.ResimUrl))
                        data.ResimUrl = model.ResimUrl;
                    if (model.Resim != null)
                        data.Resim = model.Resim;
                    repository.Update(data);
                }

                var id = await SaveChanges();

                return data.HobiId;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<Hobi> GetHobiById(int Id)
        {


            return await readOnlyRepository.GetQueryable<Hobi>(w => w.HobiId == Id)
                                     .SingleOrDefaultAsync();

        }



        public async Task<List<HobiAramaResultVM>> GetHobiList(HobiAramaVM hobiAramaVM)
        {

            var query = readOnlyRepository.GetQueryable<Hobi>(
                                           p => (hobiAramaVM.HobiAdi == null || p.HobiAdi.StartsWith(hobiAramaVM.HobiAdi))
                                           && (hobiAramaVM.HobiId == null || p.HobiId == hobiAramaVM.HobiId)
                                           && (hobiAramaVM.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(hobiAramaVM.AktifMi)));

            var total = query.Count();

            return await query.OrderByDescending(p => p.HobiId)
                                .Select(p => new HobiAramaResultVM
                                {
                                    HobiAdi = p.HobiAdi,
                                    HobiId = p.HobiId,
                                    AktifMi = p.AktifMi,
                                    Sira = p.Sira,
                                    ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : string.Empty,
                                    Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                    TotalCount = total
                                }).Skip(hobiAramaVM.start)
                                .Take(hobiAramaVM.length)
                                .ToListAsync();

        }

        public async Task<int> DeleteHobi(int id)
        {
            Hobi updatedHobi = readOnlyRepository.GetQueryable<Hobi>(w => w.HobiId == id).Single();
            updatedHobi.AktifMi = false;
            repository.Update(updatedHobi);
            return await SaveChanges();

        }

        #endregion

        #region DuvarResim

        #region Admin

        public async Task<int> DuvarResimKaydet(DuvarResimKayitVM model)
        {
            var data = new DuvarResim();

            if (model.DuvarResimId == 0)
            {
                data = new DuvarResim()
                {
                    //DuvarResimId = model.DuvarResimId,
                    Adi = model.Adi,
                    Aciklama = model.Aciklama,
                    ResimUrl = model.DosyaAdi,
                    Resim = model.Dosya,
                    Sira = model.Sira,
                    AktifMi = model.AktifMi
                };

                repository.Create(data);
            }
            else
            {
                data = await DuvarResimGetir(model.DuvarResimId);

                data.Adi = model.Adi;
                data.Aciklama = model.Aciklama;
                data.Sira = model.Sira;
                data.AktifMi = model.AktifMi;

                if (model.Dosya != null)
                {
                    data.ResimUrl = model.DosyaAdi;
                    data.Resim = model.Dosya;
                }

                if (model.KucukDosya != null)
                {
                    data.KucukResimUrl = model.KucukDosyaAdi;
                    data.KucukResim = model.KucukDosya;
                }

                repository.Update(data);
            }

            var id = await SaveChanges();

            return data.DuvarResimId;
        }

        public async Task<bool> DuvarResimSil(int id)
        {
            DuvarResim data = await DuvarResimGetir(id);
            data.AktifMi = false;
            repository.Update(data);

            var result = await SaveChanges();

            return result > 0 ? true : false;
        }

        public async Task<DuvarResimKayitVM> DuvarResimKayitVMGetir(int id)
        {
            return await readOnlyRepository.GetQueryable<DuvarResim>(p => p.DuvarResimId == id)
                                           .Select(p => new DuvarResimKayitVM
                                           {
                                               DuvarResimId = p.DuvarResimId,
                                               Adi = p.Adi,
                                               Aciklama = p.Aciklama,
                                               DosyaAdi = p.ResimUrl,
                                               Dosya = p.Resim,
                                               Resim = p.Resim == null ? "/Uploads/Site/noimg.png" : String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(p.Resim, 0, p.Resim.Length)),
                                               KucukResim = p.KucukResim == null ? "/Uploads/Site/noimg.png" : String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(p.KucukResim, 0, p.KucukResim.Length)),
                                               Sira = p.Sira,
                                               AktifMi = p.AktifMi
                                           })
                                           .SingleOrDefaultAsync();
        }

        public async Task<List<DuvarResimAramaSonucVM>> DuvarResimAramaSonucVMGetir(DuvarResimAramaVM model)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<DuvarResim>(p => (model.Aktiflik == -1 || p.AktifMi == Convert.ToBoolean(model.Aktiflik)) &&
                                                                             (model.DuvarResimId == null || p.DuvarResimId == model.DuvarResimId) &&
                                                                             (model.Adi == null || p.Adi.Contains(model.Adi)));

                var totalCount = await query.CountAsync();

                return await query.OrderByDescending(p => p.DuvarResimId)
                                  .Select(p => new DuvarResimAramaSonucVM
                                  {
                                      TotalCount = totalCount,

                                      DuvarResimId = p.DuvarResimId,
                                      Adi = p.Adi,
                                      Aciklama = p.Aciklama,
                                      ResimBase64 = p.KucukResim == null ? "/Uploads/Site/noimg.png" : String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(p.KucukResim, 0, p.KucukResim.Length)),
                                      AktifMi = p.AktifMi
                                  })
                                  .Skip(model.start)
                                  .Take(model.length)
                                  .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<DuvarResim> DuvarResimGetir(int id)
        {
            return await readOnlyRepository.GetByIdAsync<DuvarResim>(id);
        }

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Hediye Kartı Kategori

        #region Admin

        public async Task<HediyeKartKategori> GetHediyeKartKategoriById(int Id)
        {
            return await readOnlyRepository.GetQueryable<HediyeKartKategori>(w => w.HediyeKartKategoriId == Id)
                                     .SingleOrDefaultAsync();
        }

        public async Task<int> HediyeKartKategoriKayit(HediyeKartKategoriVM model)
        {
            try
            {
                var data = new HediyeKartKategori();

                if (model.HediyeKartKategoriId == 0)
                {
                    data = new HediyeKartKategori()
                    {
                        HediyeKartKategoriAdi = model.HediyeKartKategoriAdi,
                        AktifMi = model.AktifMi,
                        Sira = model.Sira,
                        HediyeKartKategoriAttribute = model.HediyeKartKategoriAttribute
                    };
                    repository.Create(data);
                }
                else
                {
                    data = await readOnlyRepository.GetQueryable<HediyeKartKategori>(w => w.HediyeKartKategoriId == model.HediyeKartKategoriId).SingleOrDefaultAsync();
                    data.HediyeKartKategoriAdi = model.HediyeKartKategoriAdi; ;
                    data.AktifMi = model.AktifMi;
                    data.Sira = model.Sira;
                    data.HediyeKartKategoriAttribute = model.HediyeKartKategoriAttribute;
                    repository.Update(data);
                }

                var id = await SaveChanges();
                return data.HediyeKartKategoriId;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<HediyeKartKategoriAramaResultVM>> GetHediyeKartKategoriList(HediyeKartKategoriAramaVM hediyeKartKategoriAramaVM)
        {

            var query = readOnlyRepository.GetQueryable<HediyeKartKategori>(
                                           p => (hediyeKartKategoriAramaVM.HediyeKartKategoriAdi == null || p.HediyeKartKategoriAdi.StartsWith(hediyeKartKategoriAramaVM.HediyeKartKategoriAdi))
                                           && (hediyeKartKategoriAramaVM.HediyeKartKategoriId == null || p.HediyeKartKategoriId == hediyeKartKategoriAramaVM.HediyeKartKategoriId)
                                           && (hediyeKartKategoriAramaVM.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(hediyeKartKategoriAramaVM.AktifMi)));

            var total = query.Count();

            return await query.OrderByDescending(p => p.HediyeKartKategoriId)
                                .Select(p => new HediyeKartKategoriAramaResultVM
                                {
                                    HediyeKartKategoriAdi = p.HediyeKartKategoriAdi,
                                    AktifMi = p.AktifMi,
                                    Sira = p.Sira,
                                    HediyeKartKategoriId = p.HediyeKartKategoriId,
                                    Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                    TotalCount = total
                                }).Skip(hediyeKartKategoriAramaVM.start)
                                .Take(hediyeKartKategoriAramaVM.length)
                                .ToListAsync();

        }

        public async Task<int> DeleteHediyeKartKategori(int id)
        {
            HediyeKartKategori updatedHediyeKartKategori = readOnlyRepository.GetQueryable<HediyeKartKategori>(w => w.HediyeKartKategoriId == id).Single();
            updatedHediyeKartKategori.AktifMi = false;
            repository.Update(updatedHediyeKartKategori);
            return await SaveChanges();

        }

        public async Task<List<HediyeKartKategori>> HediyeKartKategoriListesi()
        {
            return await readOnlyRepository.GetQueryable<HediyeKartKategori>(p => p.AktifMi == true).ToListAsync();
        }
        #endregion

        #endregion

        #region İndirim Kuponu 

        #region Admin
        public async Task<IndirimKuponu> IndirimKuponuGetirById(int Id)
        {
            return  await readOnlyRepository.GetQueryable<IndirimKuponu>(w => w.IndirimKuponId == Id).SingleOrDefaultAsync();
        }

        public async Task<int> IndirimKuponuKaydet(IndirimKuponuKayitVM model)
        {
            try
            {
                var data = new IndirimKuponu();

                if (model.IndirimKuponId == 0)
                {
                    data = new IndirimKuponu()
                    {
                        Aciklama = model.Aciklama,
                        Adi = model.Adi,
                        Link = model.Link,
                        AktifMi = model.AktifMi,
                        Resim = model.Resim,
                        ResimUrl = model.ResimUrl,
                        Sira = model.Sira,
                        YuklenmeTarihi = DateTime.Now,
                        BaslangicTarihi = Convert.ToDateTime(model.BaslangicTarihi),
                        BitisTarihi = Convert.ToDateTime(model.BitisTarihi)
                    };
                    repository.Create(data);
                }
                else
                {
                    data = await readOnlyRepository.GetQueryable<IndirimKuponu>(w => w.IndirimKuponId == model.IndirimKuponId).SingleOrDefaultAsync();
                    data.Aciklama = model.Aciklama;
                    data.Adi = model.Adi;
                    data.Link = model.Link;
                    data.AktifMi = model.AktifMi;
                    data.Sira = model.Sira;
                    data.BaslangicTarihi = Convert.ToDateTime(model.BaslangicTarihi);
                    data.BitisTarihi = Convert.ToDateTime(model.BitisTarihi);
                    if (!string.IsNullOrEmpty(model.ResimUrl))
                        data.ResimUrl = model.ResimUrl;
                    if (model.Resim != null)
                        data.Resim = model.Resim;
                    repository.Update(data);
                }

                var id = await SaveChanges();

                return data.IndirimKuponId;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SayfaDataService", "IndirimKuponuKaydet"));
                throw;
            }
        }       
        public async Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuArama(IndirimKuponuAramaVM indirimKuponuAramaVM)
        {
            var query = readOnlyRepository.GetQueryable<IndirimKuponu>().AsNoTracking();
            
            if(indirimKuponuAramaVM.IndirimKuponuId != null)
            {
                query = query.Where(p => p.IndirimKuponId == indirimKuponuAramaVM.IndirimKuponuId);
            }

            if(indirimKuponuAramaVM.AktifMi != -1)
            {
                query = query.Where(p => p.AktifMi == Convert.ToBoolean(indirimKuponuAramaVM.AktifMi));
            }

            if(indirimKuponuAramaVM.Adi != null)
            {
                query = query.Where(p => p.Adi.Contains(indirimKuponuAramaVM.Adi));
            }
           
            var total = query.Count();

            return await query.OrderByDescending(p => p.IndirimKuponId)
                                .Select(p => new IndirimKuponuAramaResultVM
                                {
                                    Adi = p.Adi,
                                    IndirimKuponId = p.IndirimKuponId,
                                    Sira = p.Sira,
                                    Resim = p.Resim,
                                    Aciklama = p.Aciklama,
                                    AktifMi = p.AktifMi,
                                    Link = p.Link,
                                    ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : "",
                                    YuklenmeTarihi = p.YuklenmeTarihi.ToString("dd.MM.yyyy HH:mm:ss"),
                                    BaslangicTarihi = p.BaslangicTarihi.ToString("dd.MM.yyyy HH:mm:ss"),
                                    BitisTarihi = p.BitisTarihi.ToString("dd.MM.yyyy HH:mm:ss"),
                                    Durum = p.AktifMi,
                                    TotalCount = total
                                }).Skip(indirimKuponuAramaVM.start)
                                .Take(indirimKuponuAramaVM.length)
                                .ToListAsync();
        }

        public async Task<int> IndirimKuponuSil(int id)
        {
            IndirimKuponu updatedIndirimKuponu = readOnlyRepository.GetQueryable<IndirimKuponu>(w => w.IndirimKuponId == id).Single();
            updatedIndirimKuponu.AktifMi = false;
            repository.Update(updatedIndirimKuponu);
            return await SaveChanges();
        }

        #endregion

        #region FrontEnd

        public async Task<int> IndirimKuponSayisiGetir()
        {
            return readOnlyRepository.GetQueryable<IndirimKuponu>(p => p.AktifMi && p.BaslangicTarihi <= DateTime.Now && p.BitisTarihi >= DateTime.Now).Count();
        }
        public async Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuGetir(IndirimKuponuAramaVM indirimKuponuAramaVM)
        {
            var query = readOnlyRepository.GetQueryable<IndirimKuponu>(p => p.AktifMi).AsNoTracking();
                 
            if (indirimKuponuAramaVM.BaslangicTarihi != null)
            {
                query = query.Where(p => p.BaslangicTarihi <= Convert.ToDateTime(indirimKuponuAramaVM.BaslangicTarihi));
            }

            if (indirimKuponuAramaVM.BitisTarihi != null)
            {
                query = query.Where(p => p.BitisTarihi >= Convert.ToDateTime(indirimKuponuAramaVM.BitisTarihi));
            }


            var total = query.Count();

            return await query.OrderBy(p => p.Sira)
                                .Select(p => new IndirimKuponuAramaResultVM
                                {
                                    Adi = p.Adi,
                                    IndirimKuponId = p.IndirimKuponId,
                                    Sira = p.Sira,
                                    Resim = p.Resim,
                                    Aciklama = p.Aciklama,
                                    AktifMi = p.AktifMi,
                                    Link = p.Link,
                                    ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : "",
                                    YuklenmeTarihi = p.YuklenmeTarihi.ToString("dd.MM.yyyy HH:mm:ss"),
                                    BaslangicTarihi = p.BaslangicTarihi.ToString("dd.MM.yyyy HH:mm:ss"),
                                    BitisTarihi = p.BitisTarihi.ToString("dd.MM.yyyy HH:mm:ss"),
                                    Durum = p.AktifMi,
                                    TotalCount = total
                                }).ToListAsync();
        }

        #endregion

        #endregion
    }
}
