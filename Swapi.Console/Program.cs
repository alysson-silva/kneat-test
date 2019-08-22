using System.Threading.Tasks;
using Swapi.Integration.Impl;
using Swapi.Integration.Spec;

namespace Swapi.Console
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            ISwapiGateway swapiGateway  = new SwapiGateway(AutoMapperConfig.Config());

            var starships = await swapiGateway.GetStarshipsAsync();

            foreach (var starship in starships)
            {
                System.Console.Write(starship.Name);
                System.Console.Write(" ");
                System.Console.WriteLine(starship.AmmountOfStops(1_000_000));
            }
        }
    }
}