using Microsoft.Extensions.Options;
using NeSever.Common.Models;
using NeSever.Common.Models.DataAktarim;
using NeSever.Common.Models.Sistem;
using NeSever.Common.Utils.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NeSever.WebUI.Services
{
    public interface ISistemApiService
    {
        Task<List<TreeViewNodeModel>> KategoriListesiniGetir();
        Task<List<DataKategoriAramaResultVM>> DataKategoriListesiniGetir(DataKategoriAramaVM dataKategoriAramaVM);
        Task<int> GuncelleDataKategoriIsActive(int id, bool isActive);
        Task<int> GuncelleDataKategoriTargetCategory(int id, int targetCategoryId);
        Task<int> DataKategoriTargetCategorySil(int id);
        Task<ResultModel> CacheTemizleme(CacheTemizleme vm);
    }
    public class SistemApiService : ISistemApiService
    {
        private readonly HttpClient httpClient;

        private readonly IOptions<NeSeverSettings> _appSettings;

        public SistemApiService(HttpClient httpClient, IOptions<NeSeverSettings> appSettings)
        {
            _appSettings = appSettings;
            httpClient.BaseAddress = new Uri(_appSettings.Value.ApiAdress + "/api/Sistem/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.httpClient = httpClient;
        }

        public async Task<List<TreeViewNodeModel>> KategoriListesiniGetir()
        {
            List<TreeViewNodeModel> TreeViewNodeModel = new List<TreeViewNodeModel>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KategoriTreeViewListesiniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    TreeViewNodeModel = JsonConvert.DeserializeObject<List<TreeViewNodeModel>>(responseData);
                }
                return TreeViewNodeModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<List<DataKategoriAramaResultVM>> DataKategoriListesiniGetir(DataKategoriAramaVM dataKategoriAramaVM)
        {
            List<DataKategoriAramaResultVM> DataKategoriAramaResultVM = new List<DataKategoriAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("DataKategoriListesiniGetir", dataKategoriAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    DataKategoriAramaResultVM = JsonConvert.DeserializeObject<List<DataKategoriAramaResultVM>>(responseData);
                }
                return DataKategoriAramaResultVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<int> GuncelleDataKategoriIsActive(int id, bool isActive)
        {

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("GuncelleDataKategoriIsActive/?id=" + id.ToString() + "&isActive=" + isActive.ToString());
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
        public async Task<int> GuncelleDataKategoriTargetCategory(int id, int targetCategoryId)
        {

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("GuncelleDataKategoriTargetCategory/?id=" + id.ToString() + "&targetCategoryId=" + targetCategoryId.ToString());
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
        public async Task<int> DataKategoriTargetCategorySil(int id)
        {

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("DataKategoriTargetCategorySil/?id=" + id.ToString());
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

        public async Task<ResultModel> CacheTemizleme(CacheTemizleme vm)
        {
            ResultModel cacheTemizlemeSonuc = new ResultModel();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("CacheTemizleme", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    cacheTemizlemeSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData);
                }
                return cacheTemizlemeSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
