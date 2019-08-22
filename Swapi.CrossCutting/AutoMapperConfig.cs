using AutoMapper;
using Swapi.CrossCutting.AutoMapper.Profiles;

namespace Swapi.CrossCutting
{
    public static class AutoMapperConfig
    {
        public static IMapper Config()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ListWrapperProfile>();
                cfg.AddProfile<StarshipProfile>();
                cfg.Advanced.AllowAdditiveTypeMapCreation = true;
            });

#if DEBUG
            configuration.AssertConfigurationIsValid();
#endif

            return configuration.CreateMapper();
        }
    }
}