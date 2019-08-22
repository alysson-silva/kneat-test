using System;
using AutoMapper;
using Swapi.CrossCutting.AutoMapper.Converters;
using Swapi.CrossCutting.AutoMapper.Resolvers;

namespace Swapi.CrossCutting.AutoMapper.Profiles
{
    public class StarshipProfile : Profile
    {
        public StarshipProfile()
        {
            CreateMap<string, Uri>().ConvertUsing<StringToUriTypeConverter>();

            CreateMap<string, TimeSpan?>().ConvertUsing<StringToTimeSpanConverter>();

            CreateMap<Integration.Spec.Starship, Domain.Starship>(MemberList.Destination)
                .ForMember(src => src.Mglt, dst => dst.MapFrom<MgltResolver>());
        }
    }
}