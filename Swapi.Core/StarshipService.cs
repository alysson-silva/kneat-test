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

        /// <summary>
        ///     Lists and calculates for each starship how many stops must be done for resupply.
        /// </summary>
        /// <param name="distanceInMglu">Travel's distance in MGLU</param>
        /// <returns>List of starships and their number of necessary stops.</returns>
        public async Task<List<StarshipStops>> ListStarshipsAndStopsAsync(long distanceInMglu)
        {
            var gateway = new SwapiGateway(_mapper);
            var starships = await gateway.GetStarshipsAsync();

            return starships
                .Select(starship => new StarshipStops(starship.Name, starship.AmmountOfStops(distanceInMglu))).ToList();
        }
    }
}