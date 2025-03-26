using Restaurant.Core.Common;

namespace Restaurant.Core.EventHandlers
{
    public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
