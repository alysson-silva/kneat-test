using AutoMapper;
using Swapi.Domain;

namespace Swapi.CrossCutting.AutoMapper.Resolvers
{
    public class MgltResolver : IValueResolver<Integration.Spec.Starship, Starship, long?>
    {
        public long? Resolve(Integration.Spec.Starship source, Starship destination, long? destMember, ResolutionContext context)
        {
            return "unknown".Equals(source.Mglt)
                ? null
                : context.Mapper.Map<long?>(source.Mglt);
        }
    }
}