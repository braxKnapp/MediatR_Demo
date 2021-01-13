using System.Threading.Tasks;
using BlazorMediatorDemo.Core.Queries;
using BlazorMediatorDemo.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorMediatorDemo.Pages
{
    public partial class FetchData : ComponentBase
    {
        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await _mediator.Send(new GetForecast(pageSize: 5));
        }
    }
}