using Microsoft.Extensions.Options;
using NeSever.Common.Models;
using NeSever.Common.Models.Admin.AramaSonucVM;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Urun;
using NeSever.Common.Models.Uyelik;
using NeSever.Common.Utils.Security;
using NeSever.Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using X.PagedList;

namespace NeSever.WebUI.Services
{
    public interface IUyelikApiService
    {
        #region ProfilEngel

        #region Admin

        #endregion

        #region FrontEnd

        Task<ProfilEngelVM> ProfilEngelKaydet(ProfilEngelVM model);
        Task<ProfilEngelVM> ProfilEngelSil(ProfilEngelVM model);
        Task<IPagedList<ProfilEngelKisiVM>> ProfilEngelListGetir(EngellenenProfilListesiAramaVM model);

        #endregion

        #endregion

        #region ProfilSikayet

        #region Admin
        Task<List<ProfilSikayetAramaSonucVM>> ProfilSikayetArama(ProfilSikayetAramaVM model);
        #endregion

        #region FrontEnd
        Task<bool> ProfilSikayetKaydet(ProfilSikayetVM model);
        #endregion

        #endregion

        #region Kullanici
        Task<ResultModel<TokenVM>> KullaniciKaydet(KullaniciKayitVM kullanici);
        Task<TokenVM> KullaniciGiris(KullaniciGirisVM kullanici);
        Task<ResultModel<TokenVM>> KullaniciFbGiris(KullaniciFbGirisVM kullanici);
        Task<ResultModel<TokenVM>> KullaniciInstegramGiris(KullaniciInstegramGirisVM kullanici);
        Task<ResultModel<TokenVM>> KullaniciGoogleGiris(KullaniciGoogleGirisVM kullanici);
        Task<KullaniciVM> KullaniciGetir(TokenVM token);
        Task<ServiceResponse> KullaniciCikis(TokenVM token);
        Task<KullaniciKisiselBilgiVM> KullaniciKisiselBilgileriGetir(TokenVM token);
        Task<List<KullaniciSehirVM>> SehirleriGetir();
        Task<ResultModel> KullaniciKisiselBilgiKaydetGuncelle(KullaniciKisiselBilgiKaydetGuncelleVM kullaniciKisiselBilgi);
        Task<ResultModel> SifreKaydetGuncelle(SifreDegistirVM vm);
        Task<ResultModel<AyarlarVM>> KullaniciHesapAyarlariniGetir(TokenVM token);
        Task<ResultModel> AyarlarKaydetGuncelle(AyarlarVM vm);
        ResultModel<TokenVM> KullaniciTokenYenile(KullaniciTokenYenileSilVM vm);
        Task<ProfilSagMenuVM> ProfilSagMenuGetir(ProfilSagMenuAraVM model);

        Task<bool> KullaniciArkadasKullaniciMi(Guid kullaniciId, Guid kullaniciArkadasId);
        Task<bool> KullaniciArkadasiminArkadasiMi(Guid kullaniciId, Guid kullaniciArkadasId);
        Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiModalGetir(KullaniciArkadasListesiModalAramaVM model);
        Task<int> KullaniciProfilGoruntulenmeSayisiGetir(Guid kullaniciId);
        Task<bool> KullaniciBakilanProfilEkle(KullaniciBakilanProfillerVM bakilanProfil);
        Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciBakilanProfilleriGetir(KullaniciArkadasListesiModalAramaVM model);

        Task<ServiceResponse> KullaniciSil(KullaniciSilVM vm);

        Task<bool> BakilanProfilSil(BakilanProfilSilVM vm);
        Task<bool> BakilanTumProfilleriSil(KullaniciVM vm);
        Task<ResultModel<KullaniciAdiVM>> KullaniciAdiGuncelle(KullaniciAdiVM kullanici);
        Task<KullaniciVM> KullaniciGetirByKullaniciId(Guid kullaniciId);

        Task<List<BildirimKullaniciGetirVM>> BildirimKullaniciListGetir(KisiyeOzelBildirimVM data);

        #endregion

        #region Arkadas
        Task<ResultModel<KullaniciArkadasVM>> ArkadasListesiGetir(ArkadasListesiGetirVM vm);
        Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> ArkadasListesiGetir(ArkadasListeAramaVM arkadasListeAramaVM);
        Task<ResultModel<ArkadaslarMenuVM>> ArkadasMenuDegerleriGetir(TokenVM vm);
        Task<ResultModel<List<ArkadasIstekleriVM>>> ArkadasIstekleriniGetir(TokenVM vm);
        Task<ResultModel<ArkadaslikIstekKabulSonucVM>> ArkadaslikIsteginiKabulEt(ArkadaslikIsteginiKabulEtVM vm);
        Task<ResultModel> ArkadaslikIsteginiReddet(ArkadaslikIsteginiSilVM vm);
        Task<IPagedList<ArkadasVM>> ArkadasAra(ArkadasAramaVM arkadasAramaVM);
        //TODO ŞG: Üst menü arama alanı için kullanılacak.
        //Task<ResultModel<List<HizliArkadasAraSonucVM>>> HizliArkadasAra(HizliArkadasAraVM vm);
        Task<ResultModel<List<ArkadasAraSonucVM>>> ArkadasAra(ArkadasAraVM vm);
        Task<ResultModel<List<ArkadasAraSonucVM>>> ArkadasArama(ArkadasAraVM vm);
        Task<ResultModel> ArkadaslikIstekGonder(ArkadaslikIstegiGonderVM vm);
        Task<ResultModel> ArkadaslikIstekGonderildiMi(ArkadaslikIstegiGonderVM vm);
        Task<ResultModel> ArkadaslikIstekBanaGonderildiMi(ArkadaslikIstegiGonderVM vm);
        Task<ResultModel<ProfilVM>> ArkadasProfilGetir(ArkadasProfilGetirVM vm);
        Task<ResultModel> MesajGonder(MesajGonderVM vm);
        Task<ResultModel> ArkadasSil(ArkadasSilVM vm);
        Task<IPagedList<ArkadasKonusmaListesiVM>> ArkadaslarMesajlarListesi(ArkadasMesajListeVM mesajListesiVM);
        Task<ResultModel<List<MesajDetaySonucVM>>> MesajDetayGetir(MesajDetayGetirVM vm);
        Task<ResultModel> KonusmaSil(KonusmaSilVM vm);
        Task<ResultModel> MesajSil(MesajSilVM vm);

