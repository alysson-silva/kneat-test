using System.Collections.Generic;

namespace Swapi.Core
{
    /// <summary>
    ///     A wrapper for lists. Provides a count and urls for the previous and next pages.
    /// </summary>
    /// <typeparam name="T">The type being wrapped by the list.</typeparam>
    public class ListWrapperResponse<T> where T : class
    {
        public long Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<T> Results { get; set; }
    }
}