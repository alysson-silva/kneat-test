using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swapi.Integration.Spec
{
    public interface ISwapiGateway
    {
        Task<IEnumerable<Domain.Starship>> GetStarshipsAsync();
    }
}