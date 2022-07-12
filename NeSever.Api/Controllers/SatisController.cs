using Microsoft.AspNetCore.Mvc;
using NeServer.Business.Program;
using NeSever.Common.Models.Satis;
using System;
using System.Threading.Tasks;

namespace NeSever.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SatisController : Controller
    {
        private readonly ISatisBusiness satisBusiness;

        public SatisController(ISatisBusiness satisBusiness)
        {
            this.satisBusiness = satisBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Sepet

        #region Admin


        #endregion

        #region FrontEnd

        [HttpGet]
        [Route("OnBilgilendirmeFormuGetir")]
        public async Task<IActionResult> OnBilgilendirmeFormuGetir()
        {
            var result = await satisBusiness.OnBilgilendirmeFormuGetir();

            return Ok(result);
        }

        [HttpGet]
        [Route("MesafeliSatisSozlesmesiGetir")]
        public async Task<IActionResult> MesafeliSatisSozlesmesiGetir()
        {
            var result = await satisBusiness.MesafeliSatisSozlesmesiGetir();

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSepetGetir")]
        public async Task<IActionResult> KullaniciSepetGetir(SepetVM model)
        {
            var result = await satisBusiness.KullaniciSepetGetir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSepetTemizle")]
        public async Task<IActionResult> KullaniciSepetTemizle(SepetVM model)
        {
            var result = await satisBusiness.KullaniciSepetTemizle(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSepetUrunArttir")]
        public async Task<IActionResult> KullaniciSepetUrunArttir(SepetVM model)
        {
            var result = await satisBusiness.KullaniciSepetUrunArttir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSepetUrunEksilt")]
        public async Task<IActionResult> KullaniciSepetUrunEksilt(SepetVM model)
        {
            var result = await satisBusiness.KullaniciSepetUrunEksilt(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSepetUrunSil")]
        public async Task<IActionResult> KullaniciSepetUrunSil(SepetVM model)
        {
            var result = await satisBusiness.KullaniciSepetUrunSil(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSepetAdresleriGetir")]
        public async Task<IActionResult> KullaniciSepetAdresleriGetir(KullaniciAdresVM model)
        {
            var result = await satisBusiness.KullaniciSepetAdresleriGetir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSepetAdresGetir")]
        public async Task<IActionResult> KullaniciSepetAdresGetir(SepetAdresVM model)
        {
            var result = await satisBusiness.KullaniciSepetAdresGetir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSepetAdresKaydetGuncelle")]
        public async Task<IActionResult> KullaniciSepetAdresKaydetGuncelle(SepetAdresVM model)
        {
            var result = await satisBusiness.KullaniciSepetAdresKaydetGuncelle(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSepetAdresSil")]
        public async Task<IActionResult> KullaniciSepetAdresSil(SepetAdresVM model)
        {
            var result = await satisBusiness.KullaniciSepetAdresSil(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciAdreslerGetir")]
        public async Task<IActionResult> KullaniciAdreslerGetir(AdresVM model)
        {
            var result = await satisBusiness.KullaniciAdreslerGetir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciOdemeGetir")]
        public async Task<IActionResult> KullaniciOdemeGetir(OdemeVM model)
        {
            var result = await satisBusiness.KullaniciOdemeGetir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciOdemeYap")]
        public async Task<IActionResult> KullaniciOdemeYap(OdemeIcerikVM model)
        {
            var result = await satisBusiness.KullaniciOdemeYap(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciOdemeSonucGetir")]
        public async Task<IActionResult> KullaniciOdemeSonucGetir(OdemeVM model)
        {
            var result = await satisBusiness.KullaniciOdemeSonucGetir(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("SepetAdresIlceGetir")]
        public async Task<IActionResult> SepetAdresIlceGetir(int id)
        {
            var result = await satisBusiness.SepetAdresIlceGetir(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("KullaniciOdemeSil")]
        public async Task<IActionResult> KullaniciOdemeSil(int id)
        {
            var result = await satisBusiness.KullaniciOdemeSil(id);

            return Ok(result);
        }

        #endregion

        #endregion

        #region Sipariş

        #region Admin

        [HttpGet]
        [Route("SatisAdresIlGetir")]
        public async Task<IActionResult> SatisAdresIlGetir()
        {
            var result = await satisBusiness.SatisAdresIlGetir();

            return Ok(result);
        }

        [HttpGet]
        [Route("OdemeDurumTipListesiGetir")]
        public async Task<IActionResult> OdemeDurumTipListesiGetir()
        {
            var result = await satisBusiness.OdemeDurumTipListesiGetir();

            return Ok(result);
        }

        [HttpGet]
        [Route("SiparisDurumTipListesiGetir")]
        public async Task<IActionResult> SiparisDurumTipListesiGetir()
        {
            var result = await satisBusiness.SiparisDurumTipListesiGetir();

            return Ok(result);
        }

        [HttpGet]
        [Route("SiparisOdemeTipListesiGetir")]
        public async Task<IActionResult> SiparisOdemeTipListesiGetir()
        {
            var result = await satisBusiness.SiparisOdemeTipListesiGetir();

            return Ok(result);
        }

        [HttpPost]
        [Route("SiparisAramaSonuc")]
        public async Task<IActionResult> SiparisAramaSonuc(SiparisAramaVM model)
        {
            var result = await satisBusiness.SiparisAramaSonuc(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("SiparisSil")]
        public async Task<IActionResult> SiparisSil(int id)
        {
            var result = await satisBusiness.SiparisSil(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("SiparisDetay")]
        public async Task<IActionResult> SiparisDetay(int id)
        {
            var result = await satisBusiness.SiparisDetay(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("SiparisGuncelle")]
        public async Task<IActionResult> SiparisGuncelle(SiparisAramaDetayVM model)
        {
            var result = await satisBusiness.SiparisGuncelle(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("SiparisHareketKaydet")]
        public async Task<IActionResult> SiparisHareketKaydet(SiparisAramaDetayVM model)
        {
            var result = await satisBusiness.SiparisHareketKaydet(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("SiparisHareketSil")]
        public async Task<IActionResult> SiparisHareketSil(int id)
        {
            var result = await satisBusiness.SiparisHareketSil(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("SiparisDetayDurum")]
        public async Task<IActionResult> SiparisDetayDurum(int id)
        {
            var result = await satisBusiness.SiparisDetayDurum(id);

            return Ok(result);
        }
        #endregion

        #region FrontEnd

        [HttpPost]
        [Route("KullaniciSiparisListesiGetir")]
        public async Task<IActionResult> KullaniciSiparisListesiGetir(KullaniciSiparisVM model)
        {
            var result = await satisBusiness.KullaniciSiparisListesiGetir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSiparisDetayGetir")]
        public async Task<IActionResult> KullaniciSiparisDetayGetir(KullaniciSiparisVM model)
        {
            var result = await satisBusiness.KullaniciSiparisDetayGetir(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("KullaniciSiparisGuncelle")]
        public async Task<IActionResult> KullaniciSiparisGuncelle(KullaniciSiparisVM model)
        {
            var result = await satisBusiness.KullaniciSiparisGuncelle(model);

            return Ok(result);
        }

        #endregion

        #endregion
    }
}
