using AutoMapper;
using Swapi.AutoMapper.Profiles;

namespace Swapi.AutoMapper
{
    /// <summary>
    ///     AutoMapper initialization
    /// </summary>
    public static class AutoMapperConfig
    {
        public static IMapper Config()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
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