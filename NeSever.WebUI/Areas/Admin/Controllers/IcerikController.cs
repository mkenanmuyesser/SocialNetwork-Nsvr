using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Sayfa;
using NeSever.WebUI.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IcerikController : BaseController
    {
        private IHostingEnvironment environment;
        private readonly ISayfaApiService sayfaApiService;
        private readonly IUrunApiService urunApiService;

        public IcerikController(IHostingEnvironment environment,
                                ISayfaApiService sayfaApiService,
                                IUrunApiService urunApiService)
        {
            this.environment = environment;
            this.sayfaApiService = sayfaApiService;
            this.urunApiService = urunApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Hobi

        [HttpGet]
        [ActionName("HobiKayit")]
        public async Task<IActionResult> HobiKayitGet(int? Id)
        {
            HobiVM model = new HobiVM();

            if (Id.HasValue)
            {
                model = await sayfaApiService.HobiGetirById(Id.Value);

            }
            else
            {
                model.AktifMi = true;
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("HobiKayit")]
        public async Task<IActionResult> HobiKayitPost(HobiVM data, IFormFile file)
        {
            JsonResult result;
            if (file != null)
            {
                if (file != null)
                //Resmi binary olarak al
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    data.Resim = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    data.ResimUrl = file.FileName;

                }
            }
            var id = await sayfaApiService.HobiKaydet(data);
            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.HobiId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.HobiId > 0 ? "update" : "insert" });
            return result;
        }


        [HttpGet]
        public IActionResult HobiArama()
        {
            HobiAramaVM model = new HobiAramaVM();
            model.AktifMi = -1;
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> HobiArama(HobiAramaVM model)
        {
            var result = await sayfaApiService.HobiArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }
        [HttpPost]
        public async Task<IActionResult> HobiSil(int id)
        {
            var result = await sayfaApiService.HobiSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }

        #endregion

        #region IlgiAlan

        [HttpGet]
        [ActionName("IlgiAlanKayit")]
        public async Task<IActionResult> IlgiAlanKayitGet(int? Id)
        {
            IlgiAlanVM model = new IlgiAlanVM();

            if (Id.HasValue)
            {
                model = await sayfaApiService.IlgiAlanGetirById(Id.Value);

            }
            else
            {
                model.AktifMi = true;
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("IlgiAlanKayit")]
        public async Task<IActionResult> IlgiAlanKayitPost(IlgiAlanVM data, IFormFile file)
        {
            JsonResult result;
            if (file != null)
            {
                if (file != null)
                //Resmi binary olarak al
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    data.Resim = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    data.ResimUrl = file.FileName;

                }
            }
            var id = await sayfaApiService.IlgiAlanKaydet(data);

            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.IlgiAlanId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.IlgiAlanId > 0 ? "update" : "insert" });
            return result;
        }

        [HttpGet]
        public IActionResult IlgiAlanArama()
        {
            IlgiAlanAramaVM model = new IlgiAlanAramaVM();
            model.AktifMi = -1;
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> IlgiAlanArama(IlgiAlanAramaVM model)
        {
            var result = await sayfaApiService.IlgiAlanArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }
        [HttpPost]
        public async Task<IActionResult> IlgiAlanSil(int id)
        {
            var result = await sayfaApiService.IlgiAlanSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }

        #endregion

        #region HediyeKarti

        [HttpGet]
        [ActionName("HediyeKartiKayit")]
        public async Task<IActionResult> HediyeKartiKayitGet(int? Id)
        {
            HediyeKartVM model = new HediyeKartVM();

            if (Id.HasValue)
            {
                model = await sayfaApiService.HediyeKartiGetirById(Id.Value);
               
            }
            else
            {
                model.AktifMi = true;
                model.HediyeKartKategoriTipleri = await sayfaApiService.HediyeKartKategoriTipleriniGetir();
            }
           
            return View(model);
        }

        [HttpPost]
        [ActionName("HediyeKartiKayit")]
        public async Task<JsonResult> HediyeKartiKayitPost(HediyeKartVM data, IFormFile dosya, IFormFile kucukDosya)
        {
            JsonResult result;
            if(data.AciklamaContent != null)
            {
                data.Aciklama = data.AciklamaContent.Substring(3,data.AciklamaContent.Length-7).Trim();
            }          
            data.KayitTarih = DateTime.Now;
            if (dosya != null && dosya.Length > 0)
            {
                string ext = dosya.FileName.Split('.').LastOrDefault();
                if (ext != null && (ext == "gif" || ext == "png" || ext == "jpg" || ext == "jpeg"))
                {
                    using (var ms = new MemoryStream())
                    {
                        dosya.CopyTo(ms);
                        data.Dosya = ms.ToArray();
                        data.DosyaAdi = dosya.FileName;
                    }
                }
                else
                {
                    result = Json(new { id = 0, message = "control", operation = "file" });
                }
            }

            if (kucukDosya != null && kucukDosya.Length > 0)
            {
                string ext = kucukDosya.FileName.Split('.').LastOrDefault();
                if (ext != null && (ext == "gif" || ext == "png" || ext == "jpg" || ext == "jpeg"))
                {
                    using (var ms = new MemoryStream())
                    {
                        kucukDosya.CopyTo(ms);
                        data.KucukDosya = ms.ToArray();
                        data.KucukDosyaAdi = kucukDosya.FileName;
                    }
                }
                else
                {
                    result = Json(new { id = 0, message = "control", operation = "file" });
                }
            }
            var id = await sayfaApiService.HediyeKartiKaydet(data);

            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.HediyeKartId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.HediyeKartId > 0 ? "update" : "insert" });
            return result;
        }

      

        [HttpGet]
        public  IActionResult HediyeKartiArama()
        {
            HediyeKartAramaVM hediyeKartAramaVM = new HediyeKartAramaVM();
            hediyeKartAramaVM.AktifMi = -1;
            return View(hediyeKartAramaVM);

        }
        [HttpPost]
        public async Task<IActionResult> HediyeKartArama(HediyeKartAramaVM model)
        {
            var result = await sayfaApiService.HediyeKartArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }
        [HttpPost]
        public async Task<IActionResult> HediyeKartSil(int id)
        {
            var result = await sayfaApiService.HediyeKartSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }

        #endregion

        #region DuvarResim

        [HttpGet]
        [ActionName("DuvarResimKayit")]
        public async Task<IActionResult> DuvarResimKayitGet(int? id)
        {
            DuvarResimKayitVM model;
            if (id.HasValue && id.Value > 0)
            {
                model = await sayfaApiService.DuvarResimKayitVMGetir(id.Value);
            }
            else
            {
                model = new DuvarResimKayitVM()
                {                     
                    Sira = 1,
                    AktifMi = true,
                };
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("DuvarResimKayit")]
        public async Task<JsonResult> DuvarResimKayitPost(DuvarResimKayitVM model, IFormFile dosya, IFormFile kucukDosya)
        {
            JsonResult result;

            if (dosya != null && dosya.Length > 0)
            {
                string ext = dosya.FileName.Split('.').LastOrDefault();
                if (ext != null && (ext == "gif" || ext == "png" || ext == "jpg" || ext == "jpeg"))
                {
                    using (var ms = new MemoryStream())
                    {
                        dosya.CopyTo(ms);
                        model.Dosya = ms.ToArray();
                        model.DosyaAdi = dosya.FileName;
                    }
                }
                else
                {
                    result = Json(new { id = 0, message = "control", operation = "file" });
                }
            }

            if (kucukDosya != null && kucukDosya.Length > 0)
            {
                string ext = kucukDosya.FileName.Split('.').LastOrDefault();
                if (ext != null && (ext == "gif" || ext == "png" || ext == "jpg" || ext == "jpeg"))
                {
                    using (var ms = new MemoryStream())
                    {
                        kucukDosya.CopyTo(ms);
                        model.KucukDosya = ms.ToArray();
                        model.KucukDosyaAdi = kucukDosya.FileName;
                    }
                }
                else
                {
                    result = Json(new { id = 0, message = "control", operation = "file" });
                }
            }

            var id = await sayfaApiService.DuvarResimKaydet(model);

            if (id > 0)
                result = Json(new { id = id, message = "success", operation = model.DuvarResimId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = model.DuvarResimId > 0 ? "update" : "insert" });

            return result;
        }

        [HttpGet]
        [ActionName("DuvarResimArama")]
        public async Task<IActionResult> DuvarResimAramaGet()
        {
            var model = new DuvarResimAramaVM()
            {                 
                Aktiflik = 1
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("DuvarResimArama")]
        public async Task<IActionResult> DuvarResimAramaPost(DuvarResimAramaVM model)
        {
            var result = await sayfaApiService.DuvarResimAramaSonucVMGetir(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;

            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        [HttpGet]
        [ActionName("DuvarResimSil")]
        public async Task<JsonResult> DuvarResimSilGet(int id)
        {
            var data = await sayfaApiService.DuvarResimSil(id);

            JsonResult result = Json(data);

            return result;
        }

        #endregion

        #region Hediye Kart Kategori

        [HttpGet]
        [ActionName("HediyeKartKategoriKayit")]
        public async Task<IActionResult> HediyeKartKategoriKayitGet(int? Id)
        {
            HediyeKartKategoriVM model = new HediyeKartKategoriVM();

            if (Id.HasValue)
            {
                model = await sayfaApiService.HediyeKartKategoriGetirById(Id.Value);

            }
            else
            {
                model.AktifMi = true;
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("HediyeKartKategoriKayit")]
        public async Task<JsonResult> HediyeKartKategoriKayitPost(HediyeKartKategoriVM data)
        {
            JsonResult result;
           
            var id = await sayfaApiService.HediyeKartKategoriKaydet(data);
            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.HediyeKartKategoriId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.HediyeKartKategoriId > 0 ? "update" : "insert" });
            return result;

        }

        [HttpGet]
        public IActionResult HediyeKartKategoriArama()
        {
            HediyeKartKategoriAramaVM hediyeKartKategoriAramaVM = new HediyeKartKategoriAramaVM();
            hediyeKartKategoriAramaVM.AktifMi = -1;
            return View(hediyeKartKategoriAramaVM);

        }

        [HttpPost]
        public async Task<IActionResult> HediyeKartKategoriArama(HediyeKartKategoriAramaVM model)
        {
            var result = await sayfaApiService.HediyeKartKategoriArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }

        [HttpPost]
        public async Task<IActionResult> HediyeKartKategoriSil(int id)
        {
            var result = await sayfaApiService.HediyeKartKategoriSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }

        #endregion

        #region Sürpriz Ürün

        [HttpGet]
        [ActionName("SurprizUrunKayit")]
        public async Task<IActionResult> SurprizUrunKayitGet(int? Id)
        {
            SurprizUrunKayitVM model = new SurprizUrunKayitVM();
            if (Id.HasValue)
            {
                model = await urunApiService.SurprizUrunGetirById(Id.Value);
            }
            else
            {
                model.AktifMi = true;
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("SurprizUrunKayit")]
        public async Task<IActionResult> SurprizUrunKayitPost(SurprizUrunKayitVM model)
        {
            JsonResult result;
            var id = await urunApiService.SurprizUrunKayit(model);
            if (id > 0)
                result = Json(new { id = id, message = "success", operation = model.SurpizUrunId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = model.SurpizUrunId > 0 ? "update" : "insert" });
            return result;
        }

        [HttpPost]
        [ActionName("SurprizUrunGetir")]
        public async Task<IActionResult> SurprizUrunGetir(string kelime)
        {

            SurprizUrunKayitVM data = new SurprizUrunKayitVM();
            if(kelime != null && kelime.Length >= 3)
            {
                var sonuc = 0;
                for (int i = 0; i < kelime.Length; i++)
                    if (char.IsDigit(kelime[i]))
                        sonuc++; 

                if (sonuc == kelime.Length)
                {
                    data.UrunIdArama = Int32.Parse(kelime);
                }
                else
                {
                    data.UrunAdi = kelime;
                    data.UrunIdArama = 0;
                }
                var urunler = await urunApiService.SurprizUrunGetir(data);

                return Json(urunler);
            }

            return Json(null);
        }

        [HttpGet]
        public IActionResult SurprizUrunArama()
        {
            SurprizUrunAramaVM model = new SurprizUrunAramaVM();
            model.AktifMi = -1;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SurprizUrunArama(SurprizUrunAramaVM model)
        {
            var result = await urunApiService.SurprizUrunArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });
        }

        [HttpPost]
        public async Task<IActionResult> SurprizUrunSil(int id)
        {
            var result = await urunApiService.SurprizUrunSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }
        #endregion

        #region İndirim Kuponu 

        [HttpGet]
        [ActionName("IndirimKuponuKayit")]
        public async Task<IActionResult> IndirimKuponuKayitGet(int? Id)
        {
            IndirimKuponuKayitVM model = new IndirimKuponuKayitVM();

            if (Id.HasValue)
            {
                model = await sayfaApiService.IndirimKuponuGetirById(Id.Value);
                if (!string.IsNullOrEmpty(model.ResimUrl))
                {
                    model.ResimBase64 = Convert.ToBase64String(model.Resim);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("IndirimKuponuKayit")]
        public async Task<JsonResult> IndirimKuponuKayitPost(IndirimKuponuKayitVM data, IFormFile file)
        {
            JsonResult result;

            if(data.AciklamaContent != null)
            {
                data.Aciklama = data.AciklamaContent.Substring(3, data.AciklamaContent.Length - 7).Trim();
            }        
            
            if(Convert.ToDateTime(data.BaslangicTarihi) < DateTime.Now.Date || Convert.ToDateTime(data.BaslangicTarihi) >= Convert.ToDateTime(data.BitisTarihi) || Convert.ToDateTime(data.BitisTarihi) < DateTime.Now.Date)
            {
                result = Json(new { id = 0, message = "tarih", operation = data.IndirimKuponId > 0 ? "update" : "insert" });
                return result;
            }


            if (file != null)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                data.Resim = ms.ToArray();
                ms.Close();
                ms.Dispose();
                data.ResimUrl = file.FileName;
            }
            else
            {
                var kuponVarmi =  await sayfaApiService.IndirimKuponuGetirById(data.IndirimKuponId);
                if(kuponVarmi == null)
                {
                    result = Json(new { id = 0, message = "resim", operation = data.IndirimKuponId > 0 ? "update" : "insert" });
                    return result;
                }                  
            }


            var id = await sayfaApiService.IndirimKuponuKaydet(data);

            if (id > 0)
                result = Json(new { id = id, message = "success", operation = data.IndirimKuponId > 0 ? "update" : "insert" });
            else
                result = Json(new { id = id, message = "error", operation = data.IndirimKuponId > 0 ? "update" : "insert" });
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> IndirimKuponuArama()
        {
            IndirimKuponuAramaVM BannerAramaVM = new IndirimKuponuAramaVM();
            BannerAramaVM.AktifMi = -1;
            return View(BannerAramaVM);

        }
        [HttpPost]
        public async Task<IActionResult> IndirimKuponuArama(IndirimKuponuAramaVM model)
        {
            var result = await sayfaApiService.IndirimKuponuArama(model);
            int totalCount = result.Any() ? result.FirstOrDefault().TotalCount : 0;
            return Json(new { draw = model.draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = result });

        }
        [HttpPost]
        public async Task<IActionResult> IndirimKuponuSil(int id)
        {
            var result = await sayfaApiService.IndirimKuponuSil(id);

            return Json(new { message = "silme işlemi başarılı" });

        }

        #endregion
    }
}
