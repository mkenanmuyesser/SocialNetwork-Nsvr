using Microsoft.Extensions.Options;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
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
    public interface ISayfaApiService
    {
        #region Blog

        #region Admin
        Task<int> BlogKaydet(BlogKayitVM model);
        Task<List<BlogKategoriVM>> BlogKategoriTipleriniGetir();
        Task<List<Common.Models.Sayfa.UrunVM>> UrunListesiniGetir(string urunSku);
        Task<List<Common.Models.Sayfa.UrunVM>> UrunListesiniGetir();
        Task<Common.Models.Sayfa.UrunVM> UrunListesiniGetirIdIle(int urunId);
        Task<List<BlogAramaResultVM>> BlogArama(BlogAramaVM blogAramaVM);
        Task<int> BlogSil(int id);
        Task<BlogKayitVM> BlogGetirById(int id);
        Task<int> BlogGuncelle(BlogKayitVM blog);
        Task<int> BlogResimPasifeAl(int blogResimId);
        Task<List<BlogResimVM>> ResimListesiniGetir(int blogId);
        Task<List<UrunAramaResultVM>> BlogUrunArama(UrunAramaVM urunAramaVM);
        #endregion

        #region FrontEnd
        Task<BlogIcerikVM> BlogIcerikGetir(int id);
        Task<IPagedList<BlogIcerikVM>> BlogIcerikListGetir(BlogIcerikAramaVM blogIcerikAramaVM);
        #endregion

        #endregion

        #region Banner

        #region Admin
        Task<int> BannerKaydet(BannerKayitVM model);
        Task<List<BannerTipVM>> BannerTipleriniGetir();
        Task<BannerKayitVM> BannerGetirById(int id);
        Task<int> BannerSil(int id);
        Task<List<BannerAramaResultVM>> BannerArama(BannerAramaVM bannerAramaVM);
        #endregion

        #region FrontEnd
        Task<List<BannerIcerikVM>> BannerIcerikListGetir();
        #endregion

        #endregion

        #region KategoriBanner

        #region Admin

        #endregion

        #region FrontEnd
        Task<List<KategoriBannerIcerikVM>> KategoriBannerIcerikListGetir(KategoriBannerIcerikAramaVM urunIcerikAramaVM);
        #endregion

        #endregion

        #region BlogKategori

        #region Admin
        Task<int> BlogKategoriKaydet(BlogKategoriVM blogKategoriVM);
        Task<BlogKategoriVM> BlogKategoriGetirById(int id);
        Task<int> BlogKategoriSil(int id);
        Task<List<BlogKategoriResultVM>> BlogKategoriAra(BlogKategoriAramaVM blogKategoriAramaVM);
        Task<int> BlogKategoriResimPasifeAl(int blogKategoriResimId);
        Task<List<BlogKategoriResimVM>> BlogKategoriResimListesiniGetir(int blogKategoriId);
        #endregion

        #region FrontEnd
        Task<List<BlogKategoriIcerikVM>> BlogKategoriIcerikListGetir();
        #endregion

        #endregion

        #region Hediye Kart

        #region Admin
        Task<int> HediyeKartiKaydet(HediyeKartVM hediyeKartVM);
        Task<HediyeKartVM> HediyeKartiGetirById(int id);
        Task<int> HediyeKartSil(int id);
        Task<List<HediyeKartAramaResultVM>> HediyeKartArama(HediyeKartAramaVM hediyeKartAramaVM);
        #endregion

        #region FrontEnd
        Task<HediyeKartIcerikVM> HediyeKartIcerikGetir(int id);
        Task<List<HediyeKartIcerikVM>> HediyeKartIcerikListGetir();
        Task<IPagedList<HediyeKartIcerikVM>> HediyeKartAramaIcerikListGetir(HediyeKartIcerikAramaVM hediyeKartIcerik);
        #endregion

        #endregion

        #region Hediye Kart Kategori

        #region Admin

        Task<HediyeKartKategoriVM> HediyeKartKategoriGetirById(int id);
        Task<int> HediyeKartKategoriKaydet(HediyeKartKategoriVM hediyeKartKategoriVM);

        Task<List<HediyeKartKategoriAramaResultVM>> HediyeKartKategoriArama(HediyeKartKategoriAramaVM hediyeKartKategoriAramaVM);
        Task<int> HediyeKartKategoriSil(int id);
        Task<List<HediyeKartKategoriVM>> HediyeKartKategoriTipleriniGetir();

        #endregion

        #endregion

        #region Ilgi Alan
        Task<int> IlgiAlanKaydet(IlgiAlanVM ilgiAlanVM);
        Task<IlgiAlanVM> IlgiAlanGetirById(int id);
        Task<int> IlgiAlanSil(int id);
        Task<List<IlgiAlanAramaResultVM>> IlgiAlanArama(IlgiAlanAramaVM ilgiAlanAramaVM);

        #endregion

        #region Hobi
        Task<int> HobiKaydet(HobiVM hobiVM);
        Task<HobiVM> HobiGetirById(int id);
        Task<int> HobiSil(int id);
        Task<List<HobiAramaResultVM>> HobiArama(HobiAramaVM hobiAramaVM);

        #endregion

        #region DuvarResim

        #region Admin

        Task<int> DuvarResimKaydet(DuvarResimKayitVM model);
        Task<bool> DuvarResimSil(int id);
        Task<DuvarResimKayitVM> DuvarResimKayitVMGetir(int id);
        Task<List<DuvarResimAramaSonucVM>> DuvarResimAramaSonucVMGetir(DuvarResimAramaVM model);

        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region İndirim Kuponu 

        #region Admin
        Task<IndirimKuponuKayitVM> IndirimKuponuGetirById(int id);
        Task<int> IndirimKuponuKaydet(IndirimKuponuKayitVM model);
        Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuArama(IndirimKuponuAramaVM indirimKuponuAramaVM);
        Task<int> IndirimKuponuSil(int id);

        #endregion

        #region FrontEnd
        Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuGetir(IndirimKuponuAramaVM indirimKuponuAramaVM);
        #endregion

        #endregion
    }

    public class SayfaApiService : ISayfaApiService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<NeSeverSettings> _appSettings;

        public SayfaApiService(HttpClient httpClient, IOptions<NeSeverSettings> appSettings)
        {
            _appSettings = appSettings;
            httpClient.BaseAddress = new Uri(_appSettings.Value.ApiAdress + "/api/Sayfa/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.httpClient = httpClient;
        }

        #region Blog 

        #region Admin
        public async Task<List<BlogKategoriVM>> BlogKategoriTipleriniGetir()
        {
            List<BlogKategoriVM> blogKategoriVMsResult = new List<BlogKategoriVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BlogKategoriTipleriniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    blogKategoriVMsResult = JsonConvert.DeserializeObject<List<BlogKategoriVM>>(responseData);
                }
                return blogKategoriVMsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> BlogKaydet(BlogKayitVM model)
        {
            int result = -1;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BlogKaydet", model);
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

        public async Task<Common.Models.Sayfa.UrunVM> UrunListesiniGetirIdIle(int urunId)
        {
            Common.Models.Sayfa.UrunVM urunVMResult = new Common.Models.Sayfa.UrunVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunListesiniGetirIdIle/?urunId=" + urunId.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    urunVMResult = JsonConvert.DeserializeObject<Common.Models.Sayfa.UrunVM>(responseData);
                }
                return urunVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UrunAramaResultVM>> BlogUrunArama(UrunAramaVM urunAramaVM)
        {
            List<UrunAramaResultVM> urunVMResult = new List<UrunAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BlogUrunArama", urunAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    urunVMResult = JsonConvert.DeserializeObject<List<UrunAramaResultVM>>(responseData);
                }
                return urunVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Common.Models.Sayfa.UrunVM>> UrunListesiniGetir(string urunSku)
        {
            List<Common.Models.Sayfa.UrunVM> urunVMResult = new List<Common.Models.Sayfa.UrunVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunListesiGetir/?urunSKU=" + urunSku);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    urunVMResult = JsonConvert.DeserializeObject<List<Common.Models.Sayfa.UrunVM>>(responseData);
                }
                return urunVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<List<Common.Models.Sayfa.UrunVM>> UrunListesiniGetir()
        {
            List<Common.Models.Sayfa.UrunVM> urunVMResult = new List<Common.Models.Sayfa.UrunVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("UrunListesiniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    urunVMResult = JsonConvert.DeserializeObject<List<Common.Models.Sayfa.UrunVM>>(responseData);
                }
                return urunVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<List<BlogResimVM>> ResimListesiniGetir(int blogId)
        {
            List<BlogResimVM> resimVMResult = new List<BlogResimVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("ResimListesiniGetirBlogIdIle/?blogId=" + blogId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    resimVMResult = JsonConvert.DeserializeObject<List<BlogResimVM>>(responseData);
                }
                return resimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<List<BlogAramaResultVM>> BlogArama(BlogAramaVM blogAramaVM)
        {
            List<BlogAramaResultVM> BlogList = new List<BlogAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BlogArama", blogAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    BlogList = JsonConvert.DeserializeObject<List<BlogAramaResultVM>>(responseData);
                }
                return BlogList;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> BlogSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BlogSil/?id=" + id.ToString());
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

        public async Task<int> BlogResimPasifeAl(int blogResimId)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BlogResimPasifeAl/?blogResimId=" + blogResimId);
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

        public async Task<BlogKayitVM> BlogGetirById(int id)
        {
            try
            {
                BlogKayitVM model = new BlogKayitVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BlogGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BlogKayitVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> BlogGuncelle(BlogKayitVM blog)
        {
            int result = -1;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BlogGuncelle", blog);
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
        #endregion

        #region FrontEnd
        public async Task<BlogIcerikVM> BlogIcerikGetir(int id)
        {
            try
            {
                BlogIcerikVM model = new BlogIcerikVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BlogIcerikGetir/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BlogIcerikVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IPagedList<BlogIcerikVM>> BlogIcerikListGetir(BlogIcerikAramaVM blogIcerikAramaVM)
        {
            IPagedList<BlogIcerikVM> BlogIcerikVMList = new List<BlogIcerikVM>().ToPagedList();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BlogIcerikListGetir", blogIcerikAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<BlogIcerikVM>>(responseData);
                    StaticPagedList<BlogIcerikVM> result = new StaticPagedList<BlogIcerikVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return BlogIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Banner

        #region Admin
        public async Task<List<BannerTipVM>> BannerTipleriniGetir()
        {
            List<BannerTipVM> bannerTipResult = new List<BannerTipVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BannerTipleriniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    bannerTipResult = JsonConvert.DeserializeObject<List<BannerTipVM>>(responseData);
                }
                return bannerTipResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> BannerKaydet(BannerKayitVM model)
        {
            int result = -1;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BannerKaydet", model);
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

        public async Task<BannerKayitVM> BannerGetirById(int id)
        {
            try
            {
                BannerKayitVM model = new BannerKayitVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BannerGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BannerKayitVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<BannerAramaResultVM>> BannerArama(BannerAramaVM bannerAramaVM)
        {
            List<BannerAramaResultVM> BannerLst = new List<BannerAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BannerArama", bannerAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    BannerLst = JsonConvert.DeserializeObject<List<BannerAramaResultVM>>(responseData);
                }
                return BannerLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> BannerSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BannerSil/?id=" + id.ToString());
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

        #region FrontEnd
        public async Task<List<BannerIcerikVM>> BannerIcerikListGetir()
        {
            List<BannerIcerikVM> BannerIcerikVMList = new List<BannerIcerikVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BannerIcerikListGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    BannerIcerikVMList = JsonConvert.DeserializeObject<List<BannerIcerikVM>>(responseData);
                }
                return BannerIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region KategoriBanner

        #region Admin

        #endregion

        #region FrontEnd
        public async Task<List<KategoriBannerIcerikVM>> KategoriBannerIcerikListGetir(KategoriBannerIcerikAramaVM urunIcerikAramaVM)
        {
            List<KategoriBannerIcerikVM> result = new List<KategoriBannerIcerikVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KategoriBannerIcerikListGetir" , urunIcerikAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<KategoriBannerIcerikVM>>(responseData);
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

        #region BlogKategori

        #region Admin
        public async Task<int> BlogKategoriKaydet(BlogKategoriVM blogKategoriVM)
        {

            int sonuc = 0;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BlogKategoriKaydet", blogKategoriVM);
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

        public async Task<BlogKategoriVM> BlogKategoriGetirById(int id)
        {
            try
            {
                BlogKategoriVM model = new BlogKategoriVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BlogKategoriGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<BlogKategoriVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<BlogKategoriResultVM>> BlogKategoriAra(BlogKategoriAramaVM blogKategoriAramaVM)
        {
            List<BlogKategoriResultVM> BlogKategoriResultVM = new List<BlogKategoriResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BlogKategoriArama", blogKategoriAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    BlogKategoriResultVM = JsonConvert.DeserializeObject<List<BlogKategoriResultVM>>(responseData);
                }
                return BlogKategoriResultVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> BlogKategoriSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BlogKategoriSil/?id=" + id.ToString());
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

        public async Task<List<BlogKategoriResimVM>> BlogKategoriResimListesiniGetir(int blogKategoriId)
        {
            List<BlogKategoriResimVM> resimVMResult = new List<BlogKategoriResimVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("ResimListesiniGetirBlogKategoriIdIle/?blogKategoriId=" + blogKategoriId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    resimVMResult = JsonConvert.DeserializeObject<List<BlogKategoriResimVM>>(responseData);
                }
                return resimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> BlogKategoriResimPasifeAl(int blogKategoriResimId)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BlogKategoriResimPasifeAl/?blogKategoriResimId=" + blogKategoriResimId);
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

        #region FrontEnd
        public async Task<List<BlogKategoriIcerikVM>> BlogKategoriIcerikListGetir()
        {
            List<BlogKategoriIcerikVM> BlogKategoriIcerikVMList = new List<BlogKategoriIcerikVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BlogKategoriIcerikListGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    BlogKategoriIcerikVMList = JsonConvert.DeserializeObject<List<BlogKategoriIcerikVM>>(responseData);
                }
                return BlogKategoriIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Hediye Kart

        #region Admin
        public async Task<int> HediyeKartiKaydet(HediyeKartVM hediyeKartVM)
        {
            int sonuc = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HediyeKartiKaydet", hediyeKartVM);
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

        public async Task<HediyeKartVM> HediyeKartiGetirById(int id)
        {
            try
            {
                HediyeKartVM model = new HediyeKartVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HediyeKartiGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<HediyeKartVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HediyeKartAramaResultVM>> HediyeKartArama(HediyeKartAramaVM hediyeKartVM)
        {
            List<HediyeKartAramaResultVM> HediyeKartAramaResultM = new List<HediyeKartAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HediyeKartArama", hediyeKartVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    HediyeKartAramaResultM = JsonConvert.DeserializeObject<List<HediyeKartAramaResultVM>>(responseData);
                }
                return HediyeKartAramaResultM;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> HediyeKartSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HediyeKartSil/?id=" + id.ToString());
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

        #region FrontEnd
        public async Task<HediyeKartIcerikVM> HediyeKartIcerikGetir(int id)
        {
            try
            {
                HediyeKartIcerikVM model = new HediyeKartIcerikVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HediyeKartIcerikGetir/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<HediyeKartIcerikVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HediyeKartIcerikVM>> HediyeKartIcerikListGetir()
        {
            List<HediyeKartIcerikVM> HediyeKartIcerikVMList = new List<HediyeKartIcerikVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HediyeKartIcerikListGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    HediyeKartIcerikVMList = JsonConvert.DeserializeObject<List<HediyeKartIcerikVM>>(responseData);
                }
                return HediyeKartIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPagedList<HediyeKartIcerikVM>> HediyeKartAramaIcerikListGetir(HediyeKartIcerikAramaVM hediyeKartIcerik)
        {
            IPagedList<HediyeKartIcerikVM> HediyeKartIcerikVMList = new List<HediyeKartIcerikVM>().ToPagedList();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HediyeKartAramaIcerikListGetir", hediyeKartIcerik);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<HediyeKartIcerikVM>>(responseData);
                    StaticPagedList<HediyeKartIcerikVM> result = new StaticPagedList<HediyeKartIcerikVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return HediyeKartIcerikVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Ilgi Alan

        public async Task<int> IlgiAlanKaydet(IlgiAlanVM ilgiAlanVM)
        {
            int sonuc = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("IlgiAlanKaydet", ilgiAlanVM);
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

        public async Task<IlgiAlanVM> IlgiAlanGetirById(int id)
        {
            try
            {
                IlgiAlanVM model = new IlgiAlanVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("IlgiAlanGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<IlgiAlanVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<IlgiAlanAramaResultVM>> IlgiAlanArama(IlgiAlanAramaVM ilgiAlanAramaVM)
        {
            List<IlgiAlanAramaResultVM> IlgiAlanAramaResultVM = new List<IlgiAlanAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("IlgiAlanArama", ilgiAlanAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    IlgiAlanAramaResultVM = JsonConvert.DeserializeObject<List<IlgiAlanAramaResultVM>>(responseData);
                }
                return IlgiAlanAramaResultVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> IlgiAlanSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("IlgiAlanSil/?id=" + id.ToString());
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

        #region Hobi

        public async Task<int> HobiKaydet(HobiVM hobiVM)
        {
            int sonuc = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HobiKaydet", hobiVM);
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

        public async Task<HobiVM> HobiGetirById(int id)
        {
            try
            {
                HobiVM model = new HobiVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HobiGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<HobiVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<HobiAramaResultVM>> HobiArama(HobiAramaVM hobiAramaVM)
        {
            List<HobiAramaResultVM> HobiAramaResultVM = new List<HobiAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HobiArama", hobiAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    HobiAramaResultVM = JsonConvert.DeserializeObject<List<HobiAramaResultVM>>(responseData);
                }
                return HobiAramaResultVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> HobiSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HobiSil/?id=" + id.ToString());
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

        #region DuvarResim

        #region Admin

        public async Task<int> DuvarResimKaydet(DuvarResimKayitVM model)
        {
            int response = -1;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("DuvarResimKaydet", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<int>(responseData);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DuvarResimSil(int id)
        {
            bool response = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("DuvarResimSil/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<bool>(responseData);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DuvarResimKayitVM> DuvarResimKayitVMGetir(int id)
        {
            DuvarResimKayitVM response = new DuvarResimKayitVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("DuvarResimKayitVMGetir/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<DuvarResimKayitVM>(responseData);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DuvarResimAramaSonucVM>> DuvarResimAramaSonucVMGetir(DuvarResimAramaVM model)
        {
            List<DuvarResimAramaSonucVM> response = new List<DuvarResimAramaSonucVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("DuvarResimAramaSonucVMGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<List<DuvarResimAramaSonucVM>>(responseData);
                }
                return response;
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

        #region Hediye Karti Kategori

        #region Admin

        public async Task<HediyeKartKategoriVM> HediyeKartKategoriGetirById(int id)
        {
            try
            {
                HediyeKartKategoriVM model = new HediyeKartKategoriVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HediyeKartKategoriGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<HediyeKartKategoriVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> HediyeKartKategoriKaydet(HediyeKartKategoriVM hediyeKartKategoriVM)
        {
            int sonuc = 0;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HediyeKartKategoriKaydet", hediyeKartKategoriVM);
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

        public async Task<List<HediyeKartKategoriAramaResultVM>> HediyeKartKategoriArama(HediyeKartKategoriAramaVM hediyeKartKategoriVM)
        {
            List<HediyeKartKategoriAramaResultVM> HediyeKartKategoriAramaResultM = new List<HediyeKartKategoriAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HediyeKartKategoriArama", hediyeKartKategoriVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    HediyeKartKategoriAramaResultM = JsonConvert.DeserializeObject<List<HediyeKartKategoriAramaResultVM>>(responseData);
                }
                return HediyeKartKategoriAramaResultM;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> HediyeKartKategoriSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HediyeKartKategoriSil/?id=" + id.ToString());
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

        public async Task<List<HediyeKartKategoriVM>> HediyeKartKategoriTipleriniGetir()
        {
            List<HediyeKartKategoriVM> hediyeKartKategoriVMsResult = new List<HediyeKartKategoriVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HediyeKartKategoriTipleriniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    hediyeKartKategoriVMsResult = JsonConvert.DeserializeObject<List<HediyeKartKategoriVM>>(responseData);
                }
                return hediyeKartKategoriVMsResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #endregion

        #region İndirim Kuponu 

        #region Admin
        public async Task<IndirimKuponuKayitVM> IndirimKuponuGetirById(int id)
        {
            try
            {
                IndirimKuponuKayitVM model = new IndirimKuponuKayitVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("IndirimKuponuGetirById/?id=" + id.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<IndirimKuponuKayitVM>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> IndirimKuponuKaydet(IndirimKuponuKayitVM model)
        {
            int result = -1;

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("IndirimKuponuKaydet", model);
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
        public async Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuArama(IndirimKuponuAramaVM indirimKuponuAramaVM)
        {
            List<IndirimKuponuAramaResultVM> indirimList = new List<IndirimKuponuAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("IndirimKuponuArama", indirimKuponuAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    indirimList = JsonConvert.DeserializeObject<List<IndirimKuponuAramaResultVM>>(responseData);
                }
                return indirimList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> IndirimKuponuSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("IndirimKuponuSil/?id=" + id.ToString());
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

        #region FrontEnd
        public async Task<List<IndirimKuponuAramaResultVM>> IndirimKuponuGetir(IndirimKuponuAramaVM indirimKuponuAramaVM)
        {
            List<IndirimKuponuAramaResultVM> indirimList = new List<IndirimKuponuAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("IndirimKuponuGetir", indirimKuponuAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    indirimList = JsonConvert.DeserializeObject<List<IndirimKuponuAramaResultVM>>(responseData);
                }
                return indirimList;
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
