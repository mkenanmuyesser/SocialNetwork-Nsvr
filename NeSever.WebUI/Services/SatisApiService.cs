using Microsoft.Extensions.Options;
using NeSever.Common.Models.Satis;
using NeSever.Common.Utils.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeSever.WebUI.Services
{
    public interface ISatisApiService
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

    public class SatisApiService : ISatisApiService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<NeSeverSettings> _appSettings;

        public SatisApiService(HttpClient httpClient, IOptions<NeSeverSettings> appSettings)
        {
            _appSettings = appSettings;
            httpClient.BaseAddress = new Uri(_appSettings.Value.ApiAdress + "/api/Satis/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.httpClient = httpClient;
        }

        #region Sepet

        #region Admin


        #endregion

        #region FrontEnd

        public async Task<OnBilgilendirmeFormuVM> OnBilgilendirmeFormuGetir()
        {
            OnBilgilendirmeFormuVM result = new OnBilgilendirmeFormuVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("OnBilgilendirmeFormuGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<OnBilgilendirmeFormuVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MesafeliSatisSozlesmesiVM> MesafeliSatisSozlesmesiGetir()
        {
            MesafeliSatisSozlesmesiVM result = new MesafeliSatisSozlesmesiVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("MesafeliSatisSozlesmesiGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<MesafeliSatisSozlesmesiVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<SepetIcerikVM> KullaniciSepetGetir(SepetVM model)
        {
            SepetIcerikVM result = new SepetIcerikVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSepetGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SepetIcerikVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> KullaniciSepetTemizle(SepetVM model)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSepetTemizle", model);
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

        public async Task<int> KullaniciSepetUrunArttir(SepetVM model)
        {
            var result = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSepetUrunArttir", model);
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

        public async Task<bool> KullaniciSepetUrunEksilt(SepetVM model)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSepetUrunEksilt", model);
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

        public async Task<bool> KullaniciSepetUrunSil(SepetVM model)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSepetUrunSil", model);
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

        public async Task<List<SepetAdresVM>> KullaniciSepetAdresleriGetir(KullaniciAdresVM model)
        {
            List<SepetAdresVM> result = new List<SepetAdresVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSepetAdresleriGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<SepetAdresVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SepetAdresVM> KullaniciSepetAdresGetir(SepetAdresVM model)
        {
            SepetAdresVM result = new SepetAdresVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSepetAdresGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SepetAdresVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> KullaniciSepetAdresKaydetGuncelle(SepetAdresVM model)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSepetAdresKaydetGuncelle", model);
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

        public async Task<bool> KullaniciSepetAdresSil(SepetAdresVM model)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSepetAdresSil", model);
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

        public async Task<AdresIcerikVM> KullaniciAdreslerGetir(AdresVM model)
        {
            AdresIcerikVM result = new AdresIcerikVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciAdreslerGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<AdresIcerikVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OdemeIcerikVM> KullaniciOdemeGetir(OdemeVM model)
        {
            OdemeIcerikVM result = new OdemeIcerikVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciOdemeGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<OdemeIcerikVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> KullaniciOdemeYap(OdemeIcerikVM model)
        {
            int result = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciOdemeYap", model);
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

        public async Task<OdemeSonucVM> KullaniciOdemeSonucGetir(OdemeVM model)
        {
            OdemeSonucVM result = new OdemeSonucVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciOdemeSonucGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<OdemeSonucVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AdresIlceVM>> SepetAdresIlceGetir(int id)
        {
            List<AdresIlceVM> result = new List<AdresIlceVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SepetAdresIlceGetir?id=" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<AdresIlceVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> KullaniciOdemeSil(int id)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciOdemeSil?id=" +  id);
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

        #endregion

        #endregion

        #region Sipariş

        #region Admin

        public async Task<List<AdresIlVM>> SatisAdresIlGetir()
        {
            List<AdresIlVM> result = new List<AdresIlVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SatisAdresIlGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<AdresIlVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OdemeDurumTipVM>> OdemeDurumTipListesiGetir()
        {
            List<OdemeDurumTipVM> result = new List<OdemeDurumTipVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("OdemeDurumTipListesiGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<OdemeDurumTipVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SiparisDurumTipVM>> SiparisDurumTipListesiGetir()
        {
            List<SiparisDurumTipVM> result = new List<SiparisDurumTipVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SiparisDurumTipListesiGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<SiparisDurumTipVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SiparisOdemeTipVM>> SiparisOdemeTipListesiGetir()
        {
            List<SiparisOdemeTipVM> result = new List<SiparisOdemeTipVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SiparisOdemeTipListesiGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<SiparisOdemeTipVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SiparisAramaSonucVM>> SiparisAramaSonuc(SiparisAramaVM model)
        {
            List<SiparisAramaSonucVM> result = new List<SiparisAramaSonucVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("SiparisAramaSonuc", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<SiparisAramaSonucVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SiparisSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SiparisSil/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SiparisAramaDetayVM> SiparisDetay(int id)
        {
            SiparisAramaDetayVM result = new SiparisAramaDetayVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SiparisDetay/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SiparisAramaDetayVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> SiparisGuncelle(SiparisAramaDetayVM model)
        {
            var result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("SiparisGuncelle", model);
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
        public async Task<bool> SiparisHareketKaydet(SiparisAramaDetayVM model)
        {
            var result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("SiparisHareketKaydet", model);
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
        public async Task<bool> SiparisHareketSil(int id)
        {
            var result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SiparisHareketSil/?id=" + id);
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

        public async Task<bool> SiparisDetayDurum(int id)
        {
            var result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SiparisDetayDurum/?id=" + id);
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
        #endregion

        #region FrontEnd

        public async Task<List<SiparisVM>> KullaniciSiparisListesiGetir(KullaniciSiparisVM model)
        {
            List<SiparisVM> result = new List<SiparisVM>();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSiparisListesiGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<SiparisVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SiparisVM> KullaniciSiparisDetayGetir(KullaniciSiparisVM model)
        {
            SiparisVM result = new SiparisVM();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSiparisDetayGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SiparisVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> KullaniciSiparisGuncelle(KullaniciSiparisVM model)
        {
            bool result = false;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSiparisGuncelle", model);
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

        #endregion

        #endregion
    }
}
