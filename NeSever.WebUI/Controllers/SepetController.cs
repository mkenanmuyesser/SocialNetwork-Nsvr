using Iyzipay.Model;
using Iyzipay.Request;
using Iyzipay.Samples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeSever.Common.Models;
using NeSever.Common.Models.Satis;
using NeSever.Common.Models.Uyelik;
using NeSever.WebUI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Controllers
{
    public class SepetController : BaseController
    {
        private readonly IUyelikApiService uyelikApiService;
        private readonly ISatisApiService satisApiService;

        public SepetController(ILogger<BaseController> logger,
                               IUyelikApiService uyelikApiService,
                               ISatisApiService satisApiService) : base(logger, uyelikApiService)
        {
            this.uyelikApiService = uyelikApiService;
            this.satisApiService = satisApiService;
            this.logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            SepetIcerikVM model = new SepetIcerikVM() { SepetUrunList = new List<SepetUrunVM>() };

            var session = HttpContext.Session.GetString("Kullanici");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        SepetVM sepetVM = new SepetVM() { KullaniciId = kullanici.KullaniciId };
                        model = await satisApiService.KullaniciSepetGetir(sepetVM);
                    }
                }
            }

            //var session = HttpContext.Session.GetString("Kullanici");
            //SepetVM sepetVM = new SepetVM() { KullaniciId = Guid.Parse("e61c19f4-aee1-4617-aadd-d7a5a1308f55") };
            //model = await satisApiService.KullaniciSepetGetir(sepetVM);

            return View(model);
        }

        public async Task<JsonResult> SepetTemizle()
        {
            bool result = false;

            var session = HttpContext.Session.GetString("Kullanici");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        SepetVM sepetVM = new SepetVM() { KullaniciId = kullanici.KullaniciId };
                        result = await satisApiService.KullaniciSepetTemizle(sepetVM);
                    }
                }
            }

            //SepetVM sepetVM = new SepetVM() { KullaniciId = Guid.Parse("e61c19f4-aee1-4617-aadd-d7a5a1308f55") };
            //result = await satisApiService.KullaniciSepetTemizle(sepetVM);

            return Json(new { error = !result, message = (result ? "İşlem Başarılı" : "İşlem Sırasında Bir Hata Oluştu") });
        }

        [HttpPost]
        public async Task<JsonResult> SepetUrunEkle(SepetVM model)
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
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici == null)
                    {
                        return Json(new { error = true, message = "", operation = "show" });
                    }
                    else
                    {
                        model.KullaniciId = kullanici.KullaniciId;
                        var result = await satisApiService.KullaniciSepetUrunArttir(model);

                        if (result > 0)
                            return Json(new { error = false, message = "", operation = "success", recordsTotal = result });
                        else
                            return Json(new { error = true, message = (result == 0 ? "İşlem Sırasında Bir Hata Oluştu" : "İşlem Başarılı"), operation = "message" });
                    }
                }
            }

            //model.KullaniciId = Guid.Parse("e61c19f4-aee1-4617-aadd-d7a5a1308f55");
            //result = await satisApiService.KullaniciSepetUrunArttir(model);        
        }

        public async Task<JsonResult> SepetUrunArttir(int id)
        {
            int result = 0;

            var session = HttpContext.Session.GetString("Kullanici");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        SepetVM sepetVM = new SepetVM() { KullaniciId = kullanici.KullaniciId, UrunId = id, Adet = 1 };
                        result = await satisApiService.KullaniciSepetUrunArttir(sepetVM);
                    }
                }
            }

            //SepetVM sepetVM = new SepetVM() { KullaniciId = Guid.Parse("e61c19f4-aee1-4617-aadd-d7a5a1308f55"), UrunId = id };
            //result = await satisApiService.KullaniciSepetUrunArttir(sepetVM);

            return Json(new { error = (result == 0 ? true : false), message = (result == 0 ? "İşlem Sırasında Bir Hata Oluştu" : "İşlem Başarılı") });
        }

        public async Task<JsonResult> SepetUrunEksilt(int id)
        {
            bool result = false;

            var session = HttpContext.Session.GetString("Kullanici");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        SepetVM sepetVM = new SepetVM() { KullaniciId = kullanici.KullaniciId, UrunId = id };
                        result = await satisApiService.KullaniciSepetUrunEksilt(sepetVM);
                    }
                }
            }

            //SepetVM sepetVM = new SepetVM() { KullaniciId = Guid.Parse("e61c19f4-aee1-4617-aadd-d7a5a1308f55"), UrunId = id };
            //result = await satisApiService.KullaniciSepetUrunEksilt(sepetVM);

            return Json(new { error = !result, message = (result ? "İşlem Başarılı" : "İşlem Sırasında Bir Hata Oluştu") });
        }

        public async Task<JsonResult> SepetUrunSil(int id)
        {
            bool result = false;

            var session = HttpContext.Session.GetString("Kullanici");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        SepetVM sepetVM = new SepetVM() { KullaniciId = kullanici.KullaniciId, UrunId = id };
                        result = await satisApiService.KullaniciSepetUrunSil(sepetVM);
                    }
                }
            }

            //SepetVM sepetVM = new SepetVM() { KullaniciId = Guid.Parse("e61c19f4-aee1-4617-aadd-d7a5a1308f55"), UrunId = id };
            //result = await satisApiService.KullaniciSepetUrunSil(sepetVM);

            return Json(new { error = !result, message = (result ? "İşlem Başarılı" : "İşlem Sırasında Bir Hata Oluştu") });
        }

        public async Task<IActionResult> AdresOdemeTip()
        {
            AdresOdemeTipIcerikVM model = new AdresOdemeTipIcerikVM() { };

            //1 - giriş yapılmışmı kontrol et
            var session = HttpContext.Session.GetString("Kullanici");
            KullaniciVM kullanici = null;

            if (session == null)
                return RedirectToAction("", "Sepet");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        AdresVM adresVM = new AdresVM() { KullaniciId = kullanici.KullaniciId };
                        model.AdresIcerik = await satisApiService.KullaniciAdreslerGetir(adresVM);
                    }
                }
            }

            return View(model);
        }

        public async Task<JsonResult> AdresSil(int id)
        {
            bool result = false;

            var session = HttpContext.Session.GetString("Kullanici");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        SepetAdresVM sepetAdresVM = new SepetAdresVM() { KullaniciId = kullanici.KullaniciId, AdresId = id };
                        result = await satisApiService.KullaniciSepetAdresSil(sepetAdresVM);
                    }
                }
            }

            //SepetAdresVM sepetAdresVM = new SepetAdresVM() { KullaniciId = Guid.Parse("e61c19f4-aee1-4617-aadd-d7a5a1308f55"), AdresId = id };
            //result = await satisApiService.KullaniciSepetAdresSil(sepetAdresVM);

            return Json(new { error = !result, message = (result ? "İşlem Başarılı" : "İşlem Sırasında Bir Hata Oluştu") });
        }

        [HttpPost]
        public async Task<JsonResult> AdresKaydetGuncelle(SepetAdresVM model)
        {
            bool result = false;

            var session = HttpContext.Session.GetString("Kullanici");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        model.KullaniciId = kullanici.KullaniciId;
                        result = await satisApiService.KullaniciSepetAdresKaydetGuncelle(model);
                    }
                }
            }

            return Json(new { error = !result, message = (result ? "İşlem Başarılı" : "İşlem Sırasında Bir Hata Oluştu") });
        }

        [HttpGet]
        [ActionName("Odeme")]
        public async Task<IActionResult> OdemeGet()
        {
            return RedirectToAction("", "Sepet");
        }

        [HttpPost]
        [ActionName("Odeme")]
        public async Task<IActionResult> OdemePost()
        {
            OdemeIcerikVM model = new OdemeIcerikVM() { };

            //1 - giriş yapılmışmı kontrol et
            var session = HttpContext.Session.GetString("Kullanici");
            KullaniciVM kullanici = null;

            if (session == null)
                return RedirectToAction("", "Sepet");

            int faturaAdresId = 0;
            int teslimatAdresId = 0;
            int odemeYontem = 0;

            int.TryParse(Request.Form["rdBtnFatura"].ToString(), out faturaAdresId);
            int.TryParse(Request.Form["rdBtnTeslimat"].ToString(), out teslimatAdresId);
            int.TryParse(Request.Form["rdBtnOdemeYontem"].ToString(), out odemeYontem);

            if (faturaAdresId == 0 || teslimatAdresId == 0 || odemeYontem == 0)
                return RedirectToAction("", "Sepet");

            string krediKartiAdSoyad = Request.Form.ContainsKey("KrediKartiAdSoyad") ? Request.Form["KrediKartiAdSoyad"].ToString() : null;
            string krediKartiNo = Request.Form.ContainsKey("KrediKartiNo") ? Request.Form["KrediKartiNo"].ToString() : null;
            string krediKartiCvv = Request.Form.ContainsKey("KrediKartiCvv") ? Request.Form["KrediKartiCvv"].ToString() : null;
            string krediKartiSonKullanmaTarihiAy = Request.Form.ContainsKey("KrediKartiSonKullanmaTarihiAy") ? Request.Form["KrediKartiSonKullanmaTarihiAy"].ToString() : null;
            string krediKartiSonKullanmaTarihiYil = Request.Form.ContainsKey("KrediKartiSonKullanmaTarihiYil") ? Request.Form["KrediKartiSonKullanmaTarihiYil"].ToString() : null;

            if (odemeYontem == 1 &&
                (string.IsNullOrEmpty(krediKartiAdSoyad) ||
                string.IsNullOrEmpty(krediKartiNo) ||
                string.IsNullOrEmpty(krediKartiCvv) ||
                string.IsNullOrEmpty(krediKartiSonKullanmaTarihiAy) ||
                string.IsNullOrEmpty(krediKartiSonKullanmaTarihiYil)))
                return RedirectToAction("", "Sepet");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        OdemeVM odemeVM = new OdemeVM() { KullaniciId = kullanici.KullaniciId };
                        model = await satisApiService.KullaniciOdemeGetir(odemeVM);
                    }
                }
            }

            //2-sepetinde ürün varmı kontrol et
            if (kullanici == null || model.SepetIcerik == null || model.SepetIcerik.SepetUrunList == null || model.SepetIcerik.SepetUrunList.Count == 0)
                return RedirectToAction("", "Sepet");

            //seçilen adresleri setle
            model.FaturaAdresId = faturaAdresId;
            model.GonderimAdresId = teslimatAdresId;

            model.SiparisOdemeTipId = odemeYontem;
            //eğer seçilen ödeme yöntemi kredi kartı ise kart bilgilerini setle
            if (odemeYontem == 1)
            {
                model.KrediKartiAdSoyad = krediKartiAdSoyad;
                model.KrediKartiNo = krediKartiNo;
                model.KrediKartiCvv = krediKartiCvv;
                model.KrediKartiSonKullanmaTarihiAy = krediKartiSonKullanmaTarihiAy;
                model.KrediKartiSonKullanmaTarihiYil = krediKartiSonKullanmaTarihiYil;
            }

            //ödeme metinlerini değiştir
            string adsoyadUnvan = kullanici.Adi + " " + kullanici.Soyadi;
            string email = kullanici.Eposta;
            string faturaAdres = model.Adresler.SingleOrDefault(p => p.AdresId == faturaAdresId).AdresBilgi;
            string teslimatAdres = model.Adresler.SingleOrDefault(p => p.AdresId == faturaAdresId).AdresBilgi;
            string telefon = model.Adresler.SingleOrDefault(p => p.AdresId == faturaAdresId).Telefon1;
            string odemeSekli = satisApiService.SiparisOdemeTipListesiGetir().Result.SingleOrDefault(p => p.SiparisOdemeTipId == model.SiparisOdemeTipId)?.Adi;
            string toplamAdet = model.SepetIcerik.SepetUrunList.Sum(p => p.Adet).ToString();
            string toplamTutar = model.SepetIcerik.OdenecekTutar.ToString("#,##0.00") + " TL";
            string tarih = DateTime.Now.ToString("dd/MM/yyyy");

            model.OnBilgilendirmeFormuIcerik = model.OnBilgilendirmeFormuIcerik.Replace("{0}", adsoyadUnvan);
            model.OnBilgilendirmeFormuIcerik = model.OnBilgilendirmeFormuIcerik.Replace("{1}", email);
            model.OnBilgilendirmeFormuIcerik = model.OnBilgilendirmeFormuIcerik.Replace("{2}", faturaAdres);
            model.OnBilgilendirmeFormuIcerik = model.OnBilgilendirmeFormuIcerik.Replace("{3}", teslimatAdres);
            model.OnBilgilendirmeFormuIcerik = model.OnBilgilendirmeFormuIcerik.Replace("{4}", telefon);
            model.OnBilgilendirmeFormuIcerik = model.OnBilgilendirmeFormuIcerik.Replace("{5}", odemeSekli);
            model.OnBilgilendirmeFormuIcerik = model.OnBilgilendirmeFormuIcerik.Replace("{6}", toplamAdet);
            model.OnBilgilendirmeFormuIcerik = model.OnBilgilendirmeFormuIcerik.Replace("{7}", toplamTutar);
            model.OnBilgilendirmeFormuIcerik = model.OnBilgilendirmeFormuIcerik.Replace("{8}", tarih);

            model.MesafeliSatisSozlesmesiIcerik = model.MesafeliSatisSozlesmesiIcerik.Replace("{0}", adsoyadUnvan);
            model.MesafeliSatisSozlesmesiIcerik = model.MesafeliSatisSozlesmesiIcerik.Replace("{1}", email);
            model.MesafeliSatisSozlesmesiIcerik = model.MesafeliSatisSozlesmesiIcerik.Replace("{2}", faturaAdres);
            model.MesafeliSatisSozlesmesiIcerik = model.MesafeliSatisSozlesmesiIcerik.Replace("{3}", teslimatAdres);
            model.MesafeliSatisSozlesmesiIcerik = model.MesafeliSatisSozlesmesiIcerik.Replace("{4}", telefon);
            model.MesafeliSatisSozlesmesiIcerik = model.MesafeliSatisSozlesmesiIcerik.Replace("{5}", odemeSekli);
            model.MesafeliSatisSozlesmesiIcerik = model.MesafeliSatisSozlesmesiIcerik.Replace("{6}", toplamAdet);
            model.MesafeliSatisSozlesmesiIcerik = model.MesafeliSatisSozlesmesiIcerik.Replace("{7}", toplamTutar);
            model.MesafeliSatisSozlesmesiIcerik = model.MesafeliSatisSozlesmesiIcerik.Replace("{8}", tarih);

            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> OdemeYap(OdemeIcerikVM model)
        {
            int result = 0;

            //1 - giriş yapılmışmı kontrol et
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null)
                return Json(new { error = true, message = "İşlem Sırasında Bir Hata Oluştu" });

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        var kullaniciId = kullanici.KullaniciId;

                        //önyüzden toplam rakam da gönder kontrol amaçlı
                        if (model.OdenecekToplamTutar > 0)
                        {
                            SepetVM sepetVM = new SepetVM() { KullaniciId = kullaniciId };
                            var sepetIcerik = await satisApiService.KullaniciSepetGetir(sepetVM);

                            //sepetteki rakam ile uyuşuyor mu?
                            if (model.OdenecekToplamTutar == sepetIcerik.OdenecekTutar)
                            {
                                model.KullaniciId = kullanici.KullaniciId;
                                model.SepetIcerik = sepetIcerik;
                                model.KullaniciIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                                result = await satisApiService.KullaniciOdemeYap(model);
                                model.OdemeId = result;

                                var kullaniciAdresler = await satisApiService.KullaniciSepetAdresleriGetir(new KullaniciAdresVM { KullaniciId = kullanici.KullaniciId });

                                var faturaAdresi = kullaniciAdresler.Where(p => p.AdresId == model.FaturaAdresId).FirstOrDefault();
                                var gonderimAdresi = kullaniciAdresler.Where(p => p.AdresId == model.GonderimAdresId).FirstOrDefault();

                                if (model.SiparisOdemeTipId == 1)
                                {
                                    Odeme3D odeme = new Odeme3D();
                                    ThreedsInitialize odemeSonuc = odeme.Should_Initialize_Threeds(model, kullanici, faturaAdresi, gonderimAdresi);

                                    if (odemeSonuc.Status == "success")
                                    {
                                        return Json(new { error = false, type = "3D", message = odemeSonuc.HtmlContent, location = "/Sepet/" });
                                    }
                                    else if (result > 0)
                                    {
                                        var sil = await satisApiService.KullaniciOdemeSil(result);
                                        return Json(new { error = true, message = "İşlem sırasında bir hata oluştu. Lütfen kredi kartı bilgilerinizi kontrol ediniz!", location = "/Sepet/OdemeSonuc/" + result });
                                    }
                                }
                                else
                                {
                                    return Json(new { error = false, type = "Normal", message = "İşlem Başarılı", location = "/Sepet/OdemeSonuc/" + result });
                                }
                            }
                            else
                            {
                                return Json(new { error = true, message = "İşlem sırasında bir hata oluştu!", location = "/Sepet/OdemeSonuc/" + result });
                            }
                        }
                    }
                }
            }

            //TempData["OdemeSonuc"] = result;


            return Json(new { error = true, message = "İşlem sırasında bir hata oluştu. Lütfen sayfayı yenileyiniz.", location = "/Sepet/OdemeSonuc/" + result });
        }

        [HttpPost]
        public async Task<IActionResult> OdemeCallback(CreateThreedsPaymentRequest request)
        {
            Odeme3D odemeSonuc = new Odeme3D();
            ThreedsPayment sonuc = odemeSonuc.Should_Create_Threeds_Payment(request);

            int siparisId = 0;
            int.TryParse(request.ConversationId, out siparisId);

            if (sonuc.Status == "success")
            {

                request.ConversationId = "/Sepet/OdemeSonuc/" + request.ConversationId;
                //başarılı olduğu için ödeme bilgisini güncelleyelim
                KullaniciSiparisVM model = new KullaniciSiparisVM() { SiparisId = siparisId, TransferId = request.PaymentId };
                var result = await satisApiService.KullaniciSiparisGuncelle(model);

                return View(request);
            }
            else
            {
                var sil = await satisApiService.KullaniciOdemeSil(siparisId);
                return RedirectToAction("", "Sepet");
            }
        }

        public async Task<IActionResult> OdemeSonuc(int id)
        {
            OdemeSonucVM result = new OdemeSonucVM();

            //1 - giriş yapılmışmı kontrol et
            var session = HttpContext.Session.GetString("Kullanici");

            if (session == null || id == 0)
                return RedirectToAction("", "Sepet");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        var kullaniciId = kullanici.KullaniciId;

                        OdemeVM model = new OdemeVM() { KullaniciId = kullaniciId, SiparisId = id };
                        result = await satisApiService.KullaniciOdemeSonucGetir(model);
                    }
                }
            }

            return View(result);
        }

        #region Partials

        [HttpGet]
        public async Task<PartialViewResult> AdresListesiPartial(string tip)
        {
            List<SepetAdresVM> result = new List<SepetAdresVM>();

            ViewData["Tip"] = tip;

            var session = HttpContext.Session.GetString("Kullanici");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        KullaniciAdresVM kullaniciAdresVM = new KullaniciAdresVM() { KullaniciId = kullanici.KullaniciId };
                        result = await satisApiService.KullaniciSepetAdresleriGetir(kullaniciAdresVM);
                    }
                }
            }

            //  model = await satisApiService.KullaniciSepetAdresleriGetir(Guid.Parse("e61c19f4-aee1-4617-aadd-d7a5a1308f55"));

            return PartialView("~/Views/Sepet/Partials/AdresListesi.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> AdresDetayPartial(int? id)
        {
            SepetAdresVM model = new SepetAdresVM();

            if (id != null)
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
                            SepetAdresVM sepetAdresVM = new SepetAdresVM() { KullaniciId = kullanici.KullaniciId, AdresId = id.Value };
                            model = await satisApiService.KullaniciSepetAdresGetir(sepetAdresVM);
                        }
                    }
                }
            }
            else
            {
                SepetAdresVM sepetAdresVM = new SepetAdresVM() { AdresId = 0 };
                model = await satisApiService.KullaniciSepetAdresGetir(sepetAdresVM);
            }

            //if (id != null)
            //{
            //    SepetAdresVM sepetAdresVM = new SepetAdresVM() { KullaniciId = Guid.Parse("e61c19f4-aee1-4617-aadd-d7a5a1308f55"), AdresId = id.Value };
            //    model = await satisApiService.KullaniciSepetAdresGetir(sepetAdresVM);
            //}

            return PartialView("~/Views/Sepet/Partials/AdresDetay.cshtml", model);
        }

        [HttpGet]
        public async Task<PartialViewResult> SiparisListesiPartial()
        {
            List<SiparisVM> result = new List<SiparisVM>();

            var session = HttpContext.Session.GetString("Kullanici");

            if (session != null)
            {
                var token = JsonConvert.DeserializeObject<TokenVM>(session);
                if (token != null)
                {
                    var kullanici = await uyelikApiService.KullaniciGetir(token);
                    if (kullanici != null)
                    {
                        KullaniciSiparisVM kullaniciAdresVM = new KullaniciSiparisVM() { KullaniciId = kullanici.KullaniciId };
                        result = await satisApiService.KullaniciSiparisListesiGetir(kullaniciAdresVM);
                    }
                }
            }

            return PartialView("~/Views/Sepet/Partials/SiparisListesi.cshtml", result);
        }

        [HttpGet]
        public async Task<PartialViewResult> SiparisDetayPartial(int? id)
        {
            SiparisVM model = new SiparisVM();

            if (id != null)
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
                            KullaniciSiparisVM sepetAdresVM = new KullaniciSiparisVM() { KullaniciId = kullanici.KullaniciId, SiparisId = id.Value };
                            model = await satisApiService.KullaniciSiparisDetayGetir(sepetAdresVM);
                        }
                    }
                }
            }

            return PartialView("~/Views/Sepet/Partials/SiparisDetay.cshtml", model);
        }

        [HttpGet]
        public async Task<List<AdresIlceVM>> SepetAdresIlceGetir(int id)
        {
            var sonuc = await satisApiService.SepetAdresIlceGetir(id);
            return sonuc;
        }

        #endregion

    }
}
