using Microsoft.Extensions.Options;
using NeSever.Common.Models.Admin;
using NeSever.Common.Models.Admin.AramaSonucVM;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Program;
using NeSever.Common.Utils.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeSever.WebUI.Services
{
    public interface IProgramApiService
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

    public class ProgramApiService : IProgramApiService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<NeSeverSettings> _appSettings;

        public ProgramApiService(HttpClient httpClient, IOptions<NeSeverSettings> appSettings)
        {
            _appSettings = appSettings;
            httpClient.BaseAddress = new Uri(_appSettings.Value.ApiAdress + "/api/Program/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.httpClient = httpClient;
        }

        #region Ayarlar

        #region Admin  

        public async Task<AyarlarVM> AyarlarBilgileriniGetir()
        {
            AyarlarVM result = new AyarlarVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("AyarlarBilgileriniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<AyarlarVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AyarlarGuncelle(AyarlarVM model)
        {


            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("AyarlarGuncelle", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
        public async Task<List<LogVM>> LogArama(LogAramaVM model)
        {

            List<LogVM> result = new List<LogVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("LogArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<LogVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FrontEnd

        public async Task<UyelikSozlesmesiVM> UyelikSozlesmesiGetir()
        {
            UyelikSozlesmesiVM result = new UyelikSozlesmesiVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UyelikSozlesmesiGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<UyelikSozlesmesiVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HakkimizdaVM> HakkimizdaBilgiGetir()
        {
            HakkimizdaVM result = new HakkimizdaVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HakkimizdaBilgiGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<HakkimizdaVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IletisimVM> IletisimBilgiGetir()
        {
            IletisimVM result = new IletisimVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("IletisimBilgiGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<IletisimVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BilgiVM> BilgiGetir()
        {
            BilgiVM result = new BilgiVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BilgiGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<BilgiVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> IletisimTalepGonder(IletisimTalepVM model)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("IletisimTalepGonder", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<bool>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SikSorulanSorularVM> SikSorulanSorularGetir()
        {
            SikSorulanSorularVM result = new SikSorulanSorularVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SikSorulanSorularGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SikSorulanSorularVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region YoneticiKullanici

        #region Admin

        public async Task<bool> YoneticiKullaniciKontrol(string eposta)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("YoneticiKullaniciKontrol/?eposta=" + eposta);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = Convert.ToBoolean(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<YoneticiKullaniciVM> YoneticiKullaniciGirisDataGetir(YoneticiKullaniciGirisVM model)
        {
            YoneticiKullaniciVM result = new YoneticiKullaniciVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("YoneticiKullaniciGirisDataGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<YoneticiKullaniciVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> YoneticiKullaniciKaydet(YoneticiKullaniciKayitVM model)
        {
            int result = -1;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("YoneticiKullaniciKaydet", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<int>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> YoneticiKullaniciSil(int id)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("YoneticiKullaniciSil/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = Convert.ToBoolean(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<YoneticiKullaniciKayitVM> YoneticiKullaniciKayitVMGetir(int id)
        {
            YoneticiKullaniciKayitVM result = new YoneticiKullaniciKayitVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("YoneticiKullaniciKayitVMGetir/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<YoneticiKullaniciKayitVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<YoneticiKullaniciAramaSonucVM>> YoneticiKullaniciArama(YoneticiKullaniciAramaVM model)
        {
            List<YoneticiKullaniciAramaSonucVM> result = new List<YoneticiKullaniciAramaSonucVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("YoneticiKullaniciArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<YoneticiKullaniciAramaSonucVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
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
            List<KullaniciAramaSonucVM> result = new List<KullaniciAramaSonucVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("UyeArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<KullaniciAramaSonucVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<KullaniciAramaSonucVM>> DogumKriterliUyeArama(DogumKriterliKullaniciAramaVM model)
        {
            List<KullaniciAramaSonucVM> result = new List<KullaniciAramaSonucVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("DogumKriterliUyeArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<KullaniciAramaSonucVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UrunSayisinaGoreKullaniciAramaSonucVM>> UrunSayisinaGoreUyeArama(UrunSayisinaGoreKullaniciArama model)
        {
            List<UrunSayisinaGoreKullaniciAramaSonucVM> result = new List<UrunSayisinaGoreKullaniciAramaSonucVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("UrunSayisinaGoreUyeArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<UrunSayisinaGoreKullaniciAramaSonucVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
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
            PanelAnasayfaRaporlarVM result = new PanelAnasayfaRaporlarVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("PanelAnasayfaRaporlariGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<PanelAnasayfaRaporlarVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region FrontEnd

        #endregion

        #endregion
    }
}
