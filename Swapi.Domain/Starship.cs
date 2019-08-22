using System;

namespace Swapi.Domain
{
    public class Starship
    {
        public string Name { get; set; }
        public long Mglt { get; set; }
        public TimeSpan Consumables { get; set; }

        public long AmmountOfStops(long distanceInMglt)
        {
            return (long) (distanceInMglt / Mglt / Consumables.TotalHours);
        }
    }
}