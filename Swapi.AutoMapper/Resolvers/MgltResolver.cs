using AutoMapper;
using Swapi.Core;

namespace Swapi.CrossCutting.Resolvers
{
    /// <summary>
    ///     Parses numbers and converts them to long. Returns null if the string is "unknown".
    /// </summary>
    public class MgltResolver : IValueResolver<StarshipResponse, Starship, long?>
    {
        public long? Resolve(StarshipResponse source, Starship destination, long? destMember, ResolutionContext context)
        {
            return "unknown".Equals(source.Mglt)
                ? null
                : context.Mapper.Map<long?>(source.Mglt);
        }
    }
}