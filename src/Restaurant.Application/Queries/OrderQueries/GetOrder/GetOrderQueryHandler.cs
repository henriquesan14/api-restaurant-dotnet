using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Queries.OrderQueries.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            Order order;
            if (request.OrderType == Core.Enums.OrderTypeEnum.COMMON)
            {
                order = await _unitOfWork.Orders.GetCommonOrderByIdAsync(request.Id);
                return _mapper.Map<OrderViewModel>(order);
            }
            order = await _unitOfWork.Orders.GetDeliveryOrderByIdAsync(request.Id);
            return _mapper.Map<OrderViewModel>(order);

        }
    }
}
