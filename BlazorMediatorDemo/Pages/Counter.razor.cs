using System.Threading.Tasks;
using BlazorMediatorDemo.Core.Commands;
using BlazorMediatorDemo.Core.Queries;
using Microsoft.AspNetCore.Components;

namespace BlazorMediatorDemo.Pages
{
    public partial class Counter : ComponentBase
    {
        private int currentCount = 0;

        protected override async Task OnInitializedAsync()
        {
            currentCount = await _mediator.Send(new GetClickCounter());
        }

        async Task IncrementCount()
        {
            currentCount = await _mediator.Send(new IncrementClickCounter());
        }
    }
}