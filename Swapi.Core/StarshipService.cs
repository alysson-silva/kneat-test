using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Swapi.Core
{
    public class StarshipService
    {
        private readonly IMapper _mapper;

        public StarshipService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<StarshipStops>> ListStarshipsAndStopsAsync(long distanceInMglu)
        {
            var gateway = new SwapiGateway(_mapper);
            var starships = await gateway.GetStarshipsAsync();

            return starships
                .Select(starship => new StarshipStops(starship.Name, starship.AmmountOfStops(distanceInMglu))).ToList();
        }
    }
}