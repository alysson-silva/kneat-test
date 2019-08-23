using System.Threading.Tasks;
using Swapi.AutoMapper;
using Swapi.Core;

namespace Swapi.Console
{
    internal class Program
    {
        // ReSharper disable once AsyncConverter.AsyncMethodNamingHighlighting
        private static async Task Main()
        {
            var starshipService = new StarshipService(AutoMapperConfig.Config());

            System.Console.Write("Please type the distance in MGLU: [Default: 1000000] ");
            var input = System.Console.ReadLine();
            System.Console.WriteLine();

            if (!long.TryParse(input, out var distanceInMglu)) distanceInMglu = 1_000_000L;

            System.Console.WriteLine("Calculating for the distance {0}.", distanceInMglu);

            var starships = await starshipService.ListStarshipsAndStopsAsync(distanceInMglu);

            foreach (var starship in starships)
                System.Console.WriteLine("{0, -30}{1, 10}", starship.Name, starship.Stops);

            System.Console.ReadLine();
        }
    }
}