using AutoMapper;
using NeSever.Common.Models.Satis;
using NeSever.Data.DataService.Program;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeServer.Business.Program
{
    public interface ISatisBusiness
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

    public class SatisBusiness : BaseBusiness, ISatisBusiness
    {
        private readonly ISatisDataService satisDataService;
        private readonly IMapper mapper;

        public SatisBusiness(ISatisDataService satisDataService,
                             IMapper mapper)
        {
            this.satisDataService = satisDataService;
            this.mapper = mapper;
        }

        #region Sepet

        #region Admin


        #endregion

        #region FrontEnd

        public async Task<OnBilgilendirmeFormuVM> OnBilgilendirmeFormuGetir()
        {
            return await satisDataService.OnBilgilendirmeFormuGetir();
        }

        public async Task<MesafeliSatisSozlesmesiVM> MesafeliSatisSozlesmesiGetir()
        {
            return await satisDataService.MesafeliSatisSozlesmesiGetir();
        }

        public async Task<SepetIcerikVM> KullaniciSepetGetir(SepetVM model)
        {
            return await satisDataService.KullaniciSepetGetir(model);
        }

        public async Task<bool> KullaniciSepetTemizle(SepetVM model)
        {
            return await satisDataService.KullaniciSepetTemizle(model);
        }

        public async Task<int> KullaniciSepetUrunArttir(SepetVM model)
        {
            return await satisDataService.KullaniciSepetUrunArttir(model);
        }

        public async Task<bool> KullaniciSepetUrunEksilt(SepetVM model)
        {
            return await satisDataService.KullaniciSepetUrunEksilt(model);
        }

        public async Task<bool> KullaniciSepetUrunSil(SepetVM model)
        {
            return await satisDataService.KullaniciSepetUrunSil(model);
        }

        public async Task<List<SepetAdresVM>> KullaniciSepetAdresleriGetir(KullaniciAdresVM model)
        {
            return await satisDataService.KullaniciSepetAdresleriGetir(model);
        }

        public async Task<SepetAdresVM> KullaniciSepetAdresGetir(SepetAdresVM model)
        {
            return await satisDataService.KullaniciSepetAdresGetir(model);
        }

        public async Task<bool> KullaniciSepetAdresKaydetGuncelle(SepetAdresVM model)
        {
            return await satisDataService.KullaniciSepetAdresKaydetGuncelle(model);
        }

        public async Task<bool> KullaniciSepetAdresSil(SepetAdresVM model)
        {
            return await satisDataService.KullaniciSepetAdresSil(model);
        }

        public async Task<AdresIcerikVM> KullaniciAdreslerGetir(AdresVM model)
        {
            return await satisDataService.KullaniciAdreslerGetir(model);
        }

        public async Task<OdemeIcerikVM> KullaniciOdemeGetir(OdemeVM model)
        {
            return await satisDataService.KullaniciOdemeGetir(model);
        }

        public async Task<int> KullaniciOdemeYap(OdemeIcerikVM model)
        {
            return await satisDataService.KullaniciOdemeYap(model);
        }

        public async Task<OdemeSonucVM> KullaniciOdemeSonucGetir(OdemeVM model)
        {
            return await satisDataService.KullaniciOdemeSonucGetir(model);
        }

        public async Task<List<AdresIlceVM>> SepetAdresIlceGetir(int id)
        {
            return await satisDataService.SepetAdresIlceGetir(id);
        }

        public async Task<bool> KullaniciOdemeSil(int id)
        {
            return await satisDataService.KullaniciOdemeSil(id);
        }

        #endregion

        #endregion

        #region Sipariş

        #region Admin

        public async Task<List<AdresIlVM>> SatisAdresIlGetir()
        {
            return await satisDataService.SatisAdresIlGetir();
        }

        public async Task<List<OdemeDurumTipVM>> OdemeDurumTipListesiGetir()
        {
            return await satisDataService.OdemeDurumTipListesiGetir();
        }

        public async Task<List<SiparisDurumTipVM>> SiparisDurumTipListesiGetir()
        {
            return await satisDataService.SiparisDurumTipListesiGetir();
        }

        public async Task<List<SiparisOdemeTipVM>> SiparisOdemeTipListesiGetir()
        {
            return await satisDataService.SiparisOdemeTipListesiGetir();
        }

        public async Task<List<SiparisAramaSonucVM>> SiparisAramaSonuc(SiparisAramaVM model)
        {
            return await satisDataService.SiparisAramaSonuc(model);
        }

        public async Task<int> SiparisSil(int id)
        {
            return await satisDataService.SiparisSil(id);
        }
        public async Task<SiparisAramaDetayVM> SiparisDetay(int id)
        {
            return await satisDataService.SiparisDetay(id);
        }
        public async Task<bool> SiparisGuncelle(SiparisAramaDetayVM model)
        {
            return await satisDataService.SiparisGuncelle(model);
        }
        public async Task<bool> SiparisHareketKaydet(SiparisAramaDetayVM model)
        {
            return await satisDataService.SiparisHareketKaydet(model);
        }
        public async Task<bool> SiparisHareketSil(int id)
        {
            return await satisDataService.SiparisHareketSil(id);
        }
        public async Task<bool> SiparisDetayDurum(int id)
        {
            return await satisDataService.SiparisDetayDurum(id);
        }
        #endregion

        #region FrontEnd

        public async Task<List<SiparisVM>> KullaniciSiparisListesiGetir(KullaniciSiparisVM model)
        {
            return await satisDataService.KullaniciSiparisListesiGetir(model);
        }
        public async Task<SiparisVM> KullaniciSiparisDetayGetir(KullaniciSiparisVM model)
        {
            return await satisDataService.KullaniciSiparisDetayGetir(model);
        }

        public async Task<bool> KullaniciSiparisGuncelle(KullaniciSiparisVM model)
        {
            return await satisDataService.KullaniciSiparisGuncelle(model);
        }

        #endregion

        #endregion
    }
}