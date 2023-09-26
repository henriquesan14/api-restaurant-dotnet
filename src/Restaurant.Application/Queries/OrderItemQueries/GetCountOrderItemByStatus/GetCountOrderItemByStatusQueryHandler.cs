using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.OrderItemQueries.GetCountOrderItemByStatus
{
    public class GetCountOrderItemByStatusQueryHandler : IRequestHandler<GetCountOrderItemByStatusQuery, CountOrderItemViewModel>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetCountOrderItemByStatusQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<CountOrderItemViewModel> Handle(GetCountOrderItemByStatusQuery request, CancellationToken cancellationToken)
        {
            var count = await _orderItemRepository.GetCountOrderItemsByStatus((int)request.Status);
            return new CountOrderItemViewModel{
                Status = request.Status,
                Count = count
            }; 
        }
    }
}
