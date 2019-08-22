using System;
using System.Linq;
using AutoMapper;

namespace Swapi.Console.AutoMapper.Converters
{
    public class StringToTimeSpanConverter : ITypeConverter<string, TimeSpan>
    {
        public TimeSpan Convert(string source, TimeSpan destination, ResolutionContext context)
        {
            var number = long.Parse(source.Split(" ").First());
            var range = source.Split(" ").Last();
            return AddFunction(range)(number);
        }

        private static Func<double, TimeSpan> AddFunction(string range)
        {
            switch (range)
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
                default:
                    throw new NotImplementedException();
            }
        }
    }
}