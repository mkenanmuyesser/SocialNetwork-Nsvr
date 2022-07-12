using AutoMapper;
using NeSever.Common.Models.FrontEnd;
using NeSever.Common.Models.Icerik;
using NeSever.Common.Models.Satis;
using NeSever.Common.Models.Sayfa;
using NeSever.Common.Models.Urun;
using NeSever.Common.Models.Uyelik;
using NeSever.Data.Entities;
using NeSever.Data.Entities.RawEntities;

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
            CreateMap<Kullanici, KullaniciKayitVM>().ReverseMap();
            CreateMap<Kullanici, KullaniciVM>().ReverseMap();
            CreateMap<Kullanici, KullaniciKisiselBilgiVM>().ReverseMap();
            CreateMap<KullaniciSehir, KullaniciSehirVM>().ReverseMap();
            CreateMap<KullaniciResim, KullaniciResimVM>().ReverseMap();

            //Sayfa Mappings

            CreateMap<BlogKategori, BlogKategoriVM>().ReverseMap();
            CreateMap<Blog, BlogKayitVM>().ReverseMap();
            CreateMap<BlogResim, BlogResimVM>().ReverseMap();
            CreateMap<Urun, NeSever.Common.Models.Sayfa.UrunVM>().ReverseMap();
            CreateMap<Urun, NeSever.Common.Models.Urun.UrunVM>().ReverseMap();
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

            CreateMap<Siparis, SiparisGetirVM>().ReverseMap();
            CreateMap<SiparisDetay, SiparisDetayVM>().ReverseMap();
            CreateMap<Adres, SiparisAdresVM>().ReverseMap();
            CreateMap<SiparisHareket, SiparisHareketVM>().ReverseMap();

            #endregion

        }
    }
}
