using AutoMapper;
using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Commands.OrderCommands.CreateCommonOrder
{
    public class CreateCommonOrderCommandHandler : IRequestHandler<CreateCommonOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public CreateCommonOrderCommandHandler(IOrderRepository orderRepository, ITableRepository tableRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCommonOrderCommand request, CancellationToken cancellationToken)
        {
            // TODO: implementar lógica de autorização
            var entity = _mapper.Map<CommonOrder>(request);
            entity.Status = Core.Enums.OrderStatus.PENDING;
            entity.EmployeeId = request.EmployeeId;
            entity.Type = "Common";
            entity.Items.ToList().ForEach(i =>
            {
                i.Status = Core.Enums.ItemOrderStatus.PENDING;
                i.CreatedAt = DateTime.Now;
            });
            
            await _tableRepository.UpdateStatusAsync(entity.TableId, Core.Enums.TableStatus.BUSY);
            var result = await _orderRepository.AddAsync(entity);
            return result.Id;
        }
    }
}
