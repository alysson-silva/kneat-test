using System;
using AutoMapper;
using Swapi.Core;
using Swapi.CrossCutting.Converters;
using Swapi.CrossCutting.Resolvers;

namespace Swapi.CrossCutting.Profiles
{
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