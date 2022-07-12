using AutoMapper;
using NeSever.Common.Models.Katalog;
using NeSever.Data.DataService.Katalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeServer.Business.Katalog
{
    public interface IKatalogBusiness
    {
        Task<List<MarkaAramaResultVM>> MarkaArama(MarkaAramaVM markaAramaVM);
        Task<int> MarkaGuncelle(MarkaVM data);


        Task<MarkaVM> MarkaGetirById(int id);

        Task<List<MarkaVM>> MarkaListesiGetir();
    }

    public class KatalogBusiness : BaseBusiness, IKatalogBusiness
    {
        private readonly IKatalogDataService katalogDataService;
        private readonly IMapper mapper;

        public KatalogBusiness(IKatalogDataService katalogDataService, IMapper mapper)
        {
            this.katalogDataService = katalogDataService;
            this.mapper = mapper;
        }

        #region Marka
        public async Task<List<MarkaAramaResultVM>> MarkaArama(MarkaAramaVM markaAramaVM)
        {

            return await katalogDataService.GetMarkaList(markaAramaVM);
    

        }

        public async Task<int> MarkaGuncelle(MarkaVM data)
        {

            return await katalogDataService.MarkaGuncelle(data);


        }
        public async Task<MarkaVM> MarkaGetirById(int id)
        {

            return await katalogDataService.GetMarkaById(id);


        }

        public async Task<List<MarkaVM>> MarkaListesiGetir()
        {

            return await katalogDataService.GetMarkaList();


        }
        #endregion
    }


}
