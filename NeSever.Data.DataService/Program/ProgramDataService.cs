using AutoMapper;
using HappyFit.Data.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Models.Admin;
using NeSever.Common.Models.Admin.AramaSonucVM;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Program;
using NeSever.Common.Utils.Email;
using NeSever.Common.Utils.Encryption;
using NeSever.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using X.PagedList;

namespace NeSever.Data.DataService.Program
{
    public interface IProgramDataService
    {
        #region Ayarlar

        #region Admin

        Task<AyarlarVM> AyarlarBilgileriniGetir();
        Task<int> AyarlarGuncelle(AyarlarVM data);
        Task<List<LogVM>> LogArama(LogAramaVM model);
        #endregion

        #region FrontEnd

        Task<UyelikSozlesmesiVM> UyelikSozlesmesiGetir();
        Task<HakkimizdaVM> HakkimizdaBilgiGetir();
        Task<IletisimVM> IletisimBilgiGetir();
        Task<BilgiVM> BilgiGetir();
        Task<bool> IletisimTalepGonder(IletisimTalepVM model);
        Task<SikSorulanSorularVM> SikSorulanSorularGetir();

        #endregion

        #endregion

        #region YoneticiKullanici

        #region Admin

        Task<bool> YoneticiKullaniciKontrol(string eposta);
        Task<YoneticiKullaniciVM> YoneticiKullaniciGirisDataGetir(YoneticiKullaniciGirisVM model);
        Task<int> YoneticiKullaniciKaydet(YoneticiKullaniciKayitVM model);
        Task<bool> YoneticiKullaniciSil(int id);
        Task<YoneticiKullanici> YoneticiKullaniciGetir(int id);
        Task<YoneticiKullaniciKayitVM> YoneticiKullaniciKayitVMGetir(int id);
        Task<List<YoneticiKullaniciAramaSonucVM>> YoneticiKullaniciArama(YoneticiKullaniciAramaVM model);

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Kullanici

        #region Admin

        Task<List<KullaniciAramaSonucVM>> UyeArama(KullaniciAramaVM model);
        Task<List<KullaniciAramaSonucVM>> DogumKriterliUyeArama(DogumKriterliKullaniciAramaVM model);
        Task<List<UrunSayisinaGoreKullaniciAramaSonucVM>> UrunSayisinaGoreUyeArama(UrunSayisinaGoreKullaniciArama model);

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Panel Anasayfa

        #region Admin
        Task<PanelAnasayfaRaporlarVM> PanelAnasayfaRaporlariGetir();
        #endregion

        #region FrontEnd

        #endregion

        #endregion
    }
    public class ProgramDataService : BaseDataService, IProgramDataService
    {
        IUnitOfWork unitOfWork;
        private readonly IRepository repository;
        private readonly IReadOnlyRepository readOnlyRepository;
        private readonly ILogger<ProgramDataService> logger;
        private readonly IMapper mapper;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public ProgramDataService(IUnitOfWork unitOfWork,
                                  IRepository repository,
                                  IReadOnlyRepository readOnlyRepository,
                                  ILogger<ProgramDataService> logger,
                                  IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }

        #region Ayarlar

