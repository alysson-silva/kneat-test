using System;
using AutoMapper;

namespace Swapi.CrossCutting.AutoMapper.Converters
{
    public class StringToUriTypeConverter : ITypeConverter<string, Uri>
    {
        public Uri Convert(string source, Uri destination, ResolutionContext context)
        {
            return new Uri(source);
        }
    }
}