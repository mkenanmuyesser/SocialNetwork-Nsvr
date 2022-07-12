using AutoMapper;
using HappyFit.Data.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NeSever.Common.Infra.DataLayer;
using NeSever.Common.Models.Satis;
using NeSever.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace NeSever.Data.DataService.Program
{
    public interface ISatisDataService
    {
        #region Sepet

        #region Admin


        #endregion

        #region FrontEnd

        Task<OnBilgilendirmeFormuVM> OnBilgilendirmeFormuGetir();
        Task<MesafeliSatisSozlesmesiVM> MesafeliSatisSozlesmesiGetir();
        Task<SepetIcerikVM> KullaniciSepetGetir(SepetVM model);
        Task<bool> KullaniciSepetTemizle(SepetVM model);
        Task<int> KullaniciSepetUrunArttir(SepetVM model);
        Task<bool> KullaniciSepetUrunEksilt(SepetVM model);
        Task<bool> KullaniciSepetUrunSil(SepetVM model);
        Task<List<SepetAdresVM>> KullaniciSepetAdresleriGetir(KullaniciAdresVM model);
        Task<SepetAdresVM> KullaniciSepetAdresGetir(SepetAdresVM model);
        Task<bool> KullaniciSepetAdresKaydetGuncelle(SepetAdresVM model);
        Task<bool> KullaniciSepetAdresSil(SepetAdresVM model);
        Task<AdresIcerikVM> KullaniciAdreslerGetir(AdresVM model);
        Task<OdemeIcerikVM> KullaniciOdemeGetir(OdemeVM model);
        Task<int> KullaniciOdemeYap(OdemeIcerikVM model);
        Task<OdemeSonucVM> KullaniciOdemeSonucGetir(OdemeVM model);
        Task<List<AdresIlceVM>> SepetAdresIlceGetir(int id);
        Task<bool> KullaniciOdemeSil(int id);

        #endregion

        #endregion

        #region Sipariş

        #region Admin
        Task<List<AdresIlVM>> SatisAdresIlGetir();
        Task<List<OdemeDurumTipVM>> OdemeDurumTipListesiGetir();
        Task<List<SiparisDurumTipVM>> SiparisDurumTipListesiGetir();
        Task<List<SiparisOdemeTipVM>> SiparisOdemeTipListesiGetir();
        Task<List<SiparisAramaSonucVM>> SiparisAramaSonuc(SiparisAramaVM model);
        Task<int> SiparisSil(int id);
        Task<SiparisAramaDetayVM> SiparisDetay(int id);
        Task<bool> SiparisGuncelle(SiparisAramaDetayVM model);
        Task<bool> SiparisHareketKaydet(SiparisAramaDetayVM model);
        Task<bool> SiparisHareketSil(int id);
        Task<bool> SiparisDetayDurum(int id);

        #endregion

        #region FrontEnd

        Task<List<SiparisVM>> KullaniciSiparisListesiGetir(KullaniciSiparisVM model);
        Task<SiparisVM> KullaniciSiparisDetayGetir(KullaniciSiparisVM model);
        Task<bool> KullaniciSiparisGuncelle(KullaniciSiparisVM model);

        #endregion

        #endregion
    }
    public class SatisDataService : BaseDataService, ISatisDataService
    {
        IUnitOfWork unitOfWork;
        private readonly IRepository repository;
        private readonly IReadOnlyRepository readOnlyRepository;
        private readonly ILogger<ProgramDataService> logger;
        private readonly IMapper mapper;
        private bool fileServerIsActive;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public SatisDataService(IUnitOfWork unitOfWork,
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

            var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings");
            if (appSettings != null)
            {
                fileServerIsActive = Convert.ToBoolean(appSettings["FileServerIsActive"]);
            }
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }

        #region Sepet

        #region Admin


        #endregion

        #region FrontEnd

        public async Task<OnBilgilendirmeFormuVM> OnBilgilendirmeFormuGetir()
        {
            return await readOnlyRepository.GetQueryable<Ayarlar>()
                                           .AsNoTracking()
                                           .Select(p => new OnBilgilendirmeFormuVM
                                           {
                                               OnBilgilendirmeFormu = p.OnBilgilendirmeFormu
                                           })
                                           .FirstOrDefaultAsync();
        }

        public async Task<MesafeliSatisSozlesmesiVM> MesafeliSatisSozlesmesiGetir()
        {
            return await readOnlyRepository.GetQueryable<Ayarlar>()
                                           .AsNoTracking()
                                           .Select(p => new MesafeliSatisSozlesmesiVM
                                           {
                                               MesafeliSatisSozlesmesi = p.MesafeliSatisSozlesmesi
                                           })
                                           .FirstOrDefaultAsync();
        }

        public async Task<SepetIcerikVM> KullaniciSepetGetir(SepetVM model)
        {
            var query = readOnlyRepository.GetQueryable<Sepet>(p => p.AktifMi &&
                                                                    p.Adet > 0 &&
                                                                    p.KullaniciId == model.KullaniciId).AsNoTracking().Include("Urun.UrunResim");

            SepetIcerikVM result = new SepetIcerikVM()
            {
                //KullaniciId = model.KullaniciId,
                SepetUrunList = await query.Select(p => new SepetUrunVM()
                {
                    Resim = p.Urun.UrunResim.Any() ? (p.Urun.UrunResim.FirstOrDefault().Resim == null ? (fileServerIsActive ? (p.Urun.UrunResim.FirstOrDefault().ResimUrl.Replace(@"\", "/")) : (p.Urun.UrunResim.FirstOrDefault().OrjinalResimUrl)) : string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Urun.UrunResim.FirstOrDefault().Resim))) : "/Uploads/Site/blog_empty_image_500_500.png",
                    UrunId = p.UrunId,
                    MarkaId = p.Urun.MarkaId,
                    UrunAdi = p.Urun.UrunAdi,
                    MarkaAdi = p.Urun.Marka.MarkaAdi,
                    Adet = p.Adet,
                    UrunBirimFiyat = p.Urun.Fiyat,
                    UrunToplamFiyat = p.Adet * p.Urun.Fiyat,
                }).ToListAsync(),
            };

            result.KdvDahilTutar = result.SepetUrunList.Sum(p => p.UrunToplamFiyat);
            result.KdvTutar = result.KdvDahilTutar * 0.18m;
            result.KdvHaricTutar = result.KdvDahilTutar - result.KdvTutar;
            result.GonderimTutar = 0;
            result.OdemeYontemiTutar = 0;
            result.IndirimTutar = 0;
            result.OdenecekTutar = result.KdvDahilTutar + result.GonderimTutar + result.OdemeYontemiTutar + result.IndirimTutar;

            return result;
        }

        public async Task<bool> KullaniciSepetTemizle(SepetVM model)
        {
            var query = readOnlyRepository.GetQueryable<Sepet>(p => p.AktifMi &&
                                                                    p.KullaniciId == model.KullaniciId);

            foreach (var sepet in query)
            {
                sepet.AktifMi = false;
                repository.Update(sepet);
            }

            await SaveChanges();

            return true;
        }

        public async Task<int> KullaniciSepetUrunArttir(SepetVM model)
        {
            var sepetUrun = readOnlyRepository.GetQueryable<Sepet>(p => p.AktifMi &&
                                                                   p.KullaniciId == model.KullaniciId &&
                                                                   p.UrunId == model.UrunId).FirstOrDefault();

            var urun = readOnlyRepository.GetQueryable<Urun>(p => p.AktifMi && p.SatilabilirUrun).AsNoTracking().FirstOrDefault();

            if (urun != null && urun.Fiyat > 0)
            {
                if (sepetUrun == null)
                {
                    sepetUrun = new Sepet()
                    {
                        UrunId = model.UrunId,
                        KullaniciId = model.KullaniciId,
                        SepetTipId = 1,
                        OlusturmaTarihi = DateTime.Now,
                        GuncellemeTarihi = DateTime.Now,
                        AktifMi = true,
                    };

                    sepetUrun.Adet += model.Adet;

                    repository.Create<Sepet>(sepetUrun);
                }
                else
                {
                    sepetUrun.Adet += model.Adet;
                }

                await SaveChanges();

            }

            var result = readOnlyRepository.GetQueryable<Sepet>(p => p.KullaniciId == model.KullaniciId && p.AktifMi == true).Select(p => p.Adet).Sum();

            return result;
        }

        public async Task<bool> KullaniciSepetUrunEksilt(SepetVM model)
        {
            var urun = readOnlyRepository.GetQueryable<Sepet>(p => p.AktifMi &&
                                                                     p.KullaniciId == model.KullaniciId &&
                                                                     p.UrunId == model.UrunId).FirstOrDefault();

            if (urun != null)
            {
                urun.Adet--;

                if (urun.Adet <= 0)
                    urun.AktifMi = false;

                await SaveChanges();
            }

            return true;
        }

        public async Task<bool> KullaniciSepetUrunSil(SepetVM model)
        {
            var urun = readOnlyRepository.GetQueryable<Sepet>(p => p.AktifMi &&
                                                                      p.KullaniciId == model.KullaniciId &&
                                                                      p.UrunId == model.UrunId).FirstOrDefault();

            if (urun != null)
            {
                urun.AktifMi = false;
                await SaveChanges();
            }

            return true;
        }

        public async Task<List<SepetAdresVM>> KullaniciSepetAdresleriGetir(KullaniciAdresVM model)
        {
            var result = new List<SepetAdresVM>();

            var kullaniciAdreslerQuery = readOnlyRepository.GetQueryable<Adres>(p => p.AktifMi &&
                                                                                     p.KullaniciId == model.KullaniciId).AsNoTracking().Include("AdresIl").Include("FaturaTip");

            result = kullaniciAdreslerQuery.Select(p => new SepetAdresVM()
            {
                AdresId = p.AdresId,
                KullaniciId = p.KullaniciId,
                FaturaTipId = p.FaturaTipId,
                FaturaTipAdi = p.FaturaTip.Adi,
                AdresAdi = p.AdresAdi,
                Ad = p.Ad,
                Soyad = p.Soyad,
                TcNo = p.TcNo,
                FirmaUnvan = p.FirmaUnvan,
                VergiNo = p.VergiNo,
                VergiDairesi = p.VergiDairesi,
                AdresBilgi = p.AdresBilgi,
                Aciklama = p.Aciklama,
                PostaKodu = p.PostaKodu,
                AdresIlId = p.AdresIlId,
                AdresIlceId = p.AdresIlceId,
                AdresIlAdi = p.AdresIl.IlAdi,
                AdresIlceAdi = p.AdresIlce.IlceAdi,
                Telefon1 = p.Telefon1,
                Telefon2 = p.Telefon2
            }).ToList();

            return result;
        }

        public async Task<SepetAdresVM> KullaniciSepetAdresGetir(SepetAdresVM model)
        {
            SepetAdresVM result = new SepetAdresVM();
            if (model.AdresId == 0)
            {
                result.AdresIlListesi = readOnlyRepository.GetQueryable<AdresIl>()
                                           .AsNoTracking()
                                           .Select(p => new AdresIlVM
                                           {
                                               AdresIlId = p.AdresIlId,
                                               IlAdi = p.IlAdi,
                                               AktifMi = p.AktifMi
                                           }).ToList();
                result.AdresIlceListesi = new List<AdresIlceVM>();
                return result;
            }

            var adres = await readOnlyRepository.GetQueryable<Adres>(p => p.KullaniciId == model.KullaniciId &&
                                                                          p.AdresId == model.AdresId).AsNoTracking().Include("AdresIl").Include("AdresIlce").FirstOrDefaultAsync();

            result.AdresId = adres.AdresId;
            result.KullaniciId = adres.KullaniciId;
            result.FaturaTipId = adres.FaturaTipId;
            result.AdresAdi = adres.AdresAdi;
            result.Ad = adres.Ad;
            result.Soyad = adres.Soyad;
            result.TcNo = adres.TcNo;
            result.FirmaUnvan = adres.FirmaUnvan;
            result.VergiNo = adres.VergiNo;
            result.VergiDairesi = adres.VergiDairesi;
            result.AdresBilgi = adres.AdresBilgi;
            result.Aciklama = adres.Aciklama;
            result.PostaKodu = adres.PostaKodu;
            result.AdresIlId = adres.AdresIlId;
            result.AdresIlceId = adres.AdresIlceId;
            result.AdresIlAdi = adres.AdresIl.IlAdi;
            result.AdresIlceAdi = adres.AdresIlce.IlceAdi;
            result.Telefon1 = adres.Telefon1;
            result.Telefon2 = adres.Telefon2;
            result.AdresIlListesi = readOnlyRepository.GetQueryable<AdresIl>()
                                           .AsNoTracking()
                                           .Select(p => new AdresIlVM
                                           {
                                               AdresIlId = p.AdresIlId,
                                               IlAdi = p.IlAdi,
                                               AktifMi = p.AktifMi
                                           }).ToList();
            result.AdresIlceListesi = readOnlyRepository.GetQueryable<AdresIlce>(p => p.AdresIlId == adres.AdresIlId)
                                           .AsNoTracking()
                                           .Select(p => new AdresIlceVM
                                           {
                                               AdresIlId = p.AdresIlId,
                                               AdresIlceId = p.AdresIlceId,
                                               IlceAdi = p.IlceAdi,
                                               AktifMi = p.AktifMi
                                           }).ToList();

            return result;
        }

        public async Task<bool> KullaniciSepetAdresKaydetGuncelle(SepetAdresVM model)
        {
            Adres adres = new Adres();

            if (model.AdresId > 0)
            {
                adres = await readOnlyRepository.GetQueryable<Adres>(p => p.AktifMi &&
                                                                          p.KullaniciId == model.KullaniciId &&
                                                                          p.AdresId == model.AdresId).FirstOrDefaultAsync();
            }

            adres.AdresId = model.AdresId;
            adres.KullaniciId = model.KullaniciId;
            adres.FaturaTipId = model.FaturaTipId;
            adres.AdresAdi = model.AdresAdi;
            adres.Ad = model.Ad;
            adres.Soyad = model.Soyad;
            adres.TcNo = model.TcNo;
            adres.FirmaUnvan = model.FirmaUnvan;
            adres.VergiNo = model.VergiNo;
            adres.VergiDairesi = model.VergiDairesi;
            adres.AdresBilgi = model.AdresBilgi;
            adres.Aciklama = model.Aciklama;
            adres.PostaKodu = model.PostaKodu;
            adres.AdresIlId = model.AdresIlId;
            adres.AdresIlceId = model.AdresIlceId;
            adres.Telefon1 = model.Telefon1;
            adres.Telefon2 = model.Telefon2;
            adres.Tarih = DateTime.Now;
            adres.AktifMi = true;

            if (model.AdresId == 0)
            {
                repository.Create<Adres>(adres);
            }

            await SaveChanges();

            return true;
        }

        public async Task<bool> KullaniciSepetAdresSil(SepetAdresVM model)
        {
            var adres = readOnlyRepository.GetQueryable<Adres>(p => p.AktifMi &&
                                                                    p.KullaniciId == model.KullaniciId &&
                                                                    p.AdresId == model.AdresId).FirstOrDefault();

            if (adres != null)
            {
                adres.AktifMi = false;
                await SaveChanges();
            }

            return true;
        }

        public async Task<AdresIcerikVM> KullaniciAdreslerGetir(AdresVM model)
        {
            AdresIcerikVM result = new AdresIcerikVM()
            {
                KullaniciId = model.KullaniciId,
            };

            var kullaniciAdreslerQuery = readOnlyRepository.GetQueryable<Adres>(p => p.AktifMi &&
                                                                                     p.KullaniciId == model.KullaniciId).AsNoTracking().Include("AdresIl");

            KullaniciAdresVM kullaniciAdresVM = new KullaniciAdresVM() { KullaniciId = model.KullaniciId };
            result.Adresler = await KullaniciSepetAdresleriGetir(kullaniciAdresVM);

            return result;
        }

        public async Task<OdemeIcerikVM> KullaniciOdemeGetir(OdemeVM model)
        {
            OdemeIcerikVM result = new OdemeIcerikVM()
            {
                KullaniciId = model.KullaniciId,
                //SepetIcerik
                //Adresler
                //CaymaHakkiIcerik
                //MesafeliSatisSozlesmesiIcerik
                //OnBilgilendirmeFormuIcerik
            };

            var sepetIcerikQuery = readOnlyRepository.GetQueryable<Sepet>(p => p.AktifMi &&
                                                                    p.Adet > 0 &&
                                                                    p.KullaniciId == model.KullaniciId).AsNoTracking().Include("Urun.UrunResim");

            result.SepetIcerik = new SepetIcerikVM()
            {
                //KullaniciId = model.KullaniciId,
                SepetUrunList = await sepetIcerikQuery.Select(p => new SepetUrunVM()
                {
                    Resim = p.Urun.UrunResim.Any() ? (p.Urun.UrunResim.FirstOrDefault().Resim == null ? (fileServerIsActive ? (p.Urun.UrunResim.FirstOrDefault().ResimUrl.Replace(@"\", "/")) : (p.Urun.UrunResim.FirstOrDefault().OrjinalResimUrl)) : string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Urun.UrunResim.FirstOrDefault().Resim))) : "/Uploads/Site/blog_empty_image_500_500.png",
                    UrunId = p.UrunId,
                    MarkaId = p.Urun.MarkaId,
                    UrunAdi = p.Urun.UrunAdi,
                    MarkaAdi = p.Urun.Marka.MarkaAdi,
                    Adet = p.Adet,
                    UrunBirimFiyat = p.Urun.Fiyat,
                    UrunToplamFiyat = p.Adet * p.Urun.Fiyat,
                }).ToListAsync(),
            };

            result.SepetIcerik.KdvDahilTutar = result.SepetIcerik.SepetUrunList.Sum(p => p.UrunToplamFiyat);
            result.SepetIcerik.KdvTutar = result.SepetIcerik.KdvDahilTutar * 0.18m;
            result.SepetIcerik.KdvHaricTutar = result.SepetIcerik.KdvDahilTutar - result.SepetIcerik.KdvTutar;
            result.SepetIcerik.GonderimTutar = 0;
            result.SepetIcerik.OdemeYontemiTutar = 0;
            result.SepetIcerik.IndirimTutar = 0;
            result.SepetIcerik.OdenecekTutar = result.SepetIcerik.KdvDahilTutar + result.SepetIcerik.GonderimTutar + result.SepetIcerik.OdemeYontemiTutar + result.SepetIcerik.IndirimTutar;

            var kullaniciAdreslerQuery = readOnlyRepository.GetQueryable<Adres>(p => p.AktifMi &&
                                                                                     p.KullaniciId == model.KullaniciId).AsNoTracking().Include("AdresIl");

            KullaniciAdresVM kullaniciAdresVM = new KullaniciAdresVM() { KullaniciId = model.KullaniciId };
            result.Adresler = await KullaniciSepetAdresleriGetir(kullaniciAdresVM);

            var ayarlarQuery = await readOnlyRepository.GetQueryable<Ayarlar>().AsNoTracking().SingleOrDefaultAsync();

            result.OnBilgilendirmeFormuIcerik = ayarlarQuery.OnBilgilendirmeFormu;
            result.MesafeliSatisSozlesmesiIcerik = ayarlarQuery.MesafeliSatisSozlesmesi;

            return result;
        }

        public async Task<int> KullaniciOdemeYap(OdemeIcerikVM model)
        {
            int result = 0;

            //önyüzden toplam rakam la karşılaştır kontrol amaçlı

            //2 - gönderilenle sepetteki ürünler aynı mı kontrol et

            //adres kendisine mi ait onu da kontrol et

            try
            {
                Siparis siparis = new Siparis()
                {
                    KullaniciId = model.KullaniciId,
                    FaturaAdresId = model.FaturaAdresId,
                    GonderimAdresId = model.GonderimAdresId == 0 ? model.FaturaAdresId : model.GonderimAdresId,
                    SiparisOdemeTipId = model.SiparisOdemeTipId,
                    // Kredi kartı seçildiyse onaylandı(3dsiz), diğer durumlarda ödeme durumu beklemede,
                    SiparisDurumTipId = model.SiparisOdemeTipId == 1 ? 3 : 1,
                    OdemeDurumTipId = 1,
                    KrediKartiAdSoyad = model.SiparisOdemeTipId == 1 ? model.KrediKartiAdSoyad : null,
                    // maskeli numaraya bir işlem yapılmadı buraya bakılacak.
                    KrediKartiMaskeliNumara = model.SiparisOdemeTipId == 1 ? KrediKartiMaskele(model.KrediKartiNo) : null,
                    KrediKartiTaksit = model.SiparisOdemeTipId == 1 ? (int?)1 : null,
                    KrediKartiTransferId = null,
                    UrunKdvDahilToplamTutar = model.SepetIcerik.KdvDahilTutar,
                    UrunKdvHaricToplamTutar = model.SepetIcerik.KdvHaricTutar,
                    UrunKdvToplamTutar = model.SepetIcerik.KdvTutar,
                    //OdemeTipUcreti = model.OdemeTipUcreti,
                    //GonderimUcreti = model.GonderimUcreti,
                    OdenecekTutar = model.SepetIcerik.OdenecekTutar,
                    IadeToplam = 0,
                    Aciklama = "",
                    KullaniciIp = model.KullaniciIp,
                    SiparisTarihi = DateTime.Now,
                    SonIslemTarihi = DateTime.Now,
                    OdemeTarihi = model.SiparisOdemeTipId == 1 ? (DateTime?)DateTime.Now : null,
                    // 3d sanal pos ise sipariş pasif olacak
                    AktifMi = true,

                    //SiparisDetay = new List<SiparisDetay>()
                };

                //sipariş kalemleri eklenecek               
                //sipariş detaya hangi kullanıcıya alındığı bilgisi de girilecek. Veritabanından alan eklenecek
                //bu siparişe bağlı sipariş detayları yani ürünler girilecek.
                foreach (var sepetUrun in model.SepetIcerik.SepetUrunList)
                {
                    //FiyatDataObj fiyatDataObj = PriceCalculationHelper.PriceDetail(sepettekiUrun.Urun.Fiyat, sepettekiUrun.Urun.Vergi.VergiOrani);                  
                    var siparisDetay = new SiparisDetay
                    {
                        Siparis = siparis,
                        UrunId = sepetUrun.UrunId,
                        //sipariş detaya hangi kullanıcıya alındığı bilgisi de girilecek. Veritabanından alan eklenecek
                        //KullaniciId = sepetUrun.KullaniciId,
                        Adet = sepetUrun.Adet,

                        UrunBirimKdvDahilTutar = sepetUrun.UrunBirimFiyat,
                        UrunBirimKdvTutar = sepetUrun.UrunBirimFiyat * 0.18m,
                        UrunBirimKdvHaricTutar = sepetUrun.UrunBirimFiyat - (sepetUrun.UrunBirimFiyat * 0.18m),

                        HesaplananBirimKdvDahilTutar = sepetUrun.UrunBirimFiyat,
                        HesaplananBirimKdvTutar = sepetUrun.UrunBirimFiyat * 0.18m,
                        HesaplananBirimKdvHaricTutar = sepetUrun.UrunBirimFiyat - (sepetUrun.UrunBirimFiyat * 0.18m),


                        HesaplananKdvDahilTutar = sepetUrun.Adet * sepetUrun.UrunBirimFiyat,
                        HesaplananKdvTutar = sepetUrun.Adet * (sepetUrun.UrunBirimFiyat * 0.18m),
                        HesaplananKdvHaricTutar = sepetUrun.Adet * (sepetUrun.UrunBirimFiyat - (sepetUrun.UrunBirimFiyat * 0.18m)),

                        AktifMi = true
                    };

                    siparis.SiparisDetay.Add(siparisDetay);
                }

                repository.Create<Siparis>(siparis);

                /*sipariş bittikten sonra siparişin içinde bulunan ürünleri pasif et
                var sepettekiUrunler = readOnlyRepository.GetQueryable<Sepet>(p => p.AktifMi &&
                                                                                   p.KullaniciId == model.KullaniciId);

                //TODO
                foreach (var sepettekiUrun in sepettekiUrunler)
                {
                    sepettekiUrun.GuncellemeTarihi = DateTime.Now;
                    sepettekiUrun.AktifMi = false;
                    repository.Update<Sepet>(sepettekiUrun);
                }*/

                await SaveChanges();

                result = siparis.SiparisId;

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "KullaniciOdemeYap"));
            }

            return result;
        }

        public async Task<OdemeSonucVM> KullaniciOdemeSonucGetir(OdemeVM model)
        {
            var result = new OdemeSonucVM();

            try
            {
                var siparis = await readOnlyRepository.GetQueryable<Siparis>(p => p.KullaniciId == model.KullaniciId && p.SiparisId == model.SiparisId).Include("Kullanici").SingleOrDefaultAsync();

                if (siparis != null)
                {
                    //if (dddSanalPosIslemiMi)
                    //{
                    //  result.SiparisBasariliMi = false;
                    //  TempData["SiparisSonuc"] = siparisSonuc;
                    //  return Json(new { success = "true", location = "/Sepet/DDDPost" }, JsonRequestBehavior.DenyGet);
                    //}
                    //else
                    //{
                    //  result.SiparisBasariliMi = true;
                    //  siparisSonuc.KrediKartiBilgi = null;
                    //  TempData["SiparisSonuc"] = siparisSonuc;
                    //  return Json(new { success = "true", location = "/Sepet/OdemeSonuc" }, JsonRequestBehavior.DenyGet);
                    //}
                    //pos işlemi evreye girdiğinde değişebilir.

                    var sepetIcerikQuery = readOnlyRepository.GetQueryable<SiparisDetay>(p => p.AktifMi &&
                                                                                              p.SiparisId == siparis.SiparisId).AsNoTracking().Include("Urun.UrunResim");

                    result.KullaniciId = siparis.KullaniciId;
                    result.KullaniciAdi = siparis.Kullanici.KullaniciAdi;
                    result.Ad = siparis.Kullanici.Adi;
                    result.Soyad = siparis.Kullanici.Soyadi;
                    result.Eposta = siparis.Kullanici.Eposta;

                    result.SepetIcerik = new SepetIcerikVM()
                    {
                        //KullaniciId = model.KullaniciId,
                        SepetUrunList = await sepetIcerikQuery.Select(p => new SepetUrunVM()
                        {
                            Resim = p.Urun.UrunResim.Any() ? (p.Urun.UrunResim.FirstOrDefault().Resim == null ? (fileServerIsActive ? (p.Urun.UrunResim.FirstOrDefault().ResimUrl.Replace(@"\", "/")) : (p.Urun.UrunResim.FirstOrDefault().OrjinalResimUrl)) : string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Urun.UrunResim.FirstOrDefault().Resim))) : "/Uploads/Site/blog_empty_image_500_500.png",
                            UrunId = p.UrunId,
                            MarkaId = p.Urun.MarkaId,
                            UrunAdi = p.Urun.UrunAdi,
                            MarkaAdi = p.Urun.Marka.MarkaAdi,
                            Adet = p.Adet,
                            UrunBirimFiyat = p.Urun.Fiyat,
                            UrunToplamFiyat = p.Adet * p.Urun.Fiyat,
                        }).ToListAsync(),
                    };

                    result.SepetIcerik.KdvDahilTutar = result.SepetIcerik.SepetUrunList.Sum(p => p.UrunToplamFiyat);
                    result.SepetIcerik.KdvTutar = result.SepetIcerik.KdvDahilTutar * 0.18m;
                    result.SepetIcerik.KdvHaricTutar = result.SepetIcerik.KdvDahilTutar - result.SepetIcerik.KdvTutar;
                    result.SepetIcerik.GonderimTutar = 0;
                    result.SepetIcerik.OdemeYontemiTutar = 0;
                    result.SepetIcerik.IndirimTutar = 0;
                    result.SepetIcerik.OdenecekTutar = result.SepetIcerik.KdvDahilTutar + result.SepetIcerik.GonderimTutar + result.SepetIcerik.OdemeYontemiTutar + result.SepetIcerik.IndirimTutar;

                    result.SiparisBasariliMi = siparis.AktifMi;
                    result.SiparisId = siparis.SiparisId;
                    result.KullaniciId = siparis.KullaniciId;
                    result.TransferId = null;
                    result.GonderimAdres = await KullaniciSepetAdresGetir(new SepetAdresVM() { KullaniciId = siparis.KullaniciId, AdresId = siparis.GonderimAdresId });
                    result.FaturaAdres = await KullaniciSepetAdresGetir(new SepetAdresVM() { KullaniciId = siparis.KullaniciId, AdresId = siparis.FaturaAdresId });
                    result.SiparisTarihi = siparis.SiparisTarihi;
                    result.OdemeTipi = readOnlyRepository.GetQueryable<SiparisOdemeTip>().SingleOrDefault(p => p.SiparisOdemeTipId == siparis.SiparisOdemeTipId)?.Adi;

                    result.ToplamIskonto = 0;
                    result.ToplamKomisyon = 0;
                    result.OdemeTipUcreti = siparis.OdemeTipUcreti;
                    result.GonderimUcreti = siparis.GonderimUcreti;
                    result.OdenecekTutar = siparis.OdenecekTutar;


                    //sepetteki ürünleri pasife çekme
                    var sepettekiUrunler = readOnlyRepository.GetQueryable<Sepet>(p => p.AktifMi &&
                                                                                   p.KullaniciId == model.KullaniciId);

                    //TODO
                    foreach (var sepettekiUrun in sepettekiUrunler)
                    {
                        sepettekiUrun.GuncellemeTarihi = DateTime.Now;
                        sepettekiUrun.AktifMi = false;
                        repository.Update<Sepet>(sepettekiUrun);
                    }
                    await SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "KullaniciOdemeSonucGetir"));
            }

            return result;
        }

        public async Task<List<AdresIlceVM>> SepetAdresIlceGetir(int id)
        {
            return await readOnlyRepository.GetQueryable<AdresIlce>(p => p.AdresIlId == id)
                                           .AsNoTracking()
                                           .Select(p => new AdresIlceVM
                                           {
                                               AdresIlId = p.AdresIlId,
                                               AdresIlceId = p.AdresIlceId,
                                               IlceAdi = p.IlceAdi,
                                               AktifMi = p.AktifMi
                                           }).ToListAsync();
        }

        public async Task<bool> KullaniciOdemeSil(int id)
        {
            try
            {
                var siparisDetay = await readOnlyRepository.GetQueryable<SiparisDetay>(p => p.SiparisId == id).ToListAsync();

                foreach (var item in siparisDetay)
                {
                    repository.Delete(item);
                }

                var siparis = await readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == id).FirstOrDefaultAsync();
                repository.Delete(siparis);

                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "KullaniciOdemeSil"));
                return false;
            }
        }

        public string KrediKartiMaskele(string krediKartiNo)
        {
            string result = "";

            if (krediKartiNo.Length > 4)
            {
                // Girilen numaranın 4 eksiği kadar # işareti ekle
                for (int i = 0; i < krediKartiNo.Length - 4; i++)
                {
                    result += "#";
                }

                // Girilen numaranın son dört hanesini sonuç katarına ekle
                result += krediKartiNo.Substring(krediKartiNo.Length - 4);
            }

            return result;
        }

        #endregion

        #endregion

        #region Sipariş

        #region Admin

        public async Task<List<AdresIlVM>> SatisAdresIlGetir()
        {
            return await readOnlyRepository.GetQueryable<AdresIl>()
                                           .AsNoTracking()
                                           .Select(p => new AdresIlVM
                                           {
                                               AdresIlId = p.AdresIlId,
                                               IlAdi = p.IlAdi,
                                               AktifMi = p.AktifMi
                                           }).ToListAsync();
        }

        public async Task<List<OdemeDurumTipVM>> OdemeDurumTipListesiGetir()
        {
            return await readOnlyRepository.GetQueryable<OdemeDurumTip>()
                                           .AsNoTracking()
                                           .Select(p => new OdemeDurumTipVM
                                           {
                                               OdemeDurumTipId = p.OdemeDurumTipId,
                                               Adi = p.Adi,
                                               Sira = p.Sira,
                                               AktifMi = p.AktifMi
                                           }).ToListAsync();
        }

        public async Task<List<SiparisDurumTipVM>> SiparisDurumTipListesiGetir()
        {
            return await readOnlyRepository.GetQueryable<SiparisDurumTip>()
                                           .AsNoTracking()
                                           .Select(p => new SiparisDurumTipVM
                                           {
                                               SiparisDurumTipId = p.SiparisDurumTipId,
                                               Adi = p.Adi,
                                               Sira = p.Sira,
                                               AktifMi = p.AktifMi
                                           }).ToListAsync();
        }

        public async Task<List<SiparisOdemeTipVM>> SiparisOdemeTipListesiGetir()
        {
            return await readOnlyRepository.GetQueryable<SiparisOdemeTip>()
                                           .AsNoTracking()
                                           .Select(p => new SiparisOdemeTipVM
                                           {
                                               SiparisOdemeTipId = p.SiparisOdemeTipId,
                                               Adi = p.Adi,
                                               Sira = p.Sira,
                                               AktifMi = p.AktifMi
                                           }).ToListAsync();
        }

        public async Task<List<SiparisAramaSonucVM>> SiparisAramaSonuc(SiparisAramaVM model)
        {
            var query = readOnlyRepository.GetQueryable<Siparis>().AsNoTracking();

            if (model.MarkaId != 0 && model.UrunId != 0)
            {
                var urun = readOnlyRepository.GetQueryable<Urun>(p => p.UrunId == model.UrunId).AsNoTracking().FirstOrDefault();
                if (urun.MarkaId != model.MarkaId)
                {
                    List<SiparisAramaSonucVM> sonuc = new List<SiparisAramaSonucVM>();
                    return sonuc;
                }
            }

            if (model.MarkaId != 0)
            {
                var markaUrunleri = readOnlyRepository.GetQueryable<Urun>(p => p.MarkaId == model.MarkaId).AsNoTracking().ToList();
                foreach (var urun in markaUrunleri)
                {
                    var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                    var siparisUrun = readOnlyRepository.GetQueryable<SiparisDetay>(p => p.UrunId == urun.UrunId).Select(p => p.SiparisId).ToList();
                    foreach (var id in siparisUrun)
                    {
                        query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == id).AsNoTracking());
                    }
                    query = query2;
                }
            }

            if (model.UrunId != 0)
            {
                var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                var siparisDetay = readOnlyRepository.GetQueryable<SiparisDetay>(p => p.UrunId == model.UrunId).Select(p => p.SiparisId).ToList();
                foreach (var id in siparisDetay)
                {
                    query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == id).AsNoTracking());
                }
                query = query2;
            }

            if (model.SiparisId != 0)
            {
                query = query.Where(p => p.SiparisId == model.SiparisId);
            }

            if (model.SiparisDurumTipId != 0)
            {
                query = query.Where(p => p.SiparisDurumTipId == model.SiparisDurumTipId);
            }

            if (model.SiparisOdemeTipId != 0)
            {
                query = query.Where(p => p.SiparisOdemeTipId == model.SiparisOdemeTipId);
            }

            if (model.OdemeDurumTipId != 0)
            {
                query = query.Where(p => p.OdemeDurumTipId == model.OdemeDurumTipId);
            }

            if (model.Aciklama != null)
            {
                query = query.Where(p => p.Aciklama.Contains(model.Aciklama.Trim()));
            }

            if (model.FaturaAdresIlId != 0)
            {
                var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                var adresIds = readOnlyRepository.GetQueryable<Adres>(p => p.AdresIlId == model.FaturaAdresIlId).Select(p => p.AdresId).ToList();
                foreach (var id in adresIds)
                {
                    query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.FaturaAdresId == id).AsNoTracking());
                }
                query = query2;
            }

            if (model.GonderimAdresIlId != 0)
            {
                var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                var adresIds = readOnlyRepository.GetQueryable<Adres>(p => p.AdresIlId == model.GonderimAdresIlId).Select(p => p.AdresId).ToList();
                foreach (var id in adresIds)
                {
                    query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.GonderimAdresId == id).AsNoTracking());
                }
                query = query2;
            }

            if (model.FaturaAdi != null && model.FaturaSoyadi != null)
            {
                var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                var adresIds = readOnlyRepository.GetQueryable<Adres>(p => p.Ad == model.FaturaAdi && p.Soyad == model.FaturaSoyadi).Select(p => p.AdresId).ToList();
                foreach (var id in adresIds)
                {
                    query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.FaturaAdresId == id).AsNoTracking());
                }
                query = query2;
            }
            else if (model.FaturaAdi != null && model.FaturaSoyadi == null)
            {
                var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                var adresIds = readOnlyRepository.GetQueryable<Adres>(p => p.Ad == model.FaturaAdi).Select(p => p.AdresId).ToList();
                foreach (var id in adresIds)
                {
                    query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.FaturaAdresId == id).AsNoTracking());
                }
                query = query2;
            }
            else if (model.FaturaAdi == null && model.FaturaSoyadi != null)
            {
                var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                var adresIds = readOnlyRepository.GetQueryable<Adres>(p => p.Soyad == model.FaturaSoyadi).Select(p => p.AdresId).ToList();
                foreach (var id in adresIds)
                {
                    query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.FaturaAdresId == id).AsNoTracking());
                }
                query = query2;
            }

            if (model.GonderimAdi != null && model.GonderimSoyadi != null)
            {
                var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                var adresIds = readOnlyRepository.GetQueryable<Adres>(p => p.Ad == model.GonderimAdi && p.Soyad == model.GonderimSoyadi).Select(p => p.AdresId).ToList();
                foreach (var id in adresIds)
                {
                    query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.GonderimAdresId == id).AsNoTracking());
                }
                query = query2;
            }
            else if (model.GonderimAdi != null && model.GonderimSoyadi == null)
            {
                var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                var adresIds = readOnlyRepository.GetQueryable<Adres>(p => p.Ad == model.GonderimAdi).Select(p => p.AdresId).ToList();
                foreach (var id in adresIds)
                {
                    query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.GonderimAdresId == id).AsNoTracking());
                }
                query = query2;
            }
            else if (model.GonderimAdi == null && model.GonderimSoyadi != null)
            {
                var query2 = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == -1).AsNoTracking();
                var adresIds = readOnlyRepository.GetQueryable<Adres>(p => p.Soyad == model.GonderimSoyadi).Select(p => p.AdresId).ToList();
                foreach (var id in adresIds)
                {
                    query2 = query2.Concat(readOnlyRepository.GetQueryable<Siparis>(p => p.GonderimAdresId == id).AsNoTracking());
                }
                query = query2;
            }

            if (model.BaslangicTarihi != null)
            {
                query = query.Where(x => (x.SiparisTarihi.Date >= Convert.ToDateTime(model.BaslangicTarihi)));
            }

            if (model.BitisTarihi != null)
            {
                query = query.Where(x => (x.SonIslemTarihi.Date <= Convert.ToDateTime(model.BitisTarihi)));
            }

            if (model.AktifMi != -1)
            {
                query = query.Where(p => p.AktifMi == Convert.ToBoolean(model.AktifMi));
            }

            var kullanicilar = readOnlyRepository.GetQueryable<Kullanici>().AsNoTracking();
            var total = query.Count();

            var result = query.Select(p => new SiparisAramaSonucVM
            {
                TotalCount = total,
                SiparisId = p.SiparisId,
                SiparisDurumTipId = p.SiparisDurumTipId,
                OdemeDurumTipId = p.OdemeDurumTipId,
                SiparisOdemeTipId = p.SiparisOdemeTipId,
                MusteriBilgileri = kullanicilar.FirstOrDefault(x => x.KullaniciId == p.KullaniciId).Adi + " " + kullanicilar.FirstOrDefault(x => x.KullaniciId == p.KullaniciId).Soyadi + " (" + kullanicilar.FirstOrDefault(x => x.KullaniciId == p.KullaniciId).Eposta + ")",
                SiparisTarihi = p.SiparisTarihi.ToString("dd.MM.yyyy HH:mm"),
                SonIslemTarihi = p.SonIslemTarihi.ToString("dd.MM.yyyy HH:mm"),
                AktifMi = p.AktifMi
            }).OrderByDescending(p => p.SiparisId).Skip(model.start).Take(model.length).ToListAsync();
            return await result;
        }

        public async Task<int> SiparisSil(int id)
        {
            Siparis siparis = readOnlyRepository.GetQueryable<Siparis>(w => w.SiparisId == id).FirstOrDefault();
            siparis.AktifMi = false;
            repository.Update(siparis);
            return await SaveChanges();
        }

        public async Task<SiparisAramaDetayVM> SiparisDetay(int id)
        {
            try
            {
                SiparisAramaDetayVM detay = new SiparisAramaDetayVM();
                var siparis = readOnlyRepository.GetQueryable<Siparis>(w => w.SiparisId == id).AsNoTracking().FirstOrDefault();
                var siparisDetay = readOnlyRepository.GetQueryable<SiparisDetay>(w => w.SiparisId == id).AsNoTracking().ToList();
                var FaturaAdres = readOnlyRepository.GetQueryable<Adres>(w => w.AdresId == siparis.FaturaAdresId).AsNoTracking().FirstOrDefault();
                var GonderimAdres = readOnlyRepository.GetQueryable<Adres>(w => w.AdresId == siparis.GonderimAdresId).AsNoTracking().FirstOrDefault();
                var siparisHareket = readOnlyRepository.GetQueryable<SiparisHareket>(w => w.SiparisId == id).AsNoTracking().ToList();

                detay.Siparis = mapper.Map<Siparis, SiparisGetirVM>(siparis);
                detay.Siparis.SiparisDurumTipListesi = await SiparisDurumTipListesiGetir();
                detay.Siparis.SiparisOdemeTipListesi = await SiparisOdemeTipListesiGetir();
                detay.Siparis.OdemeDurumTipListesi = await OdemeDurumTipListesiGetir();
                detay.Siparis.SiparisTarihi = siparis.SiparisTarihi.ToString("dd.MM.yyyy HH:mm");
                detay.Siparis.SonIslemTarihi = siparis.SonIslemTarihi.ToString("dd.MM.yyyy HH:mm");
                detay.Siparis.OdemeTarihi = Convert.ToDateTime(siparis.OdemeTarihi).ToString("dd.MM.yyyy HH:mm");
                detay.Siparis.KullaniciBilgileri = readOnlyRepository.GetQueryable<Kullanici>(w => w.KullaniciId == siparis.KullaniciId).FirstOrDefault().Adi + " " + readOnlyRepository.GetQueryable<Kullanici>(w => w.KullaniciId == siparis.KullaniciId).FirstOrDefault().Soyadi + " (" + readOnlyRepository.GetQueryable<Kullanici>(w => w.KullaniciId == siparis.KullaniciId).FirstOrDefault().KullaniciAdi + ")";

                var urunler = readOnlyRepository.GetQueryable<Urun>(p => p.UrunId == -2).AsNoTracking();
                var urunResim = readOnlyRepository.GetQueryable<UrunResim>(p => p.UrunId == -2).AsNoTracking();
                foreach (var item in siparisDetay)
                {
                    urunler = urunler.Concat(readOnlyRepository.GetQueryable<Urun>(p => p.UrunId == item.UrunId).AsNoTracking());
                    urunResim = urunResim.Concat(readOnlyRepository.GetQueryable<UrunResim>(p => p.UrunId == item.UrunId && p.AktifMi).AsNoTracking());
                }

                detay.SiparisDetay = siparisDetay.Select(p => new SiparisDetayVM
                {
                    SiparisDetayId = p.SiparisDetayId,
                    SiparisId = p.SiparisId,
                    UrunId = p.UrunId,
                    Adet = p.Adet,
                    UrunBirimKdvDahilTutar = p.UrunBirimKdvDahilTutar,
                    UrunBirimKdvHaricTutar = p.UrunBirimKdvHaricTutar,
                    UrunBirimKdvTutar = p.UrunBirimKdvTutar,
                    HesaplananBirimKdvDahilTutar = p.HesaplananBirimKdvDahilTutar,
                    HesaplananBirimKdvHaricTutar = p.HesaplananBirimKdvHaricTutar,
                    HesaplananBirimKdvTutar = p.HesaplananBirimKdvTutar,
                    HesaplananKdvDahilTutar = p.HesaplananKdvDahilTutar,
                    HesaplananKdvHaricTutar = p.HesaplananKdvHaricTutar,
                    HesaplananKdvTutar = p.HesaplananKdvTutar,
                    UrunAdi = urunler.FirstOrDefault(a => a.UrunId == p.UrunId).UrunAdi,
                    ResimBase64 = urunResim.FirstOrDefault(a => a.UrunId == p.UrunId).Resim != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(urunResim.FirstOrDefault(a => a.UrunId == p.UrunId).Resim)) : "/Uploads/Site/blog_empty_image_500_500.png",
                    AktifMi = p.AktifMi
                }).ToList();

                detay.FaturaAdresi = mapper.Map<Adres, SiparisAdresVM>(FaturaAdres);
                detay.GonderimAdresi = mapper.Map<Adres, SiparisAdresVM>(GonderimAdres);
                detay.SiparisHareket = siparisHareket.Select(p => new SiparisHareketVM
                {
                    SiparisHareketId = p.SiparisHareketId,
                    SiparisId = p.SiparisId,
                    Aciklama = p.Aciklama,
                    Tarih = p.Tarih.ToString("dd.MM.yyyy HH:mm"),
                    AktifMi = p.AktifMi
                }).ToList();

                detay.SiparisHareketEkle = new SiparisHareketVM();
                detay.SiparisHareketEkle.AktifMi = true;

                detay.AdresIlListesi = readOnlyRepository.GetQueryable<AdresIl>()
                                           .AsNoTracking()
                                           .Select(p => new AdresIlVM
                                           {
                                               AdresIlId = p.AdresIlId,
                                               IlAdi = p.IlAdi,
                                               AktifMi = p.AktifMi
                                           }).ToList();

                detay.AdresIlceListesiFatura = readOnlyRepository.GetQueryable<AdresIlce>(p => p.AdresIlId == FaturaAdres.AdresIlId)
                                           .AsNoTracking()
                                           .Select(p => new AdresIlceVM
                                           {
                                               AdresIlId = p.AdresIlId,
                                               AdresIlceId = p.AdresIlceId,
                                               IlceAdi = p.IlceAdi,
                                               AktifMi = p.AktifMi
                                           }).ToList();

                detay.AdresIlceListesiGonderim = readOnlyRepository.GetQueryable<AdresIlce>(p => p.AdresIlId == GonderimAdres.AdresIlId)
                                           .AsNoTracking()
                                           .Select(p => new AdresIlceVM
                                           {
                                               AdresIlId = p.AdresIlId,
                                               AdresIlceId = p.AdresIlceId,
                                               IlceAdi = p.IlceAdi,
                                               AktifMi = p.AktifMi
                                           }).ToList();

                return detay;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "SiparisDetay"));
                SiparisAramaDetayVM detay = new SiparisAramaDetayVM();
                return detay;
            }
        }
        public async Task<bool> SiparisGuncelle(SiparisAramaDetayVM model)
        {
            try
            {
                var siparis = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == model.Siparis.SiparisId).FirstOrDefault();

                siparis.SiparisOdemeTipId = model.Siparis.SiparisOdemeTipId;
                siparis.SiparisDurumTipId = model.Siparis.SiparisDurumTipId;
                siparis.OdemeDurumTipId = model.Siparis.OdemeDurumTipId;

                repository.Update(siparis);
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "SiparisGuncelle"));
                return false;
            }
        }
        public async Task<bool> SiparisHareketKaydet(SiparisAramaDetayVM model)
        {
            try
            {
                SiparisHareket siparisHareket = new SiparisHareket()
                {
                    SiparisId = model.SiparisHareketEkle.SiparisId,
                    Aciklama = model.SiparisHareketEkle.Aciklama,
                    Tarih = Convert.ToDateTime(model.SiparisHareketEkle.Tarih),
                    AktifMi = model.SiparisHareketEkle.AktifMi
                };

                repository.Create(siparisHareket);
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "SiparisHareketKaydet"));
                return false;
            }
        }
        public async Task<bool> SiparisHareketSil(int id)
        {
            try
            {
                var siparisHareket = readOnlyRepository.GetQueryable<SiparisHareket>(p => p.SiparisHareketId == id).FirstOrDefault();
                siparisHareket.AktifMi = false;

                repository.Update(siparisHareket);
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "SiparisHareketSil"));
                return false;
            }
        }
        public async Task<bool> SiparisDetayDurum(int id)
        {
            try
            {
                var siparisHareket = readOnlyRepository.GetQueryable<SiparisDetay>(p => p.SiparisDetayId == id).FirstOrDefault();
                if (siparisHareket.AktifMi)
                {
                    siparisHareket.AktifMi = false;
                }
                else
                {
                    siparisHareket.AktifMi = true;
                }

                repository.Update(siparisHareket);
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "SiparisDetayDurum"));
                return false;
            }
        }
        #endregion

        #region FrontEnd

        public async Task<List<SiparisVM>> KullaniciSiparisListesiGetir(KullaniciSiparisVM model)
        {
            List<SiparisVM> result = new List<SiparisVM>();

            try
            {
                var siparisList = await readOnlyRepository.GetQueryable<Siparis>(p => p.KullaniciId == model.KullaniciId).Include("Kullanici").OrderByDescending(p => p.SiparisId).ToListAsync();

                if (siparisList != null)
                {
                    foreach (var siparis in siparisList)
                    {
                        var sepetIcerikQuery = readOnlyRepository.GetQueryable<SiparisDetay>(p => p.AktifMi &&
                                                                                                  p.SiparisId == siparis.SiparisId).AsNoTracking().Include("Urun.UrunResim");

                        SiparisVM siparisResult = new SiparisVM() { SepetIcerik = new SepetIcerikVM() };

                        siparisResult.KullaniciId = siparis.KullaniciId;
                        siparisResult.KullaniciAdi = siparis.Kullanici.KullaniciAdi;
                        siparisResult.Ad = siparis.Kullanici.Adi;
                        siparisResult.Soyad = siparis.Kullanici.Soyadi;
                        siparisResult.Eposta = siparis.Kullanici.Eposta;

                        siparisResult.SepetIcerik = new SepetIcerikVM()
                        {
                            //KullaniciId = model.KullaniciId,
                            SepetUrunList = await sepetIcerikQuery.Select(p => new SepetUrunVM()
                            {
                                Resim = p.Urun.UrunResim.Any() ? (p.Urun.UrunResim.FirstOrDefault().Resim == null ? (fileServerIsActive ? (p.Urun.UrunResim.FirstOrDefault().ResimUrl.Replace(@"\", "/")) : (p.Urun.UrunResim.FirstOrDefault().OrjinalResimUrl)) : string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Urun.UrunResim.FirstOrDefault().Resim))) : "/Uploads/Site/blog_empty_image_500_500.png",
                                UrunId = p.UrunId,
                                MarkaId = p.Urun.MarkaId,
                                UrunAdi = p.Urun.UrunAdi,
                                MarkaAdi = p.Urun.Marka.MarkaAdi,
                                Adet = p.Adet,
                                UrunBirimFiyat = p.Urun.Fiyat,
                                UrunToplamFiyat = p.Adet * p.Urun.Fiyat,
                            }).ToListAsync(),
                        };

                        siparisResult.SepetIcerik.KdvDahilTutar = siparisResult.SepetIcerik.SepetUrunList.Sum(p => p.UrunToplamFiyat);
                        siparisResult.SepetIcerik.KdvTutar = siparisResult.SepetIcerik.KdvDahilTutar * 0.18m;
                        siparisResult.SepetIcerik.KdvHaricTutar = siparisResult.SepetIcerik.KdvDahilTutar - siparisResult.SepetIcerik.KdvTutar;
                        siparisResult.SepetIcerik.GonderimTutar = 20m;
                        siparisResult.SepetIcerik.OdemeYontemiTutar = 0;
                        siparisResult.SepetIcerik.IndirimTutar = -20m;
                        siparisResult.SepetIcerik.OdenecekTutar = siparisResult.SepetIcerik.KdvDahilTutar + siparisResult.SepetIcerik.GonderimTutar + siparisResult.SepetIcerik.OdemeYontemiTutar + siparisResult.SepetIcerik.IndirimTutar;

                        siparisResult.SiparisBasariliMi = siparis.AktifMi;
                        siparisResult.SiparisId = siparis.SiparisId;
                        siparisResult.KullaniciId = siparis.KullaniciId;
                        siparisResult.TransferId = null;
                        siparisResult.GonderimAdres = await KullaniciSepetAdresGetir(new SepetAdresVM() { KullaniciId = siparis.KullaniciId, AdresId = siparis.GonderimAdresId });
                        siparisResult.FaturaAdres = await KullaniciSepetAdresGetir(new SepetAdresVM() { KullaniciId = siparis.KullaniciId, AdresId = siparis.FaturaAdresId });
                        siparisResult.SiparisTarihi = siparis.SiparisTarihi;
                        siparisResult.OdemeTipi = readOnlyRepository.GetQueryable<SiparisOdemeTip>().SingleOrDefault(p => p.SiparisOdemeTipId == siparis.SiparisOdemeTipId)?.Adi;

                        siparisResult.ToplamIskonto = -20m;
                        siparisResult.ToplamKomisyon = 0;
                        siparisResult.OdemeTipUcreti = siparis.OdemeTipUcreti;
                        siparisResult.GonderimUcreti = siparis.GonderimUcreti;
                        siparisResult.OdenecekTutar = siparis.OdenecekTutar;

                        result.Add(siparisResult);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "KullaniciSiparisListesiGetir"));
            }

            return result;
        }

        public async Task<SiparisVM> KullaniciSiparisDetayGetir(KullaniciSiparisVM model)
        {
            SiparisVM result = new SiparisVM();

            try
            {
                var siparis = await readOnlyRepository.GetQueryable<Siparis>(p => p.KullaniciId == model.KullaniciId && p.SiparisId == model.SiparisId).Include("Kullanici").SingleOrDefaultAsync();

                if (siparis != null)
                {
                    var sepetIcerikQuery = readOnlyRepository.GetQueryable<SiparisDetay>(p => p.AktifMi &&
                                                                                              p.SiparisId == siparis.SiparisId).AsNoTracking().Include("Urun.UrunResim");

                    result.KullaniciId = siparis.KullaniciId;
                    result.KullaniciAdi = siparis.Kullanici.KullaniciAdi;
                    result.Ad = siparis.Kullanici.Adi;
                    result.Soyad = siparis.Kullanici.Soyadi;
                    result.Eposta = siparis.Kullanici.Eposta;
                    result.Telefon = siparis.Kullanici.Telefon;

                    result.SepetIcerik = new SepetIcerikVM()
                    {
                        //KullaniciId = model.KullaniciId,
                        SepetUrunList = await sepetIcerikQuery.Select(p => new SepetUrunVM()
                        {
                            Resim = p.Urun.UrunResim.Any() ? (p.Urun.UrunResim.FirstOrDefault().Resim == null ? (fileServerIsActive ? (p.Urun.UrunResim.FirstOrDefault().ResimUrl.Replace(@"\", "/")) : (p.Urun.UrunResim.FirstOrDefault().OrjinalResimUrl)) : string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(p.Urun.UrunResim.FirstOrDefault().Resim))) : "/Uploads/Site/blog_empty_image_500_500.png",
                            UrunId = p.UrunId,
                            MarkaId = p.Urun.MarkaId,
                            UrunAdi = p.Urun.UrunAdi,
                            MarkaAdi = p.Urun.Marka.MarkaAdi,
                            Adet = p.Adet,
                            UrunBirimFiyat = p.Urun.Fiyat,
                            UrunToplamFiyat = p.Adet * p.Urun.Fiyat,
                        }).ToListAsync(),
                    };

                    result.SepetIcerik.KdvDahilTutar = result.SepetIcerik.SepetUrunList.Sum(p => p.UrunToplamFiyat);
                    result.SepetIcerik.KdvTutar = result.SepetIcerik.KdvDahilTutar * 0.18m;
                    result.SepetIcerik.KdvHaricTutar = result.SepetIcerik.KdvDahilTutar - result.SepetIcerik.KdvTutar;
                    result.SepetIcerik.GonderimTutar = 20m;
                    result.SepetIcerik.OdemeYontemiTutar = 0;
                    result.SepetIcerik.IndirimTutar = -20m;
                    result.SepetIcerik.OdenecekTutar = result.SepetIcerik.KdvDahilTutar + result.SepetIcerik.GonderimTutar + result.SepetIcerik.OdemeYontemiTutar + result.SepetIcerik.IndirimTutar;

                    result.SiparisBasariliMi = siparis.AktifMi;
                    result.SiparisId = siparis.SiparisId;
                    result.KullaniciId = siparis.KullaniciId;
                    result.TransferId = null;
                    result.GonderimAdres = await KullaniciSepetAdresGetir(new SepetAdresVM() { KullaniciId = siparis.KullaniciId, AdresId = siparis.GonderimAdresId });
                    result.FaturaAdres = await KullaniciSepetAdresGetir(new SepetAdresVM() { KullaniciId = siparis.KullaniciId, AdresId = siparis.FaturaAdresId });
                    result.SiparisTarihi = siparis.SiparisTarihi;
                    result.OdemeTipi = readOnlyRepository.GetQueryable<SiparisOdemeTip>().SingleOrDefault(p => p.SiparisOdemeTipId == siparis.SiparisOdemeTipId)?.Adi;

                    result.ToplamIskonto = -20m;
                    result.ToplamKomisyon = 0;
                    result.OdemeTipUcreti = siparis.OdemeTipUcreti;
                    result.GonderimUcreti = siparis.GonderimUcreti;
                    result.OdenecekTutar = siparis.OdenecekTutar;
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "KullaniciSiparisDetayGetir"));
            }

            return result;
        }

        public async Task<bool> KullaniciSiparisGuncelle(KullaniciSiparisVM model)
        {
            try
            {
                var siparis = readOnlyRepository.GetQueryable<Siparis>(p => p.SiparisId == model.SiparisId).FirstOrDefault();
                siparis.OdemeDurumTipId = 2;
                siparis.KrediKartiTransferId = model.TransferId;
                siparis.OdemeTarihi = DateTime.Now;

                repository.Update(siparis);
                await SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}", "DataService", "SatisDataService", "KullaniciSiparisGuncelle"));
                return false;
            }
        }

        #endregion

        #endregion
    }
}
