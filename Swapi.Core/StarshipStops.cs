namespace Swapi.Core
{
    public class StarshipStops
    {
        public StarshipStops(string name, string stops)
        {
            Name = name;
            Stops = stops;
        }

        public string Name { get; set; }
        public string Stops { get; set; }
    }
}