        Task<ResultModel> ArkadasIstekleriniOku(TokenVM vm);
        Task<ResultModel> ProfilArkadasEkle(ArkadaslikIstegiGonderVM vm);
        #endregion

        #region KullaniciHobi

        #region Admin       
        Task<List<KullaniciHobiVM>> HobileriGetir(HobileriGetirVM vm);
        Task<KullaniciHobiVeIlgiAlanVM> KullaniciHobiIlgiAlanGetir(Guid kullaniciId);
        Task<bool> KullaniciHobiKaydetGuncelle(KullaniciHobiKaydetGuncelleVM model);
        #endregion

        #region FrontEnd

        #endregion

        #endregion

        #region KullaniciIlgiAlan

        #region Admin       

        #endregion

        #region FrontEnd
        Task<List<KullaniciIlgiAlanVM>> IlgiAlanlariniGetir(IlgiAlanGetirVM vm);
        Task<bool> KullaniciIlgiAlanKaydetGuncelle(KullaniciIlgiAlanKaydetGuncelleVM model);

        #endregion

        #endregion

        #region KullaniciUrun

        #region Admin       

        #endregion

        #region FrontEnd

        Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeEkle(KullaniciUrunEkleSilVM model);
        Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeSil(KullaniciUrunEkleSilVM model);
        Task<IPagedList<UrunIcerikVM>> KullaniciHediyeSepetiGetir(KullaniciUrunListesiAramaVM model);
        Task<int> KullaniciHediyeSepetiSayisiGetir(Guid kullaniciId);

        #endregion

        #endregion

        #region KullaniciResim
        Task<KullaniciResimVM> KullaniciProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResimVM);
        Task<KullaniciResimVM> KullaniciResimKaydet(KullaniciResimVM kullaniciResimVM);

        Task<KullaniciResimVM> KullaniciResimGetir(Guid kullaniciId);

        Task<List<KullaniciResimVM>> KullaniciResimListele(string kullaniciId);

        Task<int> ProfilResminiDegistir(Guid kullaniciId, int resimId);

        Task<int> KullaniciResimSil(Guid kullaniciId, int resimId);

        Task<IPagedList<KullaniciResimVM>> KullaniciResimListesiGetir(int start, int length, Guid KullaniciId);

