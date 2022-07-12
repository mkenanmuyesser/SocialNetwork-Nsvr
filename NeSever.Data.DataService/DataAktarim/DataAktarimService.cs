using HappyFit.Data.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Models.DataAktarim;
using NeSever.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.Data.DataService.DataAktarim
{
    public interface IDataAktarimService
    {
        Task<WebSiteBilgileriVM> GetWebSiteBilgileri();

        Task<WebSiteVM> WebSiteArama(WebSiteVM model);

        Task<int> DurumGuncelle(int id);
        Task<List<WebSiteAramaSonucVM>> WebSiteListesiniGetir();

        Task<UrunLinkIslemBilgileriVM> GetUrunLinkBilgileri();

        Task<UrunLinkIslemVM> UrunLinkArama(UrunLinkIslemVM model);

        Task<int> UrunLinkDurumGuncelle(int id);

        Task<HataLogVM> HataLogArama(HataLogVM model);

    }
    public class DataAktarimService : BaseDataService, IDataAktarimService
    {
        IUnitOfWork unitOfWork;
        private readonly IRepository repository;
        private readonly IReadOnlyRepository readOnlyRepository;
        private readonly ILogger<DataAktarimService> logger;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public DataAktarimService(IUnitOfWork unitOfWork,
                                  IRepository repository,
                                  IReadOnlyRepository readOnlyRepository,
                                  ILogger<DataAktarimService> logger)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.logger = logger;
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }

        public async Task<WebSiteBilgileriVM> GetWebSiteBilgileri()
        {
            WebSiteBilgileriVM webSiteBilgileriVM = new WebSiteBilgileriVM();
            webSiteBilgileriVM.ToplamDataAktarimSayisi = readOnlyRepository.GetQueryable<DataKategori>(p => p.IsActive == true).Count();
            webSiteBilgileriVM.ToplamKategoriSayisi = readOnlyRepository.GetAll<Kategori>().Count();
            webSiteBilgileriVM.ToplamMarkaSayisi = readOnlyRepository.GetAll<Marka>().Count();
            webSiteBilgileriVM.ToplamUrunLinkSayisi = readOnlyRepository.GetAll<DataUrunLink>().Count();

            return webSiteBilgileriVM;


        }
        public async Task<List<WebSiteAramaSonucVM>> WebSiteListesiniGetir()
        {
            return await readOnlyRepository.GetQueryable<WebSite>().OrderByDescending(p => p.WebSiteId)
                                .Select(p => new WebSiteAramaSonucVM
                                {
                                    WebSiteId = p.WebSiteId,
                                    WebSiteAdi = p.WebSiteAdi

                                })
                                .ToListAsync();


        }

        public async Task<WebSiteVM> WebSiteArama(WebSiteVM model)
        {
            var query = readOnlyRepository.GetQueryable<WebSite>(
                                 p => (model.AramaFiltreleri.Id == null || p.WebSiteId == model.AramaFiltreleri.Id)
                                   && (model.AramaFiltreleri.WebSiteAdi == null || p.WebSiteAdi.Contains(model.AramaFiltreleri.WebSiteAdi))
                                   && (model.AramaFiltreleri.SiteUrl == null || p.SiteUrl.Contains(model.AramaFiltreleri.SiteUrl))
                                   && (model.AramaFiltreleri.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(model.AramaFiltreleri.AktifMi)));

            var total = query.Count();

            model.WebSiteAramaSonucList = await query.OrderByDescending(p => p.WebSiteId)
                                .Select(p => new WebSiteAramaSonucVM
                                {
                                    WebSiteId = p.WebSiteId,
                                    WebSiteAdi = p.WebSiteAdi,
                                    WebSiteUrl = p.SiteUrl,
                                    ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : null,
                                    Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                    TotalCount = total
                                }).Skip(model.start)
                                .Take(model.length)
                                .ToListAsync();

            return model;

        }

        public async Task<int> DurumGuncelle(int id)
        {
            WebSite updatedWebSite = readOnlyRepository.GetQueryable<WebSite>(w => w.WebSiteId == id).Single();
            if (updatedWebSite.AktifMi)
                updatedWebSite.AktifMi = false;
            else
                updatedWebSite.AktifMi = true;

            repository.Update(updatedWebSite);
            return await SaveChanges();

        }

        public async Task<UrunLinkIslemBilgileriVM> GetUrunLinkBilgileri()
        {
            UrunLinkIslemBilgileriVM urunLinkIslemBilgileriVM = new UrunLinkIslemBilgileriVM();
            urunLinkIslemBilgileriVM.AktifUrunLinkSayisi = readOnlyRepository.GetQueryable<DataUrunLink>(p => p.IsActive == true).Count();
            urunLinkIslemBilgileriVM.PasifUrunLinkSayisi = readOnlyRepository.GetQueryable<DataUrunLink>(p => p.IsActive == false).Count();
            urunLinkIslemBilgileriVM.ToplamUrunLinkSayisi = readOnlyRepository.GetQueryable<DataUrunLink>().Count();

            return urunLinkIslemBilgileriVM;


        }

        public async Task<UrunLinkIslemVM> UrunLinkArama(UrunLinkIslemVM model)
        {
            var query = readOnlyRepository.GetQueryable<DataUrunLink>(
                                 p => (model.AramaFiltreleri.Id == null || p.ProductLinkHistoryId == model.AramaFiltreleri.Id)
                                   && (model.AramaFiltreleri.UrunLink == null || p.ProductLink.Contains(model.AramaFiltreleri.UrunLink))
                                   && (model.AramaFiltreleri.WebSiteId == -1 || p.WebSiteId == model.AramaFiltreleri.WebSiteId)
                                   && (model.AramaFiltreleri.AktifMi == -1 || p.IsActive == Convert.ToBoolean(model.AramaFiltreleri.AktifMi)));

            var total = query.Count();

            model.UrunLinkIslemAramaSonucList = await query.Include("WebSite").OrderByDescending(p => p.WebSiteId)
                                .Select(p => new UrunLinkIslemAramaSonucVM
                                {
                                    Id = p.ProductLinkHistoryId,
                                    WebSitesi = p.WebSite.WebSiteAdi,
                                    UrunLinki = p.ProductLink,
                                    IslemTarihi = p.LastModifiedDate.ToShortDateString(),
                                    Durum = p.IsActive == true ? "Aktif" : "Pasif",
                                    TotalCount = total
                                }).Skip(model.start)
                                .Take(model.length)
                                .ToListAsync();

            return model;

        }

        public async Task<int> UrunLinkDurumGuncelle(int id)
        {
            DataUrunLink updatedDataUrunLink = readOnlyRepository.GetQueryable<DataUrunLink>(w => w.ProductLinkHistoryId == id).Single();
            if (updatedDataUrunLink.IsActive)
                updatedDataUrunLink.IsActive = false;
            else
                updatedDataUrunLink.IsActive = true;

            repository.Update(updatedDataUrunLink);
            return await SaveChanges();

        }

        public async Task<HataLogVM> HataLogArama(HataLogVM model)
        {
            var query = readOnlyRepository.GetQueryable<DataHataLog>(
                                 p => (model.ErrorLogId == null || p.ErrorLogId == model.ErrorLogId)
                                   && (model.BaslangicTarihi == null || p.LastModifiedDate >= Convert.ToDateTime(model.BaslangicTarihi))
                                   && (model.BitisTarihi == null || p.LastModifiedDate <= Convert.ToDateTime(model.BitisTarihi))
                                   && (model.ProcessName == null || p.ProcessName.Contains(model.ProcessName))
                                   && (model.ErrorLogContent == null || p.ErrorLogContent.Contains(model.ErrorLogContent)));

            var total = query.Count();

            model.HataLogSonucListesi = await query.Include("WebSite").OrderByDescending(p => p.WebSiteId)
                                .Select(p => new HataLogAramaSonucVM
                                {
                                    ErrorLogContent = p.ErrorLogContent,
                                    WebSiteAdi = p.WebSite.WebSiteAdi,
                                    ProcessName = p.ProcessName,
                                    ErrorLogId = p.ErrorLogId,
                                    LastModifiedDate = p.LastModifiedDate.ToShortDateString(),
                                    TotalCount = total
                                }).Skip(model.start)
                                .Take(model.length)
                                .ToListAsync();

            return model;

        }
    }
}
