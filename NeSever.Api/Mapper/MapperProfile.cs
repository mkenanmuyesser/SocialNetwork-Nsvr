using AutoMapper;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Satis;
using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Urun;
using NeSever.Common.Models.Uyelik;
using NeSever.Data.Entities;
using NeSever.Data.Entities.RawEntities;

//Important note : Being a running and alive project, some codes were removed by me. If you want some detail, please just inform me

namespace NeSever.Api.Mapper
{
    public class MapperProfile :  Profile
    {
        public MapperProfile()
        {
            #region Raw Mappings

            #region Arkadas Mappings
            CreateMap<ArkadasRaw, ArkadasVM>().ReverseMap();
            #endregion

            #region Urun Raw Mappings
            CreateMap<UrunRaw, UrunIcerikVM>().ReverseMap();
            #endregion

            #region Urun Icerik Raw Mappings
            CreateMap<UrunIcerikRaw, UrunIcerikVM>().ReverseMap();
            #endregion

            #region Urun Detay Icerik Raw Mappings
            CreateMap<UrunIcerikRaw, UrunDetayIcerikVM>().ReverseMap();
            CreateMap<UrunDetayIcerikRaw, UrunDetayIcerikVM>().ReverseMap();
            #endregion

            #region Uyelik Raw Mappings
            CreateMap<ProfilRaw, ProfilSagMenuUyeVM>().ReverseMap();
            #endregion

            #endregion

            //Uyelik Mappings 
			
            CreateMap<KullaniciResim, KullaniciResimVM>().ReverseMap();

            //Sayfa Mappings

            CreateMap<BlogKategori, BlogKategoriVM>().ReverseMap();
            CreateMap<Blog, BlogKayitVM>().ReverseMap();
            CreateMap<BannerTip, BannerTipVM>().ReverseMap();
            CreateMap<Banner, BannerKayitVM>().ReverseMap();
            CreateMap<HediyeKart, HediyeKartVM>().ReverseMap();
            CreateMap<Hobi, HobiVM>().ReverseMap();
            CreateMap<Kategori, KategoriVM>().ReverseMap();
            CreateMap<IlgiAlan, IlgiAlanVM>().ReverseMap();
            CreateMap<UrunKategori, UrunKategoriVM>().ReverseMap();
            CreateMap<HediyeKartKategori, HediyeKartKategoriVM>().ReverseMap();
            CreateMap<Bildirim, KullaniciBildirimVM>().ReverseMap();
            CreateMap<UrunResim, UrunResimVM>().ReverseMap();
            CreateMap<KategoriBanner, KategoriBannerVM>().ReverseMap();
            CreateMap<IndirimKuponu, IndirimKuponuKayitVM>().ReverseMap();

            #region Siparis

            CreateMap<SiparisHareket, SiparisHareketVM>().ReverseMap();

            #endregion

        }
    }
}
