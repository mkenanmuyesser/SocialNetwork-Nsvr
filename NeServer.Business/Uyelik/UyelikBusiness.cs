using AutoMapper;
using Microsoft.Extensions.Logging;
using NeSever.BusinessDomain.Uyelik;
using NeSever.Common.Commands.Uyelik;
using NeSever.Common.Infra.Command;
using NeSever.Common.Models;
using NeSever.Common.Models.Admin.AramaSonucVM;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Urun;
using NeSever.Common.Models.Uyelik;
using NeSever.Common.Utils.Encryption;
using NeSever.Common.Utils.Security.Token;
using NeSever.Data.DataService.Program;
using NeSever.Data.DataService.Sayfa;
using NeSever.Data.DataService.Uyelik;
using NeSever.Data.Entities;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace NeServer.Business.Uyelik
{
    public interface IUyelikBusiness
    {
        Task<ResultModel<AccessToken>> KullaniciKaydet(KullaniciKayitVM vm);
        Task<CommandResponse> KullaniciGuncelle(KullaniciGuncelleCommand command);
        Task<ResultModel<AccessToken>> KullaniciTokenYenile(KullaniciTokenYenileSilVM vm);
        Task<CommandResponse> KullaniciSil(KullaniciSilCommand command);
        Task<CommandResponse> RefreshTokenSil(KullaniciRefreshTokenKaydetSilCommand kullanici);
        Task<CommandResponse<AccessToken>> KullaniciGirisYapByEmailPassword(KullaniciGirisCommand kullanici);
        Task<ResultModel<AccessToken>> KullaniciGirisYapWithFacebook(KullaniciFbGirisVM kullanici);
        Task<ResultModel<AccessToken>> KullaniciGirisYapWithInstegram(KullaniciInstegramGirisVM kullanici);
        Task<ResultModel<AccessToken>> KullaniciGirisYapWithGoogle(KullaniciGoogleGirisVM kullanici);
        Task<CommandResponse<KullaniciVM>> KullaniciGetir(KullaniciGetirCommand kullanici);
        Task<CommandResponse<KullaniciKisiselBilgiVM>> KullaniciKisiselBilgileriGetir(KullaniciTokenCommand kullanici);
        Task<IEnumerable<KullaniciSehirVM>> SehirleriGetir();
        Task<ResultModel> KullaniciKisiselBilgiKaydetGuncelle(KullaniciKisiselBilgiKaydetGuncelleVM kullaniciKisiselBilgi);
        Task<ResultModel> SifreKaydetGuncelle(SifreDegistirVM vm);
        Task<ResultModel> AyarlarKaydetGuncelle(AyarlarVM vm);
        Task<ResultModel<AyarlarVM>> KullaniciAyarlariniGetir(string token);
        Task<ResultModel<KullaniciArkadasVM>> KullaniciArkadasListesiGetirDogumGunleriIcin(ArkadasListesiGetirVM vm);
        Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiGetir(ArkadasListeAramaVM arkadasAramaVM);
        Task<ResultModel<ArkadaslarMenuVM>> ArkadasMenuDegerleriGetir(TokenVM vm);
        Task<ResultModel<List<ArkadasIstekleriVM>>> ArkadasIstekleriniGetir(TokenVM vm);
        Task<ResultModel> ArkadasIstekleriniOku(TokenVM vm);
        Task<ResultModel<ArkadaslikIstekKabulSonucVM>> ArkadaslikIsteginiKabulEt(ArkadaslikIsteginiKabulEtVM vm);
        Task<ResultModel> ArkadaslikIsteginiReddet(ArkadaslikIsteginiSilVM vm);
        Task<IPagedList<ArkadasVM>> ArkadasAramaListGetir(ArkadasAramaVM arkadasAramaVM);
        Task<ResultModel> ArkadaslikIstekGonder(ArkadaslikIstegiGonderVM vm);
        Task<ResultModel> ArkadaslikIstekGonderildiMi(ArkadaslikIstegiGonderVM vm);
        Task<ResultModel> ArkadaslikIstekBanaGonderildiMi(ArkadaslikIstegiGonderVM vm);
        Task<ResultModel<ProfilVM>> ArkadaslikProfilGetir(ArkadasProfilGetirVM vm);
        Task<ResultModel> ArkadasMesajGonder(MesajGonderVM vm);
        Task<ResultModel> ArkadasSil(ArkadasSilVM vm);
        Task<IPagedList<ArkadasKonusmaListesiVM>> KullaniciMesajListesiGetir(ArkadasMesajListeVM mesajAramaVM);
        Task<ResultModel<List<ArkadasAraSonucVM>>> ArkadasAra(ArkadasAraVM vm);
        //TODO ŞG: Üst menü arama alanı için kullanılacak.
        //Task<ResultModel<List<HizliArkadasAraSonucVM>>> HizliArkadasAra(HizliArkadasAraVM vm);
        Task<ResultModel<List<MesajDetaySonucVM>>> MesajDetayGetir(MesajDetayGetirVM vm);
        Task<ResultModel> KonusmaSil(KonusmaSilVM vm);
        Task<ResultModel> MesajSil(MesajSilVM vm);
        Task<ProfilSagMenuVM> ProfilSagMenuGetir(ProfilSagMenuAraVM model);
        Task<ResultModel> ProfilArkadasEkle(ArkadaslikIstegiGonderVM vm);

        Task<bool> KullaniciArkadasKullaniciMi(Guid kullaniciId, Guid kullaniciArkadasId);
        Task<bool> KullaniciArkadasiminArkadasiMi(Guid kullaniciId, Guid kullaniciArkadasId);
        Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiModalGetir(KullaniciArkadasListesiModalAramaVM model);
        Task<int> KullaniciProfilGoruntulenmeSayisiGetir(Guid kullaniciId);
        Task<bool> KullaniciBakilanProfilEkle(KullaniciBakilanProfillerVM bakilanProfil);
        Task<bool> KullaniciBakilanProfilSil(BakilanProfilSilVM bakilanProfil);
        Task<bool> BakilanTumProfilleriSil(KullaniciVM vm);
        Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciBakilanProfilleriGetir(KullaniciArkadasListesiModalAramaVM model);
        Task<ResultModel<KullaniciAdiVM>> KullaniciAdiGuncelle(KullaniciAdiVM kullanici);
        Task<KullaniciVM> KullaniciGetirByKullaniciId(Guid kullaniciId);
        Task<List<BildirimKullaniciGetirVM>> BildirimKullaniciListGetir(KisiyeOzelBildirimVM data);
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

        #region KullaniciHobi

        #region Admin       

        #endregion

        #region FrontEnd
        Task<IEnumerable<KullaniciHobiVM>> HobileriGetir(string query);
        Task<KullaniciHobiVeIlgiAlanVM> KullaniciHobiIlgiAlanGetir(Guid kullaniciId);
        Task<bool> KullaniciHobiKaydetGuncelle(KullaniciHobiKaydetGuncelleVM model);
        #endregion

        #endregion

        #region KullaniciIlgiAlan

        #region Admin       

        #endregion

        #region FrontEnd
        Task<IEnumerable<KullaniciIlgiAlanVM>> IlgiAlanGetir(string query);
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
        Task<int> KullaniciArkadasSayisiGetir(Guid kullaniciId);
        Task<int> KullaniciMesajSayisiGetir(Guid kullaniciId);
        Task<int> KullaniciBildirimSayisiGetir(Guid kullaniciId);
        Task<int> KullaniciArkadasIstekSayisiGetir(Guid kullaniciId);
        Task<int> KullaniciHediyeKartiSayisiGetir(Guid kullaniciId);





        #endregion

        #endregion

        #region KullaniciResim
        Task<KullaniciResimVM> KullaniciProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResim);
        Task<KullaniciResimVM> KullaniciResimKaydet(KullaniciResimVM kullaniciResimVM);
        Task<KullaniciResimVM> KullaniciResimGetir(Guid kullaniciId);
        Task<List<KullaniciResimVM>> KullaniciResimListele(string kullaniciId);
        Task<int> ProfilResminiDegistir(Guid kullaniciId, int resimId);

        Task<int> KullaniciResimSil(Guid kullaniciId, int resimId);

        Task<IPagedList<KullaniciResimVM>> KullaniciListesiResimGetir(int start, int length, Guid kullaniciId);

        Task<KullaniciResimVM> KullaniciResimGetirByResimId(int resimId);
        Task<KullaniciResim> KullaniciProfilResmiSil(KullaniciResim kullaniciResim);
        Task<KullaniciResim> KullaniciProfilResimGetir(string kullaniciId);
        Task<int> KullaniciResimSayisiGetir(Guid kullaniciId);
        Task<KullaniciResimVM> KullaniciBuyukProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResimVM);
        Task<KullaniciResimVM> KullaniciBuyukProfilResimGetir(Guid KullaniciId);
        #endregion

        #region DuvarResmi
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

        Task<ResultModel> HediyeKartSil(HediyeKartSilVM vm);

        Task<ResultModel> HediyeKartKonusmaSil(KonusmaSilVM vm);
        Task<HediyeKartIcerikVM> HediyeKartMesajIcerikGetirById(int id);

        Task<int> HediyeKartOkunduIsaretle(HediyeKartOkunduVM hediyeKartOkundu);

        #endregion

        #region KullaniciBildirim
        Task<IPagedList<KullaniciBildirimVM>> KullaniciBildirimListGetir(KullaniciBildirimListeVM model);
        Task<bool> KullaniciBildirimEkle(KullaniciBildirimVM kullaniciBildirim);
        Task<bool> KullaniciBildirimSil(KullaniciBildirimVM kullaniciBildirim);
        Task<List<KullaniciBildirimVM>> KullaniciHeaderBildirimListGetir(Guid kullaniciId);
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

        #region Sifremi Unutum
        Task<ResultModel> KullaniciYeniSifreGonder(KullaniciSifreGonderVM model);
        #endregion


        #region Kullanıcı Künye
        Task<int> KullaniciOkunmamisArkadaslikIstegiSayisiGetir(Guid kullaniciId);
        Task<int> OkunmamisMesajSayisiGetir(Guid kullaniciId);
        Task<int> ProfilEngelSayisiGetir(Guid kullaniciId);
        #endregion


        #region Kullanıcı Mesaj

        Task<ResultModel> MesajlariOku(MesajDetayGetirVM vm);
        #endregion
    }


    public class UyelikBusiness : BaseBusiness, IUyelikBusiness
    {
        private readonly IMapper mapper;
        private readonly ITokenHandler tokenHandler;
        private readonly ILogger<UyelikBusiness> logger;
        private readonly IUyelikDataService uyelikDataService;
        private readonly IProgramDataService programDataService;
        private readonly ISayfaDataService sayfaDataService;


        public UyelikBusiness(IMapper mapper,
                              ITokenHandler tokenHandler,
                              ILogger<UyelikBusiness> logger,
                              IUyelikDataService uyelikDataService, IProgramDataService programDataService, 
                              ISayfaDataService sayfaDataService)
        {
            this.mapper = mapper;
            this.tokenHandler = tokenHandler;
            this.uyelikDataService = uyelikDataService;
            this.logger = logger;
            this.programDataService = programDataService;
            this.sayfaDataService = sayfaDataService;
        }

        public async Task<ResultModel<AccessToken>> KullaniciKaydet(KullaniciKayitVM vm)
        {
            var kullaniciKayitSonuc = new ResultModel<AccessToken>()
            {
                Type = ResultType.Basarisiz
            };

            NeSever.Common.Models.Program.AyarlarVM ayarlarModel = new NeSever.Common.Models.Program.AyarlarVM();
            ayarlarModel = await programDataService.AyarlarBilgileriniGetir();

            DateTime dogumTarih;
            if (!DateTime.TryParse(string.Format("{0}.{1}.{2}", vm.KullaniciKayitDogumYil, vm.KullaniciKayitDogumAy, vm.KullaniciKayitDogumGun), out dogumTarih))
            {
                kullaniciKayitSonuc.ErrorMessage = "Giriş yaptığınız tarih yanlıştır.";
                return kullaniciKayitSonuc;
            }
            else if (dogumTarih.Date >= DateTime.Now.Date)
            {
                kullaniciKayitSonuc.ErrorMessage = "Giriş yaptığınız tarih bugünden büyük olamaz.";
                return kullaniciKayitSonuc;
            }

            var kullanici = UyelikDomain.Kayit(vm);

            var kayitliKullaniciAdiVarmi = await uyelikDataService.KullaniciGetirByKullaniciAd(vm.KullaniciKayitKullaniciAdi);

            if (kayitliKullaniciAdiVarmi != null)
            {
                kullaniciKayitSonuc.ErrorMessage = "Bu kullanıcı adı ile üye kaydı bulunmaktadır";
                return kullaniciKayitSonuc;
            }

            var kayitliEpostaVarmi = await uyelikDataService.KullaniciGetirByEPosta(vm.KullaniciKayitEposta);

            if (kayitliEpostaVarmi != null)
            {
                if ((string.IsNullOrEmpty(kayitliEpostaVarmi.Sifre) && kayitliEpostaVarmi.FacebookKullanicisiMi && !string.IsNullOrEmpty(kayitliEpostaVarmi.FacebookId)) || (string.IsNullOrEmpty(kayitliEpostaVarmi.Sifre) && kayitliEpostaVarmi.GoogleKullanicisiMi && !string.IsNullOrEmpty(kayitliEpostaVarmi.GoogleId)))
                {
                    var SocialKullanicisiSifre = kullanici.Sifre;
                    kayitliEpostaVarmi.Sifre = SocialKullanicisiSifre.Encode();

                    UyelikDomain.SocialKullanicisiniNormalKaydet(kullanici, kayitliEpostaVarmi);

                    var kullaniciGuncelleSonuc = await uyelikDataService.Update(kayitliEpostaVarmi);

                    if (kullaniciGuncelleSonuc == 0)
                    {
                        var facebookKullaniciGirisSonuc = await KullaniciGirisYapByEmailPassword(new KullaniciGirisCommand()
                        {
                            Kullanici = new KullaniciGirisVM()
                            {
                                KullaniciGirisEpostaKullaniciAd = kullanici.Eposta,
                                KullaniciGirisSifre = SocialKullanicisiSifre
                            }
                        });

                        if (!facebookKullaniciGirisSonuc.HasError)
                        {
                            kullaniciKayitSonuc.Data = new AccessToken
                            {
                                Expiration = facebookKullaniciGirisSonuc.Result.Expiration,
                                RefreshToken = facebookKullaniciGirisSonuc.Result.RefreshToken,
                                Token = facebookKullaniciGirisSonuc.Result.Token
                            };

                            kullaniciKayitSonuc.Type = ResultType.Basarili;

                        }


                        var hosgeldinizEposta = await uyelikDataService.KullaniciHosgeldinEpostaGonder(vm, ayarlarModel);
                        return kullaniciKayitSonuc;
                    }
                }

                kullaniciKayitSonuc.ErrorMessage = "Bu e-posta adresi ile üye kaydı bulunmaktadır";
                return kullaniciKayitSonuc;
            }

            var sifre = kullanici.Sifre;
            kullanici.Sifre = sifre.Encode();
            kullanici.ProfilGoruntulemeDurum = 2;
            kullanici.KisiselBilgiGosterimDurum = true;
            kullanici = await uyelikDataService.Kayit(kullanici);

            var kullaniciGirisSonuc = await KullaniciGirisYapByEmailPassword(new KullaniciGirisCommand()
            {
                Kullanici = new KullaniciGirisVM()
                {
                    KullaniciGirisEpostaKullaniciAd = kullanici.Eposta,
                    KullaniciGirisSifre = sifre
                }
            });

            if (!kullaniciGirisSonuc.HasError)
            {
                kullaniciKayitSonuc.Data = new AccessToken
                {
                    Expiration = kullaniciGirisSonuc.Result.Expiration,
                    RefreshToken = kullaniciGirisSonuc.Result.RefreshToken,
                    Token = kullaniciGirisSonuc.Result.Token
                };

                kullaniciKayitSonuc.Type = ResultType.Basarili;

            }
            var hosgeldinEposta = await uyelikDataService.KullaniciHosgeldinEpostaGonder(vm, ayarlarModel);
            return kullaniciKayitSonuc;
        }

        public Task<CommandResponse> KullaniciGuncelle(KullaniciGuncelleCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<CommandResponse> KullaniciSil(KullaniciSilCommand command)
        {
            CommandResponse<KullaniciSilVM> response = new CommandResponse<KullaniciSilVM>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                var kullanici = await uyelikDataService.KullaniciGetirById(command.Kullanici.KullaniciId);
                if (kullanici == null)
                {
                    return AppError(response, ErrorCodes.User_UserNotFound);
                }
                UyelikDomain.KullaniciKilitle(kullanici);
                await uyelikDataService.Update(kullanici);
                return Ok(response);
            }
            catch (Exception ex)
            {
                //TODO Şahin Gündoğdu : buraya logging altyapısı kurularak alınan dberror hatası loglanacak. Şimdilik const olarak error dönüyor.
                return ServerError(response, ErrorCodes.User_DeleteErrorSaveDb, ex);
            }
        }


        public async Task<ResultModel<AccessToken>> KullaniciGirisYapWithFacebook(KullaniciFbGirisVM kullanici)
        {
            var result = new ResultModel<AccessToken>
            {
                Type = ResultType.Basarisiz
            };

            try
            {
                var kullaniciSonuc = await uyelikDataService.KullaniciGetirByEPosta(kullanici.Email);

                if (kullaniciSonuc != null)
                {
                    if (kullaniciSonuc.FacebookKullanicisiMi)
                    {
                        AccessToken accessToken = tokenHandler.CreateAccessToken(kullaniciSonuc);

                        UyelikDomain.KullaniciRefreshTokenKaydet(kullaniciSonuc, accessToken.RefreshToken);
                        UyelikDomain.KullaniciKilitKaldir(kullaniciSonuc);
                        await uyelikDataService.Update(kullaniciSonuc);

                        result.Data = new AccessToken
                        {
                            Expiration = accessToken.Expiration,
                            RefreshToken = accessToken.RefreshToken,
                            Token = accessToken.Token
                        };

                        result.Type = ResultType.Basarili;
                        return result;
                    }
                    else
                    {
                        var kullaniciGuncelle = UyelikDomain.KullaniciyiFacebookKullanicisiGuncelle(kullaniciSonuc, kullanici);

                        var kullaniciGuncelleSonuc = await uyelikDataService.Update(kullaniciGuncelle);

                        if (kullaniciGuncelleSonuc == 0)
                        {
                            AccessToken accessToken = tokenHandler.CreateAccessToken(kullaniciSonuc);

                            UyelikDomain.KullaniciRefreshTokenKaydet(kullaniciSonuc, accessToken.RefreshToken);
                            UyelikDomain.KullaniciKilitKaldir(kullaniciSonuc);
                            await uyelikDataService.Update(kullaniciSonuc);

                            result.Data = new AccessToken
                            {
                                Expiration = accessToken.Expiration,
                                RefreshToken = accessToken.RefreshToken,
                                Token = accessToken.Token
                            };

                            result.Type = ResultType.Basarili;
                            return result;
                        }
                    }
                }
                else
                {
                    var kullaniciAdiKullanilmisMi = await uyelikDataService.KullaniciGetirByKullaniciAd(kullanici.Name);

                    var facebookKullanicisi = UyelikDomain.FacebookKullanicisiKaydet(kullanici);
                    var kullaniciFacebookKayitSonuc = await uyelikDataService.Kayit(facebookKullanicisi);

                    if (kullaniciAdiKullanilmisMi != null)
                    {
                        do
                        {
                            facebookKullanicisi.KullaniciAdi = UyelikDomain.KullaniciAdiOlustur(facebookKullanicisi.KullaniciAdi);

                        } while (kullaniciAdiKullanilmisMi.KullaniciAdi == facebookKullanicisi.KullaniciAdi);
                    }

                    if (kullaniciFacebookKayitSonuc != null)
                    {
                        var facebookKullaniciGetirSonuc = await uyelikDataService.KullaniciGetirByEPosta(kullanici.Email);
                        facebookKullaniciGetirSonuc.ProfilGoruntulemeDurum = 2;
                        facebookKullaniciGetirSonuc.KisiselBilgiGosterimDurum = true;

                        AccessToken accessToken = tokenHandler.CreateAccessToken(facebookKullaniciGetirSonuc);
                        UyelikDomain.KullaniciRefreshTokenKaydet(facebookKullaniciGetirSonuc, accessToken.RefreshToken);
                        await uyelikDataService.Update(facebookKullaniciGetirSonuc);

                        result.Data = new AccessToken
                        {
                            Expiration = accessToken.Expiration,
                            RefreshToken = accessToken.RefreshToken,
                            Token = accessToken.Token
                        };

                        result.Type = ResultType.Basarili;
                        result.ErrorMessage = "IlkGiris";
                        return result;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResultModel<AccessToken>> KullaniciGirisYapWithGoogle(KullaniciGoogleGirisVM kullanici)
        {
            var result = new ResultModel<AccessToken>
            {
                Type = ResultType.Basarisiz
            };

            try
            {
                var kullaniciSonuc = await uyelikDataService.KullaniciGetirByEPosta(kullanici.Email);

                if (kullaniciSonuc != null)
                {
                    if (kullaniciSonuc.GoogleKullanicisiMi)
                    {
                        AccessToken accessToken = tokenHandler.CreateAccessToken(kullaniciSonuc);

                        UyelikDomain.KullaniciRefreshTokenKaydet(kullaniciSonuc, accessToken.RefreshToken);
                        UyelikDomain.KullaniciKilitKaldir(kullaniciSonuc);
                        await uyelikDataService.Update(kullaniciSonuc);

                        result.Data = new AccessToken
                        {
                            Expiration = accessToken.Expiration,
                            RefreshToken = accessToken.RefreshToken,
                            Token = accessToken.Token
                        };

                        result.Type = ResultType.Basarili;
                        return result;
                    }
                    else
                    {
                        var kullaniciGuncelle = UyelikDomain.KullaniciyiGoogleKullanicisiGuncelle(kullaniciSonuc, kullanici);

                        var kullaniciGuncelleSonuc = await uyelikDataService.Update(kullaniciGuncelle);

                        if (kullaniciGuncelleSonuc == 0)
                        {
                            AccessToken accessToken = tokenHandler.CreateAccessToken(kullaniciSonuc);

                            UyelikDomain.KullaniciRefreshTokenKaydet(kullaniciSonuc, accessToken.RefreshToken);
                            UyelikDomain.KullaniciKilitKaldir(kullaniciSonuc);
                            await uyelikDataService.Update(kullaniciSonuc);

                            result.Data = new AccessToken
                            {
                                Expiration = accessToken.Expiration,
                                RefreshToken = accessToken.RefreshToken,
                                Token = accessToken.Token
                            };

                            result.Type = ResultType.Basarili;
                            return result;
                        }
                    }
                }
                else
                {

                    var kullaniciAdiKullanilmisMi = await uyelikDataService.KullaniciGetirByKullaniciAd(kullanici.Name);


                    var googleKullanicisi = UyelikDomain.GoogleKullanicisiKaydet(kullanici);
                    var kullanicigoogleKayitSonuc = await uyelikDataService.Kayit(googleKullanicisi);

                    if (kullaniciAdiKullanilmisMi != null)
                    {
                        do
                        {
                            googleKullanicisi.KullaniciAdi = UyelikDomain.KullaniciAdiOlustur(googleKullanicisi.KullaniciAdi);

                        } while (kullaniciAdiKullanilmisMi.KullaniciAdi == googleKullanicisi.KullaniciAdi);
                    }

                    if (kullanicigoogleKayitSonuc != null)
                    {
                        var googleKullaniciGetirSonuc = await uyelikDataService.KullaniciGetirByEPosta(kullanici.Email);
                        googleKullaniciGetirSonuc.ProfilGoruntulemeDurum = 2;
                        googleKullaniciGetirSonuc.KisiselBilgiGosterimDurum = true;

                        AccessToken accessToken = tokenHandler.CreateAccessToken(googleKullaniciGetirSonuc);
                        UyelikDomain.KullaniciRefreshTokenKaydet(googleKullaniciGetirSonuc, accessToken.RefreshToken);
                        await uyelikDataService.Update(googleKullaniciGetirSonuc);

                        result.Data = new AccessToken
                        {
                            Expiration = accessToken.Expiration,
                            RefreshToken = accessToken.RefreshToken,
                            Token = accessToken.Token
                        };

                        result.Type = ResultType.Basarili;
                        result.ErrorMessage = "IlkGiris";
                        return result;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<ResultModel<AccessToken>> KullaniciGirisYapWithInstegram(KullaniciInstegramGirisVM kullanici)
        {
            var result = new ResultModel<AccessToken>
            {
                Type = ResultType.Basarisiz
            };

            try
            {
                var kullaniciSonuc = await uyelikDataService.KullaniciGetirByEPosta(kullanici.Email);

                if (kullaniciSonuc != null)
                {
                    if (kullaniciSonuc.InstagramKullanicisiMi)
                    {
                        AccessToken accessToken = tokenHandler.CreateAccessToken(kullaniciSonuc);

                        UyelikDomain.KullaniciRefreshTokenKaydet(kullaniciSonuc, accessToken.RefreshToken);
                        UyelikDomain.KullaniciKilitKaldir(kullaniciSonuc);
                        await uyelikDataService.Update(kullaniciSonuc);

                        result.Data = new AccessToken
                        {
                            Expiration = accessToken.Expiration,
                            RefreshToken = accessToken.RefreshToken,
                            Token = accessToken.Token
                        };

                        result.Type = ResultType.Basarili;
                        return result;
                    }
                    else
                    {
                        var kullaniciGuncelle = UyelikDomain.KullaniciyiInstegramKullanicisiGuncelle(kullaniciSonuc, kullanici);

                        var kullaniciGuncelleSonuc = await uyelikDataService.Update(kullaniciGuncelle);

                        if (kullaniciGuncelleSonuc == 0)
                        {
                            AccessToken accessToken = tokenHandler.CreateAccessToken(kullaniciSonuc);

                            UyelikDomain.KullaniciRefreshTokenKaydet(kullaniciSonuc, accessToken.RefreshToken);
                            UyelikDomain.KullaniciKilitKaldir(kullaniciSonuc);
                            await uyelikDataService.Update(kullaniciSonuc);

                            result.Data = new AccessToken
                            {
                                Expiration = accessToken.Expiration,
                                RefreshToken = accessToken.RefreshToken,
                                Token = accessToken.Token
                            };

                            result.Type = ResultType.Basarili;
                            return result;
                        }
                    }
                }
                else
                {

                    var kullaniciAdiKullanilmisMi = await uyelikDataService.KullaniciGetirByKullaniciAd(kullanici.Name);


                    var instegramKullanicisi = UyelikDomain.InstegramKullanicisiKaydet(kullanici);
                    var kullaniciInstegramKayitSonuc = await uyelikDataService.Kayit(instegramKullanicisi);

                    if (kullaniciAdiKullanilmisMi != null)
                    {
                        do
                        {
                            instegramKullanicisi.KullaniciAdi = UyelikDomain.KullaniciAdiOlustur(instegramKullanicisi.KullaniciAdi);

                        } while (kullaniciAdiKullanilmisMi.KullaniciAdi == instegramKullanicisi.KullaniciAdi);
                    }

                    if (kullaniciInstegramKayitSonuc != null)
                    {
                        var facebookKullaniciGetirSonuc = await uyelikDataService.KullaniciGetirByEPosta(kullanici.Email);
                        facebookKullaniciGetirSonuc.ProfilGoruntulemeDurum = 2;
                        facebookKullaniciGetirSonuc.KisiselBilgiGosterimDurum = true;

                        AccessToken accessToken = tokenHandler.CreateAccessToken(facebookKullaniciGetirSonuc);
                        UyelikDomain.KullaniciRefreshTokenKaydet(facebookKullaniciGetirSonuc, accessToken.RefreshToken);
                        await uyelikDataService.Update(facebookKullaniciGetirSonuc);

                        result.Data = new AccessToken
                        {
                            Expiration = accessToken.Expiration,
                            RefreshToken = accessToken.RefreshToken,
                            Token = accessToken.Token
                        };

                        result.Type = ResultType.Basarili;
                        return result;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<CommandResponse<KullaniciVM>> KullaniciGetir(KullaniciGetirCommand command)
        {
            CommandResponse<KullaniciVM> response = new CommandResponse<KullaniciVM>(command);

            try
            {
                var kullanici = await uyelikDataService.KullaniciGetirByToken(command.RefreshToken);
                return Ok(response, mapper.Map<Kullanici, KullaniciVM>(kullanici));
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.User_ErrorWhileGettingUser, ex);
            }
        }

        public async Task<CommandResponse> RefreshTokenSil(KullaniciRefreshTokenKaydetSilCommand command)
        {
            CommandResponse<KullaniciVM> response = new CommandResponse<KullaniciVM>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            if (command.RefreshToken != null)
            {
                var kullanici = await uyelikDataService.KullaniciGetirByToken(command.RefreshToken);

                if (kullanici == null)
                {
                    return AppError(response, ErrorCodes.User_UserNotFound);
                }
                UyelikDomain.KullaniciRefreshTokenSil(kullanici);
                try
                {
                    await uyelikDataService.Update(kullanici);
                }
                catch (Exception ex)
                {
                    return ServerError(response, ErrorCodes.User_ErrorOccuredWhileUpdatingRecord, ex);
                }

                return Ok(response);
            }
            return ServerError(response, ErrorCodes.User_ErrorOccuredWhileUpdatingRecord, null);
        }

        public async Task<CommandResponse<AccessToken>> KullaniciGirisYapByEmailPassword(KullaniciGirisCommand command)
        {
            CommandResponse<AccessToken> response = new CommandResponse<AccessToken>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                var kullanici = await uyelikDataService.KullaniciGetirByEPostaKullaniciAdSifre(command.Kullanici.KullaniciGirisEpostaKullaniciAd, command.Kullanici.KullaniciGirisSifre.Encode());

                if (kullanici == null)
                {
                    return AppError(response, ErrorCodes.User_UserNotFound);
                }

                AccessToken accessToken = tokenHandler.CreateAccessToken(kullanici);

                UyelikDomain.KullaniciRefreshTokenKaydet(kullanici, accessToken.RefreshToken);
                UyelikDomain.KullaniciKilitKaldir(kullanici);
                await uyelikDataService.Update(kullanici);
                return Ok(response, accessToken);
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.User_ErrorWhileGettingUser, ex);
            }

        }

        //RefreshToken'a göre yeniden token üretir.
        public async Task<ResultModel<AccessToken>> KullaniciTokenYenile(KullaniciTokenYenileSilVM vm)
        {
            var tokenYenileSonuc = new ResultModel<AccessToken>()
            {
                Type = ResultType.Basarisiz
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.RefreshToken);

            if (kullanici != null)
            {
                if (kullanici.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(kullanici);
                    UyelikDomain.KullaniciRefreshTokenKaydet(kullanici, vm.RefreshToken);
                    var guncelleSonuc = await uyelikDataService.Update(kullanici);
                    if (guncelleSonuc == 0)
                    {
                        tokenYenileSonuc.Type = ResultType.Basarili;
                        tokenYenileSonuc.Data = new AccessToken
                        {
                            Expiration = accessToken.Expiration,
                            Token = accessToken.Token,
                            RefreshToken = vm.RefreshToken
                        };

                        return tokenYenileSonuc;
                    }
                }
            }

            return tokenYenileSonuc;

        }

        public async Task<CommandResponse<KullaniciKisiselBilgiVM>> KullaniciKisiselBilgileriGetir(KullaniciTokenCommand command)
        {
            CommandResponse<KullaniciKisiselBilgiVM> response = new CommandResponse<KullaniciKisiselBilgiVM>(command);
            if (response.HasError)
                return AppError(response, response.Code);

            try
            {
                var kullanici = await uyelikDataService.KullaniciGetirByToken(command.RefreshToken);
                var sehirler = await uyelikDataService.SehirleriGetir();
                var result = mapper.Map<Kullanici, KullaniciKisiselBilgiVM>(kullanici);
                result.DogumGun = kullanici.DogumTarihi.HasValue ? kullanici.DogumTarihi.Value.Day : 1;
                result.DogumAy = kullanici.DogumTarihi.HasValue ? kullanici.DogumTarihi.Value.Month : 1;
                result.DogumYil = kullanici.DogumTarihi.HasValue ? kullanici.DogumTarihi.Value.Year : 1;

                return Ok(response, result);
            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.User_ErrorWhileGettingUser, ex);
            }

        }

        public async Task<IEnumerable<KullaniciSehirVM>> SehirleriGetir()
        {
            List<KullaniciSehirVM> kullaniciSehirler = new List<KullaniciSehirVM>();

            var sehirler = await uyelikDataService.SehirleriGetir();

            sehirler.ToList().ForEach(s =>
            {
                var sehir = new KullaniciSehirVM()
                {
                    KullaniciSehirId = s.KullaniciSehirId,
                    KullaniciSehirAdi = s.KullaniciSehirAdi
                };

                kullaniciSehirler.Add(sehir);
            });

            return kullaniciSehirler;
        }

        public async Task<ResultModel> KullaniciKisiselBilgiKaydetGuncelle(KullaniciKisiselBilgiKaydetGuncelleVM kullaniciKisiselBilgi)
        {

            var result = new ResultModel
            {
                Type = ResultType.Basarisiz,
                ErrorMessage = "Kayıt Yaparken Bir Hata Oluştu."
            };


            if (kullaniciKisiselBilgi.Adi == null || kullaniciKisiselBilgi.Adi == "" )
            {
                result.ErrorMessage = "Ad alanı boş geçilemez.";
                return result;
            }

            if (kullaniciKisiselBilgi.Soyadi == null || kullaniciKisiselBilgi.Soyadi == "")
            {
                result.ErrorMessage = "Soyad alanı boş geçilemez.";
                return result;
            }

            if (kullaniciKisiselBilgi.Cinsiyet == null || kullaniciKisiselBilgi.Cinsiyet == "")
            {
                result.ErrorMessage = "Cinsiyet alanı boş geçilemez.";
                return result;
            }

            if (kullaniciKisiselBilgi.DogumTarihi == null )
            {
                result.ErrorMessage = "Doğum tarihi alanı boş geçilemez.";
                return result;
            }
            kullaniciKisiselBilgi = UyelikDomain.Guncelle(kullaniciKisiselBilgi);
            var kullanici = await uyelikDataService.KullaniciGetirByToken(kullaniciKisiselBilgi.RefreshToken);

            if (kullanici != null)
            {
                kullanici.Adi = kullaniciKisiselBilgi.Adi;
                kullanici.Soyadi = kullaniciKisiselBilgi.Soyadi;
                kullanici.Eposta = kullaniciKisiselBilgi.Eposta;
                kullanici.DogumTarihi = kullaniciKisiselBilgi.DogumTarihi;
                kullanici.Cinsiyet = kullaniciKisiselBilgi.Cinsiyet;
                kullanici.KullaniciSehirId = kullaniciKisiselBilgi.KullaniciSehirId;
                kullanici.Adres = kullaniciKisiselBilgi.Adres;
                kullanici.IliskiDurumu = kullaniciKisiselBilgi.IliskiDurumu;
                kullanici.Hakkinda = kullaniciKisiselBilgi.Hakkinda;
                kullanici.Telefon = kullaniciKisiselBilgi.Telefon;
                kullanici.InstagramAdi = kullaniciKisiselBilgi.InstagramAdi;
            }

            var kullaniciKisiselBilgiGuncelleSonuc = await uyelikDataService.Update(kullanici);


            if (kullaniciKisiselBilgiGuncelleSonuc == 0)
            {
                result.Type = ResultType.Basarili;
                result.ErrorMessage = "Kaydınız Gerçekleştirildi.";

                return result;
            }
            return result;
        }

        public async Task<ResultModel> SifreKaydetGuncelle(SifreDegistirVM vm)
        {
            var sifreKaydeSonuc = new ResultModel
            {
                Type = ResultType.Basarili
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            if (kullanici.Sifre != vm.SuankiSifre.Encode())
            {
                sifreKaydeSonuc.Type = ResultType.Basarisiz;
                sifreKaydeSonuc.ErrorMessage = "Şu Anki Şifreniz Yanlış Girildi";
                return sifreKaydeSonuc;
            }

            if (kullanici.Sifre == vm.YeniSifre.Encode())
            {
                sifreKaydeSonuc.Type = ResultType.Basarisiz;
                sifreKaydeSonuc.ErrorMessage = "Şifre Bir Önceki Şifreniz İle Aynı Olamaz";
                return sifreKaydeSonuc;
            }

            kullanici.Sifre = vm.YeniSifre.Encode();
            var sifreDegistirSonuc = await uyelikDataService.Update(kullanici);
            if (sifreDegistirSonuc > 0)
            {
                sifreKaydeSonuc.Type = ResultType.Basarisiz;
                sifreKaydeSonuc.ErrorMessage = "Şifre Güncelleme İşlemi Yapılırken Bir Hata Oluştu";

            }
            return sifreKaydeSonuc;
        }

        public async Task<ResultModel> AyarlarKaydetGuncelle(AyarlarVM vm)
        {
            var ayarlarKaydetGuncelleSonuc = new ResultModel
            {
                Type = ResultType.Basarili,
                ErrorMessage = "Ayarlarınız Kaydedildi."

            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            kullanici.DogumGunleriHatirlatmaDurum = vm.DogumGunleriHatirlatma;
            kullanici.ArkadasIstekTalepleriDurum = vm.ArkadasIstekTalepleriDurum;
            kullanici.MesajEpostaBildirimDurum = vm.MesajEpostaBildirim;
            kullanici.ProfilGoruntulemeDurum = vm.ProfilGoruntulemeDurum;
            kullanici.KisiselBilgiGosterimDurum = vm.KisiselBilgiGosterimDurum;

            var kullaniciayarlarGuncelleSonuc = await uyelikDataService.Update(kullanici);

            if (kullaniciayarlarGuncelleSonuc > 0)
            {
                ayarlarKaydetGuncelleSonuc.Type = ResultType.Basarisiz;
                ayarlarKaydetGuncelleSonuc.ErrorMessage = "Ayalarınız Kaydedilemedi.";
            }

            return ayarlarKaydetGuncelleSonuc;
        }

        public async Task<ResultModel<AyarlarVM>> KullaniciAyarlariniGetir(string token)
        {
            var kullaniciAyarlarGetirSonuc = new ResultModel<AyarlarVM>
            {
                Type = ResultType.Basarisiz
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(token);

            if (kullanici != null)
            {
                kullaniciAyarlarGetirSonuc.Type = ResultType.Basarili;
                kullaniciAyarlarGetirSonuc.Data = new AyarlarVM
                {
                    ArkadasIstekTalepleriDurum = kullanici.ArkadasIstekTalepleriDurum,
                    DogumGunleriHatirlatma = kullanici.DogumGunleriHatirlatmaDurum,
                    MesajEpostaBildirim = kullanici.MesajEpostaBildirimDurum,
                    ProfilGoruntulemeDurum = kullanici.ProfilGoruntulemeDurum,
                    KisiselBilgiGosterimDurum = kullanici.KisiselBilgiGosterimDurum
                };
            }

            return kullaniciAyarlarGetirSonuc;
        }

        public async Task<ResultModel<KullaniciArkadasVM>> KullaniciArkadasListesiGetirDogumGunleriIcin(ArkadasListesiGetirVM vm)
        {
            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);
            return await uyelikDataService.KullaniciArkadasListesiGetirDogumGunleriIcin(kullanici.KullaniciId);
        }

        public async Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiGetir(ArkadasListeAramaVM arkadasAramaVM)
        {
            var kullanici = await uyelikDataService.KullaniciGetirByToken(arkadasAramaVM.Token.RefreshToken);

            return await uyelikDataService.ArkadasListesiGetir(arkadasAramaVM, kullanici.KullaniciId);
        }

        public async Task<ResultModel<ArkadaslarMenuVM>> ArkadasMenuDegerleriGetir(TokenVM vm)
        {

            var arkadasMenuSonuc = new ResultModel<ArkadaslarMenuVM>
            {
                Type = ResultType.Basarisiz

            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.RefreshToken);
            var kullaniciById = await uyelikDataService.KullaniciGetirById(kullanici.KullaniciId);

            var kullaniciArkadaslar = await uyelikDataService.KullaniciArkadasListesiGetirDogumGunleriIcin(kullaniciById.KullaniciId);
            var bugunkiDogumGunleri = kullaniciArkadaslar.Data.Arkadaslar.Where(x => x.DogumTarihi.Month == DateTime.Now.Month && x.DogumTarihi.Day == DateTime.Now.Day).Count();
            var mesajSayisi = await OkunmamisMesajSayisiGetir(kullaniciById.KullaniciId);
            var arkadaslikIstekSayisi = await KullaniciOkunmamisArkadaslikIstegiSayisiGetir(kullaniciById.KullaniciId);
            var profilEngelSayisi= await ProfilEngelSayisiGetir(kullaniciById.KullaniciId);

            arkadasMenuSonuc.Data = new ArkadaslarMenuVM()
            {
                ArkadasIstekleriSayisi = arkadaslikIstekSayisi,
                ArkadasSayisi = kullaniciArkadaslar.Data.Arkadaslar.Count(),
                MesajSayisi = mesajSayisi,
                DogumGunleri = bugunkiDogumGunleri,
                ProfilEngelSayisi = profilEngelSayisi,
            };

            return arkadasMenuSonuc;
        }

        public async Task<ResultModel<List<ArkadasIstekleriVM>>> ArkadasIstekleriniGetir(TokenVM vm)
        {
            var arkadasIstekListesiSonuc = new ResultModel<List<ArkadasIstekleriVM>>
            {
                Type = ResultType.Basarili,
                Data = new List<ArkadasIstekleriVM>()

            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.RefreshToken);

            if (kullanici == null)
            {
                arkadasIstekListesiSonuc.ErrorMessage = "Kullanici Bilgileri Getirirken Hata Oluştu";

                return arkadasIstekListesiSonuc;
            }

            var kullaniciArkadasIstekListesi = await uyelikDataService.ArkadasIstekleriniGetir(kullanici.KullaniciId);

            var kullaniciArkadasListesi = await uyelikDataService.ArkadasListesiGetir(kullanici.KullaniciId);

            foreach (var k in kullaniciArkadasIstekListesi)
            {
                var istekGonderenKullaniciArkadasListesi = await uyelikDataService.ArkadasListesiGetir(k.ArkadaslikIstekKullanici.KullaniciId);

                var ortakArkadasSayisi = kullaniciArkadasListesi.Select(i => i.ArkadasKullaniciId)
                    .Intersect(istekGonderenKullaniciArkadasListesi.Select(d => d.ArkadasKullaniciId)).Count();

                var istek = new ArkadasIstekleriVM
                {
                    Ad = k.ArkadaslikIstekKullanici.Adi,
                    Soyad = k.ArkadaslikIstekKullanici.Soyadi,
                    OrtakArkadasSayisi = ortakArkadasSayisi,
                    ArkadasIstekKullaniciId = k.ArkadaslikIstekKullaniciId,
                    ProfilResmiBase64 = k.ArkadaslikIstekKullanici.KullaniciResim.Any() && k.ArkadaslikIstekKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true) != null ? string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(k.ArkadaslikIstekKullanici.KullaniciResim.FirstOrDefault(p => p.AktifMi == true && p.ProfilFotografiMi == true).Resim)) : "/Uploads/Site/user_icon.png",
                    ArkadaslikDurumTipId = k.ArkadaslikKabulDurumTipId,
                    GuncellemeTarihi = k.GuncellemeTarih,
                    KayitTarihi = k.KayitTarihi,
                    KullaniciId = k.KullaniciId,
                    KullaniciAdi = k.ArkadaslikIstekKullanici.KullaniciAdi
                };

                arkadasIstekListesiSonuc.Data.Add(istek);
            }

            return arkadasIstekListesiSonuc;
        }

        public async Task<ResultModel<ArkadaslikIstekKabulSonucVM>> ArkadaslikIsteginiKabulEt(ArkadaslikIsteginiKabulEtVM vm)
        {
            var arkadasIstekKabulSonuc = new ResultModel<ArkadaslikIstekKabulSonucVM>
            {
                Type = ResultType.Basarili
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            if (kullanici == null)
            {
                arkadasIstekKabulSonuc.Type = ResultType.Basarisiz;
                arkadasIstekKabulSonuc.ErrorMessage = "Kullanici Bilgileri Getirilirken Hata Oluştu";
                return arkadasIstekKabulSonuc;
            }

            var kullaniciArkadasIstek = await uyelikDataService.ArkadasIstekGetir(kullanici.KullaniciId, new Guid(vm.ArkadasIstekKullaniciId));

            var kullaniciArkadasIstek2 = await uyelikDataService.ArkadasIstekGetir(new Guid(vm.ArkadasIstekKullaniciId), kullanici.KullaniciId);

            if (kullaniciArkadasIstek2 != null)
            {
                var arkadaslikIstekKabuletSonuc2 = await uyelikDataService.ArkadasIstekKaldir(kullaniciArkadasIstek2);
            }

            var kullaniciArkadas = UyelikDomain.KullaniciArkadasKaydet(kullanici.KullaniciId, kullaniciArkadasIstek.ArkadaslikIstekKullaniciId);

            var arkadasKaydetSonuc = await uyelikDataService.ArkadasKaydet(kullaniciArkadas);

            var arkadaslikIstekKabuletSonuc = await uyelikDataService.ArkadasIstekKaldir(kullaniciArkadasIstek);

            if (arkadasKaydetSonuc != null && arkadaslikIstekKabuletSonuc != -1)
            {
                var arkadaslikIstekGuncelleSonuc = UyelikDomain.KullaniciIstekGuncelle(kullaniciArkadasIstek);
                await uyelikDataService.ArkadasIstekGuncelle(arkadaslikIstekGuncelleSonuc);
            }

            arkadasIstekKabulSonuc.Data = new ArkadaslikIstekKabulSonucVM()
            {
                Ad = kullaniciArkadasIstek.ArkadaslikIstekKullanici.Adi,
                Soyad = kullaniciArkadasIstek.ArkadaslikIstekKullanici.Soyadi,
                ArkadasKullaniciId = kullaniciArkadasIstek.ArkadaslikIstekKullanici.KullaniciId,
                KullaniciAdi = kullaniciArkadasIstek.ArkadaslikIstekKullanici.KullaniciAdi
            };

            return arkadasIstekKabulSonuc;
        }

        public async Task<ResultModel> ArkadasIstekleriniOku(TokenVM vm)
        {
            var arkadasIstekleriniOku = new ResultModel()
            {
                Type = ResultType.Basarisiz
            };
            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.RefreshToken);

            if (kullanici == null)
            {
                arkadasIstekleriniOku.Type = ResultType.Basarisiz;
                arkadasIstekleriniOku.ErrorMessage = "Kullanici Bilgileri Getirilirken Hata Oluştu";
                return arkadasIstekleriniOku;
            }
            var kullaniciOkunmamisArkadaslikIstekleri = await uyelikDataService.OkunmamisArkadasIstekleriniGetir(kullanici.KullaniciId);
            if (kullaniciOkunmamisArkadaslikIstekleri.Count() > 0)
            {
                var istekleriOku = UyelikDomain.ArkadaslikIstekleriniOku(kullaniciOkunmamisArkadaslikIstekleri.ToList());
                var kullaniciArkadaslikIstekleriOkuSonuc = await uyelikDataService.ArkadaslikIstekleriniOku(istekleriOku);
                arkadasIstekleriniOku.Type = ResultType.Basarili;
            }
            else
            {
                arkadasIstekleriniOku.Type = ResultType.Basarisiz;
            }
            return arkadasIstekleriniOku;
        }
        public async Task<ResultModel> ArkadaslikIsteginiReddet(ArkadaslikIsteginiSilVM vm)
        {
            var arkadasIstekSilSonuc = new ResultModel()
            {
                Type = ResultType.Basarisiz
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            if (kullanici == null)
            {
                arkadasIstekSilSonuc.Type = ResultType.Basarisiz;
                arkadasIstekSilSonuc.ErrorMessage = "Kullanici Bilgileri Getirilirken Hata Oluştu";
                return arkadasIstekSilSonuc;
            }

            var kullaniciArkadasIstek = await uyelikDataService.ArkadasIstekGetir(kullanici.KullaniciId, new Guid(vm.ArkadasIstekKullaniciId));

            var kullaniciArkadasIstek2 = await uyelikDataService.ArkadasIstekGetir(new Guid(vm.ArkadasIstekKullaniciId), kullanici.KullaniciId);

            if (kullaniciArkadasIstek2 != null)
            {
                var arkadaslikIstekReddetSonuc2 = await uyelikDataService.ArkadasIstekKaldir(kullaniciArkadasIstek2);
            }

            if (kullaniciArkadasIstek != null)
            {
                var arkadaslikIstekReddetSonuc = await uyelikDataService.ArkadasIstekKaldir(kullaniciArkadasIstek);

                if(arkadaslikIstekReddetSonuc != -1)
                {
                    arkadasIstekSilSonuc.Type = ResultType.Basarili;
                    arkadasIstekSilSonuc.ErrorMessage = "Arkadaşlık İsteği Reddedildi";
                }
                else
                {
                    arkadasIstekSilSonuc.Type = ResultType.Basarisiz;
                    arkadasIstekSilSonuc.ErrorMessage = "Arkadaşlık İsteği Reddedilemedi";
                }                
            }

            return arkadasIstekSilSonuc;
        }

        public async Task<IPagedList<ArkadasVM>> ArkadasAramaListGetir(ArkadasAramaVM arkadasAramaVM)
        {
            if (arkadasAramaVM.Token != null)
            {
                var kullanici = await uyelikDataService.KullaniciGetirByToken(arkadasAramaVM.Token.RefreshToken);
                arkadasAramaVM.KullaniciId = kullanici.KullaniciId;
            }

            return await uyelikDataService.ArkadasAramaListGetir(arkadasAramaVM);

        }

        public async Task<ResultModel> ArkadaslikIstekGonder(ArkadaslikIstegiGonderVM vm)
        {
            var arkadasIstekGonderSonuc = new ResultModel()
            {
                Type = ResultType.Basarisiz,
                ErrorMessage = "istekVar"
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            bool arkadaslikIstekVarmi = await uyelikDataService.ArkadasIstekVarMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

            bool arkadaslikVarmi = await uyelikDataService.KullaniciArkadasKullaniciMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

            if (arkadaslikVarmi)
            {
                arkadasIstekGonderSonuc.ErrorMessage = "arkadaslikVar";
            }
            else
            {
                if (!arkadaslikIstekVarmi)
                {
                    if (kullanici != null)
                    {
                        var arkadaslikIstekDurum = await uyelikDataService.ArkadaslikIstekDurumGetir(vm.IstekGonderilenKullaniciId);

                        if(arkadaslikIstekDurum == 3)
                        {
                            var arkadasiminArkadasimi = await uyelikDataService.KullaniciArkadasiminArkadasiMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

                            if(arkadasiminArkadasimi)
                            {
                                arkadasIstekGonderSonuc.Type = ResultType.Basarili;
                                arkadasIstekGonderSonuc.ErrorMessage = "Arkadaslik İstegi Gonderildi";
                            }
                            else
                            {
                                arkadasIstekGonderSonuc.Type = ResultType.Basarisiz;
                                arkadasIstekGonderSonuc.ErrorMessage = "ArkadasiminArkadasiDegil";
                                return arkadasIstekGonderSonuc;
                            }
                        }
                        var arkadaslikIstek = UyelikDomain.KullaniciIstekKaydet(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

                        var arkadaslikIstekKayitSonuc = await uyelikDataService.ArkadasIstekKaydet(arkadaslikIstek);

                        if (arkadaslikIstekKayitSonuc == 0)
                        {
                            arkadasIstekGonderSonuc.Type = ResultType.Basarili;
                            arkadasIstekGonderSonuc.ErrorMessage = "Arkadaslik İstegi Gonderildi";
                            return arkadasIstekGonderSonuc;
                        }
                    }
                }
            }

            var banaIstekVarmi = await uyelikDataService.BanaArkadaslikIstekVarMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);
            if(banaIstekVarmi)
            {
                arkadasIstekGonderSonuc.ErrorMessage = "banaIstekVar";
            }

            if(arkadasIstekGonderSonuc.ErrorMessage == "istekVar")
            {
                var istekSil = await uyelikDataService.ArkadaslikIstekSil(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);
            }

            return arkadasIstekGonderSonuc;
        }

        public async Task<ResultModel> ArkadaslikIstekGonderildiMi(ArkadaslikIstegiGonderVM vm)
        {
            var arkadasIstekGonderildi = new ResultModel()
            {
                Type = ResultType.Basarisiz
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            if (kullanici != null)
            {
                bool arkadaslikIstekVarmi = await uyelikDataService.ArkadasIstekVarMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

                if (arkadaslikIstekVarmi)
                {
                    var arkadaslikIstekSil = await uyelikDataService.ArkadaslikIstekSil(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);
                    arkadasIstekGonderildi.Type = ResultType.Basarili;
                    arkadasIstekGonderildi.ErrorMessage = "ArkadaslikTalebiSilindi";
                    return arkadasIstekGonderildi;
                }
                else
                {
                    var arkadaslikIstek = UyelikDomain.KullaniciIstekKaydet(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

                    var arkadaslikIstekKayitSonuc = await uyelikDataService.ArkadasIstekKaydet(arkadaslikIstek);
                    if(arkadaslikIstekKayitSonuc == 0)
                        {
                        arkadasIstekGonderildi.Type = ResultType.Basarisiz;
                        arkadasIstekGonderildi.ErrorMessage = "Arkadaslik İstegi Gonderildi";
                        return arkadasIstekGonderildi;
                    }
                }
            }
            return arkadasIstekGonderildi;
        }

        public async Task<int> KullaniciProfilGoruntulenmeSayisiGetir(Guid kullaniciId)
        {


            var profilGoruntulenme = await uyelikDataService.KullaniciGoruntulenmeSayisiArtir(kullaniciId);



            return profilGoruntulenme;
        }

        public async Task<ResultModel> ArkadaslikIstekBanaGonderildiMi(ArkadaslikIstegiGonderVM vm)
        {
            var arkadasIstekGonderildi = new ResultModel()
            {
                Type = ResultType.Basarisiz
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            if (kullanici != null)
            {
                bool arkadaslikIstekVarmi = await uyelikDataService.ArkadasIstekVarMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

                if (arkadaslikIstekVarmi)
                {
                    arkadasIstekGonderildi.Type = ResultType.Basarili;
                    arkadasIstekGonderildi.ErrorMessage = "Arkadaslik talebi var";
                    return arkadasIstekGonderildi;
                }
            }
            return arkadasIstekGonderildi;
        }

        public async Task<ResultModel<ProfilVM>> ArkadaslikProfilGetir(ArkadasProfilGetirVM model)
        {
            var result = new ResultModel<ProfilVM>()
            {
                Type = ResultType.Basarisiz,
                ErrorMessage = "Profil Bilgileri Getirilirken Bir Hata Oluştu"
            };

            try
            {
                var profil = await uyelikDataService.KullaniciGetirByKullaniciAd(model.KullaniciAdi);
                if (profil != null)
                {
                    var duvarResim = await KullaniciDuvarResimGetir(profil.KullaniciId);
                    var kullaniciResim = await KullaniciResimGetir(profil.KullaniciId);
                    var hediyeSepetiSayisi = await KullaniciHediyeSepetiSayisiGetir(profil.KullaniciId);
                    var mesajSayisi = await OkunmamisMesajSayisiGetir(profil.KullaniciId);
                    var bildirimSayisi = await KullaniciBildirimSayisiGetir(profil.KullaniciId);
                    var arkadaslikIstekSayisi = await KullaniciOkunmamisArkadaslikIstegiSayisiGetir(profil.KullaniciId);
                    var arkadasSayisi = await KullaniciArkadasSayisiGetir(profil.KullaniciId);
                    var hediyeKartiSayisi = await KullaniciHediyeKartiSayisiGetir(profil.KullaniciId);
                    var hobiler = await KullaniciHobiGetir(profil.KullaniciId);
                    var ilgiAlanlari = await KullaniciIlgiAlanGetir(profil.KullaniciId);
                    var kullaniciResimSayisi = await uyelikDataService.KullaniciResimSayisiGetir(profil.KullaniciId);
                    var profilineBakilanlar = await uyelikDataService.KullaniciBakilanProfilSayiGetir(profil.KullaniciId);
                    var indirimKuponSayisi = await sayfaDataService.IndirimKuponSayisiGetir();
                    var adresSayisi = await uyelikDataService.KullaniciAdresSayisiGetir(profil.KullaniciId);
                    var siparisSayisi = await uyelikDataService.KullaniciSiparisSayisiGetir(profil.KullaniciId);

                    result.Data = new ProfilVM()
                    {
                        UyeData = new UyeVM()
                        {
                            //ArkadasProfil
                            KullaniciId = profil.KullaniciId,
                            KullaniciAdi = profil.KullaniciAdi,
                            Adi = profil.Adi,
                            Soyadi = profil.Soyadi,
                            Sehir = profil.KullaniciSehir?.KullaniciSehirAdi,
                            KisiselBilgiGosterimDurum = profil.KisiselBilgiGosterimDurum,
                            ProfilGoruntulemeDurum = profil.ProfilGoruntulemeDurum,
                            Ulke = "TR",
                            KullaniciResimBase64 = kullaniciResim == null || string.IsNullOrEmpty(kullaniciResim.ResimBase64) ? "/Uploads/Site/user_icon.png" : string.Format("data:image/png;base64,{0}", kullaniciResim.ResimBase64),
                            DuvarResimBase64 = duvarResim == null || string.IsNullOrEmpty(duvarResim.ResimBase64) ? "/Uploads/ProfileTopHeader/top_header_23.jpg" : string.Format("data:image/png;base64,{0}", duvarResim.ResimBase64),
                            ArkadasIstekTalepleriDurum = profil.ArkadasIstekTalepleriDurum
                        },
                        SolMenuData = new ProfilSolMenuVM()
                        {
                            //ArkadasProfil
                            KisiselBilgiGosterimDurum = profil.KisiselBilgiGosterimDurum,
                            KullaniciAdi = profil.KullaniciAdi,
                            Adi = profil.Adi,
                            Soyadi = profil.Soyadi,
                            Hakkinda = profil.Hakkinda,
                            DogumTarihi = profil.DogumTarihi.HasValue ? profil.DogumTarihi.Value : new DateTime(1900, 1, 1),
                            Sehir = profil.KullaniciSehir?.KullaniciSehirAdi,
                            Ulke = "TR",
                            Cinsiyet = profil.Cinsiyet,
                            IliskiDurumu = profil.IliskiDurumu,
                            HediyeSepetiSayi = hediyeSepetiSayisi,
                            MesajSayi = mesajSayisi,
                            BildirimSayi = bildirimSayisi,
                            ArkadasIstekSayi = arkadaslikIstekSayisi,
                            ArkadasSayi = arkadasSayisi,
                            HediyeKartSayi = hediyeKartiSayisi,
                            KullaniciHobi = hobiler,
                            KullaniciIlgiAlan = ilgiAlanlari,
                            KullaniciResimSayi = kullaniciResimSayisi,
                            ProfilGoruntulenmeSayisi = profil.ProfilGoruntulenmeSayisi,
                            IndirimKuponuSayisi = indirimKuponSayisi,
                            SiparisSayi = siparisSayisi,
                            AdresSayi = adresSayisi,
                            ProfilKullaniciMi = false
                        }
                    };

                    result.Type = ResultType.Basarili;
                    result.ErrorMessage = "";
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, string.Format("/{0}/{1}/{2}/{3}", "Business", "UyelikBusiness", "ArkadaslikProfilGetir", model.KullaniciAdi));
            }

            return result;
        }

        public async Task<ResultModel> ArkadasMesajGonder(MesajGonderVM vm)
        {
            var result = new ResultModel
            {
                Type = ResultType.Basarisiz
            };

            var mesaj = UyelikDomain.KullaniciMesajKaydet(vm);

            var mesajKaydetSonuc = await uyelikDataService.KullaniciMesajKaydet(mesaj);

            if (mesajKaydetSonuc == 0)
            {
                result.Type = ResultType.Basarili;
                result.ErrorMessage = "Mesajınız gönderilmiştir.";
                return result;
            }
            return result;
        }

        public async Task<ResultModel> ArkadasSil(ArkadasSilVM vm)
        {
            var result = new ResultModel
            {
                Type = ResultType.Basarisiz
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            if (kullanici != null)
            {
                var kullaniciArkadas = await uyelikDataService.KullaniciArkadasGetir(kullanici.KullaniciId, vm.KullaniciArkadasId);

                if (kullaniciArkadas != null)
                {
                    var kullaniciArkadasPasif = UyelikDomain.ArkadasSil(kullaniciArkadas);

                    var arkadasPasifSonuc = await uyelikDataService.KullaniciArkadasGuncelle(kullaniciArkadasPasif);

                    if (arkadasPasifSonuc == 0)
                    {
                        result.Type = ResultType.Basarili;
                        result.ErrorMessage = $"{kullaniciArkadas.ArkadasKullanici.Adi} {kullaniciArkadas.ArkadasKullanici.Soyadi} arkadaşlarınızdan çıkartılmıştır.";
                        return result;
                    }
                }
            }

            return result;

        }

        public async Task<IPagedList<ArkadasKonusmaListesiVM>> KullaniciMesajListesiGetir(ArkadasMesajListeVM mesajAramaVM)
        {
            var kullanici = await uyelikDataService.KullaniciGetirByToken(mesajAramaVM.Token.RefreshToken);

            return await uyelikDataService.ArkadasMesajListGetir(mesajAramaVM, kullanici.KullaniciId);
        }

        public async Task<ResultModel<List<ArkadasAraSonucVM>>> ArkadasAra(ArkadasAraVM vm)
        {
            var result = new ResultModel<List<ArkadasAraSonucVM>>
            {
                Type = ResultType.Basarisiz
            };

            var arkadasListesi = await uyelikDataService.ArkadasAra(vm);

            if (arkadasListesi != null)
            {
                result.Data = new List<ArkadasAraSonucVM>();

                arkadasListesi.ToList().ForEach(s =>
                {

                    if (s.ArkadasKullanici.KullaniciId != vm.KullaniciId)
                    {
                        var arkadas = new ArkadasAraSonucVM
                        {
                            ArkadasKullaniciId = s.ArkadasKullanici.KullaniciId,
                            Adi = s.ArkadasKullanici.Adi,
                            Soyadi = s.ArkadasKullanici.Soyadi,
                            KullaniciAdi = s.ArkadasKullanici.KullaniciAdi
                        };
                        result.Data.Add(arkadas);
                    }
                    else
                    {
                        var arkadas = new ArkadasAraSonucVM
                        {
                            ArkadasKullaniciId = s.Kullanici.KullaniciId,
                            Adi = s.Kullanici.Adi,
                            Soyadi = s.Kullanici.Soyadi,
                            KullaniciAdi = s.Kullanici.KullaniciAdi
                        };
                        result.Data.Add(arkadas);
                    }
                });

                result.Type = ResultType.Basarili;

                return result;
            }
            return result;
        }

        //TODO ŞG: Üst menü arama alanı için kullanılacak.
        //public async Task<ResultModel<List<HizliArkadasAraSonucVM>>> HizliArkadasAra(HizliArkadasAraVM vm)
        //{
        //    var result = new ResultModel<List<HizliArkadasAraSonucVM>>
        //    {
        //        Type = ResultType.Basarisiz
        //    };

        //    var arkadasListesi = await uyelikDataService.HizliArkadasListeGetir(vm);

        //    return result;
        //}


        public async Task<ResultModel> KonusmaSil(KonusmaSilVM vm)
        {
            var result = new ResultModel()
            {
                Type = ResultType.Basarisiz
            };

            var mesajDetay = new MesajDetayGetirVM
            {
                AliciKullaniciId = vm.SilenKullaniciId,
                GonderenKullaniciId = vm.GonderenKullaniciId
            };

            var silmeSonuc = await uyelikDataService.KonusmaSil(vm, vm.SilenKullaniciId);

            if (silmeSonuc == 0)
            {
                result.Type = ResultType.Basarili;
                result.ErrorMessage = "Konuşma Mesajlarınızdan Kaldırılmıştır";
            }

            return result;
        }

        public async Task<ResultModel> MesajSil(MesajSilVM vm)
        {
            var result = new ResultModel
            {
                Type = ResultType.Belirsiz
            };

            var mesaj = await uyelikDataService.MesajGetir(vm.MesajId);

            if (mesaj.AliciKullaniciId == vm.SilenKullaniciId)
            {
                mesaj.AlanAktifMi = false;
            }
            if (mesaj.GondericiKullaniciId == vm.SilenKullaniciId)
            {
                mesaj.GonderenAktifMi = false;
            }

            var mesajSilSonuc = await uyelikDataService.MesajSil(mesaj);

            if (mesajSilSonuc == 0)
            {
                result.Type = ResultType.Basarili;
            }

            return result;
        }
        public async Task<List<KullaniciHobiVM>> KullaniciHobiGetir(Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciHobiGetir(kullaniciId);
        }
        public async Task<List<KullaniciIlgiAlanVM>> KullaniciIlgiAlanGetir(Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciIlgiAlanGetir(kullaniciId);
        }

        public async Task<List<KullaniciVM>> KisiAra(KisiAraVM vm)
        {
            return await uyelikDataService.KisiAra(vm);
        }

        public async Task<KullaniciVM> KullaniciGetirByKullaniciAdi(string kullaniciAdi)
        {
            return await uyelikDataService.KullaniciGetirByKullaniciAdi(kullaniciAdi);
        }
        public async Task<bool> KullaniciArkadasKullaniciMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            return await uyelikDataService.KullaniciArkadasKullaniciMi(kullaniciId, kullaniciArkadasId);
        }

        public async Task<bool> KullaniciBakilanProfilEkle(KullaniciBakilanProfillerVM bakilanProfil)
        {
            return await uyelikDataService.KullaniciBakilanProfilEkle(bakilanProfil);
        }

        public async Task<bool> KullaniciBakilanProfilSil(BakilanProfilSilVM bakilanProfil)
        {
            return await uyelikDataService.KullaniciBakilanProfilSil(bakilanProfil);
        }

        public async Task<bool> BakilanTumProfilleriSil(KullaniciVM vm)
        {
            return await uyelikDataService.BakilanTumProfilleriSil(vm);
        }

        public async Task<bool> KullaniciArkadasiminArkadasiMi(Guid kullaniciId, Guid kullaniciArkadasId)
        {
            return await uyelikDataService.KullaniciArkadasiminArkadasiMi(kullaniciId, kullaniciArkadasId);

        }
        public async Task<ResultModel<KullaniciAdiVM>> KullaniciAdiGuncelle(KullaniciAdiVM kullanici)
        {
            var kullaniciSonuc = new ResultModel<KullaniciAdiVM>()
            {
                Type = ResultType.Basarisiz
            };

            var kullaniciAdiVarmi = await uyelikDataService.KullaniciAdiVarmi(kullanici);
            if(kullaniciAdiVarmi)
            {
                return kullaniciSonuc;
            }

            var kullaniciGetir = await uyelikDataService.KullaniciGetirByToken(kullanici.Token.RefreshToken);

            var kullaniciAdi = kullanici.KullaniciAdi;
            kullaniciGetir.KullaniciAdi = kullaniciAdi;

            var kullaniciGuncelle = await uyelikDataService.Update(kullaniciGetir);

            kullaniciSonuc.Type = ResultType.Basarili;
            kullaniciSonuc.Data = new KullaniciAdiVM
            { 
                KullaniciAdi = kullanici.KullaniciAdi
            };

            return kullaniciSonuc;
        }
        public async Task<KullaniciVM> KullaniciGetirByKullaniciId(Guid kullaniciId)
        {
            var kullanici = await uyelikDataService.KullaniciGetirById(kullaniciId);
            var kullaniciVM = mapper.Map<Kullanici, KullaniciVM>(kullanici);
            return kullaniciVM;
        }
        public async Task<List<BildirimKullaniciGetirVM>> BildirimKullaniciListGetir(KisiyeOzelBildirimVM data)
        {
            return await uyelikDataService.BildirimKullaniciListGetir(data);
        }

        #region ProfilEngel

        #region Admin

        #endregion

        #region FrontEnd

        public async Task<ProfilEngelVM> ProfilEngelKaydet(ProfilEngelVM model)
        {
            return await uyelikDataService.ProfilEngelKaydet(model);
        }

        public async Task<ProfilEngelVM> ProfilEngelSil(ProfilEngelVM model)
        {
            return await uyelikDataService.ProfilEngelSil(model);
        }

        public async Task<IPagedList<ProfilEngelKisiVM>> ProfilEngelListGetir(EngellenenProfilListesiAramaVM model)
        {
            return await uyelikDataService.ProfilEngelListGetir(model);
        }

        #endregion

        #endregion

        public async Task<ResultModel<List<MesajDetaySonucVM>>> MesajDetayGetir(MesajDetayGetirVM vm)
        {
            var result = new ResultModel<List<MesajDetaySonucVM>>
            {
                Type = ResultType.Basarisiz
            };

            var mesajlar = await uyelikDataService.MesajDetayGetir(vm);
            //TODO buraya mesajı okuma yapılacak.

            if (mesajlar != null)
            {
                result.Data = new List<MesajDetaySonucVM>();

                mesajlar.ToList().ForEach(s =>
                {
                    var mesajDetay = new MesajDetaySonucVM
                    {
                        MesajId = s.KullaniciMesajId,
                        AliciKullanici = mapper.Map<Kullanici, KullaniciVM>(s.AliciKullanici),
                        GonderenKullanici = mapper.Map<Kullanici, KullaniciVM>(s.GondericiKullanici),
                        KayitTarihi = s.KayitTarih,
                        Mesaj = s.MesajIcerik
                    };
                    result.Data.Add(mesajDetay);
                });
                result.Type = ResultType.Basarili;
                return result;
            }
            return result;
        }

        public async Task<ProfilSagMenuVM> ProfilSagMenuGetir(ProfilSagMenuAraVM model)
        {
            return await uyelikDataService.ProfilSagMenuGetir(model);
        }

        public async Task<ResultModel> ProfilArkadasEkle(ArkadaslikIstegiGonderVM vm)
        {
            var arkadasIstekGonderSonuc = new ResultModel()
            {
                Type = ResultType.Basarisiz,
                ErrorMessage = "istekVar"
            };

            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            bool arkadaslikIstekVarmi = await uyelikDataService.ArkadasIstekVarMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

            bool arkadaslikVarmi = await uyelikDataService.KullaniciArkadasKullaniciMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

            if (arkadaslikVarmi)
            {
                arkadasIstekGonderSonuc.ErrorMessage = "arkadaslikVar";
            }
            else
            {
                if (!arkadaslikIstekVarmi)
                {
                    if (kullanici != null)
                    {
                        var arkadaslikIstekDurum = await uyelikDataService.ArkadaslikIstekDurumGetir(vm.IstekGonderilenKullaniciId);

                        if (arkadaslikIstekDurum == 3)
                        {
                            var arkadasiminArkadasimi = await uyelikDataService.KullaniciArkadasiminArkadasiMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

                            if (arkadasiminArkadasimi)
                            {
                                arkadasIstekGonderSonuc.Type = ResultType.Basarili;
                                arkadasIstekGonderSonuc.ErrorMessage = "Arkadaslik İstegi Gonderildi";
                            }
                            else
                            {
                                arkadasIstekGonderSonuc.Type = ResultType.Basarisiz;
                                arkadasIstekGonderSonuc.ErrorMessage = "ArkadasiminArkadasiDegil";
                                return arkadasIstekGonderSonuc;
                            }
                        }

                        var arkadaslikIstek = UyelikDomain.KullaniciIstekKaydet(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);

                        var arkadaslikIstekKayitSonuc = await uyelikDataService.ArkadasIstekKaydet(arkadaslikIstek);

                        if (arkadaslikIstekKayitSonuc == 0)
                        {
                            arkadasIstekGonderSonuc.Type = ResultType.Basarili;
                            arkadasIstekGonderSonuc.ErrorMessage = "Arkadaslik İstegi Gonderildi";
                            return arkadasIstekGonderSonuc;
                        }
                    }
                }
            }

            var banaIstekVarmi = await uyelikDataService.BanaArkadaslikIstekVarMi(kullanici.KullaniciId, vm.IstekGonderilenKullaniciId);
            if (banaIstekVarmi)
            {
                arkadasIstekGonderSonuc.ErrorMessage = "banaIstekVar";
            }

            return arkadasIstekGonderSonuc;
        }

        #region ProfilSikayet

        #region Admin
        public async Task<List<ProfilSikayetAramaSonucVM>> ProfilSikayetArama(ProfilSikayetAramaVM model)
        {
            return await uyelikDataService.ProfilSikayetArama(model);
        }
        #endregion

        #region FrontEnd

        public async Task<bool> ProfilSikayetKaydet(ProfilSikayetVM model)
        {
            return await uyelikDataService.ProfilSikayetKaydet(model);
        }

        #endregion

        #endregion

        #region KullaniciHobi

        #region Admin       

        #endregion

        #region FrontEnd
        public async Task<IEnumerable<KullaniciHobiVM>> HobileriGetir(string query)
        {
            List<KullaniciHobiVM> hobiler = new List<KullaniciHobiVM>();

            var hobilerSonuc = await uyelikDataService.HobileriGetir(query);

            hobilerSonuc.ToList().ForEach(s =>
            {
                var hobi = new KullaniciHobiVM()
                {
                    id = s.HobiId,
                    value = s.HobiAdi.Trim()
                };

                hobiler.Add(hobi);
            });

            return hobiler;
        }

        public async Task<KullaniciHobiVeIlgiAlanVM> KullaniciHobiIlgiAlanGetir(Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciHobiIlgiAlanGetir(kullaniciId);
        }

        public async Task<bool> KullaniciHobiKaydetGuncelle(KullaniciHobiKaydetGuncelleVM model)
        {
            return await uyelikDataService.KullaniciHobiKaydetGuncelle(model);
        }
        public async Task<bool> KullaniciIlgiAlanKaydetGuncelle(KullaniciIlgiAlanKaydetGuncelleVM model)
        {
            return await uyelikDataService.KullaniciIlgiAlanKaydetGuncelle(model);
        }
        #endregion

        #endregion

        #region KullaniciIlgiAlan

        #region Admin       

        #endregion

        #region FrontEnd
        public async Task<IEnumerable<KullaniciIlgiAlanVM>> IlgiAlanGetir(string query)
        {
            List<KullaniciIlgiAlanVM> ilgiAlanlari = new List<KullaniciIlgiAlanVM>();

            var ilgiAlanlariSonuc = await uyelikDataService.IlgiAlanlariniGetir(query);

            ilgiAlanlariSonuc.ToList().ForEach(s =>
            {
                var ilgiAlan = new KullaniciIlgiAlanVM()
                {
                    id = s.IlgiAlanId,
                    value = s.IlgiAlanAdi.Trim()
                };

                ilgiAlanlari.Add(ilgiAlan);
            });

            return ilgiAlanlari;
        }
        #endregion

        #endregion

        #region KullaniciUrun

        #region Admin       

        #endregion

        #region FrontEnd

        public async Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeEkle(KullaniciUrunEkleSilVM model)
        {
            return await uyelikDataService.KullaniciHediyeEkle(model);
        }

        public async Task<KullaniciUrunEkleSilSonucVM> KullaniciHediyeSil(KullaniciUrunEkleSilVM model)
        {
            return await uyelikDataService.KullaniciHediyeSil(model);
        }

        public async Task<IPagedList<UrunIcerikVM>> KullaniciHediyeSepetiGetir(KullaniciUrunListesiAramaVM model)
        {
            return await uyelikDataService.KullaniciHediyeSepetiGetir(model);
        }

        public async Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciArkadasListesiModalGetir(KullaniciArkadasListesiModalAramaVM model)
        {
            return await uyelikDataService.KullaniciArkadasListesiModalGetir(model);
        }

        public async Task<int> KullaniciHediyeSepetiSayisiGetir(Guid kullaniciId)
        {
            return uyelikDataService.KullaniciHediyeSepetiSayisiGetir(kullaniciId);
        }

        public async Task<int> KullaniciArkadasSayisiGetir(Guid kullaniciId)
        {
            return uyelikDataService.KullaniciArkadasSayisiGetir(kullaniciId);
        }

        public async Task<int> KullaniciMesajSayisiGetir(Guid kullaniciId)
        {
            return uyelikDataService.KullaniciMesajSayisiGetir(kullaniciId);
        }

        public async Task<int> KullaniciBildirimSayisiGetir(Guid kullaniciId)
        {
            return uyelikDataService.KullaniciBildirimSayisiGetir(kullaniciId);
        }

        public async Task<int> KullaniciArkadasIstekSayisiGetir(Guid kullaniciId)
        {
            return uyelikDataService.KullaniciArkadasIstekSayisiGetir(kullaniciId);
        }

        public async Task<int> KullaniciHediyeKartiSayisiGetir(Guid kullaniciId)
        {
            return uyelikDataService.KullaniciHediyeKartiSayisiGetir(kullaniciId);
        }

        public async Task<IPagedList<ArkadasListesiKullaniciArkadasVM>> KullaniciBakilanProfilleriGetir(KullaniciArkadasListesiModalAramaVM model)
        {
            return await uyelikDataService.KullaniciBakilanProfillerModalGetir(model);
        }
        #endregion

        #endregion

        #region KullaniciResim
        public async Task<KullaniciResimVM> KullaniciProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResim)
        {
            KullaniciResim kullaniciResimDb = await uyelikDataService.KullaniciProfilResimKaydetGuncelle(kullaniciResim);
            return mapper.Map<KullaniciResim, KullaniciResimVM>(kullaniciResimDb);
        }
        public async Task<KullaniciResimVM> KullaniciResimKaydet(KullaniciResimVM kullaniciResimVM)
        {
            KullaniciResim kullaniciResim = mapper.Map<KullaniciResimVM, KullaniciResim>(kullaniciResimVM);
            kullaniciResim = await uyelikDataService.KullaniciResimKaydet(kullaniciResim);
            return mapper.Map<KullaniciResim, KullaniciResimVM>(kullaniciResim);
        }
        public async Task<KullaniciResimVM> KullaniciResimGetir(Guid kullaniciId)
        {

            return await uyelikDataService.KullaniciResimGetir(kullaniciId);
        }
        public async Task<List<KullaniciResimVM>> KullaniciResimListele(string kullaniciId)
        {

            return await uyelikDataService.KullaniciResimListele(kullaniciId);
        }

        public async Task<int> ProfilResminiDegistir(Guid kullaniciId, int resimId)
        {

            return await uyelikDataService.ProfilResminiDegistir(kullaniciId, resimId);
        }
        public async Task<int> KullaniciResimSil(Guid kullaniciId, int resimId)
        {

            return await uyelikDataService.KullaniciResimSil(kullaniciId, resimId);
        }

        public async Task<IPagedList<KullaniciResimVM>> KullaniciListesiResimGetir(int start, int length, Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciListesiResimGetir(start, length, kullaniciId);
        }

        public async Task<KullaniciResimVM> KullaniciResimGetirByResimId(int resimId)
        {
            return await uyelikDataService.KullaniciResimGetirByResimId(resimId);
        }
        public async Task<KullaniciResim> KullaniciProfilResmiSil(KullaniciResim kullaniciResim)
        {
            return await uyelikDataService.KullaniciProfilResmiSil(kullaniciResim);
        }
        public async Task<KullaniciResim> KullaniciProfilResimGetir(string kullaniciId)
        {
            return await uyelikDataService.KullaniciProfilResimGetir(kullaniciId);

        }
        public async Task<int> KullaniciResimSayisiGetir(Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciResimSayisiGetir(kullaniciId);
        }
        public async Task<KullaniciResimVM> KullaniciBuyukProfilResimKaydetGuncelle(KullaniciResimVM kullaniciResimVM)
        {
            KullaniciResim kullaniciResimDb = await uyelikDataService.KullaniciBuyukProfilResimKaydetGuncelle(kullaniciResimVM);
            return mapper.Map<KullaniciResim, KullaniciResimVM>(kullaniciResimDb);
        }
        public async Task<KullaniciResimVM> KullaniciBuyukProfilResimGetir(Guid KullaniciId)
        {
            KullaniciResim kullaniciResimDb = await uyelikDataService.KullaniciBuyukProfilResimGetir(KullaniciId);          
            var resimVM = mapper.Map<KullaniciResim, KullaniciResimVM>(kullaniciResimDb);

            if(resimVM != null)
            {
                resimVM.ResimBase64 = Convert.ToBase64String(resimVM.Resim);
            }
            
            return resimVM;

        }
        #endregion

        #region DuvarResim

        public async Task<List<DuvarResimVM>> DuvarResimleriniGetir()
        {

            return await uyelikDataService.DuvarResimleriniGetir();
        }
        public async Task<int> KullaniciDuvarResimDegistir(Guid kullaniciId, int resimId)
        {

            return await uyelikDataService.KullaniciDuvarResimDegistir(kullaniciId, resimId);
        }
        public async Task<DuvarResimVM> KullaniciDuvarResimGetir(Guid kullaniciId)
        {

            return await uyelikDataService.KullaniciDuvarResimGetir(kullaniciId);
        }



        #endregion

        #region KullaniciHediyeKart
        public async Task<ResultModel> KullaniciHediyeKartKayit(KullaniciHediyeKartKayitVM model)
        {
            ResultModel sonuc = new ResultModel();
            if (model.GonderenKullaniciId == model.AliciKullaniciId)
            {
                sonuc.Type=ResultType.Basarisiz;
                sonuc.ErrorMessage="Gönderici ve alıcı aynı olamaz";
            }
            else
            {
                int Id = await uyelikDataService.KullaniciHediyeKartKayit(model);
                if (Id > 0)
                {

                    sonuc.Type = ResultType.Basarili;
                }
                else
                {
                    sonuc.Type = ResultType.Basarisiz;
                }
            }
            

            return sonuc;
        }

        public async Task<IPagedList<HediyeKartKonusmaListesiVM>> KullaniciHediyeKartListesiGetir(HediyeKartListeVM hediyeKartListeVM)
        {
            var kullanici = await uyelikDataService.KullaniciGetirByToken(hediyeKartListeVM.Token.RefreshToken);

            return await uyelikDataService.HediyeKartListGetir(hediyeKartListeVM, kullanici.KullaniciId);
        }


        public async Task<ResultModel<List<HediyeKartDetaySonucVM>>> HediyeKartDetayGetir(HediyeKartDetayGetirVM vm)
        {
            var result = new ResultModel<List<HediyeKartDetaySonucVM>>
            {
                Type = ResultType.Basarisiz
            };

            var mesajlar = await uyelikDataService.HediyeKartDetayGetir(vm);


            if (mesajlar != null)
            {
                result.Data = new List<HediyeKartDetaySonucVM>();

                mesajlar.ToList().ForEach(s =>
                {
                    var hediyeDetay = new HediyeKartDetaySonucVM
                    {
                        HediyeKartId = s.KullaniciHediyeKartId,
                        AliciKullanici = mapper.Map<Kullanici, KullaniciVM>(s.AliciKullanici),
                        GonderenKullanici = mapper.Map<Kullanici, KullaniciVM>(s.GonderenKullanici),
                        HediyeKart = mapper.Map<HediyeKart, HediyeKartVM>(s.HediyeKart),
                        KayitTarihi = s.KayitTarih,
                        Aciklama = s.Aciklama
                    };
                    hediyeDetay.HediyeKart.Resim = Convert.ToBase64String(s.HediyeKart.Resim);
                    result.Data.Add(hediyeDetay);
                });
                result.Type = ResultType.Basarili;
                return result;
            }
            return result;
        }

        public async Task<ResultModel> HediyeKartSil(HediyeKartSilVM vm)
        {
            var result = new ResultModel
            {
                Type = ResultType.Belirsiz
            };

            var hediyeKart = await uyelikDataService.HediyeKartGetir(vm.HediyeKartId);

            if (hediyeKart.AliciKullaniciId == vm.SilenKullaniciId)
            {
                hediyeKart.AlanAktifMi = false;
            }
            if (hediyeKart.GonderenKullaniciId == vm.SilenKullaniciId)
            {
                hediyeKart.GonderenAktifMi = false;
            }

            var hediyeKartSonuc = await uyelikDataService.HediyeKartSil(hediyeKart);

            if (hediyeKartSonuc == 0)
            {
                result.Type = ResultType.Basarili;
            }

            return result;
        }
        public async Task<ResultModel> HediyeKartKonusmaSil(KonusmaSilVM vm)
        {
            var result = new ResultModel()
            {
                Type = ResultType.Basarisiz
            };

            var silmeSonuc = await uyelikDataService.HediyeKartKonusmaSil(vm, vm.SilenKullaniciId);

            if (silmeSonuc > 0)
            {
                result.Type = ResultType.Basarili;
                result.ErrorMessage = silmeSonuc.ToString();
            }

            return result;
        }
        public async Task<HediyeKartIcerikVM> HediyeKartMesajIcerikGetirById(int id)
        {
            return await uyelikDataService.HediyeKartMesajIcerikGetirById(id);
        }
        public async Task<int> HediyeKartOkunduIsaretle(HediyeKartOkunduVM hediyeKartOkundu)
        {
            return await uyelikDataService.HediyeKartOkunduIsaretle(hediyeKartOkundu);
        }
        #endregion

        #region KullaniciBildirim
        public async Task<IPagedList<KullaniciBildirimVM>> KullaniciBildirimListGetir(KullaniciBildirimListeVM model)
        {
            return await uyelikDataService.KullaniciBildirimListGetir(model);
        }

        public async Task<bool> KullaniciBildirimEkle(KullaniciBildirimVM kullaniciBildirim)
        {
            return await uyelikDataService.KullaniciBildirimEkle(kullaniciBildirim);
        }
        public async Task<bool> KullaniciBildirimSil(KullaniciBildirimVM kullaniciBildirim)
        {
            return await uyelikDataService.KullaniciBildirimSil(kullaniciBildirim);
        }
        public async Task<List<KullaniciBildirimVM>> KullaniciHeaderBildirimListGetir(Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciHeaderBildirimListGetir(kullaniciId);
        }
        public async Task<bool> KullaniciBildirimOkundu(Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciBildirimOkundu(kullaniciId);
        }
        public async Task<int> TopluBildirimGonder(IletisimTopluBildirimVM bildirim)
        {
            return await uyelikDataService.TopluBildirimGonder(bildirim);
        }
        public async Task<List<BildirimAramaResultVM>> TumBildirimleriGetir(BildirimAramaVM bildirimAramaVM)
        {
            return await uyelikDataService.TumBildirimleriGetir(bildirimAramaVM);
        }
        public async Task<int> BildirimSil(int id)
        {
            return await uyelikDataService.BildirimSil(id);
        }
        public async Task<bool> KullaniciTumBildirimleriSil(Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciTumBildirimleriSil(kullaniciId);
        }
        public async Task<int> BildirimSayisiGetir(IletisimTopluBildirimVM bildirim)
        {
            return await uyelikDataService.BildirimSayisiGetir(bildirim);
        }
        public async Task<int> KisiyeOzelBildirimGonder(KisiyeOzelBildirimVM bildirim)
        {
            return await uyelikDataService.KisiyeOzelBildirimGonder(bildirim);
        }
        public async Task<KullaniciBildirimVM> BildirimIdBildirimGetir(int id)
        {
            return await uyelikDataService.BildirimIdBildirimGetir(id);
        }
        public async Task<List<KisiyeOzelBildirimAramaSonucVM>> KisiyeOzelBildirimleriGetir(BildirimAramaVM bildirimAramaVM)
        {
            return await uyelikDataService.KisiyeOzelBildirimleriGetir(bildirimAramaVM);
        }
        public async Task<int> KullaniciHeaderSepetUrunSayisiGetir(Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciHeaderSepetUrunSayisiGetir(kullaniciId);
        }
        #endregion

        #region Şifremi Unuttum
        public async Task<ResultModel> KullaniciYeniSifreGonder(KullaniciSifreGonderVM model)
        {
            NeSever.Common.Models.Program.AyarlarVM ayarlarModel = new NeSever.Common.Models.Program.AyarlarVM();
            ayarlarModel = await programDataService.AyarlarBilgileriniGetir();
            return await uyelikDataService.KullaniciYeniSifreGonder(model, ayarlarModel);
        }



        #endregion


        #region Kullanıcı Künye
        public async Task<int> KullaniciOkunmamisArkadaslikIstegiSayisiGetir(Guid kullaniciId)
        {
            return await uyelikDataService.KullaniciOkunmamisArkadaslikIstegiSayisiGetir(kullaniciId);
        }
        #endregion



        #region Kullanıcı Mesaj

        public async Task<int> OkunmamisMesajSayisiGetir(Guid kullaniciId)
        {
            return await uyelikDataService.OkunmamisMesajSayisiGetir(kullaniciId);
        }
        public async Task<int> ProfilEngelSayisiGetir(Guid kullaniciId)
        {
            return await uyelikDataService.ProfilEngelSayisiGetir(kullaniciId);
        }

        public async Task<ResultModel> MesajlariOku(MesajDetayGetirVM vm)
        {
            var islemSonuc = new ResultModel()
            {
                Type = ResultType.Basarisiz
            };
            var kullanici = await uyelikDataService.KullaniciGetirByToken(vm.Token.RefreshToken);

            if (kullanici == null)
            {
                islemSonuc.Type = ResultType.Basarisiz;
                islemSonuc.ErrorMessage = "Kullanici Bilgileri Getirilirken Hata Oluştu";
                return islemSonuc;
            }
            var okunmamisMesajListesi = await uyelikDataService.OkunmamisMesajlariGetir(vm);
            if (okunmamisMesajListesi.Count() > 0)
            {
                var mesajlariOku = UyelikDomain.MesajlariOku(okunmamisMesajListesi.ToList());
                var mesajlariOkuSonuc = await uyelikDataService.MesajlariOku(mesajlariOku);
                islemSonuc.Type = ResultType.Basarili;
            }
            else
            {
                islemSonuc.Type = ResultType.Basarisiz;
            }
            return islemSonuc;
        }
        #endregion
    }
}
