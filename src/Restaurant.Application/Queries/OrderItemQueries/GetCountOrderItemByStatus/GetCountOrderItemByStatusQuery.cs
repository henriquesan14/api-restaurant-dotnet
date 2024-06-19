using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Queries.OrderItemQueries.GetCountOrderItemByStatus
{
    public class GetCountOrderItemByStatusQuery : IRequest<CountOrderItemViewModel>
    {
        public GetCountOrderItemByStatusQuery(OrderItemStatusEnum status)
        {
            Status = status;
        }

        public OrderItemStatusEnum Status { get; set; }
    }
}
