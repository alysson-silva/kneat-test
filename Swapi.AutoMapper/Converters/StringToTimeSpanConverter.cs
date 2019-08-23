using System;
using System.Linq;
using AutoMapper;

namespace Swapi.AutoMapper.Converters
{
    /// <summary>
    ///     Converts a String to a TimeSpan. Returns null if the string is "unknown".
    /// </summary>
    public class StringToTimeSpanConverter : ITypeConverter<string, TimeSpan?>
    {
        public TimeSpan? Convert(string source, TimeSpan? destination, ResolutionContext context)
        {
            if ("unknown".Equals(source)) return null;

            var number = long.Parse(source.Split(" ").First());
            var range = source.Split(" ").Last();

            return ToTimeSpanFunction(range)(number);
        }

        /// <summary>
        ///     Returns a function capable of creating a new Timespan based on a duration and its unit.
        /// </summary>
        /// <param name="unit">A time unit like days, years...</param>
        /// <returns>A timespan representing the duration.</returns>
        /// <exception cref="NotImplementedException">Thrown when received an unexpected unit.</exception>
        private static Func<double, TimeSpan> ToTimeSpanFunction(string unit)
        {
            switch (unit.ToLower())
            {
                case "year":
                case "years":
                    return number => TimeSpan.FromDays(number * 365d);
                case "month":
                case "months":
                    return number => TimeSpan.FromDays(number * 30d);
                case "week":
                case "weeks":
                    return number => TimeSpan.FromDays(number * 7d);
                case "day":
                case "days":
                    return TimeSpan.FromDays;
                case "hour":
                case "hours":
                    return TimeSpan.FromHours;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}