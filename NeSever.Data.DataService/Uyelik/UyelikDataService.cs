using AutoMapper;
using HappyFit.Data.Context.UnitOfWork;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Models;
using NeSever.Common.Models.Admin.AramaSonucVM;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Urun;
using NeSever.Common.Models.Uyelik;
using NeSever.Common.Utils.Encryption;
using NeSever.Common.Utils.StringHelper;
using NeSever.Data.Context;
using NeSever.Data.DataService._RawQueries;
using NeSever.Data.Entities;
using NeSever.Data.Entities.RawEntities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using X.PagedList;

namespace NeSever.Data.DataService.Uyelik
{
    public interface IUyelikDataService
    {

        #region Kullanici
        Task<Kullanici> Kayit(Kullanici kullanici);
        Task<int> Update(Kullanici kullanici);
        Task<int> Delete(int id);
        Task<Kullanici> KullaniciGetirById(Guid kullaniciId);
        Task<Kullanici> KullaniciGetirByKullaniciAd(string kullaniciAdi);
        Task<Kullanici> KullaniciGetirByEPostaKullaniciAdSifre(string epostaKullaniciAd, string sifre);
        Task<Kullanici> KullaniciGetirByEPosta(string email);
        Task<Kullanici> KullaniciGetirByToken(string refrehToken);
        Task<IEnumerable<KullaniciSehir>> SehirleriGetir();
        Task<KullaniciVM> KullaniciGetirByKullaniciAdi(string kullaniciAdi);
        Task<List<KullaniciVM>> KisiAra(KisiAraVM vm);
        Task<ProfilSagMenuVM> ProfilSagMenuGetir(ProfilSagMenuAraVM model);

        Task<bool> KullaniciArkadasKullaniciMi(Guid kullaniciId, Guid kullaniciArkadasId);
        Task<bool> KullaniciArkadasiminArkadasiMi(Guid kullaniciId, Guid kullaniciArkadasId);
        Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiModalGetir(KullaniciArkadasListesiModalAramaVM model);
        Task<int> KullaniciGoruntulenmeSayisiArtir(Guid kullaniciId);
        Task<bool> KullaniciBakilanProfilEkle(KullaniciBakilanProfillerVM bakilanProfilVM);
        Task<bool> KullaniciBakilanProfilSil(BakilanProfilSilVM bakilanProfil);
        Task<bool> BakilanTumProfilleriSil(KullaniciVM vm);
        Task<List<KullaniciBakilanProfillerVM>> KullaniciBakilanProfilleriGetir(Guid kullaniciId);
        Task<int> KullaniciBakilanProfilSayiGetir(Guid kullaniciId);
        Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciBakilanProfillerModalGetir(KullaniciArkadasListesiModalAramaVM model);
        Task<List<ArkadasListesiKullaniciArkadasVM>> KullaniciBakilanProfillerListModalGetir(Guid kullaniciId, int start, int length);
        Task<bool> KullaniciSil(Guid kullaniciId);
        Task<bool> KullaniciAdiVarmi(KullaniciAdiVM kullanici);

        Task<List<BildirimKullaniciGetirVM>> BildirimKullaniciListGetir(KisiyeOzelBildirimVM data);
        Task<int> ArkadaslikIstekDurumGetir(Guid KullaniciId);
        Task<int> KullaniciAdresSayisiGetir(Guid kullaniciId);
        Task<int> KullaniciSiparisSayisiGetir(Guid kullaniciId);


        #endregion

        #region Arkadas

        Task<bool> ArkadasIstekVarMi(Guid kullaniciId, Guid kullaniciArkadasId);
        Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> ArkadasListesiGetir(ArkadasListeAramaVM arkadaListeAramaVM, Guid kullaniciId);
        Task<IEnumerable<KullaniciArkadas>> ArkadasListesiGetir();
        Task<IEnumerable<KullaniciArkadas>> ArkadasListesiGetir(Guid kullaniciId);
        Task<List<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiGetir(Guid kullaniciId);
        Task<List<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiGetirModal(Guid kullaniciId, int start, int length);
        Task<IEnumerable<ArkadaslikIstek>> ArkadasIstekleriniGetir(Guid KullaniciId);
        Task<ArkadaslikIstek> ArkadasIstekGetir(Guid KullaniciId, Guid ArkadasIstekKullaniciId);
        Task<KullaniciArkadas> ArkadasKaydet(KullaniciArkadas arkadas);
        Task<int> ArkadasIstekKaldir(ArkadaslikIstek arkadalikIstek);
        Task<IPagedList<ArkadasVM>> ArkadasAramaListGetir(ArkadasAramaVM arkadaListeAramaVM);
        Task<int> ArkadasIstekKaydet(ArkadaslikIstek arkadalikIstek);
        Task<int> ArkadasIstekGuncelle(ArkadaslikIstek arkadalikIstek);
        Task<int> KullaniciMesajKaydet(KullaniciMesaj mesaj);
        Task<KullaniciArkadas> KullaniciArkadasGetir(Guid kullaniciId, Guid kullaniciArkadasId);
        Task<int> KullaniciArkadasGuncelle(KullaniciArkadas arkadaslik);
        Task<ResultModel<KullaniciArkadasVM>> KullaniciArkadasListesiGetirDogumGunleriIcin(Guid kullaniciId);
        Task<IPagedList<ArkadasKonusmaListesiVM>> ArkadasMesajListGetir(ArkadasMesajListeVM mesajAramaVM, Guid kullaniciId);
        Task<IEnumerable<KullaniciArkadas>> ArkadasAra(ArkadasAraVM vm);
        Task<IEnumerable<KullaniciMesaj>> MesajDetayGetir(MesajDetayGetirVM vm);
        Task<int> KonusmaSil(KonusmaSilVM vm, Guid silenKullaniciId);
        Task<KullaniciMesaj> MesajGetir(int mesajId);
        Task<int> MesajSil(KullaniciMesaj mesaj);
        int KullaniciArkadasSayisiGetir(Guid kullaniciId);
        int KullaniciMesajSayisiGetir(Guid kullaniciId);
        int KullaniciBildirimSayisiGetir(Guid kullaniciId);
        int KullaniciArkadasIstekSayisiGetir(Guid kullaniciId);
        int KullaniciHediyeKartiSayisiGetir(Guid kullaniciId);
        //TODO ŞG: Üst menü arama alanı için kullanılacak.
        //Task<IEnumerable<HizliArkadasAraSonucVM>> HizliArkadasListeGetir(HizliArkadasAraVM vm);




        Task<IEnumerable<ArkadaslikIstek>> OkunmamisArkadasIstekleriniGetir(Guid KullaniciId);

        Task<int> ArkadaslikIstekleriniOku(IEnumerable<ArkadaslikIstek> istek);

        Task<int> ArkadaslikIstekSil(Guid kullaniciId, Guid arkadasKullaniciId);
        Task<bool> BanaArkadaslikIstekVarMi(Guid kullaniciId, Guid kullaniciArkadasId);
        Task<int> KullaniciArkadaslikDurumu(Guid kullaniciId, Guid arkadasKullaniciId);

        #endregion

        #region ProfilEngel

        #region Admin

        #endregion

        #region FrontEnd

        Task<ProfilEngelVM> ProfilEngelKaydet(ProfilEngelVM model);
        Task<ProfilEngelVM> ProfilEngelSil(ProfilEngelVM model);
        Task<IPagedList<ProfilEngelKisiVM>> ProfilEngelListGetir(EngellenenProfilListesiAramaVM model);

        #endregion

        #endregion

        #region ProfilSikayet

        #region Admin
        Task<List<ProfilSikayetAramaSonucVM>> ProfilSikayetArama(ProfilSikayetAramaVM model);
        #endregion

        #region FrontEnd

        Task<bool> ProfilSikayetKaydet(ProfilSikayetVM model);

        #endregion

        #endregion

        #region KullaniciHobi

        #region Admin       

        #endregion

        #region FrontEnd
        Task<List<KullaniciHobiVM>> KullaniciHobiGetir(Guid kullaniciId);
        Task<IEnumerable<Hobi>> HobileriGetir(string query);
        Task<KullaniciHobiVeIlgiAlanVM> KullaniciHobiIlgiAlanGetir(Guid kullaniciId);
        Task<bool> KullaniciHobiKaydetGuncelle(KullaniciHobiKaydetGuncelleVM model);
        #endregion

        #endregion

        #region KullaniciIlgiAlan

        #region Admin       

        #endregion

        #region FrontEnd
        Task<List<KullaniciIlgiAlanVM>> KullaniciIlgiAlanGetir(Guid kullaniciId);
        Task<IEnumerable<IlgiAlan>> IlgiAlanlariniGetir(string query);
        Task<bool> KullaniciIlgiAlanKaydetGuncelle(KullaniciIlgiAlanKaydetGuncelleVM model);

        #endregion

        #endregion

        #region KullaniciUrun

        #region Admin       

        #endregion

        #region FrontEnd

        Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeEkle(KullaniciUrunEkleSilVM model);
        Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeSil(KullaniciUrunEkleSilVM model);
        Task<IPagedList<UrunIcerikVM>> KullaniciHediyeSepetiGetir(KullaniciUrunListesiAramaVM model);
        int KullaniciHediyeSepetiSayisiGetir(Guid kullaniciId);

        #endregion

        #endregion

        #region KullaniciResim
        Task<KullaniciResim> KullaniciProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResim);
        Task<KullaniciResim> KullaniciResimKaydet(KullaniciResim kullaniciResim);
        Task<KullaniciResimVM> KullaniciResimGetir(Guid kullaniciId);
        Task<List<KullaniciResimVM>> KullaniciResimListele(string kullaniciId);
        Task<int> KullaniciResimSayisiGetir(Guid kullaniciId);
        Task<int> ProfilResminiDegistir(Guid kullaniciId, int resimId);
        Task<int> KullaniciResimSil(Guid kullaniciId, int resimId);
        Task<IPagedList<KullaniciResimVM>> KullaniciListesiResimGetir(int start, int length, Guid kullaniciId);
        Task<KullaniciResimVM> KullaniciResimGetirByResimId(int resimId);

