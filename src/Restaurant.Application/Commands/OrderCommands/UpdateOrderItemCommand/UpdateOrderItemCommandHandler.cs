using AutoMapper;
using MediatR;
using Restaurant.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Commands.OrderCommands.UpdateOrderItemCommand
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, int>
    {
        private IOrderItemRepository _repository;
        private IMapper _mapper;

        public UpdateOrderItemCommandHandler(IOrderItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.OrderItemId);
            if (item == null)
            {
                return 0;
            }
            var itemUpdate = _mapper.Map(request, item);
            await _repository.UpdateAsync(itemUpdate);
            return item.Id;
        }
    }
}
