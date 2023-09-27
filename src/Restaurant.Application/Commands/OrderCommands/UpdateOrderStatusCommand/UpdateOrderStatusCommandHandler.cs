using AutoMapper;
using MediatR;
using Restaurant.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Commands.OrderCommands.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var item = await _orderRepository.GetByIdAsync(request.Id);
            if (item == null)
            {
                return 0;
            }
            var itemUpdate = _mapper.Map(request, item);
            await _orderRepository.UpdateAsync(itemUpdate);
            return item.Id;
        }
    }
}