        #region Admin
        public async Task<AyarlarVM> AyarlarBilgileriniGetir()
        {
            try
            {
                return await readOnlyRepository.GetQueryable<Ayarlar>()
                                               .Select(p => new AyarlarVM
                                               {
                                                   AyarlarId = p.AyarlarId,
                                                   CacheAktifMi = p.CacheAktifMi,
                                                   ClearCacheTime = p.ClearCacheTime,
                                                   CookieTime = p.CookieTime,
                                                   FacebookHesapUrl = p.FacebookHesapUrl,
                                                   GonderilecekEpostaAktifMi = p.GonderilecekEpostaAktifMi,
                                                   GonderilecekEpostaHost = p.GonderilecekEpostaHost,
                                                   GonderilecekEpostaKullaniciAdi = p.GonderilecekEpostaKullaniciAdi,
                                                   GonderilecekEpostaPort = p.GonderilecekEpostaPort,
                                                   GonderilecekEpostaSifre = p.GonderilecekEpostaSifre,
                                                   GonderilecekEpostaTanim = p.GonderilecekEpostaTanim,
                                                   InstagramHesapUrl = p.InstagramHesapUrl,
                                                   IpBloklamaAktifMi = p.IpBloklamaAktifMi,
                                                   IpBlokListesi = p.IpBlokListesi,
                                                   KeepAliveTime = p.KeepAliveTime,
                                                   MetaDescription = p.MetaDescription,
                                                   MetaKeywords = p.MetaKeywords,
                                                   MetaTitle = p.MetaTitle,
                                                   UyelikSozlesmesi = p.UyelikSozlesmesi,
                                                   CerezPolitikasi = p.CerezPolitikasi,
                                                   AydinlatmaMetni = p.AydinlatmaMetni,
                                                   BasvuruFormu = p.BasvuruFormu,
                                                   SikSorulanSorular = p.SikSorulanSorular,
                                                   TeslimatIadeSartlari = p.TeslimatIadeSartlari,
                                                   OnBilgilendirmeFormu = p.OnBilgilendirmeFormu,
                                                   MesafeliSatisSozlesmesi = p.MesafeliSatisSozlesmesi,
                                                   SecureUrl = p.SecureUrl,
                                                   SirketAciklama = p.SirketAciklama,
                                                   SirketAd = p.SirketAd,
                                                   SirketAdres = p.SirketAdres,
                                                   SirketEposta = p.SirketEposta,
                                                   SirketFax1 = p.SirketFax1,
                                                   SirketFax2 = p.SirketFax2,
                                                   SirketHakkimizda = p.SirketHakkimizda,
                                                   SirketMapCode = p.SirketMapCode,
                                                   SirketTelefon1 = p.SirketTelefon1,
                                                   SirketTelefon2 = p.SirketTelefon2,
                                                   SslAktifMi = p.SslAktifMi,
                                                   TwitterHesapUrl = p.TwitterHesapUrl,
                                                   UygulamaAciklama = p.UygulamaAciklama,
                                                   UygulamaAd = p.UygulamaAd,
                                                   UygulamaAktifMi = p.UygulamaAktifMi,
                                                   Url = p.Url
                                               })
                                               .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<LogVM>> LogArama(LogAramaVM model)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<Log>(
                                          p => (model.Id == null || p.Id == model.Id)
                                          && (model.LevelId == null || p.Level == Enum.GetName(typeof(LogLevel), model.LevelId)));

                var total = query.Count();

                return await query.OrderByDescending(p => p.Id)
                                    .Select(p => new LogVM
                                    {
                                        Id = p.Id,
                                        Exception = p.Exception,
                                        Level = p.Level,
                                        Message = p.Message,
                                        MessageTemplate = p.MessageTemplate,
                                        TimeStamp = String.Format("{0:d/M/yyyy HH:mm:ss}", p.TimeStamp),
                                        Properties = p.Properties,
                                        TotalCount = total
                                    }).Skip(model.start)
                                    .Take(model.length)
                                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<int> AyarlarGuncelle(AyarlarVM data)
        {
            try
            {
                Ayarlar updatedAyar = readOnlyRepository.GetQueryable<Ayarlar>(w => w.AyarlarId == data.AyarlarId).Single();
                updatedAyar.CacheAktifMi = data.CacheAktifMi;
                updatedAyar.ClearCacheTime = data.ClearCacheTime;
                updatedAyar.CookieTime = data.CookieTime;
                updatedAyar.FacebookHesapUrl = data.FacebookHesapUrl;
                updatedAyar.GonderilecekEpostaAktifMi = data.GonderilecekEpostaAktifMi;
                updatedAyar.GonderilecekEpostaHost = data.GonderilecekEpostaHost;
                updatedAyar.GonderilecekEpostaKullaniciAdi = data.GonderilecekEpostaKullaniciAdi;
                updatedAyar.GonderilecekEpostaPort = data.GonderilecekEpostaPort;
                updatedAyar.GonderilecekEpostaSifre = data.GonderilecekEpostaSifre;
                updatedAyar.GonderilecekEpostaTanim = data.GonderilecekEpostaTanim;
                updatedAyar.InstagramHesapUrl = data.InstagramHesapUrl;
                updatedAyar.IpBloklamaAktifMi = data.IpBloklamaAktifMi;
                updatedAyar.IpBlokListesi = data.IpBlokListesi;
                updatedAyar.KeepAliveTime = data.KeepAliveTime;
                updatedAyar.MetaDescription = data.MetaDescription;
                updatedAyar.MetaKeywords = data.MetaKeywords;
                updatedAyar.MetaTitle = data.MetaTitle;
                updatedAyar.UyelikSozlesmesi = data.UyelikSozlesmesi;
                updatedAyar.CerezPolitikasi = data.CerezPolitikasi;
                updatedAyar.AydinlatmaMetni = data.AydinlatmaMetni;
                updatedAyar.BasvuruFormu = data.BasvuruFormu;
                updatedAyar.SikSorulanSorular = data.SikSorulanSorular;
                updatedAyar.TeslimatIadeSartlari = data.TeslimatIadeSartlari;
                updatedAyar.OnBilgilendirmeFormu = data.OnBilgilendirmeFormu;
                updatedAyar.MesafeliSatisSozlesmesi = data.MesafeliSatisSozlesmesi;
                updatedAyar.SecureUrl = data.SecureUrl;
                updatedAyar.SirketAciklama = data.SirketAciklama;
                updatedAyar.SirketAd = data.SirketAd;
                updatedAyar.SirketAdres = data.SirketAdres;
                updatedAyar.SirketEposta = data.SirketEposta;
                updatedAyar.SirketFax1 = data.SirketFax1;
                updatedAyar.SirketFax2 = data.SirketFax2;
                updatedAyar.SirketHakkimizda = data.SirketHakkimizda;
                updatedAyar.SirketMapCode = data.SirketMapCode;
                updatedAyar.SirketTelefon1 = data.SirketTelefon1;
                updatedAyar.SirketTelefon2 = data.SirketTelefon2;
                updatedAyar.SslAktifMi = data.SslAktifMi;
                updatedAyar.TwitterHesapUrl = data.TwitterHesapUrl;
                updatedAyar.UygulamaAciklama = data.UygulamaAciklama;
                updatedAyar.UygulamaAd = data.UygulamaAd;
                updatedAyar.UygulamaAktifMi = data.UygulamaAktifMi;
                updatedAyar.Url = data.Url;
                repository.Update(updatedAyar);
                return await SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        #endregion

        #region FrontEnd

        public async Task<UyelikSozlesmesiVM> UyelikSozlesmesiGetir()
        {
            return await readOnlyRepository.GetQueryable<Ayarlar>()
                                           .Select(p => new UyelikSozlesmesiVM
                                           {
                                               UyelikSozlesmesi = p.UyelikSozlesmesi
                                           })
                                           .FirstOrDefaultAsync();
        }

        public async Task<HakkimizdaVM> HakkimizdaBilgiGetir()
        {
            return await readOnlyRepository.GetQueryable<Ayarlar>()
                                           .Select(p => new HakkimizdaVM
                                           {
                                               SirketAd = p.SirketAd,
                                               SirketAciklama = p.SirketAciklama,
                                               SirketHakkimizda = p.SirketHakkimizda,
                                           })
                                           .FirstOrDefaultAsync();
        }

        public async Task<IletisimVM> IletisimBilgiGetir()
        {
            return await readOnlyRepository.GetQueryable<Ayarlar>()
                                           .Select(p => new IletisimVM
                                           {
                                               SirketAd = p.SirketAd,
                                               SirketAciklama = p.SirketAciklama,
                                               SirketAdres = p.SirketAdres,
                                               SirketEposta = p.SirketEposta,
                                               SirketTelefon1 = p.SirketTelefon1,
                                               SirketTelefon2 = p.SirketTelefon2,
                                               SirketFax1 = p.SirketFax1,
                                               SirketFax2 = p.SirketFax2,
                                               SirketMapCode = p.SirketMapCode,
                                               FacebookHesapUrl = p.FacebookHesapUrl,
                                               TwitterHesapUrl = p.TwitterHesapUrl,
                                               InstagramHesapUrl = p.InstagramHesapUrl
                                           })
                                           .FirstOrDefaultAsync();
        }

        public async Task<BilgiVM> BilgiGetir()
        {
            return await readOnlyRepository.GetQueryable<Ayarlar>()
                                           .Select(p => new BilgiVM
                                           {
                                               CerezPolitikasi = p.CerezPolitikasi,
                                               AydinlatmaMetni = p.AydinlatmaMetni,
                                               BasvuruFormu = p.BasvuruFormu,
                                               TeslimIadeSartlari = p.TeslimatIadeSartlari,
                                               UyelikSozlesmesi = p.UyelikSozlesmesi
                                           })
                                           .FirstOrDefaultAsync();
        }

        public async Task<bool> IletisimTalepGonder(IletisimTalepVM model)
        {
            string icerik = "<h4>Bilgi Talep</h4><br/>" +
                           "<b>Ad : </b>" + model.Ad + "<br/>" +
                           "<b>Soyad : </b>" + model.Soyad + "<br/>" +
                           "<b>E-posta </b>: " + model.Eposta + "<br/>" +
                           "<b>Konu : </b>" + model.Konu + "<br/>" +
                           "<b>Mesaj </b>: " + model.Mesaj;

            var ayarlar = await AyarlarBilgileriniGetir();

            EpostaVM epostaModel = new EpostaVM()
            {
                GonderilecekEposta = ayarlar.SirketEposta,
                GonderilecekEpostaTanim = ayarlar.GonderilecekEpostaTanim,
                GonderilecekEpostaKullaniciAdi = ayarlar.GonderilecekEpostaKullaniciAdi,
                GonderilecekEpostaSifre = ayarlar.GonderilecekEpostaSifre,
                GonderilecekEpostaHost = ayarlar.GonderilecekEpostaHost,
                GonderilecekEpostaPort = ayarlar.GonderilecekEpostaPort,
                GonderilecekEpostaSsl = ayarlar.SslAktifMi,
                GonderilecekEpostaIcerik = icerik
            };

            return await EmailHelper.EpostaGonder(epostaModel);
        }
        public async Task<SikSorulanSorularVM> SikSorulanSorularGetir()
        {
            return await readOnlyRepository.GetQueryable<Ayarlar>()
                                           .Select(p => new SikSorulanSorularVM
                                           {
                                               SikSorulanSorular = p.SikSorulanSorular,
                                           })
                                           .FirstOrDefaultAsync();
        }


        #endregion

        #endregion

        #region YoneticiKullanici

        #region Admin

        public async Task<bool> YoneticiKullaniciKontrol(string eposta)
        {
            var result = await readOnlyRepository.GetQueryable<YoneticiKullanici>(p => p.Eposta == eposta)
                                                 .SingleOrDefaultAsync();
            return result == null ? true : false;
        }

        public async Task<YoneticiKullaniciVM> YoneticiKullaniciGirisDataGetir(YoneticiKullaniciGirisVM model)
        {
            try
            {
                return await readOnlyRepository.GetQueryable<YoneticiKullanici>(p => p.AktifMi &&
                                                                                     p.Eposta == model.Eposta &&
                                                                                     p.Sifre == model.Sifre.Encode())
                                               .Select(p => new YoneticiKullaniciVM
                                               {
                                                   YoneticiKullaniciId = p.YoneticiKullaniciId,
                                                   Eposta = p.Eposta,
                                               })
                                               .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> YoneticiKullaniciKaydet(YoneticiKullaniciKayitVM model)
        {
            var data = new YoneticiKullanici();

            if (model.YoneticiKullaniciId == 0)
            {
                data = new YoneticiKullanici()
                {
                    //YoneticiKullaniciId = model.YoneticiKullaniciId,
                    Eposta = model.Eposta,
                    Sifre = model.Sifre.Encode(),
                    KayitKullaniciId = model.IslemKullaniciId,
                    KayitTarih = model.IslemTarih,
                    GuncellemeKullaniciId = null,
                    GuncellemeTarih = null,
                    AktifMi = model.AktifMi
                };

                repository.Create(data);
            }
            else
            {
                data = await YoneticiKullaniciGetir(model.YoneticiKullaniciId);

                //kullanici.Eposta = model.Eposta;
                data.Sifre = model.Sifre.Encode();
                data.GuncellemeKullaniciId = model.IslemKullaniciId;
                data.GuncellemeTarih = model.IslemTarih;
                data.AktifMi = model.AktifMi;

                repository.Update(data);
            }

            var id = await SaveChanges();

            return data.YoneticiKullaniciId;
        }

        public async Task<bool> YoneticiKullaniciSil(int id)
        {
            YoneticiKullanici data = await readOnlyRepository.GetByIdAsync<YoneticiKullanici>(id);
            data.AktifMi = false;
            repository.Update(data);

            var result = await SaveChanges();

            return result > 0 ? true : false;
        }

        public async Task<YoneticiKullanici> YoneticiKullaniciGetir(int id)
        {
            return await readOnlyRepository.GetByIdAsync<YoneticiKullanici>(id);
        }

        public async Task<YoneticiKullaniciKayitVM> YoneticiKullaniciKayitVMGetir(int id)
        {
            return await readOnlyRepository.GetQueryable<YoneticiKullanici>(p => p.YoneticiKullaniciId == id)
                                            .Select(p => new YoneticiKullaniciKayitVM
                                            {
                                                YoneticiKullaniciId = p.YoneticiKullaniciId,
                                                Eposta = p.Eposta,
                                                Sifre = null,
                                                AktifMi = p.AktifMi
                                            })
                                            .SingleOrDefaultAsync();
        }

        public async Task<List<YoneticiKullaniciAramaSonucVM>> YoneticiKullaniciArama(YoneticiKullaniciAramaVM model)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<YoneticiKullanici>(p => (model.Aktiflik == -1 || p.AktifMi == Convert.ToBoolean(model.Aktiflik)) &&
                                                                                    (model.Eposta == null || p.Eposta.Contains(model.Eposta)));

                var total = query.Count();

                return await query.OrderByDescending(p => p.YoneticiKullaniciId)
                                  .Select(p => new YoneticiKullaniciAramaSonucVM
                                  {
                                      YoneticiKullaniciId = p.YoneticiKullaniciId,
                                      Eposta = p.Eposta,
                                      KayitTarih = p.KayitTarih.ToString("dd.MM.yyyy"),
                                      AktifMi = p.AktifMi,
                                      TotalCount = total
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

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Kullanici

        #region Admin       

        public async Task<List<KullaniciAramaSonucVM>> UyeArama(KullaniciAramaVM model)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<Kullanici>().Select(p => new { p.KullaniciId, p.KullaniciAdi, p.Adi, p.Soyadi, p.Eposta, p.DogumTarihi, p.UyelikTarihi, p.Telefon, p.Adres, p.InstagramAdi, p.AktifMi }).AsNoTracking();

                if (model.Aktiflik != -1)
                {
                    query = query.Where(x => x.AktifMi == Convert.ToBoolean(model.Aktiflik));
                }

                if (model.KullaniciAdi != null)
                {
                    query = query.Where(x => (x.KullaniciAdi.Contains(model.KullaniciAdi)));
                }

                if (model.Adi != null)
                {
                    query = query.Where(x => (x.Adi.Contains(model.Adi)));
                }

                if (model.Soyadi != null)
                {
                    query = query.Where(x => (x.Soyadi.Contains(model.Soyadi)));
                }

                if (model.UyelikBaslangicTarihi != null)
                {
                    query = query.Where(x => (x.UyelikTarihi.Date >= Convert.ToDateTime(model.UyelikBaslangicTarihi)));
                }

                if (model.UyelikBitisTarihi != null)
                {
                    query = query.Where(x => (x.UyelikTarihi.Date <= Convert.ToDateTime(model.UyelikBitisTarihi)));
                }

                if (model.DogumBaslangicTarihi != null)
                {
                    query = query.Where(x => ((DateTime)x.DogumTarihi >= Convert.ToDateTime(model.DogumBaslangicTarihi)));
                }

                if (model.DogumBitisTarihi != null)
                {
                    query = query.Where(x => ((DateTime)x.DogumTarihi <= Convert.ToDateTime(model.DogumBitisTarihi)));
                }
                if (model.AdresVeyaTelefon == true)
                {
                    query = query.Where(x => (x.Adres != null || x.Telefon != null));
                }

                var total = await query.CountAsync();

                var result = query.OrderByDescending(p => p.KullaniciId)
                                  .Select(p => new KullaniciAramaSonucVM
                                  {
                                      TotalCount = total,

                                      KullaniciId = p.KullaniciId,
                                      KullaniciAdi = p.KullaniciAdi,
                                      Adi = p.Adi,
                                      Soyadi = p.Soyadi,
                                      Eposta = p.Eposta,
                                      DogumTarihi = Convert.ToDateTime(p.DogumTarihi).ToString("dd.MM.yyyy"),
                                      UyelikTarihi = p.UyelikTarihi.ToString("dd.MM.yyyy"),
                                      Telefon = p.Telefon,
                                      Adres = p.Adres,
                                      InstagramAdi = p.InstagramAdi,
                                      AktifMi = p.AktifMi
                                  });

                if (model.length == -1)
                    return await result.ToListAsync();
                else
                    return await result.Skip(model.start)
                                       .Take(model.length)
                                       .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "ProgramDataService", "UyeArama", ex));
                throw;
            }
        }

        public async Task<List<KullaniciAramaSonucVM>> DogumKriterliUyeArama(DogumKriterliKullaniciAramaVM model)
        {
            try
            {
                IQueryable<Kullanici> query;

                if (model.Aktiflik != -1)
                {
                    query = readOnlyRepository.GetQueryable<Kullanici>(p => (p.AktifMi == Convert.ToBoolean(model.Aktiflik))).AsNoTracking();
                }
                else
                {
                    query = readOnlyRepository.GetQueryable<Kullanici>(p => (p.AktifMi == true || p.AktifMi == false)).AsNoTracking(); ;
                }

                if (model.Ay != 0)
                {
                    query = query.Where(x => (x.DogumTarihi.Value.Month == model.Ay));
                }

                var total = await query.CountAsync();

                var result = query.OrderBy(p => p.DogumTarihi)
                                  .Select(p => new KullaniciAramaSonucVM
                                  {
                                      TotalCount = total,

                                      KullaniciId = p.KullaniciId,
                                      KullaniciAdi = p.KullaniciAdi,
                                      Adi = p.Adi,
                                      Soyadi = p.Soyadi,
                                      Eposta = p.Eposta,
                                      DogumTarihi = Convert.ToDateTime(p.DogumTarihi).ToString("dd.MM.yyyy"),
                                      UyelikTarihi = p.UyelikTarihi.ToString("dd.MM.yyyy"),
                                      Telefon = p.Telefon,
                                      Adres = p.Adres,
                                      AktifMi = p.AktifMi
                                  });

                if (model.length == -1)
                    return await result.ToListAsync();
                else
                    return await result.Skip(model.start)
                                       .Take(model.length)
                                       .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "ProgramDataService", "DogumKriterliUyeArama", ex));
                throw;
            }
        }

        public async Task<List<UrunSayisinaGoreKullaniciAramaSonucVM>> UrunSayisinaGoreUyeArama(UrunSayisinaGoreKullaniciArama model)
        {
            try
            {
                var urun = readOnlyRepository.GetQueryable<KullaniciUrun>(p => p.AktifMi == true).AsNoTracking();
                IQueryable<Kullanici> query;

                if (model.Aktiflik != -1)
                {
                    query = readOnlyRepository.GetQueryable<Kullanici>(p => (p.AktifMi == Convert.ToBoolean(model.Aktiflik))).AsNoTracking();
                }
                else
                {
                    query = readOnlyRepository.GetQueryable<Kullanici>().AsNoTracking();
                }

                var result = query.Select(p => new UrunSayisinaGoreKullaniciAramaSonucVM
                {
                    KullaniciId = p.KullaniciId,
                    KullaniciAdi = p.KullaniciAdi,
                    Adi = p.Adi,
                    Soyadi = p.Soyadi,
                    Eposta = p.Eposta,
                    DogumTarihi = Convert.ToDateTime(p.DogumTarihi).ToString("dd.MM.yyyy"),
                    UyelikTarihi = p.UyelikTarihi.ToString("dd.MM.yyyy"),
                    Telefon = p.Telefon,
                    Adres = p.Adres,
                    UrunSayisi = urun.Where(x => x.KullaniciId == p.KullaniciId).Count(),
                    AktifMi = p.AktifMi,
                    TotalCount = 0
                });

                if (model.length == -1)
                {
                    var kullanicilar = await result.ToListAsync();

                    kullanicilar = kullanicilar.OrderBy(p => p.UrunSayisi).Where(p => (p.UrunSayisi >= model.MinUrun) && (p.UrunSayisi <= model.MaxUrun)).ToList();

                    if (kullanicilar.Count() > 0)
                    {
                        kullanicilar.FirstOrDefault().TotalCount = kullanicilar.Count();
                    }

                    return kullanicilar;
                }
                else
                {
                    var uyeler = await result.ToListAsync();

                    var kullanici = uyeler.OrderBy(p => p.UrunSayisi).Where(p => (p.UrunSayisi >= model.MinUrun) && (p.UrunSayisi <= model.MaxUrun)).Skip(model.start).Take(model.length).ToList();

                    if (kullanici.Count() > 0)
                    {
                        kullanici.FirstOrDefault().TotalCount = uyeler.Where(p => (p.UrunSayisi >= model.MinUrun) && (p.UrunSayisi <= model.MaxUrun)).ToList().Count();
                    }

                    return kullanici;
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "ProgramDataService", "UrunSayisinaGoreUyeArama", ex));
                throw;
            }
        }

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Panel Anasayfa

        #region Admin
        public async Task<PanelAnasayfaRaporlarVM> PanelAnasayfaRaporlariGetir()
        {
            PanelAnasayfaRaporlarVM model = new PanelAnasayfaRaporlarVM();

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew,
                  new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                try
                {
                    model.ToplamUyeSayisi = readOnlyRepository.GetQueryable<Kullanici>().AsNoTracking().Count();
                    model.AktifUyeSayisi = readOnlyRepository.GetQueryable<Kullanici>(p => p.AktifMi == true).AsNoTracking().Count();
                    model.PasifUyeSayisi = readOnlyRepository.GetQueryable<Kullanici>(p => p.AktifMi == false).AsNoTracking().Count();

                    model.ProfilResmiOlanUyeSayisi = readOnlyRepository.GetQueryable<KullaniciResim>(p => p.AktifMi == true && p.ProfilFotografiMi == true).AsNoTracking().Count();
                    model.ProfilResmiOlmayanUyeSayisi = model.AktifUyeSayisi - model.ProfilResmiOlanUyeSayisi;


                    var aktifUye = readOnlyRepository.GetQueryable<Kullanici>(p => p.AktifMi == true).AsNoTracking();
                    var urun = readOnlyRepository.GetQueryable<KullaniciUrun>(p => p.AktifMi == true).AsNoTracking();
                    var uyeler = aktifUye.Select(p => new { UrunSayisi = urun.Where(x => x.KullaniciId == p.KullaniciId).Count() }).ToList();

                    var sepetindeUrunOlan = uyeler.OrderBy(p => p.UrunSayisi).Where(p => (p.UrunSayisi != 0)).Count();

                    model.SepetindeUrunOlanUyeSayisi = sepetindeUrunOlan;
                    model.SepetindeUrunOlmayanUyeSayisi = model.AktifUyeSayisi - sepetindeUrunOlan;

                    var list1 = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi == true).AsNoTracking().Select(m => m.KullaniciId).Distinct().ToList();
                    var list2 = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi == true).AsNoTracking().Select(m => m.ArkadasKullaniciId).Distinct().ToList();
                    model.ArkadasiOlanUyeSayisi = list1.Union(list2).Count();
                    model.ArkadasiOlmayanUyeSayisi = model.AktifUyeSayisi - model.ArkadasiOlanUyeSayisi;
                    model.OrtalamaArkadaşSayisi = (float)(readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi == true).AsNoTracking().Count() * 2) / (float)model.AktifUyeSayisi;

