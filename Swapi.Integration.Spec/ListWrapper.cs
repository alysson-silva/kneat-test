using System.Collections.Generic;

namespace Swapi.Integration.Spec
{
    public class ListWrapper<T> where T : class
    {
        public long Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<T> Results { get; set; }
    }
}