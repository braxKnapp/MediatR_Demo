using System.Threading;
using System.Threading.Tasks;
using BlazorMediatorDemo.Core.Services;
using MediatR;

namespace BlazorMediatorDemo.Core.Queries
{
    /// <summary>
    /// Uses IRequest from MediatR
    /// </summary>
    public class GetClickCounter : IRequest<int> { }

    /// <summary>
    /// Handler for the GetClickCounter Request. Uses IRequestHandler from MediatR
    /// </summary>
    public class GetClickCounterHandler : IRequestHandler<GetClickCounter, int>
    {

        private readonly ICacheManager cacheManager;

        public GetClickCounterHandler(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
        }



        /// <summary>
        /// IRequestHandler Implemented Handle Method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Count of clicks stored in CacheManager</returns>
        public Task<int> Handle(GetClickCounter request, CancellationToken cancellationToken)
        {
            return Task.FromResult(cacheManager.GetClickCount());
        }
    }
}