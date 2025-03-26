using Restaurant.Core.Entities;
using Restaurant.Core.EventHandlers;
using Restaurant.Core.Events;
using Restaurant.Core.Repositories;
using System.Linq.Expressions;

namespace Restaurant.Application.EventHandlers
{
    public class LowStockEventHandler : IDomainEventHandler<LowStockEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LowStockEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(LowStockEvent domainEvent)
        {
            Expression<Func<User, bool>> predicate = (e => e.Role.Name.Equals("Admin"));
            var users = await _unitOfWork.Users.GetAllAsync();
            

            foreach (var user in users)
            {
                var notification = new Notification(
                    userId: user.Id,
                    title: "Estoque Baixo",
                    message: $"O produto '{domainEvent.ProductName}' está com estoque baixo. A quantidade atual é {domainEvent.CurrentStock}.",
                    redirectUrl: "/estoque"
                );

                await _unitOfWork.Notifications.AddAsync(notification);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
