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
    /// <summary>
    /// Uses IRequest from MediatR
    /// </summary>
    public class GetForecast : IRequest<WeatherForecast[]>
    {
        public int PageSize { get; set; }

        public GetForecast(int pageSize = 5)
        {
            this.PageSize = pageSize;
        }
    }

    /// <summary>
    /// Handler for the GetForecast Request. Uses IRequestHandler from MediatR
    /// </summary>
    public class GetForecastHandler : IRequestHandler<GetForecast, WeatherForecast[]>
    {

        private readonly HttpClient _httpClient;

        public GetForecastHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        /// <summary>
        /// IRequestHandler Implemented Handle Method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>WeatherForecast array of designated size</returns>
        public async Task<WeatherForecast[]> Handle(GetForecast request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            return response?.Take(request.PageSize).ToArray();
        }
    }
}