        Task<KullaniciResimVM> KullaniciResimGetirByResimId(int resimId);
        Task<KullaniciResim> KullaniciProfilResmiSil(KullaniciResim kullaniciResim);
        Task<KullaniciResim> KullaniciProfilResimGetir(string kullaniciId);
        Task<int> KullaniciResimSayisiGetir(Guid kullaniciId);
        Task<KullaniciResimVM> KullaniciBuyukProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResimVM);
        Task<KullaniciResimVM> KullaniciBuyukProfilResimGetir(Guid KullaniciId);

        #endregion

        #region DuvarResim
        Task<List<DuvarResimVM>> DuvarResimleriniGetir();

        Task<int> KullaniciDuvarResimDegistir(Guid kullaniciId, int resimId);

        Task<DuvarResimVM> KullaniciDuvarResimGetir(Guid kullaniciId);
        #endregion

        #region KullaniciHediyeKart
        Task<List<KullaniciVM>> KisiAra(KisiAraVM vm);
        Task<KullaniciVM> KullaniciGetirByKullaniciAdi(string kullaniciAdi);
        Task<ResultModel> KullaniciHediyeKartKayit(KullaniciHediyeKartKayitVM model);

        Task<IPagedList<HediyeKartKonusmaListesiVM>> KullaniciHediyeKartListesiGetir(HediyeKartListeVM hediyeKartListeVM);
        Task<ResultModel<List<HediyeKartDetaySonucVM>>> HediyeKartDetayGetir(HediyeKartDetayGetirVM vm);
        Task<ResultModel> HediyeKartKonusmaSil(KonusmaSilVM vm);

        Task<ResultModel> HediyeKartSil(HediyeKartSilVM vm);

        Task<HediyeKartIcerikVM> HediyeKartIcerikGetir(int id);
        Task<int> HediyeKartOkunduIsaretle(HediyeKartOkunduVM hediyeKartOkundu);
        #endregion

        #region KullaniciBildirim
        Task<IPagedList<KullaniciBildirimVM>> KullaniciBildirimListGetir(KullaniciBildirimListeVM model);
        Task<bool> KullaniciBildirimEkle(KullaniciBildirimVM kullaniciBildirim);
        Task<bool> KullaniciBildirimSil(KullaniciBildirimVM kullaniciBildirim);
        Task<List<KullaniciBildirimVM>> KullaniciHeaderBildirimListGetir(Guid KullaniciId);
        Task<bool> KullaniciBildirimOkundu(Guid kullaniciId);
        Task<int> TopluBildirimGonder(IletisimTopluBildirimVM bildirim);
        Task<List<BildirimAramaResultVM>> TumBildirimleriGetir(BildirimAramaVM bildirimAramaVM);
        Task<int> BildirimSil(int id);
        Task<bool> KullaniciTumBildirimleriSil(Guid kullaniciId);
        Task<int> BildirimSayisiGetir(IletisimTopluBildirimVM bildirim);
        Task<int> KisiyeOzelBildirimGonder(KisiyeOzelBildirimVM bildirim);
        Task<KullaniciBildirimVM> BildirimIdBildirimGetir(int id);
        Task<List<KisiyeOzelBildirimAramaSonucVM>> KisiyeOzelBildirimleriGetir(BildirimAramaVM bildirimAramaVM);
        Task<int> KullaniciHeaderSepetUrunSayisiGetir(Guid kullaniciId);


        #endregion

        #region Sifremi Unuttum
        Task<ResultModel> KullaniciYeniSifreGonder(KullaniciSifreGonderVM model);
        #endregion


        #region Kullanıcı Mesaj
        Task<ResultModel> MesajlariOku(MesajDetayGetirVM vm);
        
        #endregion
    }

    public class UyelikApiService : IUyelikApiService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<NeSeverSettings> _appSettings;
        public UyelikApiService(HttpClient httpClient, IOptions<NeSeverSettings> appSettings)
        {
            _appSettings = appSettings;
            httpClient.BaseAddress = new Uri(_appSettings.Value.ApiAdress + "/api/Uyelik/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            this.httpClient = httpClient;
        }

        #region ProfilEngel

        #region Admin

        #endregion

        #region FrontEnd

        public async Task<ProfilEngelVM> ProfilEngelKaydet(ProfilEngelVM model)
        {
            ProfilEngelVM result = new ProfilEngelVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ProfilEngelKaydet", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ProfilEngelVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ProfilEngelVM> ProfilEngelSil(ProfilEngelVM model)
        {
            ProfilEngelVM result = new ProfilEngelVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ProfilEngelSil", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ProfilEngelVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPagedList<ProfilEngelKisiVM>> ProfilEngelListGetir(EngellenenProfilListesiAramaVM model)
        {
            IPagedList<ProfilEngelKisiVM> result = new List<ProfilEngelKisiVM>().ToPagedList();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ProfilEngelListGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<ProfilEngelKisiVM>>(responseData);
                    result = new StaticPagedList<ProfilEngelKisiVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
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

        #region ProfilSikayet

        #region Admin
        public async Task<List<ProfilSikayetAramaSonucVM>> ProfilSikayetArama(ProfilSikayetAramaVM model)
        {
            List<ProfilSikayetAramaSonucVM> result = new List<ProfilSikayetAramaSonucVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ProfilSikayetArama", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<ProfilSikayetAramaSonucVM>>(responseData);
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
        public async Task<bool> ProfilSikayetKaydet(ProfilSikayetVM model)
        {
            bool result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ProfilSikayetKaydet", model);
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

        #region Kullanici
        public async Task<ResultModel<TokenVM>> KullaniciKaydet(KullaniciKayitVM kullanici)
        {
            ResultModel<TokenVM> kullaniciKaydetResult = new ResultModel<TokenVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciKaydet", kullanici);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciKaydetResult = JsonConvert.DeserializeObject<ResultModel<TokenVM>>(responseData);
                }
                return kullaniciKaydetResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TokenVM> KullaniciGiris(KullaniciGirisVM kullanici)
        {
            TokenVM kullaniciGirisResult = new TokenVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciGirisYap", kullanici);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciGirisResult = JObject.Parse(responseData)["Result"].ToObject<TokenVM>();
                }
                return kullaniciGirisResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<TokenVM>> KullaniciFbGiris(KullaniciFbGirisVM kullanici)
        {
            ResultModel<TokenVM> kullaniciFbGirisResult = new ResultModel<TokenVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciFbGirisYap", kullanici);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciFbGirisResult = JsonConvert.DeserializeObject<ResultModel<TokenVM>>(responseData);
                }
                return kullaniciFbGirisResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<TokenVM>> KullaniciGoogleGiris(KullaniciGoogleGirisVM kullanici)
        {
            ResultModel<TokenVM> kullaniciGoogleGirisResult = new ResultModel<TokenVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciGoogleGirisYap", kullanici);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciGoogleGirisResult = JsonConvert.DeserializeObject<ResultModel<TokenVM>>(responseData);
                }
                return kullaniciGoogleGirisResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<TokenVM>> KullaniciInstegramGiris(KullaniciInstegramGirisVM kullanici)
        {
            ResultModel<TokenVM> kullaniciInstegramGirisResult = new ResultModel<TokenVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciInstegramGirisYap", kullanici);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciInstegramGirisResult = JsonConvert.DeserializeObject<ResultModel<TokenVM>>(responseData);
                }
                return kullaniciInstegramGirisResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<KullaniciVM> KullaniciGetir(TokenVM token)
        {
            KullaniciVM kullaniciGirisResult = new KullaniciVM();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciGetir", token.RefreshToken);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciGirisResult = JObject.Parse(responseData)["Result"].ToObject<KullaniciVM>();
                }
                return kullaniciGirisResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceResponse> KullaniciCikis(TokenVM token)
        {
            ServiceResponse kullaniciCikisResult = new ServiceResponse();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciCikis", token.RefreshToken);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciCikisResult = JObject.Parse(responseData).ToObject<ServiceResponse>();
                }
                return kullaniciCikisResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<KullaniciKisiselBilgiVM> KullaniciKisiselBilgileriGetir(TokenVM token)
        {
            KullaniciKisiselBilgiVM kullaniciKisiselBilgiSonuc = new KullaniciKisiselBilgiVM();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciKisiselBilgileriGetir", token.RefreshToken);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciKisiselBilgiSonuc = JObject.Parse(responseData)["Result"].ToObject<KullaniciKisiselBilgiVM>();
                }
                return kullaniciKisiselBilgiSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> KullaniciKisiselBilgiKaydetGuncelle(KullaniciKisiselBilgiKaydetGuncelleVM kullaniciKisiselBilgi)
        {
            ResultModel kullaniciKisiselBilgiSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", kullaniciKisiselBilgi.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciKisiselBilgiKaydetGuncelle", kullaniciKisiselBilgi);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciKisiselBilgiSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData);
                }
                return kullaniciKisiselBilgiSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<KullaniciSehirVM>> SehirleriGetir()
        {
            List<KullaniciSehirVM> sehirleriGetirSonuc = new List<KullaniciSehirVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsync("SehirleriGetir",null);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    sehirleriGetirSonuc = JsonConvert.DeserializeObject<List<KullaniciSehirVM>>(responseData);
                }
                return sehirleriGetirSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> SifreKaydetGuncelle(SifreDegistirVM vm)
        {
            ResultModel sifreKaydetGuncelleSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("SifreKaydetGuncelle", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    sifreKaydetGuncelleSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData);
                }
                return sifreKaydetGuncelleSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> AyarlarKaydetGuncelle(AyarlarVM vm)
        {
            ResultModel ayarlarKaydetGuncelleSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("AyarlarKaydetGuncelle", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    ayarlarKaydetGuncelleSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData);
                }
                return ayarlarKaydetGuncelleSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<AyarlarVM>> KullaniciHesapAyarlariniGetir(TokenVM token)
        {
            ResultModel<AyarlarVM> kullaniciAyarlarSonuc = new ResultModel<AyarlarVM>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciAyarlariniGetir", token.RefreshToken);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciAyarlarSonuc = JsonConvert.DeserializeObject<ResultModel<AyarlarVM>>(responseData); ;
                }
                return kullaniciAyarlarSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResultModel<TokenVM> KullaniciTokenYenile(KullaniciTokenYenileSilVM token)
        {
            var tokenYenilemeSonuc = new ResultModel<TokenVM>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            try
            {
                HttpResponseMessage responseMessage = httpClient.PostAsJsonAsync("KullaniciTokenYenile", token).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    tokenYenilemeSonuc = JsonConvert.DeserializeObject<ResultModel<TokenVM>>(responseData); ;
                }
                return tokenYenilemeSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProfilSagMenuVM> ProfilSagMenuGetir(ProfilSagMenuAraVM model)
        {
            ProfilSagMenuVM result = new ProfilSagMenuVM();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ProfilSagMenuGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ProfilSagMenuVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> KullaniciArkadasKullaniciMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            bool result=false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciArkadasKullaniciMi?kullaniciId=" + kullaniciId+ "&&kullaniciArkadasId="+kullaniciArkadasId);
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
        public async Task<bool> KullaniciArkadasiminArkadasiMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            bool result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciArkadasiminArkadasiMi?kullaniciId=" + kullaniciId + "&&kullaniciArkadasId=" + kullaniciArkadasId);
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

        public async Task<bool> KullaniciBakilanProfilEkle(KullaniciBakilanProfillerVM bakilanProfil)
        {
            bool result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciBakilanProfilEkle", bakilanProfil);
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

        public async Task<ServiceResponse> KullaniciSil(KullaniciSilVM vm)
        {
            ServiceResponse kullaniciSilSonuc = new ServiceResponse();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciSil",vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciSilSonuc = JsonConvert.DeserializeObject<ServiceResponse>(responseData); ;
                }
                return kullaniciSilSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> BakilanProfilSil(BakilanProfilSilVM vm)
        {
            bool result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BakilanProfilSil", vm);
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
        public async Task<bool> BakilanTumProfilleriSil(KullaniciVM vm)
        {
            bool result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BakilanTumProfilleriSil", vm);
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

        public async Task<ResultModel<KullaniciAdiVM>> KullaniciAdiGuncelle(KullaniciAdiVM kullanici)
        {
            ResultModel<KullaniciAdiVM> kullaniciResult = new ResultModel<KullaniciAdiVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciAdiGuncelle", kullanici);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciResult = JsonConvert.DeserializeObject<ResultModel<KullaniciAdiVM>>(responseData);
                }
                return kullaniciResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<KullaniciVM> KullaniciGetirByKullaniciId(Guid kullaniciId)
        {
            KullaniciVM kullaniciSonuc = new KullaniciVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciGetirByKullaniciId/?kullaniciId=" + kullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciSonuc = JsonConvert.DeserializeObject<KullaniciVM>(responseData); ;
                }
                return kullaniciSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BildirimKullaniciGetirVM>> BildirimKullaniciListGetir(KisiyeOzelBildirimVM data)
        {
            try
            {
                List<BildirimKullaniciGetirVM> model = new List<BildirimKullaniciGetirVM>();

                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BildirimKullaniciListGetir", data);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BildirimKullaniciGetirVM>>(responseData);

                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Arkadas
        public async Task<ResultModel<KullaniciArkadasVM>> ArkadasListesiGetir(ArkadasListesiGetirVM vm)
        {
            ResultModel<KullaniciArkadasVM> kullaniciArkadasListesiSonuc = new ResultModel<KullaniciArkadasVM>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciArkadasListesiGetirDogumGunleriIcin", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciArkadasListesiSonuc = JsonConvert.DeserializeObject<ResultModel<KullaniciArkadasVM>>(responseData); ;
                }
                return kullaniciArkadasListesiSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> ArkadasListesiGetir(ArkadasListeAramaVM arkadasListeAramaVM)
        {
            IPagedList<ArkadasListesiKullaniciArkadasVM> arkadasVMList = new List<ArkadasListesiKullaniciArkadasVM>().ToPagedList();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", arkadasListeAramaVM.Token.Token);

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciArkadasListesiGetir", arkadasListeAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<ArkadasListesiKullaniciArkadasVM>>(responseData);
                    StaticPagedList<ArkadasListesiKullaniciArkadasVM> result = new StaticPagedList<ArkadasListesiKullaniciArkadasVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return arkadasVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<ArkadaslarMenuVM>> ArkadasMenuDegerleriGetir(TokenVM vm)
        {
            ResultModel<ArkadaslarMenuVM> arkadadaslarMenuSonuc = new ResultModel<ArkadaslarMenuVM>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadasMenuDegerleriGetir", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadadaslarMenuSonuc = JsonConvert.DeserializeObject<ResultModel<ArkadaslarMenuVM>>(responseData); ;
                }
                return arkadadaslarMenuSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<List<ArkadasIstekleriVM>>> ArkadasIstekleriniGetir(TokenVM vm)
        {
            ResultModel<List<ArkadasIstekleriVM>> arkadadasIstekleriSonuc = new ResultModel<List<ArkadasIstekleriVM>>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadasIstekleriniGetir", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadadasIstekleriSonuc = JsonConvert.DeserializeObject<ResultModel<List<ArkadasIstekleriVM>>>(responseData); ;
                }
                return arkadadasIstekleriSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResultModel> ArkadasIstekleriniOku(TokenVM vm)
        {
            ResultModel istekleriOkuSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadasIstekleriniOku", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    istekleriOkuSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return istekleriOkuSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResultModel<ArkadaslikIstekKabulSonucVM>> ArkadaslikIsteginiKabulEt(ArkadaslikIsteginiKabulEtVM vm)
        {
            ResultModel<ArkadaslikIstekKabulSonucVM> arkadadaslikIsteginiKabulEtSonuc = new ResultModel<ArkadaslikIstekKabulSonucVM>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadaslikIsteginiKabulEt", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadadaslikIsteginiKabulEtSonuc = JsonConvert.DeserializeObject<ResultModel<ArkadaslikIstekKabulSonucVM>>(responseData); ;
                }
                return arkadadaslikIsteginiKabulEtSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> ArkadaslikIsteginiReddet(ArkadaslikIsteginiSilVM vm)
        {
            ResultModel arkadadaslikIsteginiSilSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadaslikIsteginiReddet", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadadaslikIsteginiSilSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return arkadadaslikIsteginiSilSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPagedList<ArkadasVM>> ArkadasAra(ArkadasAramaVM arkadasAramaVM)
        {
            IPagedList<ArkadasVM> arkadasVMList = new List<ArkadasVM>().ToPagedList();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", arkadasAramaVM.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadasAramaListGetir", arkadasAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<ArkadasVM>>(responseData);
                    StaticPagedList<ArkadasVM> result = new StaticPagedList<ArkadasVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return arkadasVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<List<ArkadasAraSonucVM>>> ArkadasAra(ArkadasAraVM vm)
        {
            ResultModel<List<ArkadasAraSonucVM>> result = new ResultModel<List<ArkadasAraSonucVM>>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadasAra", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ResultModel<List<ArkadasAraSonucVM>>>(responseData); ;

                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<List<ArkadasAraSonucVM>>> ArkadasArama(ArkadasAraVM vm)
        {
            ResultModel<List<ArkadasAraSonucVM>> result = new ResultModel<List<ArkadasAraSonucVM>>();
            
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadasArama", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ResultModel<List<ArkadasAraSonucVM>>>(responseData); ;

                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //TODO ŞG: Üst menü arama alanı için kullanılacak.
        //public async Task<ResultModel<List<HizliArkadasAraSonucVM>>> HizliArkadasAra(HizliArkadasAraVM vm)
        //{
        //    ResultModel<List<HizliArkadasAraSonucVM>> result = new ResultModel<List<HizliArkadasAraSonucVM>>();

        //    try
        //    {
        //        HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HizliArkadasAra", vm);
        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            var responseData = await responseMessage.Content.ReadAsStringAsync();
        //            result = JsonConvert.DeserializeObject<ResultModel<List<HizliArkadasAraSonucVM>>>(responseData); ;

        //            return result;
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<ResultModel> ArkadaslikIstekGonder(ArkadaslikIstegiGonderVM vm)
        {
            ResultModel arkadaslikIstekGonderSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadaslikIstekGonder", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadaslikIstekGonderSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return arkadaslikIstekGonderSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> ArkadaslikIstekGonderildiMi(ArkadaslikIstegiGonderVM vm)
        {
            ResultModel arkadaslikIstekGonderSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadaslikIstekGonderildiMi", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadaslikIstekGonderSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return arkadaslikIstekGonderSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> ArkadaslikIstekBanaGonderildiMi(ArkadaslikIstegiGonderVM vm)
        {
            ResultModel arkadaslikIstekGonderSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadaslikIstekBanaGonderildiMi", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadaslikIstekGonderSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return arkadaslikIstekGonderSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<ProfilVM>> ArkadasProfilGetir(ArkadasProfilGetirVM vm)
        {
            ResultModel<ProfilVM> arkadasProfilSonuc = new ResultModel<ProfilVM>();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadasProfilGetir", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadasProfilSonuc = JsonConvert.DeserializeObject<ResultModel<ProfilVM>>(responseData);
                }
                return arkadasProfilSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> MesajGonder(MesajGonderVM vm)
        {
            ResultModel arkadaslikIstekGonderSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadasMesajGonder", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadaslikIstekGonderSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return arkadaslikIstekGonderSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> ArkadasSil(ArkadasSilVM vm)
        {
            ResultModel arkadasSilSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ArkadasSil", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadasSilSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return arkadasSilSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IPagedList<ArkadasKonusmaListesiVM>> ArkadaslarMesajlarListesi(ArkadasMesajListeVM mesajListesiVM)
        {

            IPagedList<ArkadasKonusmaListesiVM> mesajVMList = new List<ArkadasKonusmaListesiVM>().ToPagedList();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", mesajListesiVM.Token.Token);

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciArkadasMesajListesiGetir", mesajListesiVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<ArkadasKonusmaListesiVM>>(responseData);
                    StaticPagedList<ArkadasKonusmaListesiVM> result = new StaticPagedList<ArkadasKonusmaListesiVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return mesajVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel<List<MesajDetaySonucVM>>> MesajDetayGetir(MesajDetayGetirVM vm)
        {
            var mesajDetayGetirSonuc = new ResultModel<List<MesajDetaySonucVM>>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("MesajDetayGetir", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    mesajDetayGetirSonuc = JsonConvert.DeserializeObject<ResultModel<List<MesajDetaySonucVM>>>(responseData); ;
                }
                return mesajDetayGetirSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public async Task<ResultModel> KonusmaSil(KonusmaSilVM vm)
        {
            ResultModel mesajSilSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KonusmaSil", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    mesajSilSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return mesajSilSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> MesajSil(MesajSilVM vm)
        {
            ResultModel mesajSilSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("MesajSil", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    mesajSilSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return mesajSilSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> ProfilArkadasEkle(ArkadaslikIstegiGonderVM vm)
        {
            ResultModel arkadaslikIstekGonderSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("ProfilArkadasEkle", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    arkadaslikIstekGonderSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return arkadaslikIstekGonderSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region KullaniciHobi

        #region Admin       

        #endregion

        #region FrontEnd
        public async Task<List<KullaniciHobiVM>> HobileriGetir(HobileriGetirVM vm)
        {
            List<KullaniciHobiVM> hobileriGetirSonuc = new List<KullaniciHobiVM>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HobileriGetir", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    hobileriGetirSonuc = JsonConvert.DeserializeObject<List<KullaniciHobiVM>>(responseData);
                }
                return hobileriGetirSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<KullaniciHobiVeIlgiAlanVM> KullaniciHobiIlgiAlanGetir(Guid kullaniciId)
        {
            KullaniciHobiVeIlgiAlanVM result = new KullaniciHobiVeIlgiAlanVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciHobiIlgiAlanGetir/?KullaniciId=" + kullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<KullaniciHobiVeIlgiAlanVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> KullaniciHobiKaydetGuncelle(KullaniciHobiKaydetGuncelleVM model)
        {
            bool result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciHobiKaydetGuncelle", model);
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

        public async Task<bool> KullaniciIlgiAlanKaydetGuncelle(KullaniciIlgiAlanKaydetGuncelleVM model)
        {
            bool result = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciIlgiAlanKaydetGuncelle", model);
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

        #region KullaniciIlgiAlan

        #region Admin       

        #endregion

        #region FrontEnd
        public async Task<List<KullaniciIlgiAlanVM>> IlgiAlanlariniGetir(IlgiAlanGetirVM vm)
        {
            List<KullaniciIlgiAlanVM> ilgiAlanlariGetirSonuc = new List<KullaniciIlgiAlanVM>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("IlgiAlanlariniGetir", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    ilgiAlanlariGetirSonuc = JsonConvert.DeserializeObject<List<KullaniciIlgiAlanVM>>(responseData);
                }
                return ilgiAlanlariGetirSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region KullaniciUrun

        #region Admin       

        #endregion

        #region FrontEnd

        public async Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeEkle(KullaniciUrunEkleSilVM model)
        {
            KullaniciUrunEkleSilSonucVM kullaniciArkadasListesiSonuc = new KullaniciUrunEkleSilSonucVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciHediyeEkle", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciArkadasListesiSonuc = JsonConvert.DeserializeObject<KullaniciUrunEkleSilSonucVM>(responseData); ;
                }
                return kullaniciArkadasListesiSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeSil(KullaniciUrunEkleSilVM model)
        {
            KullaniciUrunEkleSilSonucVM kullaniciArkadasListesiSonuc = new KullaniciUrunEkleSilSonucVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciHediyeSil", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciArkadasListesiSonuc = JsonConvert.DeserializeObject<KullaniciUrunEkleSilSonucVM>(responseData); ;
                }
                return kullaniciArkadasListesiSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPagedList<UrunIcerikVM>> KullaniciHediyeSepetiGetir(KullaniciUrunListesiAramaVM model)
        {
            IPagedList<UrunIcerikVM> UrunIcerikVMList = new List<UrunIcerikVM>().ToPagedList();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciHediyeSepetiGetir", model);
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

        public async Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiModalGetir(KullaniciArkadasListesiModalAramaVM model)
        {
            IPagedList<ArkadasListesiKullaniciArkadasVM> ArkadasListesiVMList = new List<ArkadasListesiKullaniciArkadasVM>().ToPagedList();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciArkadasListesiModalGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<ArkadasListesiKullaniciArkadasVM>>(responseData);
                    StaticPagedList<ArkadasListesiKullaniciArkadasVM> result = new StaticPagedList<ArkadasListesiKullaniciArkadasVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return ArkadasListesiVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> KullaniciHediyeSepetiSayisiGetir(Guid kullaniciId)
        {
            int result = 0;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciHediyeSepetiSayisiGetir/?KullaniciId=" + kullaniciId.ToString());
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

        public async Task<int> KullaniciProfilGoruntulenmeSayisiGetir(Guid kullaniciId)
        {
            int result = 0;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciProfilGoruntulenmeSayisiGetir?kullaniciId=" + kullaniciId);
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

        public async Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciBakilanProfilleriGetir(KullaniciArkadasListesiModalAramaVM model)
        {
            IPagedList<ArkadasListesiKullaniciArkadasVM> ArkadasListesiVMList = new List<ArkadasListesiKullaniciArkadasVM>().ToPagedList();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciBakilanProfilleriGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<ArkadasListesiKullaniciArkadasVM>>(responseData);
                    StaticPagedList<ArkadasListesiKullaniciArkadasVM> result = new StaticPagedList<ArkadasListesiKullaniciArkadasVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return ArkadasListesiVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region KullaniciResim

        public async Task<KullaniciResim> KullaniciProfilResmiSil(KullaniciResim kullaniciResim)
        {
            KullaniciResim KullaniciResimVMResult = new KullaniciResim();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciProfilResmiSil", kullaniciResim);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    KullaniciResimVMResult = JsonConvert.DeserializeObject<KullaniciResim>(responseData);
                }
                return KullaniciResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<KullaniciResimVM> KullaniciResimGetir(Guid kullaniciId)
        {
            KullaniciResimVM KullaniciResimVMResult = new KullaniciResimVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciResimGetir", kullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    KullaniciResimVMResult = JsonConvert.DeserializeObject<KullaniciResimVM>(responseData);
                }
                return KullaniciResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<KullaniciResimVM> KullaniciProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResimVM)
        {
            KullaniciResimVM kullaniciResimVMResult = new KullaniciResimVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciProfilResimKaydetGuncelle", kullaniciResimVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciResimVMResult = JsonConvert.DeserializeObject<KullaniciResimVM>(responseData);
                }
                return kullaniciResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<KullaniciResimVM> KullaniciResimKaydet(KullaniciResimVM kullaniciResimVM)
        {
            KullaniciResimVM kullaniciResimVMResult = new KullaniciResimVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciResimKaydet", kullaniciResimVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciResimVMResult = JsonConvert.DeserializeObject<KullaniciResimVM>(responseData);
                }
                return kullaniciResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<KullaniciResim> KullaniciProfilResimGetir(string kullaniciId)
        { KullaniciResim KullaniciResimVMResult = new KullaniciResim();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciProfilResimGetir?kullaniciId=" + kullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    KullaniciResimVMResult = JsonConvert.DeserializeObject<KullaniciResim>(responseData);
                }
                return KullaniciResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<KullaniciResimVM>> KullaniciResimListele(string kullaniciId)
        {
            List<KullaniciResimVM> KullaniciResimVMResult = new List<KullaniciResimVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciResimListele?kullaniciId=" + kullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    KullaniciResimVMResult = JsonConvert.DeserializeObject<List<KullaniciResimVM>>(responseData);
                }
                return KullaniciResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ProfilResminiDegistir(Guid kullaniciId, int resimId)
        {

            int result = 0;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("ProfilResminiDegistir/?kullaniciId=" + kullaniciId.ToString() + "&resimId=" + resimId.ToString());
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

        public async Task<int> KullaniciResimSil(Guid kullaniciId, int resimId)
        {

            int result = 0;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciResimSil/?kullaniciId=" + kullaniciId.ToString() + "&resimId=" + resimId.ToString());
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

        public async Task<IPagedList<KullaniciResimVM>> KullaniciResimListesiGetir(int start, int length, Guid kullaniciId)
        {
            IPagedList<KullaniciResimVM> KullaniciResimVMList = new List<KullaniciResimVM>().ToPagedList();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciResimListesiGetir/?start=" + start.ToString() + "&length=" + length.ToString() + "&kullaniciId=" + kullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<KullaniciResimVM>>(responseData);
                    StaticPagedList<KullaniciResimVM> result = new StaticPagedList<KullaniciResimVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return KullaniciResimVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<KullaniciResimVM> KullaniciResimGetirByResimId(int resimId)
        {
            KullaniciResimVM result = new KullaniciResimVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciResimGetirByResimId/?resimId=" + resimId.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<KullaniciResimVM>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> KullaniciResimSayisiGetir(Guid kullaniciId)
        {

            int result = 0;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciResimSayisiGetir/?kullaniciId=" + kullaniciId.ToString());
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
        public async Task<KullaniciResimVM> KullaniciBuyukProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResimVM)
        {
            KullaniciResimVM kullaniciResimVMResult = new KullaniciResimVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciBuyukProfilResimKaydetGuncelle", kullaniciResimVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciResimVMResult = JsonConvert.DeserializeObject<KullaniciResimVM>(responseData);
                }
                return kullaniciResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<KullaniciResimVM> KullaniciBuyukProfilResimGetir(Guid KullaniciId)
        {
            KullaniciResimVM kullaniciResimVMResult = new KullaniciResimVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciBuyukProfilResimGetir/?KullaniciId=" + KullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciResimVMResult = JsonConvert.DeserializeObject<KullaniciResimVM>(responseData);
                }
                return kullaniciResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DuvarResim
        public async Task<List<DuvarResimVM>> DuvarResimleriniGetir()
        {
            List<DuvarResimVM> DuvarResimVMResult = new List<DuvarResimVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("DuvarResimleriniGetir");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    DuvarResimVMResult = JsonConvert.DeserializeObject<List<DuvarResimVM>>(responseData);
                }
                return DuvarResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> KullaniciDuvarResimDegistir(Guid kullaniciId, int resimId)
        {
            int result = 0;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciDuvarResimDegistir/?kullaniciId=" + kullaniciId.ToString() + "&resimId=" + resimId.ToString());
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
        public async Task<DuvarResimVM> KullaniciDuvarResimGetir(Guid kullaniciId)
        {
            DuvarResimVM DuvarResimVMResult = new DuvarResimVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciDuvarResimGetir/?kullaniciId=" + kullaniciId.ToString());
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    DuvarResimVMResult = JsonConvert.DeserializeObject<DuvarResimVM>(responseData);
                }
                return DuvarResimVMResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region KullaniciHediyeKart
        public async Task<List<KullaniciVM>> KisiAra(KisiAraVM vm)
        {
            List<KullaniciVM> kullaniciSonuc = new List<KullaniciVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KisiAra",vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciSonuc = JsonConvert.DeserializeObject<List<KullaniciVM>>(responseData); ;
                }
                return kullaniciSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<KullaniciVM> KullaniciGetirByKullaniciAdi(string kullaniciAdi)
        {
            KullaniciVM kullaniciSonuc = new KullaniciVM();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciGetirByKullaniciAdi/?kullaniciAdi=" + kullaniciAdi);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    kullaniciSonuc = JsonConvert.DeserializeObject<KullaniciVM>(responseData); ;
                }
                return kullaniciSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResultModel> KullaniciHediyeKartKayit(KullaniciHediyeKartKayitVM model)
        {

            ResultModel ResultModel = new ResultModel();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciHediyeKartKayit", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    ResultModel = JsonConvert.DeserializeObject<ResultModel>(responseData);
                }
                return ResultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IPagedList<HediyeKartKonusmaListesiVM>> KullaniciHediyeKartListesiGetir(HediyeKartListeVM hediyeKartListeVM)
        {

            IPagedList<HediyeKartKonusmaListesiVM> mesajVMList = new List<HediyeKartKonusmaListesiVM>().ToPagedList();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", hediyeKartListeVM.Token.Token);

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciHediyeKartListesiGetir", hediyeKartListeVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<HediyeKartKonusmaListesiVM>>(responseData);
                    StaticPagedList<HediyeKartKonusmaListesiVM> result = new StaticPagedList<HediyeKartKonusmaListesiVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return mesajVMList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ResultModel<List<HediyeKartDetaySonucVM>>> HediyeKartDetayGetir(HediyeKartDetayGetirVM vm)
        {
            var hediyeKartDetaySonucVM = new ResultModel<List<HediyeKartDetaySonucVM>>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HediyeKartDetayGetir", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    hediyeKartDetaySonucVM = JsonConvert.DeserializeObject<ResultModel<List<HediyeKartDetaySonucVM>>>(responseData); ;
                }
                return hediyeKartDetaySonucVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> HediyeKartSil(HediyeKartSilVM vm)
        {
            ResultModel hediyeKartSilSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HediyeKartSil", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    hediyeKartSilSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return hediyeKartSilSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResultModel> HediyeKartKonusmaSil(KonusmaSilVM vm)
        {
            ResultModel mesajSilSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HediyeKartKonusmaSil", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    mesajSilSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return mesajSilSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HediyeKartIcerikVM> HediyeKartIcerikGetir(int id)
        {
            try
            {
                HediyeKartIcerikVM model = new HediyeKartIcerikVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("HediyeKartMesajIcerikGetirById/?id=" + id.ToString());
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

        public async Task<int> HediyeKartOkunduIsaretle(HediyeKartOkunduVM hediyeKartOkundu)
        {
            try
            {
                var sonuc = 0;
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("HediyeKartOkunduIsaretle", hediyeKartOkundu);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    sonuc = JsonConvert.DeserializeObject<int>(responseData);

                }
                return sonuc;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region KullaniciBildirim
        public async Task<IPagedList<KullaniciBildirimVM>> KullaniciBildirimListGetir(KullaniciBildirimListeVM model)
        {
            IPagedList<KullaniciBildirimVM> list = new List<KullaniciBildirimVM>().ToPagedList();

            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciBildirimListGetir", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    var subset = JsonConvert.DeserializeObject<PaginationEntity<KullaniciBildirimVM>>(responseData);
                    StaticPagedList<KullaniciBildirimVM> result = new StaticPagedList<KullaniciBildirimVM>(subset.Items, subset.MetaData.PageNumber, subset.MetaData.PageSize, subset.MetaData.TotalItemCount);

                    return result;
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> KullaniciBildirimEkle(KullaniciBildirimVM kullaniciBildirim)
        {
            try
            {
                bool result = false;
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciBildirimEkle", kullaniciBildirim);
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
        public async Task<bool> KullaniciBildirimSil(KullaniciBildirimVM kullaniciBildirim)
        {
            try
            {
                bool result = false;
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciBildirimSil", kullaniciBildirim);
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

        public async Task<List<KullaniciBildirimVM>> KullaniciHeaderBildirimListGetir(Guid kullaniciId)
        {
            List<KullaniciBildirimVM> result = new List<KullaniciBildirimVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciHeaderBildirimListGetir?kullaniciId=" + kullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<KullaniciBildirimVM>>(responseData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> KullaniciBildirimOkundu(Guid kullaniciId)
        {
            bool sonuc = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciBildirimOkundu?kullaniciId=" + kullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    sonuc = JsonConvert.DeserializeObject<bool>(responseData);
                }
                return sonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> TopluBildirimGonder(IletisimTopluBildirimVM bildirim)
        {
            try
            {
                int result = 0;
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("TopluBildirimGonder", bildirim);
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

        public async Task<List<BildirimAramaResultVM>> TumBildirimleriGetir(BildirimAramaVM bildirimAramaVM)
        {
            List<BildirimAramaResultVM> BildirimResultVM = new List<BildirimAramaResultVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("TumBildirimleriGetir", bildirimAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    BildirimResultVM = JsonConvert.DeserializeObject<List<BildirimAramaResultVM>>(responseData);
                }
                return BildirimResultVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public async Task<int> BildirimSil(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BildirimSil/?id=" + id.ToString());
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

        public async Task<bool> KullaniciTumBildirimleriSil(Guid kullaniciId)
        {
            bool sonuc = false;
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciTumBildirimleriSil?kullaniciId=" + kullaniciId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    sonuc = JsonConvert.DeserializeObject<bool>(responseData);
                }
                return sonuc;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> BildirimSayisiGetir(IletisimTopluBildirimVM bildirim)
        {
            try
            {
                int result = 0;
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("BildirimSayisiGetir", bildirim);
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
        public async Task<int> KisiyeOzelBildirimGonder(KisiyeOzelBildirimVM bildirim)
        {
            try
            {
                int result = 0;
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KisiyeOzelBildirimGonder", bildirim);
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
        public async Task<KullaniciBildirimVM> BildirimIdBildirimGetir(int id)
        {
            try
            {
                KullaniciBildirimVM bildirim = new KullaniciBildirimVM();
                HttpResponseMessage responseMessage = await httpClient.GetAsync("BildirimIdBildirimGetir?id="+ id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    bildirim = JsonConvert.DeserializeObject<KullaniciBildirimVM>(responseData);
                }
                return bildirim;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<KisiyeOzelBildirimAramaSonucVM>> KisiyeOzelBildirimleriGetir(BildirimAramaVM bildirimAramaVM)
        {
            List<KisiyeOzelBildirimAramaSonucVM> BildirimResultVM = new List<KisiyeOzelBildirimAramaSonucVM>();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KisiyeOzelBildirimleriGetir", bildirimAramaVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    BildirimResultVM = JsonConvert.DeserializeObject<List<KisiyeOzelBildirimAramaSonucVM>>(responseData);
                }
                return BildirimResultVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> KullaniciHeaderSepetUrunSayisiGetir(Guid kullaniciId)
        {
            try
            {
                int result = 0;
                HttpResponseMessage responseMessage = await httpClient.GetAsync("KullaniciHeaderSepetUrunSayisiGetir?kullaniciId="+ kullaniciId);
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

        #region SifremiUnuttum
        public async Task<ResultModel> KullaniciYeniSifreGonder(KullaniciSifreGonderVM model)
        {
            ResultModel result=new ResultModel();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("KullaniciYeniSifreGonder", model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResultModel> MesajlariOku(MesajDetayGetirVM vm)
        {
            ResultModel islemSonuc = new ResultModel();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vm.Token.Token);
            try
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync("MesajlariOku", vm);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    islemSonuc = JsonConvert.DeserializeObject<ResultModel>(responseData); ;
                }
                return islemSonuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion
    }
}
