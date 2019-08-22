using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Swapi.Integration.Spec;

namespace Swapi.Integration.Impl
{
    public class SwapiGateway : ISwapiGateway
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

        public async Task<IEnumerable<Domain.Starship>> GetStarshipsAsync()
        {
            var response = await HttpClient.GetAsync("starships");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsAsync<ListWrapper<Starship>>();

            return _mapper.Map<List<Domain.Starship>>(data.Results);
        }
    }
}