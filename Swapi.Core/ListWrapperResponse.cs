using System.Collections.Generic;

namespace Swapi.Core
{
    public class ListWrapperResponse<T> where T : class
    {
        public long Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<T> Results { get; set; }
    }
}