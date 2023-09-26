using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Queries.OrderItemQueries.GetCountOrderItemByStatus
{
    public class GetCountOrderItemByStatusQuery : IRequest<CountOrderItemViewModel>
    {
        public GetCountOrderItemByStatusQuery(OrderItemStatus status)
        {
            Status = status;
        }

        public OrderItemStatus Status { get; set; }
    }
}
