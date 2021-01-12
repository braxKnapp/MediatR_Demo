using System.Threading;
using System.Threading.Tasks;
using BlazorMediatorDemo.Core.Services;
using MediatR;

namespace BlazorMediatorDemo.Core.Commands
{
    /// <summary>
    /// Uses IRequest from MediatR
    /// </summary>
    public class IncrementClickCounter : IRequest<int> { }

    /// <summary>
    /// Handler for the IncrementClickCounter Request. Uses IRequestHandler from MediatR
    /// </summary>
    public class IncrementClickCounterHandler : IRequestHandler<IncrementClickCounter, int>
    {

        private readonly ICacheManager cacheManager;

        public IncrementClickCounterHandler(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
        }

        /// <summary>
        /// IRequestHandler Implemented Handle Method
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Current Click Count + 1</returns>
        public Task<int> Handle(IncrementClickCounter request, CancellationToken cancellationToken)
        {
            return Task.FromResult(cacheManager.IncrementClickCount());
        }
    }
}