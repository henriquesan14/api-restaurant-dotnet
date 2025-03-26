using Microsoft.Extensions.DependencyInjection;
using Restaurant.Core.Common;
using Restaurant.Core.EventHandlers;

namespace Restaurant.Infra.Events
{
    public class DomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handlers = _serviceProvider.GetServices(handlerType);

                foreach (var handler in handlers)
                {
                    // Invoca o método Handle dinamicamente
                    var handleMethod = handlerType.GetMethod("Handle");
                    if (handleMethod != null)
                    {
                        await (Task)handleMethod.Invoke(handler, new object[] { domainEvent });
                    }
                }
            }
        }
    }
}
