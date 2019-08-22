using System;

namespace Swapi.Domain
{
    public class Starship
    {
        public string Name { get; set; }
        public long? Mglt { get; set; }
        public TimeSpan? Consumables { get; set; }

        public long? AmmountOfStops(long distanceInMglt)
        {
            if (!Mglt.HasValue || Mglt == 0 || Consumables.GetValueOrDefault(TimeSpan.Zero) == TimeSpan.Zero)
            {
                return null;
            }

            return (long?) (distanceInMglt / Mglt / Consumables.GetValueOrDefault().TotalHours);
        }
    }
}