                    model.BekleyenArkadaslikIstekleri = readOnlyRepository.GetQueryable<ArkadaslikIstek>(p => p.AktifMi == true && p.ArkadaslikKabulDurumTipId == 1).AsNoTracking().Count();
                    model.OnaylanmisArkadaslikIstekleri = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi == true).AsNoTracking().Count();

                    model.ToplamBildirimSayisi = readOnlyRepository.GetQueryable<Bildirim>(p => p.AktifMi == true).AsNoTracking().Count();
                    model.OkunmusBildirimSayisi = readOnlyRepository.GetQueryable<Bildirim>(p => p.AktifMi == true && p.OkunduMu == true).AsNoTracking().Count();
                    model.OkunmamisBildirimSayisi = readOnlyRepository.GetQueryable<Bildirim>(p => p.AktifMi == true && p.OkunduMu == false).AsNoTracking().Count();

                    model.ToplamUrunSayisi = readOnlyRepository.GetQueryable<Urun>().AsNoTracking().Count();
                    model.AktifUrunSayisi = readOnlyRepository.GetQueryable<Urun>(p => p.AktifMi == true).AsNoTracking().Count();
                    model.PasifUrunSayisi = readOnlyRepository.GetQueryable<Urun>(p => p.AktifMi == false).AsNoTracking().Count();

