using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using BlazorMediatorDemo.Core.ViewModels;
using MediatR;

namespace BlazorMediatorDemo.Core.Queries
{
    public class GetForecast : IRequest<WeatherForecast[]>
    {
        public int PageSize { get; set; }

        public GetForecast(int pageSize = 5)
        {
            this.PageSize = pageSize;
        }
    }

    public class GetForecastHandler : IRequestHandler<GetForecast, WeatherForecast[]>
    {

        private readonly HttpClient _httpClient;

        public GetForecastHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecast[]> Handle(GetForecast request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            return response?.Take(request.PageSize).ToArray();
        }
    }
}