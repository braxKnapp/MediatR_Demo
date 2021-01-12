using System.Threading;
using System.Threading.Tasks;
using BlazorMediatorDemo.Core.Services;
using MediatR;

namespace BlazorMediatorDemo.Core.Queries
{
    public class GetClickCounter : IRequest<int>{}

    public class GetClickCounterHandler : IRequestHandler<GetClickCounter, int>
    {

        private readonly ICacheManager cacheManager;

        public GetClickCounterHandler(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
        }

        public Task<int> Handle(GetClickCounter request, CancellationToken cancellationToken)
        {
            return Task.FromResult(cacheManager.GetClickCount());
        }
    }
}