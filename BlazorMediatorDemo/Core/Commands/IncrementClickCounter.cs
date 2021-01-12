using System.Threading;
using System.Threading.Tasks;
using BlazorMediatorDemo.Core.Services;
using MediatR;

namespace BlazorMediatorDemo.Core.Commands
{
    public class IncrementClickCounter : IRequest<int>{}

    public class IncrementClickCounterHandler : IRequestHandler<IncrementClickCounter, int>
    {

        private readonly ICacheManager cacheManager;

        public IncrementClickCounterHandler(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
        }

        public Task<int> Handle(IncrementClickCounter request, CancellationToken cancellationToken)
        {
            return Task.FromResult(cacheManager.IncrementClickCount());
        }
    }
}