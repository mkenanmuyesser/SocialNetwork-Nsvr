using HappyFit.Data.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Models;
using NeSever.Common.Models.DataAktarim;
using NeSever.Common.Models.Sistem;
using NeSever.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace NeSever.Data.DataService.Sistem
{
    public interface ISistemDataService
    {
        Task<List<TreeViewNodeModel>> GetKategoriTreeViewList();

        #region Data Kategori
        Task<List<DataKategoriAramaResultVM>> GetDataKategoriList(DataKategoriAramaVM dataKategoriAramaVM);
        Task<int> UpdateDataKategoriTargetCategory(int id, int targetCategoryId);
        Task<int> UpdateDataKategoriIsActive(int id, bool isActive);
        Task<int> DataKategoriTargetCategorySil(int id);
        Task<ResultModel> CacheTemizleme(CacheTemizleme vm);
        #endregion


    }

    public class SistemDataService : BaseDataService, ISistemDataService
    {
        private IUnitOfWork unitOfWork;
        private IMemoryCache memoryCache;
        private IDistributedCache distributedCache;
        private readonly IRepository repository;
        private readonly IReadOnlyRepository readOnlyRepository;
        private readonly ILogger<SistemDataService> logger;
        private bool cacheIsActive;
        private string cacheType;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public SistemDataService(IUnitOfWork unitOfWork,
                                 IMemoryCache memoryCache,
                                 IDistributedCache distributedCache,
                                 IRepository repository,
                                 IReadOnlyRepository readOnlyRepository,
                                 ILogger<SistemDataService> logger)
        {
            this.unitOfWork = unitOfWork;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.logger = logger;

            var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings");
            if (appSettings != null)
            {
                cacheIsActive = Convert.ToBoolean(appSettings["CacheIsActive"]);

                if (cacheIsActive)
                {
                    cacheType = Convert.ToString(appSettings["CacheType"]);
                }
            }
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }
        public async Task<List<TreeViewNodeModel>> GetKategoriTreeViewList()
        {
            return await readOnlyRepository.GetQueryable<Kategori>()
                                    .Select(p => new TreeViewNodeModel
                                    {
                                        id=p.KategoriId.ToString(),
                                        parent = p.UstKategoriId == null ? "#" : p.UstKategoriId.ToString(),
                                        text=p.KategoriAdi

                                    })
                                    .ToListAsync();
        }

        public async Task<List<DataKategoriAramaResultVM>> GetDataKategoriList(DataKategoriAramaVM dataKategoriAramaVM)
        {

            var query = readOnlyRepository.GetQueryable<DataKategori>(
                                           p => (dataKategoriAramaVM.CategoryID == null || p.CategoryId == dataKategoriAramaVM.CategoryID)
                                           && (dataKategoriAramaVM.WebSiteID == null || p.WebSiteId == dataKategoriAramaVM.WebSiteID)
                                           && (dataKategoriAramaVM.CategoryName == null || p.CategoryName.StartsWith(dataKategoriAramaVM.CategoryName))
                                           && (dataKategoriAramaVM.IsActive == -1 || p.IsActive == Convert.ToBoolean(dataKategoriAramaVM.IsActive)));

            var total = query.Count();

            return await query.Include("WebSite").Include("Kategori").OrderByDescending(p => p.CategoryId)
                                .Select(p => new DataKategoriAramaResultVM
                                {
                                    CategoryID=p.CategoryId,
                                    CategoryName=p.CategoryName,
                                    WebSiteName=p.WebSite.WebSiteAdi,
                                    WebSiteID=p.WebSiteId,
                                    IsActive=p.IsActive,
                                    TargetCategoryName=p.Kategori.KategoriAdi != null ? p.Kategori.KategoriAdi : "Target Kategori Girilmemiş",
                                    TargetCategoryID=p.KategoriId,
                                    OriginalCategoryID=p.OriginalCategoryId,                                 
                                    Durum = p.IsActive == true ? "Aktif" : "Pasif",
                                    TotalCount = total
                                }).Skip(dataKategoriAramaVM.start)
                                .Take(dataKategoriAramaVM.length)
                                .ToListAsync();

        }

        public async Task<int> UpdateDataKategoriTargetCategory(int id,int targetCategoryId)
        {

            DataKategori updatedDataKategori = readOnlyRepository.GetQueryable<DataKategori>(w => w.CategoryId == id).Single();
            updatedDataKategori.KategoriId = targetCategoryId;      
            repository.Update(updatedDataKategori);
            return await SaveChanges();

        }
        public async Task<int> DataKategoriTargetCategorySil(int id)
        {

            DataKategori updatedDataKategori = readOnlyRepository.GetQueryable<DataKategori>(w => w.CategoryId == id).Single();
            updatedDataKategori.KategoriId = null;
            repository.Update(updatedDataKategori);
            return await SaveChanges();

        }
        public async Task<int> UpdateDataKategoriIsActive(int id, bool isActive)
        {

            DataKategori updatedDataKategori = readOnlyRepository.GetQueryable<DataKategori>(w => w.CategoryId == id).Single();
            updatedDataKategori.IsActive = isActive;
            repository.Update(updatedDataKategori);
            return await SaveChanges();

        }

        public async Task<ResultModel> CacheTemizleme(CacheTemizleme vm)
        {
            try
            {
                var result = new ResultModel()
                {
                    Type = ResultType.Basarisiz
                };

                if (cacheIsActive)
                {              
                    if (vm.BannerIcerik == true)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("GetBannerIcerikList");
                                break;
                            case "Redis":
                                distributedCache.Remove("GetBannerIcerikList");
                                break;
                        }
                        
                        result.Type = ResultType.Basarili;
                    }
                    if (vm.BlogKategoriIcerik == true)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("GetBlogKategoriIcerikList");
                                break;
                            case "Redis":
                                distributedCache.Remove("GetBlogKategoriIcerikList");
                                break;
                        }

                        result.Type = ResultType.Basarili;
                    }
                    if (vm.HediyeKartIcerik == true)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("GetHediyeKartIcerikList");
                                break;
                            case "Redis":
                                distributedCache.Remove("GetHediyeKartIcerikList");
                                break;
                        }

                        result.Type = ResultType.Basarili;
                    }
                    if (vm.KategoriBannerIcerik == true)
                    {                        
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("GetKategoriBannerIcerikList");
                                break;
                            case "Redis":
                                distributedCache.Remove("GetKategoriBannerIcerikList");
                                break;
                        }

                        result.Type = ResultType.Basarili;
                    }
                    if (vm.KategoriIcerik == true)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("GetKategoriIcerikList");
                                break;
                            case "Redis":
                                distributedCache.Remove("GetKategoriIcerikList");
                                break;
                        }

                        result.Type = ResultType.Basarili;
                    }
                    if (vm.MarkaIcerik == true)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("GetMarkaIcerikList");
                                break;
                            case "Redis":
                                distributedCache.Remove("GetMarkaIcerikList");
                                break;
                        }

                        result.Type = ResultType.Basarili;
                    }
                    if (vm.MarkaList == true)
                    {
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("MarkaListGetir");
                                break;
                            case "Redis":
                                distributedCache.Remove("MarkaListGetir");
                                break;
                        }

                        result.Type = ResultType.Basarili;
                    }
                    if (vm.UrunIcerik == true)
                    {                        
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("GetUrunIcerikList");
                                break;
                            case "Redis":
                                distributedCache.Remove("GetUrunIcerikList");
                                break;
                        }

                        result.Type = ResultType.Basarili;
                    }
                    if (vm.KadinUrunIcerik == true)
                    {                        
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("GetTrendKadinUrunIcerikList");
                                break;
                            case "Redis":
                                distributedCache.Remove("GetTrendKadinUrunIcerikList");
                                break;
                        }

                        result.Type = ResultType.Basarili;
                    }
                    if (vm.ErkekUrunIcerik == true)
                    {                        
                        switch (cacheType)
                        {
                            default:
                            case "Memory":
                                memoryCache.Remove("GetTrendErkekUrunIcerikList");
                                break;
                            case "Redis":
                                distributedCache.Remove("GetTrendErkekUrunIcerikList");
                                break;
                        }

                        result.Type = ResultType.Basarili;
                    }
                }

                return result;
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "Data", "SistemDataService", "CacheTemizleme", "cache temizlenemedi"));
                var result = new ResultModel()
                {
                    Type = ResultType.Basarisiz
                };
                return result;
            }
            
        }

    }
}
