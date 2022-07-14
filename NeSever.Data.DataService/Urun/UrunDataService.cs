using AutoMapper;
using HappyFit.Data.Context.UnitOfWork;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Models.Admin.AramaSonucVM;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Urun;
using NeSever.Common.Utils.DistributedCache;
using NeSever.Data.DataService._RawQueries;
using NeSever.Data.Entities;
using NeSever.Data.Entities.RawEntities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using X.PagedList;

//Important note : Being a running and alive project, some codes were removed by me. If you want some detail, please just inform me

namespace NeSever.Data.DataService
{
    public interface IUrunDataService
    {
        #region Marka

        #region Admin

        #endregion

        #region FrontEnd     
        Task<List<MarkaIcerikVM>> GetMarkaIcerikList();
        Task<MarkaAramaSayfaSonucVM> MarkaListGetir(string m);
        Task<string> MarkaAdindanIdGetir(string markaAdi);
        #endregion

        #endregion

        #region Kategori

        #region Admin

        Task<int> KategoriKayit(KategoriVM model);
        Task<Kategori> GetKategoriById(int Id);
        Task<List<KategoriAramaResultVM>> GetKategoriList(KategoriAramaVM kategoriAramaVM);
        Task<int> DeleteKategori(int id);
        Task<List<KategoriVM>> GetKategoriList();

        #endregion

        #region FrontEnd
        Task<List<KategoriIcerikVM>> GetKategoriIcerikList(bool anasayfadaGoster = true);
        #endregion

        #endregion

        #region KategoriBanner        

        #region FrontEnd

        #endregion

        #endregion

        #region Urun

        #region Admin
        Task<int> UrunKayit(UrunVM model);
        Task<Urun> GetUrunById(int Id);
        Task<List<UrunAramaResultVM>> GetUrunList(UrunAramaVM urunAramaVM);
        Task<int> DeleteUrun(int id);

        Task<List<UrunResimVM>> GetUrunResimById(int Id);
        Task<List<UrunKategoriVM>> GetUrunKategoriById(int Id);
        Task<int> UrunResimKaydet(UrunResimVM urunResimVM);
        Task<List<GoruntulenenUrunAramaSonucVM>> GoruntulenenUrunRaporuGetir(GoruntulenenUrunAramaVM model);
        Task<List<YonlendirilenUrunAramaSonucVM>> YonlendirilenUrunRaporuGetir(YonlendirilenUrunAramaVM model);
        #endregion

        #region FrontEnd
        Task<List<UrunIcerikVM>> GetTrendKadinUrunIcerikList();
        Task<List<UrunIcerikVM>> GetTrendErkekUrunIcerikList();
        Task<IPagedList<UrunIcerikVM>> GetUrunIcerikList(UrunIcerikAramaVM urunIcerikAramaVM);
        Task<UrunDetayIcerikVM> GetUrunDetayIcerikById(int id);
        Task YonlendirmeSayisiArttir(UrunYonlendirmeSayisi urun);
        Task KullaniciFiyatGorListArttir(KullaniciFiyatGorVM kullanici);
        int HediyeSepetindekiUrunAdeti(int urunId);
        Task<SurprizHediyeSonucVM> SurprizHediyeKontrol(SurprizHediyeVM surprizHediye);
        #endregion

        #endregion

        #region Sürpriz Ürün
        Task<List<SurprizUrunGetirVM>> SurprizUrunGetir(SurprizUrunKayitVM data);
        Task<SurprizUrunKayitVM> SurprizUrunGetirById(int id);
        Task<int> SurprizUrunKayit(SurprizUrunKayitVM model);
        Task<List<SurprizUrunAramaSonucVM>> SurprizUrunArama(SurprizUrunAramaVM model);
        Task<int> SurprizUrunSil(int id);

        #endregion
    }

    public class UrunDataService : BaseDataService, IUrunDataService
    {
        private IUnitOfWork unitOfWork;
        private IMemoryCache memoryCache;
        private MemoryCacheEntryOptions memoryCacheEntryOptions;
        private IDistributedCache distributedCache;
        private DistributedCacheEntryOptions distributedCacheEntryOptions;
        private readonly IMapper mapper;
        private readonly IRepository repository;
        private readonly IReadOnlyRepository readOnlyRepository;
        private readonly ILogger<UrunDataService> logger;
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

        public UrunDataService(IUnitOfWork unitOfWork,
                               IMemoryCache memoryCache,
                               IDistributedCache distributedCache,
                               IMapper mapper,
                               IRepository repository,
                               IReadOnlyRepository readOnlyRepository,
                               ILogger<UrunDataService> logger)
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

        #region Marka

        #region Admin

        #endregion

        #region FrontEnd

