using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Uyelik;
using NeSever.WebUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeSever.WebUI.Controllers
{
    public class ArkadasController : BaseController
    {
        private readonly IUyelikApiService uyelikApiService;

        public ArkadasController(ILogger<BaseController> logger,
                                 IUyelikApiService uyelikApiService) : base(logger, uyelikApiService)
        {
            this.uyelikApiService = uyelikApiService;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //log örneği
            //logger.Log(LogLevel.Error, null, string.Format("/{0}/{1}/{2}/{3}", "WebUI", "ArkadasController", "Index", null));

            return View();
        }

        public async Task<IActionResult> Ara(ArkadasAramaSayfaVM vm)
        {
            if (!Request.QueryString.HasValue)
                return Redirect("/");

            var arkadasAramaVM = new ArkadasAramaVM()
            {
                AramaKelime = vm.q,
                start = vm.p.HasValue && vm.p.Value > 0 ? vm.p.Value : 1,
                length = 20,
                Cinsiyet = vm.c,
                Sehir = vm.s.HasValue && vm.s.Value > 0 ? vm.s.Value : 0,
                Ulke = vm.u.HasValue && vm.u.Value > 0 ? vm.u.Value : 1,
                MedeniDurum = vm.m
            };

            if (HttpContext.Session.GetString("Kullanici") != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
                arkadasAramaVM.Token = token;
            }

            var sehirler = await uyelikApiService.SehirleriGetir();

            var arkadasAramaList = await uyelikApiService.ArkadasAra(arkadasAramaVM);

            ArkadasAramaSayfaSonucVM model = new ArkadasAramaSayfaSonucVM
            {
                ArkadasArama = vm.q,
                Cinsiyet = arkadasAramaVM.Cinsiyet,
                MedeniDurum = arkadasAramaVM.MedeniDurum,
                Ulke = arkadasAramaVM.Ulke,
                Sehir = arkadasAramaVM.Sehir,
                ArkadasAramaListSonuc = arkadasAramaList
            };

            ViewData["Sehirler"] = new SelectList(sehirler, "KullaniciSehirId", "KullaniciSehirAdi", model.Sehir);
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> ArkadasAra(string query)
        {
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
            {
                return Json(new { error = true, message = "", operation = "show" });
            }
            else
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token == null)
                {
                    return Json(new { error = true, message = "", operation = "show" });
                }
                else
                {
                    var kullaniciBilgileri = await uyelikApiService.KullaniciGetir(token);
                    if (kullaniciBilgileri == null)
                    {
                        return Json(new { error = true, message = "", operation = "show" });
                    }
                    else
                    {
                        ArkadasAraVM vm = new ArkadasAraVM()
                        {
                            AramaKelime = query,
                            KullaniciId = kullaniciBilgileri.KullaniciId,
                            Token = token
                        };


                        var arkadasAramaList = await uyelikApiService.ArkadasAra(vm);
                        return Json(arkadasAramaList.Data);
                    }
                }
            }
            //var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            //var kullaniciBilgileri = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(HttpContext.Session.GetString("KullaniciBilgileri"));

            //ArkadasAraVM vm = new ArkadasAraVM()
            //{
            //    AramaKelime = query,
            //    KullaniciId = kullaniciBilgileri.KullaniciId,
            //    Token = token
            //};


            //var arkadasAramaList = await uyelikApiService.ArkadasAra(vm);

            //return Json(arkadasAramaList.Data);
        }

        [HttpPost]
        public async Task<JsonResult> ArkadasArama(string query,string kullaniciAdi)
        {
            var kisiArama = await uyelikApiService.KullaniciGetirByKullaniciAdi(kullaniciAdi);
            if (kisiArama != null)
            {               
                ArkadasAraVM vm = new ArkadasAraVM()
                {
                    AramaKelime = query,
                    KullaniciId = kisiArama.KullaniciId,
                    Token = null
                };

                var arkadasAramaList = await uyelikApiService.ArkadasArama(vm);

                return Json(arkadasAramaList.Data);
            }
            else
            {
                return Json(new List<ArkadasAraSonucVM>());
            }
        }

        [HttpPost]
        public async Task<ResultModel> KullaniciHediyeKartGonder(KullaniciHediyeKartKayitVM vm)
        {
            vm.KayitTarih = DateTime.Now;
            vm.AktifMi = true;
            vm.OkunduMu = false;
            vm.GonderenAktifMi = true;
            vm.AlanAktifMi = true;
            if (HttpContext.Session.GetString("KullaniciBilgileri") == null)
            {
                ResultModel result = new ResultModel()
                {
                    ErrorMessage = "Lütfen giriş yapınız",
                    Type = ResultType.Basarisiz
                };
                return result;
            }
            else
            {
                var kullaniciBilgileri = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(HttpContext.Session.GetString("KullaniciBilgileri"));

                vm.GonderenKullaniciId = new Guid(kullaniciBilgileri.KullaniciId.ToString());
                var sonuc = await uyelikApiService.KullaniciHediyeKartKayit(vm);
                var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
                var kullanici = await uyelikApiService.KullaniciGetir(token);
                var arkadasKullanici = await uyelikApiService.KullaniciGetirByKullaniciId(vm.AliciKullaniciId);
                if(kullanici!=null && arkadasKullanici != null)
                {
                    var kullaniciBildirim = new KullaniciBildirimVM()
                    {
                        KullaniciId = arkadasKullanici.KullaniciId,
                        BildirimTipId = 5,
                        BildirimIcerik = "<a href=\"/Kullanici/Profil/" + kullanici.KullaniciAdi + "\" style=\"display:unset!important;\">" + kullanici.KullaniciAdi + "</a> yeni bir hediye kartı gönderdi. Hediye kartını görmek için <a href=\"javascript:;\" onclick=\"hediyeKartGit();\" style=\"display:unset!important;\"> tıkla.</a>"
                    };
                    if (sonuc.Type == ResultType.Basarili)
                    {
                        var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
                    }

                }
                
                return sonuc;
            }

        }

        public async Task<IActionResult> HediyeKartDetayGetir(string gonderenKullaniciId)
        {
            KullaniciKisiselBilgiVM kullanici = new KullaniciKisiselBilgiVM();
            TokenVM token = new TokenVM();
            if(HttpContext.Session.GetString("KullaniciBilgileri") != null && HttpContext.Session.GetString("Kullanici") != null)
            {
                kullanici = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(HttpContext.Session.GetString("KullaniciBilgileri"));
                token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            }
            else 
            {
                return RedirectToAction("HediyeKartiPartial", "Kullanici");
            }
            

            HediyeKartDetayGetirVM vm = new HediyeKartDetayGetirVM()
            {
                AliciKullaniciId = kullanici.KullaniciId,
                GonderenKullaniciId = new Guid(gonderenKullaniciId),
                Token = token
            };

            var hediyeKartDetayGetirSonuc = await uyelikApiService.HediyeKartDetayGetir(vm);
            var result = hediyeKartDetayGetirSonuc.Data;

            if (result.Any())
            {
                string kullaniciAdi = "";
                var ilkSatir = result.First();
                if (ilkSatir.GonderenKullanici.KullaniciId == kullanici.KullaniciId)
                    kullaniciAdi = ilkSatir.AliciKullanici.KullaniciAdi;
                else
                    kullaniciAdi = ilkSatir.GonderenKullanici.KullaniciAdi;

                var model = new HediyeKartlariVM()
                {
                    KullaniciAd = kullaniciAdi,
                    HediyeKartList = result,
                };

                return PartialView("~/Views/Kullanici/Partials/HediyeKartDetay.cshtml", model);
            }
            else
            {
                return RedirectToAction("HediyeKartiPartial", "Kullanici");
            }
        }

        public async Task<ResultModel<Guid>> HediyeKartSil(string hediyeKartId)
        {
            var sonuc = new ResultModel<Guid>
            {
                Type = ResultType.Basarisiz
            };

            KullaniciKisiselBilgiVM kullaniciBilgileri = new KullaniciKisiselBilgiVM();
            TokenVM token = new TokenVM();
            if (HttpContext.Session.GetString("KullaniciBilgileri") != null && HttpContext.Session.GetString("Kullanici") != null)
            {
                kullaniciBilgileri = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(HttpContext.Session.GetString("KullaniciBilgileri"));
                token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            }
            else
            {
                return sonuc;
            }

            HediyeKartSilVM vm = new HediyeKartSilVM
            {
                SilenKullaniciId = kullaniciBilgileri.KullaniciId,
                HediyeKartId = int.Parse(hediyeKartId),
                Token = token
            };

            var hediyeKartSilSonuc = await uyelikApiService.HediyeKartSil(vm);

            if (hediyeKartSilSonuc.Type == ResultType.Basarili)
            {
                sonuc.Data = vm.SilenKullaniciId;
            }

            return sonuc;
        }

        public async Task<ResultModel> HediyeKartKonusmaSil(string gonderenKullaniciId)
        {
            KullaniciKisiselBilgiVM kullaniciBilgileri = new KullaniciKisiselBilgiVM();
            TokenVM token = new TokenVM();
            var konusmaSilSonuc = new ResultModel
            {
                Type = ResultType.Basarisiz
            };
            if (HttpContext.Session.GetString("KullaniciBilgileri") != null && HttpContext.Session.GetString("Kullanici") != null)
            {
                kullaniciBilgileri = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(HttpContext.Session.GetString("KullaniciBilgileri"));
                token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));
            }
            else
            {
                return konusmaSilSonuc;
            }

            KonusmaSilVM vm = new KonusmaSilVM
            {
                SilenKullaniciId = kullaniciBilgileri.KullaniciId,
                GonderenKullaniciId = new Guid(gonderenKullaniciId),
                Token = token
            };

            konusmaSilSonuc = await uyelikApiService.HediyeKartKonusmaSil(vm);

            return konusmaSilSonuc;
        }

        [HttpPost]
        public async Task<JsonResult> KisiAra(string query)
        {
            //var kisiAramaList = await uyelikApiService.KullaniciGetirByKullaniciAdi(query);
            KisiAraVM kisiAraVM = new KisiAraVM()
            {
                AramaKelime = query,
                Length = 10,
            };
            var session = HttpContext.Session.GetString("Kullanici");
            if (session!=null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token!=null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        kisiAraVM.KullaniciId=kullanici.KullaniciId;
                        kisiAraVM.Token=token;
                    }
                }
            }
            var kisiAramaList = await uyelikApiService.KisiAra(kisiAraVM);
            return Json(kisiAramaList);
        }

        [HttpPost]
        public async Task<IActionResult> ArkadaslikIsteginiGonder(string kullaniciId)
        {
            if (HttpContext.Session.GetString("Kullanici") == null)
            {
                return Json(false);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));

            ArkadaslikIstegiGonderVM vm = new ArkadaslikIstegiGonderVM()
            {
                IstekGonderilenKullaniciId = new Guid(kullaniciId),
                Token = token
            };

            var arkadaslikIstekGondermeSonuc = await uyelikApiService.ArkadaslikIstekGonder(vm);


            var kullanici = await uyelikApiService.KullaniciGetir(token);

            if(kullanici != null)
            {
                var kullaniciBildirim = new KullaniciBildirimVM()
                {
                    KullaniciId = new Guid(kullaniciId),
                    BildirimTipId = 2,
                    BildirimIcerik = "<a href=\"/Kullanici/Profil/" + kullanici.KullaniciAdi + "\" style=\"display:unset!important;\">" + kullanici.KullaniciAdi + "</a> yeni bir arkadaşlık isteği gönderdi. Arkadaşlık isteklerini görmek için <a href=\"javascript:;\" onclick=\"arkadaslikIstekGit();\" style=\"display:unset!important;\"> tıkla.</a>"
                };
                if (arkadaslikIstekGondermeSonuc.Type == ResultType.Basarili)
                {
                    var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
                }
                else
                {
                    var bildirimSilSonuc = await uyelikApiService.KullaniciBildirimSil(kullaniciBildirim);
                }
            }
            
            
            return Json(arkadaslikIstekGondermeSonuc);
        }

        [HttpPost]
        public async Task<IActionResult> ArkadaslikIstekGonderildiMi(string kullaniciId)
        {
            if (HttpContext.Session.GetString("Kullanici") == null)
            {
                return Json(false);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));

            ArkadaslikIstegiGonderVM vm = new ArkadaslikIstegiGonderVM()
            {
                IstekGonderilenKullaniciId = new Guid(kullaniciId),
                Token = token
            };

            var arkadaslikIstekGondermeSonuc = await uyelikApiService.ArkadaslikIstekGonderildiMi(vm);

            var kullanici = await uyelikApiService.KullaniciGetir(token);

            if (kullanici != null)
            {
                var kullaniciBildirim = new KullaniciBildirimVM()
                {
                    KullaniciId = new Guid(kullaniciId),
                    BildirimTipId = 2,
                    BildirimIcerik = "<a href=\"/Kullanici/Profil/" + kullanici.KullaniciAdi + "\" style=\"display:unset!important;\">" + kullanici.KullaniciAdi + "</a> yeni bir arkadaşlık isteği gönderdi. Arkadaşlık isteklerini görmek için <a href=\"javascript:;\" onclick=\"arkadaslikIstekGit();\" style=\"display:unset!important;\"> tıkla.</a>"
                };
                if (arkadaslikIstekGondermeSonuc.Type == ResultType.Basarili)
                {
                    var bildirimSilSonuc = await uyelikApiService.KullaniciBildirimSil(kullaniciBildirim);                    
                }
                else
                {
                    arkadaslikIstekGondermeSonuc.Type = ResultType.Basarili;
                    var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
                }
            }

            return Json(arkadaslikIstekGondermeSonuc);
        }

        [HttpPost]
        public async Task<IActionResult> ArkadaslikIstekBanaGonderildiMi(string kullaniciId)
        {
            if (HttpContext.Session.GetString("Kullanici") == null)
            {
                return Json(false);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));

            ArkadaslikIstegiGonderVM vm = new ArkadaslikIstegiGonderVM()
            {
                IstekGonderilenKullaniciId = new Guid(kullaniciId),
                Token = token
            };

            var arkadaslikIstekBanaGondermeSonuc = await uyelikApiService.ArkadaslikIstekBanaGonderildiMi(vm);

            return Json(arkadaslikIstekBanaGondermeSonuc);
        }

        [HttpPost]
        public async Task<IActionResult> ArkadasProfil(string kullaniciId)
        {
            if (HttpContext.Session.GetString("Kullanici") == null)
            {
                return Json(false);
            }

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> MesajGonder(string kullaniciId)
        {
            if (HttpContext.Session.GetString("Kullanici") == null)
            {
                return Json(false);
            }
            var gondericiKullanici = JsonConvert.DeserializeObject<KullaniciVM>(HttpContext.Session.GetString("KullaniciBilgileri"));

            KullaniciMesajGonderVM vm = new KullaniciMesajGonderVM()
            {
                GondericiKullaniciId = gondericiKullanici.KullaniciId,
                AliciKullaniciId = new Guid(kullaniciId)
            };

            return PartialView("~/Views/Arkadas/Partials/ArkadasAramaMesajGonder.cshtml", vm);
        }

        [HttpPost]
        public async Task<IActionResult> ArkadasAraMesajGonder(string kullaniciId)
        {
            var kBilgi = HttpContext.Session.GetString("KullaniciBilgileri");

            if(kBilgi == null)
            {
                return Json(false);
            }

            var kullaniciBilgileri = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(kBilgi);

            if (kullaniciBilgileri == null)
            {
                return Json(false);
            }

            if (kullaniciBilgileri.KullaniciId == new Guid(kullaniciId))
            {
                return PartialView("~/Views/Arkadas/Partials/ArkadasAraMesajGonder.cshtml");
            }
            else
            {
                KullaniciMesajGonderVM vm = new KullaniciMesajGonderVM()
                {
                    GondericiKullaniciId = kullaniciBilgileri.KullaniciId,
                    AliciKullaniciId = new Guid(kullaniciId)
                };

                return PartialView("~/Views/Arkadas/Partials/ArkadasAramaMesajGonder.cshtml", vm);

            }
        }

        public async Task<ResultModel> KullaniciMesajGonder(MesajGonderVM vm)
        {
            vm.Token = JsonConvert.DeserializeObject<TokenVM>(HttpContext.Session.GetString("Kullanici"));

            var kullaniciBilgileri = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(HttpContext.Session.GetString("KullaniciBilgileri"));
            if (kullaniciBilgileri == null)
            {
                ResultModel resultModel = new ResultModel();
                resultModel.Type = ResultType.Basarisiz;
                resultModel.ErrorMessage = "Lütfen giriş yapınız";
                return resultModel;
            }
            vm.GonderenKullanici = kullaniciBilgileri.KullaniciId.ToString();
            var sonuc = await uyelikApiService.MesajGonder(vm);

            var kullanici = await uyelikApiService.KullaniciGetir(vm.Token);

            if (kullanici != null)
            {
                var kullaniciBildirim = new KullaniciBildirimVM()
                {
                    KullaniciId = new Guid(vm.AlanKullanici),
                    BildirimTipId = 4,
                    BildirimIcerik = "<a href=\"/Kullanici/Profil/" + kullanici.KullaniciAdi + "\" style=\"display:unset!important;\">" + kullanici.KullaniciAdi + "</a> yeni bir mesaj gönderdi.Mesajlarını görmek için <a href=\"javascript:;\" onclick=\"mesajlaraGit();\" style=\"display:unset!important;\">tıkla.</a>"
                };
                if (sonuc.Type == ResultType.Basarili)
                {
                    var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
                }
            }
            return sonuc;
        }

        public async Task<IActionResult> MesajDetayGetir(string gonderenKullaniciId)
        {
            var kBilgi = HttpContext.Session.GetString("KullaniciBilgileri");

            if(kBilgi == null)
            {
                return Json(false);
            }

            var kullanici = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(kBilgi);

            if (kullanici == null)
            {
                return Json(false);
            }

            var session = HttpContext.Session.GetString("Kullanici");

            if(session == null)
            {
                return Json(false);
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return Json(false);
            }
            //var kullanici = await uyelikApiService.KullaniciGetir(token);

            MesajDetayGetirVM vm = new MesajDetayGetirVM()
            {
                AliciKullaniciId = kullanici.KullaniciId,
                GonderenKullaniciId = new Guid(gonderenKullaniciId),
                Token = token
            };

            var mesajDetayGetirSonuc = await uyelikApiService.MesajDetayGetir(vm);
            //TODO ŞG: bu bölüm daha sonra tekrar aktif edilecek. şuan soldaki künye alanının ilgili sayfaya girildiğinde sıfırlanabilmesi için devre dışı bırakıldı.
            //var mesajlariOkuSonuc = await uyelikApiService.MesajlariOku(vm);
            var result = mesajDetayGetirSonuc.Data;

            if (result.Any())
            {
                string kullaniciAdi = "";
                var ilkSatir = result.First();
                if (ilkSatir.GonderenKullanici.KullaniciId == kullanici.KullaniciId)
                    kullaniciAdi = ilkSatir.AliciKullanici.KullaniciAdi;
                else
                    kullaniciAdi = ilkSatir.GonderenKullanici.KullaniciAdi;

                var model = new MesajlarVM()
                {
                    KullaniciAd = kullaniciAdi,
                    MesajList = result,
                };

                return PartialView("~/Views/Kullanici/Partials/ArkadasMesajDetay.cshtml", model);
            }
            else
            {
                return RedirectToAction("MesajlarPartial", "Kullanici");
            }

        }

        public async Task<ResultModel> KonusmaSil(string gonderenKullaniciId)
        {
            ResultModel konusmaSilSonuc = new ResultModel();
            konusmaSilSonuc.Type = ResultType.Basarisiz;

            var kBilgi = HttpContext.Session.GetString("KullaniciBilgileri");

            if(kBilgi == null)
            {              
                return konusmaSilSonuc;
            }

            var kullaniciBilgileri = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(kBilgi);

            if (kullaniciBilgileri == null)
            {
                return konusmaSilSonuc;
            }

            var session = HttpContext.Session.GetString("Kullanici");

            if(session == null)
            {
                return konusmaSilSonuc;
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return konusmaSilSonuc;
            }

            KonusmaSilVM vm = new KonusmaSilVM
            {
                SilenKullaniciId = kullaniciBilgileri.KullaniciId,
                GonderenKullaniciId = new Guid(gonderenKullaniciId),
                Token = token
            };

            konusmaSilSonuc = await uyelikApiService.KonusmaSil(vm);

            return konusmaSilSonuc;
        }

        public async Task<ResultModel<Guid>> MesajSil(string mesajId)
        {
            var sonuc = new ResultModel<Guid>
            {
                Type = ResultType.Basarisiz
            };

            var kBilgi = HttpContext.Session.GetString("KullaniciBilgileri");

            if(kBilgi == null)
            {
                return sonuc;
            }

            var kullaniciBilgileri = JsonConvert.DeserializeObject<KullaniciKisiselBilgiVM>(kBilgi);

            if(kullaniciBilgileri == null)
            {
                return sonuc;
            }

            var session = HttpContext.Session.GetString("Kullanici");

            if(session == null)
            {
                return sonuc;
            }

            var token = JsonConvert.DeserializeObject<TokenVM>(session);

            if (token == null)
            {
                return sonuc;
            }

            MesajSilVM vm = new MesajSilVM
            {
                SilenKullaniciId = kullaniciBilgileri.KullaniciId,
                MesajId = int.Parse(mesajId),
                Token = token
            };

            var mesajSilSonuc = await uyelikApiService.MesajSil(vm);

            if (mesajSilSonuc.Type == ResultType.Basarili)
            {
                sonuc.Type = ResultType.Basarili;
                sonuc.Data = vm.SilenKullaniciId;
            }

            return sonuc;
        }

        [HttpPost]
        public async Task<IActionResult> ProfilArkadasEkle(string kullaniciId)
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

            ArkadaslikIstegiGonderVM vm = new ArkadaslikIstegiGonderVM()
            {
                IstekGonderilenKullaniciId = new Guid(kullaniciId),
                Token = token
            };

            var arkadaslikIstekGondermeSonuc = await uyelikApiService.ProfilArkadasEkle(vm);
            var kullanici = await uyelikApiService.KullaniciGetir(token);

            if (kullanici != null && arkadaslikIstekGondermeSonuc.ErrorMessage == "Arkadaslik İstegi Gonderildi")
            {
                var kullaniciBildirim = new KullaniciBildirimVM()
                {
                    KullaniciId = new Guid(kullaniciId),
                    BildirimTipId = 2,
                    BildirimIcerik = "<a href=\"/Kullanici/Profil/" + kullanici.KullaniciAdi + "\" style=\"display:unset!important;\">" + kullanici.KullaniciAdi + "</a> yeni bir arkadaşlık isteği gönderdi. Arkadaşlık isteklerini görmek için <a href=\"javascript:;\" onclick=\"arkadaslikIstekGit();\" style=\"display:unset!important;\"> tıkla.</a>"
                };

                var bildirimSonuc = await uyelikApiService.KullaniciBildirimEkle(kullaniciBildirim);
            }

            return Json(arkadaslikIstekGondermeSonuc);
        }

        [HttpPost]
        public async Task<int> HediyeKartOkunduIsaretle(string gonderenKullaniciId)
        {
            var session = HttpContext.Session.GetString("Kullanici");
            if(session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                var kullanici = await uyelikApiService.KullaniciGetir(token);
                if(kullanici!=null)
                {
                    HediyeKartOkunduVM hediyeKartOkundu = new HediyeKartOkunduVM()
                    {
                        GonderenKullaniciId = new Guid(gonderenKullaniciId),
                        AliciKullaniciId = kullanici.KullaniciId
                    };
                    return await uyelikApiService.HediyeKartOkunduIsaretle(hediyeKartOkundu);
                }
                return 0;
            }
            return 0;
        }

        public async Task<IActionResult> ArkadasAramadaTopListGetir(string kelime)
        {
            var arkadasAramaVM = new ArkadasAramaVM()
            {
                AramaKelime = kelime,
                start = 0,
                length = 3
            };

            var arkadasAramaList = await uyelikApiService.ArkadasAra(arkadasAramaVM);
            var model = arkadasAramaList.ToList(); 
            return Json(model);
        }
    }
}
