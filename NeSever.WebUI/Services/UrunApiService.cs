using Microsoft.Extensions.Options;
using NeSever.Common.Models.Admin.AramaSonucVM;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Urun;
using NeSever.Common.Utils.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using X.PagedList;

namespace NeSever.WebUI.Services
{
    public interface IUrunApiService
    {
        #region Marka

        #region Admin

        #endregion

        #region FrontEnd
        Task<List<KategoriIcerikVM>> KategoriIcerikListGetir(bool anasayfadaGoster = true);
        Task<List<MarkaIcerikVM>> MarkaIcerikListGetir();
        Task<List<UrunIcerikVM>> TrendKadinUrunIcerikListGetir();
        Task<List<UrunIcerikVM>> TrendErkekUrunIcerikListGetir();
        Task<IPagedList<UrunIcerikVM>> UrunIcerikListGetir(UrunIcerikAramaVM urunIcerikAramaVM);
        Task<UrunDetayIcerikVM> UrunDetayIcerikGetir(int id);
        Task<MarkaAramaSayfaSonucVM> MarkaListGetir(string m);
        Task<string> MarkaAdindanIdGetir(string markaAdi);
        Task<List<GoruntulenenUrunAramaSonucVM>> GoruntulenenUrunRaporuGetir(GoruntulenenUrunAramaVM model);
        Task<List<YonlendirilenUrunAramaSonucVM>> YonlendirilenUrunRaporuGetir(YonlendirilenUrunAramaVM model);

        #endregion

        #endregion

        #region Kategori
        Task<int> KategoriKaydet(KategoriVM kategoriVM);
        Task<KategoriVM> KategoriGetirById(int id);
        Task<int> KategoriSil(int id);
        Task<List<KategoriAramaResultVM>> KategoriArama(KategoriAramaVM kategoriAramaVM);
        Task<List<KategoriVM>> KategoriListesiniGetir();

        #endregion

        #region KategoriBanner
        
        Task<KategoriBannerVM> KategoriBannerGetirById(int id);
        Task<int> KategoriBannerKaydet(KategoriBannerVM kategoriVM);
        Task<List<KategoriBannerAramaResultVM>> KategoriBannerArama(KategoriBannerAramaVM kategoriAramaVM);
        Task<int> KategoriBannerSil(int id);
        Task<List<KategoriBannerVM>> KategoriBannerListesiniGetir();

        #endregion

        #region Urun
        Task<int> UrunKaydet(UrunVM urunVM);
        Task<UrunVM> UrunGetirById(int id);
        Task<int> UrunSil(int id);
        Task<List<UrunAramaResultVM>> UrunArama(UrunAramaVM urunAramaVM);
        Task<List<UrunResimVM>> UrunResimGetirById(int id);
        Task<List<UrunKategoriVM>> UrunKategoriGetirById(int id);
        Task<int> UrunResimKaydet(UrunResimVM urunresimVM);
        Task YonlendirmeSayisiArttir(int urunId);
        Task KullaniciFiyatGorListArttir(Guid kullaniciId, int urunId);
        Task<SurprizHediyeSonucVM> SurprizHediyeKontrol(SurprizHediyeVM surprizHediye);
        #endregion

        #region Sürpriz Ürün
        Task<List<SurprizUrunGetirVM>> SurprizUrunGetir(SurprizUrunKayitVM data);
        Task<SurprizUrunKayitVM> SurprizUrunGetirById(int id);
        Task<int> SurprizUrunKayit(SurprizUrunKayitVM model);
        Task<List<SurprizUrunAramaSonucVM>> SurprizUrunArama(SurprizUrunAramaVM model);
        Task<int> SurprizUrunSil(int id);
        #endregion
    }

    public class UrunApiService : IUrunApiService
    {
        private readonly HttpClient httpClient;

        private readonly IOptions<NeSeverSettings> _appSettings;

