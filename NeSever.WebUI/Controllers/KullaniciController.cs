using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Urun;
using NeSever.Common.Models.Uyelik;
using NeSever.Data.Entities;
using NeSever.WebUI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace NeSever.WebUI.Controllers
{
    public class KullaniciController : BaseController
    {
        private readonly IUyelikApiService uyelikApiService;
        private readonly ISayfaApiService sayfaApiService;

        public KullaniciController(ILogger<BaseController> logger,
                                   IUyelikApiService uyelikApiService,
                                   ISayfaApiService sayfaApiService) : base(logger, uyelikApiService)
        {
            this.uyelikApiService = uyelikApiService;
            this.logger = logger;
            this.sayfaApiService = sayfaApiService;
        }

        [HttpPost]
        public async Task<TokenVM> KullaniciGiris(KullaniciGirisVM kullanici)
        {
            var kullaniciGirisResult = await uyelikApiService.KullaniciGiris(kullanici);
            if (kullaniciGirisResult != null)
            {
                HttpContext.Session.SetString("Kullanici", JsonConvert.SerializeObject(kullaniciGirisResult));
                var kullaniciBilgileri = await uyelikApiService.KullaniciGetir(kullaniciGirisResult);
                if (kullaniciBilgileri != null)
                {
                    HttpContext.Session.SetString("KullaniciBilgileri", JsonConvert.SerializeObject(kullaniciBilgileri));

                    var kullaniciResim = await uyelikApiService.KullaniciResimGetir(kullaniciBilgileri.KullaniciId);
                    if (kullaniciResim != null)
                    {
                        HttpContext.Session.SetString("KullaniciResim", JsonConvert.SerializeObject(kullaniciResim));
                    }
                }

            }
            return kullaniciGirisResult;
        }

        [HttpPost]
        public async Task<TokenVM> KullaniciFbGiris(KullaniciFbGirisVM kullanici)
        {
            kullanici.Last_Name = kullanici.Last_Name == null ? "*" : kullanici.Last_Name;

            var kullaniciGirisResult = await uyelikApiService.KullaniciFbGiris(kullanici);

            if (kullaniciGirisResult.Type == ResultType.Basarili)
            {
                HttpContext.Session.SetString("Kullanici", JsonConvert.SerializeObject(kullaniciGirisResult.Data));
                var kullaniciBilgileri = await uyelikApiService.KullaniciGetir(kullaniciGirisResult.Data);
                HttpContext.Session.SetString("KullaniciBilgileri", JsonConvert.SerializeObject(kullaniciBilgileri));

                var kullaniciResim = await uyelikApiService.KullaniciResimGetir(kullaniciBilgileri.KullaniciId);
                HttpContext.Session.SetString("KullaniciResim", JsonConvert.SerializeObject(kullaniciResim));

                if (kullaniciGirisResult.ErrorMessage == "IlkGiris")
                {
                    var kullaniciBildirim = new KullaniciBildirimVM()
                    {
                        KullaniciId = kullaniciBilgileri.KullaniciId,
                        BildirimTipId = 1,
                        BildirimIcerik = "Aramıza hoşgeldin.<a href=\"/Hediye/Ara?q=\" style=\"display:unset!important;\"> Hediyelerini seçip </a> arkadaşlıklarını kurmaya başlayabilirsin."
                    };
                    var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
                    HttpContext.Session.SetString("IlkGiris", JsonConvert.SerializeObject(kullaniciGirisResult.ErrorMessage));
                }
            }
            return kullaniciGirisResult.Data;
        }


        [HttpPost]
        public async Task<TokenVM> KullaniciInstegramGiris(KullaniciInstegramGirisVM kullanici)
        {
            var kullaniciGirisResult = await uyelikApiService.KullaniciInstegramGiris(kullanici);

            if (kullaniciGirisResult.Type == ResultType.Basarili)
            {
                HttpContext.Session.SetString("Kullanici", JsonConvert.SerializeObject(kullaniciGirisResult.Data));
                var kullaniciBilgileri = await uyelikApiService.KullaniciGetir(kullaniciGirisResult.Data);
                HttpContext.Session.SetString("KullaniciBilgileri", JsonConvert.SerializeObject(kullaniciBilgileri));

                var kullaniciResim = await uyelikApiService.KullaniciResimGetir(kullaniciBilgileri.KullaniciId);
                HttpContext.Session.SetString("KullaniciResim", JsonConvert.SerializeObject(kullaniciResim));
            }
            return kullaniciGirisResult.Data;
        }


        [HttpPost]
        public async Task<TokenVM> KullaniciGoogleGiris(KullaniciGoogleGirisVM kullanici)
        {
            kullanici.Lastname = kullanici.Lastname == null ? "*" : kullanici.Lastname;

            var kullaniciGirisResult = await uyelikApiService.KullaniciGoogleGiris(kullanici);

            if (kullaniciGirisResult.Type == ResultType.Basarili)
            {
                HttpContext.Session.SetString("Kullanici", JsonConvert.SerializeObject(kullaniciGirisResult.Data));
                var kullaniciBilgileri = await uyelikApiService.KullaniciGetir(kullaniciGirisResult.Data);
                HttpContext.Session.SetString("KullaniciBilgileri", JsonConvert.SerializeObject(kullaniciBilgileri));

                var kullaniciResim = await uyelikApiService.KullaniciResimGetir(kullaniciBilgileri.KullaniciId);
                HttpContext.Session.SetString("KullaniciResim", JsonConvert.SerializeObject(kullaniciResim));

                if (kullaniciGirisResult.ErrorMessage == "IlkGiris")
                {
                    var kullaniciBildirim = new KullaniciBildirimVM()
                    {
                        KullaniciId = kullaniciBilgileri.KullaniciId,
                        BildirimTipId = 1,
                        BildirimIcerik = "Aramıza hoşgeldin.<a href=\"/Hediye/Ara?q=\" style=\"display:unset!important;\"> Hediyelerini seçip </a> arkadaşlıklarını kurmaya başlayabilirsin."
                    };
                    var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
                    HttpContext.Session.SetString("IlkGiris", JsonConvert.SerializeObject(kullaniciGirisResult.ErrorMessage));
                }
            }
            return kullaniciGirisResult.Data;
        }

        [HttpPost]
        public async Task<bool> KullaniciCikis()
        {
            HttpContext.Session.Clear();
            if (HttpContext.Session.GetString("Kullanici") == null)
                return true;

            return false;
        }

        public IActionResult Islem()
        {
            //if (HttpContext.Session.GetString("Kullanici") != null)            
            //    return RedirectToAction("Index", "Home");            

            return View();
        }

        public async Task<IActionResult> Profil(string id)
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (string.IsNullOrEmpty(id))
            {
                if (session == null)
                    return RedirectToAction("Index", "Home");

                var token = JsonConvert.DeserializeObject<TokenVM>(session);

                var kullanici = await uyelikApiService.KullaniciGetir(token);
                var kullaniciProfil = await uyelikApiService.ArkadasProfilGetir(new ArkadasProfilGetirVM
                {
                    KullaniciAdi = kullanici.KullaniciAdi,
                    Token = token
                });

                if (kullaniciProfil == null || kullaniciProfil.Data == null)
                    return RedirectToAction("ProfilBulunamadi", "Kullanici");

                kullaniciProfil.Data.UyeData.DisKullanici = false;
                kullaniciProfil.Data.UyeData.ArkadasProfil = false;
                kullaniciProfil.Data.SolMenuData.ArkadasProfil = false;
                kullaniciProfil.Data.SolMenuData.ProfilKullaniciMi = true;
                ViewBag.Uye = kullaniciProfil.Data.UyeData;

                var IlkGiris = HttpContext.Session.GetString("IlkGiris");
                if (IlkGiris == "\"IlkGiris\"")
                {
                    TempData["IlkGiris"] = "IlkGiris";
                    HttpContext.Session.SetString("IlkGiris", JsonConvert.SerializeObject("Hayir"));
                }

                return View(kullaniciProfil.Data);
            }
            else
            {
                var arkadasProfil = await uyelikApiService.ArkadasProfilGetir(new ArkadasProfilGetirVM
                {
                    KullaniciAdi = id,
                    //Token = token
                });

                if (arkadasProfil == null || arkadasProfil.Data == null)
                    return RedirectToAction("ProfilBulunamadi", "Kullanici");

                if (session == null)
                {
                    arkadasProfil.Data.UyeData.DisKullanici = true;
                    int profilGoruntulemeDurum = arkadasProfil.Data.UyeData.ProfilGoruntulemeDurum;
                    // Herkese açık profil değil ise SayfaDurum Gizli
                    if (profilGoruntulemeDurum != 2)
                        ViewBag.SayfaDurum = "Bu profil gizlidir";
                }
                else
                {
                    arkadasProfil.Data.UyeData.DisKullanici = false;

                    var token = JsonConvert.DeserializeObject<TokenVM>(session);
                    var kullanici = await uyelikApiService.KullaniciGetir(token);

                    if (kullanici != null && kullanici.KullaniciId != arkadasProfil.Data.UyeData.KullaniciId)
                    {
                        KullaniciBakilanProfillerVM bakilanProfil = new KullaniciBakilanProfillerVM()
                        {
                            KullaniciId = kullanici.KullaniciId,
                            BakilanKullaniciId = arkadasProfil.Data.UyeData.KullaniciId
                        };
                        var sonuc = await uyelikApiService.KullaniciBakilanProfilEkle(bakilanProfil);

                        var kullaniciBildirim = new KullaniciBildirimVM()
                        {
                            KullaniciId = arkadasProfil.Data.UyeData.KullaniciId,
                            BildirimTipId = 6,
                            BildirimIcerik = "<a href=\"/Kullanici/Profil/" + kullanici.KullaniciAdi + "\" style=\"display:unset!important;\"> " + kullanici.KullaniciAdi + "</a> profilinize baktı."
                        };
                        var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
                    }

                    int profilGoruntulemeDurum = arkadasProfil.Data.UyeData.ProfilGoruntulemeDurum;
                    var arkadasKullaniciMi = await uyelikApiService.KullaniciArkadasKullaniciMi(kullanici.KullaniciId, arkadasProfil.Data.UyeData.KullaniciId);
                    arkadasProfil.Data.UyeData.KullaniciArkadasiMi = arkadasKullaniciMi;

                    switch (profilGoruntulemeDurum)
                    {
                        case 1: // Sadece Arkadaşlar
                            if (!arkadasKullaniciMi)
                                ViewBag.SayfaDurum = "Bu profil gizlidir";
                            break;
                        case 2: // Herkes

                            break;
                        case 3: // Arkadaşımın Arkadaşları
                            var arkadasiminArkadasiMi = await uyelikApiService.KullaniciArkadasiminArkadasiMi(kullanici.KullaniciId, arkadasProfil.Data.UyeData.KullaniciId);
                            if (!arkadasiminArkadasiMi)
                                ViewBag.SayfaDurum = "Bu profil gizlidir";
                            break;
                    }

                }

                arkadasProfil.Data.UyeData.ArkadasProfil = true;
                arkadasProfil.Data.SolMenuData.ArkadasProfil = true;
                arkadasProfil.Data.SolMenuData.ProfilGoruntulenmeSayisi = await uyelikApiService.KullaniciProfilGoruntulenmeSayisiGetir(arkadasProfil.Data.UyeData.KullaniciId);
                ViewBag.Uye = arkadasProfil.Data.UyeData;

                return View(arkadasProfil.Data);
            }
        }

        public async Task<JsonResult> MenuDegerleri()
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                return Json(false);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return Json(false);
            }

            var menuDegerleri = await uyelikApiService.ArkadasMenuDegerleriGetir(token);
            return Json(menuDegerleri.Data);
        }

        public IActionResult ProfilBulunamadi()
        {
            return View("~/Views/Shared/ProfilBulunamadi.cshtml");
        }

        [HttpPost]
        public async Task<JsonResult> ProfilSikayetKaydet(ProfilSikayetVM model)
        {
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullanici = await uyelikApiService.KullaniciGetir(token);

            if (model.SikayetEdilenKullaniciId == Guid.Empty)
            {
                return Json(new { error = true, message = "Kendi Profilinizi Şikayet Edemezsiniz." });
            }
            else
            {
                if (kullanici == null)
                    return Json(new { error = true, message = "Giriş Yapmış Kullanıcı Bulunamadı." });
                else if (model.SikayetEdilenKullaniciId == kullanici.KullaniciId)
                    return Json(new { error = true, message = "Kendi Profilinizi Şikayet Edemezsiniz." });
                else
                {
                    model.SikayetEdenKullaniciId = kullanici.KullaniciId;

                    var result = await uyelikApiService.ProfilSikayetKaydet(model);
                    return Json(new { error = !result, message = (result ? "İşlem Başarılı" : "İşlem Sırasında Bir Hata Oluştu") });
                }
            }
        }

        [HttpPost]
        public async Task<JsonResult> ProfilEngelKaydet(ProfilEngelVM model)
        {
            if (HttpContext.Session.GetString("Kullanici") == null)
            {
                return Json(new { error = true, message = "Kullanıcı Girişi Yapmadınız." });
            }
            else
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
                var kullanici = await uyelikApiService.KullaniciGetir(token);

                if (kullanici == null)
                    return Json(new { error = true, message = "kullanici" });
                else if (model.ProfilEngellenenKullaniciId == kullanici.KullaniciId)
                    return Json(new { error = true, message = "Kendi Profilinizi Engelleyemezsiniz." });
                else
                {
                    model.ProfilEngelleyenKullaniciId = kullanici.KullaniciId;

                    var result = await uyelikApiService.ProfilEngelKaydet(model);
                    return Json(new { error = result.Hata, message = result.Mesaj });
                }
            }
        }

        [HttpPost]
        public async Task<JsonResult> ProfilEngelSil(ProfilEngelVM model)
        {
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullanici = await uyelikApiService.KullaniciGetir(token);

            if (kullanici == null)
                return Json(new { error = true, message = "Giriş Yapmış Kullanıcı Bulunamadı." });
            else
            {
                model.ProfilEngelleyenKullaniciId = kullanici.KullaniciId;

                var result = await uyelikApiService.ProfilEngelSil(model);
                return Json(new { error = result.Hata, message = result.Mesaj });
            }
        }

        [HttpPost]
        public async Task<ResultModel<TokenVM>> KullaniciKaydet(KullaniciKayitVM kullanici)
        {
            ResultModel<TokenVM> kullaniciKayitResult = new ResultModel<TokenVM>();

            if (ModelState.IsValid)
            {
                if (kullanici.KullaniciKayitKullaniciAdi.Length < 3)
                {
                    kullaniciKayitResult.Type = ResultType.Basarisiz;
                    kullaniciKayitResult.ErrorMessage = "MinLength";
                    return kullaniciKayitResult;
                }
                string[] Harfler = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", "_" };
                foreach (var item in kullanici.KullaniciKayitKullaniciAdi)
                {
                    string karakter = item.ToString();
                    if (!Harfler.Any(karakter.Contains))
                    {
                        kullaniciKayitResult.Type = ResultType.Basarisiz;
                        kullaniciKayitResult.ErrorMessage = "TurkceKarakter";
                        return kullaniciKayitResult;
                    }
                }
                for (var i = 0; i < 3; i++)
                {
                    if (kullanici.KullaniciKayitKullaniciAdi[i] == '.' || kullanici.KullaniciKayitKullaniciAdi[i] == '_')
                    {
                        kullaniciKayitResult.Type = ResultType.Basarisiz;
                        kullaniciKayitResult.ErrorMessage = "IlkUcKarakter";
                        return kullaniciKayitResult;
                    }
                }

                kullaniciKayitResult = await uyelikApiService.KullaniciKaydet(kullanici);
                var kullaniciBilgileri = new KullaniciVM();

                if (kullaniciKayitResult.Type == ResultType.Basarili)
                {
                    HttpContext.Session.SetString("Kullanici", JsonConvert.SerializeObject(kullaniciKayitResult.Data));
                    kullaniciBilgileri = await uyelikApiService.KullaniciGetir(kullaniciKayitResult.Data);
                    HttpContext.Session.SetString("KullaniciBilgileri", JsonConvert.SerializeObject(kullaniciBilgileri));
                    var kullaniciBildirim = new KullaniciBildirimVM()
                    {
                        KullaniciId = kullaniciBilgileri.KullaniciId,
                        BildirimTipId = 1,
                        BildirimIcerik = "Aramıza hoşgeldin.<a href=\"/Hediye/Ara?q=\" style=\"display:unset!important;\"> Hediyelerini seçip </a> arkadaşlıklarını kurmaya başlayabilirsin."
                    };
                    var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
                }
            }
            else
            {
                kullaniciKayitResult.Type = ResultType.Basarisiz;
                kullaniciKayitResult.ErrorMessage = "Lütfen Bütün Alanları Doldurunuz.";
            }

            return kullaniciKayitResult;
        }

        public async Task<IActionResult> Arkadaslar()
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
                return RedirectToAction("Index", "Home");

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            var kullaniciProfil = await uyelikApiService.ArkadasProfilGetir(new ArkadasProfilGetirVM
            {
                KullaniciAdi = kullanici.KullaniciAdi,
                Token = token
            });

            if (kullaniciProfil == null || kullaniciProfil.Data == null)
                return RedirectToAction("ProfilBulunamadi", "Kullanici");

            kullaniciProfil.Data.UyeData.DisKullanici = false;
            kullaniciProfil.Data.UyeData.ArkadasProfil = false;
            kullaniciProfil.Data.SolMenuData.ArkadasProfil = false;
            ViewBag.Uye = kullaniciProfil.Data.UyeData;

            var menuDegerleri = await uyelikApiService.ArkadasMenuDegerleriGetir(token);
            return View(menuDegerleri.Data);
        }

        [HttpPost]
        public async Task<IActionResult> ArkadaslikIsteginiKabulEt(string kullaniciId)
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                return Json(false);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return Json(false);
            }

            ArkadaslikIsteginiKabulEtVM vm = new ArkadaslikIsteginiKabulEtVM()
            {
                ArkadasIstekKullaniciId = kullaniciId,
                Token = token
            };
            var arkadasKabulSonuc = await uyelikApiService.ArkadaslikIsteginiKabulEt(vm);
            var kullanici = await uyelikApiService.KullaniciGetir(token);

            if (kullanici != null)
            {
                var kullaniciBildirim = new KullaniciBildirimVM()
                {
                    KullaniciId = new Guid(kullaniciId),
                    BildirimTipId = 3,
                    BildirimIcerik = "<a href=\"/Kullanici/Profil/" + kullanici.KullaniciAdi + "\" style=\"display:unset!important;\">" + kullanici.KullaniciAdi + "</a> arkadaşlık isteğini kabul etti. Arkadaşlarını görmek için <a href=\"javascript:;\" onclick=\"arkadasListesiGit();\" style=\"display:unset!important;\"> tıkla.</a>"
                };
                if (arkadasKabulSonuc.Type == ResultType.Basarili)
                {
                    var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
                }
            }
            return Json(arkadasKabulSonuc.Data);
        }

        [HttpPost]
        public async Task<IActionResult> ArkadasSil(string kullaniciId)
        {
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));

            ArkadasSilVM vm = new ArkadasSilVM()
            {
                KullaniciArkadasId = new Guid(kullaniciId),
                Token = token
            };
            var arkadasSilSonuc = await uyelikApiService.ArkadasSil(vm);
            return Json(arkadasSilSonuc);
        }

        [HttpPost]
        public async Task<IActionResult> ArkadaslikIsteginiReddet(string kullaniciId)
        {
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));

            ArkadaslikIsteginiSilVM vm = new ArkadaslikIsteginiSilVM()
            {
                ArkadasIstekKullaniciId = kullaniciId,
                Token = token
            };
            var arkadasSilSonuc = await uyelikApiService.ArkadaslikIsteginiReddet(vm);
            return Json(arkadasSilSonuc);
        }

        public async Task<IActionResult> Fotograflar(int? p)
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
                return RedirectToAction("Index", "Home");

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            var kullaniciProfil = await uyelikApiService.ArkadasProfilGetir(new ArkadasProfilGetirVM
            {
                KullaniciAdi = kullanici.KullaniciAdi,
                Token = token
            });

            if (kullaniciProfil == null || kullaniciProfil.Data == null)
                return RedirectToAction("ProfilBulunamadi", "Kullanici");

            kullaniciProfil.Data.UyeData.DisKullanici = false;
            kullaniciProfil.Data.UyeData.ArkadasProfil = false;
            kullaniciProfil.Data.SolMenuData.ArkadasProfil = false;
            ViewBag.Uye = kullaniciProfil.Data.UyeData;

            KullaniciResimVM model = new KullaniciResimVM();
            int start = p.HasValue && p.Value > 0 ? p.Value : 1;
            int length = 4;
            model.KullaniciResimList = await uyelikApiService.KullaniciResimListesiGetir(start, length, kullanici.KullaniciId);
            return View(model);
        }

        [HttpPost]
        [RequestSizeLimit(20971520)]
        public async Task<IActionResult> FotografYukle(KullaniciResimVM data, IFormFile file)
        {
            ResultModel sonuc = new ResultModel();

            var Kullanici = HttpContext.Session.GetString("Kullanici");

            if (Kullanici == null)
            {
                sonuc.Type = ResultType.Basarisiz;
                sonuc.ErrorMessage = "session";
                return Json(sonuc);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(Kullanici);

            if (token == null)
            {
                sonuc.Type = ResultType.Basarisiz;
                sonuc.ErrorMessage = "session";
                return Json(sonuc);
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            var kullaniciResimSayisi = await uyelikApiService.KullaniciResimSayisiGetir(kullanici.KullaniciId);
            if (kullaniciResimSayisi == 20)
            {
                sonuc.Type = ResultType.Basarisiz;
                return Json(sonuc);
            }
            if (kullaniciResimSayisi >= 10)
            {
                sonuc.Type = ResultType.Basarisiz;
                sonuc.ErrorMessage = "ResimOndanFazla";
                return Json(sonuc);
            }

            KullaniciResimVM kullaniciResimVM = new KullaniciResimVM();
            kullaniciResimVM.ResimYorum = data.ResimYorum;
            kullaniciResimVM.AktifMi = true;
            kullaniciResimVM.KullaniciId = kullanici.KullaniciId;
            kullaniciResimVM.EklenmeTarihi = DateTime.Now;

            Image image = Image.FromStream(file.OpenReadStream(), true, true);
            ImageConverter converter = new ImageConverter();
            foreach (var prop in image.PropertyItems)
            {
                if (prop.Id == 0x0112) //value of EXIF
                {
                    var orientation = image.GetPropertyItem(prop.Id).Value[0];
                    int val = BitConverter.ToUInt16(prop.Value, 0);
                    var rot = RotateFlipType.RotateNoneFlipNone;

                    if (val == 3 || val == 4)
                        rot = RotateFlipType.Rotate180FlipNone;
                    else if (val == 5 || val == 6)
                        rot = RotateFlipType.Rotate90FlipNone;
                    else if (val == 7 || val == 8)
                        rot = RotateFlipType.Rotate270FlipNone;

                    if (val == 2 || val == 4 || val == 5 || val == 7)
                        rot |= RotateFlipType.RotateNoneFlipX;

                    if (rot != RotateFlipType.RotateNoneFlipNone)
                        image.RotateFlip(rot);
                }
            }

            if (image.Height > 500)
            {
                int width = Convert.ToInt32((500m / Convert.ToDecimal(image.Height)) * Convert.ToDecimal(image.Width));
                var newImage = new Bitmap(width, 500);
                using (var g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(image, 0, 0, width, 500);
                }

                kullaniciResimVM.Resim = (byte[])converter.ConvertTo(newImage, typeof(byte[]));
            }
            else
            {
                kullaniciResimVM.Resim = (byte[])converter.ConvertTo(image, typeof(byte[]));
            }

            kullaniciResimVM.ResimUzanti = file.ContentType;
            kullaniciResimVM.ResimUrl = file.FileName;
            kullaniciResimVM.ProfilFotografiMi = false;

            kullaniciResimVM = await uyelikApiService.KullaniciResimKaydet(kullaniciResimVM);
            if (kullaniciResimVM.KullaniciResimId > 0)
            {

                sonuc.Type = ResultType.Basarili;
            }
            else
            {
                sonuc.Type = ResultType.Basarisiz;
            }
            return Json(sonuc);

        }

        [HttpPost]
        [RequestSizeLimit(20971520)]
        public async Task<IActionResult> ProfilFotografYukle(KullaniciResimVM data, IEnumerable<IFormFile> file)
        {
            ResultModel sonuc = new ResultModel();

            var Kullanici = HttpContext.Session.GetString("Kullanici");

            if (Kullanici == null)
            {
                sonuc.Type = ResultType.Basarisiz;
                sonuc.ErrorMessage = "session";
                return Json(sonuc);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(Kullanici);

            if (token == null)
            {
                sonuc.Type = ResultType.Basarisiz;
                sonuc.ErrorMessage = "session";
                return Json(sonuc);
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            KullaniciResimVM kullaniciBuyukResimVM = new KullaniciResimVM();
            kullaniciBuyukResimVM.ResimYorum = data.ResimYorum;
            kullaniciBuyukResimVM.AktifMi = true;
            kullaniciBuyukResimVM.KullaniciId = kullanici.KullaniciId;
            kullaniciBuyukResimVM.EklenmeTarihi = DateTime.Now;

            KullaniciResimVM kullaniciResimVM = new KullaniciResimVM();
            kullaniciResimVM.ResimYorum = data.ResimYorum;
            kullaniciResimVM.AktifMi = true;
            kullaniciResimVM.KullaniciId = kullanici.KullaniciId;
            kullaniciResimVM.EklenmeTarihi = DateTime.Now;

            if (file.Count() == 0 || file == null)
            {
                sonuc.Type = ResultType.Basarisiz;
                return Json(sonuc);
            }

            foreach (var item in file)
            {
                Image image = Image.FromStream(item.OpenReadStream(), true, true);
                ImageConverter converter = new ImageConverter();
                foreach (var prop in image.PropertyItems)
                {
                    if (prop.Id == 0x0112) //value of EXIF
                    {
                        var orientation = image.GetPropertyItem(prop.Id).Value[0];
                        int val = BitConverter.ToUInt16(prop.Value, 0);
                        var rot = RotateFlipType.RotateNoneFlipNone;

                        if (val == 3 || val == 4)
                            rot = RotateFlipType.Rotate180FlipNone;
                        else if (val == 5 || val == 6)
                            rot = RotateFlipType.Rotate90FlipNone;
                        else if (val == 7 || val == 8)
                            rot = RotateFlipType.Rotate270FlipNone;

                        if (val == 2 || val == 4 || val == 5 || val == 7)
                            rot |= RotateFlipType.RotateNoneFlipX;

                        if (rot != RotateFlipType.RotateNoneFlipNone)
                            image.RotateFlip(rot);
                    }
                }


                if (image.Height > 120)
                {
                    int width = Convert.ToInt32((120m / Convert.ToDecimal(image.Height)) * Convert.ToDecimal(image.Width));
                    var newImage = new Bitmap(width, 120);
                    using (var g = Graphics.FromImage(newImage))
                    {
                        g.DrawImage(image, 0, 0, width, 120);
                    }
                    newImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);

                    kullaniciResimVM.Resim = (byte[])converter.ConvertTo(newImage, typeof(byte[]));
                }
                else
                {
                    kullaniciResimVM.Resim = (byte[])converter.ConvertTo(image, typeof(byte[]));
                }


                kullaniciResimVM.ResimUzanti = item.ContentType;
                kullaniciResimVM.ResimUrl = item.FileName;
                kullaniciResimVM.ProfilFotografiMi = true;
                kullaniciResimVM.BuyukProfilFotografiMi = false;

                if (image.Height > 500)
                {
                    int width = Convert.ToInt32((500m / Convert.ToDecimal(image.Height)) * Convert.ToDecimal(image.Width));
                    var newImage = new Bitmap(width, 500);
                    using (var g = Graphics.FromImage(newImage))
                    {
                        g.DrawImage(image, 0, 0, width, 500);
                    }

                    kullaniciBuyukResimVM.Resim = (byte[])converter.ConvertTo(newImage, typeof(byte[]));
                }
                else
                {
                    kullaniciBuyukResimVM.Resim = (byte[])converter.ConvertTo(image, typeof(byte[]));
                }

                kullaniciBuyukResimVM.ResimUzanti = item.ContentType;
                kullaniciBuyukResimVM.ResimUrl = item.FileName;
                kullaniciBuyukResimVM.ProfilFotografiMi = false;
                kullaniciBuyukResimVM.BuyukProfilFotografiMi = true;
            }
            kullaniciResimVM = await uyelikApiService.KullaniciProfilResimKaydetGuncelle(kullaniciResimVM);            
            var kullaniciResim = await uyelikApiService.KullaniciResimGetir(kullanici.KullaniciId);
            HttpContext.Session.SetString("KullaniciResim", JsonConvert.SerializeObject(kullaniciResim));

            if (kullaniciResim != null)
            {
                sonuc.Type = ResultType.Basarili;
                kullaniciResimVM = await uyelikApiService.KullaniciBuyukProfilResimKaydetGuncelle(kullaniciBuyukResimVM);
            }
            else
            {
                sonuc.Type = ResultType.Basarisiz;
            }

            return Json(sonuc);

        }

        [HttpPost]
        public async Task<IActionResult> FotografSil(int resimId)
        {
            ResultModel resultModel = new ResultModel();
            var Kullanici = HttpContext.Session.GetString("Kullanici");
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullanici = await uyelikApiService.KullaniciGetir(token);
            int sonuc = await uyelikApiService.KullaniciResimSil(kullanici.KullaniciId, resimId);
            if (sonuc == -1)
            {
                resultModel.Type = ResultType.Basarisiz;
                return Json(resultModel);
            }
            var kullaniciResim = await uyelikApiService.KullaniciResimGetir(kullanici.KullaniciId);
            HttpContext.Session.SetString("KullaniciResim", JsonConvert.SerializeObject(kullaniciResim));
            resultModel.Type = ResultType.Basarili;
            return Json(resultModel);
        }

        public async Task<IActionResult> FotografSilGuncelle(int resimId)
        {
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullanici = await uyelikApiService.KullaniciGetir(token);
            int sonuc = await uyelikApiService.KullaniciResimSil(kullanici.KullaniciId, resimId);
            return RedirectToAction("FotografGalerisi");
        }
        public async Task<IActionResult> ProfilFotografiSil()
        {
            ResultModel resultModel = new ResultModel();
            var Kullanici = HttpContext.Session.GetString("Kullanici");
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullanici = await uyelikApiService.KullaniciGetir(token);

            KullaniciResim kullaniciResim = await uyelikApiService.KullaniciProfilResimGetir(kullanici.KullaniciId.ToString());
            if (kullaniciResim != null)
            {
                var sonuc = await uyelikApiService.KullaniciProfilResmiSil(kullaniciResim);
                HttpContext.Session.SetString("KullaniciResim", JsonConvert.SerializeObject(null));
                resultModel.Type = ResultType.Basarili;

            }
            else
            {
                resultModel.Type = ResultType.Basarisiz;
                resultModel.ErrorMessage = "Profil resmi bulunmamaktadır";
            }

            return Json(resultModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProfilFotografiDegistir(int resimId)
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if(session == null)
            {
                return RedirectToAction();
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if(token == null)
            {
                return RedirectToAction();
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            KullaniciResimVM kullaniciResimVM = await uyelikApiService.KullaniciResimGetirByResimId(resimId);

            KullaniciResimVM kullaniciBuyukResimVM = await uyelikApiService.KullaniciResimGetirByResimId(resimId);

            if (kullaniciBuyukResimVM == null)
            {
                return RedirectToAction();
            }

            if (kullaniciResimVM == null)
            {
                return RedirectToAction();
            }
            else
            {
                kullaniciBuyukResimVM.AktifMi = true;
                kullaniciBuyukResimVM.KullaniciId = kullanici.KullaniciId;
                kullaniciBuyukResimVM.EklenmeTarihi = DateTime.Now;

                kullaniciResimVM.AktifMi = true;
                kullaniciResimVM.KullaniciId = kullanici.KullaniciId;
                kullaniciResimVM.EklenmeTarihi = DateTime.Now;

                using (var ms = new MemoryStream(kullaniciResimVM.Resim))
                {
                    Image image = Image.FromStream(ms);
                    ImageConverter converter = new ImageConverter();
                    foreach (var prop in image.PropertyItems)
                    {
                        if (prop.Id == 0x0112) //value of EXIF
                        {
                            var orientation = image.GetPropertyItem(prop.Id).Value[0];
                            int val = BitConverter.ToUInt16(prop.Value, 0);
                            var rot = RotateFlipType.RotateNoneFlipNone;

                            if (val == 3 || val == 4)
                                rot = RotateFlipType.Rotate180FlipNone;
                            else if (val == 5 || val == 6)
                                rot = RotateFlipType.Rotate90FlipNone;
                            else if (val == 7 || val == 8)
                                rot = RotateFlipType.Rotate270FlipNone;

                            if (val == 2 || val == 4 || val == 5 || val == 7)
                                rot |= RotateFlipType.RotateNoneFlipX;

                            if (rot != RotateFlipType.RotateNoneFlipNone)
                                image.RotateFlip(rot);
                        }
                    }

                    if (image.Height > 120)
                    {
                        int width = Convert.ToInt32((120m / Convert.ToDecimal(image.Height)) * Convert.ToDecimal(image.Width));
                        var newImage = new Bitmap(width, 120);
                        using (var g = Graphics.FromImage(newImage))
                        {
                            g.DrawImage(image, 0, 0, width, 120);
                        }
                        newImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);

                        kullaniciResimVM.Resim = (byte[])converter.ConvertTo(newImage, typeof(byte[]));
                    }
                    else
                    {
                        kullaniciResimVM.Resim = (byte[])converter.ConvertTo(image, typeof(byte[]));
                    }
                    kullaniciResimVM.ProfilFotografiMi = true;
                    kullaniciResimVM.BuyukProfilFotografiMi = false;

                    if (image.Height > 500)
                    {
                        int width = Convert.ToInt32((500m / Convert.ToDecimal(image.Height)) * Convert.ToDecimal(image.Width));
                        var newImage = new Bitmap(width, 500);
                        using (var g = Graphics.FromImage(newImage))
                        {
                            g.DrawImage(image, 0, 0, width, 500);
                        }

                        kullaniciBuyukResimVM.Resim = (byte[])converter.ConvertTo(newImage, typeof(byte[]));
                    }
                    else
                    {
                        kullaniciBuyukResimVM.Resim = (byte[])converter.ConvertTo(image, typeof(byte[]));
                    }
                    kullaniciBuyukResimVM.ProfilFotografiMi = false;
                    kullaniciBuyukResimVM.BuyukProfilFotografiMi = true;
                }

                kullaniciResimVM = await uyelikApiService.KullaniciProfilResimKaydetGuncelle(kullaniciResimVM);
                            
                kullaniciBuyukResimVM = await uyelikApiService.KullaniciBuyukProfilResimKaydetGuncelle(kullaniciBuyukResimVM);    

                var kullaniciResim = await uyelikApiService.KullaniciResimGetir(kullanici.KullaniciId);
                HttpContext.Session.SetString("KullaniciResim", JsonConvert.SerializeObject(kullaniciResim));
                return RedirectToAction("Profil");
            }

        }

        [HttpPost]
        public async Task<IActionResult> DuvarResmiDegistir(int resimId)
        {

            var Kullanici = HttpContext.Session.GetString("Kullanici");
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullanici = await uyelikApiService.KullaniciGetir(token);
            int sonuc = await uyelikApiService.KullaniciDuvarResimDegistir(kullanici.KullaniciId, resimId);
            return Ok();
        }

        public async Task<IActionResult> Ayarlar()
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
                return RedirectToAction("Index", "Home");

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            var kullaniciProfil = await uyelikApiService.ArkadasProfilGetir(new ArkadasProfilGetirVM
            {
                KullaniciAdi = kullanici.KullaniciAdi,
                Token = token
            });

            if (kullaniciProfil == null || kullaniciProfil.Data == null)
                return RedirectToAction("ProfilBulunamadi", "Kullanici");

            kullaniciProfil.Data.UyeData.DisKullanici = false;
            kullaniciProfil.Data.UyeData.ArkadasProfil = false;
            kullaniciProfil.Data.SolMenuData.ArkadasProfil = false;
            ViewBag.Uye = kullaniciProfil.Data.UyeData;

            return View();
        }

        [HttpPost]
        public async Task<ResultModel> KisiselBilgiKaydetGuncelle(KullaniciKisiselBilgiVM kullaniciKisiselBilgi)
        {
            ResultModel kullaniciKisiselBilgiSonuc = new ResultModel();

            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                kullaniciKisiselBilgiSonuc.Type = ResultType.Basarisiz;
                kullaniciKisiselBilgiSonuc.ErrorMessage = "session";
                return kullaniciKisiselBilgiSonuc;
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                kullaniciKisiselBilgiSonuc.Type = ResultType.Basarisiz;
                kullaniciKisiselBilgiSonuc.ErrorMessage = "session";
                return kullaniciKisiselBilgiSonuc;
            }

            if (kullaniciKisiselBilgi.Hakkinda != null && kullaniciKisiselBilgi.Hakkinda.Length > 500)
            {
                kullaniciKisiselBilgiSonuc.Type = ResultType.Basarisiz;
                kullaniciKisiselBilgiSonuc.ErrorMessage = "karakter";
                return kullaniciKisiselBilgiSonuc;
            }

            KullaniciKisiselBilgiKaydetGuncelleVM kullaniciKisisel = new KullaniciKisiselBilgiKaydetGuncelleVM()
            {
                Adi = kullaniciKisiselBilgi.Adi,
                Soyadi = kullaniciKisiselBilgi.Soyadi,
                Cinsiyet = kullaniciKisiselBilgi.Cinsiyet,
                DogumTarihi = new DateTime(kullaniciKisiselBilgi.DogumYil, kullaniciKisiselBilgi.DogumAy, kullaniciKisiselBilgi.DogumGun),
                Eposta = kullaniciKisiselBilgi.Eposta,
                Hakkinda = kullaniciKisiselBilgi.Hakkinda,
                IliskiDurumu = kullaniciKisiselBilgi.IliskiDurumu,
                KullaniciId = kullaniciKisiselBilgi.KullaniciId,
                KullaniciSehirId = kullaniciKisiselBilgi.KullaniciSehirId,
                Adres = kullaniciKisiselBilgi.Adres,
                Telefon = kullaniciKisiselBilgi.Telefon,
                InstagramAdi = kullaniciKisiselBilgi.InstagramAdi,
                Expiration = token.Expiration,
                RefreshToken = token.RefreshToken,
                Token = token.Token
            };

            kullaniciKisiselBilgiSonuc = await uyelikApiService.KullaniciKisiselBilgiKaydetGuncelle(kullaniciKisisel);

            if (kullaniciKisiselBilgiSonuc.Type == ResultType.Basarili)
            {
                HttpContext.Session.Remove("KullaniciBilgileri");
                var guncellenmisKullanici = await uyelikApiService.KullaniciGetir(token);
                HttpContext.Session.SetString("KullaniciBilgileri", JsonConvert.SerializeObject(guncellenmisKullanici));
            }

            return kullaniciKisiselBilgiSonuc;
        }

        public async Task<JsonResult> HobileriGetir([FromQuery] string query)
        {
            try
            {
                var session = HttpContext.Session.GetString("Kullanici");

                if (session == null)
                {
                    return Json(false);
                }

                var token = JsonConvert.DeserializeObject<TokenVM>(session);

                if (token == null)
                {
                    return Json(false);
                }

                HobileriGetirVM hobilerGetirModel = new HobileriGetirVM()
                {
                    Query = query,
                    Token = token
                };

                var hobiler = await uyelikApiService.HobileriGetir(hobilerGetirModel);
                return Json(hobiler);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        public async Task<JsonResult> IlgiAlanGetir([FromQuery] string query)
        {
            try
            {
                var session = HttpContext.Session.GetString("Kullanici");

                if (session == null)
                {
                    return Json(false);
                }

                var token = JsonConvert.DeserializeObject<TokenVM>(session);

                if (token == null)
                {
                    return Json(false);
                }

                IlgiAlanGetirVM ilgiAlanlariniGetirModel = new IlgiAlanGetirVM()
                {
                    Query = query,
                    Token = token
                };

                var hobiler = await uyelikApiService.IlgiAlanlariniGetir(ilgiAlanlariniGetirModel);
                return Json(hobiler);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        public async Task<JsonResult> HobiKaydetGuncelle()
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
            {
                return Json(false);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return Json(false);
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            if (kullanici == null)
                return Json(false);

            KullaniciHobiKaydetGuncelleVM model = new KullaniciHobiKaydetGuncelleVM()
            {
                KullaniciId = kullanici.KullaniciId
            };

            if (Request.Form.Count > 0)
            {
                if (Request.Form.ContainsKey("hobiler"))
                {
                    var hobiler = Request.Form["hobiler"].ToString();
                    if (!string.IsNullOrEmpty(hobiler) && hobiler != "{'hobiler': }")
                    {
                        JObject o = JObject.Parse(hobiler);
                        JArray a = (JArray)o["hobiler"];
                        model.KullaniciHobiList = a.ToObject<List<KullaniciHobiVM>>();
                    }
                }
            }

            var result = await uyelikApiService.KullaniciHobiKaydetGuncelle(model);

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> IlgiAlaniKaydetGuncelle()
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
            {
                return Json(false);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return Json(false);
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            if (kullanici == null)
                return Json(false);

            KullaniciIlgiAlanKaydetGuncelleVM model = new KullaniciIlgiAlanKaydetGuncelleVM()
            {
                KullaniciId = kullanici.KullaniciId
            };

            if (Request.Form.Count > 0)
            {
                if (Request.Form.ContainsKey("ilgiAlanlar"))
                {
                    var ilgiAlanlar = Request.Form["ilgiAlanlar"].ToString();
                    if (!string.IsNullOrEmpty(ilgiAlanlar) && ilgiAlanlar != "{'ilgiAlanlar': }")
                    {
                        JObject o = JObject.Parse(ilgiAlanlar);
                        JArray a = (JArray)o["ilgiAlanlar"];
                        model.KullaniciIlgiAlanList = a.ToObject<List<KullaniciIlgiAlanVM>>();
                    }
                }
            }

            var result = await uyelikApiService.KullaniciIlgiAlanKaydetGuncelle(model);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> AyarKaydetGuncelle(AyarlarVM ayarlarModel)
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
            {
                ResultModel model = new ResultModel();
                model.Type = ResultType.Basarisiz;
                model.ErrorMessage = "sessionnull";
                return Json(model);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);
            ayarlarModel.Token = token;

            var ayarlarKaydetGuncelleSonuc = await uyelikApiService.AyarlarKaydetGuncelle(ayarlarModel);
            return Json(ayarlarKaydetGuncelleSonuc);
        }

        [HttpPost]
        public async Task<IActionResult> SifreKaydetGuncelle(SifreDegistirVM sifreDegistirModel)
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
            {
                ResultModel model = new ResultModel();
                model.Type = ResultType.Basarisiz;
                model.ErrorMessage = "sessionnull";
                return Json(model);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);
            sifreDegistirModel.Token = token;

            var sifreKaydetGuncelleSonuc = await uyelikApiService.SifreKaydetGuncelle(sifreDegistirModel);
            return Json(sifreKaydetGuncelleSonuc);
        }

        [HttpGet]
        public async Task<IActionResult> KullaniciFotografVarmi()
        {

            var Kullanici = HttpContext.Session.GetString("Kullanici");
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullanici = await uyelikApiService.KullaniciGetir(token);
            var fotograflar = await uyelikApiService.KullaniciResimListele(kullanici.KullaniciId.ToString());
            ResultModel model = new ResultModel();
            if (fotograflar.Count() == 0)
            {
                model.Type = ResultType.Basarisiz;
            }
            else
            {
                model.Type = ResultType.Basarili;
            }

            return Json(model);

        }

        public async Task<IActionResult> KullaniciProfilFotografiVarMi()
        {
            ResultModel resultModel = new ResultModel();
            var Kullanici = HttpContext.Session.GetString("Kullanici");
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullanici = await uyelikApiService.KullaniciGetir(token);

            KullaniciResim kullaniciResim = await uyelikApiService.KullaniciProfilResimGetir(kullanici.KullaniciId.ToString());
            if (kullaniciResim != null)
            {
                resultModel.Type = ResultType.Basarili;
            }
            else
            {
                resultModel.Type = ResultType.Basarisiz;
                resultModel.ErrorMessage = "Profil resmi bulunmamaktadır";
            }

            return Json(resultModel);
        }

        #region Partials

        [HttpGet]
        public async Task<PartialViewResult> ProfilSagMenuPartial()
        {
            ProfilSagMenuVM result = new ProfilSagMenuVM();
            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                var kullanici = await uyelikApiService.KullaniciGetir(token);
                if (kullanici != null)
                {
                    ProfilSagMenuAraVM model = new ProfilSagMenuAraVM()
                    {
                        Token = token,
                        KullaniciId = kullanici.KullaniciId,
                    };

                    result = await uyelikApiService.ProfilSagMenuGetir(model);
                }
            }

            return PartialView("~/Views/Shared/Partials/ProfilSagMenu.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> HediyeSepetiPartial(string ap, int? p, string o)
        {
            HediyeSepetiVM result = new HediyeSepetiVM()
            {
                ArkadasProfil = false,
                KullaniciAdi = null,
                Siralama = o,
                HediyeList = new List<UrunIcerikVM>().ToPagedList()
            };

            if (string.IsNullOrEmpty(ap))
            {
                var session = HttpContext.Session.GetString("Kullanici");
                if (session != null)
                {
                    var token = JsonConvert.DeserializeObject<TokenVM>(session);
                    if (token != null)
                    {
                        var kullanici = await uyelikApiService.KullaniciGetir(token);
                        if (kullanici != null)
                        {
                            KullaniciUrunListesiAramaVM model = new KullaniciUrunListesiAramaVM()
                            {
                                KullaniciId = kullanici.KullaniciId,
                                start = p ?? 1,
                                length = 9,
                                order = o,
                            };

                            result.HediyeList = await uyelikApiService.KullaniciHediyeSepetiGetir(model);
                        }
                    }
                }
            }
            else
            {
                var arkadasProfil = await uyelikApiService.ArkadasProfilGetir(new ArkadasProfilGetirVM
                {
                    KullaniciAdi = ap
                });

                if (arkadasProfil == null || arkadasProfil.Data == null)
                    return null;

                KullaniciUrunListesiAramaVM model = new KullaniciUrunListesiAramaVM()
                {
                    KullaniciId = arkadasProfil.Data.UyeData.KullaniciId,
                    start = p ?? 1,
                    length = 9,
                    order = o,
                };

                result.ArkadasProfil = true;
                result.KullaniciAdi = ap;
                result.Siralama = o;
                result.HediyeList = await uyelikApiService.KullaniciHediyeSepetiGetir(model);
            }

            return PartialView("~/Views/Kullanici/Partials/HediyeSepeti.cshtml", result);
        }

        [HttpPost]
        public async Task<PartialViewResult> ArkadasListesiModalPartial(ArkadasListesiModalPartialVM modal)
        {
            ArkadasListesiModalVM result = new ArkadasListesiModalVM()
            {
                ArkadasProfil = false,
                KullaniciAdi = null,
                ArkadasList = new List<ArkadasListesiKullaniciArkadasVM>().ToPagedList()
            };

            var kullanici = await uyelikApiService.KullaniciGetirByKullaniciAdi(modal.ap);

            if (kullanici == null)
                return null;

            KullaniciArkadasListesiModalAramaVM model = new KullaniciArkadasListesiModalAramaVM()
            {
                KullaniciId = kullanici.KullaniciId,
                start = modal.p ?? 1,
                length = 5
            };

            if (HttpContext.Session.GetString("Kullanici") != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
                model.Token = token;
            }


            result.ArkadasProfil = true;
            result.KullaniciAdi = modal.ap;
            result.ArkadasList = await uyelikApiService.KullaniciArkadasListesiModalGetir(model);

            return PartialView("~/Views/Kullanici/Partials/ArkadasListesiModal.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> BakilanProfillerModalPartial(string ap, int? p)
        {
            ArkadasListesiModalVM result = new ArkadasListesiModalVM()
            {
                ArkadasProfil = false,
                KullaniciAdi = null,
                ArkadasList = new List<ArkadasListesiKullaniciArkadasVM>().ToPagedList()
            };

            var kullanici = await uyelikApiService.KullaniciGetirByKullaniciAdi(ap);

            if (kullanici == null)
                return null;

            KullaniciArkadasListesiModalAramaVM model = new KullaniciArkadasListesiModalAramaVM()
            {
                KullaniciId = kullanici.KullaniciId,
                start = p ?? 1,
                length = 5
            };

            result.ArkadasProfil = true;
            result.KullaniciAdi = ap;
            result.ArkadasList = await uyelikApiService.KullaniciBakilanProfilleriGetir(model);

            return PartialView("~/Views/Kullanici/Partials/BakilanProfillerModal.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> KisiselBilgiPartial()
        {
            var sehirler = await uyelikApiService.SehirleriGetir();
            ViewData["Sehirler"] = new SelectList(sehirler, "KullaniciSehirId", "KullaniciSehirAdi");

            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                KullaniciKisiselBilgiVM bos = new KullaniciKisiselBilgiVM();
                return PartialView("~/Views/Kullanici/Partials/KisiselBilgi.cshtml", bos);
            }
            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                KullaniciKisiselBilgiVM bos = new KullaniciKisiselBilgiVM();
                return PartialView("~/Views/Kullanici/Partials/KisiselBilgi.cshtml", bos);
            }

            var kullaniciKisiselBilgi = await uyelikApiService.KullaniciKisiselBilgileriGetir(token);

            return PartialView("~/Views/Kullanici/Partials/KisiselBilgi.cshtml", kullaniciKisiselBilgi);
        }

        [HttpGet]
        public PartialViewResult ProfilSikayetPartial(string id)
        {
            Guid sikayetEdilenKullaniciId = Guid.Empty;
            if (!string.IsNullOrEmpty(id))
                Guid.TryParse(id, out sikayetEdilenKullaniciId);

            ProfilSikayetVM model = new ProfilSikayetVM()
            {
                SikayetEdilenKullaniciId = sikayetEdilenKullaniciId
            };

            return PartialView("~/Views/Shared/Partials/ProfilSikayet.cshtml", model);
        }

        [HttpGet]
        public async Task<PartialViewResult> EngellenenProfilListesiPartial(EngellenenProfilListesiAramaSayfaVM model)
        {
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullanici = await uyelikApiService.KullaniciGetir(token);

            EngellenenProfilListesiAramaVM aramaModel = new EngellenenProfilListesiAramaVM()
            {
                KullaniciId = kullanici.KullaniciId,
                start = model.p.HasValue && model.p.Value > 0 ? model.p.Value : 1,
                length = 3,
            };

            var result = await uyelikApiService.ProfilEngelListGetir(aramaModel);

            return PartialView("~/Views/Kullanici/Partials/EngellenenProfilListesi.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> BildirimlerPartial(KullaniciBildirimListesiAramaVM aramaVM)
        {
            var result = new List<KullaniciBildirimVM>().ToPagedList();
            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);

                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);

                    if (kullanici != null)
                    {
                        KullaniciBildirimListeVM vm = new KullaniciBildirimListeVM()
                        {
                            KullaniciId = kullanici.KullaniciId,
                            start = aramaVM.p.HasValue && aramaVM.p.Value > 0 ? aramaVM.p.Value : 1,
                            length = 5,
                            //Token = token
                        };

                        result = await uyelikApiService.KullaniciBildirimListGetir(vm);
                    }
                }
            }

            return PartialView("~/Views/Kullanici/Partials/Bildirimler.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> MesajlarPartial(ArkadasMesajListesiAramaVM aramaVM)
        {
            var result = new ArkadasMesajListesiSonuc()
            {
                MesajArama = "",
                MesajListSonuc = new List<ArkadasKonusmaListesiVM>().ToPagedList()
            };

            var sessionKullanici = HttpContext.Session.GetString("Kullanici");
            var sessionKullaniciBilgileri = HttpContext.Session.GetString("KullaniciBilgileri");
            if (sessionKullanici != null && sessionKullaniciBilgileri != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(sessionKullanici);
                var kullanici = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(sessionKullaniciBilgileri);
                ArkadasMesajListeVM vm = new ArkadasMesajListeVM()
                {
                    start = aramaVM.p.HasValue && aramaVM.p.Value > 0 ? aramaVM.p.Value : 1,
                    length = 5,
                    Token = token
                };
                MesajDetayGetirVM mesajVm = new MesajDetayGetirVM()
                {
                    AliciKullaniciId = kullanici.KullaniciId,
                    Token = token
                };
                var mesajListesi = await uyelikApiService.ArkadaslarMesajlarListesi(vm);
                //TODO ŞG: Bu bölüm daha sonra iptal edilecek. Şuan soldaki künyenin sayfaya girilince sıfırlanması için eklendi.
                var mesajlariOkuSonuc = await uyelikApiService.MesajlariOku(mesajVm);
                result.MesajArama = aramaVM.q;
                result.MesajListSonuc = mesajListesi;
            }

            return PartialView("~/Views/Kullanici/Partials/Mesajlar.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> HediyeKartiPartial(HediyeKartListesiAramaVM aramaVM)
        {
            HediyeKartListesiSonucVM result = new HediyeKartListesiSonucVM
            {
                HediyeKartArama = "",
                HediyeKartListSonuc = new List<HediyeKartKonusmaListesiVM>().ToPagedList()
            };

            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);

                HediyeKartListeVM vm = new HediyeKartListeVM()
                {
                    start = aramaVM.p.HasValue && aramaVM.p.Value > 0 ? aramaVM.p.Value : 1,
                    length = 10,
                    Token = token
                };

                var hediyeKartListesi = await uyelikApiService.KullaniciHediyeKartListesiGetir(vm);

                result.HediyeKartArama = aramaVM.q;
                result.HediyeKartListSonuc = hediyeKartListesi;
            }

            return PartialView("~/Views/Kullanici/Partials/HediyeKarti.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> ArkadasListesiPartial(ArkadasListesiAramaSayfaVM aramaVM)
        {
            ArkadasListesiSayfaSonuc result = new ArkadasListesiSayfaSonuc
            {
                ArkadasArama = "",
                ArkadasListSonuc = null
            };

            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);

                ArkadasListeAramaVM vm = new ArkadasListeAramaVM()
                {
                    Siralama = aramaVM.s,
                    AramaKelime = aramaVM.q,
                    start = aramaVM.p.HasValue && aramaVM.p.Value > 0 ? aramaVM.p.Value : 1,
                    length = 9,
                    Token = token
                };

                var arkadaslistesi = await uyelikApiService.ArkadasListesiGetir(vm);

                result.ArkadasArama = aramaVM.q;
                result.ArkadasListSonuc = arkadaslistesi;
            }
            else
            {
                result.ArkadasArama = "";
                result.ArkadasListSonuc = new List<ArkadasListesiKullaniciArkadasVM>().ToPagedList();
            }

            return PartialView("~/Views/Kullanici/Partials/ArkadasListesi.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> ArkadaslikIstekleriPartial()
        {
            var result = new List<ArkadasIstekleriVM>();

            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);

                var arkadasIstekleriSonuc = await uyelikApiService.ArkadasIstekleriniGetir(token);
                var arkadasIstekleriOkuSonuc = await uyelikApiService.ArkadasIstekleriniOku(token);
                result = arkadasIstekleriSonuc.Data;
            }

            return PartialView("~/Views/Kullanici/Partials/ArkadaslikIstekleri.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> DogumGunleriPartial()
        {
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            ArkadasListesiGetirVM vm = new ArkadasListesiGetirVM()
            {
                Token = token
            };
            var arkadaslistesi = await uyelikApiService.ArkadasListesiGetir(vm);
            return PartialView("~/Views/Kullanici/Partials/DogumGunleri.cshtml", arkadaslistesi.Data);
        }

        [HttpGet]
        public async Task<PartialViewResult> FotografGalerisi(int? p)
        {
            KullaniciResimVM model = new KullaniciResimVM();
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                return PartialView("~/Views/Kullanici/Partials/FotografGalerisi.cshtml", model.KullaniciResimList);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return PartialView("~/Views/Kullanici/Partials/FotografGalerisi.cshtml", model.KullaniciResimList);
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            int start = p.HasValue && p.Value > 0 ? p.Value : 1;
            int length = 4;
            model.KullaniciResimList = await uyelikApiService.KullaniciResimListesiGetir(start, length, kullanici.KullaniciId);
            return PartialView("~/Views/Kullanici/Partials/FotografGalerisi.cshtml", model.KullaniciResimList);
        }
        [HttpGet]
        public async Task<PartialViewResult> FotografGalerisiModal(string k)
        {
            List<KullaniciResimVM> result = new List<KullaniciResimVM>();

            if (string.IsNullOrEmpty(k))
            {

                var session = HttpContext.Session.GetString("Kullanici");
                if (session != null)
                {
                    var token = JsonConvert.DeserializeObject<TokenVM>(session);
                    if (token != null)
                    {
                        var kullanici = await uyelikApiService.KullaniciGetir(token);
                        if (kullanici != null)
                        {
                            result = await uyelikApiService.KullaniciResimListele(kullanici.KullaniciId.ToString());
                        }
                    }
                }
            }
            else
            {
                var kullanici = await uyelikApiService.KullaniciGetirByKullaniciAdi(k);

                if (kullanici == null)
                    return null;

                result = await uyelikApiService.KullaniciResimListele(kullanici.KullaniciId.ToString());

            }

            return PartialView("~/Views/Kullanici/Partials/FotografGalerisiModal.cshtml", result);
        }
        [HttpGet]
        public async Task<PartialViewResult> FotografListele()
        {

            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                List<KullaniciResimVM> resim = new List<KullaniciResimVM>();
                return PartialView("~/Views/Kullanici/Partials/FotograflarPartial.cshtml", resim);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                List<KullaniciResimVM> resim = new List<KullaniciResimVM>();
                return PartialView("~/Views/Kullanici/Partials/FotograflarPartial.cshtml", resim);
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            var fotograflar = await uyelikApiService.KullaniciResimListele(kullanici.KullaniciId.ToString());
            return PartialView("~/Views/Kullanici/Partials/FotograflarPartial.cshtml", fotograflar);

        }

        [HttpGet]
        public async Task<PartialViewResult> DuvarResimleriPartial()
        {
            var fotograflar = await uyelikApiService.DuvarResimleriniGetir();
            return PartialView("~/Views/Kullanici/Partials/DuvarResimleriPartial.cshtml", fotograflar);
        }

        [HttpGet]
        public async Task<PartialViewResult> HesapAyarlariPartial()
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                AyarlarVM bos = new AyarlarVM();
                return PartialView("~/Views/Kullanici/Partials/HesapAyarlari.cshtml", bos);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                AyarlarVM bos = new AyarlarVM();
                return PartialView("~/Views/Kullanici/Partials/HesapAyarlari.cshtml", bos);
            }

            var kullaniciAyarlari = await uyelikApiService.KullaniciHesapAyarlariniGetir(token);

            return PartialView("~/Views/Kullanici/Partials/HesapAyarlari.cshtml", kullaniciAyarlari.Data);
        }

        [HttpGet]
        public async Task<PartialViewResult> SifreDegistirPartial()
        {
            return PartialView("~/Views/Kullanici/Partials/SifreDegistir.cshtml");
        }

        [HttpGet]
        public async Task<PartialViewResult> HobilerPartial()
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                KullaniciHobiKaydetGuncelleVM bos = new KullaniciHobiKaydetGuncelleVM();
                return PartialView("~/Views/Kullanici/Partials/Hobiler.cshtml", bos);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                KullaniciHobiKaydetGuncelleVM bos = new KullaniciHobiKaydetGuncelleVM();
                return PartialView("~/Views/Kullanici/Partials/Hobiler.cshtml", bos);
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            var model = await uyelikApiService.KullaniciHobiIlgiAlanGetir(kullanici.KullaniciId);

            return PartialView("~/Views/Kullanici/Partials/Hobiler.cshtml", model);
        }

        [HttpGet]
        public async Task<PartialViewResult> IlgiAlanlariPartial()
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                KullaniciIlgiAlanKaydetGuncelleVM bos = new KullaniciIlgiAlanKaydetGuncelleVM();
                return PartialView("~/Views/Kullanici/Partials/IlgiAlanlari.cshtml", bos);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                KullaniciIlgiAlanKaydetGuncelleVM bos = new KullaniciIlgiAlanKaydetGuncelleVM();
                return PartialView("~/Views/Kullanici/Partials/IlgiAlanlari.cshtml", bos);
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            var model = await uyelikApiService.KullaniciHobiIlgiAlanGetir(kullanici.KullaniciId);

            return PartialView("~/Views/Kullanici/Partials/IlgiAlanlari.cshtml", model);
        }

        [HttpGet]
        public async Task<PartialViewResult> UyeSifreGonderPartial()
        {
            KullaniciSifreGonderVM model = new KullaniciSifreGonderVM();
            return PartialView("~/Views/Kullanici/Partials/UyeSifreGonderPartial.cshtml", model);
        }
        [HttpPost]
        public async Task<JsonResult> UyeSifreGonder(KullaniciSifreGonderVM model)
        {
            model.YeniSifre = SifreOlustur(6);
            ResultModel result = await uyelikApiService.KullaniciYeniSifreGonder(model);
            return Json(result);
        }

        public string SifreOlustur(int length)
        {
            const string valid = "0123456789";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }

        [HttpGet]
        public async Task<PartialViewResult> HesapKapatmaPartial()
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                return PartialView("~/Views/Kullanici/Partials/HesapKapatma.cshtml");
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return PartialView("~/Views/Kullanici/Partials/HesapKapatma.cshtml");
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            ViewBag.kullaniciIsimSoyisim = kullanici.Adi + " " + kullanici.Soyadi;
            return PartialView("~/Views/Kullanici/Partials/HesapKapatma.cshtml");
        }


        [HttpPost]
        public async Task<IActionResult> KullaniciHesabiKapat()
        {
            var session = HttpContext.Session.GetString("Kullanici");
            ServiceResponse kullaniciHesabiKapat = new ServiceResponse();

            if (session == null)
            {
                kullaniciHesabiKapat.Status = "session";
                return Json(kullaniciHesabiKapat);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                kullaniciHesabiKapat.Status = "session";
                return Json(kullaniciHesabiKapat);
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            KullaniciSilVM vm = new KullaniciSilVM()
            {
                KullaniciId = kullanici.KullaniciId,
                Token = token
            };

            kullaniciHesabiKapat = await uyelikApiService.KullaniciSil(vm);
            return Json(kullaniciHesabiKapat);
        }

        [HttpGet]
        public async Task<bool> BakilanProfilSil(string kullaniciAdi)
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                return false;
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return false;
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            BakilanProfilSilVM vm = new BakilanProfilSilVM()
            {
                KullaniciId = kullanici.KullaniciId,
                BakilanKullaniciAdi = kullaniciAdi
            };

            return await uyelikApiService.BakilanProfilSil(vm);
        }

        [HttpGet]
        public async Task<bool> BakilanTumProfilleriSil()
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                return false;
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return false;
            }

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            return await uyelikApiService.BakilanTumProfilleriSil(kullanici);
        }

        [HttpGet]
        public async Task<PartialViewResult> FbVeyaGoogleIlkGiris()
        {
            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            var kullaniciKisiselBilgi = await uyelikApiService.KullaniciKisiselBilgileriGetir(token);
            var sehirler = await uyelikApiService.SehirleriGetir();

            ViewData["Sehirler"] = new SelectList(sehirler, "KullaniciSehirId", "KullaniciSehirAdi");

            return PartialView("~/Views/Kullanici/Partials/FbveGoogleIlkGirisModal.cshtml", kullaniciKisiselBilgi);
        }
        [HttpGet]
        public async Task<PartialViewResult> KullaniciAdiModalPartial(string kullaniciAdi)
        {
            var result = new KullaniciAdiVM();
            if (kullaniciAdi == null)
            {
                var session = HttpContext.Session.GetString("Kullanici");
                if (session != null)
                {
                    var token = JsonConvert.DeserializeObject<TokenVM>(session);
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    result.KullaniciAdi = kullanici.KullaniciAdi;
                }
                else
                {
                    result.KullaniciAdi = kullaniciAdi;
                }
            }
            else
            {
                result.KullaniciAdi = kullaniciAdi;
            }

            return PartialView("~/Views/Kullanici/Partials/KullaniciAdiDegistirme.cshtml", result);
        }

        [HttpPost]
        public async Task<ResultModel<KullaniciAdiVM>> KullaniciAdiGuncelle(string kullaniciAdi)
        {
            ResultModel<KullaniciAdiVM> kullaniciResult = new ResultModel<KullaniciAdiVM>();

            if (kullaniciAdi == null)
            {
                kullaniciResult.Type = ResultType.Basarisiz;
                kullaniciResult.ErrorMessage = "TurkceKarakter";
                return kullaniciResult;
            }
            if (kullaniciAdi.Length < 3)
            {
                kullaniciResult.Type = ResultType.Basarisiz;
                kullaniciResult.ErrorMessage = "MinLength";
                return kullaniciResult;
            }

            string[] Harfler = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", "_" };
            foreach (var item in kullaniciAdi)
            {
                string karakter = item.ToString();
                if (!Harfler.Any(karakter.Contains))
                {
                    kullaniciResult.Type = ResultType.Basarisiz;
                    kullaniciResult.ErrorMessage = "TurkceKarakter";
                    return kullaniciResult;
                }
            }

            for (var i = 0; i < 3; i++)
            {
                if (kullaniciAdi[i] == '.' || kullaniciAdi[i] == '_')
                {
                    kullaniciResult.Type = ResultType.Basarisiz;
                    kullaniciResult.ErrorMessage = "IlkUcKarakter";
                    return kullaniciResult;
                }
            }

            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                kullaniciResult.Type = ResultType.Basarisiz;
                kullaniciResult.ErrorMessage = "session";
                return kullaniciResult;
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                kullaniciResult.Type = ResultType.Basarisiz;
                kullaniciResult.ErrorMessage = "session";
                return kullaniciResult;
            }

            KullaniciAdiVM kullanici = new KullaniciAdiVM()
            {
                KullaniciAdi = kullaniciAdi,
                Token = token
            };


            if (ModelState.IsValid)
            {

                kullaniciResult = await uyelikApiService.KullaniciAdiGuncelle(kullanici);
                if (kullaniciResult.Type == ResultType.Basarili)
                {
                    HttpContext.Session.SetString("Kullanici", JsonConvert.SerializeObject(token));
                    var kullaniciBilgileri = await uyelikApiService.KullaniciGetir(token);
                    HttpContext.Session.SetString("KullaniciBilgileri", JsonConvert.SerializeObject(kullaniciBilgileri));
                }
                return kullaniciResult;
            }
            else
            {
                kullaniciResult.Type = ResultType.Basarisiz;
                kullaniciResult.ErrorMessage = "Lütfen Bütün Alanları Doldurunuz.";
                return kullaniciResult;
            }
        }

        [HttpGet]
        public async Task<PartialViewResult> KullaniciHeaderBildirimListGetir()
        {
            List<KullaniciBildirimVM> result = new List<KullaniciBildirimVM>();

            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                var kullanici = await uyelikApiService.KullaniciGetir(token);
                if (kullanici != null)
                    result = await uyelikApiService.KullaniciHeaderBildirimListGetir(kullanici.KullaniciId);
            }

            return PartialView("~/Views/Shared/Partials/HeaderBildirimler.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> KullaniciHeaderBildirimMobilListGetir()
        {
            List<KullaniciBildirimVM> result = new List<KullaniciBildirimVM>();

            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                var kullanici = await uyelikApiService.KullaniciGetir(token);
                if (kullanici != null)
                    result = await uyelikApiService.KullaniciHeaderBildirimListGetir(kullanici.KullaniciId);
            }

            return PartialView("~/Views/Shared/Partials/HeaderBildirimlerMobil.cshtml", result);
        }

        [HttpGet]
        public async Task<int> KullaniciHeaderBildirimMobilSayisiGetir()
        {
            List<KullaniciBildirimVM> result = new List<KullaniciBildirimVM>();

            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                var kullanici = await uyelikApiService.KullaniciGetir(token);
                if (kullanici != null)
                    result = await uyelikApiService.KullaniciHeaderBildirimListGetir(kullanici.KullaniciId);
            }

            return result.Count();
        }

        public async Task<bool> KullaniciBildirimOkundu()
        {
            bool sonuc = false;
            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                var kullanici = await uyelikApiService.KullaniciGetir(token);
                if (kullanici != null)
                    sonuc = await uyelikApiService.KullaniciBildirimOkundu(kullanici.KullaniciId);
            }

            return sonuc;
        }

        [HttpGet]
        public async Task<PartialViewResult> ArkadaslarSeceneklerPartial()
        {
            if (HttpContext.Session.GetString("Kullanici") != null)
            {
                return PartialView("~/Views/Kullanici/Partials/ArkadaslarSecenekler.cshtml");
            }

            return PartialView();
        }

        public async Task<PartialViewResult> ProfilFotografPartial(int? p)
        {
            KullaniciResimVM model = new KullaniciResimVM();
            var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
                return PartialView("~/Views/Kullanici/Partials/ProfilFotografPartial.cshtml", model);

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            if (kullanici == null)
            {
                return PartialView("~/Views/Kullanici/Partials/ProfilFotografPartial.cshtml", model);
            }

            int start = p.HasValue && p.Value > 0 ? p.Value : 1;
            int length = 4;
            model.KullaniciResimList = await uyelikApiService.KullaniciResimListesiGetir(start, length, kullanici.KullaniciId);
            return PartialView("~/Views/Kullanici/Partials/ProfilFotografPartial.cshtml", model);
        }

        public async Task<bool> KullaniciTumBildirimleriSil()
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
                return false;

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            if (kullanici == null)
            {
                return false;
            }

            var sonuc = await uyelikApiService.KullaniciTumBildirimleriSil(kullanici.KullaniciId);

            return sonuc;
        }

        [HttpGet]
        public async Task<PartialViewResult> IndirimKuponuPartial()
        {
            IndirimKuponuAramaVM result = new IndirimKuponuAramaVM()
            {
                BaslangicTarihi = DateTime.Now.ToString(),
                BitisTarihi = DateTime.Now.ToString(),
            };


            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        var indirimKuponlari = await sayfaApiService.IndirimKuponuGetir(result);
                        return PartialView("~/Views/Kullanici/Partials/IndirimKuponu.cshtml", indirimKuponlari);
                    }
                }
            }

            return null;
        }

        [HttpPost]
        public async Task<PartialViewResult> BuyukProfilFotografPartial(string kullaniciId)
        {
            KullaniciResimVM model = new KullaniciResimVM();
            /*var session = HttpContext.Session.GetString("Kullanici");
            if (session == null)
                return PartialView("~/Views/Kullanici/Partials/BuyukProfilFotografModal.cshtml", model);

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            var kullanici = await uyelikApiService.KullaniciGetir(token);
            if (kullanici == null)
            {
                return PartialView("~/Views/Kullanici/Partials/BuyukProfilFotografModal.cshtml", model);
            }*/
            model = await uyelikApiService.KullaniciBuyukProfilResimGetir(new Guid(kullaniciId));

            return PartialView("~/Views/Kullanici/Partials/BuyukProfilFotografModal.cshtml", model);
        }

        [HttpGet]
        public async Task<int> KullaniciHeaderSepetUrunSayisiGetir()
        {
            var result = 0;

            var session = HttpContext.Session.GetString("Kullanici");
            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);

                if(token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                        result = await uyelikApiService.KullaniciHeaderSepetUrunSayisiGetir(kullanici.KullaniciId);
                }         
            }

            return result;
        }
        #endregion
    }
}