        Task<KullaniciResim> KullaniciProfilResmiSil(KullaniciResim kullaniciResim);
        Task<KullaniciResim> KullaniciProfilResimGetir(string kullaniciId);
        Task<KullaniciResim> KullaniciBuyukProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResim);
        Task<KullaniciResim> KullaniciBuyukProfilResimGetir(Guid KullaniciId);
        #endregion

        #region DuvarResim
        Task<List<DuvarResimVM>> DuvarResimleriniGetir();

        Task<int> KullaniciDuvarResimDegistir(Guid kullaniciId, int resimId);

        Task<DuvarResimVM> KullaniciDuvarResimGetir(Guid kullaniciId);
        #endregion

        #region KullaniciHediyeKart
        Task<int> KullaniciHediyeKartKayit(KullaniciHediyeKartKayitVM model);
        Task<IPagedList<HediyeKartKonusmaListesiVM>> HediyeKartListGetir(HediyeKartListeVM hediyeKartAramaVM, Guid kullaniciId);

        Task<IEnumerable<KullaniciHediyeKart>> HediyeKartDetayGetir(HediyeKartDetayGetirVM vm);

        Task<int> HediyeKartSil(KullaniciHediyeKart hediyeKart);

        Task<KullaniciHediyeKart> HediyeKartGetir(int hediyeKartId);

        Task<int> HediyeKartKonusmaSil(KonusmaSilVM vm, Guid silenKullaniciId);

        Task<HediyeKartIcerikVM> HediyeKartMesajIcerikGetirById(int id);
        Task<int> HediyeKartOkunduIsaretle(HediyeKartOkunduVM hediyeKartOkundu);


        #endregion

        #region KullaniciBildirim
        Task<IPagedList<KullaniciBildirimVM>> KullaniciBildirimListGetir(KullaniciBildirimListeVM model);
        Task<bool> KullaniciBildirimEkle(KullaniciBildirimVM kullaniciBildirim);
        Task<bool> KullaniciBildirimSil(KullaniciBildirimVM kullaniciBildirim);
        Task<List<KullaniciBildirimVM>> KullaniciHeaderBildirimListGetir(Guid kullaniciId);
        Task<bool> KullaniciBildirimOkundu(Guid kullaniciId);
        Task<int> TopluBildirimGonder(IletisimTopluBildirimVM bildirim);
        Task<List<BildirimAramaResultVM>> TumBildirimleriGetir(BildirimAramaVM bildirimAramaVM);
        Task<int> BildirimSil(int id);
        Task<bool> KullaniciTumBildirimleriSil(Guid kullaniciId);
        Task<int> BildirimSayisiGetir(IletisimTopluBildirimVM bildirim);
        Task<int> KisiyeOzelBildirimGonder(KisiyeOzelBildirimVM bildirim);
        Task<KullaniciBildirimVM> BildirimIdBildirimGetir(int id);
        Task<List<KisiyeOzelBildirimAramaSonucVM>> KisiyeOzelBildirimleriGetir(BildirimAramaVM bildirimAramaVM);
        Task<int> KullaniciHeaderSepetUrunSayisiGetir(Guid kullaniciId);
        #endregion

        #region Şifremi Unuttum
        Task<ResultModel> KullaniciYeniSifreGonder(KullaniciSifreGonderVM model, Common.Models.Program.AyarlarVM ayarlar);
        #endregion

        #region Kullanici Künye
        Task<int> KullaniciOkunmamisArkadaslikIstegiSayisiGetir(Guid kullaniciId);
        Task<int> ProfilEngelSayisiGetir(Guid kullaniciId);

        #endregion

        #region Kullanıcı Mesaj
        Task<int> OkunmamisMesajSayisiGetir(Guid kullaniciId);

        Task<IEnumerable<KullaniciMesaj>> OkunmamisMesajlariGetir(MesajDetayGetirVM vm);

        Task<int> MesajlariOku(IEnumerable<KullaniciMesaj> istek);
        #endregion

        Task<bool> KullaniciHosgeldinEpostaGonder(KullaniciKayitVM vm, Common.Models.Program.AyarlarVM ayarlar);
    }

    public class UyelikDataService : BaseDataService, IUyelikDataService
    {

        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IRepository repository;
        private readonly IReadOnlyRepository readOnlyRepository;
        private readonly ILogger<UyelikDataService> logger;
        private bool fileServerIsActive;
        private readonly IUrunDataService urunDataService;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public UyelikDataService(IUnitOfWork unitOfWork,
                                 IMapper mapper,
                                 IRepository repository,
                                 IReadOnlyRepository readOnlyRepository,
                                 ILogger<UyelikDataService> logger,
                                 IUrunDataService urunDataService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.logger = logger;
            this.urunDataService = urunDataService;

            var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings");
            if (appSettings != null)
            {
                fileServerIsActive = Convert.ToBoolean(appSettings["FileServerIsActive"]);
            }
        }


        #region Kullanici
        public async Task<int> Delete(int id)
        {
            repository.Delete<Kullanici>(id);
            return await SaveChanges();
        }

        public async Task<Kullanici> Kayit(Kullanici kullanici)
        {
            repository.Create(kullanici);

            try
            {
                await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return kullanici;

        }

        public async Task<int> Update(Kullanici kullanici)
        {
            try
            {
                repository.Update(kullanici);
                var updateResult = await SaveChanges();

                return updateResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }

        public async Task<Kullanici> KullaniciGetirById(Guid kullaniciId)
        {
            return await readOnlyRepository.GetQueryable<Kullanici>()
                     .IncludeMultiple(x => x.KullaniciArkadasKullanici, m => m.KullaniciMesajAliciKullanici, i => i.ArkadaslikIstekKullanici, s => s.KullaniciSehir)
                    .FirstOrDefaultAsync(p => p.KullaniciId == kullaniciId);
        }

        public async Task<Kullanici> KullaniciGetirByKullaniciAd(string kullaniciAdi)
        {
            return await readOnlyRepository.GetQueryable<Kullanici>().FirstOrDefaultAsync(p => p.KullaniciAdi == kullaniciAdi);
        }

        public async Task<Kullanici> KullaniciGetirByEPostaKullaniciAdSifre(string epostaKullaniciAd, string sifre)
        {
            return await readOnlyRepository.GetQueryable<Kullanici>().IncludeMultiple(p => p.KullaniciRol)
                .FirstOrDefaultAsync(p => (p.Eposta == epostaKullaniciAd || p.KullaniciAdi == epostaKullaniciAd) && p.Sifre == sifre);
        }

        public async Task<Kullanici> KullaniciGetirByToken(string refreshToken)
        {
            return await readOnlyRepository.GetQueryable<Kullanici>().IncludeMultiple(p => p.KullaniciRol, s => s.KullaniciSehir)
                .FirstOrDefaultAsync(p => p.RefreshToken == refreshToken);
        }

        public async Task<Kullanici> KullaniciGetirByEPosta(string eposta)
        {
            return await readOnlyRepository.GetQueryable<Kullanici>()
                    .FirstOrDefaultAsync(p => p.Eposta == eposta);
        }

        public async Task<IEnumerable<KullaniciSehir>> SehirleriGetir()
        {
            return await readOnlyRepository.GetQueryable<KullaniciSehir>().Where(p => p.KullaniciUlkeId == 223).ToListAsync();
        }

        public async Task<KullaniciVM> KullaniciGetirByKullaniciAdi(string kullaniciAdi)
        {
            return await readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.KullaniciAdi == kullaniciAdi)
                      .Select(p => new KullaniciVM
                      {
                          Adi = p.Adi,
                          Soyadi = p.Soyadi,
                          Eposta = p.Eposta,
                          KullaniciAdi = p.KullaniciAdi,
                          KullaniciId = p.KullaniciId
                      })
                      .SingleOrDefaultAsync();
        }
        public async Task<List<KullaniciVM>> KisiAra(KisiAraVM vm)
        {
            List<KullaniciVM> result = new List<KullaniciVM>();
            IQueryable<Kullanici> query = null;
            try
            {
                string aramaKelime = vm.AramaKelime.ToLower(new CultureInfo("tr-TR")).Trim();
                string aramaKelimeEn = vm.AramaKelime.RemoveDiacritics().ToLower().Trim();

                query = readOnlyRepository.GetQueryable<Kullanici>(p => p.AktifMi);

                if (vm.KullaniciId != null)
                    query = query.Where(p => p.KullaniciId != vm.KullaniciId);

                if (aramaKelime == aramaKelimeEn)
                {

                    query = query.Where(p => (
                                                                               p.KullaniciAdi.StartsWith(aramaKelime) ||
                                                                               p.Adi.StartsWith(aramaKelime) ||
                                                                               p.Soyadi.StartsWith(aramaKelime) ||
                                                                               (p.Adi + " " + p.Soyadi).Contains(aramaKelime)
                                                                          )
                                                                        );
                }
                else
                {
                    query = query.Where(p => (
                                                                               p.KullaniciAdi.StartsWith(aramaKelime) ||
                                                                               p.Adi.StartsWith(aramaKelime) ||
                                                                               p.Soyadi.StartsWith(aramaKelime) ||
                                                                               (p.Adi + " " + p.Soyadi).Contains(aramaKelime) ||
                                                                               p.KullaniciAdi.StartsWith(aramaKelimeEn) ||
                                                                               p.Adi.StartsWith(aramaKelimeEn) ||
                                                                               p.Soyadi.StartsWith(aramaKelimeEn) ||
                                                                               (p.Adi + " " + p.Soyadi).Contains(aramaKelimeEn)
                                                                           )
                                                                  );
                }
                var liste = await query.Take(vm.Length).ToListAsync();
                foreach (var item in liste)
                {
                    KullaniciVM kullaniciVM = mapper.Map<Kullanici, KullaniciVM>(item);
                    result.Add(kullaniciVM);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }



            //return await readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.Adi.Contains(kullaniciAdi) || p.Soyadi.Contains(kullaniciAdi))
            //          .Select(p => new KullaniciVM
            //          {
            //              Adi = p.Adi,
            //              Soyadi = p.Soyadi,
            //              KullaniciAdi = p.KullaniciAdi,
            //              KullaniciId = p.KullaniciId
            //          })
            //          .ToListAsync();
        }
        public async Task<ProfilSagMenuVM> ProfilSagMenuGetir(ProfilSagMenuAraVM model)
        {
            var profilP = new SqlParameter("@KullaniciId", model.KullaniciId);

            var profilData = readOnlyRepository.GetFromQuery<ProfilRaw>(UyelikRawQueries.ProfilGetir, profilP);
            var profil = mapper.Map<ProfilRaw, ProfilSagMenuUyeVM>(profilData);

            ProfilSagMenuVM result = new ProfilSagMenuVM()
            {
                Profil = profil,
            };

            return result;
        }

        public async Task<bool> KullaniciBakilanProfilEkle(KullaniciBakilanProfillerVM bakilanProfilVM)
        {
            try
            {
                KullaniciBakilanProfiller bakilanProfil = new KullaniciBakilanProfiller()
                {
                    KullaniciId = bakilanProfilVM.KullaniciId,
                    BakilanKullaniciId = bakilanProfilVM.BakilanKullaniciId,
                    BakilanTarih = DateTime.Now
                };
                var dahaOnceBakildiMi = await readOnlyRepository.GetQueryable<KullaniciBakilanProfiller>()
                .FirstOrDefaultAsync(p => (p.KullaniciId == bakilanProfil.KullaniciId && p.BakilanKullaniciId == bakilanProfil.BakilanKullaniciId) ||
                                        (p.KullaniciId == bakilanProfil.KullaniciId && p.BakilanKullaniciId == bakilanProfil.BakilanKullaniciId));
                if (dahaOnceBakildiMi == null)
                {
                    repository.Create(bakilanProfil);
                    await SaveChanges();
                }
                else
                {
                    dahaOnceBakildiMi.BakilanTarih = DateTime.Now;
                    repository.Update(dahaOnceBakildiMi);
                    await SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> KullaniciBakilanProfilSil(BakilanProfilSilVM bakilanProfil)
        {
            try
            {
                var bakilan = await KullaniciGetirByKullaniciAd(bakilanProfil.BakilanKullaniciAdi);
                var query = await readOnlyRepository.GetQueryable<KullaniciBakilanProfiller>(k => k.KullaniciId == bakilanProfil.KullaniciId && k.BakilanKullaniciId == bakilan.KullaniciId)
                .IncludeMultiple(x => x.Kullanici).FirstOrDefaultAsync();

                repository.Delete(query);
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> BakilanTumProfilleriSil(KullaniciVM vm)
        {
            try
            {
                var query = await readOnlyRepository.GetQueryable<KullaniciBakilanProfiller>(k => k.KullaniciId == vm.KullaniciId)
                .IncludeMultiple(x => x.Kullanici).ToListAsync();

                foreach (KullaniciBakilanProfiller item in query)
                {
                    repository.Delete(item);
                }
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> KullaniciBakilanProfilSayiGetir(Guid kullaniciId)
        {
            return await readOnlyRepository.GetQueryable<KullaniciBakilanProfiller>(p => p.KullaniciId == kullaniciId).AsNoTracking().CountAsync();
        }

        public async Task<List<KullaniciBakilanProfillerVM>> KullaniciBakilanProfilleriGetir(Guid kullaniciId)
        {
            var query = await readOnlyRepository.GetQueryable<KullaniciBakilanProfiller>(p => p.KullaniciId == kullaniciId).AsNoTracking().IncludeMultiple(x => x.Kullanici).ToListAsync();

            var bakilanProfiller = query.Select(p => new KullaniciBakilanProfillerVM
            {
                KullaniciId = p.KullaniciId,
                BakilanKullaniciId = p.BakilanKullaniciId,
                BakilanTarih = p.BakilanTarih
            }).ToList();

            return bakilanProfiller;
        }
        public async Task<int> ArkadaslikIstekDurumGetir(Guid KullaniciId)
        {
            var kullanici = readOnlyRepository.GetQueryable<Kullanici>(p => p.KullaniciId == KullaniciId).AsNoTracking().FirstOrDefault();

            return kullanici.ArkadasIstekTalepleriDurum;
        }

        public async Task<int> KullaniciAdresSayisiGetir(Guid kullaniciId)
        {
            return readOnlyRepository.GetQueryable<Adres>(p => p.KullaniciId == kullaniciId && p.AktifMi == true).Count();
        }

        public async Task<int> KullaniciSiparisSayisiGetir(Guid kullaniciId)
        {
            return readOnlyRepository.GetQueryable<Siparis>(p => p.KullaniciId == kullaniciId && p.AktifMi == true).Count();
        }

        #endregion

        #region Arkadas
        public async Task<IEnumerable<KullaniciArkadas>> ArkadasListesiGetir()
        {
            return await readOnlyRepository.GetQueryable<KullaniciArkadas>()
                .IncludeMultiple(x => x.ArkadasKullanici, s => s.ArkadasKullanici.KullaniciSehir).ToListAsync();
        }

        public async Task<IEnumerable<KullaniciArkadas>> ArkadasListesiGetir(Guid kullaniciId)
        {
            return await readOnlyRepository.GetQueryable<KullaniciArkadas>(x => x.KullaniciId == kullaniciId)
                .IncludeMultiple(x => x.ArkadasKullanici, s => s.ArkadasKullanici.KullaniciSehir).ToListAsync();
        }

        public async Task<List<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiGetir(Guid kullaniciId)
        {
            var query = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi &&
                                                                      p.KullaniciId == kullaniciId).IncludeMultiple(x => x.ArkadasKullanici, s => s.ArkadasKullanici.KullaniciSehir,
                                                                       k => k.ArkadasKullanici.DuvarResim, v => v.ArkadasKullanici.KullaniciResim).AsNoTracking();

            var query2 = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi &&
                                                                    p.ArkadasKullaniciId == kullaniciId).IncludeMultiple(x => x.Kullanici, s => s.Kullanici.KullaniciSehir,
                                                                       k => k.Kullanici.DuvarResim, v => v.Kullanici.KullaniciResim).AsNoTracking();

            var arkadasKullaniciList = await query
                                            .Include("ArkadasKullanici")
                                            .Include("ArkadasKullanici.KullaniciSehir")
                                            .Include("ArkadasKullanici.KullaniciResim")
                                            .Include("ArkadasKullanici.DuvarResim")
                                            .Select(p => new ArkadasListesiKullaniciArkadasVM
                                            {
                                                KullaniciId = p.ArkadasKullanici.KullaniciId,
                                                KullaniciAdi = p.ArkadasKullanici.KullaniciAdi,
                                                Adi = p.ArkadasKullanici.Adi,
                                                Soyadi = p.ArkadasKullanici.Soyadi,
                                                DogumTarihi = p.ArkadasKullanici.DogumTarihi.HasValue ? p.ArkadasKullanici.DogumTarihi.Value : new DateTime(1900, 1, 1),
                                                KayitTarihi = p.KayitTarihi,
                                                Sehir = p.ArkadasKullanici.KullaniciSehir == null ? "" : p.ArkadasKullanici.KullaniciSehir.KullaniciSehirAdi,
                                                Hakkinda = p.ArkadasKullanici.Hakkinda,
                                                DuvarResimBase64 = p.ArkadasKullanici.DuvarResim != null && p.ArkadasKullanici.DuvarResim.KucukResim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.ArkadasKullanici.DuvarResim.KucukResim)) : "/Uploads/ProfileTopHeader/top_header_23.jpg",
                                                ProfilResmiBase64 = p.ArkadasKullanici.KullaniciResim.Any() && p.ArkadasKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.ArkadasKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                                                HediyeSepetiUrunSayisi = 0,
                                                ArkadasSayisi = 0
                                            })
                                            .ToListAsync();

            var arkadasKullaniciList2 = await query2
                                            .Include("ArkadasKullanici")
                                            .Include("ArkadasKullanici.KullaniciSehir")
                                            .Include("ArkadasKullanici.KullaniciResim")
                                            .Include("ArkadasKullanici.DuvarResim")
                                            .Select(p => new ArkadasListesiKullaniciArkadasVM
                                            {
                                                KullaniciId = p.Kullanici.KullaniciId,
                                                KullaniciAdi = p.Kullanici.KullaniciAdi,
                                                Adi = p.Kullanici.Adi,
                                                Soyadi = p.Kullanici.Soyadi,
                                                DogumTarihi = p.Kullanici.DogumTarihi.HasValue ? p.Kullanici.DogumTarihi.Value : new DateTime(1900, 1, 1),
                                                KayitTarihi = p.KayitTarihi,
                                                Sehir = p.Kullanici.KullaniciSehir == null ? "" : p.Kullanici.KullaniciSehir.KullaniciSehirAdi,
                                                Hakkinda = p.Kullanici.Hakkinda,
                                                DuvarResimBase64 = p.Kullanici.DuvarResim != null && p.Kullanici.DuvarResim.KucukResim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Kullanici.DuvarResim.KucukResim)) : "/Uploads/ProfileTopHeader/top_header_23.jpg",
                                                ProfilResmiBase64 = p.Kullanici.KullaniciResim.Any() && p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                                                HediyeSepetiUrunSayisi = 0,
                                                ArkadasSayisi = 0
                                            })
                                            .ToListAsync();

            if (arkadasKullaniciList2 != null)
            {
                foreach (ArkadasListesiKullaniciArkadasVM item in arkadasKullaniciList2)
                    arkadasKullaniciList.Add(item);
            }

            return arkadasKullaniciList;
        }

        public async Task<List<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiGetirModal(Guid kullaniciId, int start, int length)
        {

            var query = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi &&
                                                                      p.KullaniciId == kullaniciId).IncludeMultiple(x => x.ArkadasKullanici, s => s.ArkadasKullanici.KullaniciSehir,
                                                                       k => k.ArkadasKullanici.DuvarResim, v => v.ArkadasKullanici.KullaniciResim);

            var query2 = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi &&
                                                                    p.ArkadasKullaniciId == kullaniciId).IncludeMultiple(x => x.Kullanici, s => s.Kullanici.KullaniciSehir,
                                                                       k => k.Kullanici.DuvarResim, v => v.Kullanici.KullaniciResim);

            var arkadasKullaniciList = query
                                            .Include("ArkadasKullanici")
                                            .Include("ArkadasKullanici.KullaniciSehir")
                                            .Include("ArkadasKullanici.KullaniciResim")
                                            .Include("ArkadasKullanici.DuvarResim")
                                            .Select(p => new ArkadasListesiKullaniciArkadasVM
                                            {
                                                KullaniciId = p.ArkadasKullanici.KullaniciId,
                                                KullaniciAdi = p.ArkadasKullanici.KullaniciAdi,
                                                Adi = p.ArkadasKullanici.Adi,
                                                Soyadi = p.ArkadasKullanici.Soyadi,
                                                DogumTarihi = p.ArkadasKullanici.DogumTarihi.HasValue ? p.ArkadasKullanici.DogumTarihi.Value : new DateTime(1900, 1, 1),
                                                KayitTarihi = p.KayitTarihi,
                                                Sehir = p.ArkadasKullanici.KullaniciSehir == null ? "" : p.ArkadasKullanici.KullaniciSehir.KullaniciSehirAdi,
                                                Hakkinda = p.ArkadasKullanici.Hakkinda,
                                                DuvarResimBase64 = p.ArkadasKullanici.DuvarResim != null && p.ArkadasKullanici.DuvarResim.KucukResim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.ArkadasKullanici.DuvarResim.KucukResim)) : "/Uploads/ProfileTopHeader/top_header_23.jpg",
                                                ProfilResmiBase64 = p.ArkadasKullanici.KullaniciResim.Any() && p.ArkadasKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.ArkadasKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                                                HediyeSepetiUrunSayisi = 0,
                                                ArkadasSayisi = 0,
                                                ArkadaslikIstekDurum = 0
                                            })
                                            .ToList();

            var arkadasKullaniciList2 = query2
                                            .Include("ArkadasKullanici")
                                            .Include("ArkadasKullanici.KullaniciSehir")
                                            .Include("ArkadasKullanici.KullaniciResim")
                                            .Include("ArkadasKullanici.DuvarResim")
                                            .Select(p => new ArkadasListesiKullaniciArkadasVM
                                            {
                                                KullaniciId = p.Kullanici.KullaniciId,
                                                KullaniciAdi = p.Kullanici.KullaniciAdi,
                                                Adi = p.Kullanici.Adi,
                                                Soyadi = p.Kullanici.Soyadi,
                                                DogumTarihi = p.Kullanici.DogumTarihi.HasValue ? p.Kullanici.DogumTarihi.Value : new DateTime(1900, 1, 1),
                                                KayitTarihi = p.KayitTarihi,
                                                Sehir = p.Kullanici.KullaniciSehir == null ? "" : p.Kullanici.KullaniciSehir.KullaniciSehirAdi,
                                                Hakkinda = p.Kullanici.Hakkinda,
                                                DuvarResimBase64 = p.Kullanici.DuvarResim != null && p.Kullanici.DuvarResim.KucukResim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Kullanici.DuvarResim.KucukResim)) : "/Uploads/ProfileTopHeader/top_header_23.jpg",
                                                ProfilResmiBase64 = p.Kullanici.KullaniciResim.Any() && p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                                                HediyeSepetiUrunSayisi = 0,
                                                ArkadasSayisi = 0,
                                                ArkadaslikIstekDurum = 0
                                            })
                                            .ToList();

            if (arkadasKullaniciList2 != null)
            {
                foreach (ArkadasListesiKullaniciArkadasVM item in arkadasKullaniciList2)
                    arkadasKullaniciList.Add(item);
            }

            List<ArkadasListesiKullaniciArkadasVM> arkadasListSon = new List<ArkadasListesiKullaniciArkadasVM>();

            if (arkadasKullaniciList.Count > (start * length))
            {
                for (var i = (start * length); i < ((start + 1) * length) && i < arkadasKullaniciList.Count; i++)
                {
                    arkadasListSon.Add(arkadasKullaniciList[i]);
                }
            }
            else
            {
                arkadasListSon = arkadasKullaniciList;
            }


            return arkadasListSon;
        }

        public async Task<ResultModel<KullaniciArkadasVM>> KullaniciArkadasListesiGetirDogumGunleriIcin(Guid kullaniciId)
        {
            var kullaniciArkadasListesiSonuc = new ResultModel<KullaniciArkadasVM>
            {
                Type = ResultType.Basarisiz,
                Data = new KullaniciArkadasVM()
            };

            var query = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi &&
                                                                         (p.KullaniciId == kullaniciId || p.ArkadasKullaniciId == kullaniciId)).IncludeMultiple(x => x.ArkadasKullanici, v => v.ArkadasKullanici.KullaniciResim);

            var arkadasKullaniciList = query.Where(p => p.ArkadasKullaniciId != kullaniciId)
                                            .Include("ArkadasKullanici")
                                            .Include("ArkadasKullanici.KullaniciSehir")
                                            .Include("ArkadasKullanici.KullaniciResim")
                                            .Include("ArkadasKullanici.DuvarResim")
                                            .Select(p => new ArkadasVM
                                            {
                                                KullaniciId = p.ArkadasKullanici.KullaniciId,
                                                KullaniciAdi = p.ArkadasKullanici.KullaniciAdi,
                                                Adi = p.ArkadasKullanici.Adi,
                                                Soyadi = p.ArkadasKullanici.Soyadi,
                                                DogumTarihi = p.ArkadasKullanici.DogumTarihi.HasValue ? p.ArkadasKullanici.DogumTarihi.Value : new DateTime(1900, 1, 1),
                                                ProfilResmiBase64 = p.ArkadasKullanici.KullaniciResim.Any() && p.ArkadasKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.ArkadasKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                                            })
                                            .ToList();

            var kullaniciArkadasList = query.Where(p => p.KullaniciId != kullaniciId)
                                            .Include("ArkadasKullanici")
                                            .Include("ArkadasKullanici.KullaniciSehir")
                                            .Include("ArkadasKullanici.KullaniciResim")
                                            .Include("ArkadasKullanici.DuvarResim")
                                            .Select(p => new ArkadasVM
                                            {
                                                KullaniciId = p.Kullanici.KullaniciId,
                                                KullaniciAdi = p.Kullanici.KullaniciAdi,
                                                Adi = p.Kullanici.Adi,
                                                Soyadi = p.Kullanici.Soyadi,
                                                DogumTarihi = p.Kullanici.DogumTarihi.HasValue ? p.Kullanici.DogumTarihi.Value : new DateTime(1900, 1, 1),
                                                ProfilResmiBase64 = p.Kullanici.KullaniciResim.Any() && p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                                            })
                                            .ToList();

            arkadasKullaniciList.AddRange(kullaniciArkadasList);
            arkadasKullaniciList = arkadasKullaniciList.Distinct().ToList();

            kullaniciArkadasListesiSonuc.Data.Arkadaslar.AddRange(arkadasKullaniciList);

            return kullaniciArkadasListesiSonuc;
        }

        public async Task<IEnumerable<ArkadaslikIstek>> ArkadasIstekleriniGetir(Guid KullaniciId)
        {
            try
            {
                return await readOnlyRepository.GetQueryable<ArkadaslikIstek>(k => k.KullaniciId == KullaniciId && k.ArkadaslikKabulDurumTipId == 1)
                    .IncludeMultiple(x => x.ArkadaslikIstekKullanici, p => p.ArkadaslikIstekKullanici.KullaniciResim).OrderByDescending(p => p.KayitTarihi)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ArkadaslikIstek>> OkunmamisArkadasIstekleriniGetir(Guid KullaniciId)
        {
            try
            {
                return await readOnlyRepository.GetQueryable<ArkadaslikIstek>(k => k.AktifMi && !k.OkunduMu && k.KullaniciId == KullaniciId && k.ArkadaslikKabulDurumTipId == 1)
                    .IncludeMultiple(x => x.ArkadaslikIstekKullanici, p => p.ArkadaslikIstekKullanici.KullaniciResim)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ArkadaslikIstekleriniOku(IEnumerable<ArkadaslikIstek> istek)
        {
            repository.UpdateRange<ArkadaslikIstek>(istek);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ArkadaslikIstek> ArkadasIstekGetir(Guid kullaniciId, Guid arkadasIstekKullaniciId)
        {
            return await readOnlyRepository.GetQueryable<ArkadaslikIstek>(k => k.ArkadaslikIstekKullaniciId == arkadasIstekKullaniciId && k.KullaniciId == kullaniciId)
                .IncludeMultiple(x => x.ArkadaslikIstekKullanici).FirstOrDefaultAsync();
        }

        public async Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> ArkadasListesiGetir(ArkadasListeAramaVM arkadaListeAramaVM, Guid kullaniciId)
        {
            IPagedList<ArkadasListesiKullaniciArkadasVM> resultList = new List<ArkadasListesiKullaniciArkadasVM>().ToPagedList();

            try
            {

                var query = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi &&
                                                                       (p.KullaniciId == kullaniciId || p.ArkadasKullaniciId == kullaniciId) &&
                                                                       (string.IsNullOrEmpty(arkadaListeAramaVM.AramaKelime) ||
                                                                        p.ArkadasKullanici.KullaniciAdi.Contains(arkadaListeAramaVM.AramaKelime) ||
                                                                        p.ArkadasKullanici.Adi.Contains(arkadaListeAramaVM.AramaKelime) ||
                                                                        p.ArkadasKullanici.Soyadi.Contains(arkadaListeAramaVM.AramaKelime)))
                                                                       .IncludeMultiple(x => x.ArkadasKullanici, s => s.ArkadasKullanici.KullaniciSehir,
                                                                       k => k.ArkadasKullanici.DuvarResim, v => v.ArkadasKullanici.KullaniciResim);


                var arkadasKullaniciList = query
                                          .Where(p => p.ArkadasKullaniciId != kullaniciId)
                                          .Include("ArkadasKullanici")
                                          .Include("ArkadasKullanici.KullaniciSehir")
                                          .Include("ArkadasKullanici.KullaniciResim")
                                          .Include("ArkadasKullanici.DuvarResim")
                                          .Select(p => new ArkadasListesiKullaniciArkadasVM
                                          {
                                              KullaniciId = p.ArkadasKullanici.KullaniciId,
                                              KullaniciAdi = p.ArkadasKullanici.KullaniciAdi,
                                              Adi = p.ArkadasKullanici.Adi,
                                              Soyadi = p.ArkadasKullanici.Soyadi,
                                              DogumTarihi = p.ArkadasKullanici.DogumTarihi.HasValue ? p.ArkadasKullanici.DogumTarihi.Value : new DateTime(1900, 1, 1),
                                              KayitTarihi = p.KayitTarihi,
                                              Sehir = p.ArkadasKullanici.KullaniciSehir == null ? "" : p.ArkadasKullanici.KullaniciSehir.KullaniciSehirAdi,
                                              Hakkinda = p.ArkadasKullanici.Hakkinda,
                                              DuvarResimBase64 = p.ArkadasKullanici.DuvarResim != null && p.ArkadasKullanici.DuvarResim.KucukResim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.ArkadasKullanici.DuvarResim.KucukResim)) : "/Uploads/ProfileTopHeader/top_header_23.jpg",
                                              ProfilResmiBase64 = p.ArkadasKullanici.KullaniciResim.Any() && p.ArkadasKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.ArkadasKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                                              HediyeSepetiUrunSayisi = 0,
                                              ArkadasSayisi = 0
                                          })
                                          .ToList();

                var kullaniciArkadasList = query.Where(p => p.KullaniciId != kullaniciId)
                                                .Include("ArkadasKullanici")
                                                .Include("ArkadasKullanici.KullaniciSehir")
                                                .Include("ArkadasKullanici.KullaniciResim")
                                                .Include("ArkadasKullanici.DuvarResim")
                                                .Select(p => new ArkadasListesiKullaniciArkadasVM
                                                {
                                                    KullaniciId = p.Kullanici.KullaniciId,
                                                    KullaniciAdi = p.Kullanici.KullaniciAdi,
                                                    Adi = p.Kullanici.Adi,
                                                    Soyadi = p.Kullanici.Soyadi,
                                                    DogumTarihi = p.Kullanici.DogumTarihi.HasValue ? p.Kullanici.DogumTarihi.Value : new DateTime(1900, 1, 1),
                                                    KayitTarihi = p.KayitTarihi,
                                                    Sehir = p.Kullanici.KullaniciSehir == null ? "" : p.Kullanici.KullaniciSehir.KullaniciSehirAdi,
                                                    Hakkinda = p.Kullanici.Hakkinda.Trim(),
                                                    DuvarResimBase64 = p.Kullanici.DuvarResim != null && p.Kullanici.DuvarResim.KucukResim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Kullanici.DuvarResim.KucukResim)) : "/Uploads/ProfileTopHeader/top_header_23.jpg",
                                                    ProfilResmiBase64 = p.Kullanici.KullaniciResim.Any() && p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                                                    HediyeSepetiUrunSayisi = 0,
                                                    ArkadasSayisi = 0
                                                })
                                                .ToList();


                arkadasKullaniciList.AddRange(kullaniciArkadasList);
                arkadasKullaniciList = arkadasKullaniciList.Distinct().ToList();

                arkadasKullaniciList.ForEach(p =>
                {
                    p.HediyeSepetiUrunSayisi = KullaniciHediyeSepetiSayisiGetir(p.KullaniciId);
                    p.ArkadasSayisi = KullaniciArkadasSayisiGetir(p.KullaniciId);
                });

                var totalCount = arkadasKullaniciList.Count;

                var result = await arkadasKullaniciList.ToPagedListAsync((arkadaListeAramaVM.start <= 0 ? 1 : arkadaListeAramaVM.start), (arkadaListeAramaVM.length <= 0 ? (totalCount <= 0 ? 1 : totalCount) : arkadaListeAramaVM.length));

                return result;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "ArkadasListesiGetir", kullaniciId));

                return resultList;
            }
        }

        public async Task<IPagedList<ArkadasKonusmaListesiVM>> ArkadasMesajListGetir(ArkadasMesajListeVM mesajAramaVM, Guid kullaniciId)
        {
            IPagedList<ArkadasKonusmaListesiVM> resultList = new List<ArkadasKonusmaListesiVM>().ToPagedList();

            try
            {
                var query = readOnlyRepository.GetQueryable<KullaniciMesaj>(p => p.AktifMi &&
                                                                                 ((p.AliciKullaniciId == kullaniciId && p.AlanAktifMi) || (p.GondericiKullaniciId == kullaniciId && p.GonderenAktifMi)))
                                              .IncludeMultiple(x => x.AliciKullanici, s => s.GondericiKullanici)
                                              .OrderBy(p => p.KullaniciMesajId)
                                              .Select(p => new ArkadasKonusmaListesiVM
                                              {
                                                  KullaniciId = (p.GondericiKullaniciId == kullaniciId) ? p.AliciKullaniciId : p.GondericiKullaniciId,
                                                  ProfilResmiBase64 = (p.GondericiKullaniciId == kullaniciId) ? (p.AliciKullanici.KullaniciResim.Any() && p.AliciKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.AliciKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png") : (p.GondericiKullanici.KullaniciResim.Any() && p.GondericiKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.GondericiKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png"),
                                                  KullaniciAdi = (p.GondericiKullaniciId == kullaniciId) ? p.AliciKullanici.KullaniciAdi : p.GondericiKullanici.KullaniciAdi,
                                                  Adi = (p.GondericiKullaniciId == kullaniciId) ? p.AliciKullanici.Adi : p.GondericiKullanici.Adi,
                                                  Soyadi = (p.GondericiKullaniciId == kullaniciId) ? p.AliciKullanici.Soyadi : p.GondericiKullanici.Soyadi,
                                                  MesajOzet = string.IsNullOrEmpty(p.MesajIcerik) || p.MesajIcerik.Length > 10 ? p.MesajIcerik.Substring(0, 10) : p.MesajIcerik,
                                                  SonKonusmaTarihi = p.KayitTarih
                                              })
                                              .ToList();
                var arkadasKullaniciMesajList = query.GroupBy(p => p.KullaniciId).Select(g => g.Last()).OrderByDescending(s => s.SonKonusmaTarihi).ToList();

                var totalCount = arkadasKullaniciMesajList.Count;

                return await arkadasKullaniciMesajList.ToPagedListAsync((mesajAramaVM.start <= 0 ? 1 : mesajAramaVM.start), (mesajAramaVM.length <= 0 ? (totalCount <= 0 ? 1 : totalCount) : mesajAramaVM.length));

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "ArkadasMesajListGetir", kullaniciId));

                return resultList;
            }
        }

        public async Task<KullaniciArkadas> ArkadasKaydet(KullaniciArkadas arkadas)
        {
            repository.Create(arkadas);
            try
            {
                await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return arkadas;
        }

        public async Task<int> ArkadasIstekKaldir(ArkadaslikIstek arkadalikIstek)
        {
            repository.Delete(arkadalikIstek);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "ArkadasIstekKaldir", arkadalikIstek.ArkadaslikIstekId));
                return -1;
            }
        }

        public async Task<int> ArkadasIstekGuncelle(ArkadaslikIstek arkadalikIstek)
        {
            repository.Update(arkadalikIstek);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> ArkadasIstekKaydet(ArkadaslikIstek arkadalikIstek)
        {
            repository.Create(arkadalikIstek);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IPagedList<ArkadasVM>> ArkadasAramaListGetir(ArkadasAramaVM arkadasAramaVM)
        {
            IPagedList<ArkadasVM> result = new List<ArkadasVM>().ToPagedList();
            IQueryable<Kullanici> query = null;
            Kullanici girisYapanKullanici = new Kullanici();
            if (arkadasAramaVM.Token != null)
            {
                girisYapanKullanici = await KullaniciGetirByToken(arkadasAramaVM.Token.RefreshToken);
            }

            //using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                try
                {
                    int start = arkadasAramaVM.start <= 0 ? 0 : arkadasAramaVM.start - 1;
                    int length = arkadasAramaVM.length <= 0 ? 1 : arkadasAramaVM.length;

                    var parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@Start", start * length));
                    parameters.Add(new SqlParameter("@Length", length));

                    string kelime = arkadasAramaVM.AramaKelime?.ToLower(new CultureInfo("tr-TR"))?.Trim();
                    if (!string.IsNullOrEmpty(kelime))
                    {
                        //birden fazla kelime varsa combine bulması lazım                      
                        var kelimeler = kelime.Split(" ");

                        int sayac = 1;
                        foreach (var kelimeData in kelimeler)
                        {
                            if (string.IsNullOrEmpty(kelimeData.Trim()))
                                continue;

                            string kelimeDataEn = kelimeData.RemoveDiacritics().ToLower().Trim();

                            string param = "@Kelime" + sayac.ToString();
                            string paramEn = "@KelimeEn" + sayac.ToString();

                            parameters.Add(new SqlParameter(param, kelimeData));
                            parameters.Add(new SqlParameter(paramEn, kelimeDataEn));

                            sayac++;
                        }
                    }

                    if (arkadasAramaVM.Cinsiyet != "T" && arkadasAramaVM.Cinsiyet != null)
                        parameters.Add(new SqlParameter("@Cinsiyet", arkadasAramaVM.Cinsiyet));

                    if (arkadasAramaVM.Sehir > 0)
                        parameters.Add(new SqlParameter("@Sehir", arkadasAramaVM.Sehir));

                    if (arkadasAramaVM.KullaniciId != null)
                        parameters.Add(new SqlParameter("@KullaniciId", arkadasAramaVM.KullaniciId));

                    var arkadasTotalData = readOnlyRepository.GetFromQuery<ArkadasTotalRaw>(UyelikRawQueries.ArkadasAramaListTotalGetir(kelime, arkadasAramaVM.Cinsiyet, arkadasAramaVM.Sehir, arkadasAramaVM.KullaniciId), parameters.ToArray());
                    var arkadasData = readOnlyRepository.SelectFromQuery<ArkadasRaw>(UyelikRawQueries.ArkadasAramaListGetir(kelime, arkadasAramaVM.Cinsiyet, arkadasAramaVM.Sehir, arkadasAramaVM.KullaniciId), parameters.ToArray());
                    var arkadasList = mapper.Map<List<ArkadasRaw>, List<ArkadasVM>>(arkadasData);
                    result = new StaticPagedList<ArkadasVM>(arkadasList, start + 1, length, arkadasTotalData.Total);

                    result.ToList().ForEach(p =>
                    {
                        p.DuvarResimBase64 = p.DuvarResim.Length > 0 ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.DuvarResim)) : "/Uploads/ProfileTopHeader/top_header_23.jpg";
                        p.ProfilResmiBase64 = p.ProfilResmi.Length > 0 ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.ProfilResmi)) : "/Uploads/Site/user_icon.png";
                        p.Hakkinda = p.Hakkinda == null ? "" : (p.Hakkinda.Length >= 50 ? p.Hakkinda.Substring(0, 50) + "..." : p.Hakkinda);
                    });

                    //query = readOnlyRepository.GetQueryable<Kullanici>(p => p.AktifMi)
                    //                          .AsNoTracking()
                    //                          .Include("KullaniciUrun")
                    //                          .Include("KullaniciSehir")
                    //                          .Include("KullaniciResim")
                    //                          .Include("DuvarResim")
                    //                          .Include("ArkadaslikIstekArkadaslikIstekKullanici")
                    //                          .Include("KullaniciArkadasKullanici")
                    //                          .Include("ArkadaslikIstekArkadaslikIstekKullanici.Kullanici");

                    //if (arkadasAramaVM.KullaniciId != null)
                    //    query = query.Where(p => p.KullaniciId != arkadasAramaVM.KullaniciId);

                    //if (!string.IsNullOrEmpty(arkadasAramaVM.AramaKelime))
                    //{
                    //    //birden fazla kelime varsa combine bulması lazım
                    //    string kelime = arkadasAramaVM.AramaKelime.ToLower(new CultureInfo("tr-TR")).Trim();
                    //    var kelimeler = kelime.Split(" ");

                    //    if (kelimeler.Count() > 1)
                    //    {
                    //        foreach (var kelimeData in kelimeler)
                    //        {
                    //            string kelimeDataEn = kelimeData.RemoveDiacritics().ToLower().Trim();

                    //            query = query.Where(p => p.KullaniciAdi.StartsWith(kelimeData) ||
                    //                                     p.Adi.StartsWith(kelimeData) ||
                    //                                     p.Soyadi.StartsWith(kelimeData) ||
                    //                                     (p.Adi + " " + p.Soyadi).Contains(kelimeData) ||
                    //                                     p.KullaniciAdi.StartsWith(kelimeDataEn) ||
                    //                                     p.Adi.StartsWith(kelimeDataEn) ||
                    //                                     p.Soyadi.StartsWith(kelimeDataEn) ||
                    //                                     (p.Adi + " " + p.Soyadi).Contains(kelimeDataEn));
                    //        }
                    //    }
                    //    else
                    //    {
                    //        string kelimeEn = arkadasAramaVM.AramaKelime.RemoveDiacritics().ToLower().Trim();

                    //        if (kelime == kelimeEn)
                    //        {
                    //            query = query.Where(p => p.KullaniciAdi.StartsWith(kelime) ||
                    //                                     p.Adi.StartsWith(kelime) ||
                    //                                     p.Soyadi.StartsWith(kelime) ||
                    //                                     (p.Adi + " " + p.Soyadi).Contains(kelime));
                    //        }
                    //        else
                    //        {
                    //            query = query.Where(p => p.KullaniciAdi.StartsWith(kelime) ||
                    //                                     p.Adi.StartsWith(kelime) ||
                    //                                     p.Soyadi.StartsWith(kelime) ||
                    //                                     (p.Adi + " " + p.Soyadi).Contains(kelime) ||
                    //                                     p.KullaniciAdi.StartsWith(kelimeEn) ||
                    //                                     p.Adi.StartsWith(kelimeEn) ||
                    //                                     p.Soyadi.StartsWith(kelimeEn) ||
                    //                                     (p.Adi + " " + p.Soyadi).Contains(kelimeEn));
                    //        }
                    //    }
                    //}

                    //if (arkadasAramaVM.MedeniDurum != "T" && arkadasAramaVM.MedeniDurum != null)
                    //    query = query.Where(e => e.IliskiDurumu == arkadasAramaVM.MedeniDurum);

                    //if (arkadasAramaVM.Cinsiyet != "T" && arkadasAramaVM.Cinsiyet != null)
                    //    query = query.Where(e => e.Cinsiyet == arkadasAramaVM.Cinsiyet);

                    //if (arkadasAramaVM.Sehir > 0)
                    //    query = query.Where(e => e.KullaniciSehirId == arkadasAramaVM.Sehir);

                    //var total = query.Count();

                    //result = query.OrderByDescending(p => p.UyelikTarihi)
                    //                    .Select(p => new ArkadasVM
                    //                    {
                    //                        KullaniciId = p.KullaniciId,
                    //                        KullaniciAdi = p.KullaniciAdi,
                    //                        Adi = p.Adi,
                    //                        Soyadi = p.Soyadi,
                    //                        DogumTarihi = p.DogumTarihi.HasValue ? p.DogumTarihi.Value : new DateTime(1900, 1, 1),
                    //                        Sehir = string.IsNullOrEmpty(p.KullaniciSehir.KullaniciSehirAdi) ? "" : p.KullaniciSehir.KullaniciSehirAdi,
                    //                        Hakkinda = p.Hakkinda.Trim(),
                    //                        DuvarResimBase64 = p.DuvarResim != null && p.DuvarResim.KucukResim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.DuvarResim.KucukResim)) : "/Uploads/ProfileTopHeader/top_header_23.jpg",
                    //                        ProfilResmiBase64 = p.KullaniciResim.Any() && p.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                    //                        ArkadaslikIstekDurum = arkadasAramaVM.KullaniciId != null ?
                    //                         ((p.KullaniciArkadasKullanici.Any(x => x.AktifMi && (x.KullaniciId == arkadasAramaVM.KullaniciId || x.ArkadasKullaniciId == arkadasAramaVM.KullaniciId)) || p.KullaniciArkadasArkadasKullanici.Any(x => x.AktifMi && (x.KullaniciId == arkadasAramaVM.KullaniciId || x.ArkadasKullaniciId == arkadasAramaVM.KullaniciId))) ? 2 :
                    //               (p.ArkadaslikIstekKullanici.Any(x => x.AktifMi && (x.KullaniciId == arkadasAramaVM.KullaniciId || x.ArkadaslikIstekKullaniciId == arkadasAramaVM.KullaniciId))) ? 1 : (p.ArkadaslikIstekArkadaslikIstekKullanici.Any(x => x.AktifMi && (x.KullaniciId == arkadasAramaVM.KullaniciId || x.ArkadaslikIstekKullaniciId == arkadasAramaVM.KullaniciId))) ? 3 : 0) : 0,
                    //                        ArkadasIstekTalepleriDurum = p.ArkadasIstekTalepleriDurum,
                    //                        ProfilGoruntulemeDurum = p.ProfilGoruntulemeDurum,
                    //                        HediyeSepetiUrunSayisi = p.KullaniciUrun == null ? 0 : p.KullaniciUrun.Count(o => o.KullaniciId == p.KullaniciId && o.AktifMi),
                    //                        ArkadasSayisi = 0,
                    //                    })
                    //                     .ToPagedList((arkadasAramaVM.start <= 0 ? 1 : arkadasAramaVM.start), (arkadasAramaVM.length <= 0 ? (total <= 0 ? 1 : total) : arkadasAramaVM.length));

                    //result.ToList().ForEach(p =>
                    //{
                    //    p.Hakkinda = p.Hakkinda == null ? "" : (p.Hakkinda.Length >= 50 ? p.Hakkinda.Substring(0, 50) + "..." : p.Hakkinda);
                    //});
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "UyelikDataService", "ArkadasAramaListGetir"));
                }

                //scope.Complete();
            }

            return result;
        }
        //TODO ŞG: Üst menü arama alanı için kullanılacak.
        //public async Task<IEnumerable<HizliArkadasAraSonucVM>> HizliArkadasListeGetir(HizliArkadasAraVM hizliArkadasAraVm)
        //{
        //    IQueryable<Kullanici> query = null;
        //    try
        //    {
        //        query = readOnlyRepository.GetQueryable<Kullanici>(p => p.AktifMi);

        //        if (!string.IsNullOrEmpty(hizliArkadasAraVm.AramaKelime))
        //        {
        //            //birden fazla kelime varsa combine bulması lazım
        //            string kelime = hizliArkadasAraVm.AramaKelime.ToLower(new CultureInfo("tr-TR")).Trim().ToString();
        //            var kelimeler = kelime.Split(" ");

        //            if (kelimeler.Count() > 1)
        //            {
        //                var queryData = new List<UrunIcerikRaw>();
        //                foreach (var kelimeData in kelimeler)
        //                {
        //                    string kelimeDataEn = kelimeData.RemoveDiacritics().ToLower().Trim();

        //                    query = query.Where(p => p.KullaniciAdi.StartsWith(kelimeData) ||
        //                                             p.Adi.StartsWith(kelimeData) ||
        //                                             p.Soyadi.StartsWith(kelimeData) ||
        //                                             (p.Adi + " " + p.Soyadi).Contains(kelimeData) ||
        //                                             p.KullaniciAdi.StartsWith(kelimeDataEn) ||
        //                                             p.Adi.StartsWith(kelimeDataEn) ||
        //                                             p.Soyadi.StartsWith(kelimeDataEn) ||
        //                                             (p.Adi + " " + p.Soyadi).Contains(kelimeDataEn));
        //                }
        //            }
        //            else
        //            {
        //                string kelimeEn = hizliArkadasAraVm.AramaKelime.RemoveDiacritics().ToLower().Trim();

        //                if (kelime == kelimeEn)
        //                {
        //                    query = query.Where(p => p.KullaniciAdi.StartsWith(kelime) ||
        //                                             p.Adi.StartsWith(kelime) ||
        //                                             p.Soyadi.StartsWith(kelime) ||
        //                                             (p.Adi + " " + p.Soyadi).Contains(kelime));
        //                }
        //                else
        //                {
        //                    query = query.Where(p => p.KullaniciAdi.StartsWith(kelime) ||
        //                                             p.Adi.StartsWith(kelime) ||
        //                                             p.Soyadi.StartsWith(kelime) ||
        //                                             (p.Adi + " " + p.Soyadi).Contains(kelime) ||
        //                                             p.KullaniciAdi.StartsWith(kelimeEn) ||
        //                                             p.Adi.StartsWith(kelimeEn) ||
        //                                             p.Soyadi.StartsWith(kelimeEn) ||
        //                                             (p.Adi + " " + p.Soyadi).Contains(kelimeEn));
        //                }
        //            }
        //        }
        //        var result = await query
        //            .OrderByDescending(p => p.UyelikTarihi)
        //                         .Select(p => new HizliArkadasAraSonucVM
        //                         {
        //                             KullaniciAdi = p.KullaniciAdi,
        //                             Adi = p.Adi,
        //                             Soyadi = p.Soyadi,
        //                         }).Take(hizliArkadasAraVm.Length)
        //                         .ToListAsync();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public async Task<int> KullaniciMesajKaydet(KullaniciMesaj mesaj)
        {
            repository.Create(mesaj);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<KullaniciArkadas> KullaniciArkadasGetir(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            return await readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi).Include(p => p.ArkadasKullanici)
                .FirstOrDefaultAsync(p => (p.KullaniciId == kullaniciId && p.ArkadasKullaniciId == kullaniciArkadasId) ||
                                        (p.KullaniciId == kullaniciArkadasId && p.ArkadasKullaniciId == kullaniciId));
        }

        public async Task<int> KullaniciArkadasGuncelle(KullaniciArkadas arkadaslik)
        {
            repository.Update(arkadaslik);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<KullaniciArkadas>> ArkadasAra(ArkadasAraVM vm)
        {
            var query = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi && ((p.KullaniciId == vm.KullaniciId) || (p.ArkadasKullaniciId == vm.KullaniciId)))
                                                                      .IncludeMultiple(s => s.ArkadasKullanici.KullaniciResim, i => i.Kullanici);

            string kelime = vm.AramaKelime.ToLower(new CultureInfo("tr-TR")).Trim();
            string kelimeEn = kelime.RemoveDiacritics().ToLower().Trim();
            var arkadasKullaniciList = await query
                                          .Where(p => p.ArkadasKullaniciId != vm.KullaniciId && (string.IsNullOrEmpty(kelime) ||
                                                                        p.ArkadasKullanici.Adi.Contains(kelime) ||
                                                                        p.ArkadasKullanici.Soyadi.Contains(kelime) ||
                                                                        p.ArkadasKullanici.Adi.Contains(kelimeEn) ||
                                                                        p.ArkadasKullanici.Soyadi.Contains(kelimeEn)
                                                                        ))
                                          .Include("ArkadasKullanici")
                                          .Include("ArkadasKullanici.KullaniciSehir")
                                          .ToListAsync();

            var kullaniciArkadasList = await query.Where(p => p.KullaniciId != vm.KullaniciId && (string.IsNullOrEmpty(kelime) ||
                                                                        p.Kullanici.Adi.Contains(kelime) ||
                                                                        p.Kullanici.Soyadi.Contains(kelime) ||
                                                                        p.Kullanici.Adi.Contains(kelimeEn) ||
                                                                        p.Kullanici.Soyadi.Contains(kelimeEn)
                                                                        ))
                                            .Include("Kullanici")
                                            .Include("Kullanici.KullaniciSehir")
                                            .ToListAsync();

            arkadasKullaniciList.AddRange(kullaniciArkadasList);
            arkadasKullaniciList = arkadasKullaniciList.Distinct().ToList();

            return arkadasKullaniciList;

            //var query = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi && ((p.KullaniciId == vm.KullaniciId) || (p.ArkadasKullaniciId == vm.KullaniciId)))
            //                                                          .IncludeMultiple(s => s.ArkadasKullanici.KullaniciResim, i => i.Kullanici);

            //var arkadasKullaniciList = await query
            //                              .Where(p => p.ArkadasKullaniciId != vm.KullaniciId && (string.IsNullOrEmpty(vm.AramaKelime) ||
            //                                                            p.ArkadasKullanici.Adi.Contains(vm.AramaKelime) ||
            //                                                            p.ArkadasKullanici.Soyadi.Contains(vm.AramaKelime)))
            //                              .Include("ArkadasKullanici")
            //                              .Include("ArkadasKullanici.KullaniciSehir")
            //                              .ToListAsync();

            //var kullaniciArkadasList = await query.Where(p => p.KullaniciId != vm.KullaniciId && (string.IsNullOrEmpty(vm.AramaKelime) ||
            //                                                            p.Kullanici.Adi.Contains(vm.AramaKelime) ||
            //                                                            p.Kullanici.Soyadi.Contains(vm.AramaKelime)))
            //                                .Include("ArkadasKullanici")
            //                                .Include("ArkadasKullanici.KullaniciSehir")
            //                                .ToListAsync();

            //arkadasKullaniciList.AddRange(kullaniciArkadasList);
            //arkadasKullaniciList = arkadasKullaniciList.Distinct().ToList();


            //return arkadasKullaniciList;

        }
        public async Task<bool> KullaniciArkadasKullaniciMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            var arkadas = await readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi).AsNoTracking().Include(p => p.ArkadasKullanici)
                .FirstOrDefaultAsync(p => (p.KullaniciId == kullaniciId && p.ArkadasKullaniciId == kullaniciArkadasId) ||
                                        (p.KullaniciId == kullaniciArkadasId && p.ArkadasKullaniciId == kullaniciId));
            if (arkadas != null)
                return true;
            else
                return false;
        }
        public async Task<bool> KullaniciArkadasiminArkadasiMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            bool sonuc = false;
            var arkadas = await readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi &&
            ((p.KullaniciId == kullaniciId) || (p.ArkadasKullaniciId == kullaniciId))).AsNoTracking().ToListAsync();
            foreach (KullaniciArkadas item in arkadas)
            {
                sonuc = await KullaniciArkadasKullaniciMi(kullaniciArkadasId, item.KullaniciId);
                bool sonuc2 = await KullaniciArkadasKullaniciMi(item.ArkadasKullaniciId, kullaniciArkadasId);
                if (sonuc || sonuc2)
                {

                    return true;
                }
            }
            return false;

        }

        public async Task<bool> ArkadasIstekVarMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {


            var arkadas = await readOnlyRepository.GetQueryable<ArkadaslikIstek>(p => p.AktifMi).Include(p => p.ArkadaslikIstekKullanici)
                .FirstOrDefaultAsync(p => (p.KullaniciId == kullaniciId && p.ArkadaslikIstekKullaniciId == kullaniciArkadasId) ||
                                        (p.KullaniciId == kullaniciArkadasId && p.ArkadaslikIstekKullaniciId == kullaniciId));
            if (arkadas != null)
            {
                return true;
            }
            else
                return false;

        }
        public async Task<int> ArkadaslikIstekSil(Guid kullaniciId, Guid arkadasKullaniciId)
        {
            var arkadaslikIstek = await readOnlyRepository.GetQueryable<ArkadaslikIstek>(p => p.AktifMi).Include(p => p.ArkadaslikIstekKullanici)
               .FirstOrDefaultAsync(p => (p.KullaniciId == kullaniciId && p.ArkadaslikIstekKullaniciId == arkadasKullaniciId) ||
                                       (p.KullaniciId == arkadasKullaniciId && p.ArkadaslikIstekKullaniciId == kullaniciId));

            repository.Delete(arkadaslikIstek);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<KullaniciMesaj>> MesajDetayGetir(MesajDetayGetirVM vm)
        {
            var query = readOnlyRepository.GetQueryable<KullaniciMesaj>(p => p.AktifMi && ((p.AliciKullaniciId == vm.AliciKullaniciId) && (p.GondericiKullaniciId == vm.GonderenKullaniciId)) ||
                                                                                           ((p.AliciKullaniciId == vm.GonderenKullaniciId) && (p.GondericiKullaniciId == vm.AliciKullaniciId)))
                                                          .IncludeMultiple(s => s.AliciKullanici, i => i.GondericiKullanici);

            var arkadasKullaniciList = await query
                                          .Where(p => p.AliciKullaniciId != vm.AliciKullaniciId && p.GonderenAktifMi)
                                          .Include("AliciKullanici")
                                          .Include("GondericiKullanici")
                                          .ToListAsync();

            var kullaniciArkadasList = await query.Where(p => p.GondericiKullaniciId != vm.AliciKullaniciId && p.AlanAktifMi)
                                            .Include("AliciKullanici")
                                            .Include("GondericiKullanici")
                                            .ToListAsync();

            arkadasKullaniciList.AddRange(kullaniciArkadasList);
            arkadasKullaniciList = arkadasKullaniciList.OrderBy(x => x.KayitTarih).Distinct().ToList();


            return arkadasKullaniciList;

        }

        public async Task<int> KonusmaSil(KonusmaSilVM vm, Guid silenKullaniciId)
        {
            var query = await readOnlyRepository.GetQueryable<KullaniciMesaj>(p => p.AktifMi && ((p.AliciKullaniciId == vm.SilenKullaniciId) && (p.GondericiKullaniciId == vm.GonderenKullaniciId)) ||
                                                                                           (p.AliciKullaniciId == vm.GonderenKullaniciId && p.GondericiKullaniciId == vm.SilenKullaniciId))
                                                          .IncludeMultiple(s => s.AliciKullanici, i => i.GondericiKullanici).ToListAsync();


            foreach (var mesaj in query)
            {
                if (mesaj.GondericiKullaniciId == silenKullaniciId)
                {
                    mesaj.GonderenAktifMi = false;
                    repository.Update(mesaj);
                }

                if (mesaj.AliciKullaniciId == silenKullaniciId)
                {
                    mesaj.AlanAktifMi = false;
                    repository.Update(mesaj);
                }
            }


            return await SaveChanges();
        }

        public async Task<KullaniciMesaj> MesajGetir(int mesajId)
        {
            return await readOnlyRepository.GetByIdAsync<KullaniciMesaj>(mesajId);
        }

        public async Task<int> MesajSil(KullaniciMesaj mesaj)
        {
            repository.Update(mesaj);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<ArkadasListesiKullaniciArkadasVM>> KullaniciBakilanProfillerListModalGetir(Guid kullaniciId, int start, int length)
        {

            var query = readOnlyRepository.GetQueryable<KullaniciBakilanProfiller>(p =>
                                                                      p.KullaniciId == kullaniciId).IncludeMultiple(x => x.Kullanici).OrderByDescending(x => x.BakilanTarih);



            var bakilanProfillerList = query
                                            .Include("Kullanici")
                                            .Select(p => new ArkadasListesiKullaniciArkadasVM
                                            {
                                                KullaniciId = p.Kullanici.KullaniciId,
                                                KullaniciAdi = p.Kullanici.KullaniciAdi,
                                                Adi = p.Kullanici.Adi,
                                                Soyadi = p.Kullanici.Soyadi,
                                                DogumTarihi = p.Kullanici.DogumTarihi.HasValue ? p.Kullanici.DogumTarihi.Value : new DateTime(1900, 1, 1),
                                                KayitTarihi = p.Kullanici.UyelikTarihi,
                                                Sehir = p.Kullanici.KullaniciSehir == null ? "" : p.Kullanici.KullaniciSehir.KullaniciSehirAdi,
                                                Hakkinda = p.Kullanici.Hakkinda,
                                                DuvarResimBase64 = p.Kullanici.DuvarResim != null && p.Kullanici.DuvarResim.KucukResim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Kullanici.DuvarResim.KucukResim)) : "/Uploads/ProfileTopHeader/top_header_23.jpg",
                                                ProfilResmiBase64 = p.Kullanici.KullaniciResim.Any() && p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Kullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                                                HediyeSepetiUrunSayisi = 0,
                                                ArkadasSayisi = 0
                                            })
                                            .ToList();



            List<ArkadasListesiKullaniciArkadasVM> arkadasListSon = new List<ArkadasListesiKullaniciArkadasVM>();

            if (bakilanProfillerList.Count > (start * length))
            {
                for (var i = (start * length); i < ((start + 1) * length) && i < bakilanProfillerList.Count; i++)
                {
                    arkadasListSon.Add(bakilanProfillerList[i]);
                }
            }
            else
            {
                arkadasListSon = bakilanProfillerList;
            }


            return arkadasListSon;
        }

        public async Task<bool> BanaArkadaslikIstekVarMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            var arkadas = await readOnlyRepository.GetQueryable<ArkadaslikIstek>(p => p.AktifMi).Include(p => p.ArkadaslikIstekKullanici)
               .FirstOrDefaultAsync(p => (p.KullaniciId == kullaniciId && p.ArkadaslikIstekKullaniciId == kullaniciArkadasId));
            if (arkadas != null)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<int> KullaniciArkadaslikDurumu(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            var arkadaslikIstekDurum = 0;
            var arkadas = await readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi).Include(p => p.ArkadasKullanici)
                .FirstOrDefaultAsync(p => (p.KullaniciId == kullaniciId && p.ArkadasKullaniciId == kullaniciArkadasId) ||
                                        (p.KullaniciId == kullaniciArkadasId && p.ArkadasKullaniciId == kullaniciId));

            var istek = await readOnlyRepository.GetQueryable<ArkadaslikIstek>(p => p.AktifMi).Include(p => p.ArkadaslikIstekKullanici)
                .FirstOrDefaultAsync(p => (p.KullaniciId == kullaniciId && p.ArkadaslikIstekKullaniciId == kullaniciArkadasId));

            var istek2 = await readOnlyRepository.GetQueryable<ArkadaslikIstek>(p => p.AktifMi).Include(p => p.ArkadaslikIstekKullanici)
                .FirstOrDefaultAsync(p => (p.KullaniciId == kullaniciArkadasId && p.ArkadaslikIstekKullaniciId == kullaniciId));

            if (kullaniciId == kullaniciArkadasId)
            {
                arkadaslikIstekDurum = 4;
            }
            else if (arkadas != null)
            {
                arkadaslikIstekDurum = 2;
            }
            else if (istek != null)
            {
                arkadaslikIstekDurum = 3;
            }
            else if (istek2 != null)
            {
                arkadaslikIstekDurum = 1;
            }

            return arkadaslikIstekDurum;
        }

        #endregion

        #region ProfilEngel

        #region Admin

        #endregion

        #region FrontEnd

        public async Task<ProfilEngelVM> ProfilEngelKaydet(ProfilEngelVM model)
        {
            ProfilEngelVM result = new ProfilEngelVM()
            {
                Hata = true,
            };

            try
            {
                //herhangi bir engel varmı?
                var profilEngelData = await readOnlyRepository.GetQueryable<ProfilEngel>(p => p.ProfilEngellenenKullaniciId == model.ProfilEngellenenKullaniciId &&
                                                                                              p.ProfilEngelleyenKullaniciId == model.ProfilEngelleyenKullaniciId)
                                                              .SingleOrDefaultAsync();

                if (profilEngelData == null)
                {
                    ProfilEngel profilEngel = new ProfilEngel()
                    {
                        ProfilEngellenenKullaniciId = model.ProfilEngellenenKullaniciId,
                        ProfilEngelleyenKullaniciId = model.ProfilEngelleyenKullaniciId,
                        KayitTarihi = DateTime.Now,
                        AktifMi = true
                    };

                    repository.Create(profilEngel);

                    await SaveChanges();

                    if (profilEngel.ProfilEngelId > 0)
                    {
                        result.Hata = false;
                        result.Mesaj = "İşlem Başarılı.";
                    }
                    else
                    {
                        result.Mesaj = "Kaydetme İşleminde Hata";
                    }
                }
                else if (profilEngelData.AktifMi)
                {
                    result.Mesaj = "Bu Profil Zaten Engel Listenizde";
                }
                else
                {
                    profilEngelData.KayitTarihi = DateTime.Now;
                    profilEngelData.AktifMi = true;
                    repository.Update(profilEngelData);
                    await SaveChanges();

                    result.Hata = false;
                    result.Mesaj = "İşlem Başarılı.";
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Mesaj = "İşlem Sırasında Bir Hata Oluştu";
                return result;
            }
        }

        public async Task<ProfilEngelVM> ProfilEngelSil(ProfilEngelVM model)
        {
            ProfilEngelVM result = new ProfilEngelVM()
            {
                Hata = true,
            };

            try
            {
                var profilEngel = await readOnlyRepository.GetQueryable<ProfilEngel>(p => p.AktifMi &&
                                                                                          p.ProfilEngellenenKullaniciId == model.ProfilEngellenenKullaniciId &&
                                                                                          p.ProfilEngelleyenKullaniciId == model.ProfilEngelleyenKullaniciId)
                                                          .SingleOrDefaultAsync();
                if (profilEngel == null)
                {
                    result.Mesaj = "Engel Bulunamadı.";
                }
                else
                {
                    profilEngel.AktifMi = false;
                    profilEngel.KayitTarihi = DateTime.Now;
                    repository.Update(profilEngel);
                    await SaveChanges();

                    result.Hata = false;
                    result.Mesaj = "İşlem Başarılı.";
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Mesaj = "İşlem Sırasında Bir Hata Oluştu";
                return result;
            }
        }

        public async Task<IPagedList<ProfilEngelKisiVM>> ProfilEngelListGetir(EngellenenProfilListesiAramaVM model)
        {
            IPagedList<ProfilEngelKisiVM> resultList = new List<ProfilEngelKisiVM>().ToPagedList();

            try
            {
                var query = readOnlyRepository.GetQueryable<ProfilEngel>(p => p.AktifMi &&
                                                                              p.ProfilEngelleyenKullaniciId == model.KullaniciId);

                var total = query.Count();

                return await query.Select(p => new ProfilEngelKisiVM
                {
                    ProfilEngellenenKullaniciId = p.ProfilEngellenenKullaniciId,
                    Adi = p.ProfilEngellenenKullanici.Adi,
                    Soyadi = p.ProfilEngellenenKullanici.Soyadi,
                    KullaniciAdi = p.ProfilEngellenenKullanici.KullaniciAdi,
                    KayitTarihi = p.KayitTarihi.ToString("dd.MM.yyyy"),
                    ProfilResmiBase64 = p.ProfilEngellenenKullanici.KullaniciResim.Any() && p.ProfilEngellenenKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.ProfilEngellenenKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",

                }).ToPagedListAsync((model.start <= 0 ? 1 : model.start), (model.length <= 0 ? (total <= 0 ? 1 : total) : model.length));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #endregion

        #region ProfilSikayet

        #region Admin
        public async Task<List<ProfilSikayetAramaSonucVM>> ProfilSikayetArama(ProfilSikayetAramaVM model)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<ProfilSikayet>(p => (model.Aktiflik == -1 || p.AktifMi == Convert.ToBoolean(model.Aktiflik)) &&
                                                                                (model.ProfilSikayetId == null || p.ProfilSikayetId == model.ProfilSikayetId.Value) &&
                                                                                (model.SikayetEdenKullaniciEposta == null || p.SikayetEdenKullanici.Eposta.Contains(model.SikayetEdenKullaniciEposta)) &&
                                                                                (model.SikayetEdilenKullaniciEposta == null || p.SikayetEdilenKullanici.Eposta.Contains(model.SikayetEdilenKullaniciEposta)) &&
                                                                                (model.SikayetSebebi == null || p.SikayetSebebi.Contains(model.SikayetSebebi)) &&
                                                                                (model.BaslangicTarihi == null || p.Tarih >= Convert.ToDateTime(model.BaslangicTarihi)) &&
                                                                                (model.BitisTarihi == null || p.Tarih <= Convert.ToDateTime(model.BitisTarihi)));

                var total = query.Count();

                return await query.OrderByDescending(p => p.ProfilSikayetId)
                                  .Select(p => new ProfilSikayetAramaSonucVM
                                  {
                                      ProfilSikayetId = p.ProfilSikayetId,
                                      SikayetEdilenKullaniciEposta = p.SikayetEdilenKullanici.Eposta,
                                      SikayetEdenKullaniciEposta = p.SikayetEdenKullanici == null ? "" : p.SikayetEdenKullanici.Eposta,
                                      SikayetSebebi = p.SikayetSebebi,
                                      Tarih = p.Tarih.ToString("dd.MM.yyyy"),
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

        public async Task<bool> ProfilSikayetKaydet(ProfilSikayetVM model)
        {
            try
            {
                ProfilSikayet profilSikayet = new ProfilSikayet()
                {
                    SikayetEdenKullaniciId = model.SikayetEdenKullaniciId,
                    SikayetEdilenKullaniciId = model.SikayetEdilenKullaniciId,
                    SikayetSebebi = model.SikayetSebebi,
                    Tarih = DateTime.Now,
                    AktifMi = true
                };

                repository.Create(profilSikayet);
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #endregion

        #region KullaniciHobi

        #region Admin       

        #endregion

        #region FrontEnd

        public async Task<List<KullaniciHobiVM>> KullaniciHobiGetir(Guid kullaniciId)
        {


            var kullaniciHobiList = await readOnlyRepository.GetQueryable<KullaniciHobi>(p => p.AktifMi &&
                                                                                              p.KullaniciId == kullaniciId)
                                                            .AsNoTracking()
                                                            .Select(p => new KullaniciHobiVM
                                                            {
                                                                id = p.HobiId,
                                                                value = p.Hobi.HobiAdi
                                                            }).Distinct().ToListAsync();


            return kullaniciHobiList;
        }

        public async Task<IEnumerable<Hobi>> HobileriGetir(string query)
        {
            return await readOnlyRepository.GetQueryable<Hobi>(q => q.HobiAdi.StartsWith(query) && q.AktifMi == true).ToListAsync();
        }

        public async Task<KullaniciHobiVeIlgiAlanVM> KullaniciHobiIlgiAlanGetir(Guid kullaniciId)
        {
            KullaniciHobiVeIlgiAlanVM result = new KullaniciHobiVeIlgiAlanVM();

            var kullaniciHobiList = await readOnlyRepository.GetQueryable<KullaniciHobi>(p => p.AktifMi &&
                                                                                              p.KullaniciId == kullaniciId)
                                                            .Select(p => new KullaniciHobiVM
                                                            {
                                                                id = p.HobiId,
                                                                value = p.Hobi.HobiAdi.Trim()
                                                            })
                                                            .ToListAsync();

            JArray jarrayKullaniciHobiList = JArray.FromObject(kullaniciHobiList);
            result.Hobiler = jarrayKullaniciHobiList.ToString();

            var kullaniciIlgiAlanList = await readOnlyRepository.GetQueryable<KullaniciIlgiAlan>(p => p.AktifMi &&
                                                                                                      p.KullaniciId == kullaniciId)
                                                                .Select(p => new KullaniciIlgiAlanVM
                                                                {
                                                                    id = p.IlgiAlanId,
                                                                    value = p.IlgiAlan.IlgiAlanAdi.Trim()
                                                                })
                                                                .ToListAsync();

            JArray jarrayKullaniciIlgiAlanList = JArray.FromObject(kullaniciIlgiAlanList);
            result.IlgiAlan = jarrayKullaniciIlgiAlanList.ToString();

            return result;
        }

        public async Task<bool> KullaniciHobiKaydetGuncelle(KullaniciHobiKaydetGuncelleVM model)
        {
            try
            {
                var kullaniciHobiler = readOnlyRepository.GetQueryable<KullaniciHobi>(p => p.KullaniciId == model.KullaniciId);
                await kullaniciHobiler.ForEachAsync(p => p.AktifMi = false);

                if (model.KullaniciHobiList != null && model.KullaniciHobiList.Any())
                {
                    //eğer hobisi daha önceden varsa onu aktif et
                    var eslesenHobiler = kullaniciHobiler.Where(p => model.KullaniciHobiList.Select(o => o.id).Contains(p.HobiId)).Distinct();
                    if (eslesenHobiler.Any())
                    {
                        await eslesenHobiler.ForEachAsync(p => p.AktifMi = true);
                    }

                    //eğer hobisi önceden yoksa insert et
                    var eslesmeyenHobiler = model.KullaniciHobiList.Where(p => !eslesenHobiler.Select(o => o.HobiId).Any(o => o == p.id)).Select(p => p.id).Distinct();
                    foreach (var eslesmeyenHobi in eslesmeyenHobiler)
                    {
                        KullaniciHobi kullaniciHobi = new KullaniciHobi()
                        {
                            KullaniciId = model.KullaniciId,
                            HobiId = eslesmeyenHobi,
                            KayitTarih = DateTime.Now,
                            AktifMi = true
                        };
                        repository.Create(kullaniciHobi);
                    }
                }

                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> KullaniciIlgiAlanKaydetGuncelle(KullaniciIlgiAlanKaydetGuncelleVM model)
        {
            try
            {
                var kullaniciIlgiAlanlar = readOnlyRepository.GetQueryable<KullaniciIlgiAlan>(p => p.KullaniciId == model.KullaniciId);
                await kullaniciIlgiAlanlar.ForEachAsync(p => p.AktifMi = false);

                if (model.KullaniciIlgiAlanList != null && model.KullaniciIlgiAlanList.Any())
                {
                    //eğer ilgi alanı daha önceden varsa onu aktif et
                    var eslesenIlgiAlanlar = kullaniciIlgiAlanlar.Where(p => model.KullaniciIlgiAlanList.Select(o => o.id).Contains(p.IlgiAlanId)).Distinct();
                    if (eslesenIlgiAlanlar.Any())
                    {
                        await eslesenIlgiAlanlar.ForEachAsync(p => p.AktifMi = true);
                    }

                    //eğer ilgi alanı önceden yoksa insert et
                    var eslesmeyenIlgiAlanlar = model.KullaniciIlgiAlanList.Where(p => !eslesenIlgiAlanlar.Select(o => o.IlgiAlanId).Any(o => o == p.id)).Select(p => p.id).Distinct();
                    foreach (var eslesmeyenIlgiAlan in eslesmeyenIlgiAlanlar)
                    {
                        KullaniciIlgiAlan kullaniciIlgiAlan = new KullaniciIlgiAlan()
                        {
                            KullaniciId = model.KullaniciId,
                            IlgiAlanId = eslesmeyenIlgiAlan,
                            KayitTarih = DateTime.Now,
                            AktifMi = true
                        };
                        repository.Create(kullaniciIlgiAlan);
                    }
                }

                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #endregion

        #region KullaniciIlgiAlan

        #region Admin       

        #endregion

        #region FrontEnd
        public async Task<List<KullaniciIlgiAlanVM>> KullaniciIlgiAlanGetir(Guid kullaniciId)
        {
            var kullaniciIlgiAlanList = await readOnlyRepository.GetQueryable<KullaniciIlgiAlan>(p => p.AktifMi &&
                                                                                              p.KullaniciId == kullaniciId)
                                                                .AsNoTracking()
                                                                .Select(p => new KullaniciIlgiAlanVM
                                                                {
                                                                    id = p.IlgiAlanId,
                                                                    value = p.IlgiAlan.IlgiAlanAdi
                                                                }).Distinct().ToListAsync();


            return kullaniciIlgiAlanList;
        }
        public async Task<IEnumerable<IlgiAlan>> IlgiAlanlariniGetir(string query)
        {
            return await readOnlyRepository.GetQueryable<IlgiAlan>(q => q.IlgiAlanAdi.StartsWith(query) && q.AktifMi == true).ToListAsync();
        }
        #endregion

        #endregion

        #region KullaniciUrun

        #region Admin       

        #endregion

        #region FrontEnd

        public async Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeEkle(KullaniciUrunEkleSilVM model)
        {
            KullaniciUrunEkleSilSonucVM result = new KullaniciUrunEkleSilSonucVM()
            {
                Sonuc = false
            };

            try
            {
                var kontrol = await readOnlyRepository.GetQueryable<KullaniciUrun>(p => p.KullaniciId == model.KullaniciId &&
                                                                                        p.UrunId == model.UrunId)
                                                      .AnyAsync();

                if (kontrol)
                {
                    result.Mesaj = "Aynı ürün hediye sepetinizde bulunmaktadır.";
                }
                else
                {
                    KullaniciUrun kullaniciUrun = new KullaniciUrun()
                    {
                        KullaniciId = model.KullaniciId,
                        UrunId = model.UrunId,
                        KayitTarih = DateTime.Now,
                        AktifMi = true
                    };
                    repository.Create(kullaniciUrun);

                    await SaveChanges();

                    if (kullaniciUrun.KullaniciUrunId > 0)
                        result.Sonuc = true;
                    else
                        result.Mesaj = "İşlem sırasında bir hata oluştu.";
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeSil(KullaniciUrunEkleSilVM model)
        {
            KullaniciUrunEkleSilSonucVM result = new KullaniciUrunEkleSilSonucVM()
            {
                Sonuc = false
            };

            try
            {
                var kullaniciUrun = await readOnlyRepository.GetQueryable<KullaniciUrun>(p => p.KullaniciId == model.KullaniciId &&
                                                                                              p.UrunId == model.UrunId)
                                                            .SingleOrDefaultAsync();
                repository.Delete(kullaniciUrun);

                await SaveChanges();

                result.Sonuc = true;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPagedList<UrunIcerikVM>> KullaniciHediyeSepetiGetir(KullaniciUrunListesiAramaVM model)
        {
            IPagedList<UrunIcerikVM> result = new List<UrunIcerikVM>().ToPagedList();
            int start = model.start <= 0 ? 0 : model.start - 1;
            int length = model.length <= 0 ? 1 : model.length;
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Start", start * length));
                parameters.Add(new SqlParameter("@Length", length));
                parameters.Add(new SqlParameter("@KullaniciId", model.KullaniciId));
                var hediyeTotalData = readOnlyRepository.GetFromQuery<UrunTotalRaw>(UrunRawQueries.KullaniciHediyeSepetiTotalGetir(), parameters.ToArray());
                var hediyeData = readOnlyRepository.SelectFromQuery<UrunRaw>(UrunRawQueries.KullaniciHediyeSepetiGetir(fileServerIsActive, model.order), parameters.ToArray());
                var hediyeList = mapper.Map<List<UrunRaw>, List<UrunIcerikVM>>(hediyeData);

                foreach (var urun in hediyeList)
                {
                    urun.HediyeSepetindekiUrunAdeti = urunDataService.HediyeSepetindekiUrunAdeti(urun.UrunId);
                }

                return new StaticPagedList<UrunIcerikVM>(hediyeList, start + 1, length, hediyeTotalData.Total);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciHediyeSepetiGetir", ex));
                throw;
            }
        }

        public async Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiModalGetir(KullaniciArkadasListesiModalAramaVM model)
        {
            IPagedList<ArkadasListesiKullaniciArkadasVM> result = new List<ArkadasListesiKullaniciArkadasVM>().ToPagedList();
            int start = model.start <= 0 ? 0 : model.start - 1;
            int length = model.length <= 0 ? 1 : model.length;

            try
            {

                var arkadasTotalData = KullaniciArkadasSayisiGetir(model.KullaniciId);

                var arkadasList = await KullaniciArkadasListesiGetirModal(model.KullaniciId, start, length);

                Kullanici kullanici = new Kullanici();
                if (model.Token != null)
                {
                    kullanici = await KullaniciGetirByToken(model.Token.RefreshToken);
                    if (kullanici != null)
                    {
                        foreach (var arkadas in arkadasList)
                        {
                            var durum = await KullaniciArkadaslikDurumu(kullanici.KullaniciId, arkadas.KullaniciId);
                            arkadas.ArkadaslikIstekDurum = durum;
                            var istekTalep = await ArkadaslikIstekDurumGetir(arkadas.KullaniciId);
                            arkadas.ArkadaslikIstekTalepleriDurum = istekTalep;
                        }
                    }
                }


                return new StaticPagedList<ArkadasListesiKullaniciArkadasVM>(arkadasList, start + 1, length, arkadasTotalData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int KullaniciHediyeSepetiSayisiGetir(Guid kullaniciId)
        {
            int result = 0;

            try
            {
                result = readOnlyRepository.GetQueryable<Urun>(p => p.KullaniciUrun.Any(o => o.KullaniciId == kullaniciId && o.AktifMi))
                                           .Include("KullaniciUrun")
                                           .AsNoTracking()
                                           .Count();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciHediyeSepetiSayisiGetir", kullaniciId));
            }

            return result;
        }

        public int KullaniciArkadasSayisiGetir(Guid kullaniciId)
        {
            int result = 0;

            try
            {
                result = readOnlyRepository.GetQueryable<KullaniciArkadas>(p => p.AktifMi &&
                                                                                ((p.KullaniciId == kullaniciId) || (p.ArkadasKullaniciId == kullaniciId)))
                                           .AsNoTracking()
                                           .Select(p => (p.KullaniciId == kullaniciId ? p.ArkadasKullaniciId : p.KullaniciId))
                                           .Distinct()
                                           .Count();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciArkadasSayisiGetir", kullaniciId));
            }

            return result;
        }

        public int KullaniciMesajSayisiGetir(Guid kullaniciId)
        {
            int result = 0;

            try
            {
                result = readOnlyRepository.GetQueryable<KullaniciMesaj>(p => p.AktifMi &&
                                                                              p.AlanAktifMi &&
                                                                              p.AliciKullaniciId == kullaniciId)
                                           .Count();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciMesajSayisiGetir", kullaniciId));
            }

            return result;
        }

        public int KullaniciBildirimSayisiGetir(Guid kullaniciId)
        {
            int result = 0;

            try
            {
                result = readOnlyRepository.GetQueryable<Bildirim>(p => p.AktifMi &&
                                                                        p.KullaniciId == kullaniciId &&
                                                                        !p.OkunduMu)
                                           .AsNoTracking()
                                           .Count();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciBildirimSayisiGetir", kullaniciId));
            }

            return result;
        }

        public int KullaniciArkadasIstekSayisiGetir(Guid kullaniciId)
        {
            int result = 0;

            try
            {
                result = readOnlyRepository.GetQueryable<ArkadaslikIstek>(p => p.AktifMi &&
                                                                               p.KullaniciId == kullaniciId &&
                                                                               p.ArkadaslikKabulDurumTipId == 1)
                                           .Count();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciArkadasIstekSayisiGetir", kullaniciId));
            }

            return result;
        }
        public async Task<int> KullaniciOkunmamisArkadaslikIstegiSayisiGetir(Guid kullaniciId)
        {
            int result = 0;
            try
            {
                result = await readOnlyRepository.GetQueryable<ArkadaslikIstek>(p => p.AktifMi &&
                                                                               p.KullaniciId == kullaniciId &&
                                                                               p.ArkadaslikKabulDurumTipId == 1).AsNoTracking()
                                                                                                                .CountAsync();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciOkunmamisArkadaslikIstegiSayisiGetir", kullaniciId));
            }

            return result;
        }
        public async Task<int> ProfilEngelSayisiGetir(Guid kullaniciId)
        {
            int result = 0;
            try
            {
                result = await readOnlyRepository.GetQueryable<ProfilEngel>(p => p.AktifMi &&
                                                                                 p.ProfilEngelleyenKullaniciId == kullaniciId).AsNoTracking()
                                                                                                                              .CountAsync();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "ProfilEngelSayisi", kullaniciId));
            }

            return result;
        }
        public int KullaniciHediyeKartiSayisiGetir(Guid kullaniciId)
        {
            int result = 0;

            try
            {
                result = readOnlyRepository.GetQueryable<KullaniciHediyeKart>(p => p.AktifMi &&
                                                                              !p.OkunduMu &&
                                                                              p.AlanAktifMi &&
                                                                              p.AliciKullaniciId == kullaniciId)
                                           .Count();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciHediyeKartiSayisiGetir", kullaniciId));
            }

            return result;
        }

        public async Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciBakilanProfillerModalGetir(KullaniciArkadasListesiModalAramaVM model)
        {
            IPagedList<ArkadasListesiKullaniciArkadasVM> result = new List<ArkadasListesiKullaniciArkadasVM>().ToPagedList();
            int start = model.start <= 0 ? 0 : model.start - 1;
            int length = model.length <= 0 ? 1 : model.length;

            try
            {
                var bakilanProfiller = await KullaniciBakilanProfilleriGetir(model.KullaniciId);

                var arkadasList = await KullaniciBakilanProfillerListModalGetir(model.KullaniciId, start, length);

                return new StaticPagedList<ArkadasListesiKullaniciArkadasVM>(arkadasList, start + 1, length, bakilanProfiller.Count);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #endregion

        #region KullaniciResim
        public async Task<KullaniciResim> KullaniciProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResim)
        {
            KullaniciResim resim;

            resim = readOnlyRepository.GetQueryable<KullaniciResim>(w => w.KullaniciId == kullaniciResim.KullaniciId

                                                    && w.ProfilFotografiMi == true
                                                    && w.AktifMi == true).SingleOrDefault();
            //Güncel profil resmini yeni profil resmi ile güncelle    
            if (resim != null)
            {
                resim.Resim = kullaniciResim.Resim;
                resim.ResimUrl = kullaniciResim.ResimUrl;
                resim.ResimYorum = kullaniciResim.ResimYorum;
                resim.ResimUzanti = kullaniciResim.ResimUzanti;
                resim.EklenmeTarihi = kullaniciResim.EklenmeTarihi;
                resim.BuyukProfilFotografiMi = false;

                repository.Update(resim);
            }
            else // Kullanıcının daha önceden eklediği bir profil resmi yok ise
            {
                resim = new KullaniciResim();
                resim.KullaniciId = kullaniciResim.KullaniciId;
                resim.Resim = kullaniciResim.Resim;
                resim.ResimUrl = kullaniciResim.ResimUrl;
                resim.ResimUzanti = kullaniciResim.ResimUzanti;
                resim.ResimYorum = kullaniciResim.ResimYorum;
                resim.ProfilFotografiMi = kullaniciResim.ProfilFotografiMi;
                resim.AktifMi = kullaniciResim.AktifMi;
                resim.EklenmeTarihi = kullaniciResim.EklenmeTarihi;
                resim.BuyukProfilFotografiMi = false;
                repository.Create(resim);
            }

            try
            {
                await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resim;

        }
        public async Task<KullaniciResim> KullaniciResimKaydet(KullaniciResim kullaniciResim)
        {
            // Yeni eklenen resmi kaydet
            repository.Create(kullaniciResim);

            try
            {
                await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return kullaniciResim;

        }
        public async Task<KullaniciResimVM> KullaniciResimGetir(Guid kullaniciId)
        {

            IQueryable<KullaniciResim> query = null;
            query = readOnlyRepository.GetQueryable<KullaniciResim>(p => p.ProfilFotografiMi
                                                                      && p.AktifMi
                                                                      && p.KullaniciId == kullaniciId);

            return await query.Include("Kullanici")
                              .AsNoTracking()
                              .Select(p => new KullaniciResimVM
                              {
                                  KullaniciId = p.KullaniciId,
                                  ProfilFotografiMi = p.ProfilFotografiMi,
                                  Resim = p.Resim,
                                  ResimYorum = p.ResimYorum,
                                  AktifMi = p.AktifMi,
                                  KullaniciResim = p.KullaniciResimId,
                                  ResimUrl = p.ResimUrl,
                                  ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : null,
                                  ResimUzanti = p.ResimUzanti,
                                  DuvarResimId = p.Kullanici.DuvarResimId
                              })
                              .FirstOrDefaultAsync();
        }
        public async Task<HediyeKartIcerikVM> GetKullaniciHediyeKartIcerikById(int id)
        {
            HediyeKartIcerikVM result = new HediyeKartIcerikVM();

            try
            {
                result = await readOnlyRepository.GetQueryable<KullaniciHediyeKart>(w => w.HediyeKartId == id)
                                                 .Include("HediyeKart")
                                                 .Select(p => new HediyeKartIcerikVM
                                                 {
                                                     HediyeKartId = p.HediyeKart.HediyeKartId,
                                                     HediyeKartAdi = p.HediyeKart.HediyeKartAdi,
                                                     Aciklama = p.Aciklama,
                                                     KUllaniciProfilResimBase64 = KullaniciResimGetir(p.GonderenKullaniciId).Result.Resim != null ? Convert.ToBase64String(KullaniciResimGetir(p.GonderenKullaniciId).Result.Resim) : string.Empty,
                                                     ResimBase64 = p.HediyeKart.Resim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.HediyeKart.Resim)) : "/Uploads/Site/blog_empty_image_500_500.png",
                                                 })
                                                 .SingleOrDefaultAsync();


                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<KullaniciResimVM>> KullaniciResimListele(string kullaniciId)
        {
            IQueryable<KullaniciResim> query = null;
            query = readOnlyRepository.GetQueryable<KullaniciResim>(p =>
                                                                       p.AktifMi == true
                                                                      && p.ProfilFotografiMi != true
                                                                      && p.KullaniciId == Guid.Parse(kullaniciId));

            return await query.Include("Kullanici")
                              .AsNoTracking()
                              .Select(p => new KullaniciResimVM
                              {
                                  KullaniciId = p.KullaniciId,
                                  ProfilFotografiMi = p.ProfilFotografiMi,
                                  Resim = p.Resim,
                                  ResimYorum = p.ResimYorum,
                                  AktifMi = p.AktifMi,
                                  KullaniciResim = p.KullaniciResimId,
                                  ResimUrl = p.ResimUrl,
                                  ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : null,
                                  ResimUzanti = p.ResimUzanti,
                              })
                              .ToListAsync();
        }

        public async Task<int> KullaniciResimSayisiGetir(Guid kullaniciId)
        {
            return await readOnlyRepository.GetQueryable<KullaniciResim>(p => p.AktifMi == true
                                                                              && p.ProfilFotografiMi == false
                                                                              && (p.BuyukProfilFotografiMi == false || p.BuyukProfilFotografiMi == null)
                                                                              && p.KullaniciId == kullaniciId).AsNoTracking().CountAsync();
        }

        public async Task<KullaniciResimVM> KullaniciResimGetirByResimId(int resimId)
        {
            IQueryable<KullaniciResim> query = null;
            query = readOnlyRepository.GetQueryable<KullaniciResim>(p =>
                                                                       p.KullaniciResimId == resimId).AsNoTracking();

            return await query.Include("Kullanici")
                              .Select(p => new KullaniciResimVM
                              {
                                  KullaniciId = p.KullaniciId,
                                  ProfilFotografiMi = p.ProfilFotografiMi,
                                  Resim = p.Resim,
                                  ResimYorum = p.ResimYorum,
                                  AktifMi = p.AktifMi,
                                  KullaniciResim = p.KullaniciResimId,
                                  ResimUrl = p.ResimUrl,
                                  ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : null,
                                  ResimUzanti = p.ResimUzanti,
                                  DuvarResimId = p.Kullanici.DuvarResimId

                              })
                              .SingleOrDefaultAsync();

        }
        public async Task<KullaniciResim> KullaniciProfilResmiSil(KullaniciResim kullaniciResim)
        {
            try
            {
                repository.Delete(kullaniciResim);

                var buyukResim = readOnlyRepository.GetQueryable<KullaniciResim>(p => p.AktifMi == true && p.KullaniciId == kullaniciResim.KullaniciId && p.BuyukProfilFotografiMi == true).FirstOrDefault();

                if (buyukResim != null)
                {
                    repository.Delete(buyukResim);
                }

                await SaveChanges();

                return kullaniciResim;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public async Task<KullaniciResim> KullaniciProfilResimGetir(string kullaniciId)
        {
            KullaniciResim profilFoto = readOnlyRepository.GetQueryable<KullaniciResim>(p =>
                                                                       p.AktifMi == true &&
                                                                       p.ProfilFotografiMi == true &&
                                                                       p.KullaniciId == Guid.Parse(kullaniciId)).SingleOrDefault();
            return profilFoto;

        }
        public async Task<int> ProfilResminiDegistir(Guid kullaniciId, int resimId)
        {
            KullaniciResim eskiResim = readOnlyRepository.GetQueryable<KullaniciResim>(w => w.KullaniciId == kullaniciId && w.ProfilFotografiMi == true).SingleOrDefault();
            eskiResim.ProfilFotografiMi = false;
            repository.Update(eskiResim);
            SaveChanges();

            KullaniciResim yeniResim = readOnlyRepository.GetQueryable<KullaniciResim>(w => w.KullaniciResimId == resimId && w.KullaniciId == kullaniciId).SingleOrDefault();
            yeniResim.ProfilFotografiMi = true;
            repository.Update(yeniResim);
            return await SaveChanges();


        }
        public async Task<int> KullaniciResimSil(Guid kullaniciId, int resimId)
        {
            KullaniciResim resim = readOnlyRepository.GetQueryable<KullaniciResim>(w => w.KullaniciId == kullaniciId && w.KullaniciResimId == resimId).SingleOrDefault();
            if (resim == null)
            {
                return -1;
            }
            resim.AktifMi = false;
            repository.Update(resim);
            return await SaveChanges();
        }

        public async Task<IPagedList<KullaniciResimVM>> KullaniciListesiResimGetir(int start, int length, Guid kullaniciId)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<KullaniciResim>(
                    p => p.KullaniciId == kullaniciId &&
                    p.ProfilFotografiMi == false &&
                    (p.BuyukProfilFotografiMi == null || p.BuyukProfilFotografiMi == false) &&
                    p.AktifMi == true
                    );

                var total = query.Count();

                var resimler = query.OrderByDescending(p => p.EklenmeTarihi).Select(p => new KullaniciResimVM
                {
                    KullaniciResim = p.KullaniciResimId,
                    ResimYorum = p.ResimYorum,
                    ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : string.Empty,
                    EklenmeTarihi = p.EklenmeTarihi
                }).ToList();

                var buyukResim = readOnlyRepository.GetQueryable<KullaniciResim>(p => p.KullaniciId == kullaniciId &&
                                                                                 p.BuyukProfilFotografiMi == true &&
                                                                                 p.AktifMi == true).FirstOrDefault();

                if (buyukResim != null)
                {
                    KullaniciResimVM buyukResimVM = new KullaniciResimVM();
                    buyukResimVM = mapper.Map<KullaniciResim, KullaniciResimVM>(buyukResim);
                    buyukResimVM.ResimBase64 = buyukResimVM.Resim != null ? Convert.ToBase64String(buyukResimVM.Resim) : string.Empty;
                    buyukResimVM.KullaniciResim = buyukResimVM.KullaniciResimId;
                    resimler.Insert(0, buyukResimVM);
                }

                return await resimler.ToPagedListAsync((start <= 0 ? 1 : start), (length <= 0 ? (total <= 0 ? 1 : total) : length));

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<KullaniciResim> KullaniciBuyukProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResim)
        {
            KullaniciResim resim;

            resim = readOnlyRepository.GetQueryable<KullaniciResim>(w => w.KullaniciId == kullaniciResim.KullaniciId

                                                    && w.BuyukProfilFotografiMi == true
                                                    && w.AktifMi == true).FirstOrDefault();
            //Güncel büyük profil resmini yeni profil resmi ile güncelle    
            if (resim != null)
            {
                resim.Resim = kullaniciResim.Resim;
                resim.ResimUrl = kullaniciResim.ResimUrl;
                resim.ResimYorum = kullaniciResim.ResimYorum;
                resim.ResimUzanti = kullaniciResim.ResimUzanti;
                resim.EklenmeTarihi = kullaniciResim.EklenmeTarihi;

                repository.Update(resim);
            }
            else // Kullanıcının daha önceden eklediği bir büyük profil resmi yok ise
            {
                resim = new KullaniciResim();
                resim.KullaniciId = kullaniciResim.KullaniciId;
                resim.Resim = kullaniciResim.Resim;
                resim.ResimUrl = kullaniciResim.ResimUrl;
                resim.ResimUzanti = kullaniciResim.ResimUzanti;
                resim.ResimYorum = kullaniciResim.ResimYorum;
                resim.ProfilFotografiMi = kullaniciResim.ProfilFotografiMi;
                resim.AktifMi = kullaniciResim.AktifMi;
                resim.EklenmeTarihi = kullaniciResim.EklenmeTarihi;
                resim.BuyukProfilFotografiMi = kullaniciResim.BuyukProfilFotografiMi;
                repository.Create(resim);
            }

            try
            {
                await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resim;
        }
        public async Task<KullaniciResim> KullaniciBuyukProfilResimGetir(Guid KullaniciId)
        {
            try
            {
                KullaniciResim resim;

                resim = readOnlyRepository.GetQueryable<KullaniciResim>(w => w.KullaniciId == KullaniciId
                                                        && w.BuyukProfilFotografiMi == true
                                                        && w.AktifMi == true).FirstOrDefault();
                if (resim == null)
                {
                    var resim2 = readOnlyRepository.GetQueryable<KullaniciResim>(w => w.KullaniciId == KullaniciId
                                                        && w.ProfilFotografiMi == true
                                                        && w.AktifMi == true).FirstOrDefault();

                    return resim2;

                }
                else
                {
                    return resim;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region DuvarResim
        public async Task<List<DuvarResimVM>> DuvarResimleriniGetir()
        {
            try
            {
                IQueryable<DuvarResim> query = null;
                query = readOnlyRepository.GetQueryable<DuvarResim>(p => p.AktifMi == true);

                return await query.Select(p => new DuvarResimVM
                {
                    DuvarResimId = p.DuvarResimId,
                    Aciklama = p.Aciklama,
                    Adi = p.Adi,
                    Sira = p.Sira,
                    Resim = p.Resim,
                    AktifMi = p.AktifMi,
                    ResimUrl = p.KucukResimUrl,
                    ResimBase64 = p.KucukResim != null ? Convert.ToBase64String(p.KucukResim) : null,
                })
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> KullaniciDuvarResimDegistir(Guid kullaniciId, int resimId)
        {

            Kullanici kullanci = readOnlyRepository.GetQueryable<Kullanici>(w => w.KullaniciId == kullaniciId).SingleOrDefault();
            kullanci.DuvarResimId = resimId;
            repository.Update(kullanci);
            return await SaveChanges();

        }

        public async Task<int> KullaniciGoruntulenmeSayisiArtir(Guid kullaniciId)
        {
            int goruntulenmeSayisi = 0;
            Kullanici kullanici = readOnlyRepository.GetQueryable<Kullanici>(w => w.KullaniciId == kullaniciId).SingleOrDefault();
            if (kullanici != null)
            {
                kullanici.ProfilGoruntulenmeSayisi += 1;
                repository.Update(kullanici);
                var repo = await SaveChanges();
                goruntulenmeSayisi = kullanici.ProfilGoruntulenmeSayisi;
            }

            return goruntulenmeSayisi;
        }

        public async Task<DuvarResimVM> KullaniciDuvarResimGetir(Guid kullaniciId)
        {
            Kullanici kullanici = readOnlyRepository.GetQueryable<Kullanici>(w => w.KullaniciId == kullaniciId).SingleOrDefault();
            if (kullanici != null && kullanici.DuvarResimId.HasValue && kullanici.DuvarResimId > 0)
            {
                IQueryable<DuvarResim> query = null;
                query = readOnlyRepository.GetQueryable<DuvarResim>(p => p.AktifMi &&
                                                                         p.DuvarResimId == kullanici.DuvarResimId).AsNoTracking();

                return await query.Select(p => new DuvarResimVM
                {
                    DuvarResimId = p.DuvarResimId,
                    Aciklama = p.Aciklama,
                    Adi = p.Adi,
                    Sira = p.Sira,
                    Resim = p.Resim,
                    AktifMi = p.AktifMi,
                    ResimUrl = p.ResimUrl,
                    ResimBase64 = p.Resim != null ? Convert.ToBase64String(p.Resim) : null,
                    ResimUzanti = p.ResimUrl.Substring(0, p.ResimUrl.LastIndexOf(".") + 1)
                }).SingleOrDefaultAsync();
            }
            else
                return new DuvarResimVM();

        }


        public async Task<bool> KullaniciSil(Guid kullaniciId)
        {

            Kullanici kullanici = readOnlyRepository.GetQueryable<Kullanici>(w => w.KullaniciId == kullaniciId).SingleOrDefault();
            kullanici.HesapKilitliMi = true;
            repository.Update(kullanici);
            int isUpdate = await SaveChanges();
            bool response = isUpdate == 0 ? true : false;
            return response;

        }

        public async Task<bool> KullaniciAdiVarmi(KullaniciAdiVM kullanici)
        {
            var result = await readOnlyRepository.GetQueryable<Kullanici>(w => w.KullaniciAdi == kullanici.KullaniciAdi).FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<List<BildirimKullaniciGetirVM>> BildirimKullaniciListGetir(KisiyeOzelBildirimVM data)
        {
            var query = readOnlyRepository.GetQueryable<Kullanici>(q => q.AktifMi &&
                    (q.KullaniciAdi.Trim().StartsWith(data.KulaniciAdi.Trim())
                    || q.Adi.Trim().StartsWith(data.KulaniciAdi.Trim())
                    || q.Soyadi.Trim().StartsWith(data.KulaniciAdi.Trim()))).Select(p => new { p.KullaniciId, p.KullaniciAdi }).AsNoTracking();

            var urunler = query.Select(p => new BildirimKullaniciGetirVM { id = p.KullaniciId, text = p.KullaniciAdi }).ToListAsync();
            return await urunler;
        }
        #endregion

        #region KullaniciHediyeKart
        public async Task<int> KullaniciHediyeKartKayit(KullaniciHediyeKartKayitVM model)
        {
            try
            {
                KullaniciHediyeKart kullaniciHediyeKart = new KullaniciHediyeKart()
                {
                    AliciKullaniciId = model.AliciKullaniciId,
                    GonderenKullaniciId = model.GonderenKullaniciId,
                    Aciklama = model.Aciklama,
                    AktifMi = model.AktifMi,
                    KayitTarih = model.KayitTarih,
                    OkunduMu = model.OkunduMu,
                    HediyeKartId = model.HediyeKartId,
                    GonderenAktifMi = model.GonderenAktifMi,
                    AlanAktifMi = model.AlanAktifMi
                };
                repository.Create(kullaniciHediyeKart);
                await SaveChanges();
                return kullaniciHediyeKart.KullaniciHediyeKartId;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IPagedList<HediyeKartKonusmaListesiVM>> HediyeKartListGetir(HediyeKartListeVM hediyeKartAramaVM, Guid kullaniciId)
        {
            IPagedList<HediyeKartKonusmaListesiVM> resultList = new List<HediyeKartKonusmaListesiVM>().ToPagedList();

            try
            {
                var query = readOnlyRepository.GetQueryable<KullaniciHediyeKart>(p => p.AktifMi &&
                                                                                 ((p.AliciKullaniciId == kullaniciId && p.AlanAktifMi) || (p.GonderenKullaniciId == kullaniciId && p.GonderenAktifMi)))
                                              .IncludeMultiple(x => x.AliciKullanici, s => s.GonderenKullanici)
                                              .OrderByDescending(p => p.KayitTarih)
                                              .Select(p => new HediyeKartKonusmaListesiVM
                                              {
                                                  Adi = (p.GonderenKullaniciId == kullaniciId) ? p.AliciKullanici.Adi : p.GonderenKullanici.Adi,
                                                  ProfilResmiBase64 = (p.GonderenKullaniciId == kullaniciId) ? (p.AliciKullanici.KullaniciResim.Any() && p.AliciKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.AliciKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png") : (p.GonderenKullanici.KullaniciResim.Any() && p.GonderenKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.GonderenKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png"),
                                                  Soyadi = (p.GonderenKullaniciId == kullaniciId) ? p.AliciKullanici.Soyadi : p.GonderenKullanici.Soyadi,
                                                  KullaniciId = (p.GonderenKullaniciId == kullaniciId) ? p.AliciKullaniciId : p.GonderenKullaniciId,
                                                  Aciklama = string.IsNullOrEmpty(p.Aciklama) || p.Aciklama.Length > 10 ? p.Aciklama.Substring(0, 10) : p.Aciklama,
                                                  SonKonusmaTarihi = p.KayitTarih,
                                                  HediyeKartBase64 = Convert.ToBase64String(p.HediyeKart.Resim),
                                                  HediyeKartId = p.HediyeKartId,
                                                  OkunduMu = p.OkunduMu
                                              })
                                              .ToList();

                var hediyeKartList = query.GroupBy(p => p.KullaniciId).Select(g => g.First()).ToList();

                var totalCount = hediyeKartList.Count;

                return await hediyeKartList.ToPagedListAsync((hediyeKartAramaVM.start <= 0 ? 1 : hediyeKartAramaVM.start), (hediyeKartAramaVM.length <= 0 ? (totalCount <= 0 ? 1 : totalCount) : hediyeKartAramaVM.length));

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "HediyeKartListGetir", kullaniciId));

                return resultList;
            }
        }

        public async Task<IEnumerable<KullaniciHediyeKart>> HediyeKartDetayGetir(HediyeKartDetayGetirVM vm)
        {
            var query = readOnlyRepository.GetQueryable<KullaniciHediyeKart>(p => p.AktifMi && ((p.AliciKullaniciId == vm.AliciKullaniciId) && (p.GonderenKullaniciId == vm.GonderenKullaniciId)) ||
                                                                                           ((p.AliciKullaniciId == vm.GonderenKullaniciId) && (p.GonderenKullaniciId == vm.AliciKullaniciId)))
                                                          .IncludeMultiple(s => s.AliciKullanici, i => i.GonderenKullanici);

            var arkadasKullaniciList = await query
                                          .Where(p => p.AliciKullaniciId != vm.AliciKullaniciId && p.GonderenAktifMi)
                                          .Include("HediyeKart")
                                          .Include("AliciKullanici")
                                          .Include("GonderenKullanici")
                                          .ToListAsync();

            var kullaniciArkadasList = await query.Where(p => p.GonderenKullaniciId != vm.AliciKullaniciId && p.AlanAktifMi)
                                            .Include("HediyeKart")
                                            .Include("AliciKullanici")
                                            .Include("GonderenKullanici")
                                            .ToListAsync();

            arkadasKullaniciList.AddRange(kullaniciArkadasList);
            arkadasKullaniciList = arkadasKullaniciList.OrderBy(x => x.KayitTarih).Distinct().ToList();

            return arkadasKullaniciList;

        }
        public async Task<int> HediyeKartSil(KullaniciHediyeKart hediyeKart)
        {
            repository.Update(hediyeKart);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<KullaniciHediyeKart> HediyeKartGetir(int hediyeKartId)
        {
            return await readOnlyRepository.GetByIdAsync<KullaniciHediyeKart>(hediyeKartId);
        }

        public async Task<int> HediyeKartKonusmaSil(KonusmaSilVM vm, Guid silenKullaniciId)
        {
            try
            {
                var query = await readOnlyRepository.GetQueryable<KullaniciHediyeKart>(p => p.AktifMi && ((p.AliciKullaniciId == vm.SilenKullaniciId) && (p.GonderenKullaniciId == vm.GonderenKullaniciId)) ||
                                                                               (p.AliciKullaniciId == vm.GonderenKullaniciId && p.GonderenKullaniciId == vm.SilenKullaniciId))
                                              .IncludeMultiple(s => s.AliciKullanici, i => i.GonderenKullanici).ToListAsync();

                int silinmeSayisi = 0;

                foreach (var hediyeKart in query)
                {
                    if (hediyeKart.GonderenKullaniciId == silenKullaniciId)
                    {
                        if (hediyeKart.GonderenAktifMi != false)
                        {
                            hediyeKart.GonderenAktifMi = false;
                            repository.Update(hediyeKart);
                        }
                    }

                    if (hediyeKart.AliciKullaniciId == silenKullaniciId)
                    {
                        if (hediyeKart.AlanAktifMi != false)
                        {
                            hediyeKart.AlanAktifMi = false;
                            repository.Update(hediyeKart);
                            if (hediyeKart.OkunduMu == false)
                            {
                                silinmeSayisi++;
                            }
                        }
                    }
                }

                await SaveChanges();
                return silinmeSayisi;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region KullaniciBildirim
        public async Task<IPagedList<KullaniciBildirimVM>> KullaniciBildirimListGetir(KullaniciBildirimListeVM model)
        {
            IPagedList<KullaniciBildirimVM> resultList = new List<KullaniciBildirimVM>().ToPagedList();

            try
            {
                var query = readOnlyRepository.GetQueryable<Bildirim>(p => p.AktifMi &&
                                                                           p.KullaniciId == model.KullaniciId);

                var total = query.Count();

                return await query.OrderByDescending(p => p.KayitTarihi).Select(p => new KullaniciBildirimVM
                {
                    /*IlgiliKullaniciId = p.IlgiliKullaniciId,
                    IlgiliKullaniciAdi = p.IlgiliKullanici != null ? p.IlgiliKullanici.KullaniciAdi : null,
                    IlgiliKullaniciProfilResimBase64 = p.IlgiliKullanici == null ? "/Uploads/Site/user_icon.png" : (p.IlgiliKullanici.KullaniciResim.Any() && p.IlgiliKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.IlgiliKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png"),
                    BildirimId = p.BildirimId,*/
                    BildirimTipId = p.BildirimTipId,
                    BildirimIcerik = p.BildirimIcerik,
                    KayitTarihi = p.KayitTarihi.ToString("dd.MM.yyyy HH:mm"),
                    OkunduMu = p.OkunduMu,
                    AktifMi = p.AktifMi
                }).ToPagedListAsync((model.start <= 0 ? 1 : model.start), (model.length <= 0 ? (total <= 0 ? 1 : total) : model.length));
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> KullaniciBildirimEkle(KullaniciBildirimVM kullaniciBildirim)
        {
            try
            {
                var bildirimVarMi = readOnlyRepository.GetQueryable<Bildirim>().Where(p => p.KullaniciId == kullaniciBildirim.KullaniciId && p.BildirimTipId == kullaniciBildirim.BildirimTipId && p.BildirimIcerik == kullaniciBildirim.BildirimIcerik && p.OkunduMu == false).SingleOrDefault();

                if (bildirimVarMi != null)
                {
                    bildirimVarMi.KayitTarihi = DateTime.Now;
                    repository.Update(bildirimVarMi);
                }
                else
                {
                    var bildirim = mapper.Map<KullaniciBildirimVM, Bildirim>(kullaniciBildirim);
                    bildirim.KayitTarihi = DateTime.Now;
                    bildirim.OkunduMu = false;
                    bildirim.AktifMi = true;
                    repository.Create(bildirim);
                }
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciBildirimEkle", kullaniciBildirim.KullaniciId));
                return false;
            }
        }
        public async Task<bool> KullaniciBildirimSil(KullaniciBildirimVM kullaniciBildirim)
        {
            try
            {
                var bildirim = readOnlyRepository.GetQueryable<Bildirim>().Where(p => p.KullaniciId == kullaniciBildirim.KullaniciId &&
                                                                                    p.BildirimTipId == kullaniciBildirim.BildirimTipId &&
                                                                                    p.BildirimIcerik == kullaniciBildirim.BildirimIcerik).SingleOrDefault();

                if (bildirim != null)
                {
                    repository.Delete(bildirim);
                    await SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciBildirimEkle", kullaniciBildirim.KullaniciId));
                return false;
            }
        }

        public async Task<List<KullaniciBildirimVM>> KullaniciHeaderBildirimListGetir(Guid kullaniciId)
        {
            List<KullaniciBildirimVM> result = new List<KullaniciBildirimVM>();

            try
            {
                result = await readOnlyRepository.GetQueryable<Bildirim>(w => w.KullaniciId == kullaniciId && w.AktifMi && !w.OkunduMu)
                                                 .OrderByDescending(p => p.KayitTarihi).Select(p => new KullaniciBildirimVM
                                                 {
                                                     KullaniciId = p.KullaniciId,
                                                     BildirimTipId = p.BildirimTipId,
                                                     BildirimIcerik = p.BildirimIcerik,
                                                     KayitTarihi = p.KayitTarihi.ToString("dd.MM.yyyy HH:mm"),
                                                     OkunduMu = p.OkunduMu,
                                                     AktifMi = p.AktifMi
                                                 })
                                                 .ToListAsync();


                return result;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciHeaderBildirimListGetir", kullaniciId));
                throw;
            }
        }
        public async Task<bool> KullaniciBildirimOkundu(Guid kullaniciId)
        {
            try
            {
                var query = await readOnlyRepository.GetQueryable<Bildirim>(p => p.AktifMi && p.KullaniciId == kullaniciId).ToListAsync();
                foreach (var bildirim in query)
                {
                    if (!bildirim.OkunduMu)
                    {
                        bildirim.OkunduMu = true;
                        repository.Update(bildirim);
                        await SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciBildirimOkundu", kullaniciId));
                return false;
            }
        }

        public async Task<int> TopluBildirimGonder(IletisimTopluBildirimVM bildirim)
        {
            try
            {
                if (bildirim.BildirimId > 0)
                {
                    var bildirimGetir = await readOnlyRepository.GetQueryable<Bildirim>().Where(p => p.BildirimId == bildirim.BildirimId).FirstOrDefaultAsync();
                    bildirimGetir.BildirimIcerik = bildirim.BildirimIcerik;
                    repository.Update(bildirimGetir);
                    await SaveChanges();
                    return bildirimGetir.BildirimId;
                }
                else
                {
                    List<Kullanici> kullanicilar = new List<Kullanici>();
                    if (bildirim.Cinsiyet == null && bildirim.IliskiDurumu == null)
                    {
                        kullanicilar = await readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi).ToListAsync();
                    }
                    else if (bildirim.IliskiDurumu == null)
                    {
                        kullanicilar = await readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && p.Cinsiyet == bildirim.Cinsiyet).ToListAsync();
                    }
                    else if (bildirim.Cinsiyet == null)
                    {
                        if (bildirim.IliskiDurumu == "BI")
                        {
                            kullanicilar = await readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && (p.IliskiDurumu == bildirim.IliskiDurumu || p.IliskiDurumu == null)).ToListAsync();
                        }
                        else
                        {
                            kullanicilar = await readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && p.IliskiDurumu == bildirim.IliskiDurumu).ToListAsync();
                        }
                    }
                    else
                    {
                        if (bildirim.IliskiDurumu == "BI")
                        {
                            kullanicilar = await readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && (p.IliskiDurumu == bildirim.IliskiDurumu || p.IliskiDurumu == null) && p.Cinsiyet == bildirim.Cinsiyet).ToListAsync();
                        }
                        else
                        {
                            kullanicilar = await readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && p.IliskiDurumu == bildirim.IliskiDurumu && p.Cinsiyet == bildirim.Cinsiyet).ToListAsync();
                        }
                    }

                    if (kullanicilar.Count != 0)
                    {
                        Bildirim bildirimGonder = new Bildirim();
                        foreach (var kullanici in kullanicilar)
                        {
                            bildirimGonder = new Bildirim();
                            bildirimGonder.KayitTarihi = DateTime.Now;
                            bildirimGonder.OkunduMu = false;
                            bildirimGonder.AktifMi = true;
                            bildirimGonder.BildirimIcerik = bildirim.BildirimIcerik;
                            bildirimGonder.BildirimTipId = 7;
                            bildirimGonder.KullaniciId = kullanici.KullaniciId;
                            repository.Create(bildirimGonder);
                        }
                        await SaveChanges();
                        return bildirimGonder.BildirimId;
                    }

                    return 0;
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "TopluBildirimGonder", bildirim.BildirimId));
                return 0;
            }
        }

        public async Task<List<BildirimAramaResultVM>> TumBildirimleriGetir(BildirimAramaVM bildirimAramaVM)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<Bildirim>(p => (p.BildirimTipId == 7));

                if (bildirimAramaVM.BildirimIcerik != null)
                {
                    query = query.Where(x => (x.BildirimIcerik.Contains(bildirimAramaVM.BildirimIcerik)));
                }

                if (bildirimAramaVM.AktifMi == -1)
                {
                    query = query.Where(x => (x.AktifMi == true || x.AktifMi == false));
                }
                else
                {
                    query = query.Where(x => (x.AktifMi == Convert.ToBoolean(bildirimAramaVM.AktifMi)));
                }

                var sonuc = query.GroupBy(x => x.BildirimIcerik, x => x.OkunduMu)
                    .Select(x => new BildirimAramaResultVM
                    {
                        BildirimIcerik = x.Key,
                        Adet = x.Count(),
                        Okunan = query.Where(a => a.BildirimIcerik == x.Key && a.OkunduMu == true).Count(),
                        Okunmayan = query.Where(a => a.BildirimIcerik == x.Key && a.OkunduMu == false).Count(),
                        BildirimId = query.Where(a => a.BildirimIcerik == x.Key).Select(p => p.BildirimId).FirstOrDefault()
                    });


                return await sonuc.OrderByDescending(p => p.BildirimId)
                                    .Select(p => new BildirimAramaResultVM
                                    {
                                        BildirimIcerik = p.BildirimIcerik,
                                        Adet = p.Adet,
                                        Okunan = p.Okunan,
                                        Okunmayan = p.Okunmayan,
                                        TotalCount = sonuc.Count()
                                    }).Skip(bildirimAramaVM.start)
                                    .Take(bildirimAramaVM.length)
                                    .ToListAsync();

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "TumBildirimleriGetir", bildirimAramaVM.BildirimId));
                throw;
            }
        }

        public async Task<int> BildirimSil(int id)
        {
            try
            {
                Bildirim updateBildirim = readOnlyRepository.GetQueryable<Bildirim>(w => w.BildirimId == id).Single();
                updateBildirim.AktifMi = false;
                repository.Update(updateBildirim);
                return await SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "BildirimSil", id));
                throw;
            }
        }
        public async Task<bool> KullaniciTumBildirimleriSil(Guid kullaniciId)
        {
            try
            {
                var query = await readOnlyRepository.GetQueryable<Bildirim>(p => p.AktifMi && p.KullaniciId == kullaniciId).ToListAsync();
                foreach (var bildirim in query)
                {
                    repository.Delete(bildirim);
                }
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KullaniciTumBildirimleriSil", kullaniciId));
                return false;
            }
        }

        public async Task<HediyeKartIcerikVM> HediyeKartMesajIcerikGetirById(int id)
        {
            HediyeKartIcerikVM result = new HediyeKartIcerikVM();

            try
            {
                result = await readOnlyRepository.GetQueryable<KullaniciHediyeKart>(w => w.KullaniciHediyeKartId == id)
                                                 .Include("HediyeKart")
                                                 .Select(p => new HediyeKartIcerikVM
                                                 {
                                                     HediyeKartId = p.HediyeKartId,
                                                     HediyeKartAdi = p.HediyeKart.HediyeKartAdi,
                                                     Aciklama = p.Aciklama,
                                                     ResimBase64 = p.HediyeKart.Resim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.HediyeKart.Resim)) : "/Uploads/Site/blog_empty_image_500_500.png",
                                                 })
                                                 .SingleOrDefaultAsync();


                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> HediyeKartOkunduIsaretle(HediyeKartOkunduVM hediyeKartOkundu)
        {
            var query = readOnlyRepository.GetQueryable<KullaniciHediyeKart>(p => p.AktifMi && p.AlanAktifMi && ((p.AliciKullaniciId == hediyeKartOkundu.AliciKullaniciId) && (p.GonderenKullaniciId == hediyeKartOkundu.GonderenKullaniciId)))
                                                         .IncludeMultiple(s => s.AliciKullanici, i => i.GonderenKullanici);

            var okunduSayisi = 0;
            foreach (var item in query)
            {
                if (item.OkunduMu == false)
                {
                    item.OkunduMu = true;
                    repository.Update(item);
                    okunduSayisi++;
                }
            }
            await SaveChanges();

            return okunduSayisi;

        }

        public async Task<int> BildirimSayisiGetir(IletisimTopluBildirimVM bildirim)
        {
            try
            {
                var kullanicilar = 0;

                if (bildirim.Cinsiyet == null && bildirim.IliskiDurumu == null)
                {
                    kullanicilar = readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi).Count();
                }
                else if (bildirim.IliskiDurumu == null)
                {
                    kullanicilar = readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && p.Cinsiyet == bildirim.Cinsiyet).Count();
                }
                else if (bildirim.Cinsiyet == null)
                {
                    if (bildirim.IliskiDurumu == "BI")
                    {
                        kullanicilar = readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && (p.IliskiDurumu == bildirim.IliskiDurumu || p.IliskiDurumu == null)).Count();
                    }
                    else
                    {
                        kullanicilar = readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && p.IliskiDurumu == bildirim.IliskiDurumu).Count();
                    }
                }
                else
                {
                    if (bildirim.IliskiDurumu == "BI")
                    {
                        kullanicilar = readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && (p.IliskiDurumu == bildirim.IliskiDurumu || p.IliskiDurumu == null) && p.Cinsiyet == bildirim.Cinsiyet).Count();
                    }
                    else
                    {
                        kullanicilar = readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.AktifMi && p.IliskiDurumu == bildirim.IliskiDurumu && p.Cinsiyet == bildirim.Cinsiyet).Count();
                    }
                }

                return kullanicilar;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "BildirimSayisiGetir", bildirim.BildirimId));
                return 0;
            }
        }

        public async Task<int> KisiyeOzelBildirimGonder(KisiyeOzelBildirimVM bildirim)
        {
            try
            {
                if (bildirim.BildirimId > 0)
                {
                    var bildirimGetir = await readOnlyRepository.GetQueryable<Bildirim>().Where(p => p.BildirimId == bildirim.BildirimId).FirstOrDefaultAsync();
                    bildirimGetir.BildirimIcerik = bildirim.BildirimIcerik;
                    repository.Update(bildirimGetir);
                    await SaveChanges();
                    return bildirimGetir.BildirimId;
                }
                else
                {
                    Bildirim bildirimGonder = new Bildirim();

                    bildirimGonder = new Bildirim();
                    bildirimGonder.KayitTarihi = DateTime.Now;
                    bildirimGonder.OkunduMu = false;
                    bildirimGonder.AktifMi = true;
                    bildirimGonder.BildirimIcerik = bildirim.BildirimIcerik;
                    bildirimGonder.BildirimTipId = 8;
                    bildirimGonder.KullaniciId = bildirim.KullaniciId;
                    repository.Create(bildirimGonder);

                    await SaveChanges();
                    return bildirimGonder.BildirimId;
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KisiyeOzelBildirimGonder", bildirim.BildirimId));
                return 0;
            }
        }
        public async Task<KullaniciBildirimVM> BildirimIdBildirimGetir(int id)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<Bildirim>(p => p.BildirimId == id).FirstOrDefault();

                KullaniciBildirimVM bildirim = mapper.Map<Bildirim, KullaniciBildirimVM>(query);
                return bildirim;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "BildirimIdBildirimGetir", id));
                throw;
            }
        }
        public async Task<List<KisiyeOzelBildirimAramaSonucVM>> KisiyeOzelBildirimleriGetir(BildirimAramaVM bildirimAramaVM)
        {
            try
            {
                var query = readOnlyRepository.GetQueryable<Bildirim>(p => (p.BildirimTipId == 8));

                if (bildirimAramaVM.BildirimIcerik != null)
                {
                    query = query.Where(x => (x.BildirimIcerik.Contains(bildirimAramaVM.BildirimIcerik)));
                }

                if (bildirimAramaVM.AktifMi != -1)
                {
                    query = query.Where(x => (x.AktifMi == Convert.ToBoolean(bildirimAramaVM.AktifMi)));
                }

                var kullanicilar = readOnlyRepository.GetQueryable<Kullanici>().AsNoTracking();

                var total = await query.CountAsync();

                var sonuc = query.OrderByDescending(p => p.KayitTarihi).Select(x => new KisiyeOzelBildirimAramaSonucVM
                {
                    BildirimId = x.BildirimId,
                    KullaniciAdi = kullanicilar.Where(p => p.KullaniciId == x.KullaniciId).Select(p => p.KullaniciAdi).FirstOrDefault(),
                    Adi = kullanicilar.Where(p => p.KullaniciId == x.KullaniciId).Select(p => p.Adi).FirstOrDefault(),
                    Soyadi = kullanicilar.Where(p => p.KullaniciId == x.KullaniciId).Select(p => p.Soyadi).FirstOrDefault(),
                    MesajIcerigi = x.BildirimIcerik,
                    KullaniciAktifMi = kullanicilar.Where(p => p.KullaniciId == x.KullaniciId).Select(p => p.AktifMi).FirstOrDefault(),
                    OkunduMu = x.OkunduMu,
                    AktifMi = x.AktifMi,
                    TotalCount = total,
                }).Skip(bildirimAramaVM.start)
                  .Take(bildirimAramaVM.length)
                  .ToListAsync();


                return await sonuc;

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "KisiyeOzelBildirimleriGetir", bildirimAramaVM.BildirimId));
                throw;
            }
        }

        public async Task<int> KullaniciHeaderSepetUrunSayisiGetir(Guid kullaniciId)
        {
            return readOnlyRepository.GetQueryable<Sepet>(p => p.KullaniciId == kullaniciId && p.AktifMi == true).Select(p => p.Adet).Sum();
        }

        #endregion

        #region SifremiUnuttum
        public async Task<ResultModel> KullaniciYeniSifreGonder(KullaniciSifreGonderVM model, Common.Models.Program.AyarlarVM ayarlar)
        {
            try
            {
                ResultModel result = new ResultModel();
                var Kullanici = readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.Eposta == model.GirilenMailAdresi).SingleOrDefault();
                if (Kullanici == null)
                {
                    result.ErrorMessage = "Mail adresini yanlış girdiniz";
                    result.Type = ResultType.Basarisiz;
                    return result;
                }
                else
                {
                    var sifre = model.YeniSifre;
                    Kullanici.Sifre = sifre.Encode();

                    string icerik = "<p> Merhaba,</p>" +
                                    "<p> Şifre yenileme talebinizi aldık.</p>" +
                                    "<p><span style = 'text-decoration: underline;'> <strong>" + sifre + "&nbsp;&nbsp;</strong></span>yeni şifreniz ile giriş yapabilirsiniz.</p>" +
                                    "<p></p>" +
                                    "<p></p>";

                    SmtpClient smtpClient = new SmtpClient(ayarlar.GonderilecekEpostaHost, ayarlar.GonderilecekEpostaPort);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(ayarlar.GonderilecekEpostaKullaniciAdi, ayarlar.GonderilecekEpostaSifre);
                    smtpClient.EnableSsl = ayarlar.SslAktifMi;

                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.Subject = "Şifre Yenileme Talebi";
                    mail.Body = icerik;
                    mail.From = new MailAddress(ayarlar.GonderilecekEpostaKullaniciAdi, ayarlar.GonderilecekEpostaTanim);
                    mail.To.Add(new MailAddress(model.GirilenMailAdresi));

                    await smtpClient.SendMailAsync(mail);

                    repository.Update(Kullanici);
                    await SaveChanges();

                    result.Data = true;
                    result.Type = ResultType.Basarili;
                    return result;
                }


            }
            catch (Exception ex)
            {
                return new ResultModel { Type = ResultType.Basarisiz, ErrorMessage = "Bir hata oluştu" };
            }
        }
        #endregion

        public async Task<bool> KullaniciHosgeldinEpostaGonder(KullaniciKayitVM vm, Common.Models.Program.AyarlarVM ayarlar)
        {
            try
            {
                ResultModel result = new ResultModel();
                var Kullanici = readOnlyRepository.GetQueryable<Kullanici>().Where(p => p.Eposta == vm.KullaniciKayitEposta).SingleOrDefault();


                string icerik = "<div style = 'text-align: center;'><p style = 'color:purple; font-weight:bold;'>NESEVER</p><br>" +
                                "<p style = 'color:black;'>Hoş geldin <span style = 'font-weight:bold; text-transfrom: uppercase;'>" + vm.KullaniciKayitAd + "</span>,</p><br>" +
                                "<p style = 'color:black;'>Aramıza katılman bizi çook mutlu etti</p><br>" +
                                "<p style = 'color:black;'>Beğendiğin ve istediğin hediyeleri sen profiline ekle yeter.</p>" +
                                "<p style = 'color:black;'>Biz senin için sevdiklerine ulaşmaya çalışıyor olacağız.</p><br>" +
                                "<p style = 'color:black;'>Peki sevdiklerin Ne Sever?</p>" +
                                "<p style = 'color:black;'>Onlarda bize katıldıklarında birlikte öğreneceğiz.</p><br><br>" +
                                "<p style = 'font-size:10px; color:black;'>Bu e-posta nesever.com.tr internet sitesinde üyelik veritabanına kaydolunması sebebiyle oluşturulmuş ve gönderilmiştir.Şüpheli bir durum halinde <a href = 'mailto: info@nesever.com.tr'>  info@nesever.com.tr </a> adresine bildirimde bulunabilirsiniz.</p></div>";

                SmtpClient smtpClient = new SmtpClient(ayarlar.GonderilecekEpostaHost, ayarlar.GonderilecekEpostaPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(ayarlar.GonderilecekEpostaKullaniciAdi, ayarlar.GonderilecekEpostaSifre);
                smtpClient.EnableSsl = ayarlar.SslAktifMi;

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.Subject = "Hoş Geldiniz";
                mail.Body = icerik;
                mail.From = new MailAddress(ayarlar.GonderilecekEpostaKullaniciAdi, ayarlar.GonderilecekEpostaTanim);
                mail.To.Add(new MailAddress(vm.KullaniciKayitEposta));

                await smtpClient.SendMailAsync(mail);

                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        #region Kullanıcı Mesaj
        public async Task<int> OkunmamisMesajSayisiGetir(Guid kullaniciId)
        {
            int result = 0;

            try
            {
                result = await readOnlyRepository.GetQueryable<KullaniciMesaj>(p => p.AktifMi &&
                                                                                    !p.OkunduMu &&
                                                                                    p.AlanAktifMi &&
                                                                                    p.AliciKullaniciId == kullaniciId).AsNoTracking()
                                                                                                                      .CountAsync();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "DataService", "UyelikDataService", "OkunmamisMesajSayisiGetir", kullaniciId));
            }

            return result;
        }

        public async Task<IEnumerable<KullaniciMesaj>> OkunmamisMesajlariGetir(MesajDetayGetirVM vm)
        {
            var query = readOnlyRepository
                .GetQueryable<KullaniciMesaj>(p => p.AktifMi && !p.OkunduMu &&
                                             ((p.AliciKullaniciId == vm.AliciKullaniciId)))
                .IncludeMultiple(s => s.AliciKullanici);

            var okunmamisMesajList = await query.ToListAsync();
            return okunmamisMesajList;

        }

        public async Task<int> MesajlariOku(IEnumerable<KullaniciMesaj> istek)
        {
            repository.UpdateRange<KullaniciMesaj>(istek);
            try
            {
                return await SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}