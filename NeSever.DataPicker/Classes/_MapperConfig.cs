using AutoMapper;

namespace DataPickerProject.Classes
{
    public static class MapperConfig
    {
        public static IMapper Config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AllowNullCollections = true;
                cfg.CreateMap<DBTarget.DataUrun, DBTarget.Urun>().ForMember(dest => dest.UrunId, option => option.UseDestinationValue());
                //cfg.CreateMap<List<DBSource.Product>, List<DBTarget.Product>>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }

    }
}
