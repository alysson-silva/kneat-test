using System;
using AutoMapper;
using Swapi.CrossCutting.AutoMapper.Converters;

namespace Swapi.CrossCutting.AutoMapper.Profiles
{
    public class ListWrapperProfile : Profile
    {
        public ListWrapperProfile()
        {
            CreateMap<string, Uri>().ConvertUsing<StringToUriTypeConverter>();
        }
    }
}