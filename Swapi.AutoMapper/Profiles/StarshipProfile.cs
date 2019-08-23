using System;
using AutoMapper;
using Swapi.AutoMapper.Converters;
using Swapi.AutoMapper.Resolvers;
using Swapi.Core;

namespace Swapi.AutoMapper.Profiles
{
    /// <summary>
    ///     Responsible for mapping all things related to <see cref="Starship" />.
    /// </summary>
    public class StarshipProfile : Profile
    {
        public StarshipProfile()
        {
            CreateMap<string, TimeSpan?>().ConvertUsing<StringToTimeSpanConverter>();

            CreateMap<StarshipResponse, Starship>(MemberList.Destination)
                .ForMember(src => src.Mglt, dst => dst.MapFrom<MgltResolver>());
        }
    }
}