using System.Threading.Tasks;
using Swapi.Core;
using Swapi.CrossCutting;

namespace Swapi.Console
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            ISwapiGateway swapiGateway = new SwapiGateway(AutoMapperConfig.Config());

            var starships = await swapiGateway.GetStarshipsAsync();

            if (args.Length != 1 || !long.TryParse(args[0], out var distanceInMglu)) distanceInMglu = 1_000_000L;

            foreach (var starship in starships)
            {
                var ammountOfStops = starship.AmmountOfStops(distanceInMglu)?.ToString() ?? "unknown";
                System.Console.WriteLine("{0, -30}{1, 10}", starship.Name, ammountOfStops);
            }
        }
    }
}