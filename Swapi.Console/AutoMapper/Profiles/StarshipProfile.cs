using System;
using AutoMapper;
using Swapi.Console.AutoMapper.Converters;
using Swapi.Integration.Spec;

namespace Swapi.Console.AutoMapper.Profiles
{
    public class StarshipProfile : Profile
    {
        public StarshipProfile()
        {
            CreateMap<string, Uri>().ConvertUsing<StringToUriTypeConverter>();

            CreateMap<string, TimeSpan>().ConvertUsing<StringToTimeSpanConverter>();

            CreateMap<Starship, Domain.Starship>(MemberList.Destination);
        }
    }
}