using HappyFit.Data.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Models.Katalog;
using NeSever.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.Data.DataService.Katalog
{
    public interface IKatalogDataService
    {
        Task<List<MarkaAramaResultVM>> GetMarkaList(MarkaAramaVM markaAramaVM);
        Task<int> MarkaAnasayfaGosterilsinMiGuncelle(int id);
        Task<int> MarkaGuncelle(MarkaVM data);
        Task<MarkaVM> GetMarkaById(int id);

        Task<List<MarkaVM>> GetMarkaList();
    }
    public class KatalogDataService : BaseDataService, IKatalogDataService
    {
        IUnitOfWork unitOfWork;
        private readonly IRepository repository;
        private readonly IReadOnlyRepository readOnlyRepository;
        private readonly ILogger<KatalogDataService> logger;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public KatalogDataService(IUnitOfWork unitOfWork,
                                  IRepository repository, 
                                  IReadOnlyRepository readOnlyRepository, 
                                  ILogger<KatalogDataService> logger)
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

        public async Task<List<MarkaAramaResultVM>> GetMarkaList(MarkaAramaVM markaAramaVM)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<Marka>(
                                   p => (markaAramaVM.MarkaAdi == null || p.MarkaAdi.Contains(markaAramaVM.MarkaAdi))
                                     && (markaAramaVM.MarkaId == null || p.MarkaId == markaAramaVM.MarkaId)                         
                                     && (markaAramaVM.WebSiteId == null || p.WebSiteId == markaAramaVM.WebSiteId)
                                     && (markaAramaVM.AktifMi == -1 || p.AktifMi == Convert.ToBoolean(markaAramaVM.AktifMi)));

                var total = query.Count();

                return await query.Include("WebSite").OrderByDescending(p => p.MarkaId)
                                    .Select(p => new MarkaAramaResultVM
                                    {
                                        MarkaId=p.MarkaId,
                                        MarkaAdi=p.MarkaAdi,
                                        WebSiteId=p.WebSiteId,
                                        WebSiteAdi=p.WebSite.WebSiteAdi,
                                        Aciklama = p.Aciklama,
                                        Sira = p.Sira,
                                        MetaDescription=p.MetaDescription,
                                        MetaTitle=p.MetaTitle,
                                        MetaKeywords=p.MetaKeywords,
                                        ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : null,
                                        Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                        AnasayfaDurum = p.AnasayfadaGosterilsin == true ? "Evet" : "Hayır",
                                        TotalCount = total
                                    }).Skip(markaAramaVM.start)
                                    .Take(markaAramaVM.length)
                                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public async Task<List<MarkaVM>> GetMarkaList()
        {
            try
            {
                return await readOnlyRepository.GetQueryable<Marka>().OrderByDescending(p => p.MarkaId)
                                    .Select(p => new MarkaVM
                                    {
                                        MarkaId = p.MarkaId,
                                        MarkaAdi = p.MarkaAdi,
                                        WebSiteId = p.WebSiteId,
                                        WebSiteAdi = p.WebSite.WebSiteAdi,
                                        Aciklama = p.Aciklama,
                                        Sira = p.Sira,
                                        Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                        AnasayfaDurum = p.AnasayfadaGosterilsin == true ? "Evet" : "Hayır",
                                    })
                                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<int> MarkaAnasayfaGosterilsinMiGuncelle(int id)
        {
            Marka updatedMarka = readOnlyRepository.GetQueryable<Marka>(w => w.MarkaId == id).Single();
            if (updatedMarka.AnasayfadaGosterilsin)
                updatedMarka.AnasayfadaGosterilsin = false;
            else
                updatedMarka.AnasayfadaGosterilsin = true;
            repository.Update(updatedMarka);
            return await SaveChanges();

        }
        public async Task<int> MarkaGuncelle(MarkaVM data)
        {
            try
            {
                if (data.MarkaId == 0)
                {
                    Marka yeniMarka = new Marka()
                    {
                        WebSiteId = data.WebSiteId,
                        MarkaAdi = data.MarkaAdi,
                        Aciklama = data.Aciklama != null ? data.Aciklama.Trim() : null,
                        AnasayfadaGosterilsin = data.AnasayfadaGosterilsin,
                        MetaKeywords = data.MetaKeywords,
                        MetaDescription = data.MetaDescription,
                        MetaTitle = data.MetaTitle,
                        KayitTarih = DateTime.Now,
                        Sira = data.Sira,
                        AktifMi = data.AktifMi
                    };
                    if (!string.IsNullOrEmpty(data.ResimUrl))
                        yeniMarka.ResimUrl = data.ResimUrl;
                    if (data.Resim != null)
                        yeniMarka.Resim = data.Resim;
                    repository.Create(yeniMarka);
                    await SaveChanges();
                    return yeniMarka.MarkaId;
                }
                else
                {
                    Marka updatedMarka = readOnlyRepository.GetQueryable<Marka>(w => w.MarkaId == data.MarkaId).Single();
                    if (!string.IsNullOrEmpty(data.ResimUrl))
                        updatedMarka.ResimUrl = data.ResimUrl;
                    if (data.Resim != null)
                        updatedMarka.Resim = data.Resim;
                    updatedMarka.Sira = data.Sira;
                    updatedMarka.AnasayfadaGosterilsin = data.AnasayfadaGosterilsin;
                    updatedMarka.MetaKeywords = data.MetaKeywords;
                    updatedMarka.MetaDescription = data.MetaDescription;
                    updatedMarka.MetaTitle = data.MetaTitle;
                    updatedMarka.Aciklama = data.Aciklama;
                    updatedMarka.AktifMi = data.AktifMi;
                    updatedMarka.MarkaAdi = data.MarkaAdi;
                    updatedMarka.WebSiteId = data.WebSiteId;

                    repository.Update(updatedMarka);
                    await SaveChanges();
                    return updatedMarka.MarkaId;
                }
            }
            catch(Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "KatalogDataService", "MarkaGuncelle", data.MarkaId));
                return 0;
            }        

        }

        public async Task<MarkaVM> GetMarkaById(int id)
        {
            return await readOnlyRepository.GetQueryable<Marka>(w => w.MarkaId == id)
                                      .Include("WebSite")
                                       .Select(p => new MarkaVM
                                       {
                                           MarkaId = p.MarkaId,
                                           MarkaAdi = p.MarkaAdi,
                                           WebSiteId = p.WebSiteId,
                                           WebSiteAdi = p.WebSite.WebSiteAdi,
                                           Aciklama = p.Aciklama,
                                           Sira = p.Sira,
                                           Durum = p.AktifMi == true ? "Aktif" : "Pasif",
                                           AnasayfadaGosterilsin=p.AnasayfadaGosterilsin,
                                           AnasayfaDurum = p.AnasayfadaGosterilsin == true ? "Evet" : "Hayır",
                                           MetaDescription = p.MetaDescription,
                                           MetaTitle = p.MetaTitle,
                                           MetaKeywords = p.MetaKeywords,
                                           ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : null,
                                           AktifMi = p.AktifMi

                                       }).SingleOrDefaultAsync();
        }

   
    }
}