        public UrunApiService(HttpClient httpClient, IOptions<NeSeverSettings> appSettings)
        {
            _appSettings = appSettings;
            httpClient.BaseAddress = new Uri(_appSettings.Value.ApiAdress + "/api/Urun/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.httpClient = httpClient;
        }

        #region Marka

        #region Admin

        #endregion

        #region FrontEnd
        public async Task<List<KategoriIcerikVM>> KategoriIcerikListGetir(bool anasayfadaGoster = true)
        {
            List<KategoriIcerikVM> KategoriIcerikVMList = new List<KategoriIcerikVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KategoriIcerikListGetir/?anasayfadaGoster=" + anasayfadaGoster);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    KategoriIcerikVMList = JsonConvert.DeserializeObject<List<KategoriIcerikVM>>(responseData);
                }
                return KategoriIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MarkaIcerikVM>> MarkaIcerikListGetir()
        {
            List<MarkaIcerikVM> MarkaIcerikVMList = new List<MarkaIcerikVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("MarkaIcerikListGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    MarkaIcerikVMList = JsonConvert.DeserializeObject<List<MarkaIcerikVM>>(responseData);
                }
                return MarkaIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UrunIcerikVM>> TrendKadinUrunIcerikListGetir()
        {
            List<UrunIcerikVM> UrunIcerikVMList = new List<UrunIcerikVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("TrendKadinUrunIcerikListGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    UrunIcerikVMList = JsonConvert.DeserializeObject<List<UrunIcerikVM>>(responseData);
                }
                return UrunIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UrunIcerikVM>> TrendErkekUrunIcerikListGetir()
        {
            List<UrunIcerikVM> UrunIcerikVMList = new List<UrunIcerikVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("TrendErkekUrunIcerikListGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    UrunIcerikVMList = JsonConvert.DeserializeObject<List<UrunIcerikVM>>(responseData);
                }
                return UrunIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPagedList<UrunIcerikVM>> UrunIcerikListGetir(UrunIcerikAramaVM blogIcerikAramaVM)
        {
            IPagedList<UrunIcerikVM> UrunIcerikVMList = new List<UrunIcerikVM>().ToPagedList();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("UrunIcerikListGetir", blogIcerikAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<UrunIcerikVM>>(responseData);
                    StaticPagedList<UrunIcerikVM> result = new StaticPagedList<UrunIcerikVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return UrunIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UrunDetayIcerikVM> UrunDetayIcerikGetir(int id)
        {
            try
            {
                UrunDetayIcerikVM model = new UrunDetayIcerikVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunDetayIcerikGetir/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<UrunDetayIcerikVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MarkaAramaSayfaSonucVM> MarkaListGetir(string m)
        {
            MarkaAramaSayfaSonucVM MarkaIcerikVMList = new MarkaAramaSayfaSonucVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("MarkaListGetir/?m=" + m);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    MarkaIcerikVMList = JsonConvert.DeserializeObject<MarkaAramaSayfaSonucVM>(responseData);
                }
                return MarkaIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> MarkaAdindanIdGetir(string markaAdi)
        {
            string markaId = "";
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("MarkaAdindanIdGetir/?markaAdi=" + markaAdi);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    markaId = responseData;
                }
                return markaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GoruntulenenUrunAramaSonucVM>> GoruntulenenUrunRaporuGetir(GoruntulenenUrunAramaVM model)
        {
            List<GoruntulenenUrunAramaSonucVM> GoruntulenenUrunRaporVM = new List<GoruntulenenUrunAramaSonucVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("GoruntulenenUrunRaporuGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    GoruntulenenUrunRaporVM = JsonConvert.DeserializeObject<List<GoruntulenenUrunAramaSonucVM>>(responseData);
                }
                return GoruntulenenUrunRaporVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<YonlendirilenUrunAramaSonucVM>> YonlendirilenUrunRaporuGetir(YonlendirilenUrunAramaVM model)
        {
            List<YonlendirilenUrunAramaSonucVM> YonlendirilenUrunRaporVM = new List<YonlendirilenUrunAramaSonucVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("YonlendirilenUrunRaporuGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    YonlendirilenUrunRaporVM = JsonConvert.DeserializeObject<List<YonlendirilenUrunAramaSonucVM>>(responseData);
                }
                return YonlendirilenUrunRaporVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region Kategori
        public async Task<int> KategoriKaydet(KategoriVM kategoriVM)
        {
            int sonuc = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KategoriKaydet", kategoriVM);
                if (responseMessage.IsSuccessStatusCode)
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

        public async Task<KategoriVM> KategoriGetirById(int id)
        {
            try
            {
                KategoriVM model = new KategoriVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KategoriGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<KategoriVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> KategoriGuncelle(KategoriVM kategori)
        {
            int result = -1;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KategoriGuncelle", kategori);
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

        public async Task<List<KategoriAramaResultVM>> KategoriArama(KategoriAramaVM kategoriAramaVM)
        {
            List<KategoriAramaResultVM> KategoriLst = new List<KategoriAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KategoriArama", kategoriAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    KategoriLst = JsonConvert.DeserializeObject<List<KategoriAramaResultVM>>(responseData);
                }
                return KategoriLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> KategoriSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KategoriSil/?id=" + id.ToString());
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
        public async Task<List<KategoriVM>> KategoriListesiniGetir()
        {
            List<KategoriVM> KategoriLst = new List<KategoriVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KategoriListesiniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    KategoriLst = JsonConvert.DeserializeObject<List<KategoriVM>>(responseData);
                }
                return KategoriLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        #endregion

        #region KategoriBanner
        public async Task<KategoriBannerVM> KategoriBannerGetirById(int id)
        {
            try
            {
                KategoriBannerVM model = new KategoriBannerVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KategoriBannerGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<KategoriBannerVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> KategoriBannerKaydet(KategoriBannerVM kategoriBannerVM)
        {
            int sonuc = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KategoriBannerKaydet", kategoriBannerVM);
                if (responseMessage.IsSuccessStatusCode)
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

        public async Task<List<KategoriBannerAramaResultVM>> KategoriBannerArama(KategoriBannerAramaVM kategoriAramaVM)
        {
            List<KategoriBannerAramaResultVM> KategoriLst = new List<KategoriBannerAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KategoriBannerArama", kategoriAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    KategoriLst = JsonConvert.DeserializeObject<List<KategoriBannerAramaResultVM>>(responseData);
                }
                return KategoriLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> KategoriBannerSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KategoriBannerSil/?id=" + id.ToString());
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

        public async Task<List<KategoriBannerVM>> KategoriBannerListesiniGetir()
        {
            List<KategoriBannerVM> KategoriBannerList = new List<KategoriBannerVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KategoriBannerListesiniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    KategoriBannerList = JsonConvert.DeserializeObject<List<KategoriBannerVM>>(responseData);
                }
                return KategoriBannerList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Urun

        public async Task<int> UrunKaydet(UrunVM urunVM)
        {
            int sonuc = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("UrunKaydet", urunVM);
                if (responseMessage.IsSuccessStatusCode)
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

        public async Task<int> UrunResimKaydet(UrunResimVM urunresimVM)
        {
            int sonuc = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("UrunResimKaydet", urunresimVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    sonuc = JsonConvert.DeserializeObject<int>(responseData);
                }
                return sonuc;
            }
            catch (Exception ex)
            {
                return sonuc;
            }
        }

        public async Task<UrunVM> UrunGetirById(int id)
        {
            try
            {
                UrunVM model = new UrunVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<UrunVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UrunAramaResultVM>> UrunArama(UrunAramaVM urunAramaVM)
        {
            List<UrunAramaResultVM> UrunLst = new List<UrunAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("UrunArama", urunAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    UrunLst = JsonConvert.DeserializeObject<List<UrunAramaResultVM>>(responseData);
                }
                return UrunLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UrunSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunSil/?id=" + id.ToString());
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

        public async Task<List<UrunResimVM>> UrunResimGetirById(int id)
        {
            try
            {
                List<UrunResimVM> model = new List<UrunResimVM>();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunResimGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<UrunResimVM>>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UrunKategoriVM>> UrunKategoriGetirById(int id)
        {
            try
            {
                List<UrunKategoriVM> model = new List<UrunKategoriVM>();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunKategoriGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<UrunKategoriVM>>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task YonlendirmeSayisiArttir(int urunId)
        {
            UrunYonlendirmeSayisi urun = new UrunYonlendirmeSayisi();
            urun.UrunId = urunId;
            try
            {
                await httpClient.PostAsJsonAsync("YonlendirmeSayisiArttir", urun);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task KullaniciFiyatGorListArttir(Guid kullaniciId, int urunId)
        {
            KullaniciFiyatGorVM kullanici = new KullaniciFiyatGorVM();
            kullanici.KullaniciId = kullaniciId;
            kullanici.UrunId = urunId;
            try
            {
                await httpClient.PostAsJsonAsync("KullaniciFiyatGorListArttir", kullanici);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SurprizHediyeSonucVM> SurprizHediyeKontrol(SurprizHediyeVM surprizHediye)
        {
            SurprizHediyeSonucVM result = new SurprizHediyeSonucVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("SurprizHediyeKontrol", surprizHediye);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SurprizHediyeSonucVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Sürpriz Ürün
        public async Task<List<SurprizUrunGetirVM>> SurprizUrunGetir(SurprizUrunKayitVM data)
        {
            try
            {
                List<SurprizUrunGetirVM> model = new List<SurprizUrunGetirVM>();
                
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("SurprizUrunGetir",data);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<SurprizUrunGetirVM>>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<SurprizUrunKayitVM> SurprizUrunGetirById(int id)
        {
            try
            {
                SurprizUrunKayitVM model = new SurprizUrunKayitVM();

                HttpResponseMessage responseMessage = await httpClient.GetAsync("SurprizUrunGetirById/?id="+ id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<SurprizUrunKayitVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<int> SurprizUrunKayit(SurprizUrunKayitVM model)
        {
            try
            {
                var id = -1;
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("SurprizUrunKayit", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    id = JsonConvert.DeserializeObject<int>(responseData);
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<SurprizUrunAramaSonucVM>> SurprizUrunArama(SurprizUrunAramaVM model)
        {
            try
            {
                List<SurprizUrunAramaSonucVM> result = new List<SurprizUrunAramaSonucVM>();
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("SurprizUrunArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<SurprizUrunAramaSonucVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> SurprizUrunSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("SurprizUrunSil/?id=" + id.ToString());
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


        #endregion
    }
}
