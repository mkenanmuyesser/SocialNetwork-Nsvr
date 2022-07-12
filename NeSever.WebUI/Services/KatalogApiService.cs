using Microsoft.Extensions.Options;
using NeSever.Common.Models.Katalog;
using NeSever.Common.Utils.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeSever.WebUI.Services
{
    public interface IKatalogApiService
    {
        Task<List<MarkaAramaResultVM>> MarkaArama(MarkaAramaVM model);



        Task<int> MarkaSiralamaGuncelle(int id, int sira);

        Task<MarkaVM> MarkaGetirById(int id);

        Task<int> MarkaGuncelle(MarkaVM data);

        Task<List<MarkaVM>> MarkaListesiGetir();
    }
    public class KatalogApiService : IKatalogApiService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<NeSeverSettings> _appSettings;

        public KatalogApiService(HttpClient httpClient, IOptions<NeSeverSettings> appSettings)
        {
            _appSettings = appSettings;
            httpClient.BaseAddress = new Uri(_appSettings.Value.ApiAdress + "/api/Katalog/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.httpClient = httpClient;
        }

        public async Task<List<MarkaAramaResultVM>> MarkaArama(MarkaAramaVM model)
        {
            List<MarkaAramaResultVM> MarkaAramaResultVM = new List<MarkaAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("MarkaArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    MarkaAramaResultVM = JsonConvert.DeserializeObject<List<MarkaAramaResultVM>>(responseData);
                }
                return MarkaAramaResultVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<MarkaVM>> MarkaListesiGetir()
        {
            List<MarkaVM> MarkaAramaResultVM = new List<MarkaVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("MarkaListesiGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    MarkaAramaResultVM = JsonConvert.DeserializeObject<List<MarkaVM>>(responseData);
                }
                return MarkaAramaResultVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> MarkaGuncelle(MarkaVM data)
        {
            try
            {
                int sonuc = 0;
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("MarkaGuncelle", data);
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    sonuc = JsonConvert.DeserializeObject<int>(responseData);

                }
                return sonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> MarkaSiralamaGuncelle(int id, int sira)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("MarkaSiralamaGuncelle/?id=" + id.ToString() + "&sira=" + sira.ToString());
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
        public async Task<MarkaVM> MarkaGetirById(int id)
        {
            try
            {
                MarkaVM resultModel = new MarkaVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("MarkaGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    resultModel = JsonConvert.DeserializeObject<MarkaVM>(responseData);
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