                    model.ToplamGoruntulenmeSayisi = readOnlyRepository.GetQueryable<Urun>(p => p.AktifMi == true).AsNoTracking().Sum(p => p.GoruntulenmeSayisi);
                    model.ToplamYonlendirmeSayisi = readOnlyRepository.GetQueryable<Urun>(p => p.AktifMi == true).AsNoTracking().Sum(p => p.YonlendirmeSayisi);

                    model.ToplamMarkaSayisi = readOnlyRepository.GetQueryable<Marka>().AsNoTracking().Count();
                    model.AktifMarkaSayisi = readOnlyRepository.GetQueryable<Marka>(p => p.AktifMi == true).AsNoTracking().Count();
                    model.PasifMarkaSayisi = readOnlyRepository.GetQueryable<Marka>(p => p.AktifMi == false).AsNoTracking().Count();

                    model.ToplamMesajSayisi = readOnlyRepository.GetQueryable<KullaniciMesaj>(p => p.AktifMi == true).AsNoTracking().Count();
                    model.OrtalamaMesajSayisi = (float)model.ToplamMesajSayisi / (float)model.AktifUyeSayisi;

                    model.ToplamGonderilenHediyeKartSayisi = readOnlyRepository.GetQueryable<KullaniciHediyeKart>(p => p.AktifMi == true).AsNoTracking().Count();
                    model.OrtalamaGonderilenHediyeKartSayisi = (float)model.ToplamGonderilenHediyeKartSayisi / (float)model.AktifUyeSayisi;
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "ProgramDataService", "PanelAnasayfaRaporlariGetir"));
                }

                scope.Complete();
            }

            return model;
        }
        #endregion

        #region FrontEnd

        #endregion

        #endregion
    }
}
