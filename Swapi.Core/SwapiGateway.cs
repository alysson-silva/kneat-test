using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;

namespace Swapi.Core
{
    public class SwapiGateway
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private readonly IMapper _mapper;

        public SwapiGateway(IMapper mapper)
        {
            _mapper = mapper;

            HttpClient.BaseAddress = new Uri("https://swapi.co/api/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Starship>> GetStarshipsAsync()
        {
            var starships = new List<StarshipResponse>();

            await GetAllPagesAsync("starships", starships);

            return _mapper.Map<List<Starship>>(starships);
        }

        private static async Task GetAllPagesAsync<T>(string requestUri, List<T> list) where T : class
        {
            var response = await HttpClient.GetAsync($"{requestUri}");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsAsync<ListWrapperResponse<T>>();

            list.AddRange(data.Results);

            if (data.Next != null) await GetAllPagesAsync(data.Next, list);
        }
    }
}