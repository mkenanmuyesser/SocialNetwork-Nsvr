using Microsoft.Extensions.Options;
using NeSever.Common.Models.DataAktarim;
using NeSever.Common.Utils.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeSever.WebUI.Services
{
    public interface IDataAktarimApiService
    {
        Task<WebSiteBilgileriVM> WebSiteBilgileriniGetir();

        Task<WebSiteVM> WebSiteArama(WebSiteVM model);

        Task<int> DurumGuncelle(int webSiteId);

        Task<List<WebSiteAramaSonucVM>> WebSiteListesiniGetir();

        Task<UrunLinkIslemBilgileriVM> UrunLinkBilgileriniGetir();
        Task<UrunLinkIslemVM> UrunLinkArama(UrunLinkIslemVM model);

        Task<int> UrunLinkDurumGuncelle(int id);

        Task<HataLogVM> HataLogArama(HataLogVM model);
    }
    public class DataAktarimApiService : IDataAktarimApiService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<NeSeverSettings> _appSettings;

        public DataAktarimApiService(HttpClient httpClient, IOptions<NeSeverSettings> appSettings)
        {
            _appSettings = appSettings;
            httpClient.BaseAddress = new Uri(_appSettings.Value.ApiAdress + "/api/DataAktarim/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.httpClient = httpClient;
        }

        public async Task<WebSiteBilgileriVM> WebSiteBilgileriniGetir()
        {
            WebSiteBilgileriVM WebSiteVMResult = new WebSiteBilgileriVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("WebSiteBilgileriniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    WebSiteVMResult = JsonConvert.DeserializeObject<WebSiteBilgileriVM>(responseData);
                }
                return WebSiteVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<WebSiteAramaSonucVM>> WebSiteListesiniGetir()
        {
            List<WebSiteAramaSonucVM> WebSiteAramaSonucVMResult = new List<WebSiteAramaSonucVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("WebSiteListesiniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    WebSiteAramaSonucVMResult = JsonConvert.DeserializeObject<List<WebSiteAramaSonucVM>>(responseData);
                }
                return WebSiteAramaSonucVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<WebSiteVM> WebSiteArama(WebSiteVM model)
        {
            WebSiteVM WebSiteVMResult = new WebSiteVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("WebSiteArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    WebSiteVMResult = JsonConvert.DeserializeObject<WebSiteVM>(responseData);
                }
                return WebSiteVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DurumGuncelle(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("DurumGuncelle/?id=" + id.ToString());
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
        public async Task<UrunLinkIslemBilgileriVM> UrunLinkBilgileriniGetir()
        {
            UrunLinkIslemBilgileriVM UrunLinkIslemBilgileriVMResult = new UrunLinkIslemBilgileriVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunLinkBilgileriniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    UrunLinkIslemBilgileriVMResult = JsonConvert.DeserializeObject<UrunLinkIslemBilgileriVM>(responseData);
                }
                return UrunLinkIslemBilgileriVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UrunLinkIslemVM> UrunLinkArama(UrunLinkIslemVM model)
        {
            UrunLinkIslemVM UrunLinkIslemVMResult = new UrunLinkIslemVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("UrunLinkArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    UrunLinkIslemVMResult = JsonConvert.DeserializeObject<UrunLinkIslemVM>(responseData);
                }
                return UrunLinkIslemVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UrunLinkDurumGuncelle(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunLinkDurumGuncelle/?id=" + id.ToString());
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
        public async Task<HataLogVM> HataLogArama(HataLogVM model)
        {
            HataLogVM HataLogVMResult = new HataLogVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HataLogArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    HataLogVMResult = JsonConvert.DeserializeObject<HataLogVM>(responseData);
                }
                return HataLogVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
