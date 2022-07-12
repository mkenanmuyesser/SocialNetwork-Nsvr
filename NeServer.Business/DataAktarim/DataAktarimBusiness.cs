using AutoMapper;
using NeSever.Common.Models.DataAktarim;
using NeSever.Data.DataService.DataAktarim;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeServer.Business.DataAktarim
{
    public interface IDataAktarimBusiness
    {
        Task<WebSiteBilgileriVM> WebSiteBilgileriniGetir();

        Task<WebSiteVM> WebSiteArama(WebSiteVM webSiteVM);

        Task<int> DurumGuncelle(int id);

        Task<List<WebSiteAramaSonucVM>> WebSiteListesiniGetir();

        Task<UrunLinkIslemBilgileriVM> UrunLinkBilgileriniGetir();
        Task<UrunLinkIslemVM> UrunLinkArama(UrunLinkIslemVM UrunLinkIslemVM);

        Task<int> UrunLinkDurumGuncelle(int id);

        Task<HataLogVM> HataLogArama(HataLogVM HataLogVM);


    }
    public class DataAktarimBusiness : BaseBusiness, IDataAktarimBusiness
    {
        private readonly IDataAktarimService dataAktarimService;
        private readonly IMapper mapper;

        public DataAktarimBusiness(IDataAktarimService dataAktarimService, IMapper mapper)
        {
            this.dataAktarimService = dataAktarimService;
            this.mapper = mapper;
        }

        public async Task<WebSiteBilgileriVM> WebSiteBilgileriniGetir()
        {
            return await dataAktarimService.GetWebSiteBilgileri();

        }

        public async Task<WebSiteVM> WebSiteArama(WebSiteVM webSiteVM)
        {
            return await dataAktarimService.WebSiteArama(webSiteVM);

        }

        public async Task<int> DurumGuncelle(int id)
        {

            return await dataAktarimService.DurumGuncelle(id);


        }
        public async Task<List<WebSiteAramaSonucVM>> WebSiteListesiniGetir()
        {

            return await dataAktarimService.WebSiteListesiniGetir();


        }
        public async Task<UrunLinkIslemBilgileriVM> UrunLinkBilgileriniGetir()
        {

            return await dataAktarimService.GetUrunLinkBilgileri();


        }
        public async Task<UrunLinkIslemVM> UrunLinkArama(UrunLinkIslemVM UrunLinkIslemVM)
        {
            return await dataAktarimService.UrunLinkArama(UrunLinkIslemVM);

        }

        public async Task<int> UrunLinkDurumGuncelle(int id)
        {

            return await dataAktarimService.UrunLinkDurumGuncelle(id);


        }
        public async Task<HataLogVM> HataLogArama(HataLogVM HataLogVM)
        {
            return await dataAktarimService.HataLogArama(HataLogVM);

        }
    }
 }
