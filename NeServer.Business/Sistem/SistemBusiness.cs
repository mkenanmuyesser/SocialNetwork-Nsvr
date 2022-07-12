using NeSever.Common.Models;
using NeSever.Common.Models.DataAktarim;
using NeSever.Common.Models.Sistem;
using NeSever.Data.DataService.Sistem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeServer.Business.Sistem
{
    public interface ISistemBusiness
    {
        Task<List<TreeViewNodeModel>> KategoriTreeViewListesiniGetir();

        Task<List<DataKategoriAramaResultVM>> DataKategoriListesiGetir(DataKategoriAramaVM dataKategoriAramaVM);
        Task<int> GuncelleDataKategoriIsActive(int id, bool isActive);
        Task<int>  GuncelleDataKategoriTargetCategory(int id, int targetCategoryId);
        Task<int> DataKategoriTargetCategorySil(int id);
        Task<ResultModel> CacheTemizleme(CacheTemizleme vm);
    }
    public class SistemBusiness : BaseBusiness, ISistemBusiness
    {
        private readonly ISistemDataService  sistemDataService;

        public SistemBusiness(ISistemDataService sistemDataService)
        {
            this.sistemDataService = sistemDataService;
        }

        public async Task<List<TreeViewNodeModel>> KategoriTreeViewListesiniGetir()
        {
            return await sistemDataService.GetKategoriTreeViewList();

        }
        public async Task<List<DataKategoriAramaResultVM>> DataKategoriListesiGetir(DataKategoriAramaVM dataKategoriAramaVM)
        {
            return await sistemDataService.GetDataKategoriList(dataKategoriAramaVM);

        }
        public async Task<int> GuncelleDataKategoriIsActive(int id, bool isActive)
        {
            return await sistemDataService.UpdateDataKategoriIsActive(id,isActive);

        }
        public async Task<int> GuncelleDataKategoriTargetCategory(int id, int targetCategoryId)
        {
            return await sistemDataService.UpdateDataKategoriTargetCategory(id, targetCategoryId);

        }
        public async Task<int> DataKategoriTargetCategorySil(int id)
        {

            return await sistemDataService.DataKategoriTargetCategorySil(id);

        }
        public async Task<ResultModel> CacheTemizleme(CacheTemizleme vm)
        {
            return await sistemDataService.CacheTemizleme(vm);            
        }
    }
}
