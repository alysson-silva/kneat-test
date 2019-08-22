using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swapi.Core
{
    public interface ISwapiGateway
    {
        Task<IEnumerable<Starship>> GetStarshipsAsync();
    }
}