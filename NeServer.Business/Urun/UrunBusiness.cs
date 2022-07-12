using AutoMapper;
using NeSever.Common.Commands.Urun;
using NeSever.Common.Infra.Command;
using NeSever.Common.Models.Admin.AramaSonucVM;
using NeSever.Common.Models.Admin.AramaVM;
using NeSever.Common.Models.Admin.KayitVM;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Urun;
using NeSever.Data.DataService;
using NeSever.Data.Entities;
using NeSever.User.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace NeServer.Business.Urun
{
    public interface IUrunBusiness
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
        #endregion

        #endregion

        #region Kategori
        Task<CommandResponse<int>> KategoriKaydet(KategoriCommand command);
        Task<KategoriVM> KategoriGetirById(int id);
        Task<List<KategoriAramaResultVM>> KategoriArama(KategoriAramaVM kategoriAramaVM);
        Task<int> KategoriSil(int id);
        Task<List<KategoriVM>> KategoriListesiniGetir();
        #endregion

        #region KategoriBanner       
        Task<KategoriBannerVM> KategoriBannerGetirById(int id);
        Task<CommandResponse<int>> KategoriBannerKaydet(KategoriBannerCommand command);
        Task<List<KategoriBannerAramaResultVM>> KategoriBannerArama(KategoriBannerAramaVM kategoriAramaVM);
        Task<int> KategoriBannerSil(int id);
        Task<List<KategoriBannerVM>> KategoriBannerListesiniGetir();
        #endregion

        #region Urun
        Task<CommandResponse<int>> UrunKaydet(UrunCommand command);
        Task<UrunVM> UrunGetirById(int id);
        Task<List<UrunAramaResultVM>> UrunArama(UrunAramaVM urunAramaVM);
        Task<int> UrunSil(int id);
        Task<List<UrunResimVM>> UrunResimGetirById(int id);
        Task<List<UrunKategoriVM>> UrunKategoriGetirById(int id);
        Task<int> UrunResimKaydet(UrunResimVM urunResimVM);
        Task<List<GoruntulenenUrunAramaSonucVM>> GoruntulenenUrunRaporuGetir(GoruntulenenUrunAramaVM model);
        Task<List<YonlendirilenUrunAramaSonucVM>> YonlendirilenUrunRaporuGetir(YonlendirilenUrunAramaVM model);
        Task YonlendirmeSayisiArttir(UrunYonlendirmeSayisi urun);
        Task KullaniciFiyatGorListArttir(KullaniciFiyatGorVM kullanici);
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

    public class UrunBusiness : BaseBusiness, IUrunBusiness
    {
        private readonly IUrunDataService urunDataService;
        private readonly IMapper mapper;

        public UrunBusiness(IUrunDataService urunDataService, IMapper mapper)
        {
            this.urunDataService = urunDataService;
            this.mapper = mapper;
        }

        #region Marka

        #region Admin

        #endregion

        #region FrontEnd
        public async Task<List<KategoriIcerikVM>> KategoriIcerikListGetir(bool anasayfadaGoster = true)
        {
            return await urunDataService.GetKategoriIcerikList(anasayfadaGoster);
        }
        public async Task<List<MarkaIcerikVM>> MarkaIcerikListGetir()
        {
            return await urunDataService.GetMarkaIcerikList();
        }
        public async Task<List<UrunIcerikVM>> TrendKadinUrunIcerikListGetir()
        {
            return await urunDataService.GetTrendKadinUrunIcerikList();
        }
        public async Task<List<UrunIcerikVM>> TrendErkekUrunIcerikListGetir()
        {
            return await urunDataService.GetTrendErkekUrunIcerikList();
        }
        public async Task<IPagedList<UrunIcerikVM>> UrunIcerikListGetir(UrunIcerikAramaVM urunIcerikAramaVM)
        {
            return await urunDataService.GetUrunIcerikList(urunIcerikAramaVM);
        }
        public async Task<UrunDetayIcerikVM> UrunDetayIcerikGetir(int id)
        {
            return await urunDataService.GetUrunDetayIcerikById(id);
        }
        public async Task<MarkaAramaSayfaSonucVM> MarkaListGetir(string m)
        {
            return await urunDataService.MarkaListGetir(m);
        }
        public async Task<string> MarkaAdindanIdGetir(string markaAdi)
        {
            return await urunDataService.MarkaAdindanIdGetir(markaAdi);
        }
        #endregion

        #endregion

        #region Kategori
        public async Task<CommandResponse<int>> KategoriKaydet(KategoriCommand command)
        {
            CommandResponse<int> response = new CommandResponse<int>(command);
            int sonuc = 0;
            try
            {
                sonuc = await urunDataService.KategoriKayit(command.Kategori);

            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.User_ErrorOccuredWhileAddingRecord, ex);
            }

            return Ok(response, sonuc);
        }
        public async Task<KategoriVM> KategoriGetirById(int id)
        {
            Kategori kategori = await urunDataService.GetKategoriById(id);
            KategoriVM model = mapper.Map<Kategori, KategoriVM>(kategori);
            return model;
        }

        public async Task<List<KategoriAramaResultVM>> KategoriArama(KategoriAramaVM kategoriAramaVM)
        {

            return await urunDataService.GetKategoriList(kategoriAramaVM);

        }
        public async Task<int> KategoriSil(int id)
        {
            return await urunDataService.DeleteKategori(id);
        }

        public async Task<List<KategoriVM>> KategoriListesiniGetir()
        {
            return await urunDataService.GetKategoriList();
        }

        #endregion

        #region KategoriBanner        

        public async Task<KategoriBannerVM> KategoriBannerGetirById(int id)
        {
            KategoriBanner kategori = await urunDataService.KategoriBannerGetirById(id);
            KategoriBannerVM model = mapper.Map<KategoriBanner, KategoriBannerVM>(kategori);
            return model;
        }

        public async Task<CommandResponse<int>> KategoriBannerKaydet(KategoriBannerCommand command)
        {
            CommandResponse<int> response = new CommandResponse<int>(command);
            int sonuc = 0;
            try
            {
                sonuc = await urunDataService.KategoriBannerKayit(command.KategoriBanner);

            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.User_ErrorOccuredWhileAddingRecord, ex);
            }

            return Ok(response, sonuc);
        }

        public async Task<List<KategoriBannerAramaResultVM>> KategoriBannerArama(KategoriBannerAramaVM kategoriAramaVM)
        {
            return await urunDataService.KategoriBannerArama(kategoriAramaVM);
        }

        public async Task<int> KategoriBannerSil(int id)
        {
            return await urunDataService.KategoriBannerSil(id);
        }

        public async Task<List<KategoriBannerVM>> KategoriBannerListesiniGetir()
        {
            return await urunDataService.GetKategoriBannerList();
        }

        #endregion

        #region Urun
        public async Task<CommandResponse<int>> UrunKaydet(UrunCommand command)
        {
            CommandResponse<int> response = new CommandResponse<int>(command);
            int sonuc = 0;
            try
            {
                sonuc = await urunDataService.UrunKayit(command.Urun);

            }
            catch (Exception ex)
            {
                return ServerError(response, ErrorCodes.User_ErrorOccuredWhileAddingRecord, ex);
            }

            return Ok(response, sonuc);
        }
        public async Task<UrunVM> UrunGetirById(int id)
        {
            NeSever.Data.Entities.Urun urun = await urunDataService.GetUrunById(id);
            UrunVM model = mapper.Map<NeSever.Data.Entities.Urun, UrunVM>(urun);
            return model;
        }
        public async Task<List<UrunAramaResultVM>> UrunArama(UrunAramaVM urunAramaVM)
        {

            return await urunDataService.GetUrunList(urunAramaVM);
        }
        public async Task<int> UrunSil(int id)
        {
            return await urunDataService.DeleteUrun(id);
        }

        public async Task<List<UrunResimVM>> UrunResimGetirById(int id)
        {
            return await urunDataService.GetUrunResimById(id);
        }
        public async Task<List<UrunKategoriVM>> UrunKategoriGetirById(int id)
        {
            return await urunDataService.GetUrunKategoriById(id);
        }
        public async Task<int> UrunResimKaydet(UrunResimVM urunResimVM)
        {
            int sonuc = 0;
            try
            {
                return await urunDataService.UrunResimKaydet(urunResimVM);
            }
            catch (Exception ex)
            {
                return sonuc;
            }
        }
        public async Task<List<GoruntulenenUrunAramaSonucVM>> GoruntulenenUrunRaporuGetir(GoruntulenenUrunAramaVM model)
        {
            return await urunDataService.GoruntulenenUrunRaporuGetir(model);
        }

        public async Task<List<YonlendirilenUrunAramaSonucVM>> YonlendirilenUrunRaporuGetir(YonlendirilenUrunAramaVM model)
        {
            return await urunDataService.YonlendirilenUrunRaporuGetir(model);
        }

        public async Task YonlendirmeSayisiArttir(UrunYonlendirmeSayisi urun)
        {
            await urunDataService.YonlendirmeSayisiArttir(urun);
        }
        public async Task KullaniciFiyatGorListArttir(KullaniciFiyatGorVM kullanici)
        {
            await urunDataService.KullaniciFiyatGorListArttir(kullanici);
        }

        public async Task<SurprizHediyeSonucVM> SurprizHediyeKontrol(SurprizHediyeVM surprizHediye)
        {
            return await urunDataService.SurprizHediyeKontrol(surprizHediye);
        }

        #endregion                

        #region Sürpriz Ürün
        public async Task<List<SurprizUrunGetirVM>> SurprizUrunGetir(SurprizUrunKayitVM data)
        {
            return await urunDataService.SurprizUrunGetir(data);
        }
        public async Task<SurprizUrunKayitVM> SurprizUrunGetirById(int id)
        {
            return await urunDataService.SurprizUrunGetirById(id);
        }
        public async Task<int> SurprizUrunKayit(SurprizUrunKayitVM model)
        {
            return await urunDataService.SurprizUrunKayit(model);
        }
        public async Task<List<SurprizUrunAramaSonucVM>> SurprizUrunArama(SurprizUrunAramaVM model)
        {
            return await urunDataService.SurprizUrunArama(model);
        }
        public async Task<int> SurprizUrunSil(int id)
        {
            return await urunDataService.SurprizUrunSil(id);
        }

        #endregion
    }
}
