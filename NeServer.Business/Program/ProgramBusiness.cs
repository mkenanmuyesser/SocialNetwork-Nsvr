using AutoMapper;
using NeSever.Common.Models.Admin;
using NeSever.Common.Models.Admin.AramaSonucVM;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Program;
using NeSever.Data.DataService.Program;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeServer.Business.Program
{
    public interface IProgramBusiness
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

    public class ProgramBusiness : BaseBusiness, IProgramBusiness
    {
        private readonly IProgramDataService programDataService;
        private readonly IMapper mapper;

        public ProgramBusiness(IProgramDataService programDataService, IMapper mapper)
        {
            this.programDataService = programDataService;
            this.mapper = mapper;
        }

        #region Ayarlar

        #region Admin   
        public async Task<AyarlarVM> AyarlarBilgileriniGetir()
        {
            return await programDataService.AyarlarBilgileriniGetir();
        }

        public async Task<int> AyarlarGuncelle(AyarlarVM data)
        {
            return await programDataService.AyarlarGuncelle(data);
        }
    
        public async Task<List<LogVM>> LogArama(LogAramaVM model)
        {
            return await programDataService.LogArama(model);
        }
        #endregion

        #region FrontEnd

        public async Task<UyelikSozlesmesiVM> UyelikSozlesmesiGetir()
        {
            return await programDataService.UyelikSozlesmesiGetir();
        }

        public async Task<HakkimizdaVM> HakkimizdaBilgiGetir()
        {
            return await programDataService.HakkimizdaBilgiGetir();
        }

        public async Task<IletisimVM> IletisimBilgiGetir()
        {
            return await programDataService.IletisimBilgiGetir();
        }

        public async Task<BilgiVM> BilgiGetir()
        {
            return await programDataService.BilgiGetir();
        }

        public async Task<bool> IletisimTalepGonder(IletisimTalepVM model)
        {
            return await programDataService.IletisimTalepGonder(model);
        }
        public async Task<SikSorulanSorularVM> SikSorulanSorularGetir()
        {
            return await programDataService.SikSorulanSorularGetir();
        }

        #endregion

        #endregion

        #region YoneticiKullanici

        #region Admin

        public async Task<bool> YoneticiKullaniciKontrol(string eposta)
        {
            return await programDataService.YoneticiKullaniciKontrol(eposta);
        }

        public async Task<YoneticiKullaniciVM> YoneticiKullaniciGirisDataGetir(YoneticiKullaniciGirisVM model)
        {
            return await programDataService.YoneticiKullaniciGirisDataGetir(model);
        }

        public async Task<int> YoneticiKullaniciKaydet(YoneticiKullaniciKayitVM model)
        {
            return await programDataService.YoneticiKullaniciKaydet(model);
        }

        public async Task<bool> YoneticiKullaniciSil(int id)
        {
            return await programDataService.YoneticiKullaniciSil(id);
        }

        public async Task<YoneticiKullaniciKayitVM> YoneticiKullaniciKayitVMGetir(int id)
        {
            return await programDataService.YoneticiKullaniciKayitVMGetir(id);
        }

        public async Task<List<YoneticiKullaniciAramaSonucVM>> YoneticiKullaniciArama(YoneticiKullaniciAramaVM model)
        {
            return await programDataService.YoneticiKullaniciArama(model);
        }

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Kullanici

        #region Admin

        public async Task<List<KullaniciAramaSonucVM>> UyeArama(KullaniciAramaVM model)
        {
            return await programDataService.UyeArama(model);
        }

        public async Task<List<KullaniciAramaSonucVM>> DogumKriterliUyeArama(DogumKriterliKullaniciAramaVM model)
        {
            return await programDataService.DogumKriterliUyeArama(model);
        }

        public async Task<List<UrunSayisinaGoreKullaniciAramaSonucVM>> UrunSayisinaGoreUyeArama(UrunSayisinaGoreKullaniciArama model)
        {
            return await programDataService.UrunSayisinaGoreUyeArama(model);
        }

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region Panel Anasayfa

        #region Admin
        public async Task<PanelAnasayfaRaporlarVM> PanelAnasayfaRaporlariGetir()
        {
            return await programDataService.PanelAnasayfaRaporlariGetir();
        }
        #endregion

        #region FrontEnd

        #endregion

        #endregion
    }
}