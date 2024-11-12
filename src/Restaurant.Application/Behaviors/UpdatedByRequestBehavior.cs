using MediatR;
using Restaurant.Application.Identity;
using Restaurant.Core.Request;

namespace Restaurant.Application.Behaviors
{
    public class UpdatedByBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly AuthenticatedUser _authenticatedUser;

        public UpdatedByBehavior(AuthenticatedUser authenticatedUser)
        {
            _authenticatedUser = authenticatedUser;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is IUpdatedByRequest createdRequest)
            {
                createdRequest.UpdatedByUserId = _authenticatedUser.Id;
            }

            return await next();
        }
    }
}
