using AutoMapper;

namespace Tests.Lib
{
    public class MapperFactory
    {
        public static IMapper CreateMapper(Profile profile)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            return mapperConfig.CreateMapper();
        }
        public static IMapper CreateMapper(params Profile[] profiles)
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }                
            });
            return mapperConfig.CreateMapper();
        }
    }
}
