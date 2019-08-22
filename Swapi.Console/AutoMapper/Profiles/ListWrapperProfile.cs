using System;
using AutoMapper;
using Swapi.Console.AutoMapper.Converters;

namespace Swapi.Console.AutoMapper.Profiles
{
    public class ListWrapperProfile : Profile
    {
        public ListWrapperProfile()
        {
            CreateMap<string, Uri>().ConvertUsing<StringToUriTypeConverter>();
        }
    }
}