        public async Task<List<MarkaIcerikVM>> GetMarkaIcerikList()
        {
            List<MarkaIcerikVM> result = null;

            if (cacheIsActive)
            {
                switch (cacheType)
                {
                    default:
                    case "Memory":
                        memoryCache.TryGetValue<List<MarkaIcerikVM>>("GetMarkaIcerikList", out result);
                        break;
                    case "Redis":
                        result = await distributedCache.GetAsync<List<MarkaIcerikVM>>("GetMarkaIcerikList");
                        break;
                }
            }

            if (result == null || !cacheIsActive)
            {
                try
                {
                    var query = readOnlyRepository.GetQueryable<Marka>(p => p.AktifMi &&
                                                                            p.AnasayfadaGosterilsin);

                    result = await query.OrderBy(p => p.Sira)
                                      .Select(p => new MarkaIcerikVM
                                      {
                                          MarkaId = p.MarkaId,
                                          MarkaAdi = p.MarkaAdi,
                                          Aciklama = p.Aciklama,
                                          ResimBase64 = p.Resim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Resim)) : "/Uploads/Site/blog_empty_image_500_500.png"
                                      })
                                      .ToListAsync();

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<MarkaIcerikVM>>("GetMarkaIcerikList", result, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<MarkaIcerikVM>>("GetMarkaIcerikList", result, distributedCacheEntryOptions);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "UrunDataService", "GetMarkaIcerikList"));
                }
            }

            return result ?? new List<MarkaIcerikVM>();
        }

        public async Task<MarkaAramaSayfaSonucVM> MarkaListGetir(string m)
        {
            MarkaAramaSayfaSonucVM result = new MarkaAramaSayfaSonucVM()
            {
                BenzersizMarkaIsimleri = new List<string>(),
                HarfListesi = new List<string>(),
                MarkaListesi = new List<MarkaIcerikVM>()
            };
            List<MarkaIcerikVM> data = null;

            if (cacheIsActive)
            {
                switch (cacheType)
                {
                    default:
                    case "Memory":
                        memoryCache.TryGetValue<List<MarkaIcerikVM>>("MarkaListGetir", out data);
                        break;
                    case "Redis":
                        data = await distributedCache.GetAsync<List<MarkaIcerikVM>>("MarkaListGetir");
                        break;
                }

                if (data != null)
                {
                    if (string.IsNullOrEmpty(m))
                    {
                        result.MarkaListesi = data;
                        result.BenzersizMarkaIsimleri = data.Select(p => p.MarkaAdi.ToUpper()).Distinct().ToList();
                    }
                    else
                    {
                        result.MarkaListesi = data.Where(p => p.MarkaAdi.ToLower(new CultureInfo("tr-TR", false)).StartsWith(m.ToLower(new CultureInfo("tr-TR", false)))).ToList();
                        result.BenzersizMarkaIsimleri = result.MarkaListesi.Select(p => p.MarkaAdi.ToUpper()).Distinct().ToList();
                    }
                }
            }

            if (data == null || !cacheIsActive)
            {
                try
                {
                    var query = readOnlyRepository.GetQueryable<Marka>(p => p.AktifMi);

                    var markalar = await query.OrderBy(p => p.MarkaAdi)
                                              .Select(p => new MarkaIcerikVM
                                              {
                                                  MarkaId = p.MarkaId,
                                                  MarkaAdi = p.MarkaAdi,
                                                  //Aciklama = p.Aciklama,
                                                  //ResimBase64 = p.Resim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Resim)) : "/Uploads/Site/blog_empty_image_500_500.png"
                                              })
                                             .ToListAsync();

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<MarkaIcerikVM>>("MarkaListGetir", markalar, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<MarkaIcerikVM>>("MarkaListGetir", markalar, distributedCacheEntryOptions);
                                break;
                        }
                    }

                    if (string.IsNullOrEmpty(m))
                        result.MarkaListesi = markalar;
                    else
                        result.MarkaListesi = markalar.Where(p => p.MarkaAdi.ToLower(new CultureInfo("tr-TR", false)).StartsWith(m.ToLower(new CultureInfo("tr-TR", false)))).ToList();

                    result.BenzersizMarkaIsimleri = result.MarkaListesi.Select(p => p.MarkaAdi.ToUpper()).Distinct().ToList();
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "UrunDataService", "MarkaListGetir"));
                }
            }

            return result ?? new MarkaAramaSayfaSonucVM();
        }

        public async Task<string> MarkaAdindanIdGetir(string markaAdi)
        {
            try
            {
                string result = "";

                if (!string.IsNullOrEmpty(markaAdi))
                {
                    var query = readOnlyRepository.GetQueryable<Marka>(p => p.AktifMi);

                    var marka = await query.OrderBy(p => p.MarkaAdi)
                                           .Select(p => new
                                           {
                                               MarkaId = p.MarkaId,
                                               MarkaAdi = p.MarkaAdi,
                                           }).Where(p => p.MarkaAdi.ToUpper() == markaAdi.ToUpper()).ToListAsync();

                    foreach (var item in marka)
                    {
                        result += (item.MarkaId + ",");
                    }

                    result = result.TrimEnd(',');
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #endregion

        #region Kategori
 
        #region FrontEnd

        public async Task<List<KategoriIcerikVM>> GetKategoriIcerikList(bool anasayfadaGoster = true)
        {
            List<KategoriIcerikVM> result = null;

            if (cacheIsActive)
            {
                switch (cacheType)
                {
                    default:
                    case "Memory":
                        memoryCache.TryGetValue<List<KategoriIcerikVM>>("GetKategoriIcerikList", out result);
                        break;
                    case "Redis":
                        result = await distributedCache.GetAsync<List<KategoriIcerikVM>>("GetKategoriIcerikList");
                        break;
                }

                if (result != null)
                {
                    if (anasayfadaGoster)
                        result = result.Where(p => p.AnasayfadaGoster).ToList();
                }
            }

            if (result == null || !cacheIsActive)
            {
                try
                {
                    var query = readOnlyRepository.GetQueryable<Kategori>(p => p.AktifMi &&
                                                                               !p.SabitKategori)
                                                  .AsNoTracking();

                    var data = await query.OrderBy(p => p.Sira)
                                          .Select(p => new
                                          {
                                              p.UstKategoriId,
                                              p.KategoriId,
                                              p.Parametre,
                                              p.KategoriAdi,
                                              p.Aciklama,
                                              p.Sira,
                                              p.AnasayfadaGoster
                                          })
                                          .ToListAsync();

                    result = data.Select(p => new KategoriIcerikVM
                    {
                        UstKategoriId = p.UstKategoriId,
                        KategoriId = p.KategoriId,
                        Parametre = p.Parametre,
                        KategoriAdi = p.KategoriAdi,
                        Aciklama = p.Aciklama,
                        Sira = p.Sira,
                        AnasayfadaGoster = p.AnasayfadaGoster
                    }).ToList();

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<KategoriIcerikVM>>("GetKategoriIcerikList", result, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<KategoriIcerikVM>>("GetKategoriIcerikList", result, distributedCacheEntryOptions);
                                break;
                        }
                    }

                    if (anasayfadaGoster)
                        result = result.Where(p => p.AnasayfadaGoster).ToList();
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "UrunDataService", "GetKategoriIcerikList"));
                }
            }

            return result ?? new List<KategoriIcerikVM>();
        }

        #endregion

        #endregion

        #region KategoriBanner

        #region Admin

        public async Task<KategoriBanner> KategoriBannerGetirById(int Id)
        {
            return await readOnlyRepository.GetQueryable<KategoriBanner>(w => w.KategoriBannerId == Id)
                                     .SingleOrDefaultAsync();
        }

        public async Task<int> KategoriBannerKayit(KategoriBannerVM model)
        {
            try
            {
                var data = new KategoriBanner();

                if (model.KategoriBannerId == 0)
                {
                    data.UstKategoriId = model.UstKategoriId;
                    data.UstKategoriBannerId = model.UstKategoriBannerId;
                    data.Adi = model.Adi;
                    data.Aciklama = model.Aciklama;
                    data.Parametre = model.Parametre;
                    data.Sira = model.Sira;
                    data.AnasayfadaGoster = model.AnasayfadaGoster;
                    data.Resim = model.Resim;
                    data.ResimUrl = model.ResimUrl;
                    data.AktifMi = model.AktifMi;
                    data.AnasayfadaGoster = model.AnasayfadaGoster;
                    data.OlusturmaTarihi = DateTime.Now;
                    data.GuncellemeTarihi = DateTime.Now;
                    repository.Create(data);
                }
                else
                {
                    data = await readOnlyRepository.GetQueryable<KategoriBanner>(w => w.KategoriBannerId == model.KategoriBannerId).SingleOrDefaultAsync();
                    data.UstKategoriId = model.UstKategoriId;
                    data.UstKategoriBannerId = model.UstKategoriBannerId;
                    data.Adi = model.Adi;
                    data.Aciklama = model.Aciklama;
                    data.Parametre = model.Parametre;
                    data.Sira = model.Sira;
                    data.AnasayfadaGoster = model.AnasayfadaGoster;
                    if (model.Resim != null && model.Resim.Length > 0)
                        data.Resim = model.Resim;
                    if (!string.IsNullOrEmpty(model.ResimUrl))
                        data.ResimUrl = model.ResimUrl;
                    data.AktifMi = model.AktifMi;
                    data.AnasayfadaGoster = model.AnasayfadaGoster;
                    data.GuncellemeTarihi = DateTime.Now;
                    repository.Update(data);
                }

                var id = await SaveChanges();

                return data.KategoriBannerId;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<KategoriBannerAramaResultVM>> KategoriBannerArama(KategoriBannerAramaVM kategoriAramaVM)
        {
            var query = readOnlyRepository.GetQueryable<KategoriBanner>(
                                           p => (kategoriAramaVM.Adi == null || p.Adi.StartsWith(kategoriAramaVM.Adi))
                                           && (kategoriAramaVM.UstKategoriId == null || p.UstKategoriId == kategoriAramaVM.UstKategoriId)
                                           && (kategoriAramaVM.KategoriBannerId == null || p.KategoriBannerId == kategoriAramaVM.KategoriBannerId)
                                           && (kategoriAramaVM.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(kategoriAramaVM.AktifMi)));

            var total = query.Count();

            return await query.Include("UstKategori")
                              .Include("UstKategoriBanner")
                              .OrderByDescending(p => p.KategoriBannerId)
                              .Select(p => new KategoriBannerAramaResultVM
                              {
                                  KategoriBannerId = p.KategoriBannerId,
                                  Adi = p.Adi,
                                  UstKategoriAdi = p.UstKategori == null ? "" : p.UstKategori.KategoriAdi,
                                  UstKategoriBannerAdi = p.UstKategoriBanner == null ? "" : p.UstKategoriBanner.Adi,
                                  AnasayfadaGoster = p.AnasayfadaGoster,
                                  AnasayfadaGosterDurum = p.AnasayfadaGoster == true ? "Evet" : "Hayır",
                                  Parametre = p.Parametre,
                                  Sira = p.Sira,
                                  ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : null,
                                  ResimUrl = p.ResimUrl,
                                  TotalCount = total
                              })
                              .Skip(kategoriAramaVM.start)
                              .Take(kategoriAramaVM.length)
                              .ToListAsync();

        }

        public async Task<int> KategoriBannerSil(int id)
        {
            KategoriBanner updatedKategori = readOnlyRepository.GetQueryable<KategoriBanner>(w => w.KategoriBannerId == id).Single();
            updatedKategori.AktifMi = false;
            repository.Update(updatedKategori);
            return await SaveChanges();
        }

        public async Task<List<KategoriBannerVM>> GetKategoriBannerList()
        {
            return await readOnlyRepository.GetQueryable<KategoriBanner>()
                                             .Select(p => new KategoriBannerVM
                                             {
                                                 KategoriBannerId = p.KategoriBannerId,
                                                 Adi = p.Adi,
                                             }).ToListAsync();
        }

        #endregion

        #region FrontEnd


        #endregion

        #endregion

        #region Urun

        #region Admin
        public async Task<int> UrunKayit(UrunVM model)
        {
            try
            {
                var data = new Urun();

                if (model.UrunId == 0)
                {
                    if (model.UrunKategoriListesi.Count > 0)
                    {
                        foreach (var item in model.UrunKategoriListesi)
                        {
                            UrunKategori urunKategori = new UrunKategori();
                            urunKategori.KategoriId = item.KategoriId;
                            urunKategori.UrunId = model.UrunId;
                            urunKategori.AktifMi = true;
                            urunKategori.Sira = 1;

                            data.UrunKategori.Add(urunKategori);
                        }
                    }

                    data.UrunAdi = model.UrunAdi;
                    data.Aciklama = model.Aciklama;
                    data.MetaTitle = model.MetaTitle;
                    data.MetaKeywords = model.MetaKeywords;
                    data.MetaDescription = model.MetaDescription;
                    data.MarkaId = model.MarkaId;
                    data.OriginalId = model.OriginalId;
                    data.Sira = model.Sira.Value;
                    data.Sku = model.Sku;
                    data.KisaAciklama = model.KisaAciklama;
                    data.AktifMi = model.AktifMi;
                    data.AdresUrl = model.AdresUrl;
                    data.AnasayfadaGoster = model.AnasayfadaGoster;
                    data.GoruntulenmeSayisi = model.GoruntulenmeSayisi;
                    data.Etiketler = model.Etiketler;
                    data.Fiyat = model.Fiyat;
                    data.WebSiteId = model.WebSiteId;
                    data.KayitTarih = DateTime.Now;
                    data.SatilabilirUrun = model.SatilabilirUrun;

                    List<UrunResim> urunResimLst = new List<UrunResim>();
                    if (model.UrunResimListesi != null)
                    {
                        foreach (UrunResimVM item in model.UrunResimListesi)
                        {
                            UrunResim urunResim = new UrunResim()
                            {
                                UrunId = model.UrunId,
                                Resim = item.Resim,
                                ResimUrl = item.ResimUrl,
                                OrjinalResimUrl = item.OrjinalResimUrl,
                                Sira = item.Sira,
                                KayitTarih = DateTime.Now,
                                AktifMi = item.AktifMi
                            };
                            urunResimLst.Add(urunResim);
                        }
                    }
                    data.UrunResim = urunResimLst;

                    repository.Create(data);
                }
                else
                {


                    data = await readOnlyRepository.GetQueryable<Urun>(w => w.UrunId == model.UrunId).SingleOrDefaultAsync();
                    var oncekiKategoriler = await readOnlyRepository.GetQueryable<UrunKategori>(w => w.UrunId == model.UrunId).ToListAsync();
                    foreach (UrunKategori item in oncekiKategoriler)
                    {
                        item.AktifMi = false;
                        repository.Update(item);
                        await SaveChanges();
                    }
                    data.UrunAdi = model.UrunAdi;
                    data.Aciklama = model.Aciklama;
                    data.MetaTitle = model.MetaTitle;
                    data.MetaKeywords = model.MetaKeywords;
                    data.MetaDescription = model.MetaDescription;
                    data.MarkaId = model.MarkaId;
                    data.OriginalId = model.OriginalId;
                    if (model.Sira.HasValue)
                        data.Sira = model.Sira.Value;
                    data.Sku = model.Sku;
                    data.KisaAciklama = model.KisaAciklama;
                    data.AktifMi = model.AktifMi;
                    data.AdresUrl = model.AdresUrl;
                    data.AnasayfadaGoster = model.AnasayfadaGoster;
                    data.Etiketler = model.Etiketler;
                    data.Fiyat = model.Fiyat;
                    data.GuncellemeTarih = DateTime.Now;
                    data.UrunId = model.UrunId;
                    data.SatilabilirUrun = model.SatilabilirUrun;

                    if (model.UrunKategoriListesi.Count > 0)
                    {
                        foreach (var item in model.UrunKategoriListesi)
                        {
                            UrunKategori urunKategori = new UrunKategori();
                            urunKategori.KategoriId = item.KategoriId;
                            urunKategori.UrunId = model.UrunId;
                            urunKategori.AktifMi = true;
                            urunKategori.Sira = 1;

                            data.UrunKategori.Add(urunKategori);
                        }
                    }
                    repository.Update(data);

                    if (model.UrunResimListesi.Count() > 0)
                    {
                        //Urun Resim Update
                        var oncekiResimler = readOnlyRepository.GetQueryable<UrunResim>(w => w.UrunId == model.UrunId).ToList();
                        foreach (var item in oncekiResimler)
                        {
                            repository.Delete(item);
                            SaveChanges();
                        }
                        List<UrunResim> urunResimLst = new List<UrunResim>();

                        foreach (UrunResimVM item in model.UrunResimListesi)
                        {
                            UrunResim urunResim = new UrunResim()
                            {
                                UrunId = model.UrunId,
                                Resim = item.Resim,
                                ResimUrl = item.ResimUrl,
                                OrjinalResimUrl = item.OrjinalResimUrl,
                                Sira = item.Sira,
                                KayitTarih = DateTime.Now,
                                AktifMi = item.AktifMi
                            };
                            urunResimLst.Add(urunResim);
                        }

                        foreach (var item in urunResimLst)
                        {
                            repository.Create(item);
                        }
                    }
                    else
                    {
                        var oncekiResimler = readOnlyRepository.GetQueryable<UrunResim>(w => w.UrunId == model.UrunId).ToList();
                        foreach (var item in oncekiResimler)
                        {
                            repository.Delete(item);
                            SaveChanges();
                        }
                    }
                }

                var id = await SaveChanges();

                return data.UrunId;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public async Task<Urun> GetUrunById(int Id)
        {
            return await readOnlyRepository.GetQueryable<Urun>(w => w.UrunId == Id)
                                     .SingleOrDefaultAsync();

        }

        public async Task<List<UrunAramaResultVM>> GetUrunList(UrunAramaVM urunAramaVM)
        {
            var kategoriIds = new List<int>();
            if (!string.IsNullOrEmpty(urunAramaVM.secilenKategoriListesi))
            { kategoriIds = urunAramaVM.secilenKategoriListesi.Split(',').Select(Int32.Parse).ToList(); }
            var query = readOnlyRepository.GetQueryable<Urun>().Include("UrunKategori").AsNoTracking();

            if (urunAramaVM.AktifMi != -1)
            {
                query = query.Where(p => p.AktifMi == Convert.ToBoolean(urunAramaVM.AktifMi));
            }

            if (urunAramaVM.UrunAdi != null)
            {
                query = query.Where(p => p.UrunAdi.Contains(urunAramaVM.UrunAdi.Trim()));
            }

            if (urunAramaVM.UrunId != null)
            {
                query = query.Where(p => p.UrunId == urunAramaVM.UrunId);
            }

            if (urunAramaVM.Sku != null)
            {
                query = query.Where(p => p.Sku.Contains(urunAramaVM.Sku.Trim()));
            }

            if (urunAramaVM.Aciklama != null)
            {
                query = query.Where(p => p.Aciklama.Contains(urunAramaVM.Aciklama.Trim()));
            }

            if (urunAramaVM.AdresUrl != null)
            {
                query = query.Where(p => p.AdresUrl.Contains(urunAramaVM.AdresUrl.Trim()));
            }

            if (urunAramaVM.secilenKategoriListesi != null)
            {
                query = query.Where(p => (p.UrunKategori.Any(o => kategoriIds.Contains(o.KategoriId))));
            }

            if (urunAramaVM.SatilabilirUrunMu != -1)
            {
                query = query.Where(p => p.SatilabilirUrun == Convert.ToBoolean(urunAramaVM.SatilabilirUrunMu));
            }

            var total = query.Count();

            var result = await query.Include("UrunResim").Include("UrunKategori").OrderByDescending(p => p.UrunId)
                               .Select(p => new UrunAramaResultVM
                               {
                                   UrunId = p.UrunId,
                                   UrunAdi = p.UrunAdi,
                                   Aciklama = p.Aciklama,
                                   AnasayfadaGoster = p.AnasayfadaGoster,
                                   AdresUrl = p.AdresUrl,
                                   Sira = p.Sira,
                                   ResimUrl = p.UrunResim.Any(x => x.AktifMi) ? (p.UrunResim.First(x => x.AktifMi).Resim != null ? ("data:image/png;base64," + Convert.ToBase64String(p.UrunResim.First(x => x.AktifMi).Resim)) : p.UrunResim.First(x => x.AktifMi).OrjinalResimUrl) : "../../Themes/Admin/design/noimage.png",
                                   KisaAciklama = p.KisaAciklama,
                                   Sku = p.Sku,
                                   AnasayfadaGosterDurum = p.AnasayfadaGoster == true ? "Evet" : "Hayır",
                                   Durum = p.AktifMi == true ? "Evet" : "Hayır",
                                   TotalCount = total
                               }).Skip(urunAramaVM.start)
                                .Take(urunAramaVM.length)
                                .ToListAsync();
            result.ForEach(p => p.KategoriAdi = KategoriGetir(p.UrunId, urunAramaVM.secilenKategoriListesi));

            return result;


        }
        public string KategoriGetir(int urunId, string secilenKategoriListesi)
        {
            string kategoriIsimleri = string.Empty;
            var urunKategoriIsimleriLst = readOnlyRepository.GetQueryable<UrunKategori>(p => p.UrunId == urunId && p.AktifMi == true).Include("Kategori")
                        .Select(
                            p => p.Kategori.KategoriAdi
                        ).ToList();
            ;
            for (int i = 0; i < urunKategoriIsimleriLst.Count; i++)
            {
                if (i != (urunKategoriIsimleriLst.Count - 1))
                    kategoriIsimleri += urunKategoriIsimleriLst[i] + ",";
                else
                    kategoriIsimleri += urunKategoriIsimleriLst[i];
            }
            return kategoriIsimleri;
        }
        public async Task<int> DeleteUrun(int id)
        {
            Urun updatedUrun = readOnlyRepository.GetQueryable<Urun>(w => w.UrunId == id).Single();
            updatedUrun.AktifMi = false;
            repository.Update(updatedUrun);
            return await SaveChanges();

        }

        public async Task<List<UrunResimVM>> GetUrunResimById(int Id)
        {
            return await readOnlyRepository.GetQueryable<UrunResim>(w => w.UrunId == Id && w.AktifMi)
                                     .Select(p => new UrunResimVM
                                     {
                                         UrunResimId = p.UrunResimId,
                                         UrunId = p.UrunId,
                                         OrjinalResimUrl = p.OrjinalResimUrl,
                                         Resim = p.Resim,
                                         AktifMi = p.AktifMi,
                                         ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : null,
                                         ResimUrl = p.ResimUrl,
                                         Sira = p.Sira
                                     })
                                     .ToListAsync();

        }
        public async Task<List<UrunKategoriVM>> GetUrunKategoriById(int Id)
        {
            return await readOnlyRepository.GetQueryable<UrunKategori>(w => w.UrunId == Id && w.AktifMi == true).Include("Kategori")
                                     .Select(p => new UrunKategoriVM
                                     {
                                         KategoriId = p.KategoriId,
                                         KategoriAdi = p.Kategori.KategoriAdi,
                                         AktifMi = p.AktifMi,
                                         UrunId = p.UrunId,
                                         UrunKategoriId = p.UrunKategoriId,
                                         Sira = p.Sira
                                     })
                                     .ToListAsync();

        }
        public async Task<int> UrunResimKaydet(UrunResimVM urunResimVM)
        {
            try
            {

                if(urunResimVM.Resim == null ||urunResimVM.ResimUrl == null)
                {
                    return urunResimVM.UrunId;
                }

                var urunResim = mapper.Map<UrunResimVM, UrunResim>(urunResimVM);
                repository.Create(urunResim);
                await SaveChanges();
                return urunResimVM.UrunId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<List<GoruntulenenUrunAramaSonucVM>> GoruntulenenUrunRaporuGetir(GoruntulenenUrunAramaVM model)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<Urun>(p => p.MarkaId == -2).Select(p => new { p.UrunAdi, p.GoruntulenmeSayisi, p.KayitTarih, p.AktifMi }).AsNoTracking();

                if (model.MarkaAdi == "hepsi")
                {
                    query = readOnlyRepository.GetQueryable<Urun>().Select(p => new { p.UrunAdi, p.GoruntulenmeSayisi, p.KayitTarih, p.AktifMi }).AsNoTracking();
                }
                else
                {
                    var markaId = readOnlyRepository.GetQueryable<Marka>(p => p.MarkaAdi.ToUpper() == model.MarkaAdi).Select(p => new { p.MarkaId }).AsNoTracking().ToList();

                    foreach (var id in markaId)
                    {
                        query = query.Concat(readOnlyRepository.GetQueryable<Urun>(p => p.MarkaId == id.MarkaId).Select(p => new { p.UrunAdi, p.GoruntulenmeSayisi, p.KayitTarih, p.AktifMi }).AsNoTracking());
                    }
                }


                if (model.Aktiflik != -1)
                {
                    query = query.Where(x => x.AktifMi == Convert.ToBoolean(model.Aktiflik));
                }

                if (model.BaslangicTarihi != null)
                {
                    query = query.Where(x => (x.KayitTarih.Date >= Convert.ToDateTime(model.BaslangicTarihi)));
                }

                if (model.BitisTarihi != null)
                {
                    query = query.Where(x => (x.KayitTarih.Date <= Convert.ToDateTime(model.BitisTarihi)));
                }


                var total = await query.Select(p => p.GoruntulenmeSayisi).SumAsync();

                var result = query.OrderByDescending(p => p.GoruntulenmeSayisi)
                                  .Select(p => new GoruntulenenUrunAramaSonucVM
                                  {
                                      ToplamGoruntulenme = total,

                                      UrunAdi = (p.UrunAdi.Length > 32) ? p.UrunAdi.Substring(0, 32) : p.UrunAdi,
                                      AktifMi = p.AktifMi,
                                      GoruntulenmeSayisi = p.GoruntulenmeSayisi,
                                  }).Take(5).ToListAsync();

                return await result;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UrunDataService", "GoruntulenenUrunRaporuGetir", ex));
                throw;
            }
        }

        public async Task<List<YonlendirilenUrunAramaSonucVM>> YonlendirilenUrunRaporuGetir(YonlendirilenUrunAramaVM model)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<Urun>(p => p.MarkaId == -2).Select(p => new { p.UrunAdi, p.YonlendirmeSayisi, p.KayitTarih, p.AktifMi }).AsNoTracking();

                if (model.MarkaAdi == "hepsi")
                {
                    query = readOnlyRepository.GetQueryable<Urun>().Select(p => new { p.UrunAdi, p.YonlendirmeSayisi, p.KayitTarih, p.AktifMi }).AsNoTracking();
                }
                else
                {
                    var markaId = readOnlyRepository.GetQueryable<Marka>(p => p.MarkaAdi.ToUpper() == model.MarkaAdi).Select(p => new { p.MarkaId }).AsNoTracking().ToList();

                    foreach (var id in markaId)
                    {
                        query = query.Concat(readOnlyRepository.GetQueryable<Urun>(p => p.MarkaId == id.MarkaId).Select(p => new { p.UrunAdi, p.YonlendirmeSayisi, p.KayitTarih, p.AktifMi }).AsNoTracking());
                    }
                }


                if (model.Aktiflik != -1)
                {
                    query = query.Where(x => x.AktifMi == Convert.ToBoolean(model.Aktiflik));
                }

                if (model.BaslangicTarihi != null)
                {
                    query = query.Where(x => (x.KayitTarih.Date >= Convert.ToDateTime(model.BaslangicTarihi)));
                }

                if (model.BitisTarihi != null)
                {
                    query = query.Where(x => (x.KayitTarih.Date <= Convert.ToDateTime(model.BitisTarihi)));
                }


                var total = await query.Select(p => p.YonlendirmeSayisi).SumAsync();

                var result = query.OrderByDescending(p => p.YonlendirmeSayisi)
                                  .Select(p => new YonlendirilenUrunAramaSonucVM
                                  {
                                      ToplamYonlendirme = total,

                                      UrunAdi = (p.UrunAdi.Length > 30) ? p.UrunAdi.Substring(0, 30) : p.UrunAdi,
                                      AktifMi = p.AktifMi,
                                      YonlendirmeSayisi = p.YonlendirmeSayisi,
                                  }).Take(5).ToListAsync();

                return await result;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UrunDataService", "YonlendirilenUrunRaporuGetir", ex));
                throw;
            }
        }
        #endregion

        #region FrontEnd

        public async Task<List<UrunIcerikVM>> GetTrendKadinUrunIcerikList()
        {
            List<UrunIcerikVM> result = null;

            if (cacheIsActive)
            {
                switch (cacheType)
                {
                    default:
                    case "Memory":
                        memoryCache.TryGetValue<List<UrunIcerikVM>>("GetTrendKadinUrunIcerikList", out result);
                        break;
                    case "Redis":
                        result = await distributedCache.GetAsync<List<UrunIcerikVM>>("GetTrendKadinUrunIcerikList");
                        break;
                }
            }

            if (result == null || !cacheIsActive)
            {
                try
                {
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@KategoriId", -3));

                    var trendData = await readOnlyRepository.SelectFromQueryAsync<UrunRaw>(UrunRawQueries.TrendHediyeGetir(fileServerIsActive), parameters.ToArray());
                    result = mapper.Map<List<UrunRaw>, List<UrunIcerikVM>>(trendData);

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<UrunIcerikVM>>("GetTrendKadinUrunIcerikList", result, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<UrunIcerikVM>>("GetTrendKadinUrunIcerikList", result, distributedCacheEntryOptions);
                                break;
                        }
                    }

                    foreach (var item in result)
                    {
                        item.HediyeSepetindekiUrunAdeti = HediyeSepetindekiUrunAdeti(item.UrunId);
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "UrunDataService", "GetTrendKadinUrunIcerikList"));
                }
            }

            return result ?? new List<UrunIcerikVM>();
        }

        public async Task<List<UrunIcerikVM>> GetTrendErkekUrunIcerikList()
        {
            List<UrunIcerikVM> result = null;

            if (cacheIsActive)
            {
                switch (cacheType)
                {
                    default:
                    case "Memory":
                        memoryCache.TryGetValue<List<UrunIcerikVM>>("GetTrendErkekUrunIcerikList", out result);
                        break;
                    case "Redis":
                        result = await distributedCache.GetAsync<List<UrunIcerikVM>>("GetTrendErkekUrunIcerikList");
                        break;
                }
            }

            if (result == null || !cacheIsActive)
            {
                try
                {
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@KategoriId", -2));

                    var trendData = await readOnlyRepository.SelectFromQueryAsync<UrunRaw>(UrunRawQueries.TrendHediyeGetir(fileServerIsActive), parameters.ToArray());
                    result = mapper.Map<List<UrunRaw>, List<UrunIcerikVM>>(trendData);

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<UrunIcerikVM>>("GetTrendErkekUrunIcerikList", result, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<UrunIcerikVM>>("GetTrendErkekUrunIcerikList", result, distributedCacheEntryOptions);
                                break;
                        }
                    }

                    foreach (var item in result)
                    {
                        item.HediyeSepetindekiUrunAdeti = HediyeSepetindekiUrunAdeti(item.UrunId);
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "UrunDataService", "GetTrendErkekUrunIcerikList"));
                }
            }

            return result ?? new List<UrunIcerikVM>();
        }

        public async Task<IPagedList<UrunIcerikVM>> GetUrunIcerikList(UrunIcerikAramaVM urunIcerikAramaVM)
        {
            try
            {
                int start = urunIcerikAramaVM.start <= 0 ? 0 : urunIcerikAramaVM.start - 1;
                int length = urunIcerikAramaVM.length <= 0 ? 1 : urunIcerikAramaVM.length;

                List<int> kategoriListe = new List<int>();
                if (!string.IsNullOrEmpty(urunIcerikAramaVM.AramaKategori))
                {
                    var kategoriParametre = urunIcerikAramaVM.AramaKategori.Split(',').ToList();
                    kategoriParametre.ForEach(p =>
                    {
                        int kategori = 0;
                        if (int.TryParse(p, out kategori))
                            kategoriListe.Add(kategori);
                    });
                }
                string kategoriId = string.Join(',', kategoriListe);

                List<int> markaListe = new List<int>();
                if (!string.IsNullOrEmpty(urunIcerikAramaVM.AramaMarka))
                {
                    var markaParametre = urunIcerikAramaVM.AramaMarka.Split(',').ToList();
                    markaParametre.ForEach(p =>
                    {
                        int marka = 0;
                        if (int.TryParse(p, out marka))
                            markaListe.Add(marka);
                    });
                }
                string markaId = string.Join(',', markaListe);

                List<int> webSiteListe = new List<int>();
                if (!string.IsNullOrEmpty(urunIcerikAramaVM.AramaSite))
                {
                    var webSiteParametre = urunIcerikAramaVM.AramaSite.Split(',').ToList();
                    webSiteParametre.ForEach(p =>
                    {
                        int webSite = 0;
                        if (int.TryParse(p, out webSite))
                            webSiteListe.Add(webSite);
                    });
                }
                string webSiteId = string.Join(',', webSiteListe);

                if (cacheIsActive)
                {
                    List<UrunIcerikRaw> hediyeTumData = null;

                    switch (cacheType)
                    {
                        default:
                        case "Memory":
                            memoryCache.TryGetValue<List<UrunIcerikRaw>>("GetUrunIcerikList", out hediyeTumData);
                            break;
                        case "Redis":
                            hediyeTumData = await distributedCache.GetAsync<List<UrunIcerikRaw>>("GetUrunIcerikList");
                            break;
                    }

                    if (hediyeTumData == null)
                    {
                        hediyeTumData = await readOnlyRepository.SelectFromQueryAsync<UrunIcerikRaw>(UrunRawQueries.TumHediyeListGetir(fileServerIsActive));

                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Set<List<UrunIcerikRaw>>("GetUrunIcerikList", hediyeTumData, memoryCacheEntryOptions);
                                break;
                            case "Redis":
                                await distributedCache.SetAsync<List<UrunIcerikRaw>>("GetUrunIcerikList", hediyeTumData, distributedCacheEntryOptions);
                                break;
                        }
                    }

                    //koşullar burada devreye girecek
                    var query = hediyeTumData.AsQueryable();

                    if (!string.IsNullOrEmpty(urunIcerikAramaVM.AramaKelime))
                    {
                        //birden fazla kelime varsa combine bulması lazım
                        string kelime = urunIcerikAramaVM.AramaKelime.ToLower(new CultureInfo("tr-TR", false)).Trim();
                        var kelimeler = kelime.Split(" ");
                        if (kelimeler.Count() > 1)
                        {
                            foreach (var kelimeData in kelimeler)
                            {
                                query = query.Where(p => p.UrunAdi.Contains(kelimeData) ||
                                                         (p.Etiketler != null && p.Etiketler.Contains(kelimeData)));
                            }
                            //query = query.Where(p => kelimeler.Count(s => p.UrunAdi.Contains(s)) > 1 ||
                            //                         (p.Etiketler != null && kelimeler.Count(s => p.Etiketler.Contains(s))>1));
                        }
                        else
                        {
                            query = query.Where(p => p.UrunAdi.Contains(kelime) ||
                                                     (p.Etiketler != null && p.Etiketler.Contains(kelime)));
                        }
                    }

                    if (kategoriListe.Any())
                    {
                        if (kategoriListe.Count == 1)
                            query = query.ToList()
                                         .Where(p => !string.IsNullOrEmpty(p.Kategoriler) &&
                                                     p.Kategoriler.Split(',').Any(p => Convert.ToInt32(p) == kategoriListe[0])).AsQueryable();
                        else
                            query = query.ToList()
                                         .Where(p => !string.IsNullOrEmpty(p.Kategoriler) &&
                                                     p.Kategoriler.Split(',').Any(p => kategoriListe.Contains(Convert.ToInt32(p)))).AsQueryable();
                    }

                    if (markaListe.Any())
                    {
                        if (markaListe.Count == 1)
                            query = query.Where(p => p.MarkaId == markaListe.First());
                        else
                            query = query.Where(p => markaListe.Any(x => x == p.MarkaId));
                    }

                    if (webSiteListe.Any())
                    {
                        if (webSiteListe.Count == 1)
                            query = query.Where(p => p.WebSiteId == webSiteListe.First());
                        else
                            query = query.Where(p => webSiteListe.Any(x => x == p.WebSiteId));
                    }

                    var total = query.Count();

                    //sıralama
                    switch (urunIcerikAramaVM.Siralama)
                    {
                        default:
                        case "TEY":
                            query = query.OrderByDescending(p => p.UrunId);
                            break;
                        case "TEE":
                            query = query.OrderBy(p => p.UrunId);
                            break;
                        case "FGAZ":
                            query = query.OrderByDescending(p => p.Fiyat);
                            break;
                        case "FGAR":
                            query = query.OrderBy(p => p.Fiyat);
                            break;
                    }

                    var result = query.Skip(start * length).Take(length).ToList();

                    var hediyeList = mapper.Map<List<UrunIcerikRaw>, List<UrunIcerikVM>>(result);

                    foreach (var item in hediyeList)
                    {
                        item.HediyeSepetindekiUrunAdeti = HediyeSepetindekiUrunAdeti(item.UrunId);
                    }

                    return new StaticPagedList<UrunIcerikVM>(hediyeList, start + 1, length, total);
                }
                else
                {
                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@Start", start * length));
                    parameters.Add(new SqlParameter("@Length", length));

                    if (!string.IsNullOrEmpty(urunIcerikAramaVM.AramaKelime))
                        parameters.Add(new SqlParameter("@AramaKelime", urunIcerikAramaVM.AramaKelime));

                    if (!string.IsNullOrEmpty(kategoriId))
                        parameters.Add(new SqlParameter("@KategoriId", kategoriId));

                    if (!string.IsNullOrEmpty(markaId))
                        parameters.Add(new SqlParameter("@MarkaId", markaId));

                    if (!string.IsNullOrEmpty(webSiteId))
                        parameters.Add(new SqlParameter("@WebSiteId", webSiteId));

                    var hediyeTotalData = await readOnlyRepository.GetFromQueryAsync<UrunTotalRaw>(UrunRawQueries.HediyeListTotalGetir(urunIcerikAramaVM.AramaKelime, kategoriId, urunIcerikAramaVM.AramaMarka, urunIcerikAramaVM.AramaSite), parameters.ToArray());
                    var hediyeData = await readOnlyRepository.SelectFromQueryAsync<UrunRaw>(UrunRawQueries.HediyeListGetir(fileServerIsActive, urunIcerikAramaVM.Siralama, urunIcerikAramaVM.AramaKelime, kategoriId, urunIcerikAramaVM.AramaMarka, urunIcerikAramaVM.AramaSite), parameters.ToArray());
                    var hediyeList = mapper.Map<List<UrunRaw>, List<UrunIcerikVM>>(hediyeData);

                    foreach (var item in hediyeList)
                    {
                        item.HediyeSepetindekiUrunAdeti = HediyeSepetindekiUrunAdeti(item.UrunId);
                    }

                    return new StaticPagedList<UrunIcerikVM>(hediyeList, start + 1, length, hediyeTotalData.Total);
                }

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "UrunDataService", "GetUrunIcerikList"));
                throw;
            }
        }

        public async Task<UrunDetayIcerikVM> GetUrunDetayIcerikById(int id)
        {
            UrunDetayIcerikVM result = new UrunDetayIcerikVM();

            try
            {
                Urun urun = null;

                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew,
                  new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    urun = readOnlyRepository.GetQueryable<Urun>(w => w.UrunId == id).SingleOrDefault();
                    if (urun != null)
                    {
                        urun.GoruntulenmeSayisi++;
                        repository.Update(urun);
                        await SaveChanges();
                    }

                    scope.Complete();
                }

                if (urun != null)
                {
                    List<UrunIcerikRaw> hediyeTumData = null;
                    UrunIcerikRaw urunIcerik = null;

                    if (cacheIsActive)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.TryGetValue<List<UrunIcerikRaw>>("GetUrunIcerikList", out hediyeTumData);
                                break;
                            case "Redis":
                                hediyeTumData = await distributedCache.GetAsync<List<UrunIcerikRaw>>("GetUrunIcerikList");
                                break;
                        }

                        if (hediyeTumData != null)
                        {
                            urunIcerik = hediyeTumData.SingleOrDefault(p => p.UrunId == id);
                        }
                    }

                    string resimler = "";
                    if (urunIcerik != null)
                    {
                        result = mapper.Map<UrunIcerikRaw, UrunDetayIcerikVM>(urunIcerik);
                        resimler = urunIcerik.Resimler;
                        var parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@UrunId", id));

                        var data = readOnlyRepository.GetFromQuery<UrunDetayIcerikSayiRaw>(UrunRawQueries.UrunDetaySayiGetir(), parameters.ToArray());
                        result.GoruntulenmeSayisi = data.GoruntulenmeSayisi;
                        result.HediyeSepetiSayisi = data.HediyeSepetiSayisi;
                    }
                    else
                    {
                        var parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@UrunId", id));

                        var data = readOnlyRepository.GetFromQuery<UrunDetayIcerikRaw>(UrunRawQueries.UrunDetayGetir(fileServerIsActive), parameters.ToArray());
                        resimler = data.Resimler;
                        result = mapper.Map<UrunDetayIcerikRaw, UrunDetayIcerikVM>(data);
                    }

                    if (string.IsNullOrEmpty(resimler))
                    {
                        List<string> emptyPictureList = new List<string>();
                        emptyPictureList.Add("/Uploads/Site/blog_empty_image_500_500.png");
                        result.Resimler = emptyPictureList;
                    }
                    else
                    {
                        result.Resimler = resimler.Split('|');
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "UrunDataService", "GetUrunDetayIcerikById"));
            }

            return result;
        }

        public async Task YonlendirmeSayisiArttir(UrunYonlendirmeSayisi urunVM)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew,
                   new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                try
                {
                    var urun = readOnlyRepository.GetQueryable<Urun>(w => w.UrunId == urunVM.UrunId).SingleOrDefault();
                    if (urun != null)
                    {
                        urun.YonlendirmeSayisi++;
                        repository.Update(urun);
                        await SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "UrunDataService", "YonlendirmeSayisiArttir"));
                }

                scope.Complete();
            }
        }

        public async Task KullaniciFiyatGorListArttir(KullaniciFiyatGorVM kullanici)
        {
            try
            {
                KullaniciUrunFiyatGor kullaniciVM = new KullaniciUrunFiyatGor();
                kullaniciVM.KullaniciId = kullanici.KullaniciId;
                kullaniciVM.UrunId = kullanici.UrunId;
                kullaniciVM.BakilanTarih = DateTime.Now;
                repository.Create(kullaniciVM);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int HediyeSepetindekiUrunAdeti(int urunId)
        {
            int result = 0;

            try
            {
                result = readOnlyRepository.GetQueryable<KullaniciUrun>(p => p.AktifMi && p.UrunId == urunId).Count();
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        
        #endregion

        #endregion

        #region Sürpriz Ürün
        public async Task<List<SurprizUrunGetirVM>> SurprizUrunGetir(SurprizUrunKayitVM data)
        {
            if (data.UrunIdArama == 0)
            {
                var query = readOnlyRepository.GetQueryable<Urun>(q => q.UrunAdi.Trim().StartsWith(data.UrunAdi.Trim())).Select(p => new { p.UrunId, p.UrunAdi, p.AktifMi });

                query = query.Where(x => x.AktifMi == true);

                var urunler = query.Select(p => new SurprizUrunGetirVM { id = p.UrunId, text = p.UrunAdi }).ToListAsync();
                return await urunler;
            }
            else
            {
                var query = readOnlyRepository.GetQueryable<Urun>(q => q.UrunId == data.UrunIdArama)
                                                        .Select(p => new { p.UrunId, p.UrunAdi, p.AktifMi });


                query = query.Where(x => x.AktifMi == true);


                var urunler = query.Select(p => new SurprizUrunGetirVM { id = p.UrunId, text = p.UrunAdi }).ToListAsync();
                return await urunler;
            }

        }
        public async Task<SurprizUrunKayitVM> SurprizUrunGetirById(int id)
        {
            var urunler = readOnlyRepository.GetQueryable<Urun>().AsNoTracking();

            return await readOnlyRepository.GetQueryable<SurprizUrun>(w => w.SurprizUrunId == id).Select(p => new SurprizUrunKayitVM
            {
                SurpizUrunId = p.SurprizUrunId,
                UrunId = p.UrunId,
                AktifMi = p.AktifMi,
                UrunAdi = urunler.Where(x => x.UrunId == p.UrunId).Select(p => p.UrunAdi).FirstOrDefault()
            }).SingleOrDefaultAsync();
        }
        public async Task<int> SurprizUrunKayit(SurprizUrunKayitVM model)
        {
            try
            {
                var surprizUrun = readOnlyRepository.GetQueryable<SurprizUrun>(w => w.SurprizUrunId == model.SurpizUrunId).SingleOrDefault();

                if (surprizUrun != null)
                {
                    surprizUrun.AktifMi = model.AktifMi;
                    surprizUrun.UrunId = model.UrunId != 0 ? model.UrunId : surprizUrun.UrunId;
                    repository.Update(surprizUrun);
                    await SaveChanges();
                    return surprizUrun.SurprizUrunId;
                }
                else
                {
                    var data = new SurprizUrun();

                    data.UrunId = model.UrunId;
                    data.KayitTarih = DateTime.Now;
                    data.GuncellemeTarih = data.KayitTarih;
                    data.AktifMi = true;

                    repository.Create(data);
                    await SaveChanges();

                    return data.SurprizUrunId;
                }

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UrunDataService", "SurprizUrunKayit", model.UrunId));
                return -1;
            }
        }
        public async Task<List<SurprizUrunAramaSonucVM>> SurprizUrunArama(SurprizUrunAramaVM model)
        {
            var query = readOnlyRepository.GetQueryable<SurprizUrun>().Select(p => new { p.KullaniciId, p.SurprizUrunId, p.UrunId, p.AktifMi, p.KazandigiTarih }).AsNoTracking();

            if (model.AktifMi != -1)
            {
                query = query.Where(x => x.AktifMi == Convert.ToBoolean(model.AktifMi));
            }

            if (model.SurprizUrunId != 0)
            {
                query = query.Where(x => x.SurprizUrunId == model.SurprizUrunId);
            }
            else if (model.UrunId != 0)
            {
                query = query.Where(x => x.UrunId == model.UrunId);
            }
            else if (model.UrunAdi != null)
            {
                var urunId = readOnlyRepository.GetQueryable<Urun>(x => (x.UrunAdi.Trim().StartsWith(model.UrunAdi.Trim()))).Select(p => new { p.UrunId }).AsNoTracking();

                query = query.Where(p => p.UrunId == urunId.Where(x => x.UrunId == p.UrunId).Select(k => k.UrunId).FirstOrDefault());

            }
            else if (model.KullaniciAdiVeyaEposta != null)
            {
                var ePostami = model.KullaniciAdiVeyaEposta.IndexOf('@');
                if (ePostami >= 0)
                {
                    var kullaniciId = readOnlyRepository.GetQueryable<Kullanici>(x => (x.Eposta.Contains(model.KullaniciAdiVeyaEposta.Trim()))).Select(p => new { p.KullaniciId }).AsNoTracking().FirstOrDefault();

                    query = query.Where(x => (x.KullaniciId == kullaniciId.KullaniciId));
                }
                else
                {
                    var kullaniciId = readOnlyRepository.GetQueryable<Kullanici>(x => (x.KullaniciAdi.Contains(model.KullaniciAdiVeyaEposta.Trim()))).Select(p => new { p.KullaniciId }).AsNoTracking().FirstOrDefault();
                    query = query.Where(x => (x.KullaniciId == kullaniciId.KullaniciId));
                }
            }

            int total = await query.CountAsync();

            var urun = readOnlyRepository.GetQueryable<Urun>().AsNoTracking();
            var kullanici = readOnlyRepository.GetQueryable<Kullanici>().AsNoTracking();

            var result = query.OrderByDescending(p => p.SurprizUrunId).Select(p => new SurprizUrunAramaSonucVM
            {
                TotalCount = total,
                SurprizUrunId = p.SurprizUrunId,
                UrunId = p.UrunId,
                UrunAdi = urun.Where(x => x.UrunId == p.UrunId).Select(p => p.UrunAdi).FirstOrDefault(),
                KullaniciAdi = kullanici.Where(x => x.KullaniciId == p.KullaniciId).Select(p => p.KullaniciAdi).FirstOrDefault(),
                Adi = kullanici.Where(x => x.KullaniciId == p.KullaniciId).Select(p => p.Adi).FirstOrDefault(),
                Soyadi = kullanici.Where(x => x.KullaniciId == p.KullaniciId).Select(p => p.Soyadi).FirstOrDefault(),
                Eposta = kullanici.Where(x => x.KullaniciId == p.KullaniciId).Select(p => p.Eposta).FirstOrDefault(),
                KazandigiTarih = p.KazandigiTarih.HasValue ? p.KazandigiTarih.Value.ToString("dd.MM.yyyy HH:mm:ss") : "",
                AktifMi = p.AktifMi
            });

            return await result.Skip(model.start)
                               .Take(model.length)
                               .ToListAsync();
        }
        public async Task<int> SurprizUrunSil(int id)
        {
            SurprizUrun updatedSurprizUrun = readOnlyRepository.GetQueryable<SurprizUrun>(w => w.SurprizUrunId == id).Single();
            updatedSurprizUrun.AktifMi = false;
            repository.Update(updatedSurprizUrun);
            return await SaveChanges();
        }

        #endregion

    }
}
